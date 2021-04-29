using AstroClient.components;
using AstroClient.extensions;
using RubyButtonAPI;
using System;
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

        public static string Pickup_Identifier { get; private set; } = "Pickup_ID";
        public static string VRCInteractable_Identifier{ get; private set; } = "VRCInteractable_ID";
        public static string Trigger_Identifier { get; private set; } = "Trigger_ID";
        public static string UdonBehaviour_Identifier { get; private set; } = "UdonBehaviour_ID";

        public static string Default_PickupESPColorHex { get; private set; } = "4AB30D";
        public static string Default_VRCInteractableESPColorHex { get; private set; } = "E47D39";
        public static string Default_TriggerESPColorHex { get; private set; } = "EF2C3F";
        public static string Default_UdonBehaviourESPColorHex { get; private set; } = "CD14C7";

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
                    ObjectESP ESP = item.AddComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        ESP.Id = VRCInteractable_Identifier;
                        ESP.ChangeColor(Default_VRCInteractableESPColorHex);
                    }
                }
            }
        }

        public static void RemoveESPToVRCInteractables()
        {
            var items = WorldUtils.GetAllVRCInteractables();
            foreach (var item in items)
            {
                item.DestroyESPByIdentifier(VRCInteractable_Identifier);
            }
        }

        #endregion VRCInteractableESP

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
                    var ESP = item.AddComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        ESP.Id = Pickup_Identifier;
                        ESP.ChangeColor(Default_PickupESPColorHex);
                    }
                }
            }
        }

        private static void RemoveESPToPickups()
        {
            var items = WorldUtils.GetPickups();
            foreach (var item in items)
            {
                item.DestroyESPByIdentifier(Pickup_Identifier);
            }
        }

        #endregion PickupESP

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
                    ObjectESP ESP = item.AddComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        ESP.Id = Trigger_Identifier;
                        ESP.ChangeColor(Default_TriggerESPColorHex);
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
                item.DestroyESPByIdentifier(Trigger_Identifier);
            }
        }

        #endregion TriggerESP

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
                    player.gameObject.AddComponent<PlayerESP>();
                }
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
                        item.gameObject.AddComponent<PlayerESP>();
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

        #endregion playerESP

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
                    var ESP = item.AddComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        ESP.Id = UdonBehaviour_Identifier;
                        ESP.ChangeColor(Default_UdonBehaviourESPColorHex);
                    }
                }
            }
        }

        private static void RemoveESPToUdonBehaviours()
        {
            var items = WorldUtils.GetUdonBehaviours();
            foreach (var item in items)
            {
                item.DestroyESPByIdentifier(UdonBehaviour_Identifier);
            }
        }

        #endregion UdonBehaviourESP
    }
}