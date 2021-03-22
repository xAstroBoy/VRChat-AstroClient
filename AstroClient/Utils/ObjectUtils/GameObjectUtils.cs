using Boo.Lang;
using Il2CppSystem.Text;
using RubyButtonAPI;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using UnhollowerBaseLib;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRCSDK2;
using VRC_Pickup = VRC.SDKBase.VRC_Pickup;
using Photon.Pun;
using VRC;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.components;
using static AstroClient.HandsUtils;
using AstroClient.ConsoleUtils;
using DayClientML2.Utility.Extensions;
using AstroClient.extensions;
using AstroClient.SyncPhysicExt;
#endregion AstroClient Imports

namespace AstroClient.GameObjectDebug
{
    public class GameObjectUtils : Overridables
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var GameObjectsMenus = new QMNestedButton(menu, x, y, "GameObjects DebugMenu", "Find Whatever is in these VRChat GameObjects in console", null, null, null, null, btnHalf);
            GameObjectUtils.GameObjDumper = new QMSingleButton(GameObjectsMenus, 1, 0, "World's Gameobject Dumper", new Action(GameObjectUtils.GameObjectDumper), "Dump All World GameObjects's names in a file!", null, null);
            new QMSingleButton(GameObjectsMenus, 2, 0, "Print GameObject Components in console", new Action(GameObjectUtils.DumpHoldingGameObjComponent), "Prints Gameobj components in console", null, null);
            GameObjectUtils.GrabGameObjDumper = new QMSingleButton(GameObjectsMenus, 3, 0, "Grabbable name Dumper", new Action(GameObjectUtils.GrabbableGameObjDumper), "Dump All Grabbable GameObjects's names in a file!", null, null);
            GameObjectUtils.ObjDumperWithComponentsBtn = new QMSingleButton(GameObjectsMenus, 4, 0, "Dump World GameObjects with components", new Action(GameObjectUtils.GameObjDumperWithComponents), "Dump All World GameObjects's along with their components!", null, null);
            new QMSingleButton(GameObjectsMenus, 1, 1, "Print RigidBody Info In Console", new Action(() => { HandsUtils.GetGameObjectToEdit().PrintAllRigidBodySettings(); }), "Print RigidBody Details in console!", null, null);
            new QMSingleButton(GameObjectsMenus, 2, 1, "Find who is controlling pickups", new Action(GameObjectUtils.GetAllPickupsOwners), "Print Pickups Owners in console!", null, null);
            new QMSingleButton(GameObjectsMenus, 3, 1, "Print VideoPlayer Links in console.", new Action(GameObjectUtils.DumpVideoPlayerURLS), "Print VideoPlayers URLS Queque in console!", null, null);
            new QMSingleButton(GameObjectsMenus, 4, 1, "Cleans Queque in Videoplayers", new Action(GameObjectUtils.ClearVideoPlayers), "Clears Queque in VideoPlayers.", null, null);
            ColliderDisplay.ToggleColliderXRayBtn = new QMToggleButton(GameObjectsMenus, 1, 2, "XRay ON", new Action(() => { XRay.ToggleEnabledRenderers(); }), "XRay OFF", new Action(() => { XRay.ToggleEnabledRenderers(); }), "Reveals Colliders.", null, null, null, false);
            ColliderDisplay.ToggleColliderInvisibleXRayBtn = new QMToggleButton(GameObjectsMenus, 2, 2, "Invisible Xray ON", new Action(() => { XRay.ToggleDisabledRenderers(); }), "Invisible XRay OFF", new Action(() => { XRay.ToggleDisabledRenderers(); }), "Reveals Invisible colliders.", null, null, null, false);

            ColliderDisplay.ToggleColliderDisplayBtn = new QMToggleButton(GameObjectsMenus, 3, 2, "Collider Viewer ON", new Action(() => { ColliderDisplay.ToggleDisplays(true); }), "Collider Viewer OFF", new Action(() => { ColliderDisplay.ToggleDisplays(false); }), "Reveals all world triggers available.", null, null, null, false);
            GameObjectESP.TriggerESPToggler = new QMToggleButton(GameObjectsMenus, 4, 2, "Trigger ESP ON", new Action(GameObjectESP.AddESPToTriggers), "Trigger ESP OFF", new Action(GameObjectESP.RemoveESPToTriggers), "Reveals all world triggers available.", null, null, null, false);
        }

        public static Il2CppArrayBase<VRC_SyncVideoPlayer> GetVRC_SyncVideoPlayers()
        {
            return Resources.FindObjectsOfTypeAll<VRC_SyncVideoPlayer>();
        }

        public static Il2CppArrayBase<SyncVideoPlayer> GetSyncVideoPlayer()
        {
            return Resources.FindObjectsOfTypeAll<SyncVideoPlayer>();
        }

        public static void DumpVideoPlayerURLS()
        {
            foreach (var VideoPlayer in GetVRC_SyncVideoPlayers())
            {
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

        public static void ClearVideoPlayers()
        {
            foreach (var VideoPlayer in GetVRC_SyncVideoPlayers())
            {
                if (VideoPlayer != null)
                {
                    VideoPlayer.Stop();
                    VideoPlayer.Clear();

                    UnityEngine.Object.DestroyImmediate(VideoPlayer.gameObject);
                }
            }
        }

        public static void CheckObjComponents(GameObject Obj)
        {
            try
            {
                if (Obj != null)
                {
                    var components = Obj.GetComponentsInChildren<Component>(true);
                    foreach (Component OriginalComponent in components)
                    {
                        ModConsole.Log(Obj.name + " component : " + OriginalComponent.ToString());
                    }
                }
            }
            catch (Exception) { }
        }

        public static string ReturnObjectComponentsToString(GameObject Obj)
        {
            StringBuilder comp = new StringBuilder();
            try
            {
                if (Obj != null)
                {
                    var components = Obj.GetComponentsInChildren<Component>(true);
                    foreach (Component OriginalComponent in components)
                    {
                        comp.AppendLine("Component : " + OriginalComponent.ToString() + ",");
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

        public static void EnableAllWorldPickups()
        {
            var pickups = WorldUtils.GetAllWorldPickups();
            foreach (var component in pickups)
            {
                if (component.gameObject.name == "ViewFinder")
                {
                    continue;
                }
                if (component.gameObject.name == "AvatarDebugConsole")
                {
                    continue;
                }
                if (!component.gameObject.active)
                {
                    component.gameObject.SetActive(true);
                }
            }
        }


        public static void TeleportPlayerToPickup(GameObject obj)
        {
            if(obj != null && Utils.CurrentUser != null)
            {
                Utils.CurrentUser.transform.position = obj.transform.position;
            }
        }
        public static void RestoreOriginalLocation(GameObject obj, bool RestoreBodySettings)
        {
            if (obj != null)
            {
                var PhysicSync = obj.GetComponentInChildren<SyncPhysics>();
                var control = obj.GetComponent<RigidBodyController>();
                if (RestoreBodySettings)
                {
                    if (control != null)
                    {
                        control.RestoreOriginalBody();
                    }
                }

                if (PhysicSync != null)
                {
                    OnlineEditor.TakeObjectOwnership(obj);
                    PhysicSync.RespawnItem();
                    return;
                }
            }
        }

        public static bool IsLocalPlayerHoldingObject(GameObject obj)
        {
            var pickup = obj.GetComponent<VRC_Pickup>();
            if (pickup != null)
            {
                if (pickup.currentPlayer.displayName != LocalPlayerUtils.GetSelfVRCPlayerApi().displayName)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static void TeleportPickupsToTheirDefaultPosition()
        {
            foreach (var Pickup in WorldUtils.GetAllWorldPickups())
            {
                if (Pickup != null)
                {
                    if (Pickup.gameObject.name == "ViewFinder")
                    {
                        continue;
                    }
                    if (Pickup.gameObject.name == "AvatarDebugConsole")
                    {
                        continue;
                    }
                    RestoreOriginalLocation(Pickup.gameObject, true);
                }
            }
        }

        public static void DisableAllWorldPickups()
        {
            Thread.CurrentThread.IsBackground = true;
            var basepickup = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>();
            foreach (var component in basepickup)
            {
                if (component.gameObject.name == "ViewFinder")
                {
                    continue;
                }
                if (component.gameObject.name == "AvatarDebugConsole")
                {
                    continue;
                }
                if (component.gameObject.active)
                {
                    component.gameObject.SetActive(false);
                }
            }
            var SDK3Pickup = Resources.FindObjectsOfTypeAll<VRC.SDK3.Components.VRCPickup>();
            foreach (var component in basepickup)
            {
                if (component.gameObject.name == "ViewFinder")
                {
                    continue;
                }
                if (component.gameObject.name == "AvatarDebugConsole")
                {
                    continue;
                }
                if (!component.gameObject.active)
                {
                    component.gameObject.SetActive(true);
                }
            }
        }

        public static void GrabbableGameObjDumper()
        {
            GrabGameObjDumper.setIntractable(false);
            new Thread(() =>
            {
                string path = Path.Combine(Environment.CurrentDirectory + @$"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_VRCPickups.txt");
                Thread.CurrentThread.IsBackground = true;
                var listg = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>();
                using (var txtFile = File.AppendText(path))
                {
                    foreach (var gameobj in listg)
                    {
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

        public static void GameObjectDumper()
        {
            GameObjDumper.setIntractable(false);
            new Thread(() =>
            {
                string path = Path.Combine(Environment.CurrentDirectory + @$"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_GameObjects.txt");
                Thread.CurrentThread.IsBackground = true;
                var listg = Resources.FindObjectsOfTypeAll<Transform>();
                using (var txtFile = File.AppendText(path))
                {
                    foreach (var gameobj in listg)
                    {
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


        public static void GetAllPickupsOwners()
        {
            foreach (var item in WorldUtils.GetAllWorldPickups())
            {
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

        public static void GameObjDumperWithComponents()
        {
            ObjDumperWithComponentsBtn.setIntractable(false);
            string path = Path.Combine(Environment.CurrentDirectory + @$"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_GameObjects_With_components.txt");
            var listg = Resources.FindObjectsOfTypeAll<GameObject>();
            using (var txtFile = File.AppendText(path))
            {
                foreach (var gameobj in listg)
                {
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

        public static List<GameObject> GetAllPickupObjects()
        {
            List<GameObject> Objects = new List<GameObject>();
            var listg = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>();
            foreach (var obj in listg)
            {
                if (!Objects.Contains(obj.gameObject))
                {
                    Objects.Add(obj.gameObject);
                }
            }
            return Objects;
        }

        public static void RemoveWorldMirrors()
        {
            FindWorldMirrors();
            DestroyMirrors();
        }

        public static void FindWorldMirrors()
        {
            Mirrors.Clear();
            var Mir1 = Resources.FindObjectsOfTypeAll<MirrorReflection>();
            var Mir2 = Resources.FindObjectsOfTypeAll<VRCMirrorReflection>();
            var Mir3 = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_MirrorReflection>();
            var Mir4 = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_MirrorReflection>();
            foreach (var item in Mir1)
            {
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }
            foreach (var item in Mir2)
            {
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }
            foreach (var item in Mir3)
            {
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }
            foreach (var item in Mir4)
            {
                if (!Mirrors.Contains(item.gameObject))
                {
                    Mirrors.Add(item.gameObject);
                    ModConsole.Log("Added " + item.gameObject.name + " To the Mirrors List!");
                }
            }

            ModConsole.Log("Mirrors Found : " + Mirrors.Count());
        }

        public static void DestroyMirrors()
        {
            foreach (var item in Mirrors)
            {
                if (item != null)
                {
                    ModConsole.Log("Killed Mirror : " + item.name);
                    OnlineEditor.TakeObjectOwnership(item);
                    Networking.Destroy(item);
                    UnityEngine.Object.DestroyImmediate(item);
                }
            }
        }

        public override void OnLevelLoaded()
        {
            Mirrors.Clear();
            if (GameObjDumper != null)
            {
                GameObjDumper.setIntractable(true);
            }
            if (GrabGameObjDumper != null)
            {
                GrabGameObjDumper.setIntractable(true);
            }

            if (ObjDumperWithComponentsBtn != null)
            {
                ObjDumperWithComponentsBtn.setIntractable(true);
            }
        }

        public static void DumpHoldingGameObjComponent()
        {
            var held = HandsUtils.GetHoldGameObject();
            if (held != null)
            {
                CheckObjComponents(held);
            }
            else
            {
                CheckObjComponents(HandsUtils.GetGameObjectToEdit());
            }
        }

        public static QMSingleButton GameObjDumper;
        public static QMSingleButton GrabGameObjDumper;
        public static QMSingleButton ObjDumperWithComponentsBtn;

        public static bool HasPrePatchedGameObjects = false;

        public static List<GameObject> Mirrors = new List<GameObject>();
    }
}