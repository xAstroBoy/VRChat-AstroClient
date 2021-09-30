namespace AstroClient.AntiCrash
{
    using RubyButtonAPI;
    using UnityEngine;

    /// <summary>
    /// I don't recommend calling it VRCAC.
    /// As I'm not going to be straight up ripping the code.
    /// I'm rewriting and using VRCAC as a reference.
    /// This is going to be our own AntiCrash :)
    /// </summary>
    internal class VRCAntiCrash_InitButtons : GameEvents
    {
        // MOST ACTIONS REQUIRE A CONFIG!
        // FOR FULL PORT WE NEED A CONFIG .

        internal static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "VRCAntiCrash", "Ported VRCAntiCrash Features", null, null, null, null, btnHalf);
            _ = new QMSingleButton(menu, 0, -0.5f, "Pay Respect", () => { }, "Pay Respect To All Crashers Who Will fail to Crash You", null, null, true); // NEEDS ACTION AND CONFIG;
            _ = new QMSingleButton(menu, 0, 0, "Select Self", () => { }, "Select Your Own User.", null, null, true); // NEEDS ACTION
            _ = new QMSingleButton(menu, 0, 0.5f, "Reload Avatars", () => { }, "Reload All Avatars in Your Current instance.", null, null, true); // NEEDS ACTION
            InitKinkySubmenu(menu, 0, 1f, true);

            _ = new QMSingleToggleButton(menu, 1, 0, "Fly", () => { }, "Fly", () => { }, "Toggle Fly With VR Support", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 2, 0, "NoClip", () => { }, "NoClip", () => { }, "Toggle NoClip With VR Support", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 3, 0, "Force Clone", () => { }, "Force Clone", () => { }, "Toggle Forrce Clone", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 4, 0, "Player ESP", () => { }, "Player ESP", () => { }, "Toggle Player ESP , (Bubbles Around Player)", Color.green, Color.red, null, false, true);

            _ = new QMSingleToggleButton(menu, 1, 0.5f, "Delete Portals", () => { }, "Delete Portals", () => { }, "Toggle Deleting Portals if you fail entering them due to checks", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 2, 0.5f, "Info +", () => { }, "Info +", () => { }, "Toggle Info + - Adds Information To The Userinfo Page, and more", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 3, 0.5f, "Speed +", () => { }, "Speed +", () => { }, "Toggle Speed + - Sliders on the next page.", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 4, 0.5f, "Allow Friends", () => { }, "Allow Friends", () => { }, "Toggle Allow Friends , To allow friends portals to be entered.", Color.green, Color.red, null, false, true);

            _ = new QMSingleToggleButton(menu, 1, 1, "Rainbow ESP", () => { }, "Rainbow ESP", () => { }, "Toggle Rainbow ESP , Make the border of anything you hower rainbow.", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 2, 1, "Anti-Spawn Shit", () => { }, "Anti-Spawn Shit", () => { }, "Toggle Anti-Spawn Shit , Make avatar with intros such as audio or particles not show.", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 3, 1, "Player Collision", () => { }, "Player Collision", () => { }, "Toggle Player Collision , Make Players who walk into you be able to push you.", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 4, 1, "Anti-Lewd", () => { }, "Anti-Lewd", () => { }, "Toggle Anti-Lewd , Make Avatars with Easily recognizable lewd objects such as toggleable Dicks not show.", Color.green, Color.red, null, false, true);

            _ = new QMSingleToggleButton(menu, 1, 1.5f, "Anti Portal Enter", () => { }, "Anti Portal Enter", () => { }, "Toggle Anti Portal Enter , Make You only able to enter portals by you or friends Depending on allow friends Option & Auto Deletes Portals on enter.", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 2, 1.5f, "Fly OnPress", () => { }, "Fly OnPress", () => { }, "Toggle Fly OnPress , Make Fly/NoClip Fly Up/Down When Q/E Are HELD , With this Off it will be toggle-Mode.", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 3, 1.5f, "Anti-Pickup Crash", () => { }, "Anti-Pickup Crash", () => { }, "Toggle Anti-Pickup Crash , Automatically Gets Rid of pickups Being Used to Crash you upon Being teleported to you.", Color.green, Color.red, null, false, true);
            _ = new QMSingleToggleButton(menu, 4, 1.5f, "Anti-World Triggers", () => { }, "Anti-World Triggers", () => { }, "Toggle Anti-World Triggers , Stop Clients with World Triggers From Affecting You.", Color.green, Color.red, null, false, true);
        }

        internal static void InitKinkySubmenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "Kinky Options", "Ported VRCAntiCrash Kinky Features", null, null, null, null, btnHalf);
            _ = new QMSingleButton(menu, 1, 0, "Leash", () => { }, "Toggles A Leash To your Master", null, null, true); // NEEDS ACTION;
            _ = new QMSingleButton(menu, 1, 0.5f, "Auto Lewdify", () => { }, "Automatically lewdifies avatars that spawns in.", null, null, true); // NEEDS ACTION ;
            _ = new QMSingleButton(menu, 1, 1, "Force Lewdify", () => { }, "Destroy meshes to bypass avatars 3.0 attempting to stop lewdify function", null, null, true); // NEEDS ACTION;

            // ADD SLIDER
        }
    }
}