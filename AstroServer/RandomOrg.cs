namespace AstroServer
	{
	using HtmlAgilityPack;

	public static class RandomOrg
		{
		public static string Source = "https://www.random.org/strings/?num=10&len=20&digits=on&upperalpha=on&loweralpha=on&unique=on&format=html&rnd=new";

		public static string ClassToGet = "data";

		public static string GetRandomKey()
			{
			string key = string.Empty;

			var web = new HtmlWeb();
			var doc = web.Load(Source);

			foreach (HtmlNode node in doc.DocumentNode.SelectNodes($"//pre[@class='{ClassToGet}']"))
				{
				key = node.InnerText;
				key = key.Replace("\r", string.Empty);
				key = key.Replace("\n", string.Empty);
				}

			return key;
			}
		}
	}