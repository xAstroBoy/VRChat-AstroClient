namespace AstroClient
{
	using AstroClient.ModDetector;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using FavCat.Database.Stored;
	using FavCat.Modules;
	using MelonLoader;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	public class Favcat_Utils : GameEvents
	{

		public override void OnSceneLoaded(int buildIndex, string sceneName)
		{
			if (IsRunning)
			{
				if (coroutinetoken != null)
				{
					MelonCoroutines.Stop(coroutinetoken);
				}
				IsRunning = false;
			}
		}
		private static bool _IsRunning;

		private static bool IsRunning
		{
			get
			{
				return _IsRunning;
			}
			set
			{
				_IsRunning = value;
				if(!value)
				{
					coroutinetoken = null;
				}
			}
		}
		private static object coroutinetoken;

		public static void Run_RevealWorldPedestrials()
		{
			if (!IsRunning)
			{
				coroutinetoken = MelonCoroutines.Start(RevealWorldPedestrals());
			}
			else
			{
				ModConsole.DebugLog("The Coroutine is already Running!");
			}
		}

		private static System.Collections.IEnumerator RevealWorldPedestrals()
		{
			
			if(!FindMods.Favcat_Unchained_Present)
			{
				IsRunning = false;
				yield return null;
			}
			if(IsRunning)
			{
				yield return null;
			}
			IsRunning = true;
			var ids = WorldUtils.Get_World_Pedestrals_Avatar_ids();
			if (ids.Count() != 0)
			{
				System.Collections.Generic.List<StoredAvatar> StoredAvatars = new System.Collections.Generic.List<StoredAvatar>();
				System.Action<StoredAvatar> StoredAvatarAction = default(System.Action<StoredAvatar>);
				foreach (string id in ids)
				{
					System.Action<StoredAvatar> result;
					if ((result = StoredAvatarAction) == null)
					{
						result = (StoredAvatarAction = delegate (StoredAvatar avatar)
						{
							if (!StoredAvatars.Select((StoredAvatar o) => o.AvatarId).Contains(avatar.AvatarId))
							{
								StoredAvatars.Add(avatar);
							}
						});
					}
					ModConsole.DebugLog("Found AvatarID : " + id);
					AvatarModule.GetStoredFromID(id, result);
				}
				int Attemptcount = 0;
				int previousidcount = 0;
				int limit = 10;
				while (StoredAvatars.Count < ids.Count)
				{
					var avatarcount = StoredAvatars.Count;
					if (previousidcount == avatarcount)
					{
						Attemptcount++;
					}
					else
					{
						previousidcount = avatarcount;
						Attemptcount = 0;
					}
					if (Attemptcount == limit)
					{
						ModConsole.DebugLog("Attempt Count Limit reached, Skipping...");
						break;
					}
					else
					{
						ModConsole.DebugLog("Waiting On Pedestal Dump To Load Pedestals Into Avatar Menu.. - Current Count: " + StoredAvatars.Count + "/" + ids.Count);
						ModConsole.DebugLog($"Attempt of {Attemptcount} / {limit}...");
					}
					yield return new WaitForSeconds(0.8f);
				}
				ModConsole.DebugLog("Done!");
				AvatarModule.SetSearchHeader("Search running...", Scroll: false);
				AvatarModule.AvatarSearchResults("Avatar Pedestals From: " + WorldUtils.Get_World_Name(), StoredAvatars);
				yield return new WaitForSeconds(1f);
				AvatarModule.SetSearchHeader("Avatar Pedestals From: " + WorldUtils.Get_World_Name() , false);
				IsRunning = false;
				yield return null;
			}
			else
			{
				ModConsole.Warning("This world Doesn't have Pedestrals!");
				IsRunning = false;
				yield return null;
			}
			IsRunning = false;
			yield return null;
		}

	}
}
