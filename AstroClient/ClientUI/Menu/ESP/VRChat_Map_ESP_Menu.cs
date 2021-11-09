namespace AstroClient.ClientUI.QuickMenuButtons.ESP
{
    using System;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.ESP.Pickup;
    using AstroMonos.Components.ESP.Trigger;
    using AstroMonos.Components.ESP.UdonBehaviour;
    using AstroMonos.Components.ESP.VRCInteractable;
    using UnityEngine;

    internal class VRChat_Map_ESP_Menu : GameEvents
    {
        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "ESP Menu", "ESP Options", null, null, null, null, btnHalf);

            PickupESPToggleBtn = new QMSingleButton(main, 1, 0f, "Pickup ESP ON", new Action(() => { Toggle_Pickup_ESP = true; }), "Pickup ESP OFF", new Action(() => { Toggle_Pickup_ESP = false; }), "Toggle Pickup ESP", Color.green, Color.red, null, false, true);
            VRCInteractableESPToggleBtn = new QMSingleButton(main, 1, 0.5f, "VRC Interactable ESP ON", new Action(() => { Toggle_VRCInteractable_ESP = true; }), "VRC Interactable ESP OFF", new Action(() => { Toggle_VRCInteractable_ESP = false; }), "Toggle VRC Interactable ESP", Color.green, Color.red, null, false, true);
            TriggerESPToggleBtn = new QMSingleButton(main, 1, 1f, "Trigger ESP ON", new Action(() => { Toggle_Trigger_ESP = true; }), "Trigger ESP OFF", new Action(() => { Toggle_Trigger_ESP = false; }), "Toggle Trigger ESP", Color.green, Color.red, null, false, true);
            UdonBehaviourESPToggleBtn = new QMSingleButton(main, 1, 1.5f, "Udon Behaviour ESP ON", new Action(() => { Toggle_UdonBehaviour_ESP = true; }), "Udon Behaviour ESP OFF", new Action(() => { Toggle_UdonBehaviour_ESP = false; }), "Toggle Udon Behaviour ESP", Color.green, Color.red, null, false, true);
        }

        private static QMSingleButton VRCInteractableESPToggleBtn;
        private static QMSingleButton PickupESPToggleBtn;
        private static QMSingleButton TriggerESPToggleBtn;
        private static QMSingleButton UdonBehaviourESPToggleBtn;

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Toggle_VRCInteractable_ESP = false;
            Toggle_Trigger_ESP = false;
            Toggle_UdonBehaviour_ESP = false;
            Toggle_Pickup_ESP = false;
        }

        #region VRCInteractableESP

        private static bool _Toggle_VRCInteractable_ESP;

        internal static bool Toggle_VRCInteractable_ESP
        {
            get
            {
                return _Toggle_VRCInteractable_ESP;
            }
            set
            {
                if (value)
                {
                    AddESPToVRCInteractables();
                }
                else
                {
                    RemoveESPToVRCInteractables();
                }

                _Toggle_VRCInteractable_ESP = value;
                if (VRCInteractableESPToggleBtn != null)
                {
                    VRCInteractableESPToggleBtn.SetToggleState(value);
                }
            }
        }

        internal static void AddESPToVRCInteractables()
        {
            var items = WorldUtils_Old.Get_VRCInteractables();
            foreach (var item in items)
            {
                if (item != null)
                {
                    _ = item.GetOrAddComponent<ESP_VRCInteractable>();
                }
            }
        }

        internal static void RemoveESPToVRCInteractables()
        {
            var items = WorldUtils_Old.Get_VRCInteractables();
            foreach (var item in items)
            {
                var ESP = item.GetComponent<ESP_VRCInteractable>();
                if (ESP != null)
                {
                    ESP.DestroyMeLocal();
                }
            }
        }

        #endregion VRCInteractableESP

        #region PickupESP

        private static bool _Toggle_Pickup_ESP;

        internal static bool Toggle_Pickup_ESP
        {
            get
            {
                return _Toggle_Pickup_ESP;
            }
            set
            {
                if (value)
                {
                    AddESPToPickups();
                }
                else
                {
                    RemoveESPToPickups();
                }

                _Toggle_Pickup_ESP = value;
                if (PickupESPToggleBtn != null)
                {
                    PickupESPToggleBtn.SetToggleState(value);
                }
            }
        }

        private static void AddESPToPickups()
        {
            var items = WorldUtils_Old.Get_Pickups();
            foreach (var item in items)
            {
                if (item != null)
                {
                    _ = item.GetOrAddComponent<ESP_Pickup>();
                }
            }
        }

        private static void RemoveESPToPickups()
        {
            var items = WorldUtils_Old.Get_Pickups();
            foreach (var item in items)
            {
                var ESP = item.GetComponent<ESP_Pickup>();
                if (ESP != null)
                {
                    ESP.DestroyMeLocal();
                }
            }
        }

        #endregion PickupESP

        #region TriggerESP

        private static bool _Toggle_Trigger_ESP;

        internal static bool Toggle_Trigger_ESP
        {
            get
            {
                return _Toggle_Trigger_ESP;
            }
            set
            {
                if (value)
                {
                    AddESPToTriggers();
                }
                else
                {
                    RemoveESPToTriggers();
                }

                _Toggle_Trigger_ESP = value;
                if (TriggerESPToggleBtn != null)
                {
                    TriggerESPToggleBtn.SetToggleState(value);
                }
            }
        }

        private static void AddESPToTriggers()
        {
            var items = WorldUtils_Old.Get_Triggers();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var triggeresp = item.GetOrAddComponent<ESP_Trigger>();
                    if (triggeresp != null)
                    {
                        var trigger1 = item.GetComponent<VRC.SDKBase.VRC_Trigger>();
                        if (trigger1 != null)
                        {
                            triggeresp.trigger = trigger1;
                            triggeresp.Lock = false;
                        }
                        else
                        {
                            var trigger2 = item.GetComponent<VRCSDK2.VRC_Trigger>();
                            if (trigger2 != null)
                            {
                                triggeresp.trigger2 = trigger2;
                                triggeresp.Lock = false;
                            }
                        }
                    }
                }
            }
        }

        private static void RemoveESPToTriggers()
        {
            var items = WorldUtils_Old.Get_Triggers();
            foreach (var item in items)
            {
                var ESP = item.GetComponent<ESP_Trigger>();
                if (ESP != null)
                {
                    ESP.DestroyMeLocal();
                }
            }
        }

        #endregion TriggerESP

        #region UdonBehaviourESP

        private static bool _Toggle_UdonBehaviour_ESP;

        internal static bool Toggle_UdonBehaviour_ESP
        {
            get
            {
                return _Toggle_UdonBehaviour_ESP;
            }
            set
            {
                if (value)
                {
                    AddESPToUdonBehaviours();
                }
                else
                {
                    RemoveESPToUdonBehaviours();
                }

                _Toggle_UdonBehaviour_ESP = value;
                if (UdonBehaviourESPToggleBtn != null)
                {
                    UdonBehaviourESPToggleBtn.SetToggleState(value);
                }
            }
        }

        private static void AddESPToUdonBehaviours()
        {
            var items = WorldUtils_Old.Get_UdonBehaviours();
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        _ = item.gameObject.GetOrAddComponent<ESP_UdonBehaviour>();
                    }
                }
            }
        }

        private static void RemoveESPToUdonBehaviours()
        {
            var items = WorldUtils_Old.Get_UdonBehaviours();
            if (items != null)
            {
                foreach (var item in items)
                {
                    var ESP = item.GetComponent<ESP_UdonBehaviour>();
                    if (ESP != null)
                    {
                        ESP.DestroyMeLocal();
                    }
                }
            }
        }

        #endregion UdonBehaviourESP
    }
}