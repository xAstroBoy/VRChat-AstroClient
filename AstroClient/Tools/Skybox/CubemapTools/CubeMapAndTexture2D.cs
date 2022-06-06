using System.Collections;
using System.Drawing;
using System.Text;
using AstroClient.Tools.Skybox.SkyboxClasses;
using AstroClient.Tools.TextureTools;
using UnityEngine.Experimental.Rendering;

namespace AstroClient.Tools.Skybox.CubemapTools
{
    using System;
    using System.IO;
    using UnityEngine;

    public static class CubeMapAndTexture2D
    {
        private static Texture2D CorrectTextureFormat(Texture2D tex)
        {
            if (tex.format != TextureFormat.ARGB32)
            {
                return TextureHelper.CopyToARGB32CubeMap(tex);
            }
            return tex;
        }

        internal static void SaveCubemapToFile(Texture cubemap, string path)
        {

            CubemapFace[] faces = new CubemapFace[] {
                CubemapFace.PositiveX, CubemapFace.NegativeX,
                CubemapFace.PositiveY, CubemapFace.NegativeY,
                CubemapFace.PositiveZ, CubemapFace.NegativeZ };

            foreach (CubemapFace face in faces)
            {
                try
                {
                    var imagepath = Path.Combine(path, $"{face.ToString()}.png");
                    Log.Debug($"Generating Texture of {face}");
                    var newTex = TextureHelper.CopyTexture(cubemap, new Rect(0, 0, cubemap.width, cubemap.height), (int)face);
                    if (newTex != null)
                    {
                        TextureHelper.SaveTextureAsPNG(newTex, imagepath);
                        UnityEngine.Object.Destroy(newTex);
                    }
                    if (File.Exists(imagepath))
                    {
                        switch (face)
                        {
                            case CubemapFace.NegativeX:
                            case CubemapFace.PositiveX:
                            case CubemapFace.NegativeZ:
                            case CubemapFace.PositiveZ:
                                Bitmap bitmap1 = (Bitmap)Bitmap.FromFile(imagepath);
                                bitmap1.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                bitmap1.Save(imagepath);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
            }
        }
    }
}
