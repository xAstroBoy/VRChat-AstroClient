namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Spinner
{
    using System;
    using System.Linq;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class SpinnerSubMenu : Tweaker_Events
    {



        internal static void Init_SpinnerSubMenu(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Spin Control", "Make them spiiiiin!");
            _ = new QMSingleButton(submenu,  "+ 1 x", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceX(); }), "Add Spin Force to spinner!");
            _ = new QMSingleButton(submenu,  "+ 1 Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceY(); }), "Add Spin Force to spinner!");
            _ = new QMSingleButton(submenu,  "+ 1 Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceZ(); }), "Add Spin Force to spinner!");
            SpinAmountTell = new QMSingleButton(submenu,  "none", null, "Tells What's the spin force of the spinner!");
            _ = new QMSingleButton(submenu,  "- 1 x", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceX(); }), "Subtract Spin Force to spinner!");
            _ = new QMSingleButton(submenu,  "- 1 Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceY(); }), "Subtract Spin Force to spinner!");
            _ = new QMSingleButton(submenu,  "- 1 Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceZ(); }), "Subtract Spin Force to spinner!");
             SpinnerTimerBtn = new QMSingleButton(submenu, "none", null, "Tells What's the spin Speed!");
            _ = new QMSingleButton(submenu,  "Remove all Spinner Objects", new Action(KillAllSpinners), "Removes all Spinner components from objects!");
            _ = new QMSingleButton(submenu,  "Remove Spinner from Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Spinner(); }), "Removes all Spinner components from object!");
            _ = new QMSingleButton(submenu,  "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncSpinnerSpeed(); }), "Edits the Spinner Speed");
            _ = new QMSingleButton(submenu,  "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecSpinnerSpeed(); }), "Edits the Spinner Speed");
        }

        internal static void KillAllSpinners()
        {
            var list = Resources.FindObjectsOfTypeAll<SpinnerBehaviour>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                SpinnerBehaviour item = list[i];
                UnityEngine.Object.Destroy(item);
            }
        }

        internal override void OnSpinnerBehaviour_OnPropertyChanged(SpinnerBehaviour SpinnerBehaviour)
        {
            if (SpinnerBehaviour != null)
            {
                SpinnerTimerBtn.SetButtonText("Timer : " + SpinnerBehaviour.SpinnerTimer);
                SpinAmountTell.SetButtonText("X : " + SpinnerBehaviour.ForceX + " Y : " + SpinnerBehaviour.ForceY + " Z :" + SpinnerBehaviour.ForceZ);
            }
            else
            {
                SpinnerTimerBtn.SetButtonText("Timer : " + "0");
                SpinAmountTell.SetButtonText("X : " + "0" + " Y : " + "0" + " Z :" + "0");
            }

        }

        private static QMSingleButton SpinAmountTell;
        private static QMSingleButton SpinnerTimerBtn;
    }
}