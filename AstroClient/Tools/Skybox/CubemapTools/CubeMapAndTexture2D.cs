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

        internal static void SaveCubemapToFile(Texture cubemap, string path)
        {

            CubemapFace[] faces = new CubemapFace[] {
                CubemapFace.PositiveX, CubemapFace.NegativeX,
                CubemapFace.PositiveY, CubemapFace.NegativeY,
                CubemapFace.PositiveZ, CubemapFace.NegativeZ };
            bool isNegativeX = false;
            bool isPositiveX = false;

            foreach (CubemapFace face in faces)
            {
                try
                {
                    string filename = $"{face.ToString()}.png";
                    // Swapping Positive X & NegativeX names due to cubemaps being weird af when loaded.
                    if(face == CubemapFace.PositiveX)
                    {
                        filename = $"{CubemapFace.NegativeX.ToString()}.png";
                    }
                    if (face == CubemapFace.NegativeX)
                    {
                        filename = $"{CubemapFace.PositiveX.ToString()}.png"; 
                    }

                    string imagepath = Path.Combine(path,filename);
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
                                Rotate(imagepath);
                                break;

                            case CubemapFace.PositiveX:
                                Rotate(imagepath);
                                break;

                            case CubemapFace.NegativeZ:
                                Rotate(imagepath);
                                break;

                            case CubemapFace.PositiveZ:
                                Rotate(imagepath);
                                break;
                            default:
                                break;
                        }
                    }

                    void Rotate(string path)
                    {
                        Bitmap bitmap1 = (Bitmap)Bitmap.FromFile(path);
                        bitmap1.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap1.Save(path);

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
