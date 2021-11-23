﻿namespace AstroClient.Tools.Extensions
{
    using System;
    using UnityEngine;

    internal static class Texture_Ext
    {


        public static Texture CreateReadableCopy(this Texture tex)
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
                RenderTexture.ReleaseTemporary(rt);

                return _newTex;
            }
            catch (Exception e)
            {
                RenderTexture.active = currentRT;
                ModConsole.ErrorExc(e);
                return default;
            }
        }


        public static Texture2D ToTexture2D(this Texture tex)
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
                RenderTexture.ReleaseTemporary(rt);

                return _newTex;
            }
            catch (Exception e)
            {
                RenderTexture.active = currentRT;
                ModConsole.ErrorExc(e);
                return default;
            }
        }
        //internal static Texture2D ToTexture2D(this Texture Texture)
        //{
        //    RenderTexture currentRT = RenderTexture.active;

        //    try
        //    {
        //        Texture mainTexture = Texture;
        //        Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        //        RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
        //        RenderTexture.active = renderTexture;
        //        Graphics.Blit(mainTexture, renderTexture);
        //        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        //        texture2D.Apply();
        //        RenderTexture.active = currentRT;
        //        return texture2D;
        //    }
        //    catch (Exception e)
        //    {
        //        RenderTexture.active = currentRT;
        //        ModConsole.ErrorExc(e);
        //    }
        //    RenderTexture.active = currentRT;
        //    return null;
        //}

        internal static Texture2D GetTexture2DByCubeMap(this Cubemap cubemap)
        {
            int everyW = cubemap.width;
            int everyH = cubemap.height;

            Texture2D texture2D = new Texture2D(everyW * 4, everyH * 3);
            texture2D.SetPixels(everyW, 0, everyW, everyH, cubemap.GetPixels(CubemapFace.PositiveY));
            texture2D.SetPixels(0, everyH, everyW, everyH, cubemap.GetPixels(CubemapFace.NegativeX));
            texture2D.SetPixels(everyW, everyH, everyW, everyH, cubemap.GetPixels(CubemapFace.PositiveZ));
            texture2D.SetPixels(2 * everyW, everyH, everyW, everyH, cubemap.GetPixels(CubemapFace.PositiveX));
            texture2D.SetPixels(3 * everyW, everyH, everyW, everyH, cubemap.GetPixels(CubemapFace.NegativeZ));
            texture2D.SetPixels(everyW, 2 * everyH, everyW, everyH, cubemap.GetPixels(CubemapFace.NegativeY));
            texture2D.Apply();
            texture2D = FlipPixels(texture2D, false, true);
            return texture2D;
        }


        internal static Texture2D FlipPixels(this Texture2D texture, bool flipX, bool flipY)
        {
            if (!flipX && !flipY)
            {
                return texture;
            }
            if (flipX)
            {
                for (int i = 0; i < texture.width / 2; i++)
                {
                    for (int j = 0; j < texture.height; j++)
                    {
                        Color tempC = texture.GetPixel(i, j);
                        texture.SetPixel(i, j, texture.GetPixel(texture.width - 1 - i, j));
                        texture.SetPixel(texture.width - 1 - i, j, tempC);
                    }
                }
            }
            if (flipY)
            {
                for (int i = 0; i < texture.width; i++)
                {
                    for (int j = 0; j < texture.height / 2; j++)
                    {
                        Color tempC = texture.GetPixel(i, j);
                        texture.SetPixel(i, j, texture.GetPixel(i, texture.height - 1 - j));
                        texture.SetPixel(i, texture.height - 1 - j, tempC);
                    }
                }
            }
            texture.Apply();
            return texture;
        }

    }
}
