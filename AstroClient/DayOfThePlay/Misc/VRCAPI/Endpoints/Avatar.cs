using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using DayBots.VRCAPI.Classes;
using DayClientML2;
using AstroClient.ConsoleUtils;

namespace DayBots.VRCAPI.Endpoints
{
    class AvatarEndpoint
    {
        public Variables Variables { get;set;}
        public AvatarEndpoint(Variables variables) { Variables = variables; }
        public async Task<DayClientML2.Utility.Api.Object.AvatarObject> GetAvatar(string AvtrID)
        {
            var avatar = JsonConvert.DeserializeObject<DayClientML2.Utility.Api.Object.AvatarObject>(await Variables.SendRequest(Variables.HTTPMethods.GET,API.AvatarCommand + AvtrID,null));
            ModConsole.Log($"[API] Avatar returned Ok! [Avatar:{avatar.name}|ID:{avatar.id}]");
            return avatar;
        }
        public async Task<List<DayClientML2.Utility.Api.Object.AvatarObject>> GetPublicAvatars(string userid, int startingfrom, int amount)
        {
            var Headers = new Dictionary<string, string>();
            Headers.Add("userId", userid);
            Headers.Add("offset", startingfrom.ToString());
            Headers.Add("n", amount.ToString());
            Headers.Add("order", "descending");
            List<DayClientML2.Utility.Api.Object.AvatarObject> avatars = new List<DayClientML2.Utility.Api.Object.AvatarObject>();
            avatars.AddRange(JsonConvert.DeserializeObject<List<DayClientML2.Utility.Api.Object.AvatarObject>>(await Variables.SendRequest(Variables.HTTPMethods.GET,"avatars/",Headers)));
            if(avatars.Count == amount)
            {
                avatars.AddRange(await (GetPublicAvatars(userid,startingfrom + amount, amount)));
            }
            return avatars;
        }
    }
}
