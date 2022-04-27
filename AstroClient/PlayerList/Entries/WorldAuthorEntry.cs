using AstroClient.ClientActions;

namespace AstroClient.PlayerList.Entries
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using VRC.Core;

    [RegisterComponent]
    public class WorldAuthorEntry : EntryBase
    {
        public WorldAuthorEntry(IntPtr obj) : base(obj) { }

        [HideFromIl2Cpp]
        public override string Name => "World Author";
        void Start()
        {
            ClientEventActions.Event_OnEnterWorld += OnEnterWorld;
        }

        [HideFromIl2Cpp]
        private void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            textComponent.text = OriginalText.Replace("{worldauthor}", world.authorName);
        }
    }
}