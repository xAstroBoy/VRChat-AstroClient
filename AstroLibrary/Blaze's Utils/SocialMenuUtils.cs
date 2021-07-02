namespace Blaze.Utils
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using VRC.Core;
	using VRC.UI;

	class SocialMenuUtils
    {
        public static void RefreshSocial()
        {
			using (IEnumerator<UiUserList> enumerator = Resources.FindObjectsOfTypeAll<UiUserList>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UiUserList uiUserList = enumerator.Current;
					try
					{
						uiUserList.Method_Public_Void_0();
						uiUserList.Method_Public_Void_1();
						uiUserList.Method_Public_Void_2();
					}
					catch (Exception ex)
					{
						Logs.Msg(ex.ToString(), ConsoleColor.Red);
					}
				}
				return;
			}
		}

		public static APIUser GetAPIUserFromSM()
        {
			return UnityEngine.Object.FindObjectOfType<PageUserInfo>().field_Public_APIUser_0;
        }

		public static ApiWorld GetApiWorldFromSM()
        {
			return UnityEngine.Object.FindObjectOfType<PageWorldInfo>().field_Private_ApiWorld_0;
        }
    }
}
