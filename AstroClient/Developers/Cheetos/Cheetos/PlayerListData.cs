namespace AstroClient
{
    using System.Linq;
    using AstroLibrary.Utility;
    using Il2CppSystem.Text;
    using Photon.Realtime;
    using UnityEngine;
    using VRC.Core;
    using VRC.SDKBase;
    using static AstroLibrary.Extensions.PlayerExtensions;

    internal class PlayerListData
    {
        internal Player PhotonPlayer { get; private set; }

        internal VRC.Player Player { get; private set; }

        internal APIUser APIUser { get; private set; }

        internal VRCPlayerApi PlayerAPI { get; private set; }

        internal PlayerNet PlayerNet { get; private set; }

        internal VRCPlayer VRCPlayer { get; private set; }

        internal string UserID => PhotonPlayer.GetUserID();

        internal string Name => PhotonPlayer.GetDisplayName();

        internal bool IsMaster => Player != null && Player.GetIsMaster();

        internal bool IsSelf => Player != null && Player.GetUserID().Equals(Utils.LocalPlayer.GetPlayer().GetUserID());

        internal bool IsFriend => APIUser != null && APIUser.GetIsFriend();

        internal bool IsInVR => Player != null && Player.GetIsInVR();

        internal bool IsDanger => VRCPlayer != null && VRCPlayer.GetIsDANGER();

        internal string Rank => APIUser != null ? APIUser.GetRank() : string.Empty;

        internal RankType RankType => APIUser != null ? APIUser.GetRankEnum() : RankType.VeryNegativeTrust;

        internal Color RankColor => APIUser != null ? APIUser.GetRankColor() : Color.white;

        internal Color Color
        {
            get
            {
                if (GetIsInvisible())
                {
                    return Color.white;
                }

                if (IsDanger)
                {
                    return Color.red;
                }

                return RankColor;
            }
        }

        internal string Prefix
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (GetIsInvisible())
                {
                    return "<color=silver>[INVISIBLE]\n</color>";
                }

                if (IsInVR)
                {
                    _ = stringBuilder.Append("<color=silver>[VR]</color>");
                }
                else
                {
                    _ = stringBuilder.Append("<color=silver>[PC]</color>");
                }

                if (IsDanger)
                {
                    _ = stringBuilder.Append("<color=pink>[DANGER]</color>");
                }

                if (IsMaster)
                {
                    _ = stringBuilder.Append("<color=cyan>[IM]</color>");
                }

                if (IsFriend)
                {
                    _ = stringBuilder.Append("<color=green>[F]</color>");
                }

                //if (ModerationManager.field_Private_Static_ModerationManager_0.GetIsBlockedEitherWay(UserID))
                //{
                //    _ = stringBuilder.Append("<color=red>[B]</color>");
                //}

                return $"{stringBuilder.ToString()}\n";
            }
        }

        internal bool GetIsInvisible()
        {
            return Player == null || !WorldUtils.Players.Any(p => p.GetUserID().Equals(Player.GetUserID()));
        }

        internal PlayerListData(Player photonPlayer)
        {
            PhotonPlayer = photonPlayer;
            Player = photonPlayer?.GetPhotonPlayer();
            APIUser = Player?.GetAPIUser();
            PlayerAPI = Player?.GetVRCPlayerApi();
            PlayerNet = Player?.GetPlayerNet();
            VRCPlayer = Player?.GetVRCPlayer();
        }
    }
}