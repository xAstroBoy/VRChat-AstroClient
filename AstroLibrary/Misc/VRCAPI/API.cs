namespace DayBots.VRCAPI
{
	using AstroLibrary.Bots.VRCAPI.Endpoints;
	using DayBots.VRCAPI.Endpoints;
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Net.Http;

	internal class API
	{
		internal const string APIKEYLONG = "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26";
		internal const string APIKEY = "JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26";
		internal const string APIURL = "https://api.vrchat.cloud/api/1/";

		internal const string WorldCommand = "worlds/";
		internal const string UserCommand = "users/";
		internal const string JoinCommand = "joins/";
		internal const string VisitCommand = "visits/";
		internal const string AuthCommand = "auth/user";
		internal const string AvatarCommand = "avatars/";

		public static List<API> APIClients = new List<API>();

		public Variables Variables { get; set; }
		public AvatarEndpoint Avatar { get; set; }
		public MiscEndpoint Misc { get; set; }

		public API(string AuthToken)
		{
			Variables = new Variables();
			if (Variables.HttpClient == null)
			{
				Variables.CookieContainer = new CookieContainer();
				Variables.HttpClientHandler = new HttpClientHandler
				{
					UseCookies = false
				};
				Variables.HttpClientHandler.UseCookies = false;
				Variables.HttpClient = new HttpClient(Variables.HttpClientHandler)
				{
					BaseAddress = new Uri(APIURL)
				};
			}
			Variables.AuthCookie = AuthToken;
			APIClients.Add(this);
			Avatar = new AvatarEndpoint(Variables);
			Misc = new MiscEndpoint(Variables);
			Misc.GetSelf();
		}
	}
}