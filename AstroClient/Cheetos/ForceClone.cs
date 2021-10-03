namespace AstroClient.Cheetos
{
    using AstroClient.Streamer;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;

    internal static class ForceClone
    {
        internal static void ClonePlayer()
        {
            if (!StreamerProtector.IsExploitsAllowed) { ModConsole.Error("Force Clone Failed, A Streamer Is Present!"); return; }
            var player = QuickMenuUtils.SelectedPlayer;

            if (player != null)
            {
                MiscUtils.ChangeAvatar(player.GetApiAvatar().id);
            }
        }
    }
}