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
    public class ModerationRevealer : AstroMonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        public ModerationRevealer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        private static string BlockedText { get; } = "Blocked You";
        private static string MutedText { get; } = "Muted You";

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

            if (AssignedPlayer.GetAPIUser().HasBlockedYou())
            {
                GenerateBlockedTag();
            }

            if (AssignedPlayer.GetAPIUser().HasMutedYou())
            {
                GenerateMutedTag();
            }
        }
        private SingleTag MutedTag;
        private void GenerateMutedTag()
        {
            if (MutedTag == null)
            {
                MutedTag = AssignedPlayer.AddComponent<SingleTag>();
                if (MutedTag != null)
                {
                    MutedTag.SystemColor_SetBackgroundColor(System.Drawing.Color.Orange);
                    MutedTag.Text = MutedText;
                }

            }
        }


        private SingleTag BlockedTag;
        private void GenerateBlockedTag()
        {
            if (BlockedTag == null)
            {
                BlockedTag = AssignedPlayer.AddComponent<SingleTag>();
                if (BlockedTag != null)
                {
                    MutedTag.SystemColor_SetBackgroundColor(System.Drawing.Color.Red);
                    BlockedTag.Text = BlockedText;
                }
            }
        }

        internal override void OnPlayerLeft(Player player)
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

            }
            catch { }
        }

        internal override void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()))
            {
                GenerateBlockedTag();
            }

        }
        internal override void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()))
            {
                if (BlockedTag != null)
                {
                    Destroy(BlockedTag);
                }
            }

        }

        internal override void OnPlayerMutedYou(Photon.Realtime.Player player)
        {
            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()))
            {
                GenerateMutedTag();
            }
        }

        internal override void OnPlayerUnmutedYou(Photon.Realtime.Player player)
        {
            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()))
            {
                if (MutedTag != null)
                {
                    Destroy(MutedTag);
                }
            }
        }


        internal Player AssignedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}