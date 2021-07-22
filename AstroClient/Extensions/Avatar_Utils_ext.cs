namespace AstroClient.Extensions
{
	using AstroLibrary.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public static class Avatar_Utils_ext
	{

		public static bool isAvatarID(this string id)
		{
			return id.isNotNullOrEmptyOrWhiteSpace() && id.StartsWith("avtr_");
		}


	}
}
