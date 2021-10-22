namespace Blaze.Utils
{
    using AstroLibrary.Console;
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
                        ModConsole.Exception(ex.ToString());
                    }
                }
                return;
            }
        }

        public static APIUser APIUserFromSM => UnityEngine.Object.FindObjectOfType<PageUserInfo>().field_Public_APIUser_0;

        public static ApiWorld ApiWorldFromSM => UnityEngine.Object.FindObjectOfType<PageWorldInfo>().field_Private_ApiWorld_0;
    }
}
