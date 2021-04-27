namespace AstroServer
{
    using System;
    using System.Collections.Generic;
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
            var client = new MongoClient(
                "mongodb+srv://localhost:27017"
            );
            var database = client.GetDatabase("astro");
        }
    }
}
