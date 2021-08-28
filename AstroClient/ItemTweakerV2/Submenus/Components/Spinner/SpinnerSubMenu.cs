namespace AstroClient.ItemTweakerV2.Submenus
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using RubyButtonAPI;
    using System;

    public class SpinnerSubMenu : Tweaker_Events
    {
        public static void Init_SpinnerSubMenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var submenu = new QMNestedButton(menu, x, y, "Spin Control", "Make them spiiiiin!", null, null, null, null, btnHalf);
            new QMSingleButton(submenu, 1, 0, "+ 1 x", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceX(); }), "Add Spin Force to spinner!", null, null);
            new QMSingleButton(submenu, 2, 0, "+ 1 Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceY(); }), "Add Spin Force to spinner!", null, null);
            new QMSingleButton(submenu, 3, 0, "+ 1 Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceZ(); }), "Add Spin Force to spinner!", null, null);
            ObjectSpinnerManager.SpinAmountTell = new QMSingleButton(submenu, 4, 0, "none", null, "Tells What's the spin force of the spinner!", null, null);
            new QMSingleButton(submenu, 1, 1, "- 1 x", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceX(); }), "Subtract Spin Force to spinner!", null, null);
            new QMSingleButton(submenu, 2, 1, "- 1 Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceY(); }), "Subtract Spin Force to spinner!", null, null);
            new QMSingleButton(submenu, 3, 1, "- 1 Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceZ(); }), "Subtract Spin Force to spinner!", null, null);
            ObjectSpinnerManager.SpinnerTimerBtn = new QMSingleButton(submenu, 4, 1, "none", null, "Tells What's the spin Speed!", null, null);
            new QMSingleButton(submenu, 2, 2, "Remove all Spinner Objects", new Action(ObjectSpinnerManager.KillObjectSpinners), "Removes all Spinner components from objects!", null, null);
            new QMSingleButton(submenu, 1, 2, "Remove Spinner from Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Spinner(); }), "Removes all Spinner components from object!", null, null);
            new QMSingleButton(submenu, 3, 2, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncSpinnerSpeed(); }), "Edits the Spinner Speed", null, null);
            new QMSingleButton(submenu, 4, 2, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecSpinnerSpeed(); }), "Edits the Spinner Speed", null, null);
        }
    }
}