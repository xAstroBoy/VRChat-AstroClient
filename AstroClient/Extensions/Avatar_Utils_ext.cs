namespace AstroClient.Extensions
{
	using AstroLibrary.Extensions;

	public static class Avatar_Utils_ext
	{
		public static bool isAvatarID(this string id)
		{
			return id.IsNotNullOrEmptyOrWhiteSpace() && id.StartsWith("avtr_");
		}
	}
}
