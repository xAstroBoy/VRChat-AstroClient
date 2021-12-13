namespace AstroClient.Streamer
{
    using System.Drawing;
    using Constants;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;
    using SystemColors = Tools.Colors.SystemColors;

    internal class WorldAuthorDetector : AstroEvents
    {
        internal override void OnPlayerJoined(Player player)
        {
            if (!Bools.IsDeveloper)
            {
                return;
            }

            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (apiuser.IsWorldCreator())
                    {
                        player.AddSingleTag(Color.DarkOrange, "World Author");
                        PopupUtils.QueHudMessage($"World Author : {apiuser.displayName} Joined!");
                        ModConsole.Warning($"World Author : {apiuser.displayName} Joined!");
                    }
                }
            }
        }

        internal override void OnPlayerLeft(Player player)
        {
            if (!Bools.IsDeveloper)
            {
                return;
            }

            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (apiuser.IsWorldCreator())
                    {
                        PopupUtils.QueHudMessage($"World Author : {apiuser.displayName} Left!");
                        ModConsole.Warning($"World Author : {apiuser.displayName} Left!");
                    }
                }
            }
        }




    }
}

