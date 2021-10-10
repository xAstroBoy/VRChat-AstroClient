namespace CheetosLibrary
{
    #region Imports

    using System;
    using System.IO;
    using System.Reflection;
    using UnityEngine;

    #endregion Imports

    public static class ResourceUtils
    {
        public static Texture2D LoadPNG(string filePath)
        {
            byte[] fileData = ExtractResource(Assembly.GetExecutingAssembly(), filePath);
            Texture2D tex = new Texture2D(2, 2);
            ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
            return tex;
        }

        public static Texture2D LoadPNG(byte[] fileData)
        {
            Texture2D tex = new Texture2D(2, 2);
            ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
            return tex;
        }

        public static byte[] ExtractResource(Assembly assembly, string filename)
        {
            using (Stream resFilestream = assembly.GetManifestResourceStream(filename))
            {
                if (resFilestream == null) return null;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
}