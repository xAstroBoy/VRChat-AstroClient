namespace DayBots.VRCAPI.Endpoints
{
	using DayBots.VRCAPI.Classes;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Threading;
	using System.Threading.Tasks;

	internal class MiscEndpoint
    {
        public Variables Variables { get; set; }

        public MiscEndpoint(Variables variables)
        {
            Variables = variables;
        }

        public async Task<UserSelf> GetSelf()
        {
            var user = JsonConvert.DeserializeObject<UserSelf>(await Variables.SendRequest(Variables.HTTPMethods.GET, "auth/user", null));
            Variables.Self = user;
            return user;
        }

        public async void JoinLobby(string worldid)
        {
            var Headers = new Dictionary<string, string>
            {
                { "userId", Variables.Self.id },
                { "worldId", worldid }
            };
            await Variables.SendRequest(Variables.HTTPMethods.PUT, "joins", Headers);
        }

        public async void VisitLobby(string worldid)
        {
            var Headers = new Dictionary<string, string>
            {
                { "userId", Variables.Self.id },
                { "worldId", worldid }
            };
            await Variables.SendRequest(Variables.HTTPMethods.PUT, "visits", Headers);
        }

        public async void FakeExist(string worldid, float time)
        {
            new Thread(() =>
            {
                Stopwatch Timer = Stopwatch.StartNew();
                JoinLobby(worldid);
                for (; ; )
                {
                    VisitLobby(worldid);
                    Thread.Sleep(2500);
                    if (Timer.Elapsed.Seconds > time)
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
            return JsonConvert.DeserializeObject<RoomPassword>(Variables.SendRequest(Variables.HTTPMethods.GET, $"instances/{worldid}/join", null).GetAwaiter().GetResult());
        }

        public async Task<string> GetUsersOnline()
        {
            return await Variables.SendRequest(Variables.HTTPMethods.GET, "visits", null);
        }

        public async Task<WorldInstanceResponse> GetInstance(string worldId, string instanceId)
        {
            return JsonConvert.DeserializeObject<WorldInstanceResponse>(await Variables.SendRequest(Variables.HTTPMethods.GET, $"{API.WorldCommand}/{worldId}/{instanceId}", null));
        }

        public async void SendNotification(NotificationType type, string userid)
        {
            switch (type)
            {
                case NotificationType.friendrequest:
                    Variables.SendRequest(Variables.HTTPMethods.POST, $"user/{userid}/friendRequest", null);
                    break;

                case NotificationType.votekick:
                    break;

                default:
                    var Headers = new Dictionary<string, string>
                    {
                        { "message", "API Utils" },
                        { "type", type.ToString() }
                    };
                    Variables.SendRequest(Variables.HTTPMethods.POST, $"user/{userid}/notification", null);
                    break;
            }
        }

        public async Task<List<Notification>> GetAllNotification(NotificationType type, bool urs, DateTime after)
        {
            var Headers = new Dictionary<string, string>
            {
                { "type", type.ToString() },
                { "sent", urs.ToString() },
                { "after", after.ToString() }
            };
            return JsonConvert.DeserializeObject<List<Notification>>(await Variables.SendRequest(Variables.HTTPMethods.GET, "user/notifications", Headers));
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