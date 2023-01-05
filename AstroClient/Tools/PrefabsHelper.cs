using System;
using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

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
            if (SceneUtils.DynamicPrefabs.Count != 0)
            {
                for (int i = 0; i < SceneUtils.DynamicPrefabs.Count; i++)
                {
                    var prefab = SceneUtils.DynamicPrefabs[i];
                    prefab.GetOrAddComponent<RegisterAsPrefab>();
                }
            }
        }
    }
}
