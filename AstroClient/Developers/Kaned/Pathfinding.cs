using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AstroClient.Target;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace AstroClient.Kaned
{
    internal class Pathfinding
    {
        private static float coarseness = 0.2f;
        private static int maxMSPerFrame = 25;

        internal static Player targetedPlayer;

        internal static List<Hunter> hunters = new List<Hunter>();

        //List<GameObject> indicators = new List<GameObject>();

        internal static QMNestedGridMenu PathMenu;
        internal static QMSingleButton[] buttons;
        internal static QMSingleButton targetInfo;
        internal static QMSingleButton hunterInfo;
        internal static bool followingState = false;

        //Get the difference between the current cost and its parent's cost to get the fraction by which to lerp each frame

        internal static void InitMenu(QMNestedGridMenu KWIPMenu)
        {
            PathMenu = new QMNestedGridMenu(KWIPMenu, "Pathing", "");
            _ = new QMSingleButton(PathMenu, 1, 0, "Select Objects", () =>
            {
                hunters.Clear();
                for (int i = 2; i < WorldUtils.Pickups.Count; i++)
                {
                    var pu = WorldUtils.Pickups[i];
                    if (pu.enabled == false) continue;
                    if (pu.gameObject.active == false) continue;
                    hunters.Add(new Hunter() { pickup = pu });
                }
                //hunters.Add(new Hunter() { pickup = WorldUtils.Pickups[2] });
                Log.Write("Pickups located");
                for (int i = 0; i < hunters.Count; i++)
                {
                    Log.Write($"{i,-2}, {hunters[i].pickup.name}");
                }
                RefreshInfo();
            }, "");
            _ = new QMSingleButton(PathMenu, 1, 0.5f, "Target Player", () =>
            {
                if (TargetSelector.CurrentTarget != null)
                {
                    targetedPlayer = TargetSelector.CurrentTarget;
                    RefreshInfo();
                    //var p = TargetSelector.CurrentTarget.Get_Player_Bone_Position(HumanBodyBones.Chest);
                }
            }, "");

            _ = new QMSingleButton(PathMenu, 2, 0, "Gen Path", () =>
            {
                if (targetedPlayer != null && hunters.Count > 0)
                {
                    //for (int i = 0; i < hunters.Count; i++)
                    //{
                    //    new Pathfinder().GetPath(hunters[i].pickup.transform.position, (Vector3)targetedPlayer.Get_Player_Bone_Position(HumanBodyBones.Chest), (x, a) =>
                    //    {
                    //        //indicators
                    //        //foreach (var p in x.points)
                    //        //{
                    //        //    var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //        //    obj.transform.position = p;
                    //        //    obj.transform.localScale = Vector3.one * coarseness;
                    //        //    UnityEngine.Object.Destroy(obj.GetComponent<Collider>());
                    //        //    obj.RigidBody_Set_Gravity(false);
                    //        //    indicators.Add(obj);
                    //        //}
                    //        int index = (int)a[0];
                    //        Log.Write(index.ToString());
                    //        hunters[index].path = x.points;
                    //        if (followingState)
                    //        {
                    //            hunters[index].startFollow();
                    //        }
                    //    }, new object[] { i }, coarseness, maxMSPerFrame);
                    //}
                    new Pathfinder().MultiGetPath(hunters.Select(x => x.pickup.transform.position).ToArray(), hunters.Select(x => (Vector3)targetedPlayer.Get_Player_Bone_Transform(HumanBodyBones.Chest).position).ToArray(), (x, a) =>
                    {
                        //indicators
                        //foreach (var p in x.points)
                        //{
                        //    var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        //    obj.transform.position = p;
                        //    obj.transform.localScale = Vector3.one * coarseness;
                        //    UnityEngine.Object.Destroy(obj.GetComponent<Collider>());
                        //    obj.RigidBody_Set_Gravity(false);
                        //    indicators.Add(obj);
                        //}
                        int index = (int)a[0];
                        Log.Write(index.ToString());
                        hunters[index].path = x.points;
                        if (followingState)
                        {
                            hunters[index].startFollow();
                        }
                    }, Enumerable.Range(0, hunters.Count).Select(x => new object[] { x }).ToArray(), coarseness, maxMSPerFrame);
                }
            }, "Try to create a path");

            //_ = new QMSingleButton(WIPMenu, 1, 1, "Clear", () =>
            //{
            //    indicators.ForEach(x => x.DestroyMeLocal());
            //    indicators.Clear();
            //}, "Clears Indicators", btnHalf: true);
            _ = new QMSingleButton(PathMenu, 2, 1, "StopPathing", () =>
            {

            }, "NOT IMPLEMENTED Stops trying to find paths that have yet to be generated");
            _ = new QMToggleButton(PathMenu, 3, 0, "FollowPath", () =>
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
            _ = new QMToggleButton(PathMenu, 3, 1, "ActiveTracking", () =>
            {

            }, "ActiveTracking", () =>
            {

            }, "NOT IMPLEMENTED Automatically update the paths of hunters");
            _ = new QMSingleButton(PathMenu, 1, 1.5f, "Test", () =>
            {
                //for (int i = 0; i < 32; i++)
                //{
                //    Log.Write($"Number: {i}, Name: {LayerMask.LayerToName(i)}");
                //}
                //Log.Write("------------------------------------------------------------");
                //var players = Utils.PlayerManager.AllPlayers();
                //foreach (var p in players)
                //{
                //    Log.Write($"PName: {p.GetDisplayName()}, Layer: {p.gameObject.layer}");
                //}
                var pickups = WorldUtils.Pickups;
                int num = 0;
                foreach (var o in pickups)
                {
                    Log.Write($"{num,3} - {o.name}");
                    num++;
                }
            }, "");
            targetInfo = new QMSingleButton(PathMenu, 4, 0, "None", () => { RefreshInfo(); }, "");
            hunterInfo = new QMSingleButton(PathMenu, 4, 1, "None", () => { RefreshInfo(); }, "");
            buttons = new QMSingleButton[]
            {
                new QMSingleButton(PathMenu, 0, -1, "0.1", () =>
                {
                    coarseness = 0.1f;
                    activateNum(0);
                }, "", btnHalf: true),
                new QMSingleButton(PathMenu, 0, -0.5f, "0.15", () =>
                {
                    coarseness = 0.15f;
                    activateNum(1);
                }, "", btnHalf: true),
                new QMSingleButton(PathMenu, 0, 0, "0.2", () =>
                {
                    coarseness = 0.2f;
                    activateNum(2);
                }, "", btnHalf: true),
                new QMSingleButton(PathMenu, 0, 0.5f, "0.25", () =>
                {
                    coarseness = 0.25f;
                    activateNum(3);
                }, "", btnHalf: true),
                new QMSingleButton(PathMenu, 0, 1, "0.5", () =>
                {
                    coarseness = 0.5f;
                    activateNum(4);
                }, "", btnHalf: true),
                new QMSingleButton(PathMenu, 0, 1.5f, "1", () =>
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
                    b.SetTextColor(UnityEngine.Color.red);
                }
                buttons[pos].SetTextColor(UnityEngine.Color.green);
            }
        }

        private static void RefreshInfo()
        {
            targetInfo.SetButtonText($"Player: {(targetedPlayer == null ? "No Target" : targetedPlayer.GetDisplayName())}");
            hunterInfo.SetButtonText($"Active Hunters: {hunters.Count}");
        }

        internal class Hunter
        {
            internal VRC_Pickup pickup;
            internal object coroutine = null;
            internal bool following = false;
            internal Vector3[] path;
            internal void startFollow()
            {
                following = true;
                t = 1;
                pind = 0;
                coroutine = MelonLoader.MelonCoroutines.Start(follow());
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
                    if (path == null)
                    {
                        //Log.Write("PATH IS FUCKED");
                        yield break;
                    }
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
                    t += (Time.deltaTime / pdist);
                    yield return null;
                }
            }
        }
    }
}
