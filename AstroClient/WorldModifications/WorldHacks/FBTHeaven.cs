#pragma warning disable 649

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.AstroUdons;
    using Tools.Extensions;
    using Tools.Skybox;
    using Tools.UdonSearcher;
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
        private static List<GameObject> TrashToDelete = new List<GameObject>();
        private static bool isCurrentWorld;
        private static QMToggleButton LockButton1;
        private static GameObject LockIndicator1;
        private static QMToggleButton LockButton2;
        private static GameObject LockIndicator2;
        private static QMToggleButton LockButton3;
        private static GameObject LockIndicator3;
        private static QMToggleButton LockButton4;
        private static GameObject LockIndicator4;

        internal static void InitButtons(QMGridTab main)
        {
            FBTExploitsPage = new QMNestedGridMenu(main, "FBTHeaven Exploits", "FBTHeaven Exploits");

            _ = new QMSingleButton(FBTExploitsPage, 1, 0, "Unlock Door\n1", () => { UnlockDoor(1); }, "Unlock Door 1");
            _ = new QMSingleButton(FBTExploitsPage, 2, 0, "Unlock Door\n2", () => { UnlockDoor(2); }, "Unlock Door 2");
            _ = new QMSingleButton(FBTExploitsPage, 3, 0, "Unlock Door\n3", () => { UnlockDoor(3); }, "Unlock Door 3");
            _ = new QMSingleButton(FBTExploitsPage, 4, 0, "Unlock Door\n4", () => { UnlockDoor(4); }, "Unlock Door 4");

            _ = new QMSingleButton(FBTExploitsPage, 1, 1, "Lock Door\n1", () => { LockDoor(1); }, "Lock Door 1");
            _ = new QMSingleButton(FBTExploitsPage, 2, 1, "Lock Door\n2", () => { LockDoor(2); }, "Lock Door 2");
            _ = new QMSingleButton(FBTExploitsPage, 3, 1, "Lock Door\n3", () => { LockDoor(3); }, "Lock Door 3");
            _ = new QMSingleButton(FBTExploitsPage, 4, 1, "Lock Door\n4", () => { LockDoor(4); }, "Lock Door 4");

            LockButton1 = new QMToggleButton(FBTExploitsPage, 1, 4, "Unlock 1", () => { UnlockDoor(1); }, "Lock 1", () => { LockDoor(1); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton2 = new QMToggleButton(FBTExploitsPage, 2, 4, "Unlock 2", () => { UnlockDoor(2); }, "Lock 2", () => { LockDoor(2); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton3 = new QMToggleButton(FBTExploitsPage, 3, 4, "Unlock 3", () => { UnlockDoor(3); }, "Lock 3", () => { LockDoor(3); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton4 = new QMToggleButton(FBTExploitsPage, 4, 4, "Unlock 4", () => { UnlockDoor(4); }, "Lock 4", () => { LockDoor(4); }, "Toggle Door Lock", Color.green, Color.red);
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
                ModConsole.DebugLog($"Recognized {Name} World,  Removing Blinders and Dividers...");
                var blinders = GameObjectFinder.Find("[AREA_DEVIDERS]");
                if (blinders != null)
                {
                    blinders.DestroyMeLocal();
                }
                else
                {
                    ModConsole.Error("World Blinders and Dividers not found...");
                }
                var OcclusionWalls = GameObjectFinder.Find("Occlusion Walls");
                if (OcclusionWalls != null)
                {
                    OcclusionWalls.DestroyMeLocal();
                }
                else
                {
                    ModConsole.Error("World Occlusion Walls not found...");
                }
                var logger = GameObjectFinder.Find("Logger");
                if (logger != null)
                {
                    ModConsole.Log("Logger found, this is sus...");
                    TrashToDelete.AddGameObject(logger);
                }
                if (SkyboxEditor.SetSkyboxByFileName("dark_coalsack"))
                {
                    ModConsole.DebugLog("Replaced FBT heaven Skybox as is dark and the author made it on purpose to prevent fly/noclip members.");
                }

                var rootObject = GameObjectFinder.FindRootSceneObject("FBT");
                if (rootObject != null)
                {
                    // Fuck the useless blinders.

                    var trashblinder_8 = rootObject.transform.FindObject("Blindbox");
                    var trashblinder_9 = rootObject.transform.FindObject("Blindbox (1)");
                    var trashblinder_10 = rootObject.transform.FindObject("Blindbox (2)");
                    var trashblinder_11 = rootObject.transform.FindObject("Blindbox (3)");
                    var trashblinder_12 = rootObject.transform.FindObject("FBT_Heaven_Occluder");


                    TrashToDelete.AddGameObject(trashblinder_8.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_9.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_10.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_11.gameObject);
                    TrashToDelete.AddGameObject(trashblinder_12.gameObject);

                    if (TrashToDelete.Count() != 0)
                    {
                        for (int i = 0; i < TrashToDelete.Count; i++)
                        {
                            GameObject trash = TrashToDelete[i];
                            trash.DestroyMeLocal();
                        }
                    }

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

                    if (LockIndicator1 == null || LockIndicator2 == null || LockIndicator3 == null || LockIndicator4 == null)
                    {
                        ModConsole.Error("Could not find a lock indicator!");
                    }
                }
                else
                {
                    ModConsole.Error("Could not find rootObject!");
                }

                // USE UDON RPC OR USE THE LISTENERS For Enable or Ondisable in the outside buttons, easy!

                // I'll fix this later..
                //MelonCoroutines.Start(UpdateButtonsLoop());
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

        internal override void OnRoomLeft()
        {
            isCurrentWorld = false;
            TrashToDelete.Clear();
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

        private static IEnumerator UpdateButtonsLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld) yield break;
                RefreshButtons();
                yield return new WaitForSeconds(0.25f);
            }
        }

        private static void LockDoor(int doorID)
        {
            UdonSearch.FindUdonEvent($"Room {doorID} main script", "OnToggle").InvokeBehaviour();
            //RefreshButtons();
        }

        private static void UnlockDoor(int doorID)
        {
            UdonSearch.FindUdonEvent($"Room {doorID} main script", "OffToggle").InvokeBehaviour();
            //RefreshButtons();
        }

        private static void RefreshButtons()
        {
            if (LockIndicator1.active)
            {
                LockButton1.SetToggleState(true);
            }
            else
            {
                LockButton1.SetToggleState(false);
            }

            if (LockIndicator2.active)
            {
                LockButton2.SetToggleState(true);
            }
            else
            {
                LockButton2.SetToggleState(false);
            }

            if (LockIndicator3.active)
            {
                LockButton3.SetToggleState(true);
            }
            else
            {
                LockButton3.SetToggleState(false);
            }

            if (LockIndicator4.active)
            {
                LockButton4.SetToggleState(true);
            }
            else
            {
                LockButton4.SetToggleState(false);
            }
        }
    }
}