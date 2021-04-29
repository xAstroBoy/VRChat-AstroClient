namespace AstroClient.extensions
{
	using VRC;
	using VRC.Core;

	public static class PlayerExtensions
	{
		public static Player GetPlayer(this APIUser api)
		{
			if (WorldUtils.GetAllPlayers0() != null)
			{
				foreach (var player in WorldUtils.GetAllPlayers0())
				{
					if (player != null)
					{
						if (player.prop_APIUser_0.id == api.id)
						{
							return player;
						}
					}
				}
			}
			return null;
		}
	}
}