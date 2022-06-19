﻿using System;
using AstroClient.AstroMonos.Components.ESP;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.World;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.ClientUI.QuickMenuGUI.ESP
{
    internal class VRChat_Map_ESP_Menu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        internal static void InitButtons(QMGridTab menu)
        {
            var main = new QMNestedGridMenu(menu, "ESP Menu", "ESP Options");

            PickupESPToggleBtn = new QMToggleButton(main,  "Pickup ESP", new Action(() => { Toggle_Pickup_ESP = true; }), new Action(() => { Toggle_Pickup_ESP = false; }), "Toggle Pickup ESP");
            VRCInteractableESPToggleBtn = new QMToggleButton(main,  "VRC Interactable ESP", new Action(() => { Toggle_VRCInteractable_ESP = true; }), new Action(() => { Toggle_VRCInteractable_ESP = false; }), "Toggle VRC Interactable ESP");
            TriggerESPToggleBtn = new QMToggleButton(main,  "Trigger ESP", new Action(() => { Toggle_Trigger_ESP = true; }), new Action(() => { Toggle_Trigger_ESP = false; }), "Toggle Trigger ESP");
            UdonBehaviourESPToggleBtn = new QMToggleButton(main,  "Udon Behaviour ESP", new Action(() => { Toggle_UdonBehaviour_ESP = true; }), new Action(() => { Toggle_UdonBehaviour_ESP = false; }), "Toggle Udon Behaviour ESP");
        }

        private static QMToggleButton VRCInteractableESPToggleBtn;
        private static QMToggleButton PickupESPToggleBtn;
        private static QMToggleButton TriggerESPToggleBtn;
        private static QMToggleButton UdonBehaviourESPToggleBtn;

        private void OnRoomLeft()
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
                    var renderer = item.GetGetInChildrens<Renderer>(true);
                    if (renderer != null)
                    {
                        renderer.GetOrAddComponent<ESP_VRCInteractable>();
                    }
                    else
                    {
                        ComponentUtils.GetOrAddComponent<ESP_VRCInteractable>(item);
                    }
                }
            }
        }

        internal static void RemoveESPToVRCInteractables()
        {
            var items = WorldUtils_Old.Get_VRCInteractables();
            foreach (var item in items)
            {
                var ESP = item.GetGetInChildrens<ESP_VRCInteractable>(true);
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
                    var renderer = item.GetGetInChildrens<Renderer>(true);
                    if (renderer != null)
                    {
                        renderer.GetOrAddComponent<ESP_Pickup>();
                    }
                    else
                    {
                        ComponentUtils.GetOrAddComponent<ESP_Pickup>(item);
                    }
                }
            }
        }

        private static void RemoveESPToPickups()
        {
            var items = WorldUtils_Old.Get_Pickups();
            foreach (var item in items)
            {
                var ESP = item.GetGetInChildrens<ESP_Pickup>(true);
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
                    ESP_Trigger triggeresp = null;
                    var renderer = item.GetGetInChildrens<Renderer>(true);
                    if (renderer != null)
                    {
                       triggeresp = renderer.GetOrAddComponent<ESP_Trigger>();
                    }
                    else
                    {
                      triggeresp =  ComponentUtils.GetOrAddComponent<ESP_Trigger>(item);
                    }

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
                        var renderer = item.gameObject.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.GetOrAddComponent<ESP_UdonBehaviour>();
                        }
                        else
                        {
                            ComponentUtils.GetOrAddComponent<ESP_UdonBehaviour>(item.gameObject);
                        }
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
                    var ESP = item.gameObject.GetGetInChildrens<ESP_UdonBehaviour>(true);
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