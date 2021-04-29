namespace AstroServer
	{
	using MongoDB.Driver;
	using MongoDB.Entities;
	using System;
	using System.IO;
	using System.Threading.Tasks;

	internal class Database
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