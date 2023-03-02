using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Controller;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.Spawnables
{
    internal class GrappleSpawner : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if(IsGrappleEnabled)
            {
                Spawn();
            }
        }

        private void OnRoomLeft()
        {
            Destroy();
        }

        private static GameObject GrappleObject { get; set; } = null;


        private static bool _IsGrappleEnabled { get; set; } = false;
        internal static bool IsGrappleEnabled
        {
            get => _IsGrappleEnabled;
            set
            {
                if(value != _IsGrappleEnabled)
                {
                    if(value)
                    {
                        Spawn();
                    }
                    else
                    {
                        Destroy();
                    }
                    _IsGrappleEnabled = value;
                }
            }
        } 





        private static void Spawn()
        {
            if(GrappleObject= null)
            {
                Vector3? Pos = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
                Quaternion? Rot = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
                if (Pos.HasValue && Rot.HasValue)
                {
                    if (GameInstances.LocalPlayer.IsUserInVR())
                    {
                        GrappleObject = Object.Instantiate(ClientResources.Loaders.Prefabs.Grapple_VR, Pos.GetValueOrDefault(), Rot.GetValueOrDefault(), null);
                        GrappleObject.GetOrAddComponent<Grapple_VR_Controller>();
                    }
                    else
                    {
                        GrappleObject = Object.Instantiate(ClientResources.Loaders.Prefabs.Grapple_Desktop, Pos.GetValueOrDefault(), Rot.GetValueOrDefault(), null);
                        GrappleObject.GetOrAddComponent<Grapple_Desktop_Controller>();

                    }
                    GrappleObject.AddToWorldUtilsMenu();
                }
            }
        }

        internal static void Destroy()
        {
            if (GrappleObject != null)
            {
                GrappleObject.DestroyMeLocal(true);
            }
        }
    }
}