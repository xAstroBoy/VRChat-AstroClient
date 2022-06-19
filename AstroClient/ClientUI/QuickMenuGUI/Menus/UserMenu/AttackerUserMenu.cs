using System;
using AstroClient.Constants;
using AstroClient.Tools.ObjectEditor;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.ClientUI.QuickMenuGUI.Menus.UserMenu
{
    internal class AttackerUserMenu : AstroEvents
    {

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            if (Bools.AllowAttackerComponent)
            {

                var submenu = new QMNestedGridMenu(menu, "Attack", "Attack selected player");
                _ = new QMSingleButton(submenu, 3, 0, "All Pickups Attack player.", new Action(ObjectMiscOptions.AllWorldPickupsAttackTarget), "Make that dirty pickup thief regret stealing from you.", null, null);
                _ = new QMSingleButton(submenu, 3, 1, "Remove\nPlayer (bound) Attackers", new Action(ObjectMiscOptions.RemoveAllAttackPlayer), "Removes any Attackers bound to this player.", null, null);
            }
        }
    }
}