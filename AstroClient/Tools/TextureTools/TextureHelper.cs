using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AstroClient.Tools.TextureTools
{
    /// <summary>
    /// Helper class for working with <see cref="Texture2D"/>s, including some runtime-specific helpers and some general utility.
    /// </summary>
    internal static class TextureHelper
    {
        /// <summary>
        /// Helper for invoking Unity's <c>ImageConversion.EncodeToPNG</c> method.
        /// </summary>
        public static byte[] EncodeToPNG(Texture2D tex)
            => Il2CppTextureHelper.Internal_EncodeToPNG(tex);

        /// <summary>
        /// Helper for creating a new <see cref="Texture2D"/>.
        /// </summary>
        public static Texture2D NewTexture2D(int width, int height)
            => Il2CppTextureHelper.Internal_NewTexture2D(width, height);


        /// <summary>
        /// Helper for calling Unity's <see cref="Graphics.Blit"/> method.
        /// </summary>
        public static void Blit(Texture2D tex, RenderTexture rt)
            => Il2CppTextureHelper.Internal_Blit(tex, rt);


        /// <summary>
        /// Helper for creating a <see cref="Sprite" /> from the provided <paramref name="texture"/>.
        /// </summary>
        public static Sprite CreateSprite(Texture2D texture)
            => Il2CppTextureHelper.Internal_CreateSprite(texture);


        /// <summary>
        /// Helper for creating a <see cref="Sprite" /> from the provided <paramref name="texture"/>.
        /// </summary>
        public static void CreateSprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, Vector4 border)
            => Il2CppTextureHelper.Internal_CreateSprite(texture, rect, pivot, pixelsPerUnit, extrude, border);


        /// <summary>
        /// Helper for checking <c>Texture2D.isReadable</c>.
        /// </summary>
        public static bool IsReadable(Texture2D tex)
        {
            try
            {
                // This will cause an exception if it's not readable
                tex.GetPixel(0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a pixel copy of the provided <paramref name="orig"/>.
        /// </summary>
        public static Texture2D Copy(Texture2D orig) => Copy(orig, new(0, 0, orig.width, orig.height));

        /// <summary>
        /// Creates a pixel copy of the provided <paramref name="orig"/>, within the <paramref name="rect"/> dimensions.
        /// </summary>
        public static Texture2D Copy(Texture2D orig, Rect rect)
        {
            if (!IsReadable(orig))
                return ForceReadTexture(orig, rect);

            Texture2D newTex = Il2CppTextureHelper.Internal_NewTexture2D((int)rect.width, (int)rect.height);
            newTex.SetPixels(orig.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
            return newTex;
        }

        /// <summary>
        /// Copies the provided <paramref name="origTex"/> into a readable <see cref="Texture2D"/>.
        /// </summary>
        public static Texture2D ForceReadTexture<T>(T origTex, Rect dimensions = default) where T : Texture
        {
            try
            {
                if (dimensions == default)
                    dimensions = new(0, 0, origTex.width, origTex.height);

                FilterMode origFilter = origTex.filterMode;
                RenderTexture origRenderTexture = RenderTexture.active;

                origTex.filterMode = FilterMode.Point;

                RenderTexture rt = RenderTexture.GetTemporary(origTex.width, origTex.height, 0, RenderTextureFormat.ARGB32);
                rt.filterMode = FilterMode.Point;
                RenderTexture.active = rt;

                Il2CppTextureHelper.Internal_Blit(origTex, rt);

                Texture2D newTex = Il2CppTextureHelper.Internal_NewTexture2D((int)dimensions.width, (int)dimensions.height);
                newTex.ReadPixels(dimensions, 0, 0);
                newTex.Apply(false, false);

                RenderTexture.active = origRenderTexture;
                origTex.filterMode = origFilter;

                return newTex;
            }
            catch (Exception e)
            {
                Log.Error($"Exception on ForceReadTexture:");
                Log.Exception(e);
                return default;
            }
        }
        /// <summary>
        /// Saves the provided <paramref name="tex"/> as a PNG file, into the provided <paramref name="dir"/> as "<paramref name="name"/>.png"
        /// </summary>
        public static void SaveTextureAsPNG(Texture tex, string dir, string name)
        {
            var converted = ForceReadTexture(tex);
            byte[] data = Il2CppTextureHelper.Internal_EncodeToPNG(converted);

            if (data == null || !data.Any())
                throw new Exception("The data from calling EncodeToPNG on the provided Texture was null or empty.");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllBytes(Path.Combine(dir, $"{name}.png"), data);
        }


        /// <summary>
        /// Saves the provided <paramref name="tex"/> as a PNG file, into the provided <paramref name="dir"/> as "<paramref name="name"/>.png"
        /// </summary>
        public static void SaveTextureAsPNG(Texture2D tex, string dir, string name)
        {
            if (tex.format != TextureFormat.ARGB32 || !IsReadable(tex))
                tex = ForceReadTexture(tex);

            byte[] data = Il2CppTextureHelper.Internal_EncodeToPNG(tex);

            if (data == null || !data.Any())
                throw new Exception("The data from calling EncodeToPNG on the provided Texture was null or empty.");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllBytes(Path.Combine(dir, $"{name}.png"), data);
        }




    }
}
