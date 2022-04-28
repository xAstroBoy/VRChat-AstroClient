using AstroClient.ClientActions;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System.Collections;
    using CheetoLibrary;
    using MelonLoader;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Utility;

    internal class ModerationRevealerHelper : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerJoin += OnPlayerJoined;
        }

        private void OnPlayerJoined(Player player)
        {
            MelonCoroutines.Start(AddModerationHelper(player));
        }

        private static IEnumerator AddModerationHelper(Player player)
        {
            yield return new WaitForEndOfFrame();
            if (player != null)
            {
                player.gameObject.GetOrAddComponent<ModerationRevealer>();
            }

            yield return null;
        }

    }
}