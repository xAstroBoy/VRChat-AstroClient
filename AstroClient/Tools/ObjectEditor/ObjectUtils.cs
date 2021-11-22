namespace AstroClient.Tools.ObjectEditor
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using AstroMonos.Components.Tools;
    using ClientUI.Menu.ItemTweakerV2.Selector;
    using ColliderViewer;
    using Extensions;
    using Il2CppSystem.Text;
    using Online;
    using Photon.Pun;
    using UnhollowerBaseLib;
    using UnityEngine;
    using VRC;
    using VRC.SDK3.Components;
    using VRC.SDKBase;
    using VRCSDK2;
    using World;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;
    using xAstroBoy.Utility;
    using Color = System.Drawing.Color;
    using VRC_Pickup = VRC.SDKBase.VRC_Pickup;

    #endregion Imports

    internal class GameObjectMenu : AstroEvents
    {
        internal static void InitButtons(QMGridTab menu)
        {
            var GameObjectsMenus = new QMNestedGridMenu(menu, "GameObjects DebugMenu", "Find Whatever is in these VRChat GameObjects in console");
            _ = new QMSingleButton(GameObjectsMenus, 1, 1, "Print RigidBody Info In Console", new Action(() => { Tweaker_Object.GetGameObjectToEdit().gameObject.PrintAllRigidBodySettings(); }), "Print RigidBody Details in console!", null, null);
            _ = new QMSingleButton(GameObjectsMenus, 2, 1, "Find who is controlling pickups", new Action(GetAllPickupsOwners), "Print Pickups Owners in console!", null, null);
            _ = new QMSingleButton(GameObjectsMenus, 3, 1, "Print VideoPlayer Links in console.", new Action(DumpVideoPlayerURLS), "Print VideoPlayers URLS Queque in console!", null, null);
            _ = new QMSingleButton(GameObjectsMenus, 4, 1, "Cleans Queque in Videoplayers", new Action(ClearVideoPlayers), "Clears Queque in VideoPlayers.", null, null);
            ColliderDisplay.ToggleColliderXRayBtn = new QMToggleButton(GameObjectsMenus, 1, 2, "XRay ON", new Action(() => { XRay.ToggleEnabledRenderers(); }), "XRay OFF", new Action(() => { XRay.ToggleEnabledRenderers(); }), "Reveals Colliders.", null, null, null, false);
            ColliderDisplay.ToggleColliderInvisibleXRayBtn = new QMToggleButton(GameObjectsMenus, 2, 2, "Invisible Xray ON", new Action(() => { XRay.ToggleDisabledRenderers(); }), "Invisible XRay OFF", new Action(() => { XRay.ToggleDisabledRenderers(); }), "Reveals Invisible colliders.", null, null, null, false);

            ColliderDisplay.ToggleColliderDisplayBtn = new QMToggleButton(GameObjectsMenus, 3, 2, "Collider Viewer ON", new Action(() => { ColliderDisplay.ToggleDisplays(true); }), "Collider Viewer OFF", new Action(() => { ColliderDisplay.ToggleDisplays(false); }), "Reveals all world triggers available.", null, null, null, false);
        }

        internal static Il2CppArrayBase<VRC_SyncVideoPlayer> VRC_SyncVideoPlayers => Resources.FindObjectsOfTypeAll<VRC_SyncVideoPlayer>();

        internal static Il2CppArrayBase<SyncVideoPlayer> SyncVideoPlayers => Resources.FindObjectsOfTypeAll<SyncVideoPlayer>();

        internal static void DumpVideoPlayerURLS()
        {
            for (int i = 0; i < VRC_SyncVideoPlayers.Count; i++)
            {
                VRC_SyncVideoPlayer VideoPlayer = VRC_SyncVideoPlayers[i];
                if (VideoPlayer != null)
                {
                    foreach (var video in VideoPlayer.Videos)
                    {
                        if (video != null)
                        {
                            ModConsole.Log("VideoPlayer URL Found :" + video.URL);
                        }
                    }
                }
            }
        }

        internal static void ClearVideoPlayers()
        {
            for (int i = 0; i < VRC_SyncVideoPlayers.Count; i++)
            {
                VRC_SyncVideoPlayer VideoPlayer = VRC_SyncVideoPlayers[i];
                if (VideoPlayer != null)
                {
                    VideoPlayer.Stop();
                    VideoPlayer.Clear();

                    UnityEngine.Object.DestroyImmediate(VideoPlayer.gameObject);
                }
            }
        }

        internal static void CheckObjComponents(Transform Obj)
        {
            try
            {
                if (Obj != null)
                {
                    var components = Obj.GetComponentsInChildren<Component>(true);
                    for (int i = 0; i < components.Count; i++)
                    {
                        Component OriginalComponent = components[i];
                        ModConsole.Log(Obj.name + " component : " + OriginalComponent.ToString());
                    }
                }
            }
            catch (Exception) { }
        }

        internal static void CheckObjComponents(GameObject Obj)
        {
            try
            {
                if (Obj != null)
                {
                    var components = Obj.GetComponentsInChildren<Component>(true);
                    for (int i = 0; i < components.Count; i++)
                    {
                        Component OriginalComponent = components[i];
                        ModConsole.Log(Obj.name + " component : " + OriginalComponent.ToString());
                    }
                }
            }
            catch (Exception) { }
        }

        internal static string ReturnObjectComponentsToString(GameObject Obj)
        {
            StringBuilder comp = new StringBuilder();
            try
            {
                if (Obj != null)
                {
                    var components = Obj.GetComponentsInChildren<Component>(true);
                    for (int i = 0; i < components.Count; i++)
                    {
                        Component OriginalComponent = components[i];
                        _ = comp.AppendLine("Component : " + OriginalComponent.ToString() + ",");
                    }
                    return comp.ToString();
                }
                return "Object is null here!";
            }
            catch (Exception)
            {
                return "Exception Found! Aborted!";
            }
        }

        internal static void EnableAllWorldPickups()
        {
            List<GameObject> list = WorldUtils_Old.Get_Pickups();
            for (int i = 0; i < list.Count; i++)
            {
                GameObject item = list[i];
                if (!item.active)
                {
                    item.SetActive(true);
                }
            }
        }

        internal static void TeleportPlayerToPickup(GameObject obj)
        {
            if (obj != null && GameInstances.CurrentUser != null)
            {
                GameInstances.CurrentUser.transform.position = obj.transform.position;
            }
        }

        internal static void RestoreOriginalLocation(GameObject obj, bool RestoreBodySettings)
        {
            if (obj != null)
            {
                obj.TryTakeOwnership();
                var control = obj.GetComponent<RigidBodyController>();

                if (control != null)
                {
                    if (RestoreBodySettings)
                    {
                        control.RestoreOriginalBody();
                    }

                    if (control.SyncPhysics != null)
                    {
                        control.SyncPhysics.RespawnItem();
                    }
                }
                else
                {
                    var SyncPhysic = obj.GetComponent<SyncPhysics>();
                    if (SyncPhysic != null)
                    {
                        SyncPhysic.RespawnItem();
                    }
                }
            }
        }

        internal static bool IsLocalPlayerHoldingObject(GameObject obj) => obj.GetComponent<VRC_Pickup>() != null && obj.GetComponent<VRC_Pickup>().currentPlayer.displayName == GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().displayName;

        internal static void TeleportPickupsToTheirDefaultPosition(bool RestoreBodySettings)
        {
            List<GameObject> list = WorldUtils_Old.Get_Pickups();
            for (int i = 0; i < list.Count; i++)
            {
                GameObject Pickup = list[i];
                if (Pickup != null)
                {
                    RestoreOriginalLocation(Pickup.gameObject, RestoreBodySettings);
                }
            }
        }

        internal static void DisableAllWorldPickups()
        {
            List<GameObject> list = WorldUtils_Old.Get_Pickups();
            for (int i = 0; i < list.Count; i++)
            {
                GameObject item = list[i];
                if (!item.active)
                {
                    item.SetActive(false);
                }
            }
        }

        internal static void GrabbableGameObjDumper()
        {
            GrabGameObjDumper.SetIntractable(false);
            new Thread(() =>
            {
                string path = Path.Combine(Environment.CurrentDirectory + $@"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_VRCPickups.txt");
                Thread.CurrentThread.IsBackground = true;
                var listg = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
                using (var txtFile = File.AppendText(path))
                {
                    for (int i = 0; i < listg.Count; i++)
                    {
                        VRC_Pickup gameobj = listg[i];
                        if (File.Exists(path))
                        {
                            txtFile.WriteLine("Found: " + gameobj.name);
                        }
                        else
                        {
                            using (FileStream fs = File.Create(path))
                            {
                                txtFile.WriteLine("Found: " + gameobj.name);
                            }
                        }
                    }
                    txtFile.Close();
                }
                ModConsole.Log("Done Dumping GameObjects, Check The Path");
            }).Start();
        }

        internal static void GameObjectDumper()
        {
            GameObjDumper.SetIntractable(false);
            new Thread(() =>
            {
                string path = Path.Combine(Environment.CurrentDirectory + $@"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_GameObjects.txt");
                Thread.CurrentThread.IsBackground = true;
                var listg = Resources.FindObjectsOfTypeAll<Transform>();
                using (var txtFile = File.AppendText(path))
                {
                    for (int i = 0; i < listg.Count; i++)
                    {
                        Transform gameobj = listg[i];
                        if (File.Exists(path))
                        {
                            txtFile.WriteLine("Found: " + gameobj.name);
                        }
                        else
                        {
                            using (FileStream fs = File.Create(path))
                            {
                                txtFile.WriteLine("Found: " + gameobj.name);
                            }
                        }
                    }
                    txtFile.Close();
                }
                ModConsole.Log("Done Dumping GameObjects, Check The Path");
            }).Start();
        }

        internal static void GetAllPickupsOwners()
        {
            List<GameObject> list = WorldUtils_Old.Get_Pickups();
            for (int i = 0; i < list.Count; i++)
            {
                GameObject item = list[i];
                if (item != null)
                {
                    var photon = item.GetComponent<PhotonView>();
                    if (photon != null)
                    {
                        var ownerid = photon.field_Private_Int32_0;
                        var player = PlayerManager.Method_Public_Static_Player_Int32_0(ownerid);
                        if (player != null)
                        {
                            ModConsole.Log("Player : " + player.prop_APIUser_0.displayName + " is controlling object : " + item.name, Color.GreenYellow);
                        }
                    }
                }
            }
        }

        internal static void GameObjDumperWithComponents()
        {
            ObjDumperWithComponentsBtn.SetIntractable(false);
            string path = Path.Combine(Environment.CurrentDirectory + $@"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_GameObjects_With_components.txt");
            var listg = Resources.FindObjectsOfTypeAll<GameObject>();
            using (var txtFile = File.AppendText(path))
            {
                for (int i = 0; i < listg.Count; i++)
                {
                    GameObject gameobj = listg[i];
                    if (File.Exists(path))
                    {
                        txtFile.WriteLine("Found: " + gameobj.name + " With Components: ");
                        txtFile.WriteLine("{");
                        txtFile.Write(ReturnObjectComponentsToString(gameobj));
                        txtFile.WriteLine("}");
                    }
                    else
                    {
                        using (FileStream fs = File.Create(path))
                        {
                            txtFile.WriteLine("Found: " + gameobj.name + " With Components: ");
                            txtFile.WriteLine("{");
                            txtFile.Write(ReturnObjectComponentsToString(gameobj));
                            txtFile.WriteLine("}");
                        }
                    }
                }
                txtFile.Close();
            }
            ModConsole.Log("Done Dumping GameObjects, Check The Path");
        }

        internal static List<GameObject> GetAllPickupObjects()
        {
            List<GameObject> Objects = new List<GameObject>();
            var listg = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
            for (int i = 0; i < listg.Count; i++)
            {
                VRC_Pickup obj = listg[i];
                if (!Objects.Contains(obj.gameObject))
                {
                    Objects.Add(obj.gameObject);
                }
            }
            return Objects;
        }

        internal static void RemoveWorldMirrors()
        {
            FindWorldMirrors();
            DestroyMirrors();
        }

        internal static void FindWorldMirrors()
        {
            Mirrors.Clear();
            var Mir1 = Resources.FindObjectsOfTypeAll<MirrorReflection>();
            var Mir2 = Resources.FindObjectsOfTypeAll<VRCMirrorReflection>();
            var Mir3 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_MirrorReflection>();
            var Mir4 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_MirrorReflection>();
            for (int i = 0; i < Mir1.Count; i++)
            {
                MirrorReflection item = Mir1[i];
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }
            for (int i = 0; i < Mir2.Count; i++)
            {
                VRCMirrorReflection item = Mir2[i];
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }
            for (int i = 0; i < Mir3.Count; i++)
            {
                VRC.SDKBase.VRC_MirrorReflection item = Mir3[i];
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }
            for (int i = 0; i < Mir4.Count; i++)
            {
                VRCSDK2.VRC_MirrorReflection item = Mir4[i];
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }

            ModConsole.Log("Mirrors Found : " + Mirrors.Count());
        }

        internal static void DestroyMirrors()
        {
            for (int i = 0; i < Mirrors.Count; i++)
            {
                GameObject item = Mirrors[i];
                if (item != null)
                {
                    ModConsole.Log("Killed Mirror : " + item.name);
                    OnlineEditor.TakeObjectOwnership(item);
                    Networking.Destroy(item);
                    UnityEngine.Object.DestroyImmediate(item);
                }
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Mirrors.Clear();
            if (GameObjDumper != null)
            {
                GameObjDumper.SetIntractable(true);
            }
            if (GrabGameObjDumper != null)
            {
                GrabGameObjDumper.SetIntractable(true);
            }

            if (ObjDumperWithComponentsBtn != null)
            {
                ObjDumperWithComponentsBtn.SetIntractable(true);
            }
        }

        internal static void DumpHoldingGameObjComponent()
        {
            var held = Tweaker_Object.GetGameObjectToEdit();
            if (held != null)
            {
                CheckObjComponents(held);
            }
        }

        internal static void DumpObjectComponent(GameObject obj)
        {
            if (obj != null)
            {
                CheckObjComponents(obj);
            }
        }

        internal static void DumpObjectComponent(Transform obj)
        {
            if (obj != null)
            {
                CheckObjComponents(obj);
            }
        }

        internal static QMSingleButton GameObjDumper;
        internal static QMSingleButton GrabGameObjDumper;
        internal static QMSingleButton ObjDumperWithComponentsBtn;

        internal static bool HasPrePatchedGameObjects = false;

        internal static List<GameObject> Mirrors = new List<GameObject>();
    }
}