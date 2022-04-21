namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Crazy
{
    using System;
    using System.Linq;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class CrazyComponentSubMenu : Tweaker_Events
    {
        internal static void Init_CrazyComponentSubMenu(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Crazy Object", "Make Items fly in random directions lol!");
            _ = new QMSingleButton(submenu,  "Crazy Object (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithGravity(); }), "Make Held Object Go Nuts!");
            _ = new QMSingleButton(submenu,  "Crazy Object (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithoutGravity(); }), "Make Held Object Go Nuts!");
            _ = new QMSingleButton(submenu,  "Remove all Crazy Objects", new Action(KillCrazyObjects), "Removes all Rockets components from objects!");
            CrazyTimerBtn = new QMSingleButton(submenu,  "none", null, "Tells CrazyObj Speed");
            _ = new QMSingleButton(submenu,  "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncCrazySpeed(); }), "Edits the CrazyObj Speed");
            _ = new QMSingleButton(submenu,  "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecCrazySpeed(); }), "Edits the CrazyObj Speed");
        }


        internal override void OnCrazyBehaviour_OnPropertyChanged(CrazyBehaviour CrazyBehaviour)
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