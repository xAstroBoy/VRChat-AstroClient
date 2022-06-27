using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AstroClient.AstroMonos.Components.UI.SingleTag;
using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.Streamer;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using VRC;
using WebSocketSharp;
using WebSocketSharp.Net;
using Color = System.Drawing.Color;
using Random = System.Random;

namespace AstroClient.SnaxyTagsV3;

internal class SnaxyTagsSystem : AstroEvents
{
    private static readonly Random random = new Random();

    private static WebSocket SnaxySocket { get; set; } = null;

    private static string SnaxyKey { get; set; } = "";

    private static string SnaxyConsole { get; set; } = "";

    internal override void RegisterToEvents()
    {
        ClientEventActions.OnApplicationStart += ApplicationStart;
        ClientEventActions.OnPlayerJoin += OnPlayerJoin;
        ClientEventActions.OnPlayerLeft += OnPlayerLeft;
        ClientEventActions.OnRoomLeft += RoomLeft;

    }

    private void RoomLeft()
    {
        CurrentSnaxyTags.Clear(); 
    }

    private void ApplicationStart()
    {
        if (ConfigManager.General.SpoofedUserID.IsNullOrEmptyOrWhiteSpace())
        {
            ConfigManager.General.SpoofedUserID = UserIDGenerator();
            Log.Debug($"Generated UserID For SnaxyTag API : {ConfigManager.General.SpoofedUserID}");

        }
        Task.Run(InitiateWebsocket);
    }

    internal static string RandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    /// <summary>
    /// Fools the SnaxyTag Websocket to be a random user.
    /// </summary>
    /// <returns></returns>
    internal static string UserIDGenerator()
    {
        var result = new StringBuilder();
        // Generate a user ID
        result.Append("usr_");
        result.Append(RandomString(8));
        result.Append("-");
        result.Append(RandomString(4));
        result.Append("-");
        result.Append(RandomString(4));
        result.Append("-");
        result.Append(RandomString(4));
        result.Append("-");
        result.Append(RandomString(12));
        return result.ToString();
    }

    internal static string GetGroupSaveGetPermissions(string ApiUser, string Key)
    {
        ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
        byte[] bytes = aSCIIEncoding.GetBytes(Key);
        byte[] bytes2 = aSCIIEncoding.GetBytes(ApiUser);
        return BitConverter.ToString(new HMACSHA256(bytes).ComputeHash(bytes2)).Replace("-", "").ToLower();
    }






    private IEnumerator WebsocketTag(string text)
    {
        yield return null;
        if (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null || string.IsNullOrEmpty(text))
        {
            yield break;
        }
        var Command = text.Split(',')[0];
        if (Command != "gotTag")
        {
            var Content = Encoding.UTF8.GetString(Convert.FromBase64String(text.Split(',')[1]));

            if (Command == "recieveNotification" && Content.IsNotNullOrEmptyOrWhiteSpace()) 
            {
                PopupUtils.QueHudMessage(Content);
            }
            Log.Debug($"[SnaxyTag] Command: {Command}, Content {Content}");
        }
        else
        {
            var UserID = text.Split(',')[1];
            var Content = Encoding.UTF8.GetString(Convert.FromBase64String(text.Split(',')[2]));
            if ((from mbox in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray()
                    where GetGroupSaveGetPermissions(mbox.GetAPIUser().GetUserID(), SnaxyKey) == UserID
                    select mbox).Count() != 1)
            {
                yield break;
            }
            Player player = (from mbox in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray()
                where GetGroupSaveGetPermissions(mbox.GetAPIUser().GetUserID(), SnaxyKey) == UserID
                select mbox).First();
            if (player.GetAPIUser() == null)
            {
                yield break;
            }
            Log.Debug($"[SnaxyTag] Command: {Command}, User : {player.GetAPIUser().GetDisplayName()} , Content : {Content}");

            if (Content.IsNullOrEmptyOrWhiteSpace()|| Content.Length < 1)
            {
                RemoveSnaxyTag(player);
            }
            else if (Content != "none" || Content.Length > 0)
            {
                var TagText = Content;
                SetSnaxyTag(player, CheckTagText(TagText));
            }
        }
    }

    private static string CheckTagText(string TagText)
    {
        if (TagText.Contains("<color=#000000>"))
        {
            TagText = TagText.Replace("<color=#000000>", "<color=white>");
        }
        if (TagText.Contains("<color=black>"))
        {
            TagText = TagText.Replace("<color=black>", "<color=white>");
        }

        return TagText;
    }

    // Sets tags into a dictionary
    private static void SetSnaxyTag(Player player, string text)
    {
        if (player != null)
        {
            var UserID = player.GetAPIUser().GetUserID();
            
            if (text.isMatchWholeWord("Streamer"))
            {
                // if the snaxy says is a streamer, but yet we have it already flagged, we can ignore it as we have a similiar tag saying that already.
                if (StreamerIdentifier.IsAStreamer(UserID))
                {
                    return;
                }
            }
            if (CurrentSnaxyTags.ContainsKey(UserID))
            {
                CurrentSnaxyTags[UserID].Text = text;
            }
            else
            {
                var tag = player.AddSingleTag(text, Color.Black.ToUnityEngineColor());
                CurrentSnaxyTags.Add(UserID, tag);
            }
        }
    }

    private static void RemoveSnaxyTag(Player player)
    {
        if (player != null)
        {
            var UserID = player.GetAPIUser().GetUserID();
            if (CurrentSnaxyTags.ContainsKey(UserID))
            {
                var tag = CurrentSnaxyTags[UserID];
                tag.DestroyMeLocal();
                CurrentSnaxyTags.Remove(UserID);
            }
        }
    }


    private void InitiateWebsocket()
    {
        SnaxySocket = new WebSocket("ws://totallynotaipleaktomyvps.nulls.sbs:81");
        SnaxySocket.SetCookie(new Cookie("uid", ConfigManager.General.SpoofedUserID));
        SnaxySocket.SetCookie(new Cookie("melonversion", (string)typeof(MelonLoader.BuildInfo).GetField("Version").GetValue(null)));
        SnaxySocket.Log.Output += OnOutput;
        SnaxySocket.OnError -= OnError;
        SnaxySocket.OnClose += OnClose;
        SnaxySocket.OnMessage += OnMessage;
        SnaxySocket.OnOpen += OnOpen;
        SnaxySocket.Connect();

    }

    private void OnOpen(object sender, EventArgs e)
    {
        Log.Write("Connected to SnaxyTag!.");
    }

    private void OnOutput(LogData arg1, string arg2)
    {
        Log.Debug($"[SnaxyTag] Logger : {arg2}");
    }

    private void OnError(object sender, ErrorEventArgs e)
    {
        Log.Write($"[SnaxyTag] Connection lost , Reason : {e.Message}!");
        SnaxySocket = null;
        InitiateWebsocket();
    }


    private void OnClose(object sender, CloseEventArgs closeEventArgs)
    {

        Log.Write($"[SnaxyTag] Connection lost , Reason : {closeEventArgs.Reason} !");
        SnaxySocket = null;
        InitiateWebsocket();

    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        string text = e.Data.ToString();
        var Command = text.Split(',')[0];
        var Content = Encoding.UTF8.GetString(Convert.FromBase64String(text.Split(',')[1]));
        //Log.Write($"Snaxy OnMessage : Command : {Command}, : {Content}");


        if (Command == "getKey" && SnaxyKey != Content)
        {
            //Log.Write($"[SnaxyTag] : Got key from socket. {Content}");
            SnaxyKey = Content;
            if (SnaxySocket != null && VRCPlayer.field_Internal_Static_VRCPlayer_0 != null)
            {
                foreach (Player item in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                {
                    SnaxySocket.Send("getUser," + GetGroupSaveGetPermissions(item.GetAPIUser().GetUserID(), SnaxyKey));
                }
            }
        }
        if (text.Split(',')[0] == "gotConsoleMsgName" && SnaxyConsole != Content)
        {

            SnaxyConsole = Content;
            Log.Write($"[SnaxyTag] Console :{SnaxyConsole}");
        }
        if (text.Split(',')[0] == "OutdatedMelons")
        {
            Log.Write($"[SnaxyTag] :{Content}");
        }
        MelonCoroutines.Start(WebsocketTag(text));
    }
    private void OnPlayerJoin(Player player)
    {
        if (SnaxySocket != null)
        {
            var Message = GetGroupSaveGetPermissions(player.GetAPIUser().GetUserID(), SnaxyKey);
            //Log.Write($"[SnaxyTag] : Sending Request getUser , Message : {Message}");
            SnaxySocket.Send("getUser," + Message);
        }
    }
    private void OnPlayerLeft(Player player)
    {
        var user = player.GetAPIUser().GetUserID();
        if(CurrentSnaxyTags.ContainsKey(user))
        {
            var tag = CurrentSnaxyTags[user];
            if(tag != null)
            {
                tag.DestroyMeLocal();
            }
            CurrentSnaxyTags.Remove(user);
        }
    }

    private static Dictionary<string, SingleTag> CurrentSnaxyTags = new(StringComparer.OrdinalIgnoreCase);

}