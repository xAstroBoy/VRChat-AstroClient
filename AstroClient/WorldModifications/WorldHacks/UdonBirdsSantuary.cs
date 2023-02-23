using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Skybox;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy.UIPaths;
using AstroClient.xAstroBoy.Utility;
using VRC.Core;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class Udon_Bird_Santuary : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnEnterWorld += OnWorldEnter;
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldEnter(ApiWorld world, ApiWorldInstance instance)
        {
            if (world == null) return;

            if (world.id.Equals(WorldIds.Udon_Bird_Santuary))
            {
                try
                {
                    InstallSkybox();
                }
                catch { }
                try
                {
                    FixMoss();
                }
                catch { }
                try
                {
                    GetRidOftrash();
                }
                catch { }
                try
                {
                    FixWater();
                }
                catch { }
                try
                {
                    MakeLandWalkable();
                }
                catch { }

                 // make the scenery actually walkable, not ugly 
            }
        }
        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.Udon_Bird_Santuary))
            {
                SceneUtils.RespawnHeightY = -150f; 
                PlayerCameraEditor.PlayerCamera.farClipPlane = 5000f;
                RenderSettings.fog = false;
                try
                {
                    InstallSkybox();
                }
                catch { }
                try
                {
                    FixMoss();
                }
                catch { }
                try
                {
                    GetRidOftrash();
                }
                catch { }
                try
                {
                    FixWater();
                }
                catch { }
                try
                {
                    MakeLandWalkable();
                }
                catch { }

            }
        }
        private static GameObject MossExpander = null;
        private static string[] Trash = new[]
        {
            "fog",
            "Occlusion Area",
            "LagDetector",
        };

        internal static void InstallSkybox()
        {
            if (SkyboxEditor.SetSkyboxByFileName("MountainsSkybox"))
            {
                Log.Debug("Better Skybox Installed.");
            }

        }

        private static void GetRidOftrash()
        {
            foreach (var item in Trash)
            {
                var obj = Finder.Find(item);
                if (obj != null)
                {
                    obj.DestroyMeLocal(true);
                }
            }
        }
        private static void FixWater()
        {
            var water = Finder.Find("Water");
            if (water != null)
            {
                // expand it first .
                var scale = water.transform.localScale;
                scale.y = 999999f;
                scale.x = 999999f;
                water.transform.localScale = scale;
            }

        }

        private static void FixMoss()
        {
            var moss = Finder.Find("Mossy Ground");
            if (moss != null)
            {
                if (MossExpander == null)
                {
                    // make a primitive plane
                    MossExpander = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    MossExpander.name = "Moss Expander";
                }
                if (MossExpander != null)
                {
                    MossExpander.transform.position = new Vector3(0f, -1.238f, -1.23f);
                    var scale = moss.transform.localScale;
                    scale.x = 250f;
                    scale.z = 250f;
                    // get both renderers
                    var mossRenderer = moss.GetComponent<MeshRenderer>();
                    var planeRenderer = MossExpander.GetComponent<MeshRenderer>();
                    // copy the material
                    planeRenderer.material = mossRenderer.material;
                }

            }

        }

        private static readonly string[] Lands = new[]
{
            "TerrainTestHifi (1)",
            "TerrainTestHifi",
            "Terrain (ID_16228)/Terrain_ID_16228",
        };



        private static void MakeLandWalkable()
        {
            foreach(var item in Lands)
            {
                var land = Finder.Find(item);
                if (land != null)
                {
                    land.isStatic = true;
                    land.GetOrAddComponent<MeshCollider>();
                }

            }
        }


    }
}