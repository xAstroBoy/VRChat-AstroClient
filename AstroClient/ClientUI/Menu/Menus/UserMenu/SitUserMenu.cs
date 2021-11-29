namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using AstroMonos.Components.Player;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class SitUserMenu : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Sit", "Sit on selected player");
            _ = new QMSingleButton(submenu, "Sit On Head", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.SelectedPlayer, HumanBodyBones.Head); }, "Sit On Head");
            _ = new QMSingleButton(submenu, "Sit On LeftHand", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.SelectedPlayer, HumanBodyBones.LeftHand); }, "Sit On LeftHand");
            _ = new QMSingleButton(submenu, "Sit On RightHand", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.SelectedPlayer, HumanBodyBones.RightHand); }, "Sit On RightHand");
            _ = new QMSingleButton(submenu, "Sit On LeftFoot", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.SelectedPlayer, HumanBodyBones.LeftFoot); }, "Sit On LeftFoot");
            _ = new QMSingleButton(submenu, "Sit On RightFoot", () => { SitOnPlayer.AttachToTarget(QuickMenuUtils.SelectedPlayer, HumanBodyBones.RightFoot); }, "Sit On RightFoot");

            //var setHeightButton = new QMSingleButton(sitMenu, 3, 0, $"Set\nHeight\n{SitOnPlayer.Height}", () =>
            //{
            //	CheetosHelpers.PopupCall("Set Height Value", "Done", "Enter Height. . .", true, delegate (string text)
            //	{
            //		float value = 0f;

            //		try
            //		{
            //			value = float.Parse(text);
            //		}
            //		catch
            //		{
            //			ModConsole.Error("Input value must be a float value!");
            //		}
            //		finally
            //		{
            //			SitOnPlayer.Height = value / 100;
            //		}
            //	});
            //}, $"{SitOnPlayer.Height}");
        }
    }
}