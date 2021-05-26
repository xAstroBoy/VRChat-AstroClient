﻿namespace AstroClient.Components
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

	public class MaskRemover : GameEventsBehaviour
	{
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public MaskRemover(IntPtr obj0) : base(obj0)
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
				ModConsole.DebugLog($"[MaskRemover Debug] : {msg}");
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
											var childs = Avatar.Get_All_Childs();
											if (childs.Count() != 0)
											{
												foreach (var item in childs)
												{
													if (item.gameObject.GetComponent<Renderer>())
													{
														if (item.name.ToLower().Equals("mask") || item.name.ToLower().Equals("facemask"))
														{
															item.DestroyMeLocal();
														}
													}
													else
													{
														foreach (var itemchilds in item.Get_All_Childs())
														{
															if (itemchilds.gameObject.GetComponent<Renderer>())
															{
																if (itemchilds.name.ToLower().Equals("mask") || itemchilds.name.ToLower().Equals("facemask"))
																{
																	itemchilds.DestroyMeLocal();
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
						}
					}
				}
			}
		}




		public void OnDestroy()
		{
			player.ReloadAvatar();
		}


		private Transform AvatarRoot = null;
		private Transform Avatar = null;
		private Transform Armature = null;
		private Transform Body = null;
		private Player player = null;
		private Animator AvatarAnimator = null;


	}
}