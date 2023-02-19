using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Utility;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using Tools.Extensions;
    using Tools.Skybox;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class FBTHeaven : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private static readonly string[] Trash = new[]
        {
            "FBT_Heaven_Extend V3/[Prefebs]/FBT Heaven Extension V3_Compressed/Foyer Blind Box",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (1)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (3)/Blindbox (7)/Blindbox_Top",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (2)/Blindbox_Top (2)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox/Blindbox (4)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (2)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (2)/Blindbox (6)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (3)/Blindbox (7)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (3)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (3)/Blindbox_Top (3)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox/Blindbox_Top",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (1)/Blindbox (5)/Blindbox_Top",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (1)/Blindbox_Top (1)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox/Blindbox (4)/Blindbox_Top",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (2)/Blindbox (6)/Blindbox_Top",
            "FBT Heaven Main Area/[AREA_DEVIDERS]/Blindbox (1)/Blindbox (5)",
            "FBT Heaven Main Area/[AREA_DEVIDERS]",
            "FBT Heaven Main Area/[OCCLUSION]",
            "We stand with EAC template [Collider]",
            "World Admin Panel/AdminTool/FunArea/_areaObj/_allowedArea"
        };

        private static readonly string[] SecureAreas = new[]
        {
            "[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 3/PrivateDoorSet/SecureArea",
            "[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 2/PrivateDoorSet/SecureArea",
            "[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 4/SecureArea",
            "[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 3/SecureArea",
            "[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 1/SecureArea",
            "[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 2/SecureArea",
        };

        private bool _HasSubscribed = false;

        private bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                    }
                }
                _HasSubscribed = value;
            }
        }

        internal static QMNestedGridMenu FBTExploitsPage;
        private static bool isCurrentWorld;
        internal static WorldButton_Squared ToggleLock_4 { get; set; } = null;
        internal static WorldButton_Squared ToggleLock_1 { get; set; } = null;
        internal static WorldButton_Squared EnterRoom_3 { get; set; } = null;
        internal static WorldButton_Squared EnterRoom_4 { get; set; } = null;
        internal static WorldButton_Squared ToggleLock_3 { get; set; } = null;
        internal static WorldButton_Squared EnterRoom_2 { get; set; } = null;
        internal static WorldButton_Squared EnterRoom_1 { get; set; } = null;
        internal static WorldButton_Squared ToggleLock_2 { get; set; } = null;

        internal static void InitButtons(QMGridTab main)
        {
            FBTExploitsPage = new QMNestedGridMenu(main, "FBTHeaven Exploits", "FBTHeaven Exploits");
            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n1", () => { ToggleDoor_1(); }, "Toggle Door 1");
            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n2", () => { ToggleDoor_2(); }, "Toggle Door 2");
            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n3", () => { ToggleDoor_3(); }, "Toggle Door 3");
            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n4", () => { ToggleDoor_4(); }, "Toggle Door 4");
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.FBTHeaven)
            {
                if (FBTExploitsPage != null)
                {
                    FBTExploitsPage.SetInteractable(true);
                    FBTExploitsPage.SetTextColor(Color.green);
                }
                HasSubscribed = true;

                GameObject_RPC_Firewall.EditRule("Main Code", "_RoomDestroy", false, false, true);

                isCurrentWorld = true;
                Log.Debug($"Recognized {Name} World,  Removing Blinders and Dividers...");

                foreach (var item in Trash)
                {
                    try
                    {
                        var obj = Finder.Find(item);
                        if (obj != null)
                        {
                            obj.DestroyMeLocal(false);
                        }
                    }
                    catch { }
                }

                if (SkyboxEditor.SetSkyboxByFileName("Skybox_Space 2 Large"))
                {
                    Log.Debug("Replaced FBT heaven Skybox as is dark and the author made it on purpose to prevent fly/noclip members.");
                }
                
                if(Room_1_LockObject != null)
                {
                    Room_1_LockInteract = Room_1_LockObject.gameObject.FindUdonEvent("_interact");
                }
                if (Room_2_LockObject != null)
                {
                    Room_2_LockInteract = Room_2_LockObject.gameObject.FindUdonEvent("_interact");
                }
                if (Room_3_LockObject != null)
                {
                    Room_3_LockInteract = Room_3_LockObject.gameObject.FindUdonEvent("_interact");
                }
                if (Room_4_LockObject != null)
                {
                    Room_4_LockInteract = Room_4_LockObject.gameObject.FindUdonEvent("_interact");
                }

                CreateWorldButtons();
                PatchSecureZones();

            }
            else
            {
                if (FBTExploitsPage != null)
                {
                    FBTExploitsPage.SetInteractable(false);
                    FBTExploitsPage.SetTextColor(Color.red);
                }
            }
        }

        private static void CreateWorldButtons()
        {
            if (ToggleLock_4 == null)
            {
                ToggleLock_4 = new WorldButton_Squared(new Vector3(-17.992f, 7.9996f, 3.2f), new Vector3(0f, 0f, 270f), 0.6f, "<color=green>Lockpick Room</color>", ToggleDoor_4);
                ToggleLock_4.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (ToggleLock_1 == null)
            {
                ToggleLock_1 = new WorldButton_Squared(new Vector3(-5.299f, 7.9368f, 5.9999f), new Vector3(0f, 90f, 270f), 0.6f, "<color=green>Lockpick Room</color>", ToggleDoor_1);
                ToggleLock_1.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (EnterRoom_3 == null)
            {
                EnterRoom_3 = new WorldButton_Squared(new Vector3(-16.2865f, 8.0709f, 5.9999f), new Vector3(0f, 90f, 270f), 0.6f, "<color=green>Enter Room</color>", TeleportToRoom_3);
                EnterRoom_3.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (EnterRoom_4 == null)
            {
                EnterRoom_4 = new WorldButton_Squared(new Vector3(-17.992f, 8.1337f, 3.2f), new Vector3(0f, 0f, 270f), 0.6f, "<color=green>Enter Room</color>", TeleportToRoom_4);
                EnterRoom_4.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (ToggleLock_3 == null)
            {
                ToggleLock_3 = new WorldButton_Squared(new Vector3(-16.2865f, 7.9368f, 5.9999f), new Vector3(0f, 90f, 270f), 0.6f, "<color=green>Lockpick Room</color>", ToggleDoor_3);
                ToggleLock_3.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (EnterRoom_2 == null)
            {
                EnterRoom_2 = new WorldButton_Squared(new Vector3(-10.7829f, 8.0709f, 5.9999f), new Vector3(0f, 90f, 270f), 0.6f, "<color=green>Enter Room</color>", TeleportToRoom_2);
                EnterRoom_2.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (EnterRoom_1 == null)
            {
                EnterRoom_1 = new WorldButton_Squared(new Vector3(-5.299f, 8.0709f, 5.9999f), new Vector3(0f, 90f, 270f), 0.6f, "<color=green>Enter Room</color>", TeleportToRoom_1);
                EnterRoom_1.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (ToggleLock_2 == null)
            {
                ToggleLock_2 = new WorldButton_Squared(new Vector3(-10.7829f, 7.9368f, 5.9999f), new Vector3(0f, 90f, 270f), 0.6f, "<color=green>Lockpick Room</color>", ToggleDoor_2);
                ToggleLock_2.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }
        }

        internal static void TeleportToRoom_1()
        {
            if (Room_1_Inside_Teleport != null)
            {
                GameInstances.LocalPlayer.TeleportTo(Room_1_Inside_Teleport, true);
            }
        }

        internal static void TeleportToRoom_2()
        {
            if (Room_2_Inside_Teleport != null)
            {
                GameInstances.LocalPlayer.TeleportTo(Room_2_Inside_Teleport, true);
            }
        }

        internal static void TeleportToRoom_3()
        {
            if (Room_3_Inside_Teleport != null)
            {
                GameInstances.LocalPlayer.TeleportTo(Room_3_Inside_Teleport, true);
            }
        }

        internal static void TeleportToRoom_4()
        {
            if (Room_4_Inside_Teleport != null)
            {
                GameInstances.LocalPlayer.TeleportTo(Room_4_Inside_Teleport, true);
            }
        }

        internal static void ToggleDoor_1()
        {
            Room_1_LockInteract.Invoke();
        }

        internal static void ToggleDoor_2()
        {
            Room_2_LockInteract.Invoke();
        }

        internal static void ToggleDoor_3()
        {
            Room_3_LockInteract.Invoke();
        }

        internal static void ToggleDoor_4()
        {
            Room_4_LockInteract.Invoke();
        }

        private void PatchSecureZones()
        {
            var PatchColl = 999999999f;
            foreach (var item in SecureAreas)
            {
                var obj = Finder.Find(item);
                if (obj != null)
                {
                    var coll = obj.GetComponent<BoxCollider>();
                    if (coll != null)
                    {
                        coll.size = new Vector3(PatchColl, PatchColl, PatchColl);
                    }
                }
            }
        }

        private void OnRoomLeft()
        {
            //UseUdonCustomEvent = false;
            HasSubscribed = false;
            ToggleLock_4 = null;
            ToggleLock_1 = null;
            EnterRoom_3 = null;
            EnterRoom_4 = null;
            ToggleLock_3 = null;
            EnterRoom_2 = null;
            EnterRoom_1 = null;
            ToggleLock_2 = null;
            _Room_1_Inside_Teleport = null;
            _Room_1_outside_Teleport = null;
            _Room_2_Inside_Teleport = null;
            _Room_2_outside_Teleport = null;
            _Room_3_Inside_Teleport = null;
            _Room_3_outside_Teleport = null;
            _Room_4_Inside_Teleport = null;
            _Room_4_outside_Teleport = null;
            _Room_1_LockObject = null;
            _Room_2_LockObject = null;
            _Room_3_LockObject = null;
            _Room_4_LockObject = null;
            Room_1_LockInteract = null;
            Room_2_LockInteract = null;
            Room_3_LockInteract = null;
            Room_4_LockInteract = null;
        }

        private static Transform _Room_1_Inside_Teleport;

        internal static Transform Room_1_Inside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_1_Inside_Teleport == null)
                {
                    return _Room_1_Inside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 1/DoorInside/TeleportTarget").transform;
                }
                return _Room_1_Inside_Teleport;
            }
        }

        private static Transform _Room_1_outside_Teleport;

        internal static Transform Room_1_outside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_1_outside_Teleport == null)
                {
                    return _Room_1_outside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 1/DoorInside/TeleportTarget").transform;
                }
                return _Room_1_outside_Teleport;
            }
        }

        private static Transform _Room_2_Inside_Teleport;

        internal static Transform Room_2_Inside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_2_Inside_Teleport == null)
                {
                    return _Room_2_Inside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 2/DoorInside/TeleportTarget").transform;
                }
                return _Room_2_Inside_Teleport;
            }
        }

        private static Transform _Room_2_outside_Teleport;

        internal static Transform Room_2_outside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_2_outside_Teleport == null)
                {
                    return _Room_2_outside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 2/DoorInside/TeleportTarget").transform;
                }
                return _Room_2_outside_Teleport;
            }
        }

        private static Transform _Room_3_Inside_Teleport;

        internal static Transform Room_3_Inside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_3_Inside_Teleport == null)
                {
                    return _Room_3_Inside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 3/DoorInside/TeleportTarget").transform;
                }
                return _Room_3_Inside_Teleport;
            }
        }

        private static Transform _Room_3_outside_Teleport;

        internal static Transform Room_3_outside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_3_outside_Teleport == null)
                {
                    return _Room_3_outside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 3/DoorInside/TeleportTarget").transform;
                }
                return _Room_3_outside_Teleport;
            }
        }

        private static Transform _Room_4_Inside_Teleport;

        internal static Transform Room_4_Inside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_4_Inside_Teleport == null)
                {
                    return _Room_4_Inside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 4/DoorInside/TeleportTarget").transform;
                }
                return _Room_4_Inside_Teleport;
            }
        }

        private static Transform _Room_4_outside_Teleport;

        internal static Transform Room_4_outside_Teleport
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_4_outside_Teleport == null)
                {
                    return _Room_4_outside_Teleport = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 4/DoorInside/TeleportTarget").transform;
                }
                return _Room_4_outside_Teleport;
            }
        }

        private static Transform _Room_1_LockObject;

        internal static Transform Room_1_LockObject
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_1_LockObject == null)
                {
                    return _Room_1_LockObject = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 1/DoorInside/Lock").transform;
                }
                return _Room_1_LockObject;
            }
        }

        private static Transform _Room_2_LockObject;

        internal static Transform Room_2_LockObject
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_2_LockObject == null)
                {
                    return _Room_2_LockObject = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 2/DoorInside/Lock").transform;
                }
                return _Room_2_LockObject;
            }
        }

        private static Transform _Room_3_LockObject;

        internal static Transform Room_3_LockObject
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_3_LockObject == null)
                {
                    return _Room_3_LockObject = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 3/DoorInside/Lock").transform;
                }
                return _Room_3_LockObject;
            }
        }

        private static Transform _Room_4_LockObject;

        internal static Transform Room_4_LockObject
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_4_LockObject == null)
                {
                    return _Room_4_LockObject = Finder.Find("[Scripts]/Frenzy's Script/Club Private Room Doors/Private Room Door Locks[KillFrenzyScript]/Room 4/DoorInside/Lock").transform;
                }
                return _Room_4_LockObject;
            }
        }

        private static UdonBehaviour_Cached Room_1_LockInteract { get; set; }
        private static UdonBehaviour_Cached Room_2_LockInteract { get; set; }

        private static UdonBehaviour_Cached Room_3_LockInteract { get; set; }

        private static UdonBehaviour_Cached Room_4_LockInteract { get; set; }


    }
}