namespace AstroClientCore.Variables
{
	public class GlobalVariables
	{
		private static string version = "0.0 Beta";

		public static string Version
		{
			get
			{
#if DEBUG
				return version += " Debug";
#else
				return version;
#endif
			}
		}

		public static bool IsDebug
		{
			get
			{
#if DEBUG
				return true;
#else
				return false;
#endif
			}
		}
	}
}