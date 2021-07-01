namespace Blaze.Utils
{
	using MelonLoader;
	using System;
	using System.Linq;
	using System.Reflection;
	using UnhollowerRuntimeLib.XrefScans;
	using UnityEngine;
	using VRC.Core;
	using VRC.UI;

	internal static class VRCUiManagerUtils
    {
        internal static VRCUiPage ShowScreen(this VRCUiManager Instance, VRCUiPage page)
        {
            return ShowScreenActionAction(page);
        }

        internal static void ShowScreen(this VRCUiManager Instance, string pageName)
        {
            VRCUiPage vrcuiPage = Instance.GetPage(pageName);
            if (vrcuiPage != null)
            {
                Instance.ShowScreen(vrcuiPage);
            }
        }

        internal static VRCUiPage GetPage(this VRCUiManager Instance, string screenPath)
        {
            GameObject gameObject = GameObject.Find(screenPath);
            VRCUiPage vrcuiPage = null;
            if (gameObject != null)
            {
                vrcuiPage = gameObject.GetComponent<VRCUiPage>();
                if (vrcuiPage == null)
                {
                    MelonLogger.Error("Screen Not Found - " + screenPath);
                }
            }
            else
            {
                MelonLogger.Warning("Screen Not Found - " + screenPath);
            }
            return vrcuiPage;
        }

        internal static ShowScreenAction ShowScreenActionAction
        {
            get
            {
                if (ourShowScreenAction != null)
                {
                    return ourShowScreenAction;
                }
                MethodInfo method = typeof(VRCUiManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single(delegate (MethodInfo it)
                {
                    if (it.ReturnType == typeof(VRCUiPage) && it.GetParameters().Length == 1 && it.GetParameters()[0].ParameterType == typeof(VRCUiPage))
                    {
                        return XrefScanner.XrefScan(it).Any(jt =>
                        {
                            if (jt.Type == XrefType.Global)
                            {
                                Il2CppSystem.Object @object = jt.ReadAsObject();
                                return ((@object != null) ? @object.ToString() : null) == "Screen Not Found - ";
                            }
                            return false;
                        });
                    }
                    return false;
                });
                ourShowScreenAction = (ShowScreenAction)Delegate.CreateDelegate(typeof(ShowScreenAction), VRCUiManager.prop_VRCUiManager_0, method);
                return ourShowScreenAction;
            }
        }

        private static ShowScreenAction ourShowScreenAction;

        public delegate VRCUiPage ShowScreenAction(VRCUiPage page);

        internal static void RefreshUser()
        {
            APIUser user = VRCUiManager.prop_VRCUiManager_0.field_Public_GameObject_0.GetComponentInChildren<PageUserInfo>().GetUser();

            if (user == null)
            {
                Console.WriteLine("user null");
                return;
            }
            APIUser.FetchUser(user.id,
                new Action<APIUser>((userapi) =>
                {
                    PageUserInfo pageUserInfo = VRCUiManager.prop_VRCUiManager_0.prop_VRCUiPopupManager_0.GetComponentInChildren<PageUserInfo>();
                    if (pageUserInfo != null)
                    {
                        pageUserInfo.Method_Public_Void_APIUser_PDM_0(userapi);
                        pageUserInfo.Method_Private_Boolean_APIUser_PDM_0(userapi);
                        pageUserInfo.Method_Private_EnumNPublicSealedvaNoOnOfSeReBlInFa10Unique_APIUser_PDM_0(userapi);

                        //LogHandler.Log("Refreshed user: " + userapi.id);
                    }
                }),
                new Action<string>((Error) =>
                {
                    //LogHandler.Log("Error Couldnt Fetch User\n" + Error);
                }));
        }

        internal static APIUser GetUser(this PageUserInfo Instance)
        {
            return Instance.field_Public_APIUser_0;
        }

        internal static void SelectAPIUser(this VRCUiManager instance, APIUser user)
        {
            QuickMenu.prop_QuickMenu_0.field_Private_APIUser_0 = user;
            QuickMenu.prop_QuickMenu_0.Method_Public_Void_EnumNPublicSealedvaUnWoAvSoSeUsDeSaCuUnique_Boolean_0((QuickMenu.EnumNPublicSealedvaUnWoAvSoSeUsDeSaCuUnique)4, false);
        }

        internal static void SelectAPIUser(this VRCUiManager instance, string userid)
        {
            APIUser.FetchUser(userid,
                new Action<APIUser>((User) =>
                {
                    instance.SelectAPIUser(User);
                }),
                new Action<string>((Error) =>
                {
                    PopupUtils.InformationAlert("Error", "Unable to Fetch User\n" + Error);
                }));
        }
    }
}
