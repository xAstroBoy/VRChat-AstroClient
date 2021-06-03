namespace AstroClient
{
	using DayClientML2.Utility.Extensions;
	using UnityEngine;
	using VRC;
	using VRC.Core;
	using VRC.SDKBase;
	using static DayClientML2.Utility.Extensions.PlayerExtensions;

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

		public bool IsSelf => Player != null && Player.UserID().Equals(LocalPlayerUtils.GetSelfPlayer().UserID());

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
				if (IsInvisible)
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

		public string Prefix
		{
			get
			{
				var value = string.Empty;

				if (IsInvisible)
				{
					return "<color=silver>[INVISIBLE]\n</color>";
				}

				if (IsInVR)
				{
					value += "<color=silver>[VR]</color>";
				}
				else
				{
					value += "<color=silver>[PC]</color>";
				}

				if (IsDanger)
				{
					value += "<color=pink>[DANGER]</color>";
				}

				if (IsMaster)
				{
					value += "<color=cyan>[IM]</color>";
				}

				if (IsFriend)
				{
					value += "<color=green>[F]</color>";
				}

				if (value != string.Empty)
				{
					value += "\n";
				}

				return value;
			}
		}

		public bool IsInvisible
		{
			get
			{
				var players = WorldUtils.Get_Players();

				foreach (var o in players)
				{
					if (o.UserID().Equals(PhotonPlayer.GetUserID()))
					{
						return false;
					}
				}

				return true;
			}
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