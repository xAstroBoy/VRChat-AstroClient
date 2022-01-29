namespace AstroClient.Constants
{
    using System.Collections.Generic;
    using UnityEngine;

    internal class GlobalLists : AstroEvents
    {
        internal static List<Renderer> RenderObjects { get; } = new List<Renderer>();

        internal override void OnRoomLeft() => RenderObjects.Clear();
    }
}