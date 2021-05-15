namespace AstroClient.Extensions
{
	using VRC;
	using VRC.Core;

	public static class PlayerExtensions
	{
		public static Player GetPlayer(this APIUser api)
		{
			if (WorldUtils.Get_Players() != null)
			{
				foreach (var player in WorldUtils.Get_Players())
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