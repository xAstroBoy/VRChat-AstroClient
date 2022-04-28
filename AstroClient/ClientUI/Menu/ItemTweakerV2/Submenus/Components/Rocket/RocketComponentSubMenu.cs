using AstroClient.ClientActions;

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

    internal class RocketComponentSubMenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.OnRocketBehaviourPropertyChanged += OnRocketBehaviour_OnPropertyChanged;
        }
        internal static void Init_RocketComponentSubMenu(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedButton(menu, "Rocket Maker", "Turn Items Into Rockets, Be careful as they will explode on impact!");
            _ = new QMSingleButton(submenu, 1, 0, "Rocket Object Direction (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithG(); }), "Turn Held Object Into a rocket!", null, null);
            _ = new QMSingleButton(submenu, 2, 0, "Rocket Object Direction (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutG(); }), "Turn Held Object Into a rocket!", null, null);
            _ = new QMSingleButton(submenu, 1, 1, "Rocket Always UP (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithGAndGoUp(); }), "Turn Held Object Into a rocket!", null, null);
            _ = new QMSingleButton(submenu, 2, 1, "Rocket Always UP (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutGAndGoUp(); }), "Turn Held Object Into a rocket!", null, null);
            _ = new QMSingleButton(submenu, 5, 0, "Remove all rockets", new Action(KillAllRockets), "Removes all Rockets components from objects!", null, null);
            RocketTimer = new QMSingleButton(submenu, 4, 0, "none", null, "Tells What's the Rocket Speed!", null, null);
            _ = new QMSingleButton(submenu, 1, 2, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncRocketSpeed(); }), "Edits the Rocket Speed", null, null);
            _ = new QMSingleButton(submenu, 2, 2, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecRocketSpeed(); }), "Edits the Rocket Speed", null, null);
        }

        private void OnRocketBehaviour_OnPropertyChanged(RocketBehaviour RocketBehaviour)
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