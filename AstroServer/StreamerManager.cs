namespace AstroServer
	{
	using System.Collections.Generic;
	using System.IO;

	public static class StreamerManager
		{
		public static Dictionary<string, string> GetAllStreamerInfo()
			{
			Dictionary<string, string> pairs = new Dictionary<string, string>();
			foreach (var keyinfo in File.ReadLines("/root/streamers.txt"))
				{
				var info = keyinfo.Split(":");
				pairs.Add(info[0], info[1]);
				}
			return pairs;
			}

		public static string GetStreamerID(string name)
			{
			foreach (var keyinfo in File.ReadLines("/root/streamers.txt"))
				{
				var info = keyinfo.Split(":");

				if (info[1].ToLower().Contains(name.ToLower()) || info[1].ToLower().Equals(name.ToLower()))
					{
					return info[0];
					}
				}
			return string.Empty;
			}
		}
	}