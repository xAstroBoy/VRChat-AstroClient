namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using System;
    using Constants;
    using Tools.ObjectEditor;
    using xAstroBoy.AstroButtonAPI;

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