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
    public class ModerationRevealer : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

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
                        ClientEventActions.OnPlayerBlockedYou += OnPlayerBlockedYou;
                        ClientEventActions.OnPlayerUnblockedYou += OnPlayerUnblockedYou;
                        ClientEventActions.OnPlayerMutedYou += OnPlayerMutedYou;
                        ClientEventActions.OnPlayerUnmutedYou += OnPlayerUnmutedYou;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerLeft -= OnPlayerLeft;
                        ClientEventActions.OnPlayerBlockedYou -= OnPlayerBlockedYou;
                        ClientEventActions.OnPlayerUnblockedYou -= OnPlayerUnblockedYou;
                        ClientEventActions.OnPlayerMutedYou -= OnPlayerMutedYou;
                        ClientEventActions.OnPlayerUnmutedYou -= OnPlayerUnmutedYou;
                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            Destroy(this);
        }

        public ModerationRevealer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        private Color MutedColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.Orange.ToUnityEngineColor();

        private Color BlockedColor { [HideFromIl2Cpp] get; }= System.Drawing.Color.Red.ToUnityEngineColor();
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
            HasSubscribed = true;
            if (AssignedPlayer.GetVRCPlayerApi().isLocal)
            {
                Destroy(this);
            }

            if (AssignedPlayer.GetAPIUser().HasBlockedYou())
            {
                GetBlockedTag();
            }

            if (AssignedPlayer.GetAPIUser().HasMutedYou())
            {
                GetMutedTag();
            }
        }
        private SingleTag MutedTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private void GetMutedTag()
        {

            if (MutedTag == null)
            {
                MutedTag = gameObject.AddComponent<SingleTag>();
            }

            MiscUtils.DelayFunction(0.5f, () =>
            {

                if (MutedTag != null)
                {
                    MutedTag.Text = "Muted You";
                    MutedTag.BackGroundColor = MutedColor;
                    MutedTag.ShowTag = true;
                }
            });
        }

        private SingleTag BlockedTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private void GetBlockedTag()
        {
            int debug = 0;
            try
            {
                debug = 1;
                if (BlockedTag == null)
                {
                    BlockedTag = gameObject.AddComponent<SingleTag>();
                }
                debug = 2;
                MiscUtils.DelayFunction(0.5f, () =>
                {
                    debug = 3;
                    if (BlockedTag != null)
                    {

                        BlockedTag.Text = "Blocked You";
                        debug = 4;
                        BlockedTag.BackGroundColor = BlockedColor;
                        debug = 5;
                        BlockedTag.ShowTag = true;
                        debug = 6;
                    }
                });
            }
            catch 
            {
                //Log.Error($"Error at debug {debug}");
                //Log.Exception(e);
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
                    Destroy(BlockedTag);
                }
                if (MutedTag != null)
                {
                    Destroy(MutedTag);
                }
                HasSubscribed = false;

            }
            catch { }
        }

        private void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            if (AssignedPlayer.GetAPIUser().HasBlockedYou())
            {
                GetBlockedTag();
            }

        }
        private void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
            if (!AssignedPlayer.GetAPIUser().HasBlockedYou())
            {
                if (BlockedTag != null)
                {
                    BlockedTag.ShowTag = false;
                    Destroy(BlockedTag);
                }
            }

        }

        private void OnPlayerMutedYou(Photon.Realtime.Player player)
        {
            if (AssignedPlayer.GetAPIUser().HasMutedYou())
            {
                GetMutedTag();
            }
        }

        private void OnPlayerUnmutedYou(Photon.Realtime.Player player)
        {
            if (!AssignedPlayer.GetAPIUser().HasMutedYou())
            {
                Destroy(MutedTag);
            }
        }


        internal Player AssignedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}