namespace AstroClient.Cheetos
{
    using xAstroBoy.Utility;

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