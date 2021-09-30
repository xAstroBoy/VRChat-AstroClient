namespace AstroClient.Variables
{
    using System.Collections.Generic;
    using UnityEngine;

    internal class GlobalLists : GameEvents
    {
        internal static List<Renderer> RenderObjects { get; } = new List<Renderer>();

        internal override void OnSceneLoaded(int buildIndex, string sceneName) => RenderObjects.Clear();
    }
}