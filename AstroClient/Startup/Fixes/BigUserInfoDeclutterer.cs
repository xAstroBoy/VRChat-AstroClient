using AstroClient.AstroMonos.Components.Tools;
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

        private static void DisableButtonContainingText(Transform obj, string text)
        {
            if (obj != null)
            {
                var textobj = obj.GetComponentInChildren<UnityEngine.UI.Text>();
                if (textobj != null)
                {
                    if (textobj.text.ToLower().Equals(text.ToLower())) 
                    {
                        obj.GetOrAddComponent<Disabler>();
                        //UnityEngine.Object.Destroy(obj.gameObject);
                    }
                }
            }
        }



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
                        UserInfoPageTransform.FindObject("Ruby user page")?.GetOrAddComponent<Disabler>();
                        var UserPanel = UserInfoPageTransform.FindObject("User Panel");
                        if (UserPanel != null)
                        {

                            foreach (var item in UserPanel.Get_Childs())
                            {
                                if (item.name.Contains("EditStatusButton(Clone)"))
                                {
                                    DisableButtonContainingText(item, "Force Clone");
                                    DisableButtonContainingText(item, "Portal to Instance");
                                    DisableButtonContainingText(item, "Teleport to");
                                }
                            }
                        }
                        var RightUpperButtonColumn = UserInfoPageTransform.FindObject("Buttons/RightSideButtons/RightUpperButtonColumn");
                        if (RightUpperButtonColumn != null)
                        {
                            RightUpperButtonColumn.FindObject("Teleport")?.GetOrAddComponent<Disabler>();
                            RightUpperButtonColumn.FindObject("Favorite Avatar")?.GetOrAddComponent<Disabler>();
                            RightUpperButtonColumn.FindObject("Teleport")?.GetOrAddComponent<Disabler>();
                        }



                    }

                    ClientEventActions.OnBigMenuOpen -= OnBigMenuOpen;
                    HasDeclutteredUserInfoPage = true;
                }
            }
        }
    }
}