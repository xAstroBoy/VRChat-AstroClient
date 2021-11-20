namespace AstroClient.AstroMonos.Components.Tools
{
    using CheetoLibrary;
    using VRC;
    using xAstroBoy.Utility;

    internal class ModerationRevealerHelper : AstroEvents
    {
        internal override void OnPlayerJoined(Player player)
        {
            if (player != null && !player.GetAPIUser().IsSelf)
            {
                player.gameObject.GetOrAddComponent<ModerationRevealer>();
            }
        }


    }
}