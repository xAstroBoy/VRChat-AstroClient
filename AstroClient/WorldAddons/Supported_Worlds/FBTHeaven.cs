namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using MelonLoader;
    using RubyButtonAPI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FBTHeaven : GameEvents
    {
        public static QMNestedButton FBTExploitsPage;
        public static float ButtonUpdateTime = 0f;

        private static QMToggleButton LockButton1;
        private static GameObject LockIndicator1;
        private static QMToggleButton LockButton2;
        private static GameObject LockIndicator2;
        private static QMToggleButton LockButton3;
        private static GameObject LockIndicator3;
        private static QMToggleButton LockButton4;
        private static GameObject LockIndicator4;

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

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.FBTHeaven)
            {
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

                //var rootObject = GameObjectFinder.FindRootSceneObject("Drag me");
                //if (rootObject != null)
                //{
                //    LockIndicator1 = rootObject.transform.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_1/Door_Handle_Sign_1").gameObject;
                //    LockIndicator2 = rootObject.transform.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_2/Door_Handle_Sign_2").gameObject;
                //    LockIndicator3 = rootObject.transform.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_3/Door_Handle_Sign_3").gameObject;
                //    LockIndicator4 = rootObject.transform.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_4/Door_Handle_Sign_4").gameObject;

                //    if (LockIndicator1 == null || LockIndicator2 == null || LockIndicator3 == null || LockIndicator4 == null)
                //    {
                //        ModConsole.Error("Could not find a lock indicator!");
                //    }
                //}
                //else
                //{
                //    ModConsole.Error("Could not find rootObject!");
                //}

                // I'll fix this later..
                //MelonCoroutines.Start(UpdateButtonsLoop());
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
                    if (!WorldUtils.IsInWorld()) yield break;
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