using AstroClient.ConsoleUtils;
using MelonLoader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using VRC.Core;
using VRC.UI;

namespace DayClientML2.Utility.Extensions
{
    public static class VRCUiManagerExtension
    {
        public static APIUser SelectedAPIUser(this VRCUiManager Instance)
        {
            return Instance.GetMenuContent().GetComponentInChildren<PageUserInfo>().GetUser();
        }

        public static void SelectAPIUser(this VRCUiManager instance, APIUser user)
        {
            Utils.QuickMenu.field_Private_APIUser_0 = user;
            Utils.QuickMenu.Method_Public_Void_Int32_Boolean_0(4, false);
        }

        public static void SelectAPIUser(this VRCUiManager instance, string userid)
        {
            APIUser.FetchUser(userid,
                new Action<APIUser>((User) =>
                {
                    instance.SelectAPIUser(User);
                }),
                new Action<string>((Error) =>
                {
                    Utils.VRCUiPopupManager.ShowAlert("Error", "Couldnt Fetch User\n" + Error);
                }));
        }

        public static void CloseUI(this VRCUiManager Instance, bool withFade = false)
        {
            try
            {
                Instance.Method_Public_Void_Boolean_0(withFade);
            }
            catch { }
        }

        public static void EnableCursor(this VRCUiCursorManager instance, bool EnableCursor)
        {
            instance.field_Private_Boolean_0 = EnableCursor;
        }

        public static void CloseUI()
        {
            Utils.VRCUiManager.CloseUI();
        }

        public static void OpenUI(this VRCUiManager Instance, bool showDefaultScreen = false, bool showBackdrop = true)
        {
            Instance.Method_Public_Void_Boolean_Boolean_0(showDefaultScreen, showBackdrop);
        }

        public static VRCUiPage GetPage(this VRCUiManager Instance, string screenPath)
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

        public static VRCUiPage ShowScreen(this VRCUiManager Instance, VRCUiPage page)
        {
            return ShowScreenActionAction(page);
        }

        public static void ShowScreen(this VRCUiManager Instance, string pageName)
        {
            VRCUiPage vrcuiPage = Instance.GetPage(pageName);
            if (vrcuiPage != null)
            {
                Instance.ShowScreen(vrcuiPage);
            }
        }

        public static ShowScreenAction ShowScreenActionAction
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
                ourShowScreenAction = (ShowScreenAction)Delegate.CreateDelegate(typeof(ShowScreenAction), Utils.VRCUiManager, method);
                return ourShowScreenAction;
            }
        }

        private static ShowScreenAction ourShowScreenAction;

        public delegate VRCUiPage ShowScreenAction(VRCUiPage page);

#warning This needs fixed, update 1069 broke it
        /**
        internal static void RefreshUser()
        {
            APIUser user = Utils.VRCUiManager.field_Public_GameObject_0.GetComponentInChildren<PageUserInfo>().GetUser();

            if (user == null)
            {
                Console.WriteLine("user null");
                return;
            }
            APIUser.FetchUser(user.id,
                new Action<APIUser>((userapi) =>
                {
                    PageUserInfo pageUserInfo = Utils.VRCUiManager.GetMenuContent().GetComponentInChildren<PageUserInfo>();
                    if (pageUserInfo != null)
                    {
                        pageUserInfo.Method_Private_Boolean_APIUser_PDM_0(userapi);
                        pageUserInfo.Method_Private_Boolean_APIUser_PDM_1(userapi);

                        ModConsole.Log("Refreshed user: " + userapi.id);
                    }
                }),
                new Action<string>((Error) =>
                {
                    ModConsole.Log("Error Couldnt Fetch User\n" + Error);
                }));
        }
        **/

        internal static void GetAvatarAuthorFromSocial(this APIUser Instance)
        {
            var avatarLink = new Uri(Instance.currentAvatarImageUrl);

            string adjustedLink = string.Format("https://{0}", avatarLink.Authority);

            for (int i = 0; i < avatarLink.Segments.Length - 2; i++)
            {
                adjustedLink += avatarLink.Segments[i];
            }

            avatarLink = new Uri(adjustedLink.Trim("/".ToCharArray()));
            void OnSuccess(APIUser user)
            {
                ModConsole.Log($"Found Author: {user.id}");
                Utils.VRCUiManager.SelectAPIUser(user);
            }
            if (avatarLink == null) return;
            WebRequest request = WebRequest.Create(avatarLink);
            WebResponse response = request.GetResponse();
            if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK) return;
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                JObject jsonData = (JObject)JsonSerializer.CreateDefault().Deserialize(streamReader, typeof(JObject));

                var requestedData = jsonData.ToObject<Api.Object.ImageFile>();
                //ModConsole.Log(JsonConvert.SerializeObject(jsonData, Formatting.Indented));
                APIUser.FetchUser(requestedData.ownerId, new Action<APIUser>(OnSuccess), new Action<string>((thing) => { }));
            }

            response.Close();
        }

#warning This needs fixed, update 1069 broke it
        internal static void RefreshMenu()
        {
            //UiUserList[] userLists = Utils.VRCUiManager.GetComponentsInChildren<UiUserList>(true);

            //foreach (UiUserList userList in userLists)
            //{
            //    userList.Method_Public_Void_0();
            //    userList.Method_Public_Void_1();
            //    userList.Method_Public_Void_2();
            //}
            //ModConsole.Log("Refreshed social lists!");
        }

        internal static GameObject GetMenuContent(this VRCUiManager Instance)
        {
            return Instance.field_Public_GameObject_0;
        }

        internal static APIUser GetUser(this PageUserInfo Instance)
        {
            return Instance.field_Public_APIUser_0;
        }
    }
}