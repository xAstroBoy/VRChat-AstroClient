using AstroClient.GameObjectDebug;
using AstroClient.Worlds;
using RubyButtonAPI;
using System;

namespace AstroClient.Startup.Buttons
{
    internal class WorldPickupsBtn
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var sub = new QMNestedButton(menu, x, y, "Pickup Control", "Pickup Control", null, null, null, null, btnHalf);
            new QMSingleButton(sub, 1, 0, "Reveal all world pickups", new Action(GameObjectUtils.EnableAllWorldPickups), "Enables all world pickups!", null, null);
            new QMSingleButton(sub, 2, 0, "Hide all world pickups", new Action(GameObjectUtils.DisableAllWorldPickups), "Disables all world pickups!", null, null);
            new QMSingleButton(sub, 3, 0, "Restore Original pickups pos", new Action(GameObjectUtils.TeleportPickupsToTheirDefaultPosition), "Restores all Pickups Original Position!", null, null);
            new QMSingleButton(sub, 1, 1, "Clear QPens Drawing Globally", new Action(QVPensUtils.ResetQPensGlobal), "Clears QPens Globally", null, null);
            new QMSingleButton(sub, 2, 1, "Allow Theft Globally", new Action(ObjectMiscOptions.AllowTheftGlobal), "Allows Theft", null, null, true);
            new QMSingleButton(sub, 2, 1.5f, "Disallow Theft Globally", new Action(ObjectMiscOptions.DisallowTheftGlobal), "Blocks Theft", null, null, true);
        }
    }
}