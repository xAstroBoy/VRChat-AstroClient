﻿namespace AstroClient.Components
{
	using AstroClient.components;
	using AstroClient.ConsoleUtils;
	using DayClientML2.Utility.Extensions;
	using System.Collections.Generic;
	using System.Linq;
	using VRC;
	using VRC.Core;

	internal class SingleTagsUtils : GameEvents
	{
		public override void OnLevelLoaded()
		{
			Counter.Clear();
		}

		public override void OnPlayerLeft(Player player)
		{
			if (player != null)
			{
				var entry = GetEntry(player);
				if (entry != null)
				{
					RemoveCounter(entry);
				}
			}
		}

		public static PlayerTagCounter GetEntry(Player player)
		{
			return Counter.Where(x => x.Player == player).DefaultIfEmpty(null).First();
		}

		private static readonly bool DebugMode = false;

		public static void Debug(string msg)
		{
			if (DebugMode)
			{
				ModConsole.DebugLog($"SingleTagsUtils Debug : {msg}");
			}
		}

		public static SingleTag AddSingleTag(Player player)
		{
			SingleTag newtag = null;
			if (player != null)
			{
				bool AddNewPlayer = false;
				newtag = player.gameObject.AddComponent<SingleTag>();
				int stack = 2;
				Debug("Searching for Entries To Parse stack order...");
				// I HOPE THIS WORKS CAUSE WHY TF IT DOESNT COUNT EM
				var entry = GetEntry(player);
				if (entry != null)
				{
					Debug($"Found existing stack for {player.DisplayName()} having current stack value : {entry.AssignedStack}");
					entry.AssignedStack++;
					stack = entry.AssignedStack;
				}
				else
				{
					Debug($"No Entry Found for player {player.DisplayName()} , using default stack value {stack} for generated SingleTag");
					AddNewPlayer = true;
				}
				Debug($"Assigned to newly Generated SingleTag a stack value of {stack}");

				newtag.InternalStack = stack;
				if (AddNewPlayer)
				{
					var addme = new PlayerTagCounter(player, stack);
					if (Counter != null)
					{
						if (!Counter.Contains(addme))
						{
							Debug($"Added New Entry for Player : {player.GetAPIUser().DisplayName()} using stack {addme.AssignedStack}");
							Counter.Add(addme);
						}
					}
				}
			}
			return newtag;
		}

		public static List<PlayerTagCounter> GetAssignedTagsToPlayer(Player player)
		{
			List<PlayerTagCounter> AssignedTags = new List<PlayerTagCounter>();
			if (player != null)
			{
				foreach (var tag in Counter)
				{
					if (tag != null && tag.Player != null)
					{
						if (tag.Player == player)
						{
							AssignedTags.Add(tag);
						}
					}
				}
			}
			return AssignedTags;
		}

		public static List<PlayerTagCounter> Counter = new List<PlayerTagCounter>();

		public static void RemoveCounter(PlayerTagCounter entry)
		{
			if (entry != null)
			{
				if (Counter.Contains(entry))
				{
					Counter.Remove(entry);
				}
			}
		}

		public class PlayerTagCounter
		{
			public Player Player { get; set; }
			public int AssignedStack { get; set; }

			public PlayerTagCounter(Player user, int stack)
			{
				this.Player = user;
				AssignedStack = stack;
			}
		}
	}
}