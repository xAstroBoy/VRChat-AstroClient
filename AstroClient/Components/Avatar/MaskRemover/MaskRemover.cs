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
			if(player == null)
			{
				player = GetComponent<Player>();
			}
			if(player != null)
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

											var avichilds = AvatarUtils.AvatarParents(Avatar, Armature, Body);
											if (avichilds.Count() != 0)
											{
												foreach (var item in avichilds)
												{
													if (item.name.ToLower().Equals("mask"))
													{
														item.DestroyMeLocal();
													}
													else
													{
														foreach(var itemchilds in item.Get_All_Childs())
														{
															if(itemchilds.name.ToLower().Equals("mask"))
															{
																item.DestroyMeLocal();
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




		private void OnDestroy()
		{
			player.ReloadAvatar();
		}


		internal Transform AvatarRoot { get; private set; } = null;
		internal Transform Avatar { get; private set; } = null;
		internal Transform Armature { get; private set; } = null;
		internal Transform Body { get; private set; } = null;
		internal Player player { get; private set; } = null;
		internal Animator AvatarAnimator { get; private set; } = null;


	}
}