namespace AstroServer
{
    using AstroServer.Serializable;
    using MongoDB.Driver;
    using MongoDB.Entities;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    internal class Database
    {
        public static async Task Initialize()
        {
            await DB.InitAsync("astro", MongoClientSettings.FromConnectionString(GetConnectionString()));

            // I use this below to update accounts when I add new fields
            //var accounts = DB.Collection<AccountData>();

            //var update = Builders<AccountData>.Update.Set("IsBeta", false);
            //var filter = Builders<AccountData>.Filter.Empty;
            //var options = new UpdateOptions() { IsUpsert = true };
            //var result = accounts.UpdateMany(filter, update, options);
            //Console.WriteLine($"Updated: {result.ModifiedCount} accounts with missing data");

            // Clean the database
            var avatars = await DB.Find<AvatarDataEntity>().ManyAsync(a => a.Name == null).ConfigureAwait(false);

            if (avatars.Count > 0)
            {
                foreach (var avatar in avatars)
                {
                    await avatar.DeleteAsync().ConfigureAwait(false);
                }

                Console.WriteLine($"{avatars.Count} invalid avatars found and purged..");
            }

            Console.WriteLine("Database Initialized..");
        }

        public static string GetConnectionString()
        {
            return File.ReadAllText("/root/mono.txt");
        }
    }
}