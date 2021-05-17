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

	public class Lewdifier : GameEventsBehaviour
	{
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public Lewdifier(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		private bool DebugMode = false;

		[HideFromIl2Cpp]
		private void Debug(string msg)
		{
			if (DebugMode)
			{
				ModConsole.DebugLog($"[Lewdifier Debug] : {msg}");
			}
		}

		// Use this for initialization
		public void Start()
		{
			if(player == null)
			{
				player = GetComponent<Player>();
			}
			if(player != null)
			{
				if(PlayerTag == null)
				{
					PlayerTag = player.AddSingleTag();
					if(PlayerTag != null)
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
										AvatarRoot = avatar.transform.root;
										if (AvatarRoot != null)
										{
											Avatar = AvatarRoot.Get_Avatar();
											Armature = AvatarRoot.Get_Armature();
											Body = AvatarRoot.Get_Body();
											AvatarAnimator = Avatar.GetComponentInChildren<Animator>();
											PlayerTag.ShowTag = false;
											if (!LewdifierUtils.AvatarsToSkip.Contains(apiavatar.id))
											{
												var avichilds = AvatarUtils.AvatarParents(Avatar, Armature, Body);
												if(avichilds.Count() != 0)
												{
													bool hasTurnedOffChilds = Lewdify_Terms_To_turn_Off(avichilds);
													bool hasTurnedOnChilds = Lewdify_Terms_To_turn_On(avichilds);
													if(hasTurnedOffChilds && !hasTurnedOnChilds)
													{
														if(PlayerTag != null)
														{
															PlayerTag.Label_Text = "Possibly NSFW";
															PlayerTag.Tag_Color = ColorUtils.HexToColor("#FFA500");
															PlayerTag.ShowTag = true;
														}
													}
													else if(!hasTurnedOffChilds && hasTurnedOnChilds)
													{
														if (PlayerTag != null)
														{
															PlayerTag.Label_Text = "Possibly NSFW";
															PlayerTag.Tag_Color = ColorUtils.HexToColor("#FFA500");
															PlayerTag.ShowTag = true;
														}
													}
													else if(!hasTurnedOffChilds && !hasTurnedOnChilds)
													{
														if (PlayerTag != null)
														{
															PlayerTag.Label_Text = "NOT NSFW";
															PlayerTag.Tag_Color = Color.blue;
															PlayerTag.ShowTag = true;
														}
													}
													else if(hasTurnedOffChilds && hasTurnedOnChilds)
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
											else
											{
												ModConsole.DebugLog("Skipped A Avatar, As is in AvatarsToSkip");
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private bool Lewdify_Terms_To_turn_Off(List<Transform> avataritems)
		{
			bool flag = false;
			if (avataritems.Count() != 0)
			{
				foreach (var item in avataritems)
				{
					foreach (var childitem in item.Get_All_Childs())
					{
						ModConsole.DebugLog($"Checking {childitem.name} in TermsToToggleOff");
						if (LewdifierUtils.TermsToToggleOff.Contains(childitem.name.ToLower()))
						{
							ModConsole.DebugLog($"{childitem.name} Found in TermsToToggleOff", System.Drawing.Color.Green);

							flag = true;
							if (AvatarModifier.ForceLewdify)
							{
								childitem.DestroyMeLocal();
							}
							else
							{
								if (childitem.gameObject.active)
								{
									childitem.gameObject.SetActiveRecursively(false);
								}
								if(!ChildsToKeepOff.Contains(childitem))
								{
									ChildsToKeepOff.Add(childitem);
								}
							}
						}
					}
				}
			}
			return flag;
		}

		private bool Lewdify_Terms_To_turn_On(List<Transform> avataritems)
		{
			bool flag = false;
			if (avataritems.Count() != 0)
			{
				foreach (var item in avataritems)
				{
					foreach (var childitem in item.Get_All_Childs())
					{
						ModConsole.DebugLog($"Checking {childitem.name} in TermsToToggleOn");

						if (LewdifierUtils.TermsToToggleOn.Contains(childitem.name.ToLower()))
						{
							ModConsole.DebugLog($"{childitem.name} Found in TermsToToggleOn", System.Drawing.Color.Green);

							flag = true;
							var parent = childitem.Get_root_of_avatar_child();
							ModConsole.DebugLog($"Got root of  {childitem.name} , Root is : {parent.name}");

							if (parent != null)
							{
								ModConsole.DebugLog($"Enabling Parent.. {parent.name}...");


								if (!parent.gameObject.active)
								{
									parent.gameObject.active = true;
								}
								if (!childitem.gameObject.active)
								{
									childitem.gameObject.SetActiveRecursively(true);
								}


							}

						}
					}
				}
			}
			return flag;
		}


		// TODO: Figure how to Edit the animator to Be able to toggle the Objects with animator active.
		private void Update()
		{
		}

		private void LateUpdate()
		{
			if(AvatarModifier.ForceLewdify)
			{
				if(ChildsToKeepOff.Count() != 0)
				{
					foreach(var child in ChildsToKeepOff)
					{
						if (child != null)
						{
							if (child.gameObject.active)
							{
								child.DestroyMeLocal();
							}
						}
					}
				}
			}
		}



		private void OnDestroy()
		{
			ChildsTokeepOn.Clear();
			ChildsToKeepOff.Clear();
			PlayerTag.DestroyMeLocal();
			player.ReloadAvatar();
		}


		internal Transform AvatarRoot { get; private set; } = null;

		internal Transform Avatar { get; private set; } = null;
		internal Transform Armature { get; private set; } = null;
		internal Transform Body { get; private set; } = null;
		internal SingleTag PlayerTag { get; private set; } = null;
		internal Player player { get; private set; } = null;
		internal Animator AvatarAnimator { get; private set; } = null;

		internal List<Transform> ChildsToKeepOff  { get; private set; } = new List<Transform>();
		internal List<Transform> ChildsTokeepOn { get; private set; } = new List<Transform>();

	}
}