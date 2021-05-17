namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using DayClientML2.Utility;
	using System;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC;
	using AstroClient.AvatarMods;
	using VRC.SDKBase;
	using System.Collections.Generic;
	using System.Linq;
	using DayClientML2.Utility.Extensions;
	using Object = UnityEngine.Object;

	public class Lewdifier : GameEventsBehaviour
	{
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public Lewdifier(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		private bool DebugMode = true;

		[HideFromIl2Cpp]
		private void Debug(string msg)
		{
			if (DebugMode)
			{
				if (player != null)
				{
					ModConsole.DebugLog($"[Lewdifier Debug] [{player.DisplayName()}] : {msg}");
				}
				else
				{
					ModConsole.DebugLog($"[Lewdifier Debug] : {msg}");

				}
			}
		}

		// Use this for initialization
		public void Start()
		{
			if (player == null)
			{
				player = GetComponent<Player>();
			}
			if (player != null)
			{
				if (PlayerTag == null)
				{
					PlayerTag = player.AddSingleTag();
					if (PlayerTag != null)
					{
						PlayerTag.ShowTag = false;
					}
				}
				player.ReloadAvatar();
			}
		}



		public override void OnAvatarSpawn(GameObject avatar, VRC_AvatarDescriptor DescriptorObj, bool state)
		{
			if (avatar != null && DescriptorObj != null)
			{
				var AvatarPlayer = avatar.transform.root.GetComponentInChildren<Player>();
				if (AvatarPlayer != null)
				{
					if (AvatarPlayer == player) // Checks if this assigned player is the same.
					{
						if (AvatarRoot == null)
						{
							AvatarRoot = avatar.transform.root;
						}
						Avatar = null;
						AvatarAnimator = null;
						Armature = null;
						Body = null;
						ChildsToKeepOff.Clear();
						ChildsTokeepOn.Clear();
						PlayerTag.ShowTag = false;
						var manager = AvatarPlayer._vrcplayer.prop_VRCAvatarManager_0;
						if (manager != null)
						{
							if (manager.prop_VRCAvatarDescriptor_0 != null && manager.prop_VRC_AvatarDescriptor_0 != null)
							{
								var apiavatar = manager.field_Private_ApiAvatar_1;
								if (apiavatar != null)
								{
									if (!string.IsNullOrEmpty(apiavatar.assetUrl) && !string.IsNullOrEmpty(apiavatar.id))
									{
										AvatarID = apiavatar.id;
										lewdify_Avatar();
									}
								}
							}
						}
					}
				}
			}
		}


		internal void lewdify_Avatar()
		{
			if (!LewdifierUtils.AvatarsToSkip.Contains(AvatarID))
			{
				if(AvatarRoot == null)
				{
					AvatarRoot = this.transform.root;
				}
				if (AvatarRoot != null)
				{
					Avatar = AvatarRoot.Get_Avatar();
					Armature = AvatarRoot.Get_Armature();
					Body = AvatarRoot.Get_Body();
					AvatarAnimator = Avatar.GetComponentInChildren<Animator>();
					PlayerTag.ShowTag = false;

					var avichilds = AvatarUtils.AvatarParents(Avatar, Armature, Body);
					if (avichilds.Count() != 0)
					{
						bool hasTurnedOffChilds = Lewdify_Terms_To_turn_Off(avichilds);
						bool hasTurnedOnChilds = Lewdify_Terms_To_turn_On(avichilds);
						if (hasTurnedOffChilds && !hasTurnedOnChilds)
						{
							if (PlayerTag != null)
							{
								PlayerTag.Label_Text = "Possibly NSFW";
								PlayerTag.Tag_Color = ColorUtils.HexToColor("#FFA500");
								PlayerTag.ShowTag = true;
							}
						}
						else if (!hasTurnedOffChilds && hasTurnedOnChilds)
						{
							if (PlayerTag != null)
							{
								PlayerTag.Label_Text = "Possibly NSFW";
								PlayerTag.Tag_Color = ColorUtils.HexToColor("#FFA500");
								PlayerTag.ShowTag = true;
							}
						}
						else if (!hasTurnedOffChilds && !hasTurnedOnChilds)
						{
							if (PlayerTag != null)
							{
								PlayerTag.Label_Text = "NOT NSFW";
								PlayerTag.Tag_Color = Color.blue;
								PlayerTag.ShowTag = true;
							}
						}
						else if (hasTurnedOffChilds && hasTurnedOnChilds)
						{
							if (PlayerTag != null)
							{
								PlayerTag.Label_Text = "NSFW";
								PlayerTag.Tag_Color = Color.red;
								PlayerTag.ShowTag = true;
							}
						}
					}

				}
			}
			else
			{
				if (PlayerTag != null)
				{
					PlayerTag.Label_Text = "Skipped Lewdify";
					PlayerTag.Tag_Color = Color.cyan;
					PlayerTag.ShowTag = true;
				}
			}
		}
	


		private bool Lewdify_Terms_To_turn_Off(List<Transform> avataritems)
		{
			bool FoundaHit = false;
			if (avataritems.Count() != 0)
			{
				foreach (var parent in avataritems)
				{
					if (CheckForTermsToToggleOff(parent))
					{
						FoundaHit = true;
					}
					if (parent != null)
					{

						foreach (var child in parent.Get_All_Childs())
						{
							if (CheckForTermsToToggleOff(child))
							{
								FoundaHit = true;
							}
						}
					}
				}
			}
			return FoundaHit;
		}
	
		private bool CheckForTermsToToggleOff(Transform item)
		{
			bool FoundaHit = false;
			Debug($"Checking {item.name} in TermsToToggleOff");
			if (LewdifierUtils.TermsToToggleOff.Contains(item.name.ToLower()))
			{
				Debug($"{item.name} Found in TermsToToggleOff");

				FoundaHit = true;
				if (AvatarModifier.ForceLewdify)
				{
					item.DestroyMeLocal();
				}
				else
				{
					if (item.gameObject.active)
					{
						item.gameObject.SetActiveRecursively(false);
					}
					if (!ChildsToKeepOff.Contains(item))
					{
						ChildsToKeepOff.Add(item);
					}
				}
			}
			return FoundaHit;
		}




		private bool Lewdify_Terms_To_turn_On(List<Transform> avataritems)
		{
			bool FoundaHit = false;
			if (avataritems.Count() != 0)
			{
				foreach (var parent in avataritems)
				{
					if (CheckForTermsToToggleOn(parent))
					{
						FoundaHit = true;
					}

					foreach (var child in parent.Get_All_Childs())
					{
						if (CheckForTermsToToggleOn(child))
						{
							FoundaHit = true;
						}
					}
				}
			}
			return FoundaHit;
		}

		private bool CheckForTermsToToggleOn(Transform item)
		{
			bool flag = false;
			Debug($"Checking {item.name} in TermsToToggleOn");

			if (LewdifierUtils.TermsToToggleOn.Contains(item.name.ToLower()))
			{
				flag = true;

				Debug($"{item.name} Found in TermsToToggleOn");

				var parent = item.Get_root_of_avatar_child();
				ModConsole.DebugLog($"Got root of  {item.name} , Root is : {parent.name}");

				if (parent != null)
				{
					ModConsole.DebugLog($"Enabling Parent.. {parent.name}...");


					if (!parent.gameObject.active)
					{
						parent.gameObject.active = true;
					}
					if (!item.gameObject.active)
					{
						item.gameObject.SetActiveRecursively(true);
					}


				}

			}
			return flag;
		}



		// TODO: Figure how to Edit the animator to Be able to toggle the Objects with animator active.
		public void Update()
		{
		}

		public void LateUpdate()
		{
			if (AvatarModifier.ForceLewdify)
			{
				try
				{
					if (ChildsToKeepOff.Count() != 0)
					{
						foreach (var child in ChildsToKeepOff)
						{
							if (child != null)
							{
								if (child.gameObject.active)
								{
									ChildsToKeepOff.Remove(child);
									child.DestroyMeLocal();
								}
							}
						}
					}
				}
				catch { }
			}
		}



		public void OnDestroy()
		{
			ChildsTokeepOn.Clear();
			ChildsToKeepOff.Clear();
			Destroy(PlayerTag);
			player.ReloadAvatar();
		}


		private Transform AvatarRoot = null;
		private Transform Avatar  = null;
		private Transform Armature  = null;
		private Transform Body = null;
		private SingleTag PlayerTag = null;
		private Player player = null;
		private Animator AvatarAnimator  = null;
		private string AvatarID = null;
		private List<Transform> ChildsToKeepOff  = new List<Transform>();
		private List<Transform> ChildsTokeepOn = new List<Transform>();

	}
}