namespace AstroButtonAPI
{
    using AstroClient;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using CheetoLibrary;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AstroClient.Tasks;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC;
    using VRC.Core;
    using VRC.DataModel;
    using VRC.DataModel.Core;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Menus;

    internal static class UIPageGenerator
    {
        internal static UIPage GenerateQuickMenuPage(this GameObject nested, string menuName)
        {
            return GenerateQuickMenuPageAsync(nested, menuName).Result;
        }



        private static async Task<UIPage> GenerateQuickMenuPageAsync(this GameObject nested, string menuName)
        {
            return Task.Run(async () => await GeneratePage(nested, menuName)).Result;
        }


        private static async Task<UIPage> GeneratePage(GameObject nested, string menuName)
        {
            return await Task.Run(async () =>
            {
                UIPage result = null;
                if (nested != null)
                {
                    //result = UnityEngine.Object.Instantiate(QuickMenuTools.QuickMenuPage, nested.transform, true);

                    result = nested.AddComponent<UIPage>();
                    if (result != null)
                    {
                        result.name = menuName;
                        result.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController();
                        result.field_Public_String_0 = menuName;
                        result.field_Private_Boolean_1 = true;
                        result.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
                        result.field_Private_List_1_UIPage_0.Add(result);
                        QuickMenuTools.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, result);
                    }
                }
                return result;
            });
        }
    }
}