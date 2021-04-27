namespace AstroServer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;

    class Database
    {
        public static void Test()
        {
            // ...
            var client = new MongoClient(GetConnectionString());
            var database = client.GetDatabase("astro");
        }

        public static string GetConnectionString()
        {
            return File.ReadAllText("/root/mono.txt");
        }
    }
}
