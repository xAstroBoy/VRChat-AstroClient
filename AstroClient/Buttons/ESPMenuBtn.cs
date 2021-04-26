using AstroClient.components;
using AstroClient.GameObjectDebug;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using UnityEngine;
using VRC;

namespace AstroClient.Startup.Buttons
{
    internal class ESPMenuBtn : GameEvents
    {
        public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "ESP Menu", "ESP Options", null, null, null, null, btnHalf);
            PlayerESPToggleBtn = new QMSingleToggleButton(main, 1, 0f, "Player ESP ON", new Action(() => { EnabledPlayerESP = true; }), "Player ESP OFF", new Action(() => { EnabledPlayerESP = false; }), "Toggles Player ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            
            PickupESPToggleBtn = new QMSingleToggleButton(main, 2, 0f, "Pickup ESP ON", new Action(() => { EnabledPickupESP = true; }), "Pickup ESP OFF", new Action(() => { EnabledPickupESP = false; }), "Toggle Pickup ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            VRCInteractableESPToggleBtn = new QMSingleToggleButton(main, 2, 0.5f, "VRC Interactable ESP ON", new Action(() => { EnabledVRCInteractableESP = true; }), "VRC Interactable ESP OFF", new Action(() => { EnabledVRCInteractableESP = false; }), "Toggle VRC Interactable ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            TriggerESPToggleBtn = new QMSingleToggleButton(main, 2, 1f, "Trigger ESP ON", new Action(() => { EnabledTriggerESP = true; }), "Trigger ESP OFF", new Action(() => { EnabledTriggerESP = false; }), "Toggle Trigger ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            UdonBehaviourESPToggleBtn = new QMSingleToggleButton(main, 2, 1.5f, "Udon Behaviour ESP ON", new Action(() => { EnabledUdonBehaviourESP = true; }), "Udon Behaviour ESP OFF", new Action(() => { EnabledUdonBehaviourESP = false; }), "Toggle Udon Behaviour ESP", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
        }

        public override void OnLevelLoaded()
        {
            EnabledPickupESP = false;
            EnabledVRCInteractableESP = false;
            EnabledTriggerESP = false;
            EnabledUdonBehaviourESP = false;
        }


        public readonly static string PickupESPColorHex = "4AB30D";
        public readonly static string VRCInteractableESPColorHex = "E47D39";
        public readonly static string TriggerESPColorHex = "EF2C3F";
        public readonly static string UdonBehaviourESPColorHex = "CD14C7";

        private static QMSingleToggleButton PlayerESPToggleBtn;
        private static QMSingleToggleButton VRCInteractableESPToggleBtn;
        private static QMSingleToggleButton PickupESPToggleBtn;
        private static QMSingleToggleButton TriggerESPToggleBtn;
        private static QMSingleToggleButton UdonBehaviourESPToggleBtn;


        #region VRCInteractableESP

        private static bool _EnabledVRCInteractableESP;

        private static bool EnabledVRCInteractableESP
        {
            get
            {
                return _EnabledVRCInteractableESP;
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

                _EnabledVRCInteractableESP = value;
                if (VRCInteractableESPToggleBtn != null)
                {
                    VRCInteractableESPToggleBtn.setToggleState(value);
                }
            }
        }

        public static void AddESPToVRCInteractables()
        {
            var items = WorldUtils.GetAllVRCInteractables();
            foreach (var item in items)
            {
                if (item != null)
                {
                    ObjectESP VRCInteractable = item.AddComponent<ObjectESP>();
                    if (VRCInteractable != null)
                    {
                        VRCInteractable.ChangeColor(VRCInteractableESPColorHex);
                    }
                }
            }
        }

        public static void RemoveESPToVRCInteractables()
        {
            var items = WorldUtils.GetAllVRCInteractables();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var ESP = item.GetComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        UnityEngine.Object.Destroy(ESP);
                    }
                }
            }
        }

        #endregion

        #region PickupESP

        private static bool _EnabledPickupESP;

        private static bool EnabledPickupESP
        {
            get
            {
                return _EnabledPickupESP;
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

                _EnabledPickupESP = value;
                if (PickupESPToggleBtn != null)
                {
                    PickupESPToggleBtn.setToggleState(value);
                }
            }
        }

        private static void AddESPToPickups()
        {
            var items = WorldUtils.GetPickups();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var Pickup = item.AddComponent<ObjectESP>();
                    if (Pickup != null)
                    {
                        Pickup.ChangeColor(PickupESPColorHex);
                    }
                }
            }
        }

        private static void RemoveESPToPickups()
        {
            var items = WorldUtils.GetPickups();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var ESP = item.GetComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        UnityEngine.Object.Destroy(ESP);
                    }
                }
            }
        }

        #endregion

        #region TriggerESP

        private static bool _EnabledTriggerESP;

        private static bool EnabledTriggerESP
        {
            get
            {
                return _EnabledTriggerESP;
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

                _EnabledTriggerESP = value;
                if (TriggerESPToggleBtn != null)
                {
                    TriggerESPToggleBtn.setToggleState(value);
                }
            }
        }

        private static void AddESPToTriggers()
        {
            var items = WorldUtils.GetTriggers();
                foreach (var item in items)
                {
                    if (item != null)
                    {
                          var trigger = item.AddComponent<ObjectESP>();
                    if(trigger != null)
                    {
                        trigger.ChangeColor(TriggerESPColorHex);
                    }
                        //if (WorldUtils.GetWorldID() == WorldIds.SnoozeScaryMaze5)
                        //{
                        //    if (item.name == "The Doctor Watcher Activate")
                        //    {
                        //        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                        //        continue;
                        //    }
                        //    if (item.name == "Teddy Watcher Activate")
                        //    {
                        //        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                        //        continue;
                        //    }
                        //    if (item.name == "Kill Trigger For Maze Part 2")
                        //    {
                        //        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                        //        continue;
                        //    }
                        //    if (item.name == "Kill Trigger For Maze")
                        //    {
                        //        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                        //        continue;
                        //    }
                        //    if (item.transform.parent != null && item.transform.parent.gameObject != null)
                        //    {
                        //        if (item.transform.parent.gameObject.name == "Do Something Easter Egg")
                        //        {
                        //            if (item.name == "Area Trigger")
                        //            {
                        //                ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name + " With parent : " + item.transform.parent.gameObject.name);
                        //                continue;
                        //            }
                        //        }
                        //    }

                        //    item.AddComponent<ObjectESP>();
                        //}
                        //else
                        //{
                        //    item.AddComponent<ObjectESP>();
                        //}
                    }
                }
        }

        private static void RemoveESPToTriggers()
        {
            var items = WorldUtils.GetTriggers();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var ESP = item.GetComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        UnityEngine.Object.Destroy(ESP);
                    }
                }
            }
        }

        #endregion

        #region playerESP
        private static bool _EnabledPlayerESP;

        public static bool EnabledPlayerESP
        {
            get
            {
                return _EnabledPlayerESP;
            }
            set
            {
                if (value)
                {
                    AddESPToAllPlayers();
                }
                else
                {
                    RemoveAllActivePlayerESPs();
                }

                _EnabledPlayerESP = value;
                if (PlayerESPToggleBtn != null)
                {
                    PlayerESPToggleBtn.setToggleState(value);
                }
            }
        }


        public override void OnPlayerJoined(Player player)
        {
            if (EnabledPlayerESP)
            {
                if (player != null && player != LocalPlayerUtils.GetSelfPlayer())
                {
                    var esp = player.gameObject.AddComponent<PlayerESP>();                }
            }
        }

        private static void AddESPToAllPlayers()
        {
            foreach (var item in WorldUtils.GetAllPlayers0())
            {
                if (item != LocalPlayerUtils.GetSelfPlayer())
                {
                   if (item.gameObject.GetComponent<PlayerESP>() == null)
                    {
                       var esp = item.gameObject.AddComponent<PlayerESP>();
                    }
                }
            }
        }

        private static void RemoveAllActivePlayerESPs()
        {
            foreach (var player in WorldUtils.GetAllPlayers0())
            {

                var esp = player.gameObject.GetComponent<PlayerESP>();
                if (esp != null)
                {
                    UnityEngine.Object.Destroy(esp);
                }
            }
        }

        #endregion

        #region UdonBehaviourESP

        private static bool _EnabledUdonBehaviourESP;
        private static bool EnabledUdonBehaviourESP
        {
            get
            {
                return _EnabledUdonBehaviourESP;
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

                _EnabledUdonBehaviourESP = value;
                if (UdonBehaviourESPToggleBtn != null)
                {
                    UdonBehaviourESPToggleBtn.setToggleState(value);
                }
            }
        }

        private static void AddESPToUdonBehaviours()
        {
            var items = WorldUtils.GetUdonBehaviours();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var UdonBehaviour = item.AddComponent<ObjectESP>();
                    if (UdonBehaviour != null)
                    {
                        UdonBehaviour.ChangeColor(UdonBehaviourESPColorHex);
                    }
                }
            }
        }

        private static void RemoveESPToUdonBehaviours()
        {
            var items = WorldUtils.GetUdonBehaviours();
            foreach (var item in items)
            {
                if (item != null)
                {
                    var ESP = item.GetComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        UnityEngine.Object.Destroy(ESP);
                    }
                }
            }
        }

        #endregion


    }
}