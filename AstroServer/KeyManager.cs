namespace AstroServer
{
    using AstroServer.Serializable;
    using MongoDB.Entities;
    using System;
    using System.IO;
    using System.Linq;

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

        //public static void AddKey(string key, ulong discordID)
        //{
        //	using (StreamWriter sw = File.AppendText("/root/keys.txt"))
        //	{
        //		sw.WriteLine($"{Environment.NewLine}{key}:{discordID}");
        //	}
        //}

        public static int GetDevKeyCount()
        {
            return DB.Find<AccountData>().ManyAsync(a => a.IsDeveloper).Result.Count;
        }

        public static int GetBetaKeyCount()
        {
            return DB.Find<AccountData>().ManyAsync(a => a.IsBeta).Result.Count;
        }

        public static int GetKeyCount()
        {
            return DB.Find<AccountData>().ManyAsync(a => (!a.IsDeveloper && !a.IsBeta)).Result.Count;
        }

        public static bool IsKeyValid(string key)
        {
            return DB.Find<AccountData>().ManyAsync(a => a.Key.Equals(key)).Result.Any();
        }

        public static AccountData GetAccountData(string key)
        {
            return DB.Find<AccountData>().ManyAsync(a => a.Key.Equals(key)).Result.FirstOrDefault();
        }

        public static ulong GetKeysDiscordOwner(string authKey)
        {
            var account = DB.Find<AccountData>().ManyAsync(a => a.Key.Equals(authKey)).Result.First();
            return account != null ? account.DiscordID : 0;
        }
    }
}