/* Note: This is also an issue with the official menu    */
/* Note: While loading a 400KiB string isn't really a    */
/*       problem, trying to render that to a texture is. */

namespace AstroClient.ClientUI.ActionMenuButtons.AvatarParametersModule.Menu {
    using AstroLibrary.Console;
    using Mono.WebBrowser;
    using UnityEngine;

    internal static class CameraUtils {
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
                        ModConsole.DebugLog("Failed to Generate a texture due to Camera being null;");
                    }
                    else
                    {
                        if (camera.targetTexture == null)
                        {
                            ModConsole.DebugLog("Failed to generate a texture due to Camera TargetTexture being null.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RenderTexture.active = currentRT;
                ModConsole.ErrorExc(e);
            }
            RenderTexture.active = currentRT;
            return result;
        }
    }
}
