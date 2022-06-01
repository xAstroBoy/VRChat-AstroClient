using AstroClient.ClientActions;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class PickupBlockerTag : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;
        internal Player AssignedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private SingleTag BlockedTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnPlayerLeft += OnPlayerLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerLeft -= OnPlayerLeft;
                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            Destroy(this);
        }

        public PickupBlockerTag(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        private void Start()
        {
            if (AssignedPlayer == null)
            {
                AssignedPlayer = GetComponent<Player>();
                if (AssignedPlayer == null)
                {
                    Destroy(this);
                }
            }
            if (AssignedPlayer.GetVRCPlayerApi().isLocal)
            {
                Destroy(this);
            }
            HasSubscribed = true;
            Log.Write($"Added Block for Player {AssignedPlayer.GetDisplayName()}  from using Pickups.");
            SpawnTag();

        }
        internal void SpawnTag()
        {
            if (AssignedPlayer != null)
            {
                if (BlockedTag == null)
                {
                    BlockedTag = AssignedPlayer.AddSingleTag("Pickup Blocked", System.Drawing.Color.Orange);
                }

            }
        }
        private void OnPlayerLeft(Player player)
        {
            if (AssignedPlayer.Equals(player)) Destroy(this);
        }


        private void OnDestroy()
        {
            try
            {
                if (BlockedTag != null)
                {
                    BlockedTag.DestroyMeLocal(true);
                }
                Log.Write($"Removed Block for Player {AssignedPlayer.GetDisplayName()}  from using Pickups.");
                HasSubscribed = false;

            }
            catch { }
        }




    }
}