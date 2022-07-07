using AstroClient.ClientActions;
using AstroClient.Constants;
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

    internal class AvatarPageDeclutterer : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnBigMenuOpen += OnBigMenuOpen;
        }

        private static Transform _AvatarPageTransform = null;
        private static Transform AvatarPageTransform
        {
            get
            {
                if(_AvatarPageTransform == null)
                {
                    return _AvatarPageTransform = Finder.Find("UserInterface/MenuContent/Screens/Avatar")?.transform;
                }
                return _AvatarPageTransform;
            }
        }

        private static Transform _EarlyAccessBS = null;
        public static Transform EarlyAccessHeader
        {
            get
            {
                if(_EarlyAccessBS == null)
                {
                    return _EarlyAccessBS = Finder.Find("UserInterface/MenuContent/Backdrop/Backdrop/Image")?.transform;
                }
                return _EarlyAccessBS;
            }
        }

        private static bool hasDeletedEarlyAccessButton = false;

        private static bool HasDeclutteredAvatarPage = false;
        private void OnBigMenuOpen()
        {
            
            if(!HasDeclutteredAvatarPage)
            {
                if (AvatarPageTransform != null)
                {
                    // Only for me, if cheeto wants he can remove this
                    if (UserIdentifiers.is_xAstroBoy)
                    {
                        foreach(var item in AvatarPageTransform.Get_Childs())
                        {
                            // Remove the SMButtons (useless)
                            if(item.name.Contains("SMButton"))
                            {
                                item.DestroyMeLocal();
                            }
                        }
                        AvatarPageTransform.FindObject("Avtr_Rename List 1")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Rename List 2")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Rename List 3")?.DestroyMeLocal(true);

                        AvatarPageTransform.FindObject("Avtr_Add Avi List 1")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Add Avi List 2")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Add Avi List 3")?.DestroyMeLocal(true);

                        AvatarPageTransform.FindObject("Avtr_Remove Avi List 1")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Remove Avi List 2")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Remove Avi List 3")?.DestroyMeLocal(true);

                        
                        AvatarPageTransform.FindObject("Avtr_Toggle Lists")?.DestroyMeLocal(true);

                        AvatarPageTransform.FindObject("Avtr_Toggle Public Avatars")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Toggle Legacy Avatars")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Toggle Avatar Worlds")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Avtr_Toggle Favorite Avatars")?.DestroyMeLocal(true);

                        AvatarPageTransform.FindObject("Favorite Avatar")?.DestroyMeLocal(true);
                        AvatarPageTransform.FindObject("Add By ID")?.DestroyMeLocal(true);

                    }
                    HasDeclutteredAvatarPage = true;
                }
            }

            if(!hasDeletedEarlyAccessButton)
            {
                if(EarlyAccessHeader != null)
                {
                    EarlyAccessHeader.DestroyMeLocal(true);
                    hasDeletedEarlyAccessButton = true;
                }
                else
                {
                    hasDeletedEarlyAccessButton = true;
                }
                ClientEventActions.OnBigMenuOpen -= OnBigMenuOpen;
            }
            
        }
    }
}