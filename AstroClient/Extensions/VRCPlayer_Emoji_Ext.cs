namespace AstroLibrary.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public static class VRCPlayer_Emoji_Ext
	{

		public static float Get_Emoji_Cooldown(this VRCPlayer instance)
		{
			return instance.field_Private_Single_4;
		}

		public static void Set_Emoji_Cooldown(this VRCPlayer instance, float value)
		{
			if (instance != null)
			{
				instance.field_Private_Single_4 = value;
			}
		}
	}
}
