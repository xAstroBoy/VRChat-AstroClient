namespace AstroLibrary.Bots.VRCAPI.Endpoints
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Console;
    using DayBots.VRCAPI;
    using Newtonsoft.Json;

    internal class AvatarEndpoint
    {
        public Variables Variables { get; set; }

        public AvatarEndpoint(Variables variables)
        {
            Variables = variables;
        }

        public async Task<Misc.Api.Object.AvatarObject> GetAvatar(string AvtrID)
        {
            var avatar = JsonConvert.DeserializeObject<Misc.Api.Object.AvatarObject>(await Variables.SendRequest(Variables.HTTPMethods.GET, API.AvatarCommand + AvtrID, null));
            ModConsole.Log($"[API] Avatar returned Ok! [Avatar:{avatar.name}|ID:{avatar.id}]");
            return avatar;
        }

        public async Task<List<Misc.Api.Object.AvatarObject>> GetPublicAvatars(string userid, int startingfrom, int amount)
        {
            var Headers = new Dictionary<string, string>
            {
                { "userId", userid },
                { "offset", startingfrom.ToString() },
                { "n", amount.ToString() },
                { "order", "descending" }
            };
            List<Misc.Api.Object.AvatarObject> avatars = new List<Misc.Api.Object.AvatarObject>();
            avatars.AddRange(JsonConvert.DeserializeObject<List<Misc.Api.Object.AvatarObject>>(await Variables.SendRequest(Variables.HTTPMethods.GET, "avatars/", Headers)));
            if (avatars.Count == amount)
            {
                avatars.AddRange(await GetPublicAvatars(userid, startingfrom + amount, amount));
            }
            return avatars;
        }
    }
}