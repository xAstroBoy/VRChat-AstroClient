﻿using System.Windows.Forms;
using AstroClient.ClientResources.Loaders;
using AstroClient.Constants;
using AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using VRC;
using VRC.Core;
using VRC.UI;

namespace AstroClient.ClientUI.QuickMenuGUI.Wings
{
    using AvatarUtils = Tools.Player.AvatarUtils;

    internal class MainClientWings
    {
        internal static QMWingToggleButton WingDebugButton;

        internal static void InitMainWing()
        {
            var menu = new QMWings(1000, true, "AstroClient", "AstroClient Main", Icons.planet_sprite);
            new QMWingSingleButton(menu, "Copy Instance ID", () => { Clipboard.SetText($"{WorldUtils.FullID}"); }, "Copy the ID of the current instance.");
            new QMWingSingleButton(menu, "Join Instance", () => { new PortalInternal().Method_Private_Void_String_String_PDM_0(Clipboard.GetText().Split(':')[0], Clipboard.GetText().Split(':')[1]); }, "Join an instance via your clipboard.");
            new QMWingSingleButton(menu, "Avatar By ID", () =>
            {
                string text = Clipboard.GetText();
                if (text.StartsWith("avtr_")) new PageAvatar { field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal { field_Internal_ApiAvatar_0 = new ApiAvatar { id = text } } }.ChangeToSelectedAvatar();
                else Log.Error("Clipboard does not contains Avatar ID!");
            }, "Allows you to change into a public avatar with its id.");
            new QMWingSingleButton(menu, "Reload Avatars", () => { MelonCoroutines.Start(AvatarUtils.ReloadAllAvatars()); }, "Reloads All Avatars.");

            WingDebugButton = new QMWingToggleButton(menu, "Debug Console", () => { Bools.IsDebugMode = true; }, () => { Bools.IsDebugMode = false; }, "Toggle Debug Console", null, Bools.IsDebugMode);
        }
    }
}