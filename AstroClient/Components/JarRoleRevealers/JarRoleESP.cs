﻿namespace AstroClient.components
{
	using AstroClient.Components;
	using AstroClient.ConsoleUtils;
	using AstroClient.extensions;
	using AstroClient.Startup.Buttons;
	using DayClientML2.Utility.Extensions;
	using System;
	using System.Linq;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using UnityEngine.UI;
	using VRC;
	using VRC.Core;
	using static AstroClient.JarRoleController;
	using Object = UnityEngine.Object;

	public class JarRoleESP : GameEventsBehaviour
	{
		public JarRoleESP(IntPtr ptr) : base(ptr)
		{
			AntiGarbageCollection.Add(this);
		}

		private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

		// Use this for initialization
		public void Start()
		{

				var p = GetComponent<Player>();
				if (p != null)
				{
					Internal_player = p;
				}
				else
				{
					UnityEngine.Object.Destroy(this);
				}
				isRPCActive = false;
				if (Internal_player != null)
				{
					if (Internal_player.prop_APIUser_0 != null)
					{
						Internal_user = Internal_player.prop_APIUser_0;
					}
				}
				if (Internal_AssignedEntry == null)
				{
					FindEntryWithUser();
				}
				GameRoleTag = SingleTagsUtils.AddSingleTag(Internal_player);
				if (isAmongUsWorld)
				{
					AmongUSVoteRevealTag = SingleTagsUtils.AddSingleTag(Internal_player);
					AmongUSVoteRevealTag.ShowTag = false;
					AmongUSHasVoted = false;
				}
				if (JarRoleController.ViewRoles)
				{
					SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
					ResetESPColor();
					GameRoleTag.ShowTag = false;
				}
				else
				{
					SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
					ResetESPColor();
					GameRoleTag.ShowTag = false;
				}
				if (JarRoleController.IsMurder4World)
				{
					Murder4CurrentRole = Murder4Roles.Unassigned;
					ModConsole.DebugLog("Registered " + Internal_user.displayName + " On Murder 4 Role ESP.");
				}
				if (JarRoleController.isAmongUsWorld)
				{
					AmongUsCurrentRole = AmongUsRoles.Unassigned;
					ModConsole.DebugLog("Registered " + Internal_user.displayName + " On Among US Role ESP.");
				}
			
		}

		
		private static JarRoleESP TranslateSyncVotedFor(int value)
		{
			return RoleEspComponents.Where(x => x.LinkedEntry.nodevalue == value).First();
		}

		
		private static int RemoveSyncVotedForText(string key)
		{
			var removedtext = key.ToLower().Replace("syncvotedfor", string.Empty).Replace(" ", string.Empty);
			int.TryParse(removedtext, out var value);
			return value;
		}

		
		public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
		{
			if (Internal_player != null)
			{
				if (sender != null)
				{
					ModConsole.DebugLog($"JarRoleESP : {sender.DisplayName()} Sent RPC on Node {obj.name} , Matching {Internal_AssignedNode.name} assigned to {Internal_player.DisplayName()}, Having action {action}");
				}
				else
				{
					ModConsole.DebugLog($"JarRoleESP : Detected RPC on Node {obj.name} , Matching {Internal_AssignedNode.name} assigned to {Internal_player.DisplayName()} , Having action {action}");

				}
			}

			if (obj != null)
			{
				if (isAmongUsWorld)
				{
					if (Internal_AssignedNode != null)
					{

						if (obj.Equals(Internal_AssignedNode))
						{

							if (action == "SyncAssignB")
							{
								AmongUsCurrentRole = AmongUsRoles.Crewmate;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
							else if (action == "SyncAssignM")
							{
								AmongUsCurrentRole = AmongUsRoles.Impostor;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
							else if (action == "SyncKill")
							{
								AmongUsCurrentRole = AmongUsRoles.None;
								AmongUSHasVoted = false;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
							else if (action.Contains("SyncVotedFor"))
							{
								var against = TranslateSyncVotedFor(RemoveSyncVotedForText(action));
								if (against != null)
								{
									if (against != GetLocalPlayerNode())
									{
										SetTag(AmongUSVoteRevealTag, $"Voted: {against.Apiuser.displayName}", Color.white, ColorUtils.HexToColor("#44DBAC"));
									}
									else
									{
										SetTag(AmongUSVoteRevealTag, $"Voted: {against.Apiuser.displayName}", Color.white, ColorUtils.HexToColor("#C22B26"));
									}
								}
								AmongUSHasVoted = true;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
							else if (action.Equals("SyncAbstainedVoting"))
							{
								AmongUSHasVoted = true;
								SetTag(AmongUSVoteRevealTag, $"Skipped Vote", Color.white, ColorUtils.HexToColor("#1BA039"));
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
						}
					}

					if (action.Equals("SyncEndVotingPhase") || action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
					{
						AmongUSHasVoted = false;
						if (AmongUSVoteRevealTag != null)
						{
							SetTag(AmongUSVoteRevealTag, $"Has not voted Yet", Color.white, ColorUtils.HexToColor("#034989"));
						}
						if (action.Equals("SyncAbort") || action.Equals("SyncVictoryB") || action.Equals("SyncVictoryM") || action.Equals("SyncStart"))
						{
							AmongUsCurrentRole = AmongUsRoles.None;
							AmongUSHasVoted = false;
						}
						if (!isRPCActive)
						{
							isRPCActive = true;
						}
					}
				}
				else if (IsMurder4World)
				{
					if (Internal_AssignedNode != null)
					{

						if (obj.Equals(Internal_AssignedNode))
						{
							if (action == "SyncAssignB")
							{
								Murder4CurrentRole = Murder4Roles.Bystander;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
							else if (action == "SyncAssignD")
							{
								Murder4CurrentRole = Murder4Roles.Detective;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
							else if (action == "SyncAssignM")
							{
								Murder4CurrentRole = Murder4Roles.Murderer;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
							else if (action == "SyncKill")
							{
								Murder4CurrentRole = Murder4Roles.None;
								if (!isRPCActive)
								{
									isRPCActive = true;
								}
							}
						}

						if (action == "SyncVictoryB" || action == "SyncVictoryM" || action == "SyncAbort" || action == "SyncAbort" || action.Equals("SyncStart"))
						{
							Murder4CurrentRole = Murder4Roles.None;
							if (!isRPCActive)
							{
								isRPCActive = true;
							}
						}
					}
				}
			}

		}
	



		
		private AmongUsRoles CheckEntryAmongUS(GameObject Entry)
		{
			if (Entry != null)
			{
				var Color = GetPlayerEntryColor(Entry);
				if (Entry.active)
				{
					if (Color == NoRolesAssigned)
					{
						return AmongUsRoles.None;
					}
					else if (Color == CrewmateColor)
					{
						return AmongUsRoles.Crewmate;
					}
					else if (Color == ImpostorColor)
					{
						return AmongUsRoles.Impostor;
					}
					else if (Color == Unassigned)
					{
						return AmongUsRoles.Unassigned;
					}
					else
					{
						ModConsole.Warning("Unknown Color Detected!");
						ModConsole.Warning(Internal_user.displayName + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
						return AmongUsRoles.None;
					}
				}
				else
				{
					return AmongUsRoles.Unassigned;
				}
			}
			return AmongUsRoles.Unassigned;
		}

		
		private AmongUsRoles GetPlayerRoleAmongUS()
		{
			if (Internal_AssignedEntry != null)
			{
				if (VerifyEntry(Internal_AssignedEntry))
				{
					return CheckEntryAmongUS(Internal_AssignedEntry);
				}
				else
				{
					FindEntryWithUser();
					return CheckEntryAmongUS(Internal_AssignedEntry);
				}
			}
			else
			{
				FindEntryWithUser();
				return CheckEntryAmongUS(Internal_AssignedEntry);
			}
		}

		
		private Murder4Roles GetPlayerRoleMurder4()
		{
			if (Internal_AssignedEntry != null)
			{
				if (VerifyEntry(Internal_AssignedEntry))
				{
					return CheckEntryMurder4(Internal_AssignedEntry);
				}
				else
				{
					FindEntryWithUser();
					return CheckEntryMurder4(Internal_AssignedEntry);
				}
			}
			else
			{
				FindEntryWithUser();
				return CheckEntryMurder4(Internal_AssignedEntry);
			}
		}

		
		private bool VerifyEntry(GameObject Entry)
		{
			if (Entry != null)
			{
				var EntryText = Entry.GetComponentInChildren<Text>();
				if (EntryText != null)
				{
					if (!string.IsNullOrEmpty(EntryText.text) && !string.IsNullOrWhiteSpace(EntryText.text))
					{
						if (EntryText.text == Internal_user.displayName)
						{
							return true;
						}
					}
				}
			} 
			return false;
		}

		
		private void FindEntryWithUser()
		{
			foreach (var item in JarRoleController.JarRoleLinks)
			{
				if (item != null)
				{
					if (item.Entry != null)
					{
						var EntryText = item.Entry.GetComponentInChildren<Text>();
						if (EntryText != null)
						{
							if (!string.IsNullOrEmpty(EntryText.text) && !string.IsNullOrWhiteSpace(EntryText.text))
							{
								if (EntryText.text == Internal_user.displayName)
								{
									Internal_SavedEntry = item;
									break;
								}
							}
						}
					}
				}
			}
		}

		
		public Color? Murder4GetNamePlateColor()
		{
			if (Murder4CurrentRole == Murder4Roles.Detective)
			{
				return DetectiveColor;
			}
			if (Murder4CurrentRole == Murder4Roles.Murderer)
			{
				return MurderColor;
			}
			if (Murder4CurrentRole == Murder4Roles.Bystander)
			{
				return BystanderColor;
			}
			if (Murder4CurrentRole == Murder4Roles.Unassigned)
			{
				return null;
			}
			if (Murder4CurrentRole == Murder4Roles.None)
			{
				return null;
			}
			return null;
		}

		
		public Color? AmongUsGetNamePlateColor()
		{
			if (AmongUsCurrentRole == AmongUsRoles.Crewmate)
			{
				return CrewmateColor;
			}
			if (AmongUsCurrentRole == AmongUsRoles.Impostor)
			{
				return ImpostorColor;
			}
			if (AmongUsCurrentRole == AmongUsRoles.Unassigned)
			{
				return null;
			}
			if (AmongUsCurrentRole == AmongUsRoles.None)
			{
				return null;
			}
			return null;
		}

		
		private Murder4Roles CheckEntryMurder4(GameObject Entry)
		{
			if (Entry != null)
			{
				var Color = GetPlayerEntryColor(Entry);
				if (Entry.active)
				{
					if (Color == NoRolesAssigned)
					{
						return Murder4Roles.None;
					}
					else if (Color == BystanderColor)
					{
						return Murder4Roles.Bystander;
					}
					else if (Color == DetectiveColor)
					{
						return Murder4Roles.Detective;
					}
					else if (Color == MurderColor)
					{
						return Murder4Roles.Murderer;
					}
					else if (Color == Unassigned)
					{
						return Murder4Roles.Unassigned;
					}
					else
					{
						ModConsole.Warning("Unknown Color Detected!");
						ModConsole.Warning(Internal_user.displayName + " Current Color : new Color(" + Color.r + "f, " + Color.g + "f, " + Color.b + "f, " + Color.a + "f)");
						return Murder4Roles.None;
					}
				}
				else
				{
					return Murder4Roles.Unassigned;
				}
			}
			return Murder4Roles.Unassigned;
		}

		
		private Color GetPlayerEntryColor(GameObject Entry)
		{
			if (Entry != null)
			{
				var Image = Entry.GetComponentInChildren<Image>();
				if (Image != null)
				{
					return Image.color;
				}
			}
			return Color.white;
		}

		
		private SingleTag SetTag(SingleTag tag, string text, Color TextColor, Color TagColor)
		{
			if (tag != null)
			{
				if (tag.Label_Text != text)
				{
					tag.Label_Text = text;
				}
				if (tag.Label_TextColor != TextColor)
				{
					tag.Label_TextColor = TextColor;
				}
				if (tag.Tag_Color != TagColor)
				{
					tag.Tag_Color = TagColor;
				}
				return tag;
			}
			else
			{
				tag = SingleTagsUtils.AddSingleTag(Internal_player);
				return SetTag(tag, text, TextColor, TagColor);
			}
		}

		public void OnDestroy()
		{
			if (GameRoleTag != null)
			{
				Object.Destroy(GameRoleTag);
			}
			if (AmongUSVoteRevealTag != null)
			{
				Object.Destroy(AmongUSVoteRevealTag);
			}
			//if (_AssignedPlayerEntry != null)
			//{
			//    _AssignedPlayerEntry.RenameObject("Unassigned Entry");
			//}
			if (_AssignedPlayerNode != null)
			{
				_AssignedPlayerNode.RenameObject("Unassigned Node");
			}

			JarRoleController.RoleEspComponents.Remove(this);
		}

		
		private string GetCurrentSingleTagText()
		{
			return GameRoleTag.Label_Text;
		}

		private void SetEspColorIfExists(Color color)
		{
			if (Internal_player != null)
			{
				if (ESPMenu.Toggle_Player_ESP)
				{
					var esp = Internal_player.gameObject.GetComponent<PlayerESP>();
					if (esp != null)
					{
						esp.ChangeColor(color);
					}
				}
			}
		}

		private void ResetESPColor()
		{
			if (Internal_player != null)
			{
				if (ESPMenu.Toggle_Player_ESP)
				{
					var esp = Internal_player.gameObject.GetComponent<PlayerESP>();
					if (esp != null)
					{
						esp.ResetColor();
					}
				}
			}
		}

		public void Update()
		{
			try
			{
				if(Internal_AssignedEntry == null)
				{
					FindEntryWithUser();
				}
				else
				{
					if(!VerifyEntry(Internal_AssignedEntry))
					{
						FindEntryWithUser();
					}
				}

					if (GameRoleTag != null)
					{
						if (GameRoleTag.ShowTag != JarRoleController.ViewRoles)
						{
							GameRoleTag.ShowTag = JarRoleController.ViewRoles;
						}

					}
					if (JarRoleController.IsMurder4World)
					{
					if (!isRPCActive)
					{
						var ReturnedRole = GetPlayerRoleMurder4();
						if (ReturnedRole != Murder4CurrentRole)
						{
							Murder4CurrentRole = ReturnedRole;
						}
					}
					if (JarRoleController.ViewRoles)
						{
							if (AssignedMurder4Role != Murder4Roles.None && AssignedMurder4Role != Murder4Roles.Unassigned)
							{
								if (GetCurrentSingleTagText() != AssignedMurder4Role.ToString())
								{
									var color = Murder4GetNamePlateColor();
									if (color != null)
									{
										SetTag(GameRoleTag, AssignedMurder4Role.ToString(), DefaultTextColor, color.Value);
										SetEspColorIfExists(color.Value);
									}
								}
							}
							else
							{
								if (GetCurrentSingleTagText() != NoRoles)
								{
									SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
									ResetESPColor();
								}
							}
						}
						else
						{
							if (GetCurrentSingleTagText() != HiddenRole)
							{
								SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
								ResetESPColor();
							}
						}
					}
					else if (JarRoleController.isAmongUsWorld)
					{
					if (!isRPCActive)
					{
						var ReturnedRole = GetPlayerRoleAmongUS();
						if (ReturnedRole != AmongUsCurrentRole)
						{
							AmongUsCurrentRole = ReturnedRole;
						}
					}
					if (AmongUSVoteRevealTag == null)
						{
							AmongUSVoteRevealTag = SingleTagsUtils.AddSingleTag(Internal_player);
						}

						if (JarRoleController.ViewRoles)
						{
							if (AmongUSHasVoted)
							{
								if (!AmongUSVoteRevealTag.ShowTag)
								{
									AmongUSVoteRevealTag.ShowTag = true;
								}
							}
							if (AmongUsCurrentRole != AmongUsRoles.None && AmongUsCurrentRole != AmongUsRoles.Unassigned)
							{
								if (GetCurrentSingleTagText() != AmongUsCurrentRole.ToString())
								{
									var color = AmongUsGetNamePlateColor();
									if (color != null)
									{
										SetTag(GameRoleTag, AmongUsCurrentRole.ToString(), DefaultTextColor, color.Value);
										SetEspColorIfExists(color.Value);
									}
								}
							}
							else
							{
								if (GetCurrentSingleTagText() != NoRoles)
								{
									SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
									ResetESPColor();
									AmongUSHasVoted = false;
								}
							}
						}
						else
						{
							if (AmongUSVoteRevealTag != null)
							{
								if (AmongUSVoteRevealTag.ShowTag)
								{
									AmongUSVoteRevealTag.ShowTag = false;
								}
							}

							if (GetCurrentSingleTagText() != HiddenRole)
							{
								SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
								ResetESPColor();
							}
						}
					
				}
			}
			catch (Exception e) { ModConsole.DebugError("JarRoleRevealer OnUpdate Exception : " + e); }
		}

		private readonly string HiddenRole = "Role Hidden";
		private readonly string NoRoles = "No Role";

		private readonly Color NoRolesColor = Color.yellow;
		private readonly Color HiddenRolesColor = Color.green;
		private readonly Color DefaultTextColor = Color.white;

		internal Murder4Roles AssignedMurder4Role
		{
			
			get
			{
				return Murder4CurrentRole;
			}
		}

		internal AmongUsRoles AssignedAmongUS4Role
		{
			
			get
			{
				return AmongUsCurrentRole;
			}
		}

		internal enum Murder4Roles
		{
			None = 0,
			Detective = 1,
			Murderer = 2,
			Bystander = 3,
			Unassigned = 4,
		}

		internal enum AmongUsRoles
		{
			None = 0,
			Crewmate = 1,
			Impostor = 2,
			Unassigned = 3,
		}

		private LinkedNodes Internal_SavedEntry
		{
			
			get
			{
				return _SavedEntry;
			}
			
			set
			{
				_SavedEntry = value;
				Internal_AssignedEntry = value.Entry.gameObject;
				Internal_AssignedNode = value.Node.gameObject;
			}
		}

		internal LinkedNodes LinkedEntry
		{
			
			get
			{
				return Internal_SavedEntry;
			}
		}

		private GameObject Internal_AssignedEntry
		{
			
			get
			{
				return _AssignedPlayerEntry;
			}
			
			set
			{
				_AssignedPlayerEntry = value;
			}
		}

		internal GameObject Entry
		{
			
			get
			{
				return Internal_AssignedEntry;
			}
		}

		internal APIUser Apiuser
		{
			
			get
			{
				return Internal_user;
			}
		}

		private GameObject _AssignedPlayerNode;

		private GameObject Internal_AssignedNode
		{
			
			get
			{
				return _AssignedPlayerNode;
			}
			
			set
			{
				if (_AssignedPlayerNode != null)
				{
					if (value != _AssignedPlayerNode)
					{
						_AssignedPlayerNode.RenameObject("Unassigned Node");
					}
				}
				value.RenameObject(Internal_user.displayName);
				_AssignedPlayerNode = value;
			}
		}

		internal GameObject Node
		{
			
			get
			{
				return Internal_AssignedNode;
			}
		}

		private bool _AmongUSHasVoted;

		internal bool AmongUSHasVoted
		{
			
			get
			{
				return _AmongUSHasVoted;
			}
			
			set
			{
				if (AmongUSVoteRevealTag != null)
				{
					if (JarRoleController.ViewRoles)
					{
						if (AmongUsCurrentRole == AmongUsRoles.Crewmate || AmongUsCurrentRole == AmongUsRoles.Impostor)
						{
							AmongUSVoteRevealTag.ShowTag = value;
						}
					}
					else
					{
						AmongUSVoteRevealTag.ShowTag = false;
					}
				}

				_AmongUSHasVoted = value;
			}
		}

		internal bool AmongUSCanVote
		{
			
			get
			{
				if (AmongUsCurrentRole == AmongUsRoles.Crewmate)
				{
					if (!AmongUSHasVoted)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else if (AmongUsCurrentRole == AmongUsRoles.Impostor)
				{
					if (!AmongUSHasVoted)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else if (AmongUsCurrentRole == AmongUsRoles.Unassigned)
				{
					return false;
				}
				else if (AmongUsCurrentRole == AmongUsRoles.None)
				{
					return false;
				}
				else
				{
					return false;
				}
			}
		}
		internal bool isRPCActive { get; set; } = false;
		internal Murder4Roles Murder4CurrentRole { get; set; } = Murder4Roles.Unassigned;
		internal AmongUsRoles AmongUsCurrentRole { get; set; } = AmongUsRoles.Unassigned;
		internal Player Internal_player { get; private set; } = null;
		internal APIUser Internal_user { get; private set; } = null;
		internal GameObject _AssignedPlayerEntry { get; private set; } = null;
		internal SingleTag GameRoleTag { get; private set; } = null;

		internal SingleTag AmongUSVoteRevealTag { get; private set; } = null;

		internal LinkedNodes _SavedEntry { get; private set; } = null;

		// MURDER 4 MAP
		private readonly Color MurderColor = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);

		private readonly Color BystanderColor = new Color(0.3428266f, 0.5883213f, 0.6792453f, 1f);
		private readonly Color DetectiveColor = new Color(0.2976544f, 0.251424f, 0.4716981f, 1f);

		// AMONG US MAP
		private readonly Color ImpostorColor = new Color(0.5377358f, 0.1648718f, 0.1728278f, 1f);

		private readonly Color CrewmateColor = new Color(0f, 0.3228593f, 0.8396226f, 1f);

		// GENERAL
		private readonly Color Unassigned = new Color(0.5f, 0.5f, 0.5f, 1f);

		private readonly Color NoRolesAssigned = new Color(0f, 0f, 0f, 0f);
	}
}