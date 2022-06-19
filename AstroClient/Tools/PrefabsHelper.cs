using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.Tools
{
    internal class PrefabsHelper : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (SceneUtils.DynamicPrefabs.Length != 0)
            {
                foreach (var prefab in SceneUtils.DynamicPrefabs)
                {
                    prefab.GetOrAddComponent<RegisterAsPrefab>();
                }

            }
        }
    }
}
