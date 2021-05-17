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
			RemoveMasksToggle = new QMSingleToggleButton(tmp, 1, 0, "Auto Remove Masks", () => { MaskDeleter = true; }, "Auto Remove Masks", () => { MaskDeleter = false; }, "Remove Masks From all avatars (Will make all Avatars Reload)", Color.green, Color.red, null, false, true);
			LewdifyToggle = new QMSingleToggleButton(tmp, 1, 0.5f, "Auto Lewdify", () => { Lewdify = true; }, "Auto Lewdify", () => { Lewdify = false; }, "Lewdifies All avatars In Instance (Will make all Avatars Reload)", Color.green, Color.red, null, false, true);
			ForceLewdifyToggle = new QMSingleToggleButton(tmp, 1, 1f, "Forced Lewdify", () => { ForceLewdify = true; }, "Forced Lewdify", () => { ForceLewdify = false; }, "Force Lewdify avatars (Destroys the Transforms, Due to SDK3 Avatars Refusing to toggle them.) (Will make all Avatars Reload)", Color.green, Color.red, null, false, true);
			LewdifyLists = new QMSingleButton(tmp, 1, 1.5f, "NOT SET", () => { LewdifierUtils.RefreshAll(); }, "Refresh Current Lists", null, null, false);
			LewdifyLists.SetResizeTextForBestFit(true);
			
		}

		public static void InitUserMenu(float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton("UserInteractMenu", x, y, "Avatar Utilities", "AstroClient Avatar utilities", null, null, null, null, btnHalf);
			new QMSingleButton(menu, 1, 0, "Dump Avatar Transforms", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Avatar_Transform_Dumper(); }, "Dump Avatar Transforms", null, null, true);
			new QMSingleButton(menu, 1, 0.5f, "Dump Avatar Renderers", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Avatar_Renderer_Dumper(); }, "Dump Avatar Renderers", null, null, true);
			new QMSingleButton(menu, 1, 1, "Dump Avatar Materials", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Avatar_Material_Dumper(); }, "Dump Avatar Materials", null, null, true);
			new QMSingleButton(menu, 1, 1.5f, "Lewdify", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Add_Lewdify(); }, "Lewdify This Player Avatar", null, null, true);
			new QMSingleButton(menu, 1, 2, "Remove Lewdify Effect.", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Remove_Lewdify(); }, "Remove the Lewdifier On this user..", null, null, true);
			new QMSingleButton(menu, 1, 2.5f, "Skip Avatar Lewdifying.", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().BlackListAvatar_Lewdifier(); }, "Skip This Avatar From being Lewdified.", null, null, true);


			new QMSingleButton(menu, 2, 0f, "Add Mask Remover", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Add_MaskRemover(); }, "Remove The Annoying Mask Theme on this user.", null, null, true);
			new QMSingleButton(menu, 2, 0.5f, "Remove Mask Remover", () => { QuickMenuUtils.GetSelectedUser().GetPlayer().Add_MaskRemover(); }, "Remove The Mask Remover on this user.", null, null, true);


		}


		public override void OnPlayerJoined(Player player)
		{
			if (player != null)
			{
				if (Lewdify)
				{
					player.Add_Lewdify();
				}
				if (MaskDeleter)
				{
					player.Add_MaskRemover();
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
				if(value)
				{
					foreach (var player in WorldUtils.Get_Players())
					{
						if (player != null)
						{
							player.Add_Lewdify();
						}
					}
				}
				else
				{
					foreach (var player in WorldUtils.Get_Players())
					{
						if (player != null)
						{
							player.Add_Lewdify();
						}
					}
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
				if(value)
				{
					foreach(var player in WorldUtils.Get_Players())
					{
						if(player != null)
						{
							player.Add_MaskRemover();
						}
					}
				}
				else
				{

				}
			}
		}

		public static QMSingleButton LewdifyLists { get; set; }



	}



}