namespace AstroClient.Cheetos
{
    using AstroClient.Streamer;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;

    internal static class ForceClone
    {
        internal static void ClonePlayer()
        {
            var player = QuickMenuUtils.SelectedPlayer;

            if (player != null)
            {
                MiscUtils.ChangeAvatar(player.GetApiAvatar().id);
            }
        }
    }
}