namespace AstroClient.AvatarMods
{
	using AstroClient.Extensions;
	using AstroLibrary.Console;
	using DayClientML2.Utility;
	using RubyButtonAPI;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	internal class AvatarModifier : GameEvents
	{
		public static void InitQMMenu(QMTabMenu tab, float x, float y, bool btnHalf)
		{
			var tmp = new QMNestedButton(tab, x, y, "Avatar Modifiers", "Modify Other's avatars", null, null, null, null, btnHalf);
			new QMSingleButton(tmp, 5, 0, "Reload All Avatars", () => { AvatarUtils.Reload_All_Avatars(); }, "Reloads All avatars", null, null, true);
			RemoveMasksToggle = new QMSingleToggleButton(tmp, 1, 0, "Remove Masks", () => { MaskDeleter = true; }, "Remove Masks", () => { MaskDeleter = false; }, "Remove Masks From all avatars (Requires Avatar Reload)", Color.green, Color.red, null, false, true);
			LewdifyToggle = new QMSingleToggleButton(tmp, 1, 0.5f, "Lewdify", () => { Lewdify = true; }, "Lewdify", () => { Lewdify = false; }, "Lewdify avatars (Requires a Avatar Reload)", Color.green, Color.red, null, false, true);
			ForceLewdifyToggle = new QMSingleToggleButton(tmp, 1, 1f, "Forced Lewdify", () => { ForceLewdify = true; }, "Forced Lewdify", () => { ForceLewdify = false; }, "Force Lewdify avatars (Destroys the Transforms, Due to SDK3 Avatars Refusing to toggle them.) (Requires a Avatar Reload)", Color.green, Color.red, null, false, true);
			LewdifyLists = new QMSingleButton(tmp, 1, 1.5f, "NOT SET", () => { Lewdifier.RefreshAll(); }, "Refresh Current Lists", null, null, false);
			LewdifyLists.SetResizeTextForBestFit(true);
			
		}

		public static void InitUserMenu(float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton("UserInteractMenu", x, y, "Avatar Utilities", "AstroClient Avatar utilities", null, null, null, null, btnHalf);
			new QMSingleButton(menu, 1, 0, "Dump Avatar Transforms", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Avatar_Transform_Dumper(); }, "Dump Avatar Transforms", null, null, true);
			new QMSingleButton(menu, 1, 0.5f, "Dump Avatar Renderers", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Avatar_Renderer_Dumper(); }, "Dump Avatar Renderers", null, null, true);
			new QMSingleButton(menu, 1, 1, "Dump Avatar Materials", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Avatar_Material_Dumper(); }, "Dump Avatar Materials", null, null, true);
			new QMSingleButton(menu, 1, 1.5f, "Lewdify", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Lewdify(); }, "Lewdify This Player Avatar", null, null, true);
			new QMSingleButton(menu, 1, 2, "Skip Avatar Lewdifying.", () => {  }, "Skip This Avatar From being Lewdified.", null, null, true);


		}

		public static string PossiblyNSFW { get; } = "Possibly NSFW";
		public static string NSFW { get; } = "NSFW Avatar";

		public void RemoveLewdNSFWTags(Player player)
		{
			foreach (var tag in player.SearchTags(PossiblyNSFW))
			{
				if (tag != null)
				{
					tag.DestroyMeLocal();
				}
			}
			foreach (var tag in player.SearchTags(NSFW))
			{
				if (tag != null)
				{
					tag.DestroyMeLocal();
				}
			}
		}

		public override void OnAvatarSpawn(GameObject avatar, VRC_AvatarDescriptor DescriptorObj, bool state)
		{
			if (avatar != null && DescriptorObj != null)
			{
				var player = avatar.transform.root.GetComponentInChildren<Player>();
				if (player != null)
				{
					RemoveLewdNSFWTags(player);
					var manager = player._vrcplayer.prop_VRCAvatarManager_0;
					if (manager != null)
					{
						if (manager.prop_VRCAvatarDescriptor_0 != null && manager.prop_VRC_AvatarDescriptor_0 != null)
						{
							var apiavatar = manager.field_Private_ApiAvatar_1;
							if (apiavatar != null)
							{
								if (!string.IsNullOrEmpty(apiavatar.assetUrl) && !string.IsNullOrEmpty(apiavatar.id))
								{
									Transform root = avatar.transform.root;
									if (root != null)
									{
										Transform AvatarHolder = root.Get_Avatar();
										Transform Armature = root.Get_Armature();
										Transform Body = root.Get_Body();

										if (AvatarHolder != null)
										{
											var childs = AvatarUtils.AvatarParents(AvatarHolder, Armature, Body);
											if (childs.Count() != 0 && childs != null)
											{
												if (MaskDeleter)
												{
													RemoveMasks(childs);
												}
												if (Lewdify)
												{
													if (!Lewdifier.AvatarsToSkip.Contains(apiavatar.id))
													{
														childs.Lewdify(out var OffChilds, out var OnChilds);
														if (OffChilds && !OnChilds)
														{
															if (!player.HasTagWithText(PossiblyNSFW))
															{
																var tag = player.AddSingleTag();
																MiscUtility.DelayFunction(0.5f, () =>
															{
																if (tag != null)
																{
																	tag.Label_Text = PossiblyNSFW;
																	tag.Tag_Color = ColorUtils.HexToColor("#FFA500");
																	tag.Label_TextColor = UnityEngine.Color.white;
																}
															});
															}
														}
														else if (!OffChilds && OnChilds)
														{
															if (!player.HasTagWithText(PossiblyNSFW))
															{
																var tag = player.AddSingleTag();
																MiscUtility.DelayFunction(0.5f, () =>
																{
																	if (tag != null)
																	{
																		tag.Label_Text = PossiblyNSFW;
																		tag.Tag_Color = ColorUtils.HexToColor("#FFA500");
																		tag.Label_TextColor = UnityEngine.Color.white;
																	}
																});
															}
														}
														else if (OnChilds && OffChilds)
														{
															if (!player.HasTagWithText(NSFW))
															{
																var tag = player.AddSingleTag();
																MiscUtility.DelayFunction(0.5f, () =>
																{
																	if (tag != null)
																	{
																		tag.Label_Text = NSFW;
																		tag.Tag_Color = UnityEngine.Color.red;
																		tag.Label_TextColor = UnityEngine.Color.white;
																	}
																});
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
			}
		}

		// Destroys Masks.
		public static void RemoveMasks(List<Transform> items)
		{
			foreach (var item in items)
			{
				if (item != null)
				{
					if (item.name.ToLower() == "mask")
					{
						item.gameObject.DestroyMeLocal();
					}
					else
					{
						foreach (var child in item.GetComponentsInChildren<Transform>(true))
						{
							if (child != null)
							{
								if (child.name.ToLower() == "mask")
								{
									child.gameObject.DestroyMeLocal();
								}
							}
						}
					}
				}
			}
		}

		public static QMSingleToggleButton ForceLewdifyToggle { get; set; }

		private static bool _ForceLewdify = false;

		public static bool ForceLewdify
		{
			get
			{
				return _ForceLewdify;
			}
			set
			{
				_ForceLewdify = value;
				if (ForceLewdify != null)
				{
					ForceLewdifyToggle.setToggleState(value);
				}
			}
		}

		public static QMSingleToggleButton LewdifyToggle { get; set; }

		private static bool _Lewdify = false;

		public static bool Lewdify
		{
			get
			{
				return _Lewdify;
			}
			set
			{
				_Lewdify = value;
				if (Lewdify != null)
				{
					LewdifyToggle.setToggleState(value);
				}
			}
		}

		public static QMSingleToggleButton RemoveMasksToggle { get; set; }

		private static bool _MaskDeleter = false;

		public static bool MaskDeleter
		{
			get
			{
				return _MaskDeleter;
			}
			set
			{
				_MaskDeleter = value;
				if (RemoveMasksToggle != null)
				{
					RemoveMasksToggle.setToggleState(value);
				}
			}
		}

		public static QMSingleButton LewdifyLists { get; set; }



	}



}