using AstroClient.ClientActions;

namespace AstroClient.Constants
{
    using System.Collections.Generic;
    using UnityEngine;

    internal class GlobalLists : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
        }

    
        internal static List<Renderer> RenderObjects { get; } = new List<Renderer>();

        private void OnRoomLeft() => RenderObjects.Clear();
    }
}