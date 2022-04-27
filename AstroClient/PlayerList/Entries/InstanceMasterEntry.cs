using AstroClient.ClientActions;

namespace AstroClient.PlayerList.Entries
{
    using System;
    using System.Collections;
    using ClientAttributes;
    using MelonLoader;
    using Photon.Realtime;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class InstanceMasterEntry : EntryBase
    {
        public InstanceMasterEntry(IntPtr obj0) : base(obj0) { }

        [HideFromIl2Cpp]
        public override string Name => "Instance Master";

        void Start()
        {
            ClientEventActions.Event_OnPlayerJoin += OnPlayerJoined;
            ClientEventActions.Event_OnMasterClientSwitched += OnMasterClientSwitched;
        }

        private void OnPlayerJoined(VRC.Player player)
        {
            // This will handle getting the master on instance join
            if (player.prop_VRCPlayerApi_0 != null && player.prop_VRCPlayerApi_0.isMaster)
            {
                textComponent.text = OriginalText.Replace("{instancemaster}", player.prop_APIUser_0.displayName);
            }
        }

        private void OnMasterClientSwitched(Player player)
        {
            MelonCoroutines.Start(GetOnMasterChanged(player));
        }
        [HideFromIl2Cpp]
        private IEnumerator GetOnMasterChanged(Player player)
        {
            while (player.field_Public_Player_0 == null)
                yield return null;

            textComponent.text = OriginalText.Replace("{instancemaster}", player.field_Public_Player_0.prop_APIUser_0.displayName);
            yield break;
        }
    }
}
