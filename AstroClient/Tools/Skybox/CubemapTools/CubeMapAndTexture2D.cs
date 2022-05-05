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

        internal static IEnumerator SaveCubemapToFile(Cubemap cubemap, string path)
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
                    Texture2D newTex = new Texture2D(cubemap.width, cubemap.height, cubemap.format, false);
                    newTex.filterMode = FilterMode.Point;
                    Log.Debug($"Generating Texture of {face}");
                    Graphics.CopyTexture(cubemap, (int)face, 0, newTex, 0, 0);
                    Log.Debug("Saving Texture...");


                    Log.Debug($"Saved {cubemap.name} {face.ToString()}");
                    byte[] data = Il2CppTextureHelper.Internal_EncodeToPNG(newTex);

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    File.WriteAllBytes(imagepath, data);


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
                    UnityEngine.Object.Destroy(newTex);

                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
            }
            yield return null;
        }
    }
}
