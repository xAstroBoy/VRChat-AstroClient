﻿using System.Linq;
using UnhollowerBaseLib;

namespace AstroClient.xAstroBoy.AstroButtonAPI.PageGenerators
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
                    result.field_Protected_MenuStateController_0 = QuickMenuTools.QuickMenuController;
                    result.field_Public_String_0 = menuName;
                    result.field_Private_Boolean_1 = true;
                    result.field_Private_List_1_UIPage_0 = new List<UIPage>();
                    result.field_Private_List_1_UIPage_0.Add(result);
                    QuickMenuTools.QuickMenuController.AddPage(result);
                }
            }

            return result;
        }




        internal static void AddPage(this MenuStateController controller, UIPage page)
        {
            if (page != null)
            {
                var list = controller.field_Public_ArrayOf_UIPage_0.ToList();
                if (!list.Contains(page))
                {
                    list.Add(page);
                }
                controller.field_Public_ArrayOf_UIPage_0 = list.ToArray();
            }
        }

        internal static void RemovePage(this MenuStateController controller, UIPage page, bool DestroyPage = true)
        {
            if (page != null)
            {
                var list = controller.field_Public_ArrayOf_UIPage_0.ToList();
                if (list.Contains(page))
                {
                    list.Remove(page);
                    if (DestroyPage)
                    {
                        UnityEngine.Object.Destroy(page);
                    }
                }
                controller.field_Public_ArrayOf_UIPage_0 = list.ToArray();
            }
        }




    }
}