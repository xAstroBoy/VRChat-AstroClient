using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.Core;
using VRC.UI;

namespace Blaze.Utils
{
    class SocialMenuUtils
    {
        internal static void RefreshSocial()
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

		internal static APIUser GetAPIUserFromSM()
        {
			return UnityEngine.Object.FindObjectOfType<PageUserInfo>().field_Public_APIUser_0;
        }

		internal static ApiWorld GetApiWorldFromSM()
        {
			return UnityEngine.Object.FindObjectOfType<PageWorldInfo>().field_Private_ApiWorld_0;
        }
    }
}
