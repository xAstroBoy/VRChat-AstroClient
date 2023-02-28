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

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

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
                FixMoss();
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

        private static void FixMoss()
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
                MossExpander.transform.localScale = MossExpander.transform.localScale.SetX(MossExpanderExpansion);
                MossExpander.transform.localScale = MossExpander.transform.localScale.SetZ(MossExpanderExpansion);
                // get both renderers
                var mossRenderer = MossyGround.GetComponent<MeshRenderer>();
                var planeRenderer = MossExpander.GetComponent<MeshRenderer>();
                // copy the material
                planeRenderer.material = mossRenderer.material;

            }

        }




        private static float MossExpanderExpansion { get; } = 150f;

        private static bool isCurrentWorld{ get; set; }
    }
}