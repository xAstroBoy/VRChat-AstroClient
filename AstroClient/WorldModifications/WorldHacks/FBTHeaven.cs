using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy.Extensions;
using Oculus.Platform.Models;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using AstroMonos.AstroUdons;
    using System.Collections.Generic;
    using Tools.Extensions;
    using Tools.Skybox;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class FBTHeaven : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private static readonly string[] Trash = new[]
        {
            "FBT/FBT_Heaven_Occluder",
            "FBT/Blindbox",
            "FBT/Blindbox (3)/Blindbox (7)/Blindbox_Top",
            "FBT/Blindbox (1)",
            "FBT/Blindbox/Blindbox (4)",
            "FBT/Blindbox (2)/Blindbox_Top (2)",
            "FBT/Blindbox (2)",
            "FBT/Blindbox (2)/Blindbox (6)/Blindbox_Top",
            "FBT/Blindbox (1)/Blindbox (5)",
            "FBT/Blindbox (3)/Blindbox (7)",
            "FBT/Blindbox (2)/Blindbox (6)",
            "FBT/Blindbox (3)/Blindbox_Top (3)",
            "FBT/Blindbox (3)",
            "FBT/Blindbox/Blindbox_Top",
            "FBT/Blindbox (1)/Blindbox (5)/Blindbox_Top",
            "FBT/Blindbox (1)/Blindbox_Top (1)",
            "FBT/Blindbox/Blindbox (4)/Blindbox_Top",
            "FBT/[OCCLUSION]",
            "FBT/[AREA_DEVIDERS]",
            "Occlusion Walls",
            "I Need Frames/Occlusion walls",
        };

        private static BoxCollider _Room_1_Bounds;
        internal static BoxCollider Room_1_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if(_Room_1_Bounds == null)
                {
                    _Room_1_Bounds = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 1/Room Trigger").GetComponent<BoxCollider>();
                }
                return _Room_1_Bounds;
            }
        }
        private static BoxCollider _Room_2_Bounds;
        internal static BoxCollider Room_2_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_2_Bounds == null)
                {
                    _Room_2_Bounds = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 2/Room Trigger (1)").GetComponent<BoxCollider>();
                }
                return _Room_2_Bounds;
            }
        }

        private static BoxCollider _Room_3_Bounds;
        internal static BoxCollider Room_3_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_3_Bounds == null)
                {
                    _Room_3_Bounds = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 3/Room Trigger (2)").GetComponent<BoxCollider>();
                }
                return _Room_3_Bounds;
            }
        }
        private static BoxCollider _Room_4_Bounds;
        internal static BoxCollider Room_4_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_4_Bounds == null)
                {
                    _Room_4_Bounds = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 4/Room Trigger (3)").GetComponent<BoxCollider>();
                }
                return _Room_4_Bounds;
            }
        }
        private static Vector3? _Room_1_Original_Bounds;
        internal static Vector3? Room_1_Original_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_1_Bounds == null) return null;
                if (_Room_1_Original_Bounds == null)
                {
                    _Room_1_Original_Bounds = Room_1_Bounds.size;
                }
                return _Room_1_Original_Bounds;
            }
        }
        private static Vector3? _Room_2_Original_Bounds;
        internal static Vector3? Room_2_Original_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_2_Bounds == null) return null;
                if (_Room_2_Original_Bounds == null)
                {
                    _Room_2_Original_Bounds = Room_2_Bounds.size;
                }
                return _Room_2_Original_Bounds;
            }
        }

        private static Vector3? _Room_3_Original_Bounds;
        internal static Vector3? Room_3_Original_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_3_Bounds == null) return null;
                if (_Room_3_Original_Bounds == null)
                {
                    _Room_3_Original_Bounds = Room_3_Bounds.size;
                }
                return _Room_3_Original_Bounds;
            }
        }
        private static Vector3? _Room_4_Original_Bounds;
        internal static Vector3? Room_4_Original_Bounds
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_4_Bounds == null) return null;
                if (_Room_4_Original_Bounds == null)
                {
                    _Room_4_Original_Bounds = Room_4_Bounds.size;
                }
                return _Room_4_Original_Bounds;
            }
        }


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
        private static bool _UseUdonCustomEvent = false;
        private static bool UseUdonCustomEvent 
        {
            get => _UseUdonCustomEvent;
            set
            {
                if (!isCurrentWorld) return;
                if (_UseUdonCustomEvent != value)
                {
                    if (value)
                    {
                        ClientEventActions.Udon_SendCustomEvent += UdonSendCustomEvent;
                    }
                    else
                    {
                        ClientEventActions.Udon_SendCustomEvent -= UdonSendCustomEvent;
                    }
                }
                _UseUdonCustomEvent = value;
            }
        }

        private static bool WaitForCollider1Check;
        private static bool WaitForCollider2Check;
        private static bool WaitForCollider3Check;
        private static bool WaitForCollider4Check;

        private static void UdonSendCustomEvent(UdonBehaviour instance, string udonevent)
        {
            if (udonevent.isMatch("_InBoundsCheck"))
            {

                if (WaitForCollider1Check)
                {
                    if(instance.Equals(Room_1_Bounds.gameObject.GetComponent<UdonBehaviour>()))
                    {
                        Room_1_Bounds.size = Room_1_Original_Bounds.Value;
                        WaitForCollider1Check = false;
                    }
                }
                if (WaitForCollider2Check)
                {
                    if (instance.Equals(Room_2_Bounds.gameObject.GetComponent<UdonBehaviour>()))
                    {
                        Room_2_Bounds.size = Room_2_Original_Bounds.Value;
                        WaitForCollider2Check = false;
                    }

                }
                if (WaitForCollider3Check)
                {
                    if (instance.Equals(Room_3_Bounds.gameObject.GetComponent<UdonBehaviour>()))
                    {
                        Room_3_Bounds.size = Room_3_Original_Bounds.Value;
                        WaitForCollider3Check = false;
                    }

                }
                if (WaitForCollider4Check)
                {
                    if (instance.Equals(Room_4_Bounds.gameObject.GetComponent<UdonBehaviour>()))
                    {
                        Room_4_Bounds.size = Room_4_Original_Bounds.Value;
                        WaitForCollider4Check = false;
                    }

                }
            }
            if (!WaitForCollider1Check && !WaitForCollider2Check && !WaitForCollider3Check && !WaitForCollider4Check)
            {
                UseUdonCustomEvent = false;
            }

        }

        internal static QMNestedGridMenu FBTExploitsPage;
        internal static float ButtonUpdateTime = 0f;
        private static bool isCurrentWorld;



        internal static void InitButtons(QMGridTab main)
        {
            FBTExploitsPage = new QMNestedGridMenu(main, "FBTHeaven Exploits", "FBTHeaven Exploits");

            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n1", () => { ToggleDoor(1); }, "Toggle Door 1");
            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n2", () => { ToggleDoor(2); }, "Toggle Door 2");
            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n3", () => { ToggleDoor(3); }, "Toggle Door 3");
            _ = new QMSingleButton(FBTExploitsPage, "Toggle Door\n4", () => { ToggleDoor(4); }, "Toggle Door 4");
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


                if (Room_1_main_script != null)
                {
                    Toggle_Door_1 = Room_1_main_script.FindUdonEvent("_RoomLockToggle");
                }

                if (Room_2_main_script != null)
                {
                    Toggle_Door_2 = Room_2_main_script.FindUdonEvent("_RoomLockToggle");
                }
                if (Room_3_main_script != null)
                {
                    Toggle_Door_3 = Room_3_main_script.FindUdonEvent("_RoomLockToggle");
                }
                if (Room_4_main_script != null)
                {
                    Toggle_Door_4 = Room_4_main_script.FindUdonEvent("_RoomLockToggle");
                }

                if (SkyboxEditor.SetSkyboxByFileName("Moon"))
                {
                    Log.Debug("Replaced FBT heaven Skybox as is dark and the author made it on purpose to prevent fly/noclip members.");
                }
                var doorinvisibleplane = Finder.Find("FBT/Plane");
                if (doorinvisibleplane != null)
                {
                    // make invisible this shit.
                    var renderers = doorinvisibleplane.GetComponentsInChildren<Renderer>(true);
                    for (int i = 0; i < renderers.Count; i++)
                    {
                        Renderer rend = renderers[i];
                        if (rend != null)
                        {
                            rend.enabled = false;
                            rend.DestroyMeLocal();
                        }
                    }
                }
                _ = Room_1_Original_Bounds;
                _ = Room_2_Original_Bounds;
                _ = Room_3_Original_Bounds;
                _ = Room_4_Original_Bounds;


                AddLockPickButton(Room_1_ExternalBtn, 1);
                AddLockPickButton(Room_2_ExternalBtn, 2);
                AddLockPickButton(Room_3_ExternalBtn, 3);
                AddLockPickButton(Room_4_ExternalBtn, 4);
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

        private static void AttachListener(GameObject button, System.Action OnEnable, System.Action OnDisable)
        {
            var rend = button.GetComponentInChildren<Renderer>(true);
            if (rend != null) // Attach preferrably where the renderer is to increase accuracy!
            {
                var listener = rend.gameObject.GetOrAddComponent<GameObjectListener>();
                if (listener != null)
                {
                    listener.OnEnabled += OnEnable;
                    listener.OnDisabled += OnDisable;
                    if (rend.gameObject.active)
                    {
                        OnEnable?.Invoke();
                    }
                    else
                    {
                        OnDisable?.Invoke();
                    }
                }
            }
        }

        private void OnRoomLeft()
        {
            isCurrentWorld = false;
            Toggle_Door_1 = null;
            Toggle_Door_2 = null;
            Toggle_Door_3 = null;
            Toggle_Door_4 = null;
            _Room_1_Original_Bounds = null;
            _Room_2_Original_Bounds = null;
            _Room_3_Original_Bounds = null;
            _Room_4_Original_Bounds = null;
            UseUdonCustomEvent = false;
            HasSubscribed = false;
        }

        private static void AddLockPickButton(GameObject HandleSign, int doorID)
        {
            if (HandleSign != null)
            {
                var collider = HandleSign.GetOrAddComponent<SphereCollider>();
                if (collider != null)
                {
                    collider.isTrigger = true;
                }

                var AstroTrigger = HandleSign.GetOrAddComponent<VRC_AstroInteract>();
                if (AstroTrigger != null)
                {
                    AstroTrigger.interactText = "Open Room " + doorID + " (AstroClient)";
                    AstroTrigger.OnInteract += () =>
                    {
                        ToggleDoor(doorID); 
                        MiscUtils.DelayFunction(5f, () =>
                        {
                            switch (doorID)
                            {
                                case 1:
                                    if (WaitForCollider1Check)
                                    {
                                        WaitForCollider1Check = false;
                                        if (Room_1_Original_Bounds != null)
                                            Room_1_Bounds.size = Room_1_Original_Bounds.Value;
                                    }
                                    break;

                                case 2:
                                    if (WaitForCollider2Check)
                                    {
                                        WaitForCollider2Check = false;
                                        if (Room_2_Original_Bounds != null)
                                            Room_2_Bounds.size = Room_2_Original_Bounds.Value;
                                    }

                                    break;

                                case 3:
                                    if (WaitForCollider3Check)
                                    {
                                        WaitForCollider3Check = false;
                                        if (Room_3_Original_Bounds != null)
                                            Room_3_Bounds.size = Room_3_Original_Bounds.Value;
                                    }


                                    break;

                                case 4:
                                    if (WaitForCollider4Check)
                                    {
                                        WaitForCollider4Check = false;
                                        if (Room_4_Original_Bounds != null)
                                            Room_4_Bounds.size = Room_4_Original_Bounds.Value;
                                    }
                                    break;

                                default:
                                    return;
                            }
                        });
                    };
                }
                //var parent = HandleSign.transform.parent.FindObject($"Door_Teleport_In_{doorID} (1)");
                //if (parent != null)
                //{
                //    // Get the Boxcollider and remove it.
                //    var col2 = parent.GetComponent<BoxCollider>();
                //    if(col2 != null)
                //    {
                //        col2.isTrigger = true;

                //       // col2.center = col2.center.SetX(0);
                //        //col2.center = col2.center.SetY(0);
                //        //col2.center = col2.center.SetZ(-0.04958916f);


                //        col2.size = col2.size.SetX(1.2f);
                //        col2.size = col2.size.SetY(2.5f);
                //        col2.size = col2.size.SetZ(0);


                //    }


                //}
            }
        }

        internal static void ToggleDoor(int doorID)
        {
            switch (doorID)
            {
                case 1:
                    SpecialInvoke(Toggle_Door_1, Room_1_Bounds);
                    WaitForCollider1Check = true;
                    break;

                case 2:
                    SpecialInvoke(Toggle_Door_2, Room_2_Bounds);
                    WaitForCollider2Check = true;
                    break;

                case 3:
                    SpecialInvoke(Toggle_Door_3, Room_3_Bounds);
                    WaitForCollider3Check = true;

                    break;

                case 4:
                    SpecialInvoke(Toggle_Door_4, Room_4_Bounds);
                    WaitForCollider4Check = true;
                    break;

                default:
                    return;
            }
        }


        /// <summary>
        /// FBT made a Collider trigger to check if a person is in the room, the workaround is to set this collider and then restore it.
        /// Challenge accepted Azuki :3
        /// </summary>
        private static void SpecialInvoke(UdonBehaviour_Cached udon, BoxCollider collider)
        {

            if (udon != null && collider != null)
            {
                UseUdonCustomEvent = true;
                // Azuki, you tried LMAO
                collider.size = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                // KEK
                udon.InvokeBehaviour();


            }
        }

        private static GameObject _Room_1_ExternalBtn;
        internal static GameObject Room_1_ExternalBtn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_1_ExternalBtn == null)
                {
                    return _Room_1_ExternalBtn = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 1/Door_Handle_Sign_1 (1)");
                }

                return _Room_1_ExternalBtn;
            }
        }
        private static GameObject _Room_2_ExternalBtn;
        internal static GameObject Room_2_ExternalBtn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_2_ExternalBtn == null)
                {
                    return _Room_2_ExternalBtn = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 2/Door_Handle_Sign_2 (1)");
                }

                return _Room_2_ExternalBtn;
            }
        }
        private static GameObject _Room_3_ExternalBtn;
        internal static GameObject Room_3_ExternalBtn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_3_ExternalBtn == null)
                {
                    return _Room_3_ExternalBtn = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 3/Door_Handle_Sign_3 (1)");
                }

                return _Room_3_ExternalBtn;
            }
        }
        private static GameObject _Room_4_ExternalBtn;
        internal static GameObject Room_4_ExternalBtn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Room_4_ExternalBtn == null)
                {
                    return _Room_4_ExternalBtn = Finder.Find("Scripts/WunderCrossPrivateRoom/Room 4/Door_Handle_Sign_4 (1)");
                }

                return _Room_4_ExternalBtn;
            }
        }
        private static GameObject _Scripts;

        internal static GameObject Scripts
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Scripts == null)
                {
                    return _Scripts = Finder.FindRootSceneObject("Scripts");
                }

                return _Scripts;
            }
        }

        private static GameObject _Room_Scripts;

        internal static GameObject Room_Scripts
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Scripts == null) return null;
                if (_Room_Scripts == null)
                {
                    return _Room_Scripts = Scripts.FindObject("WunderCrossPrivateRoom");
                }

                return _Room_Scripts;
            }
        }

        private static GameObject _Room_1_main_script;

        internal static GameObject Room_1_main_script
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_Scripts == null) return null;
                if (_Room_1_main_script == null)
                {
                    return _Room_1_main_script = Room_Scripts.FindObject("Room 1");
                }

                return _Room_1_main_script;
            }
        }

        private static GameObject _Room_2_main_script;

        internal static GameObject Room_2_main_script
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_Scripts == null) return null;
                if (_Room_2_main_script == null)
                {
                    return _Room_2_main_script = Room_Scripts.FindObject("Room 2");
                }

                return _Room_2_main_script;
            }
        }

        private static GameObject _Room_3_main_script;

        internal static GameObject Room_3_main_script
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_Scripts == null) return null;
                if (_Room_3_main_script == null)
                {
                    return _Room_3_main_script = Room_Scripts.FindObject("Room 3");
                }

                return _Room_3_main_script;
            }
        }

        private static GameObject _Room_4_main_script;

        internal static GameObject Room_4_main_script
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Room_Scripts == null) return null;
                if (_Room_4_main_script == null)
                {
                    return _Room_4_main_script = Room_Scripts.FindObject("Room 4");
                }

                return _Room_4_main_script;
            }
        }

        private static UdonBehaviour_Cached Toggle_Door_1 { get; set; } = null;
        private static UdonBehaviour_Cached Toggle_Door_2 { get; set; } = null;
        private static UdonBehaviour_Cached Toggle_Door_3 { get; set; } = null;
        private static UdonBehaviour_Cached Toggle_Door_4 { get; set; } = null;

        private static bool _IsRoom1Locked { get; set; } = false;

        private static bool isRoom1Locked
        {
            get
            {
                return _IsRoom1Locked;
            }
            set
            {
                _IsRoom1Locked = value;
                //if (LockButton1 != null)
                //{
                //    LockButton1.SetToggleState(value);
                //}
            }
        }

        private static bool _IsRoom2Locked { get; set; } = false;

        private static bool isRoom2Locked
        {
            get
            {
                return _IsRoom2Locked;
            }
            set
            {
                _IsRoom2Locked = value;
                // if (LockButton2 != null)
                // {
                //     LockButton2.SetToggleState(value);
                // }
            }
        }

        private static bool _IsRoom3Locked { get; set; } = false;

        private static bool isRoom3Locked
        {
            get
            {
                return _IsRoom3Locked;
            }
            set
            {
                _IsRoom3Locked = value;
                // if (LockButton3 != null)
                // {
                //     LockButton3.SetToggleState(value);
                // }
            }
        }

        private static bool _IsRoom4Locked { get; set; } = false;

        private static bool isRoom4Locked
        {
            get
            {
                return _IsRoom4Locked;
            }
            set
            {
                _IsRoom4Locked = value;
                // if (LockButton4 != null)
                // {
                //     LockButton4.SetToggleState(value);
                // }
            }
        }
    }
}