namespace AstroClient.AvatarMods
{
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using RubyButtonAPI;
    using System;
    using UnityEngine;
    using VRC;

    internal class AvatarModifier : GameEvents
    {
        public static void InitQMMenu(QMTabMenu tab, float x, float y, bool btnHalf)
        {
            var tmp = new QMNestedButton(tab, x, y, "Avatar Modifiers", "Modify Other's avatars", null, null, null, null, btnHalf);
            _ = new QMSingleButton(tmp, 5, 0, "Reload All Avatars", () => { MelonCoroutines.Start(AvatarUtils.ReloadAllAvatars()); }, "Reloads All avatars", null, null, true);
            RemoveMasksToggle = new QMSingleToggleButton(tmp, 1, 0, "Auto Remove Masks", () => { MaskDeleter = true; }, "Auto Remove Masks", () => { MaskDeleter = false; }, "Remove Masks From all avatars (Will make all Avatars Reload)", Color.green, Color.red, null, false, true);
            LewdifyToggle = new QMSingleToggleButton(tmp, 1, 0.5f, "Auto Lewdify", () => { Lewdify = true; }, "Auto Lewdify", () => { Lewdify = false; }, "Lewdifies All avatars In Instance (Will make all Avatars Reload)", Color.green, Color.red, null, false, true);
            ForceLewdifyToggle = new QMSingleToggleButton(tmp, 1, 1f, "Forced Lewdify", () => { ForceLewdify = true; }, "Forced Lewdify", () => { ForceLewdify = false; }, "Force Lewdify avatars (Destroys the Transforms, Due to SDK3 Avatars Refusing to toggle them.) (Will make all Avatars Reload)", Color.green, Color.red, null, false, true);
            LewdifierUtils.LewdifyLists = new QMSingleButton(tmp, 1, 1.5f, "NOT SET", new Action(() => { LewdifierUtils.RefreshAll(); }), "Refresh Current Lists", null, null, false);
            LewdifierUtils.LewdifyLists.SetResizeTextForBestFit(true);
        }

        public static void InitUserMenu(float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton("UserInteractMenu", x, y, "Avatar Utilities", "AstroClient Avatar utilities", null, null, null, null, btnHalf);
            _ = new QMSingleButton(menu, 1, 0, "Dump Avatar Transforms", () => { QuickMenuUtils.SelectedPlayer.Avatar_Transform_Dumper(); }, "Dump Avatar Transforms", null, null, true);
            _ = new QMSingleButton(menu, 1, 0.5f, "Dump Avatar Renderers", () => { QuickMenuUtils.SelectedPlayer.Avatar_Renderer_Dumper(); }, "Dump Avatar Renderers", null, null, true);
            _ = new QMSingleButton(menu, 1, 1, "Dump Avatar Materials", () => { QuickMenuUtils.SelectedPlayer.Avatar_Material_Dumper(); }, "Dump Avatar Materials", null, null, true);
            _ = new QMSingleButton(menu, 1, 1.5f, "Lewdify", () => { QuickMenuUtils.SelectedPlayer.Add_Lewdify(); }, "Lewdify This Player Avatar", null, null, true);
            _ = new QMSingleButton(menu, 1, 2, "Remove Lewdify Effect.", () => { QuickMenuUtils.SelectedPlayer.Remove_Lewdify(); }, "Remove the Lewdifier On this user..", null, null, true);
            _ = new QMSingleButton(menu, 1, 2.5f, "Skip Avatar Lewdifying.", () => { QuickMenuUtils.SelectedPlayer.BlackListAvatar_Lewdifier(); }, "Skip This Avatar From being Lewdified.", null, null, true);
            _ = new QMSingleButton(menu, 2, 0f, "Add Mask Remover", () => { QuickMenuUtils.SelectedPlayer.Add_MaskRemover(); }, "Remove The Annoying Mask Theme on this user.", null, null, true);
            _ = new QMSingleButton(menu, 2, 0.5f, "Remove Mask Remover", () => { QuickMenuUtils.SelectedPlayer.Add_MaskRemover(); }, "Remove The Mask Remover on this user.", null, null, true);
        }

        public override void OnPlayerJoined(Player player)
        {
            if (player == null) throw new ArgumentNullException();
            if (player != Utils.LocalPlayer.GetPlayer())
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
                    ForceLewdifyToggle.SetToggleState(value);
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
                if (value)
                {
                    foreach (var player in WorldUtils.Players)
                    {
                        if (player != Utils.LocalPlayer.GetPlayer())
                        {
                            if (player != null)
                            {
                                player.Add_Lewdify();
                            }
                        }
                    }
                }
                else
                {
                    foreach (var player in WorldUtils.Players)
                    {
                        if (player != Utils.LocalPlayer.GetPlayer())
                        {
                            if (player != null)
                            {
                                player.Remove_Lewdify();
                            }
                        }
                    }
                }
                _Lewdify = value;
                if (Lewdify != null)
                {
                    LewdifyToggle.SetToggleState(value);
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
                if (value)
                {
                    foreach (var player in WorldUtils.Players)
                    {
                        if (player != Utils.LocalPlayer.GetPlayer())
                        {
                            if (player != null)
                            {
                                player.Add_MaskRemover();
                            }
                        }
                    }
                }
                else
                {
                    foreach (var player in WorldUtils.Players)
                    {
                        if (player != Utils.LocalPlayer.GetPlayer())
                        {
                            if (player != null)
                            {
                                player.Remove_MaskRemover();
                            }
                        }
                    }
                }
                _MaskDeleter = value;
                if (RemoveMasksToggle != null)
                {
                    RemoveMasksToggle.SetToggleState(value);
                }
            }
        }
    }
}