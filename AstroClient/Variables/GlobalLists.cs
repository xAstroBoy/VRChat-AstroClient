namespace AstroClient.Variables
{
    using System.Collections.Generic;
    using UnityEngine;

    public class GlobalLists : GameEvents
    {
        public static List<Renderer> RenderObjects { get; } = new List<Renderer>();

        public override void OnSceneLoaded(int buildIndex, string sceneName) => RenderObjects.Clear();
    }
}