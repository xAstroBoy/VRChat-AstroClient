using AstroClient.ClientActions;

namespace AstroClient.Cheetos
{
    #region Imports

    using System.Collections.Generic;
    using AstroMonos.Components.Player;
    using AstroMonos.Components.Spoofer;
    using Constants;
    using Photon.Realtime;
    using Tools.Extensions;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.Core;
    using WebSocketSharp;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class CheetosTestStuff : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnMasterClientSwitched += OnMasterClientSwitched;
            ClientEventActions.OnWorldReveal += OnWorldReveal;

            ClientEventActions.OnRoomLeft += OnRoomJoined;
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private static bool DoOnce;
        private static WebSocket ws;

        //internal override void VRChat_OnQuickMenuInit()
        //{
        //    var infoBar = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar");
        //    var infobartext = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/EarlyAccessText").GetComponent<Text>();

        //    infobartext.color = new Color(1, 0, 1, 1);

        //    infoBar.transform.localPosition -= new Vector3(0, 110, 0);
        //    infobartext.text = "AstroClient";

        //    //_ = MelonCoroutines.Start(Connect());
        //}

        //private static IEnumerator Connect()
        //{
        //    //while (APIUser.CurrentUser == null) yield return new WaitForSeconds(0.1F);
        //    //while (string.IsNullOrWhiteSpace(ApiCredentials.authToken)) yield return new WaitForSeconds(0.1F);
        //    //try
        //    //{
        //    //    Console.WriteLine($"AuthCookie: " + ApiCredentials.authToken);
        //    //    var protocols = new Il2CppStringArray(new string[] { });
        //    //    ws = new WebSocketSharp.WebSocket("wss://pipeline.vrchat.cloud/?authToken=" + ApiCredentials.authToken);
        //    //    ws.OnOpen += OnOpened;
        //    //    ws.OnMessage += HandleMessage;
        //    //    ws.Connect();
        //    //}
        //    //catch
        //    //{
        //    //    Console.WriteLine("[ApiExtensions] VRChat Pipeline WebSocket Error");
        //    //}

        //    yield break;
        //}

        //private static void HandleMessage(object sender, MessageEventArgs e)
        //{
        //    var WebSocketRawData = JsonConvert.DeserializeObject<WebSocketObject>(e.Data);
        //    var WebSocketData = JsonConvert.DeserializeObject<WebSocketContent>(WebSocketRawData?.content);
        //    var type = WebSocketRawData?.type;

        //    switch (type)
        //    {
        //        case "friend-online":
        //            Log.Write($"[Friends] '{WebSocketData.user.displayName}' -> Came Online");
        //            break;
        //        case "friend-active":
        //            Log.Write($"[Friends] '{WebSocketData.user.displayName}' -> Status: {WebSocketData.user.state} - '{WebSocketData.user.status}'");
        //            break;
        //        case "friend-location":
        //            if (WebSocketData.location.Equals("private"))
        //            {
        //                Log.Write($"[Friends] '{WebSocketData.user.displayName}' -> Went to a private location");
        //            }
        //            else
        //            {
        //                Log.Write($"[Friends] '{WebSocketData.user.displayName}' -> Went to {WebSocketData.world.name} - {WebSocketData.location}");
        //            }
        //            break;
        //        case "user-location":
        //            break;
        //        default:
        //            Log.Write($"[API] Unhandled Type: {type}");
        //            break;
        //    }

        //    //Log.Write($"[API] {e.Data}");
        //}

        //private static void OnOpened(object sender, EventArgs e)
        //{
        //    Log.Write("[API] Connected To WebSocket!");
        //    //Helper().Start();
        //}

        private void OnMasterClientSwitched(Player player)
        {
            if (!WorldUtils.IsInWorld) return;

            if (player.GetPhotonPlayer().GetAPIUser().IsSelf)
            {
                if (PlayerSpooferUtils.IsSpooferActive)
                {
                    PopupUtils.QueHudMessage(
                        $"'{PlayerSpooferUtils.SpooferInstance.Original_DisplayName}' is now the room master.");
                }
            }
            else
            {
                PopupUtils.QueHudMessage($"'{player.GetPhotonPlayer().GetDisplayName()}' is now the room master.");
            }

            player.GetVRCPlayer().AddSingleTag(System.Drawing.Color.OrangeRed, "Instance Master");

        }

        private void OnRoomJoined()
        {
            Log.Write("You joined a room.");
        }

        private void OnRoomLeft()
        {
            Log.Write("You left a room.");
        }

        //internal override void OnPlayerJoined(Player player)
        //{
        //    return;
        //    if (player == null) throw new ArgumentNullException();
        //    if (player.gameObject.GetComponent<CheetoNameplate>() == null) player.gameObject.AddComponent<CheetoNameplate>();
        //}

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            //VRC.Player player = PlayerUtils.GetPlayer();
            //if (player.gameObject.GetComponent<SitOnPlayer>() == null) player.gameObject.AddComponent<SitOnPlayer>();

            if (Bools.IsDeveloper && !DoOnce)
            {
                PopupUtils.QueHudMessage("Developer Mode!");
                DoOnce = true;
            }

            WorldUtils.InstanceMaster.GetPlayer().AddSingleTag(System.Drawing.Color.OrangeRed, "Instance Master");
        }
    }
}