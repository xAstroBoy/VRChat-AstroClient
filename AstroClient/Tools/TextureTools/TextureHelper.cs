using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AstroClient.Tools.TextureTools
{
    /// <summary>
    /// Helper class for working with <see cref="Texture2D"/>s, including some runtime-specific helpers and some general utility.
    /// </summary>
    internal class TextureHelper
    {
        /// <summary>
        /// Returns true if it is possible to force-read non-readable Cubemaps in this game.
        /// </summary>
        public static bool CanForceReadCubemaps => true;

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
        /// Helper for creating a new <see cref="Texture2D"/>.
        /// </summary>
        public static Texture2D NewTexture2D(int width, int height, TextureFormat textureFormat, bool mipChain)
            => Il2CppTextureHelper.Internal_NewTexture2D(width, height, textureFormat, mipChain);

        /// <summary>
        /// Helper for calling Unity's <see cref="Graphics.Blit"/> method.
        /// </summary>
        public static void Blit(Texture tex, RenderTexture rt)
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
        /// Helper for checking <c>Cubemap.isReadable</c>.
        /// </summary>
        public static bool IsReadable(Cubemap tex)
        {
            try
            {
                // This will cause an exception if it's not readable
                tex.GetPixel(CubemapFace.PositiveX, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Copies the provided <paramref name="source"/> into a readable <see cref="Texture2D"/>.
        /// <br/> Supports <see cref="Texture2D"/> and individual <see cref="Cubemap"/> faces.
        /// </summary>
        /// <param name="source">The original Texture to copy from.</param>
        /// <param name="dimensions">Optional dimensions to use from the original Texture. If set to default, uses the entire original.</param>
        /// <param name="cubemapFace">If copying a Cubemap, set this to the desired face index from 0 to 5.</param>
        /// <param name="dstX">Optional destination starting X value.</param>
        /// <param name="dstY">Optional destination starting Y value.</param>
        /// <returns>A new Texture2D, copied from the <paramref name="source"/>.</returns>
        public static Texture2D CopyTexture(Texture source, Rect dimensions = default, int cubemapFace = 0, int dstX = 0, int dstY = 0)
        {
            TextureFormat format = TextureFormat.ARGB32;
            if (source.TryCast<Texture2D>() is Texture2D tex2D)
                format = tex2D.format;
            else if (source.TryCast<Cubemap>() is Cubemap cmap)
                format = cmap.format;

            Texture2D newTex = NewTexture2D((int)dimensions.width, (int)dimensions.height, format, false);
            newTex.filterMode = FilterMode.Point;

            return CopyTexture(source, newTex, dimensions, cubemapFace, dstX, dstY);
        }

        /// Copies the provided <paramref name="source"/> into the <paramref name="destination"/> Texture.
        /// <br/><br/>Supports <see cref="Texture2D"/> and individual <see cref="Cubemap"/> faces.
        /// </summary>
        /// <param name="source">The original Texture to copy from.</param>
        /// <param name="destination">The destination Texture to copy into.</param>
        /// <param name="dimensions">Optional dimensions to use from the original Texture. If set to default, uses the entire original.</param>
        /// <param name="cubemapFace">If copying a Cubemap, set this to the desired face index from 0 to 5.</param>
        /// <param name="dstX">Optional destination starting X value.</param>
        /// <param name="dstY">Optional destination starting Y value.</param>
        /// <returns>The <paramref name="destination"/> Texture, copied from the <paramref name="source"/>.</returns>
        public static Texture2D CopyTexture(Texture source, Texture2D destination,
            Rect dimensions = default, int cubemapFace = 0, int dstX = 0, int dstY = 0)
        {
            try
            {
                if (source.TryCast<Texture2D>() == null && source.TryCast<Cubemap>() == null)
                    throw new NotImplementedException($"TextureHelper.Copy does not support Textures of type '{source.GetIl2CppType().FullName}'.");

                if (dimensions == default)
                    dimensions = new(0, 0, source.width, source.height);

                if (source.TryCast<Texture2D>() is Texture2D texture2D)
                {
                    return CopyToARGB32(texture2D, dimensions, dstX, dstY);
                }
                else
                {
                    Il2CppTextureHelper.Internal_CopyTexture(source, cubemapFace, 0, 0, 0, source.width, source.height, destination, 0, 0, dstX, dstY);
                    return destination;
                }
            }
            catch (Exception e)
            {
                Log.Error($"Failed to force-copy Texture");
                Log.Exception(e);
                return default;
            }
        }

        /// <summary>
        /// Unwraps the Cubemap into a Texture2D, showing the the X faces on the left, Y in the middle and Z on the right,
        /// with positive faces on the top row and negative on the bottom.
        /// </summary>
        public static Texture2D UnwrapCubemap(Cubemap cubemap)
        {
            if (!IsReadable(cubemap) && !Il2CppTextureHelper.Internal_CanForceReadCubemaps)
                throw new NotSupportedException("Unable to force-read non-readable Cubemaps in this game.");

            Texture2D newTex = NewTexture2D(cubemap.width * 3, cubemap.height * 2, cubemap.format, false);

            for (int i = 0; i < 6; i++)
            {
                int x = i % 3 * cubemap.width;
                int y = i % 2 * cubemap.height;

                // Using the Graphics.CopyTexture method is faster then SetPixels(GetPixels())
                if (Il2CppTextureHelper.Internal_CanForceReadCubemaps)
                    CopyTexture(cubemap, newTex, default, i, x, y);
                else
                    newTex.SetPixels(x, y, cubemap.width, cubemap.height, cubemap.GetPixels((CubemapFace)i));
            }

            return newTex;
        }

        /// <summary>
        /// Converts the <paramref name="origTex"/> into a readable <see cref="TextureFormat.ARGB32"/>-format <see cref="Texture2D"/>.
        /// <br /><br />Supports non-readable Textures.
        /// </summary>
        public static Texture2D CopyToARGB32(Texture2D origTex, Rect dimensions = default, int dstX = 0, int dstY = 0)
        {
            if (dimensions == default && origTex.format == TextureFormat.ARGB32 && IsReadable(origTex))
                return origTex;

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
            newTex.ReadPixels(dimensions, dstX, dstY);
            newTex.Apply(false, false);

            RenderTexture.active = origRenderTexture;
            origTex.filterMode = origFilter;

            return newTex;
        }


        /// <summary>
        /// Converts the <paramref name="origTex"/> into a readable <see cref="TextureFormat.ARGB32"/>-format <see cref="Texture2D"/>.
        /// <br /><br />Supports non-readable Textures.
        /// </summary>
        public static Texture2D CopyToARGB32CubeMap(Texture2D origTex, Rect dimensions = default, int dstX = 0, int dstY = 0,int Width = 0, int Height = 0)
        {
            if (dimensions == default && origTex.format == TextureFormat.ARGB32 && IsReadable(origTex))
                return origTex;

            if (dimensions == default)
                dimensions = new(0, 0, origTex.width, origTex.height);

            FilterMode origFilter = origTex.filterMode;
            RenderTexture origRenderTexture = RenderTexture.active;

            origTex.filterMode = FilterMode.Point;

            RenderTexture rt = RenderTexture.GetTemporary(Width, Height, 0, RenderTextureFormat.ARGB32);
            rt.filterMode = FilterMode.Point;
            RenderTexture.active = rt;

            Il2CppTextureHelper.Internal_Blit(origTex, rt);

            Texture2D newTex = Il2CppTextureHelper.Internal_NewTexture2D((int)dimensions.width, (int)dimensions.height);
            newTex.ReadPixels(dimensions, dstX, dstY);
            newTex.Apply(false, false);

            RenderTexture.active = origRenderTexture;
            origTex.filterMode = origFilter;

            return newTex;
        }

        /// <summary>
        /// Saves the provided <paramref name="tex"/> as a PNG file, into the provided <paramref name="dir"/> as "<paramref name="name"/>.png".
        /// <br /><br />To save a <see cref="Cubemap"/>, use <see cref="Copy"/> for each face,
        /// using the <c>cubemapFace</c> parameter to select the face.
        /// </summary>
        public static void SaveTextureAsPNG(Texture tex, string dir, string name)
            => SaveTextureAsPNG(tex, Path.Combine(dir, name));


        /// <summary>
        /// Saves the provided <paramref name="tex"/> as a PNG file, into the provided <paramref name="dir"/> as "<paramref name="name"/>.png".
        /// <br /><br />To save a <see cref="Cubemap"/>, use <see cref="Copy"/> for each face,
        /// using the <c>cubemapFace</c> parameter to select the face.
        /// </summary>
        public static void SaveTextureAsPNG(Texture2D tex, string dir, string name)
            => SaveTextureAsPNG(tex, Path.Combine(dir, name));

        /// <summary>
        /// Saves the provided <paramref name="texture"/> as a PNG file to the provided path.
        /// <br /><br />To save a <see cref="Cubemap"/>, use <see cref="Copy"/> for each face,
        /// using the <c>cubemapFace</c> parameter to select the face, and save each resulting Texture2D.
        /// </summary>
        public static void SaveTextureAsPNG(Texture2D texture, string fullPathWithFilename)
        {
            Texture2D tex = texture;

            if (!IsReadable(texture) || texture.format != TextureFormat.ARGB32)
                tex = CopyToARGB32(texture);

            byte[] data = Il2CppTextureHelper.Internal_EncodeToPNG(tex);

            if (data == null || !data.Any())
                throw new Exception("The data from calling EncodeToPNG on the provided Texture was null or empty.");

            string dir = Path.GetDirectoryName(fullPathWithFilename);
            string name = Path.GetFileNameWithoutExtension(fullPathWithFilename);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllBytes(Path.Combine(dir, $"{name}.png"), data);

            if (tex != texture)
            {
                UnityEngine.Object.Destroy(tex);
            }
        }
        /// <summary>
        /// Saves the provided <paramref name="texture"/> as a PNG file to the provided path.
        /// <br /><br />To save a <see cref="Cubemap"/>, use <see cref="Copy"/> for each face,
        /// using the <c>cubemapFace</c> parameter to select the face, and save each resulting Texture2D.
        /// </summary>
        public static void SaveTextureAsPNG(Texture texture, string fullPathWithFilename)
        {
            var converted = ForceReadTexture(texture);
            byte[] data = Il2CppTextureHelper.Internal_EncodeToPNG(converted);
            if (data == null || !data.Any())
                throw new Exception("The data from calling EncodeToPNG on the provided Texture was null or empty.");

            string dir = Path.GetDirectoryName(fullPathWithFilename);
            string name = Path.GetFileNameWithoutExtension(fullPathWithFilename);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllBytes(Path.Combine(dir, $"{name}.png"), data);
        }

        public static Texture2D ForceReadTexture(Texture2D origTex, Rect dimensions = default)
            => Copy(origTex, dimensions);

        public static Texture2D Copy(Texture2D orig)
            => Copy(orig, new(0, 0, orig.width, orig.height));

        public static Texture2D Copy(Texture2D orig, Rect rect)
            => CopyTexture(orig, rect, 0, 0, 0);

        public static Texture2D ForceReadTexture(Texture origTex, Rect dimensions = default)
    => Copy(origTex, dimensions);

        public static Texture2D Copy(Texture orig)
            => Copy(orig, new(0, 0, orig.width, orig.height));

        public static Texture2D Copy(Texture orig, Rect rect)
            => CopyTexture(orig, rect, 0, 0, 0);
    }
}