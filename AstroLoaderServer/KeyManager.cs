using System.IO;

namespace AstroLoaderServer
{
    internal static class KeyManager
    {
        /// <summary>
        /// Returns the auth token for the DiscordBot
        /// </summary>
        /// <returns></returns>
        public static string GetBotToken()
        {
            return File.ReadAllText("/root/discordtoken.txt");
        }

        public static int GetDevKeyCount()
        {
            return File.ReadAllLines("/root/devs.txt").Length;
        }

        public static int GetKeyCount()
        {
            return File.ReadAllLines("/root/keys.txt").Length;
        }

        public static bool IsDevKey(string authKey)
        {
            foreach (var keyinfo in File.ReadLines("/root/devs.txt"))
            {
                var info = keyinfo.Split(":");

                if (info[0].Equals(authKey))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidKey(string authKey)
        {
            foreach (var keyinfo in File.ReadLines("/root/devs.txt"))
            {
                var info = keyinfo.Split(":");

                if (info[0].Equals(authKey))
                {
                    return true;
                }
            }
            foreach (var keyinfo in File.ReadLines("/root/keys.txt"))
            {
                var info = keyinfo.Split(":");

                if (info[0].Equals(authKey))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
