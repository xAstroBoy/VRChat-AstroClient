using AstroClient.AstroMonos.Components.Tools;
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

    internal class KeyboardPopupDeclutterer : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnBigMenuOpen += OnBigMenuOpen;
        }

        private static Transform _InputPopupTransform = null;
        private static Transform InputPopupTransform
        {
            get
            {
                if (_InputPopupTransform == null)
                {
                    return _InputPopupTransform = Finder.Find("UserInterface/MenuContent/Popups/InputPopup")?.transform;
                }
                return _InputPopupTransform;
            }
        }

        private static void DestroyButtonContainingText(Transform obj, string text)
        {
            if (obj != null)
            {
                var textobj = obj.GetComponentInChildren<UnityEngine.UI.Text>();
                if (textobj != null)
                {
                    if (textobj.text.ToLower().Equals(text.ToLower())) 
                    {
                        UnityEngine.Object.Destroy(obj.gameObject);
                    }
                }
            }
        }



        private static bool HasDeclutteredPopup = false;
        private void OnBigMenuOpen()
        {

            if (!HasDeclutteredPopup)
            {
                if (InputPopupTransform != null)
                {
                    // Only for me, if cheeto wants he can remove this
                    if (UserIdentifiers.is_xAstroBoy)
                    {
                        InputPopupTransform.FindObject("Favorite Button(Clone)")?.GetOrAddComponent<Disabler>();
                        InputPopupTransform.FindObject("PasteFromClipboard")?.GetOrAddComponent<Disabler>();
                    }
                    ClientEventActions.OnBigMenuOpen -= OnBigMenuOpen;
                    HasDeclutteredPopup = true;

                }
            }
        }
    }
}