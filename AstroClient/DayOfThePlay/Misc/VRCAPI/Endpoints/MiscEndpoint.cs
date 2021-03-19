using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using DayBots.VRCAPI.Classes;

namespace DayBots.VRCAPI.Endpoints
{
    class MiscEndpoint
    {
        public Variables Variables { get; set; }
        public MiscEndpoint(Variables variables) { Variables = variables; }

        public async Task<Classes.UserSelf> GetSelf()
        {
            var user = JsonConvert.DeserializeObject<Classes.UserSelf>(await Variables.SendRequest(Variables.HTTPMethods.GET, "auth/user", null));
            Variables.Self = user;
            return user;
        }
        public async void JoinLobby(string worldid)
        {
            var Headers = new Dictionary<string, string>();
            Headers.Add("userId", Variables.Self.id);
            Headers.Add("worldId", worldid);
            await Variables.SendRequest(Variables.HTTPMethods.PUT,"joins",Headers);
        }
        public async void VisitLobby(string worldid)
        {
            var Headers = new Dictionary<string, string>();
            Headers.Add("userId", Variables.Self.id);
            Headers.Add("worldId", worldid);
            await Variables.SendRequest(Variables.HTTPMethods.PUT, "visits", Headers);
        }
        public async void FakeExist(string worldid,float time)
        {
            new Thread(() =>
            {
                Stopwatch Timer = Stopwatch.StartNew();
                JoinLobby(worldid);
                for(; ; )
                {
                    VisitLobby(worldid);
                    Thread.Sleep(2500);
                    if(Timer.Elapsed.Seconds > time)
                    {
                        Thread.CurrentThread.Abort();
                    }
                }
            })
            {
                IsBackground = true
            }.Start();
        }
        public RoomPassword GetRoomPassword(string worldid)
        {
            return JsonConvert.DeserializeObject<RoomPassword>(Variables.SendRequest(Variables.HTTPMethods.GET, $"instances/{worldid}/join",null).GetAwaiter().GetResult());
        }
        public async Task<string> GetUsersOnline()
        {
            return await (Variables.SendRequest(Variables.HTTPMethods.GET, "visits", null));
        }
        public async Task<Classes.WorldInstanceResponse> GetInstance(string worldId, string instanceId)
        {
            return JsonConvert.DeserializeObject<Classes.WorldInstanceResponse>(await Variables.SendRequest(Variables.HTTPMethods.GET, $"{API.WorldCommand}/{worldId}/{instanceId}", null));
        }
        public async void SendNotification(NotificationType type,string userid)
        {
            switch (type)
            {
                case NotificationType.friendrequest:
                    Variables.SendRequest(Variables.HTTPMethods.POST, $"user/{userid}/friendRequest", null);
                    break;
                case NotificationType.votekick:
                    break;
                default:
                    var Headers = new Dictionary<string, string>();
                    Headers.Add("message", "API Utils");
                    Headers.Add("type", type.ToString());
                    Variables.SendRequest(Variables.HTTPMethods.POST, $"user/{userid}/notification",null);
                    break;
            }
        }
        public async Task<List<Classes.Notification>> GetAllNotification(NotificationType type,bool urs,DateTime after)
        {
            var Headers = new Dictionary<string, string>();
            Headers.Add("type", type.ToString());
            Headers.Add("sent", urs.ToString());
            Headers.Add("after", after.ToString());
            return JsonConvert.DeserializeObject<List<Classes.Notification>>(await Variables.SendRequest(Variables.HTTPMethods.GET, "user/notifications", Headers));
        }
        public enum NotificationType
        {
            friendrequest,
            invite,
            requestInvite,
            votekick,

        }
    }
}
