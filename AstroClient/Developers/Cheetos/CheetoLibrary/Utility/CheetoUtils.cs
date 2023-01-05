using TMPro;

namespace AstroClient.CheetoLibrary.Utility
{
    #region Imports

    using System;
    using System.IO;
    using System.Reflection;
    using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Raw;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Core;
    using xAstroBoy;

    //using VRC.UI.Elements;

    #endregion Imports

    public static class CheetoUtils
    {
        public static void TryRun(Action[] actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                try
                {
                    actions[i].Invoke();
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
            }
        }

        public static Texture2D LoadBundlePng(byte[] bundle)
        {
            try
            {
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, bundle); //..this will auto-resize the texture dimensions.
                return tex;
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return null;
            }

        }
        public static Texture2D LoadPNGFromDir(string filePath)
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(filePath);
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
                return tex;
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return null;
            }
        }

        public static Texture2D LoadPNG(string filePath)
        {
            try
            {
                byte[] fileData = ExtractResource(Assembly.GetExecutingAssembly(), filePath);
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
                return tex;
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return null;
            }
        }

        public static Texture2D LoadPNG(byte[] fileData)
        {
            Texture2D tex = new Texture2D(2, 2);
            ImageConversion.LoadImage(tex, fileData); //..this will auto-resize the texture dimensions.
            return tex;
        }

        public static byte[] ExtractResource(Assembly assembly, string filename)
        {
            try
            {
                using (Stream resFilestream = assembly.GetManifestResourceStream(filename))
                {
                    if (resFilestream == null) return null;
                    byte[] ba = new byte[resFilestream.Length];
                    resFilestream.Read(ba, 0, ba.Length);
                    return ba;
                }
            }
            catch (Exception e)
            {
                Log.Error($"Failed to extract resource: {filename}");
                Log.Exception(e);
            }
            return null;
        }
    }
}