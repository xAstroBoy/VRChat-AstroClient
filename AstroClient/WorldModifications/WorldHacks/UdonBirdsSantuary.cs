using System.Collections;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Skybox;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy.UIPaths;
using AstroClient.xAstroBoy.Utility;
using VRC.Core;
using VRC.Udon;
using System.Collections.Generic;
using AstroClient.Developers.xAstroBoy.AstroLibrary.Extensions;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using UnityEngine;
using UnityEngine.UI;

namespace AstroClient.WorldModifications.WorldHacks
{

    internal class UdonBirdsSantuary : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.Udon_Bird_Santuary))
            {
                isCurrentWorld = true;
                SceneUtils.Set_Scene_RespawnHeightY(-150f); 
                PlayerCameraEditor.PlayerCamera.farClipPlane = 5000f;
                RenderSettings.fog = false;
                InstallSkybox();
                ExpandMoss();
                //ExpandWater();
                //MakeSceneryCollide();
                GetRidOftrash();
            }
            isCurrentWorld = false;
        }
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

        private static void ExpandMoss()
        {
            var MossyGround = Finder.Find("Mossy Ground");
            if (MossyGround != null)
            {
                var MossExpander = Finder.Find("Moss Expander");
                if (MossExpander == null)
                {
                    // make a primitive plane
                    MossExpander = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    MossExpander.name = "Moss Expander";
                }
                MossExpander.transform.position = new Vector3(0f, -1.238f, -1.23f);
                MossExpander.transform.localScale = MossExpander.transform.localScale.SetX(MossExpansion);
                MossExpander.transform.localScale = MossExpander.transform.localScale.SetZ(MossExpansion);
                // get both renderers
                var mossRenderer = MossyGround.GetComponent<MeshRenderer>();
                var planeRenderer = MossExpander.GetComponent<MeshRenderer>();
                // copy the material
                planeRenderer.material = mossRenderer.material;
                //MossyGround.SeparateMeshes(true);
                //MossyGround.transform.localScale = MossyGround.transform.localScale.SetX(MossExpander);
                //MossyGround.transform.localScale = MossyGround.transform.localScale.SetZ(MossExpander);

            }

        }
        //private static void ExpandWater()
        //{
        //    var Water = Finder.Find("Water");
        //    if (Water != null)
        //    {
        //        Water.SeparateMeshes(false);
        //        Water.transform.localScale = Water.transform.localScale.SetX(WaterExpander);
        //        Water.transform.localScale = Water.transform.localScale.SetZ(WaterExpander);

        //    }

        //}

        //private static string[] Scenery = new[]
        //{
        //    "TerrainTestHifi (1)",
        //    "TerrainTestHifi",
        //    "Terrain (ID_16228)/Terrain_ID_16228",
        //};
        //private static void MakeSceneryCollide()
        //{
        //    foreach(var scenery in Scenery)
        //    {
        //        var item = Finder.Find(scenery);
        //        if (item != null)
        //        {
        //            item.SeparateMeshes(true);

        //        }

        //    }

        //}



        private static float MossExpansion { get; } = 150f;
        private static float WaterExpander { get; } = 450f;

        private static bool isCurrentWorld{ get; set; }
    }
}