﻿namespace AstroClient.Extensions
{
	using System.Linq;
	using VRC;
	using VRC.Core;

	public static class PlayerExtensions
	{
		public static Player GetPlayer(this APIUser api)
		{
			if (WorldUtils.Get_Players() != null)
			{
				foreach (Player player in WorldUtils.Get_Players().Where(player => player != null).Where(player => player.prop_APIUser_0.id == api.id))
				{
					return player;
				}
			}
			return null;
		}
	}
}