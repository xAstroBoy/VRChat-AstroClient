namespace DayBots.VRCAPI.Endpoints
{
	using AstroLibrary.Console;
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	internal class AvatarEndpoint
	{
		public Variables Variables { get; set; }

		public AvatarEndpoint(Variables variables)
		{
			Variables = variables;
		}

		public async Task<DayClientML2.Utility.Api.Object.AvatarObject> GetAvatar(string AvtrID)
		{
			var avatar = JsonConvert.DeserializeObject<DayClientML2.Utility.Api.Object.AvatarObject>(await Variables.SendRequest(Variables.HTTPMethods.GET, API.AvatarCommand + AvtrID, null));
			ModConsole.Log($"[API] Avatar returned Ok! [Avatar:{avatar.name}|ID:{avatar.id}]");
			return avatar;
		}

		public async Task<List<DayClientML2.Utility.Api.Object.AvatarObject>> GetPublicAvatars(string userid, int startingfrom, int amount)
		{
			var Headers = new Dictionary<string, string>
			{
				{ "userId", userid },
				{ "offset", startingfrom.ToString() },
				{ "n", amount.ToString() },
				{ "order", "descending" }
			};
			List<DayClientML2.Utility.Api.Object.AvatarObject> avatars = new List<DayClientML2.Utility.Api.Object.AvatarObject>();
			avatars.AddRange(JsonConvert.DeserializeObject<List<DayClientML2.Utility.Api.Object.AvatarObject>>(await Variables.SendRequest(Variables.HTTPMethods.GET, "avatars/", Headers)));
			if (avatars.Count == amount)
			{
				avatars.AddRange(await GetPublicAvatars(userid, startingfrom + amount, amount));
			}
			return avatars;
		}
	}
}