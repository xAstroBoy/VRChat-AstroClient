using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Constants;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;
using VRC.UI.Core.Styles;

namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class TabWhiteImageFix : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnQuickMenuOpen += OnQuickMenuOpen;
        }

        private static Transform _ImageBackgroundTransform = null;
        private static Transform ImageBackgroundTransform
        {
            get
            {
                if(_ImageBackgroundTransform == null)
                {
                    return _ImageBackgroundTransform = GameObjectFinder.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Background_QM_PagePanel")?.transform;
                }
                return _ImageBackgroundTransform;
            }
        }


        private void OnQuickMenuOpen()
        {

            if (ImageBackgroundTransform != null)
            {
                // Only for me, if cheeto wants he can remove this
                if (UserIdentifiers.is_xAstroBoy)
                {

                    var image = ImageBackgroundTransform.GetComponent<Image>();
                    if (image != null)
                    {
                        image.gameObject.RemoveComponent<StyleElement>();
                        image.color = Color.clear;
                        ClientEventActions.OnQuickMenuOpen -= OnQuickMenuOpen;
                    }
                }
                else
                {
                    ClientEventActions.OnQuickMenuOpen -= OnQuickMenuOpen;
                }
            }
        }
        
    }
}