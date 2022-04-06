namespace AstroClient.Tools.Skybox.CubemapTools
{
    using System;
    using System.IO;
    using UnityEngine;

    public static class CubeMapAndTexture2D
    {
        /// <summary>
        /// Use 6 plane map to get Cubemap
        /// </summary>
        /// <param name="tempTex"></param>
        /// <returns></returns>
        public static Cubemap GetCubeMapByCubeTexture2D(Texture2D tempTex)
        {
            tempTex = FlipPixels(tempTex, false, true);
            int everyW = (int)(tempTex.width / 4f);
            int everyH = (int)(tempTex.height / 3f);
            int cubeMapSize = Mathf.Min(everyW, everyH);

            Cubemap cubemap = new Cubemap(cubeMapSize, TextureFormat.RGB24, false);
            cubemap.SetPixels(tempTex.GetPixels(cubeMapSize, 0, cubeMapSize, cubeMapSize), CubemapFace.PositiveY);
            cubemap.SetPixels(tempTex.GetPixels(0, cubeMapSize, cubeMapSize, cubeMapSize), CubemapFace.NegativeX);
            cubemap.SetPixels(tempTex.GetPixels(cubeMapSize, cubeMapSize, cubeMapSize, cubeMapSize), CubemapFace.PositiveZ);
            cubemap.SetPixels(tempTex.GetPixels(2 * cubeMapSize, cubeMapSize, cubeMapSize, cubeMapSize), CubemapFace.PositiveX);
            cubemap.SetPixels(tempTex.GetPixels(3 * cubeMapSize, cubeMapSize, cubeMapSize, cubeMapSize), CubemapFace.NegativeZ);
            cubemap.SetPixels(tempTex.GetPixels(cubeMapSize, 2 * cubeMapSize, cubeMapSize, cubeMapSize), CubemapFace.NegativeY);
            cubemap.Apply();
            return cubemap;
        }

        /// <summary>
        ///  Get Cubemap with panorado panorama
        /// </summary>
        /// <param name="tempTex"></param>
        /// <returns></returns>
        public static Cubemap GetCubeMapByPanoradoTexture2D(Texture2D tempTex)
        {
            int everyW = (int)(tempTex.width / 4f);
            int everyH = (int)(tempTex.height / 3f);
            int cubeMapSize = Mathf.Min(everyW, everyH);

            Cubemap cubemap = new Cubemap(cubeMapSize, TextureFormat.RGB24, false);
            cubemap.SetPixels(CreateCubemapTexture(tempTex, cubeMapSize, 0).GetPixels(), CubemapFace.PositiveZ);
            cubemap.SetPixels(CreateCubemapTexture(tempTex, cubeMapSize, 1).GetPixels(), CubemapFace.NegativeZ);
            cubemap.SetPixels(CreateCubemapTexture(tempTex, cubeMapSize, 2).GetPixels(), CubemapFace.NegativeX);
            cubemap.SetPixels(CreateCubemapTexture(tempTex, cubeMapSize, 3).GetPixels(), CubemapFace.PositiveX);
            cubemap.SetPixels(CreateCubemapTexture(tempTex, cubeMapSize, 4).GetPixels(), CubemapFace.PositiveY);
            cubemap.SetPixels(CreateCubemapTexture(tempTex, cubeMapSize, 5).GetPixels(), CubemapFace.NegativeY);
            cubemap.Apply();
            return cubemap;
        }

        static Texture2D CreateCubemapTexture(Texture2D m_srcTexture, int texSize, int faceIndex, string fileName = null)
        {
            Texture2D tex = new Texture2D(texSize, texSize, TextureFormat.RGB24, false);

            Vector3[] vDirA = new Vector3[4];
            if (faceIndex == 0)
            {
                vDirA[0] = new Vector3(-1.0f, -1.0f, -1.0f);
                vDirA[1] = new Vector3(1.0f, -1.0f, -1.0f);
                vDirA[2] = new Vector3(-1.0f, 1.0f, -1.0f);
                vDirA[3] = new Vector3(1.0f, 1.0f, -1.0f);
            }

            if (faceIndex == 1)
            {
                vDirA[0] = new Vector3(1.0f, -1.0f, 1.0f);
                vDirA[1] = new Vector3(-1.0f, -1.0f, 1.0f);
                vDirA[2] = new Vector3(1.0f, 1.0f, 1.0f);
                vDirA[3] = new Vector3(-1.0f, 1.0f, 1.0f);
            }

            if (faceIndex == 2)
            {
                vDirA[0] = new Vector3(1.0f, -1.0f, -1.0f);
                vDirA[1] = new Vector3(1.0f, -1.0f, 1.0f);
                vDirA[2] = new Vector3(1.0f, 1.0f, -1.0f);
                vDirA[3] = new Vector3(1.0f, 1.0f, 1.0f);
            }

            if (faceIndex == 3)
            {
                vDirA[0] = new Vector3(-1.0f, -1.0f, 1.0f);
                vDirA[1] = new Vector3(-1.0f, -1.0f, -1.0f);
                vDirA[2] = new Vector3(-1.0f, 1.0f, 1.0f);
                vDirA[3] = new Vector3(-1.0f, 1.0f, -1.0f);
            }

            if (faceIndex == 4)
            {
                vDirA[0] = new Vector3(-1.0f, 1.0f, -1.0f);
                vDirA[1] = new Vector3(1.0f, 1.0f, -1.0f);
                vDirA[2] = new Vector3(-1.0f, 1.0f, 1.0f);
                vDirA[3] = new Vector3(1.0f, 1.0f, 1.0f);
            }

            if (faceIndex == 5)
            {
                vDirA[0] = new Vector3(-1.0f, -1.0f, 1.0f);
                vDirA[1] = new Vector3(1.0f, -1.0f, 1.0f);
                vDirA[2] = new Vector3(-1.0f, -1.0f, -1.0f);
                vDirA[3] = new Vector3(1.0f, -1.0f, -1.0f);
            }

            Vector3 rotDX1 = (vDirA[1] - vDirA[0]) / (float)texSize;
            Vector3 rotDX2 = (vDirA[3] - vDirA[2]) / (float)texSize;

            float dy = 1.0f / (float)texSize;
            float fy = 0.0f;

            Color[] cols = new Color[texSize];
            for (int y = 0; y < texSize; y++)
            {
                Vector3 xv1 = vDirA[0];
                Vector3 xv2 = vDirA[2];
                for (int x = 0; x < texSize; x++)
                {
                    Vector3 v = ((xv2 - xv1) * fy) + xv1;
                    v.Normalize();
                    cols[x] = CalcProjectionSpherical(m_srcTexture, v);
                    xv1 += rotDX1;
                    xv2 += rotDX2;
                }

                tex.SetPixels(0, y, texSize, 1, cols);
                fy += dy;
            }

            tex.wrapMode = TextureWrapMode.Clamp; //  In the case of Cubemap, if you are not clamp on WrapMode, you will see the boundary.
            tex.Apply();
            tex = FlipPixels(tex, true, true);
            return tex;
        }

        internal static Color CalcProjectionSpherical(Texture2D m_srcTexture, Vector3 vDir)
        {
            float theta = Mathf.Atan2(vDir.z, vDir.x); //  -π ~ + π (rotated in the horizontal direction).
            float phi = Mathf.Acos(vDir.y); //    0 ~ + π (rotated in the vertical direction).

            float PI = Convert.ToSingle(System.Math.PI);
            while (theta < -System.Math.PI) theta += PI + PI;
            while (theta > System.Math.PI) theta -= PI + PI;

            float dx = theta / PI; // -1.0 ～ +1.0.
            float dy = phi / PI; //  0.0 ～ +1.0.

            dx = dx * 0.5f + 0.5f;
            int px = (int)(dx * (float)m_srcTexture.width);
            if (px < 0) px = 0;
            if (px >= m_srcTexture.width) px = m_srcTexture.width - 1;
            int py = (int)(dy * (float)m_srcTexture.height);
            if (py < 0) py = 0;
            if (py >= m_srcTexture.height) py = m_srcTexture.height - 1;

            Color col = m_srcTexture.GetPixel(px, m_srcTexture.height - py - 1);
            return col;
        }

        /// <summary>
        ///  Horizontal / vertical reverse postup
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="flipX"></param>
        /// <param name="flipY"></param>
        /// <returns></returns>
        public static Texture2D FlipPixels(Texture2D texture, bool flipX, bool flipY)
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

        /// <summary>
        ///  Cut Cubemap to a normal map
        /// </summary>
        /// <param name="cubemap"></param>
        /// <returns></returns>
        public static Texture2D GetTexture2DByCubeMap(Cubemap cubemap)
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



        internal static void SaveCubemapToFile(Cubemap cubemap, string path)
        {

                CubemapFace[] faces = new CubemapFace[] {
                CubemapFace.PositiveX, CubemapFace.NegativeX,
                CubemapFace.PositiveY, CubemapFace.NegativeY,
                CubemapFace.PositiveZ, CubemapFace.NegativeZ };

            Texture2D Text = new Texture2D(cubemap.width, cubemap.height);

            foreach (CubemapFace face in faces)
            {
                try
                {
                    Log.Debug($"Generating Texture of {face}");
                    Text.SetPixels(cubemap.GetPixels(face));
                    Log.Debug("Saving Texture...");
                    File.WriteAllBytes(path + "/" + cubemap.name + "_" + face.ToString() + ".png",
                        ImageConversion.EncodeToPNG(Text));
                    Log.Debug($"Saved {cubemap.name} {face.ToString()}");
                }
                catch (Exception e)
                {
                    ModConsole.ErrorExc(e);
                }
            }
        }
    }
}
