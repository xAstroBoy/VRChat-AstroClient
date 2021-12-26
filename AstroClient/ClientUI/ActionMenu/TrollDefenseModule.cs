namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using Gompoc.ActionMenuAPI.Api;
    using Menu.ESP;
    using Menu.RandomSubmenus;
    using Menu.SettingsMenu;
    using Spawnables.Enderpearl;
    using Tools.Player.Movement.Exploit;

    internal class TrollDefenseModule : AstroEvents
    {
        internal override void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Troll Defense Options", () =>
            {
                CustomSubMenu.AddToggle("Crash Sit Troll", TrollDefenseSubMenu.SerializerTroll, ToggleValue => { TrollDefenseSubMenu.SerializerTroll = ToggleValue; }, null, false);
            });

            ModConsole.Log("Troll Defense Module is ready!", Color.Green);
        }
    }
}