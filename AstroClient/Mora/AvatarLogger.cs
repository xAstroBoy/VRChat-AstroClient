using AstroNetworkingLibrary.Serializable;
using Harmony;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using VRC.Core;

namespace AstroClient
{
    internal class AvatarLogger : GameEvents
    {
        private const string PublicAvatarFile = "AstroClient\\AvatarLog\\Avatars.html";
        private static string _avatarIDs = "";
        private static readonly Queue<ApiAvatar> AvatarToPost = new Queue<ApiAvatar>();
        private static readonly HttpClient WebHookClient = new HttpClient();

        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(AvatarLogger).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        public override void OnApplicationStart()
        {
            Directory.CreateDirectory("AstroClient\\AvatarLog");
            if (!File.Exists(PublicAvatarFile))
                File.AppendAllText(PublicAvatarFile, $"{Environment.NewLine}{Environment.NewLine}");

            foreach (var line in File.ReadAllLines(PublicAvatarFile))
                if (line.Contains("Avatar ID"))
                    _avatarIDs += line.Replace("Avatar ID:", "");

            var patchMan = HarmonyInstance.Create("nya");
            patchMan.Patch(
                typeof(AssetBundleDownloadManager).GetMethods().FirstOrDefault(mi =>
                    mi.GetParameters().Length == 1 && mi.GetParameters().First().ParameterType == typeof(ApiAvatar) &&
                    mi.ReturnType == typeof(void)), GetPatch("ApiAvatarDownloadPatch"));
        }

        private static bool ApiAvatarDownloadPatch(ApiAvatar __0)
        {
            DateTime now = DateTime.Now;

            if (!_avatarIDs.Contains(__0.id))
            {
                _avatarIDs += __0.id;
                var sb = new StringBuilder();
                sb.AppendLine($"<br> {now}");
                sb.AppendLine($"<br>Avatar Name: {__0.name}");
                sb.AppendLine($"<br>Avatar Description: {__0.description}");
                sb.AppendLine($"<br>Avatar ID: {__0.id}");
                sb.AppendLine($"<br>Avatar Author Name: {__0.authorName}");
                sb.AppendLine($"<br>Avatar Author ID: {__0.authorId}");
                sb.AppendLine($"<br>Avatar Release Status: {__0.releaseStatus}");
                sb.AppendLine($"<br>Avatar Asset URL: <a href='{ __0.assetUrl}' > Click Me </a> ");
                sb.AppendLine($"<br>Avatar Release Status: {__0.releaseStatus}");
                sb.AppendLine($"<br>Avatar Version: {__0.version} <br>Avatar Thumbnail Image URL: <br><img src='{__0.thumbnailImageUrl}' width=200 height=200 /><br><br><br>");
                sb.AppendLine(Environment.NewLine);
                File.AppendAllText(PublicAvatarFile, sb.ToString());
                sb.Clear();
            }

            AvatarData data = new AvatarData();
            data.ID = __0.id;
            data.Name = __0.name;
            data.Description = __0.description;
            data.AuthorID = __0.authorId;
            data.AuthorName = __0.authorName;
            data.AssetURL = __0.assetUrl;
            data.ImageURL = __0.imageUrl;
            data.ThumbnailURL = __0.thumbnailImageUrl;
            data.ReleaseStatus = __0.releaseStatus;
            data.Version = __0.version;
            // NetworkingManager.SendAvatarLog(data);
            // NetworkingManager.SendLongAssShit();
            return true;
        }
    }
}