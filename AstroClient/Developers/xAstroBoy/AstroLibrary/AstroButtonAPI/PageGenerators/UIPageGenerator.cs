using System.Linq;
using UnhollowerBaseLib;

namespace AstroClient.xAstroBoy.AstroButtonAPI.PageGenerators
{
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnityEngine;
    using VRC.UI.Elements;

    internal static class UIPageGenerator
    {
        internal static UIPage GenerateQuickMenuPage(this GameObject nested, MenuStateController controller, string menuName)
        {

            UIPage result = null;
            if (nested != null)
            {
                result = nested.AddComponent<UIPage>();
                if (result != null)
                {
                    result.name = menuName;
                    result.field_Protected_MenuStateController_0 = controller;
					result.SetName(menuName);
                    result.field_Private_Boolean_1 = true;
                    result.field_Private_List_1_UIPage_0 = new List<UIPage>();
                    result.field_Private_List_1_UIPage_0.Add(result);
                    controller.AddPage(result);
                }
            }
            result.enabled = true;
            return result;
        }

        internal static UIPage GeneratePage(this UIPage template, MenuStateController controller, string menuName)
        {

            UIPage result = null;
            if (template != null)
            {
                result = Object.Instantiate(template, template.transform.parent, true);
                result.gameObject.EnableUIComponents();
                if (result != null)
                {
                    result.name = menuName;
                    result.field_Protected_MenuStateController_0 = controller;
                    result.SetName(menuName);
                    result.field_Private_Boolean_1 = true;
                    result.field_Private_List_1_UIPage_0 = new List<UIPage>();
                    result.field_Private_List_1_UIPage_0.Add(result);
                    controller.AddPage(result);
                }
            }
            result.enabled = true;
            return result;
        }


        internal static void SetupPage(this UIPage page, MenuStateController controller, string menuName)
        {
            if (page != null)
            {
                page.name = menuName;
                page.field_Protected_MenuStateController_0 = controller;
                page.SetName(menuName);
                page.field_Private_Boolean_1 = true;
                page.field_Private_List_1_UIPage_0 = new List<UIPage>();
                page.field_Private_List_1_UIPage_0.Add(page);
                controller.AddPage(page);
            }
        }

        internal static void AddPage(this MenuStateController controller, UIPage page)
        {
            if (page != null)
            {
                var list = controller.field_Public_ArrayOf_UIPage_0.ToList();
                if (!list.Contains(page))
                {
                    list.Add(page);
                    controller.field_Public_ArrayOf_UIPage_0 = list.ToArray();
                }
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
                    controller.field_Public_ArrayOf_UIPage_0 = list.ToArray();
                }
            }
        }




    }
}