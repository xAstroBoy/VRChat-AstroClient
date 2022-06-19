using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;

namespace AstroClient.Tools.ObjectEditor
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using AstroMonos.Components.Tools;
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
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
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
                            Log.Write("VideoPlayer URL Found :" + video.URL);
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


        internal static bool IsLocalPlayerHoldingObject(GameObject obj) => obj.GetComponent<VRC_Pickup>() != null && obj.GetComponent<VRC_Pickup>().currentPlayer.displayName == GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().displayName;

        internal static void TeleportPickupsToTheirDefaultPosition(bool RestoreBodySettings)
        {
            List<GameObject> list = WorldUtils_Old.Get_Pickups();
            for (int i = 0; i < list.Count; i++)
            {
                GameObject Pickup = list[i];
                if (Pickup != null)
                {
                    Pickup.RespawnPickup(RestoreBodySettings);
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
                            Log.Write("Player : " + player.prop_APIUser_0.displayName + " is controlling object : " + item.name, Color.GreenYellow);
                        }
                    }
                }
            }
        }








        internal static bool HasPrePatchedGameObjects = false;

    }
}