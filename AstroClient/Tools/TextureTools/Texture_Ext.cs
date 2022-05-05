using UnityEngine;

namespace AstroClient.Tools.TextureTools
{
    internal static class TextureTools
    {


        internal static Texture2D ForceReadTexture(this Texture2D tex)
        {
            return TextureHelper.ForceReadTexture(tex);
        }
        internal static Texture2D ForceReadTexture(this UnityEngine.Texture Texture)
        {
            return Texture.Cast<Texture2D>().ForceReadTexture();
        }

        internal static void SaveTextureAsPNG(this UnityEngine.Texture texture, string dir, string name)
        {
            TextureHelper.SaveTextureAsPNG(texture, dir, name);
        }

        internal static void SaveTextureAsPNG(this Texture2D tex, string dir, string name)
        {
            TextureHelper.SaveTextureAsPNG(tex, dir, name);
        }


    }
}