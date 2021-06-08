namespace AstroClient.Cheetos
{
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;

	public static class ForceClone
    {
        internal static void ClonePlayer()
        {
            var player = QuickMenu.prop_QuickMenu_0.SelectedPlayer();

            if (player != null)
            {
                MiscFunc.ChangeAvatar(player.GetApiAvatar().id);
            }
        }
    }
}