namespace AstroClient.Cheetos
{
	using AstroLibrary.Utility;

	public static class ForceClone
    {
        internal static void ClonePlayer()
        {
            var player = QuickMenuUtils.GetSelectedPlayer();

            if (player != null)
            {
                MiscUtils.ChangeAvatar(player.GetApiAvatar().id);
            }
        }
    }
}