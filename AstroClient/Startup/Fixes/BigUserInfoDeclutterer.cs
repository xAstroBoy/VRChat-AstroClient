using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;

namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class BigUserInfoDeclutterer : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnBigMenuOpen += OnBigMenuOpen;
        }

        private static Transform _UserInfoPageTransform = null;
        private static Transform UserInfoPageTransform
        {
            get
            {
                if(_UserInfoPageTransform == null)
                {
                    return _UserInfoPageTransform = GameObjectFinder.Find("UserInterface/MenuContent/Screens/UserInfo")?.transform;
                }
                return _UserInfoPageTransform;
            }
        }

        private static void DestroyButtonContainingText(Transform obj, string text)
        {
            if (obj != null)
            {
                var textobj = obj.GetComponentInChildren<UnityEngine.UI.Text>();
                if (textobj != null)
                {
                    if (textobj.text.ToLower().Equals(text.ToLower())) ;
                    {
                        UnityEngine.Object.Destroy(obj.gameObject);
                    }
                }
            }
        }


        private static bool hasDeletedEarlyAccessButton = false;

        private static bool HasDeclutteredUserInfoPage = false;
        private void OnBigMenuOpen()
        {
            
            if(!HasDeclutteredUserInfoPage)
            {
                if (UserInfoPageTransform != null)
                {
                    // Only for me, if cheeto wants he can remove this
                    if (GameInstances.CurrentUser.GetAPIUser().id == "usr_a2fb27e8-921e-42f5-aa22-545c816b376e")
                    {
                        UserInfoPageTransform.FindObject("Ruby user page")?.DestroyMeLocal(true);
                        foreach(var item in UserInfoPageTransform.Get_Childs())
                        {
                            if(item.name.Contains("EditStatusButton(Clone)"))
                            {
                                DestroyButtonContainingText(item, "Force Clone");
                                DestroyButtonContainingText(item, "Portal to Instance");
                                DestroyButtonContainingText(item, "Teleport to");
                                DestroyButtonContainingText(item, "Force Clone");

                            }
                        }

                    }

                    ClientEventActions.OnBigMenuOpen -= OnBigMenuOpen;
                    HasDeclutteredUserInfoPage = true;
                }
            }
        }
    }
}