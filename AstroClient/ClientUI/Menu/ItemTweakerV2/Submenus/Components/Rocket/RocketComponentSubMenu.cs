namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Rocket
{
    using System;
    using System.Linq;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class RocketComponentSubMenu : Tweaker_Events
    {
        internal static void Init_RocketComponentSubMenu(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Rocket Maker", "Turn Items Into Rockets, Be careful as they will explode on impact!");
            _ = new QMSingleButton(submenu, "Rocket Object Direction (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithG(); }), "Turn Held Object Into a rocket!");
            _ = new QMSingleButton(submenu, "Rocket Object Direction (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutG(); }), "Turn Held Object Into a rocket!");
            _ = new QMSingleButton(submenu, "Rocket Always UP (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithGAndGoUp(); }), "Turn Held Object Into a rocket!");
            _ = new QMSingleButton(submenu, "Rocket Always UP (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutGAndGoUp(); }), "Turn Held Object Into a rocket!");
            _ = new QMSingleButton(submenu, "Remove all rockets", new Action(KillAllRockets), "Removes all Rockets components from objects!");
            RocketTimer = new QMSingleButton(submenu,  "none", null, "Tells What's the Rocket Speed!");
            _ = new QMSingleButton(submenu,  "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncRocketSpeed(); }), "Edits the Rocket Speed");
            _ = new QMSingleButton(submenu,  "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecRocketSpeed(); }), "Edits the Rocket Speed");
        }

        internal override void OnRocketBehaviour_OnPropertyChanged(RocketBehaviour RocketBehaviour)
        {
            if (RocketBehaviour != null)
            {
                RocketTimer.SetButtonText("Timer : " + RocketBehaviour.RocketTimer);
            }
            else
            {
                RocketTimer.SetButtonText("Timer : 0");
            }
        }


        internal static void KillAllRockets()
        {
            var list = Resources.FindObjectsOfTypeAll<RocketBehaviour>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                RocketBehaviour item = list[i];
                UnityEngine.Object.Destroy(item);
            }
        }

        private static QMSingleButton RocketTimer;
    }
}