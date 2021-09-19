namespace AstroClient
{
    using AstroLibrary.Utility;
    using Il2CppSystem.Text;
    using System.Linq;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.Management;
    using VRC.SDKBase;
    using static AstroLibrary.Extensions.PlayerExtensions;

    public class PlayerListData
    {
        public Photon.Realtime.Player PhotonPlayer { get; private set; }

        public Player Player { get; private set; }

        public APIUser APIUser { get; private set; }

        public VRCPlayerApi PlayerAPI { get; private set; }

        public PlayerNet PlayerNet { get; private set; }

        public VRCPlayer VRCPlayer { get; private set; }

        public string UserID => PhotonPlayer.GetUserID();

        public string Name => PhotonPlayer.GetDisplayName();

        public bool IsMaster => Player != null && Player.GetIsMaster();

        public bool IsSelf => Player != null && Player.GetUserID().Equals(Utils.LocalPlayer.GetPlayer().GetUserID());

        public bool IsFriend => APIUser != null && APIUser.GetIsFriend();

        public bool IsInVR => Player != null && Player.GetIsInVR();

        public bool IsDanger => VRCPlayer != null && VRCPlayer.GetIsDANGER();

        public string Rank => APIUser != null ? APIUser.GetRank() : string.Empty;

        public RankType RankType => APIUser != null ? APIUser.GetRankEnum() : RankType.VeryNegativeTrust;

        public Color RankColor => APIUser != null ? APIUser.GetRankColor() : Color.white;

        public Color Color
        {
            get
            {
                if (GetIsInvisible())
                {
                    return Color.white;
                }
                else if (IsDanger)
                {
                    return Color.red;
                }
                else
                {
                    return RankColor;
                }
            }
        }

        public string Prefix
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

        public bool GetIsInvisible()
        {
            return Player == null || !WorldUtils.Players.Any(p => p.GetUserID().Equals(Player.GetUserID()));
        }

        public PlayerListData(Photon.Realtime.Player photonPlayer)
        {
            PhotonPlayer = photonPlayer;
            Player = photonPlayer?.GetPlayer();
            APIUser = Player?.GetAPIUser();
            PlayerAPI = Player?.GetVRCPlayerApi();
            PlayerNet = Player?.GetPlayerNet();
            VRCPlayer = Player?.GetVRCPlayer();
        }
    }
}