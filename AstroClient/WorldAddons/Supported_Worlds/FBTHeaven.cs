namespace AstroClient
{
    using AstroClient.Components;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class FBTHeaven : GameEvents
    {
        public static QMNestedButton FBTExploitsPage;
        public static float ButtonUpdateTime = 0f;
        private static List<GameObject> TrashToDelete = new List<GameObject>();
        //private static QMToggleButton LockButton1;
        //private static GameObject LockIndicator1;
        //private static QMToggleButton LockButton2;
        //private static GameObject LockIndicator2;
        //private static QMToggleButton LockButton3;
        //private static GameObject LockIndicator3;
        //private static QMToggleButton LockButton4;
        //private static GameObject LockIndicator4;

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            TrashToDelete.Clear();
        }

        public static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            FBTExploitsPage = new QMNestedButton(main, x, y, "FBTHeaven Exploits", "FBTHeaven Exploits", null, null, null, null, btnHalf);

            _ = new QMSingleButton(FBTExploitsPage, 1, 0, $"Unlock Door\n1", () => { UnlockDoor(1); }, $"Unlock Door 1");
            _ = new QMSingleButton(FBTExploitsPage, 2, 0, $"Unlock Door\n2", () => { UnlockDoor(2); }, $"Unlock Door 2");
            _ = new QMSingleButton(FBTExploitsPage, 3, 0, $"Unlock Door\n3", () => { UnlockDoor(3); }, $"Unlock Door 3");
            _ = new QMSingleButton(FBTExploitsPage, 4, 0, $"Unlock Door\n4", () => { UnlockDoor(4); }, $"Unlock Door 4");

            _ = new QMSingleButton(FBTExploitsPage, 1, 1, $"Lock Door\n1", () => { LockDoor(1); }, $"Lock Door 1");
            _ = new QMSingleButton(FBTExploitsPage, 2, 1, $"Lock Door\n2", () => { LockDoor(2); }, $"Lock Door 2");
            _ = new QMSingleButton(FBTExploitsPage, 3, 1, $"Lock Door\n3", () => { LockDoor(3); }, $"Lock Door 3");
            _ = new QMSingleButton(FBTExploitsPage, 4, 1, $"Lock Door\n4", () => { LockDoor(4); }, $"Lock Door 4");

            //LockButton1 = new QMToggleButton(FBTExploitsPage, 1, 0, "Unlock 1", () => { UnlockDoor(1); }, "Lock 1", () => { LockDoor(1); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            //LockButton2 = new QMToggleButton(FBTExploitsPage, 2, 0, "Unlock 2", () => { UnlockDoor(2); }, "Lock 2", () => { LockDoor(2); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            //LockButton3 = new QMToggleButton(FBTExploitsPage, 3, 0, "Unlock 3", () => { UnlockDoor(3); }, "Lock 3", () => { LockDoor(3); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            //LockButton4 = new QMToggleButton(FBTExploitsPage, 4, 0, "Unlock 4", () => { UnlockDoor(4); }, "Lock 4", () => { LockDoor(4); }, "Toggle Door Lock", null, Color.green, Color.red, false);
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.FBTHeaven)
            {
                //
                ModConsole.DebugLog($"Recognized {Name} World,  Removing Blinders and Dividers...");
                var blinders = GameObjectFinder.Find("[AREA_DEVIDERS]");
                if (blinders != null)
                {
                    blinders.DestroyMeLocal();
                }
                else
                {
                    ModConsole.Error("World Blinders and Divivers not found...");
                }

                var rootObject = GameObjectFinder.FindRootSceneObject("Drag me");
                if (rootObject != null)
                {
                    // Fuck the useless blinders.
                    var trashblinder_0 = rootObject.transform.FindObject("Main_area-Private_rooms");
                    var trashblinder_1 = rootObject.transform.FindObject("Main_area-Private_rooms_1");
                    var trashblinder_2 = rootObject.transform.FindObject("Main_area-Private_rooms (1)");
                    var trashblinder_3 = rootObject.transform.FindObject("Main_area-Private_rooms_1 (1)");
                    var trashblinder_4 = rootObject.transform.FindObject("Main_area-Private_rooms (2)");
                    var trashblinder_5 = rootObject.transform.FindObject("Main_area-Private_rooms_1 (2)");
                    var trashblinder_6 = rootObject.transform.FindObject("Main_area-Private_rooms (3)");
                    var trashblinder_7 = rootObject.transform.FindObject("Main_area-Private_rooms_1 (3)");

                    var trashblinder_8 = rootObject.transform.FindObject("Blindbox");
                    var trashblinder_9 = rootObject.transform.FindObject("Blindbox (1)");
                    var trashblinder_10 = rootObject.transform.FindObject("Blindbox (2)");
                    var trashblinder_11 = rootObject.transform.FindObject("Blindbox (3)");
                    var trashblinder_12 = rootObject.transform.FindObject("FBT_Heaven_Occluder");

                    var logger = GameObjectFinder.Find("Logger");
                    if (logger != null)
                    {
                        ModConsole.Log("Logger found, this is sus...");
                        TrashToDelete.AddGameObject(logger);
                    }

                    TrashToDelete.AddGameObject(trashblinder_0.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_1.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_2.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_3.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_4.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_5.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_6.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_7.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_8.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_9.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_10.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_11.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_12.gameObject);

                    if (TrashToDelete.Count() != 0)
                    {
                        foreach (var trash in TrashToDelete)
                        {
                            trash.DestroyMeLocal();
                        }
                    }
                    var doorinvisibleplane = rootObject.transform.FindObject("Plane");
                    if (doorinvisibleplane != null)
                    {
                        // make invisible this shit.
                        var renderers = doorinvisibleplane.GetComponentsInChildren<Renderer>(true);
                        foreach (var rend in renderers)
                        {
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

                    //if (LockIndicator1 == null || LockIndicator2 == null || LockIndicator3 == null || LockIndicator4 == null)
                    //{
                    //    ModConsole.Error("Could not find a lock indicator!");
                    //}
                }
                else
                {
                    ModConsole.Error("Could not find rootObject!");
                }

                // USE UDON RPC OR USE THE LISTENERS For Enable or Ondisable in the outside buttons, easy!

                // I'll fix this later..
                //MelonCoroutines.Start(UpdateButtonsLoop());
            }
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

                var AstroTrigger = HandleSign.GetOrAddComponent<VRC_AstroUdonTrigger>();
                if (AstroTrigger != null)
                {
                    AstroTrigger.interactText = "Lockpick Door " + doorID + " (AstroClient)";
                    AstroTrigger.OnInteract += () => { UnlockDoor(doorID); };
                }
            }
        }

        private static IEnumerator UpdateButtonsLoop()
        {
            for (; ; )
            {
                ButtonUpdateTime += 1 * Time.deltaTime;

                if (ButtonUpdateTime < 100f)
                {
                    yield return null;
                }
                else
                {
                    if (!WorldUtils.IsInWorld) yield break;
                    ButtonUpdateTime = 0f;
                }

                RefreshButtons();
            }
        }

        private static void LockDoor(int doorID)
        {
            UdonSearch.FindUdonEvent($"Room {doorID} main script", $"OnToggle").ExecuteUdonEvent();
            //RefreshButtons();
        }

        private static void UnlockDoor(int doorID)
        {
            UdonSearch.FindUdonEvent($"Room {doorID} main script", $"OffToggle").ExecuteUdonEvent();
            //RefreshButtons();
        }

        private static void RefreshButtons()
        {
            //if (LockIndicator1.active)
            //{
            //    LockButton1.SetToggleState(true);
            //}
            //else
            //{
            //    LockButton1.SetToggleState(false);
            //}

            //if (LockIndicator2.active)
            //{
            //    LockButton2.SetToggleState(true);
            //}
            //else
            //{
            //    LockButton2.SetToggleState(false);
            //}

            //if (LockIndicator3.active)
            //{
            //    LockButton3.SetToggleState(true);
            //}
            //else
            //{
            //    LockButton3.SetToggleState(false);
            //}

            //if (LockIndicator4.active)
            //{
            //    LockButton4.SetToggleState(true);
            //}
            //else
            //{
            //    LockButton4.SetToggleState(false);
            //}
        }
    }
}