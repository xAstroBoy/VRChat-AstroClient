﻿namespace AstroClient.xAstroBoy.AstroButtonAPI.PageGenerators
{
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnityEngine;
    using VRC.UI.Elements;

    internal static class UIPageGenerator
    {
        internal static UIPage GenerateQuickMenuPage(this GameObject nested, string menuName)
        {

            UIPage result = null;
            if (nested != null)
            {
                result = nested.AddComponent<UIPage>();
                if (result != null)
                {
                    result.name = menuName;
                    result.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController;
                    result.field_Public_String_0 = menuName;
                    result.field_Private_Boolean_1 = true;
                    result.field_Private_List_1_UIPage_0 = new List<UIPage>();
                    result.field_Private_List_1_UIPage_0.Add(result);
                    QuickMenuTools.QuickMenuController.field_Private_Dictionary_2_String_UIPage_0.Add(menuName, result);
                }
            }

            return result;
        }

        
    }
}