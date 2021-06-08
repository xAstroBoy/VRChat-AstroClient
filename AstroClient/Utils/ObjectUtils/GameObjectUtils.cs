namespace AstroClient.GameObjectDebug
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweaker;
	using AstroLibrary.Console;
	using Boo.Lang;
	using AstroLibrary.Extensions;
	using Il2CppSystem.Text;
	using Photon.Pun;
	using RubyButtonAPI;
	using System;
	using System.IO;
	using System.Linq;
	using System.Threading;
	using UnhollowerBaseLib;
	using UnityEngine;
	using VRC;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRCSDK2;
	using Color = System.Drawing.Color;
	using VRC_Pickup = VRC.SDKBase.VRC_Pickup;

	public class GameObjectUtils : GameEvents
    {
        public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var GameObjectsMenus = new QMNestedButton(menu, x, y, "GameObjects DebugMenu", "Find Whatever is in these VRChat GameObjects in console", null, null, null, null, btnHalf);
            GameObjDumper = new QMSingleButton(GameObjectsMenus, 1, 0, "World's Gameobject Dumper", new Action(GameObjectDumper), "Dump All World GameObjects's names in a file!", null, null);
            new QMSingleButton(GameObjectsMenus, 2, 0, "Print GameObject Components in console", new Action(DumpHoldingGameObjComponent), "Prints Gameobj components in console", null, null);
            GrabGameObjDumper = new QMSingleButton(GameObjectsMenus, 3, 0, "Grabbable name Dumper", new Action(GrabbableGameObjDumper), "Dump All Grabbable GameObjects's names in a file!", null, null);
            ObjDumperWithComponentsBtn = new QMSingleButton(GameObjectsMenus, 4, 0, "Dump World GameObjects with components", new Action(GameObjDumperWithComponents), "Dump All World GameObjects's along with their components!", null, null);
            new QMSingleButton(GameObjectsMenus, 1, 1, "Print RigidBody Info In Console", new Action(() => { Tweaker_Object.GetGameObjectToEdit().gameObject.PrintAllRigidBodySettings(); }), "Print RigidBody Details in console!", null, null);
            new QMSingleButton(GameObjectsMenus, 2, 1, "Find who is controlling pickups", new Action(GetAllPickupsOwners), "Print Pickups Owners in console!", null, null);
            new QMSingleButton(GameObjectsMenus, 3, 1, "Print VideoPlayer Links in console.", new Action(DumpVideoPlayerURLS), "Print VideoPlayers URLS Queque in console!", null, null);
            new QMSingleButton(GameObjectsMenus, 4, 1, "Cleans Queque in Videoplayers", new Action(ClearVideoPlayers), "Clears Queque in VideoPlayers.", null, null);
            ColliderDisplay.ToggleColliderXRayBtn = new QMToggleButton(GameObjectsMenus, 1, 2, "XRay ON", new Action(() => { XRay.ToggleEnabledRenderers(); }), "XRay OFF", new Action(() => { XRay.ToggleEnabledRenderers(); }), "Reveals Colliders.", null, null, null, false);
            ColliderDisplay.ToggleColliderInvisibleXRayBtn = new QMToggleButton(GameObjectsMenus, 2, 2, "Invisible Xray ON", new Action(() => { XRay.ToggleDisabledRenderers(); }), "Invisible XRay OFF", new Action(() => { XRay.ToggleDisabledRenderers(); }), "Reveals Invisible colliders.", null, null, null, false);

            ColliderDisplay.ToggleColliderDisplayBtn = new QMToggleButton(GameObjectsMenus, 3, 2, "Collider Viewer ON", new Action(() => { ColliderDisplay.ToggleDisplays(true); }), "Collider Viewer OFF", new Action(() => { ColliderDisplay.ToggleDisplays(false); }), "Reveals all world triggers available.", null, null, null, false);
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

        public static void CheckObjComponents(Transform Obj)
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
            foreach (var item in WorldUtils.Get_Pickups())
            {
                if (!item.active)
                {
                    item.SetActive(true);
                }
            }
        }

        public static void TeleportPlayerToPickup(GameObject obj)
        {
            if (obj != null && Utils.CurrentUser != null)
            {
                Utils.CurrentUser.transform.position = obj.transform.position;
            }
        }

        public static void RestoreOriginalLocation(GameObject obj, bool RestoreBodySettings)
        {
			if (obj != null)
			{
				obj.TakeOwnership();
				var control = obj.GetComponent<RigidBodyController>();
				var SyncPhysic = obj.GetComponent<SyncPhysics>();

				if (control != null)
				{
					if (RestoreBodySettings)
					{
						control.RestoreOriginalBody();
					}
				}
				if (SyncPhysic != null)
				{
					SyncPhysic.RespawnItem();
				}
			}
        }

        public static bool IsLocalPlayerHoldingObject(GameObject obj)
        {
            return obj.GetComponent<VRC_Pickup>() != null && obj.GetComponent<VRC_Pickup>().currentPlayer.displayName == LocalPlayerUtils.GetSelfVRCPlayerApi().displayName;
        }

        public static void TeleportPickupsToTheirDefaultPosition(bool RestoreBodySettings)
        {
            foreach (var Pickup in WorldUtils.Get_Pickups())
            {
                if (Pickup != null)
                {
                    RestoreOriginalLocation(Pickup.gameObject, RestoreBodySettings);
                }
            }
        }

        public static void DisableAllWorldPickups()
        {
            foreach (var item in WorldUtils.Get_Pickups())
            {
                if (!item.active)
                {
                    item.SetActive(false);
                }
            }
        }

        public static void GrabbableGameObjDumper()
        {
            GrabGameObjDumper.SetIntractable(false);
            new Thread(() =>
            {
                string path = Path.Combine(Environment.CurrentDirectory + $@"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_VRCPickups.txt");
                Thread.CurrentThread.IsBackground = true;
                var listg = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
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
            GameObjDumper.SetIntractable(false);
            new Thread(() =>
            {
                string path = Path.Combine(Environment.CurrentDirectory + $@"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_GameObjects.txt");
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
            foreach (var item in WorldUtils.Get_Pickups())
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
            ObjDumperWithComponentsBtn.SetIntractable(false);
            string path = Path.Combine(Environment.CurrentDirectory + $@"/{BuildInfo.Name}_DebugInfos/" + RoomManager.field_Internal_Static_ApiWorld_0.name.ToString() + "_GameObjects_With_components.txt");
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
            var listg = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
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

        public static void DumpHoldingGameObjComponent()
        {
            var held = Tweaker_Object.GetGameObjectToEdit();
            if (held != null)
            {
                CheckObjComponents(held);
            }
        }

        public static void DumpObjectComponent(GameObject obj)
        {
            if (obj != null)
            {
                CheckObjComponents(obj);
            }
        }

        public static void DumpObjectComponent(Transform obj)
        {
            if (obj != null)
            {
                CheckObjComponents(obj);
            }
        }

        public static QMSingleButton GameObjDumper;
        public static QMSingleButton GrabGameObjDumper;
        public static QMSingleButton ObjDumperWithComponentsBtn;

        public static bool HasPrePatchedGameObjects = false;

        public static List<GameObject> Mirrors = new List<GameObject>();
    }
}