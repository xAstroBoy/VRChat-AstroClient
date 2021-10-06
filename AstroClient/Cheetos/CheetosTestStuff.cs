namespace AstroClient.Cheetos
{
    #region Imports

    using AstroClient.Components;
    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Finder;
    using AstroLibrary.Misc.Api.Object;
    using AstroLibrary.Utility;
    using MelonLoader;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnhollowerBaseLib;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC;
    using VRC.Core;
    using WebSocketSharp;

    #endregion Imports

    internal class CheetosTestStuff : GameEvents
    {
        private static bool DoOnce;
        private static WebSocket ws;

        internal override void VRChat_OnUiManagerInit()
        {
            var infoBar = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar");
            var infobartext = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/EarlyAccessText").GetComponent<Text>();

            infobartext.color = new Color(1, 0, 1, 1);

            infoBar.transform.localPosition -= new Vector3(0, 110, 0);
            infobartext.text = "AstroClient";

            if (Bools.IsDeveloper)
            {
                SearchNet.Connect();

                SearchNet.AddusertoSearch("usr_e358e56c-da53-4ada-a860-1cc8ac54c13f", false); // Jacked Delta (Asshole)
                SearchNet.AddusertoSearch("usr_d078d7cc-bbfb-4e4e-b970-ccead7998a5b", false); // Qg
                SearchNet.AddusertoSearch("usr_1365189e-4d5e-4015-a754-3daff40a972e", false); // SusheSarah (Moist)
            }
            _ = MelonCoroutines.Start(Connect());
        }

        private static IEnumerator Connect()
        {
            //while (APIUser.CurrentUser == null) yield return new WaitForSeconds(0.1F);
            //while (string.IsNullOrWhiteSpace(ApiCredentials.authToken)) yield return new WaitForSeconds(0.1F);
            //try
            //{
            //    Console.WriteLine($"AuthCookie: " + ApiCredentials.authToken);
            //    var protocols = new Il2CppStringArray(new string[] { });
            //    ws = new WebSocketSharp.WebSocket("wss://pipeline.vrchat.cloud/?authToken=" + ApiCredentials.authToken);
            //    ws.OnOpen += OnOpened;
            //    ws.OnMessage += HandleMessage;
            //    ws.Connect();
            //}
            //catch
            //{
            //    Console.WriteLine("[ApiExtensions] VRChat Pipeline WebSocket Error");
            //}

            yield break;
        }

        private static void HandleMessage(object sender, MessageEventArgs e)
        {
            var WebSocketRawData = JsonConvert.DeserializeObject<WebSocketObject>(e.Data);
            var WebSocketData = JsonConvert.DeserializeObject<WebSocketContent>(WebSocketRawData?.content);
            var type = WebSocketRawData?.type;

            switch (type)
            {
                case "friend-online":
                    ModConsole.Log($"[Friends] '{WebSocketData.user.displayName}' -> Came Online");
                    break;
                case "friend-active":
                    ModConsole.Log($"[Friends] '{WebSocketData.user.displayName}' -> Status: {WebSocketData.user.state} - '{WebSocketData.user.status}'");
                    break;
                case "friend-location":
                    if (WebSocketData.location.Equals("private"))
                    {
                        ModConsole.Log($"[Friends] '{WebSocketData.user.displayName}' -> Went to a private location");
                    }
                    else
                    {
                        ModConsole.Log($"[Friends] '{WebSocketData.user.displayName}' -> Went to {WebSocketData.world.name} - {WebSocketData.location}");
                    }
                    break;
                case "user-location":
                    break;
                default:
                    ModConsole.Log($"[API] Unhandled Type: {type}");
                    break;
            }

            //ModConsole.Log($"[API] {e.Data}");
        }


        private static void OnOpened(object sender, EventArgs e)
        {
            ModConsole.Log("[API] Connected To WebSocket!");
            //Helper().Start();
        }

        internal override void OnMasterClientSwitched(Photon.Realtime.Player player)
        {
            if (!WorldUtils.IsInWorld) return;

            PopupUtils.QueHudMessage($"'{player.field_Public_Player_0.GetDisplayName()}' is now the room master.");
        }

        internal override void OnRoomJoined()
        {
            ModConsole.Log("You joined a room.");
        }

        internal override void OnRoomLeft()
        {
            ModConsole.Log("You left a room.");
        }

        internal override void OnPlayerJoined(Player player)
        {
            return;
            if (player == null) throw new ArgumentNullException();
            if (player.gameObject.GetComponent<CheetoNameplate>() == null) player.gameObject.AddComponent<CheetoNameplate>();
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            Player player = PlayerUtils.GetPlayer();
            if (player.gameObject.GetComponent<SitOnPlayer>() == null) player.gameObject.AddComponent<SitOnPlayer>();

            if (Bools.IsDeveloper && !DoOnce)
            {
                PopupUtils.QueHudMessage("Developer Mode!");
                DoOnce = true;
            }
        }
    }
}