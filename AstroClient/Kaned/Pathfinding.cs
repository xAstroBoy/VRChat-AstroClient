namespace AstroClient.Kaned
{
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.SDKBase;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using VRC;
    using System.Diagnostics;
    using System;

    internal class Pathfinding : GameEvents
    {
        private float coarseness = 0.2f;
        private int maxInterPerFrame = 10;

        internal Player targetedPlayer;

        internal List<Hunter> hunters = new List<Hunter>();

        List<GameObject> indicators = new List<GameObject>();

        internal QMNestedButton WIPMenu { get; private set; }
        internal QMSingleButton[] buttons;
        internal QMSingleButton targetInfo;
        internal QMSingleButton hunterInfo;
        internal bool followingState = false;

        //Get the difference between the current cost and its parent's cost to get the fraction by which to lerp each frame

        internal override void VRChat_OnUiManagerInit()
        {
            WIPMenu = new QMNestedButton("ShortcutMenu", 5, 4.5f, "KWIP", "WIP Features", btnTextColor: Color.red, btnHalf: true);

            _ = new QMSingleButton(WIPMenu, 1, 0, "Select Objects", () =>
            {
                hunters.Clear();
                for (int i = 2; i < WorldUtils.Pickups.Count; i++)
                {
                    hunters.Add(new Hunter() { pickup = WorldUtils.Pickups[i] });
                }
                //hunters.Add(new Hunter() { pickup = WorldUtils.Pickups[2] });
                hunters.ForEach(x => { ModConsole.Log(x.pickup.name); });
                RefreshInfo();
            }, "", btnHalf: true);
            _ = new QMSingleButton(WIPMenu, 1, 0.5f, "Target Player", () =>
            {
                if (TargetSelector.CurrentTarget != null)
                {
                    targetedPlayer = TargetSelector.CurrentTarget;
                    RefreshInfo();
                    //var p = TargetSelector.CurrentTarget.Get_Player_Bone_Position(HumanBodyBones.Chest);
                }
            }, "", btnHalf: true);

            _ = new QMSingleButton(WIPMenu, 2, 0, "Gen Path", () =>
            {
                if (targetedPlayer != null && hunters.Count > 0)
                {
                    for (int i = 0; i < hunters.Count; i++)
                    {
                        new Pathfinder().GetPath(hunters[i].pickup.transform.position, (Vector3)targetedPlayer.Get_Player_Bone_Position(HumanBodyBones.Chest), coarseness, maxInterPerFrame, (x) =>
                        {
                            foreach (var p in x.points)
                            {
                                var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                obj.transform.position = p;
                                obj.transform.localScale = Vector3.one * coarseness;
                                UnityEngine.Object.Destroy(obj.GetComponent<Collider>());
                                obj.RigidBody_Set_Gravity(false);
                                indicators.Add(obj);
                            }
                            hunters[i].path = x.points;
                            if (followingState)
                            {
                                hunters[i].startFollow();
                            }
                        });
                    }
                }
            }, "Try to create a path");

            _ = new QMSingleButton(WIPMenu, 1, 1, "Clear", () =>
            {
                indicators.ForEach(x => x.DestroyMeLocal());
                indicators.Clear();
            }, "Clears Indicators", btnHalf: true);
            _ = new QMSingleButton(WIPMenu, 2, 1, "StopPathing", () =>
            {

            }, "NOT IMPLEMENTED Stops trying to find paths that have yet to be generated", btnHalf: true);
            _ = new QMToggleButton(WIPMenu, 3, 0, "FollowPath", () =>
            {
                followingState = true;
                foreach (var h in hunters)
                {
                    h.startFollow();
                }
            }, "FollowPath", () =>
            {
                followingState = false;
                foreach (var h in hunters)
                {
                    h.stopFollow();
                }
            }, "Makes objects follow their generated paths");
            _ = new QMToggleButton(WIPMenu, 3, 1, "ActiveTracking", () =>
            {

            }, "ActiveTracking", () =>
            {

            }, "NOT IMPLEMENTED Automatically update the paths of hunters");
            _ = new QMSingleButton(WIPMenu, 1, 1.5f, "Test", () =>
            {
                //for (int i = 0; i < 32; i++)
                //{
                //    ModConsole.Log($"Number: {i}, Name: {LayerMask.LayerToName(i)}");
                //}
                //ModConsole.Log("------------------------------------------------------------");
                //var players = Utils.PlayerManager.AllPlayers();
                //foreach (var p in players)
                //{
                //    ModConsole.Log($"PName: {p.GetDisplayName()}, Layer: {p.gameObject.layer}");
                //}
                var pickups = WorldUtils.Pickups;
                int num = 0;
                foreach (var o in pickups)
                {
                    ModConsole.Log($"{num,3} - {o.name}");
                    num++;
                }
            }, "");
            targetInfo = new QMSingleButton(WIPMenu, 4, 0, "None", () => { RefreshInfo(); }, "");
            hunterInfo = new QMSingleButton(WIPMenu, 4, 1, "None", () => { RefreshInfo(); }, "");
            buttons = new QMSingleButton[]
            {
                new QMSingleButton(WIPMenu, 0, -1, "0.1", () =>
                {
                    coarseness = 0.1f;
                    activateNum(0);
                }, "", btnHalf: true),
                new QMSingleButton(WIPMenu, 0, -0.5f, "0.15", () =>
                {
                    coarseness = 0.15f;
                    activateNum(1);
                }, "", btnHalf: true),
                new QMSingleButton(WIPMenu, 0, 0, "0.2", () =>
                {
                    coarseness = 0.2f;
                    activateNum(2);
                }, "", btnHalf: true),
                new QMSingleButton(WIPMenu, 0, 0.5f, "0.25", () =>
                {
                    coarseness = 0.25f;
                    activateNum(3);
                }, "", btnHalf: true),
                new QMSingleButton(WIPMenu, 0, 1, "0.5", () =>
                {
                    coarseness = 0.5f;
                    activateNum(4);
                }, "", btnHalf: true),
                new QMSingleButton(WIPMenu, 0, 1.5f, "1", () =>
                {
                    coarseness = 1;
                    activateNum(5);
                }, "", btnHalf: true),
            };

            activateNum(2);
            RefreshInfo();

            void activateNum(int pos)
            {
                foreach (var b in buttons)
                {
                    b.SetTextColor(Color.red);
                }
                buttons[pos].SetTextColor(Color.green);
            }
        }

        private void RefreshInfo()
        {
            targetInfo.SetButtonText($"Player: {(targetedPlayer == null ? "No Target" : targetedPlayer.GetDisplayName())}");
            hunterInfo.SetButtonText($"Active Hunters: {hunters.Count}");
        }

        internal class Hunter
        {
            internal VRC_Pickup pickup;
            internal Coroutine coroutine = null;
            internal bool following = false;
            internal Vector3[] path;
            internal void startFollow()
            {
                following = true;
                t = 1;
                pind = 0;
                coroutine = (Coroutine)MelonLoader.MelonCoroutines.Start(follow());
            }
            internal void stopFollow()
            {
                following = false;
            }
            private Vector3 start;
            private Vector3 end;
            private float t = 1;
            private int pind = 0;
            private float pdist = 1;
            IEnumerator follow()
            {
                while (following)
                {
                    if (t >= 1)
                    {
                        if (pind == path.Length) yield break;
                        t = 0;
                        end = path[pind];
                        start = pickup.transform.position;
                        pind++;
                        pdist = Vector3.Distance(start, end);
                    }
                    pickup.transform.position = Vector3.Lerp(start, end, t);
                    t += (Time.deltaTime / pdist) * 2;
                    yield return null;
                }
            }
        }
    }
}
