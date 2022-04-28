using AstroClient.ClientActions;

namespace AstroClient.PlayerList.Entries
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using VRC.Core;

    [RegisterComponent]
    public class WorldNameEntry : EntryBase
    {
        public WorldNameEntry(IntPtr obj0) : base(obj0) { }

        [HideFromIl2Cpp]
        public override string Name => "World Name";

        [HideFromIl2Cpp]
        public override void Init(object[] parameters = null)
        {
            ClientEventActions.OnEnterWorld += OnEnterWorld;
        }

        [HideFromIl2Cpp]
        private void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            textComponent.text = OriginalText.Replace("{worldname}", world.name);
        }
    }
}
