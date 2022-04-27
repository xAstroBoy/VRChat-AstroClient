using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Crazy
{
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using System;
    using System.Linq;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class CrazyComponentSubMenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.Event_OnCrazyBehaviourPropertyChanged += OnCrazyBehaviour_OnPropertyChanged;
        }

        internal static void Init_CrazyComponentSubMenu(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedButton(menu, "Crazy Object", "Make Items fly in random directions lol!");
            _ = new QMSingleButton(submenu, 1, 0, "Crazy Object (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithGravity(); }), "Make Held Object Go Nuts!", null, null);
            _ = new QMSingleButton(submenu, 2, 0, "Crazy Object (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithoutGravity(); }), "Make Held Object Go Nuts!", null, null);
            _ = new QMSingleButton(submenu, 3, 0, "Remove all Crazy Objects", new Action(KillCrazyObjects), "Removes all Rockets components from objects!", null, null);
            CrazyTimerBtn = new QMSingleButton(submenu, 4, 0, "none", null, "Tells CrazyObj Speed", null, null);
            _ = new QMSingleButton(submenu, 1, 1, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncCrazySpeed(); }), "Edits the CrazyObj Speed", null, null);
            _ = new QMSingleButton(submenu, 2, 1, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecCrazySpeed(); }), "Edits the CrazyObj Speed", null, null);
        }

        private void OnCrazyBehaviour_OnPropertyChanged(CrazyBehaviour CrazyBehaviour)
        {
            if (CrazyBehaviour != null)
            {
                CrazyTimerBtn.SetButtonText("Timer : " + CrazyBehaviour.CrazyTimer);
            }
            else
            {
                CrazyTimerBtn.SetButtonText("Timer : " + "0");
            }
        }

        internal static void KillCrazyObjects()
        {
            var list = Resources.FindObjectsOfTypeAll<CrazyBehaviour>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                CrazyBehaviour item = list[i];
                UnityEngine.Object.Destroy(item);
            }
        }

        private static QMSingleButton CrazyTimerBtn;
    }
}