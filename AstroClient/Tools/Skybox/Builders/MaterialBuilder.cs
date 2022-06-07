using AstroClient.ClientUI.Menu.RandomSubmenus;
using AstroClient.Tools.Skybox.CubemapTools;
using UnityEngine;

namespace AstroClient.Tools.Skybox.MaterialBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class MaterialBuilder
    {
        //internal static Material BuildCubemap(Texture2D PositiveX, Texture2D NegativeX, Texture2D PositiveY, Texture2D NegativeY, Texture2D PositiveZ, Texture2D NegativeZ)
        //{
        //    var reason = new StringBuilder();
        //    if (PositiveX == null) reason.AppendLine("PositiveX Texture is missing!");
        //    if (NegativeX == null) reason.AppendLine("NegativeX Texture is missing!");
        //    if (PositiveY == null) reason.AppendLine("PositiveY Texture is missing!");
        //    if (NegativeY == null) reason.AppendLine("NegativeY Texture is missing!");
        //    if (PositiveZ == null) reason.AppendLine("PositiveZ Texture is missing!");
        //    if (NegativeZ == null) reason.AppendLine("NegativeZ Texture is missing!");
        //    if (PositiveX == null || NegativeX == null || PositiveY == null || NegativeY == null || PositiveZ == null || NegativeZ == null)
        //    {
        //        Log.Debug("Failed Material Generation " + reason.ToString());
        //        reason.Clear();
        //        return null;
        //    }

        //    reason.Clear();
        //    var shader = Shader.Find("Skybox/Cubemap Extended");
        //    if (shader != null)
        //    {
        //        var GeneratedCube = CubeMapAndTexture2D.GenerateCubeMapFromTexture2D(PositiveX, NegativeX, PositiveY, NegativeY, PositiveZ, NegativeZ);
        //        if (GeneratedCube != null)
        //        {
        //            var result = new Material(shader);
        //            if (result != null)
        //            {
        //                result.SetPass(0);
        //                result.SetTexture("_Tex", GeneratedCube);
        //                result.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        //            }
        //            return result;
        //        }
        //    }

        //    return null;
        //}

        private static Material GetOriginalSkyboxMaterial()
        {
            if (SkyboxEditor.isUsingCustomSkybox)
            {
                if (SkyboxEditor.OriginalSkybox != null)
                {
                    return SkyboxEditor.OriginalSkybox;
                }
            }
            else
            {
                if (RenderSettings.skybox != null)
                {
                    return RenderSettings.skybox;
                }
            }
            return null;
        }

        internal static Material BuildSixSidedMaterial(Texture2D Up, Texture2D Down, Texture2D Back, Texture2D Front, Texture2D Left, Texture2D Right)
        {
            var reason = new StringBuilder();
            if (Up == null) reason.AppendLine("Up Texture is missing!");
            if (Down == null) reason.AppendLine("Down Texture is missing!");
            if (Back == null) reason.AppendLine("Back Texture is missing!");
            if (Front == null) reason.AppendLine("Front Texture is missing!");
            if (Left == null) reason.AppendLine("Left Texture is missing!");
            if (Right == null) reason.AppendLine("Right Texture is missing!");
            if (Up == null || Down == null || Back == null || Front == null || Left == null || Right == null)
            {
                Log.Debug("Failed Material Generation " + reason.ToString());
                reason.Clear();
                return null;
            }

            reason.Clear();
            var shader = Shader.Find("Skybox/6 Sided");
            if (shader != null)
            {
                var result = new Material(shader);
                if (result != null)
                {

                    if (SkyboxScrollMenu.ShouldCopyOriginalMatProperties)
                    {
                        var mat = GetOriginalSkyboxMaterial();
                        if (mat != null)
                        {
                            if (mat.shader.name == "Skybox/6 Sided")
                            {
                                Log.Debug("Detected the same shader in original skybox! Copying properties...");
                                result.CopyPropertiesFromMaterial(mat);
                            }
                            else
                            {
                                result.SetPass(0);
                            }
                        }
                        else
                        {
                            result.SetPass(0);
                        }
                    }
                    else
                    {
                        result.SetPass(0);
                    }
                    result.SetTexture("_UpTex", Up);
                    result.SetTexture("_DownTex", Down);
                    result.SetTexture("_BackTex", Back);
                    result.SetTexture("_FrontTex", Front);
                    result.SetTexture("_LeftTex", Left);
                    result.SetTexture("_RightTex", Right);
                    return result;
                }
            }

            return null;
        }

    }
}
