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

        public override void VRChat_OnUiManagerInit()
        {
            var infoBar = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar");
            var infobartext = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/EarlyAccessText").GetComponent<Text>();

            infobartext.color = new Color(1, 0, 1, 1);

            infoBar.transform.localPosition -= new Vector3(0, 110, 0);
            infobartext.text = "AstroClient";

            _ = MelonCoroutines.Start(Connect());
        }
        internal static WebSocket ws;

        private static IEnumerator Connect()
        {
            while (APIUser.CurrentUser == null) yield return new WaitForSeconds(0.1F);
            while (string.IsNullOrWhiteSpace(ApiCredentials.authToken)) yield return new WaitForSeconds(0.1F);
            try
            {
                Console.WriteLine($"AuthCookie: " + ApiCredentials.authToken);
                var protocols = new Il2CppStringArray(new string[] { });
                ws = new WebSocketSharp.WebSocket("wss://pipeline.vrchat.cloud/?authToken=" + ApiCredentials.authToken);
                ws.OnOpen += OnOpened;
                ws.OnMessage += HandleMessage;
                ws.Connect();
            }
            catch
            {
                Console.WriteLine("[ApiExtensions] VRChat Pipeline WebSocket Error");
            }

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
                case "friend-update":
                    //ModConsole.Log($"[Friends] '{WebSocketData.user.displayName}' -> Status: {WebSocketData.user.state} - '{WebSocketData.user.status}'");
                    break;
                case "friend-offline":
                    ModConsole.Log($"[Friends] '{WebSocketData.user.displayName}' -> Went Offline");
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
                case "friend-delete":
                    ModConsole.Log($"[Friends] '{WebSocketData.user.displayName}' deleted you");
                    CheetosHelpers.SendHudNotification($"[Friends] '{WebSocketData.user.displayName}' deleted you");
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

        public override void OnMasterClientSwitched(Photon.Realtime.Player player)
        {
            if (!WorldUtils.IsInWorld) return;

            CheetosHelpers.SendHudNotification($"'{player.field_Public_Player_0.GetDisplayName()}' is now the room master.");
        }

        public override void OnRoomJoined()
        {
            ModConsole.Log("You joined a room.");
        }

        public override void OnRoomLeft()
        {
            ModConsole.Log("You left a room.");
        }

        public override void OnPlayerJoined(Player player)
        {
            if (!ModDetector.FindMods.IsNotoriousPresent && AstroClient.ConfigManager.UI.NamePlates)
            {
                player.gameObject.AddComponent<NamePlates>();
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            return;
            Player player = PlayerUtils.GetPlayer();
            if (player.gameObject.GetComponent<SitOnPlayer>() == null)
            {
                player.gameObject.AddComponent<SitOnPlayer>();
            }

            if (Bools.IsDeveloper)
            {
                if (!DoOnce)
                {
                    CheetosHelpers.SendHudNotification("Developer Mode!");
                    DoOnce = true;
                }
            }
        }

        public override void OnPlayerSelected(Player player)
        {
            ModConsole.Log($"Player Selected: {player.name}");
        }
    }
}