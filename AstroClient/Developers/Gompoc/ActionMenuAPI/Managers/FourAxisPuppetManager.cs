using AstroClient.ClientActions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.Gompoc.ActionMenuAPI.Managers
{
    using System;
    using Helpers;
    using Types;
    using UnityEngine;
    using UnityEngine.XR;

    internal class FourAxisPuppetManagerEventHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnUpdate += OnUpdate; 
            ClientEventActions.VRChat_OnActionMenuInit += VRChat_OnActionMenuInit;

        }

        private void VRChat_OnActionMenuInit()
        {
            FourAxisPuppetManager.Setup();
        }
        private void OnUpdate()
        {
            FourAxisPuppetManager.OnUpdate();
        }
    }


    internal static class FourAxisPuppetManager
    {
        private static AxisPuppetMenu fourAxisPuppetMenuRight;
        private static AxisPuppetMenu fourAxisPuppetMenuLeft;
        private static ActionMenuHand hand;
        private static bool open;
        public static AxisPuppetMenu current { get; private set; }

        public static Vector2 fourAxisPuppetValue { get; set; }

        public static Action<Vector2> onUpdate { get; set; }

        public static void Setup()
        {
            fourAxisPuppetMenuLeft = Utilities
                .CloneGameObject(QuickMenuTools.UserInterface.FindObject("ActionMenu/Container/MenuL/ActionMenu/AxisPuppetMenu").gameObject, QuickMenuTools.UserInterface.FindObject("ActionMenu/Container/MenuL/ActionMenu").gameObject).GetComponent<AxisPuppetMenu>();
            fourAxisPuppetMenuRight = Utilities
                                    .CloneGameObject(QuickMenuTools.UserInterface.FindObject("ActionMenu/Container/MenuR/ActionMenu/AxisPuppetMenu").gameObject, QuickMenuTools.UserInterface.FindObject("ActionMenu/Container/MenuR/ActionMenu").gameObject).GetComponent<AxisPuppetMenu>();
        }

        public static void OnUpdate()
        {
            //Probably a better more efficient way to do all this
            if (current != null && current.gameObject.gameObject.active)
            {
                if (XRDevice.isPresent)
                {
                    if (hand == ActionMenuHand.Right)
                    {
                        if (Input.GetAxis(Constants.RIGHT_TRIGGER) >= 0.4f)
                        {
                            CloseFourAxisMenu();
                            return;
                        }
                    }
                    else if (hand == ActionMenuHand.Left)
                    {
                        if (Input.GetAxis(Constants.LEFT_TRIGGER) >= 0.4f)
                        {
                            CloseFourAxisMenu();
                            return;
                        }
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    CloseFourAxisMenu();
                    return;
                }

                fourAxisPuppetValue = (hand == ActionMenuHand.Left ? InputManager.LeftInput : InputManager.RightInput) / 16;
                var x = fourAxisPuppetValue.x;
                var y = fourAxisPuppetValue.y;
                if (x >= 0)
                {
                    current.GetFillLeft().SetAlpha(0);
                    current.GetFillRight().SetAlpha(x);
                }
                else
                {
                    current.GetFillLeft().SetAlpha(Math.Abs(x));
                    current.GetFillRight().SetAlpha(0);
                }

                if (y >= 0)
                {
                    current.GetFillDown().SetAlpha(0);
                    current.GetFillUp().SetAlpha(y);
                }
                else
                {
                    current.GetFillDown().SetAlpha(Math.Abs(y));
                    current.GetFillUp().SetAlpha(0);
                }

                UpdateMathStuff();
                CallUpdateAction();
            }
        }

        public static void OpenFourAxisMenu(string title, Action<Vector2> update, PedalOption pedalOption)
        {
            if (open) return;
            switch (hand = Utilities.GetActionMenuHand())
            {
                case ActionMenuHand.Invalid:
                    return;
                case ActionMenuHand.Left:
                    current = fourAxisPuppetMenuLeft;
                    open = true;
                    break;
                case ActionMenuHand.Right:
                    current = fourAxisPuppetMenuRight;
                    open = true;
                    break;
            }
            Input.ResetInputAxes();
            InputManager.ResetMousePos();
            onUpdate = update;
            current.gameObject.SetActive(true);
            current.GetTitle().text = title;
            var actionMenu = Utilities.GetActionMenuOpener().GetActionMenu();
            actionMenu.DisableInput();
            actionMenu.SetMainMenuOpacity(0.5f);
            current.transform.localPosition = pedalOption.GetActionButton().transform.localPosition;
        }

        private static void CallUpdateAction()
        {
            try
            {
                onUpdate?.Invoke(fourAxisPuppetValue);
            }
            catch (Exception e)
            {
                Log.Error($"Exception caught in onUpdate action passed to Four Axis Puppet:");
                Log.Exception(e);
            }
        }

        public static void CloseFourAxisMenu()
        {
            if (current == null) return;
            CallUpdateAction();
            current.gameObject.SetActive(false);
            current = null;
            open = false;
            hand = ActionMenuHand.Invalid;
            var actionMenu = Utilities.GetActionMenuOpener().GetActionMenu();
            actionMenu.SetMainMenuOpacity();
            actionMenu.EnableInput();
        }

        private static void UpdateMathStuff()
        {
            var mousePos = hand == ActionMenuHand.Left ? InputManager.LeftInput : InputManager.RightInput;
            current.GetCursor().transform.localPosition = mousePos * 4;
        }
    }
}