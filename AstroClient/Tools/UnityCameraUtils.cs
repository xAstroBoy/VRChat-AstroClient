using System.Drawing;
using System.IO;
using Mono.WebBrowser;
using UnityEngine;

namespace AstroClient.Tools {
    internal static class UnityCameraUtils {
        internal static Texture2D ToTexture2D(this UnityEngine.Camera camera, string texturename)
        {
            var currentRT = RenderTexture.active;
            Texture2D result = null;
            try
            {
                if (camera != null && camera.targetTexture != null)
                {
                    RenderTexture.active = camera.targetTexture;
                    camera.Render();

                    var width = camera.targetTexture.width;
                    var height = camera.targetTexture.height;
                    result = new Texture2D(width, height, TextureFormat.RGBA32, false, true);
                    result.name = texturename;
                    result.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
                    result.Apply();
                    RenderTexture.active = currentRT;
                }
                else
                {

                    if (camera == null)
                    {
                        Log.Debug("Failed to Generate a texture due to Camera being null;");
                    }
                    else
                    {
                        if (camera.targetTexture == null)
                        {
                            Log.Debug("Failed to generate a texture due to Camera TargetTexture being null.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RenderTexture.active = currentRT;
                Log.Exception(e);
            }
            RenderTexture.active = currentRT;
            return result;
        }

        internal static Texture2D toTexture2D(this RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
            var old_rt = RenderTexture.active;
            RenderTexture.active = rTex;

            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();

            RenderTexture.active = old_rt;
            return tex;
        }

        internal static Bitmap ToBitMap(this UnityEngine.Camera camera)
        {
            var texture = camera.activeTexture.toTexture2D();
            byte[] buffer = ImageConversion.EncodeToPNG(texture);
            Object.Destroy(texture);
            Bitmap bitmap;
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                bitmap = new Bitmap(stream);
            }
            return bitmap;
        }
    }
}
