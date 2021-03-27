namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using Cinemachine;
    using DG.Tweening.Plugins.Core.PathCore;
    using Mono.CSharp;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SaveDataExtensions
    {
        public static void Save<SaveData>(this SaveData saveData)
        {
            SaveDataManager.Save<SaveData>(saveData);
        }
    }

    public static class SaveDataManager
    {
        public static void Save<T>(T saveData)
        {
            string path = GetAndCheckLocation(saveData);
            JSonWriter.WriteToJsonFile<T>(path, saveData);
        }

        private static string GetAndCheckLocation<T>(T saveData)
        {
            string path = $@"{Environment.CurrentDirectory}\Config\{BuildInfo.Name}\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                ModConsole.DebugLog($"SaveData directory created: {path}");
            }

            path = $@"{path}\{saveData.GetType().Name}.json";
            if (!File.Exists(path))
            {
                File.Create(path);
                ModConsole.DebugLog($"SaveData file created: {path}");
            }

            return path;
        }
    }
}
