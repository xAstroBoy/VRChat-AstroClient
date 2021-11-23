﻿namespace AstroClient.Tools.Extensions
{
    using System;
    using System.IO;
    using System.Linq;
    using UnityEngine;

    internal static class TextureTools
    {

        internal static bool IsReadable(Texture2D tex)
        {
            try
            {
                // This will cause an exception if it's not readable.
                // Reason for doing it this way is not all Unity versions
                // ship with the 'Texture.isReadable' property.

                tex.GetPixel(0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public static bool LoadImage(Texture2D tex, string filePath, bool markNonReadable)
        //{
        //    if (!File.Exists(filePath))
        //        return false;
        //
        //    return Instance.LoadImage(tex, File.ReadAllBytes(filePath), markNonReadable);
        //}

        internal static Texture2D Copy(Texture2D orig, Rect rect)
        {
            if (!IsReadable(orig))
                orig = ForceReadTexture(orig);

            Color[] pixels = orig.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
            Texture2D newTex = new Texture2D((int)rect.width, (int)rect.height);
            newTex.SetPixels(pixels);
            return newTex;
        }

        internal static Texture2D ForceReadTexture(this Texture2D tex)
        {
            RenderTexture currentRT = RenderTexture.active;

            try
            {
                FilterMode origFilter = tex.filterMode;
                tex.filterMode = FilterMode.Point;

                var rt = RenderTexture.GetTemporary(tex.width, tex.height, 0, RenderTextureFormat.ARGB32);
                rt.filterMode = FilterMode.Point;
                RenderTexture.active = rt;

                Graphics.Blit(tex, rt);

                var _newTex = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);

                _newTex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
                _newTex.Apply(false, false);

                tex.filterMode = origFilter;

                RenderTexture.active = currentRT;
                return _newTex;
            }
            catch (Exception e)
            {
                RenderTexture.active = currentRT;
                ModConsole.Error($"Exception on ForceReadTexture: {e.ToString()}");
                return default;
            }
        }
        internal static Texture2D ToTexture2D(this Texture Texture)
        {
            RenderTexture currentRT = RenderTexture.active;
            try
            {
                Texture mainTexture = Texture;
                Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
                RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
                RenderTexture.active = renderTexture;
                Graphics.Blit(mainTexture, renderTexture);
                texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                texture2D.Apply();
                RenderTexture.active = currentRT;
                texture2D.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                return texture2D;
            }
            catch (Exception e)
            {
                RenderTexture.active = currentRT;
                ModConsole.ErrorExc(e);
            }
            RenderTexture.active = currentRT;
            return null;
        }

        internal static void SaveTextureAsPNG(Texture texture, string dir, string name, bool isDTXnmNormal = false)
        {
            SaveTextureAsPNG(texture.ToTexture2D(), dir, name, isDTXnmNormal);
        }

        internal static void SaveTextureAsPNG(Texture2D tex, string dir, string name, bool isDTXnmNormal = false)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            byte[] data;
            string savepath = $@"{dir}\{name}.png";

            // Make sure we can EncodeToPNG it.
            if (tex.format != TextureFormat.ARGB32 || !IsReadable(tex))
                tex = ForceReadTexture(tex);

            if (isDTXnmNormal)
            {
                tex = DTXnmToRGBA(tex);
                tex.Apply(false, false);
            }

            data = ImageConversion.EncodeToPNG(tex);

            if (data == null || !data.Any())
                ModConsole.Error("Couldn't get any data for the texture!");
            else
                File.WriteAllBytes(savepath, data);
            ModConsole.DebugLog("Exported Texture in Path: " + savepath);
        }

        // Converts DTXnm-format Normal Map to RGBA-format Normal Map.
        internal static Texture2D DTXnmToRGBA(Texture2D tex)
        {
            Color[] colors = tex.GetPixels();

            for (int i = 0; i < colors.Length; i++)
            {
                var c = colors[i];

                c.r = c.a * 2 - 1;  // red <- alpha
                c.g = c.g * 2 - 1;  // green is always the same

                var rg = new Vector2(c.r, c.g); //this is the red-green vector
                c.b = Mathf.Sqrt(1 - Mathf.Clamp01(Vector2.Dot(rg, rg))); //recalculate the blue channel

                colors[i] = new Color(
                    (c.r * 0.5f) + 0.5f,
                    (c.g * 0.5f) + 0.25f,
                    (c.b * 0.5f) + 0.5f
                );
            }

            var newtex = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
            newtex.SetPixels(colors);

            return newtex;
        }
    }
}