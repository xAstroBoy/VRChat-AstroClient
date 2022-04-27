using AstroClient.ClientActions;

namespace AstroClient.PlayerList.Entries
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using VRC;

    [RegisterComponent]
    public class PlayerListHeaderEntry : EntryBase
    {
        public PlayerListHeaderEntry(IntPtr obj0) : base(obj0) { }

        [HideFromIl2Cpp]
        public override string Name => "PlayerList Header";
		
        [HideFromIl2Cpp]
        public override void Init(object[] parameters = null)
        {
            ClientEventActions.Event_OnPlayerJoin += OnPlayerJoined;
            ClientEventActions.Event_OnPlayerLeft += OnPlayerLeft;
        }

        [HideFromIl2Cpp]
        private void OnPlayerJoined(Player player)
        {
            textComponent.text = OriginalText.Replace("{playercount}", PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count.ToString());
        }

        private void OnPlayerLeft(Player player)
        {
            textComponent.text = OriginalText.Replace("{playercount}", PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count.ToString());
        }
    }
}
