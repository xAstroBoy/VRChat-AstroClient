namespace AstroServer
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Entities;

    class Database
    {
        public async static Task Initialize()
        {
            await DB.InitAsync("astro", MongoClientSettings.FromConnectionString(GetConnectionString()));
            Console.WriteLine("Database Initialized..");
        }

        public static string GetConnectionString()
        {
            return File.ReadAllText("/root/mono.txt");
        }
    }
}
