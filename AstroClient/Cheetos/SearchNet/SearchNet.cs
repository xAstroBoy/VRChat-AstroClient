namespace AstroClient.Cheetos
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using WebSocketSharp;

    internal class SearchNet
    {
		public static WebSocket ws;
        public static List<string> Ids = new List<string>();
        public static List<VRChat_SearchNet> Found = new List<VRChat_SearchNet>();
        public static string CurrentForceJoin = "";
        public static string CurrentForceJoinUsername = "";

        public static void Connect()
		{
			try
			{
				AppDomain.CurrentDomain.UnhandledException += SearchNet.WarnBlank;
				bool flag = File.Exists(Directory.GetCurrentDirectory() + "/AstroClient/SearchNet.txt");
				if (flag)
				{
					string text = File.ReadAllText(Directory.GetCurrentDirectory() + "/AstroClient/SearchNet.txt");
					string[] array = text.Split(new char[]
					{
						'\n'
					});
					SearchNet.Ids = new List<string>();
					foreach (string text2 in array)
					{
						bool flag2 = text2.StartsWith("usr");
						if (flag2)
						{
							bool flag3 = !SearchNet.Ids.Contains(text2);
							if (flag3)
							{
								SearchNet.Ids.Add(text2);
							}
						}
					}
				}
				else
				{
					File.WriteAllText(Directory.GetCurrentDirectory() + "/AstroClient/SearchNet.txt", "");
				}
				SearchNet.ws = new WebSocket("ws://ws.skid-hub.com/SearchNet", Array.Empty<string>());
				SearchNet.ws.OnOpen += SearchNet.Connected;
				SearchNet.ws.OnMessage += SearchNet.Logging;
				SearchNet.ws.OnClose += SearchNet.Restart;
				SearchNet.ws.Connect();
				foreach (string id in SearchNet.Ids)
				{
					SearchNet.AddusertoSearch(id, false);
				}
			}
			catch
			{
			}
		}
        private static void Connected(object sender, EventArgs e)
        {
            ModConsole.Log("[SearchNet] Connected.");
        }

        private static void Restart(object sender, CloseEventArgs e)
		{
			try
			{
				//bool searchNet = Config.Instance.SearchNet;
				if (Bools.IsDeveloper)
				{
					SearchNet.Connect();
				}
			}
			catch
			{
			}
		}

		private static void WarnBlank(object sender, UnhandledExceptionEventArgs e)
		{
			File.WriteAllText("error.txt", e.ExceptionObject.ToString());
		}

		public static void AddusertoSearch(string id, bool add = true)
		{
			try
			{
                ModConsole.Log($"[SearchNet] Added: {id}");
				SearchNet.ws.Send("search:" + id);
				if (add)
				{
					File.WriteAllText(Directory.GetCurrentDirectory() + "/AstroClient/SearchNet.txt", File.ReadAllText(Directory.GetCurrentDirectory() + "/AstroClient/SearchNet.txt") + "\n" + id);
				}
			}
			catch
			{
			}
		}

		public static void RemoveusertoSearch(string id, bool add = true)
		{
			try
			{
				SearchNet.Ids.Remove(id);
				if (add)
				{
					File.WriteAllText(Directory.GetCurrentDirectory() + "/AstroClient/SearchNet.txt", string.Join("\n", SearchNet.Ids.ToArray()));
				}
				SearchNet.ws.Close();
			}
			catch
			{
			}
		}

		private static void Logging(object sender, MessageEventArgs e)
		{
			try
			{
				VRChat_SearchNet vrchat_SearchNet = new VRChat_SearchNet();
				bool flag = vrchat_SearchNet.ParsefromJson(e.Data);
				if (flag)
				{
					SearchNet.Found.Add(vrchat_SearchNet);
					bool flag2 = vrchat_SearchNet.Action == VRChat_SearchNet.World_Event.Join;
					if (flag2)
					{
						ModConsole.Log(string.Concat(new string[]
						{
							"[SearchNet] ",
							vrchat_SearchNet.Username,
							" Joined\n",
							vrchat_SearchNet.worldname,
							" [",
							vrchat_SearchNet.worldprivacy,
							"]\nPress Del to Join!"
						}));
						SearchNet.CurrentForceJoin = vrchat_SearchNet.worldid;
						SearchNet.CurrentForceJoinUsername = vrchat_SearchNet.Username;
					}
					bool flag3 = vrchat_SearchNet.Action == VRChat_SearchNet.World_Event.Leave;
					if (flag3)
					{
                        ModConsole.Log(string.Concat(new string[]
						{
							"[SearchNet] ",
							vrchat_SearchNet.Username,
							" Leaved\n",
							vrchat_SearchNet.worldname,
							" [",
							vrchat_SearchNet.worldprivacy,
							"]"
						}));
					}
				}
			}
			catch
			{
			}
		}

	}
}
