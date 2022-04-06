using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.CustomClasses;
namespace AstroClient.WorldModifications.WorldHacks
{
    using AstroMonos.AstroUdons;
    using System.Collections.Generic;
    using System.Linq;
    using Tools.Extensions;
    using Tools.Skybox;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class FBTHeaven : AstroEvents
    {
        internal static QMNestedGridMenu FBTExploitsPage;
        internal static float ButtonUpdateTime = 0f;
        private static bool isCurrentWorld;
       // private static QMToggleButton LockButton1;
       // private static QMToggleButton LockButton2;
       // private static QMToggleButton LockButton3;
       // private static QMToggleButton LockButton4;

        internal static void InitButtons(QMGridTab main)
        {
            FBTExploitsPage = new QMNestedGridMenu(main, "FBTHeaven Exploits", "FBTHeaven Exploits");

            _ = new QMSingleButton(FBTExploitsPage, "Unlock Door\n1", () => { UnlockDoor(1); }, "Unlock Door 1");
            _ = new QMSingleButton(FBTExploitsPage, "Unlock Door\n2", () => { UnlockDoor(2); }, "Unlock Door 2");
            _ = new QMSingleButton(FBTExploitsPage, "Unlock Door\n3", () => { UnlockDoor(3); }, "Unlock Door 3");
            _ = new QMSingleButton(FBTExploitsPage, "Unlock Door\n4", () => { UnlockDoor(4); }, "Unlock Door 4");

            _ = new QMSingleButton(FBTExploitsPage, "Lock Door\n1", () => { LockDoor(1); }, "Lock Door 1");
            _ = new QMSingleButton(FBTExploitsPage, "Lock Door\n2", () => { LockDoor(2); }, "Lock Door 2");
            _ = new QMSingleButton(FBTExploitsPage, "Lock Door\n3", () => { LockDoor(3); }, "Lock Door 3");
            _ = new QMSingleButton(FBTExploitsPage, "Lock Door\n4", () => { LockDoor(4); }, "Lock Door 4");

           //LockButton1 = new QMToggleButton(FBTExploitsPage,  "Lock 1", () => { LockDoor(1); }, "Unlock 1", () => { UnlockDoor(1); }, "Toggle Door Lock", Color.green, Color.red);
           //LockButton2 = new QMToggleButton(FBTExploitsPage,  "Lock 2", () => { LockDoor(2); }, "Unlock 2", () => { UnlockDoor(2); }, "Toggle Door Lock", Color.green, Color.red);
           //LockButton3 = new QMToggleButton(FBTExploitsPage,  "Lock 3", () => { LockDoor(3); }, "Unlock 3", () => { UnlockDoor(3); }, "Toggle Door Lock", Color.green, Color.red);
           //LockButton4 = new QMToggleButton(FBTExploitsPage,  "Lock 4", () => { LockDoor(4); }, "Unlock 4", () => { UnlockDoor(4); }, "Toggle Door Lock", Color.green, Color.red);
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.FBTHeaven)
            {
                if (FBTExploitsPage != null)
                {
                    FBTExploitsPage.SetInteractable(true);
                    FBTExploitsPage.SetTextColor(Color.green);
                }

                isCurrentWorld = true;
                Log.Debug($"Recognized {Name} World,  Removing Blinders and Dividers...");
                var blinders = GameObjectFinder.Find("[AREA_DEVIDERS]");
                if (blinders != null)
                {
                    blinders.DestroyMeLocal();
                }
                else
                {
                    Log.Error("World Blinders and Dividers not found...");
                }
                var OcclusionWalls = GameObjectFinder.Find("Occlusion Walls");
                if (OcclusionWalls != null)
                {
                    OcclusionWalls.DestroyMeLocal();
                }
                else
                {
                    Log.Error("World Occlusion Walls not found...");
                }
                var logger = GameObjectFinder.FindRootSceneObject("Logger");
                if (logger != null)
                {
                    Log.Write("Logger found, this is sus...");
                    logger.DestroyMeLocal();
                }

                if (Room_1_main_script != null)
                {
                    Lock_Door_1 = Room_1_main_script.FindUdonEvent("OnToggle");
                    if (Lock_Door_1 != null)
                    {
                        Unlock_Door_1 = Lock_Door_1.UdonBehaviour.FindUdonEvent("OffToggle");
                    }
                }

                if (Room_2_main_script != null)
                {
                    Lock_Door_2 = Room_2_main_script.FindUdonEvent("OnToggle");
                    if (Lock_Door_2 != null)
                    {
                        Unlock_Door_2 = Lock_Door_2.UdonBehaviour.FindUdonEvent("OffToggle");
                    }
                }
                if (Room_3_main_script != null)
                {
                    Lock_Door_3 = Room_3_main_script.FindUdonEvent("OnToggle");
                    if (Lock_Door_3 != null)
                    {
                        Unlock_Door_3 = Lock_Door_3.UdonBehaviour.FindUdonEvent("OffToggle");
                    }
                }
                if (Room_4_main_script != null)
                {
                    Lock_Door_4 = Room_4_main_script.FindUdonEvent("OnToggle");
                    if (Lock_Door_4 != null)
                    {
                        Unlock_Door_4 = Lock_Door_4.UdonBehaviour.FindUdonEvent("OffToggle");
                    }
                }
                if (SkyboxEditor.SetSkyboxByFileName("Skybox_Hong Kong Skybox"))
                {
                    Log.Debug("Replaced FBT heaven Skybox as is dark and the author made it on purpose to prevent fly/noclip members.");
                }

                var rootObject = GameObjectFinder.FindRootSceneObject("FBT");
                if (rootObject != null)
                {
                    // Fuck the useless blinders.

                    rootObject.transform.FindObject("Blindbox").DestroyMeLocal();
                    rootObject.transform.FindObject("Blindbox (1)").DestroyMeLocal();
                    rootObject.transform.FindObject("Blindbox (2)").DestroyMeLocal();
                    rootObject.transform.FindObject("Blindbox (3)").DestroyMeLocal();
                    rootObject.transform.FindObject("FBT_Heaven_Occluder").DestroyMeLocal();
                    rootObject.transform.FindObject("[OCCLUSION]").DestroyMeLocal();



                    var doorinvisibleplane = rootObject.transform.FindObject("Plane");
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

                    var outsidebutton1 = rootObject.transform.FindObject("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_1/Door_Handle_Sign_1").gameObject;
                    var outsidebutton2 = rootObject.transform.FindObject("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_2/Door_Handle_Sign_2").gameObject;
                    var outsidebutton3 = rootObject.transform.FindObject("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_3/Door_Handle_Sign_3").gameObject;
                    var outsidebutton4 = rootObject.transform.FindObject("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_4/Door_Handle_Sign_4").gameObject;

                    AddLockPickButton(outsidebutton1, 1);
                    AddLockPickButton(outsidebutton2, 2);
                    AddLockPickButton(outsidebutton3, 3);
                    AddLockPickButton(outsidebutton4, 4);

                    //AttachListener(outsidebutton1, () => { isRoom1Locked = true; }, () => { isRoom1Locked = false; });
                    //AttachListener(outsidebutton2, () => { isRoom2Locked = true; }, () => { isRoom2Locked = false; });
                    //AttachListener(outsidebutton3, () => { isRoom3Locked = true; }, () => { isRoom3Locked = false; });
                    //AttachListener(outsidebutton4, () => { isRoom4Locked = true; }, () => { isRoom4Locked = false; });
                }
                else
                {
                    ModConsole.Error("Could not find rootObject!");
                }
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

        internal override void OnRoomLeft()
        {
            isCurrentWorld = false;
            Unlock_Door_1 = null;
            Unlock_Door_2 = null;
            Unlock_Door_3 = null;
            Unlock_Door_4 = null;

            Lock_Door_1 = null;
            Lock_Door_2 = null;
            Lock_Door_3 = null;
            Lock_Door_4 = null;
        }

        private static void AddLockPickButton(GameObject HandleSign, int doorID)
        {
            if (HandleSign != null)
            {
                var collider = HandleSign.GetOrAddComponent<MeshCollider>();
                if (collider != null)
                {
                    collider.smoothSphereCollisions = true;
                }

                var AstroTrigger = HandleSign.GetOrAddComponent<VRC_AstroInteract>();
                if (AstroTrigger != null)
                {
                    AstroTrigger.interactText = "Lockpick Door " + doorID + " (AstroClient)";
                    AstroTrigger.OnInteract += () => { UnlockDoor(doorID); };
                }
            }
        }

        internal static void LockDoor(int doorID)
        {
            switch (doorID)
            {
                case 1:
                    Lock_Door_1.InvokeBehaviour();
                    break;

                case 2:
                    Lock_Door_2.InvokeBehaviour();
                    break;

                case 3:
                    Lock_Door_3.InvokeBehaviour();
                    break;

                case 4:
                    Lock_Door_4.InvokeBehaviour();
                    break;

                default:
                    return;
            }
        }

        internal static void UnlockDoor(int doorID)
        {
            switch (doorID)
            {
                case 1:
                    Unlock_Door_1.InvokeBehaviour();
                    break;

                case 2:
                    Unlock_Door_2.InvokeBehaviour();
                    break;

                case 3:
                    Unlock_Door_3.InvokeBehaviour();
                    break;

                case 4:
                    Unlock_Door_4.InvokeBehaviour();
                    break;

                default:
                    return;
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
                    return _Scripts = GameObjectFinder.FindRootSceneObject("Scripts");
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
                    return _Room_Scripts = Scripts.FindObject("Room Scripts");
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
                    return _Room_1_main_script = Room_Scripts.FindObject("Room 1 main script");
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
                    return _Room_2_main_script = Room_Scripts.FindObject("Room 2 main script");
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
                    return _Room_3_main_script = Room_Scripts.FindObject("Room 3 main script");
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
                    return _Room_4_main_script = Room_Scripts.FindObject("Room 4 main script");
                }

                return _Room_4_main_script;
            }
        }

        private static UdonBehaviour_Cached Unlock_Door_1 { get; set; } = null;
        private static UdonBehaviour_Cached Unlock_Door_2 { get; set; } = null;
        private static UdonBehaviour_Cached Unlock_Door_3 { get; set; } = null;
        private static UdonBehaviour_Cached Unlock_Door_4 { get; set; } = null;

        private static UdonBehaviour_Cached Lock_Door_1 { get; set; } = null;
        private static UdonBehaviour_Cached Lock_Door_2 { get; set; } = null;
        private static UdonBehaviour_Cached Lock_Door_3 { get; set; } = null;
        private static UdonBehaviour_Cached Lock_Door_4 { get; set; } = null;

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