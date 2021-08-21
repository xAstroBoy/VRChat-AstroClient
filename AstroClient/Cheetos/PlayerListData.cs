namespace AstroClient
{
	using AstroLibrary.Extensions;
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

        public bool IsSelf => Player != null && Player.UserID().Equals(Utils.LocalPlayer.GetPlayer().UserID());

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
                    stringBuilder.Append("<color=silver>[VR]</color>");
                }
                else
                {
                    stringBuilder.Append("<color=silver>[PC]</color>");
                }

                if (IsDanger)
                {
                    stringBuilder.Append("<color=pink>[DANGER]</color>");
                }

                if (IsMaster)
                {
                    stringBuilder.Append("<color=cyan>[IM]</color>");
                }

                if (IsFriend)
                {
                    stringBuilder.Append("<color=green>[F]</color>");
                }

				if (ModerationManager.field_Private_Static_ModerationManager_0.GetIsBlockedEitherWay(UserID))
				{
					stringBuilder.Append("<color=red>[B]</color>");
				}

				return $"{stringBuilder.ToString()}\n";
            }
        }

        public bool GetIsInvisible()
        {
			return Player == null || !WorldUtils.Get_Players().Any(p => p.UserID().Equals(Player.UserID()));
		}

        public PlayerListData(Photon.Realtime.Player photonPlayer)
        {
            PhotonPlayer = photonPlayer;
            Player = photonPlayer.GetPlayer();
            APIUser = Player.GetAPIUser();
            PlayerAPI = Player.GetVRCPlayerApi();
            PlayerNet = Player.GetPlayerNet();
            VRCPlayer = Player.GetVRCPlayer();
        }
    }
}