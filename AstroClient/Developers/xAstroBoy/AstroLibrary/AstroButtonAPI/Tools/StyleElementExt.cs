using System.Linq;
using Cinemachine;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;
using VRC.UI.Core.Styles;

namespace AstroClient.xAstroBoy.AstroButtonAPI.Tools
{

    internal static class StyleElementExt
    {
        //internal static List<Component> GetImageComponents(this StyleElement instance)
        //{
        //    return instance.field_Public_List_1_Component_0;
        //}

        //internal static List<ElementStyle> Get_ElementStyles(this StyleElement instance)
        //{
        //    return instance.field_Public_List_1_ElementStyle_0;
        //}
        //internal static void Clear_ProgrammedElementStyles(this StyleElement instance)
        //{
        //    instance.field_Public_List_1_ElementStyle_0.Clear();
        //}
        //internal static void DisableStyleElement(this StyleElement instance)
        //{
        //    // Rebuild the list.
        //    if (instance != null)
        //    {
        //        // Fuck this, remove the components.
        //        instance.field_Public_List_1_Component_0.Clear();
        //        //instance.field_Public_Dictionary_2_Type_Component_0.Clear();

        //        // And the elementstyles.
        //        //instance.field_Private_ElementStyle_0 = null;
        //        //instance.field_Private_ElementStyle_1 = null;
        //        instance.field_Public_List_1_ElementStyle_0.Clear(); 
        //    }
        //}

        //internal static void SetColor(this StyleElement instance, Color color, bool OverrideAlpha = true)
        //{
        //    // Rebuild the list.
        //    if (instance != null)
        //    {
        //        var list = new List<ElementStyle>();
        //        foreach(var item in instance.Get_ElementStyles())
        //        {

        //            list.Add(item.SetColor(color, OverrideAlpha));
        //        }

        //        instance.Clear_ProgrammedElementStyles();
        //        foreach (var item in list)
        //        {
        //            instance.field_Public_List_1_ElementStyle_0.Add(item);
        //        }

        //        if(instance.field_Private_ElementStyle_0 != null)
        //        {
        //            instance.field_Private_ElementStyle_0 = instance.field_Private_ElementStyle_0.SetColor(color, OverrideAlpha);
        //        }
        //        if (instance.field_Private_ElementStyle_1 != null)
        //        {
        //            instance.field_Private_ElementStyle_1 = instance.field_Private_ElementStyle_1.SetColor(color, OverrideAlpha);
        //        }

        //    }
        //}

        //private static ElementStyle SetColor(this ElementStyle instance, Color color, bool OverrideAlpha = true)
        //{
        //    var Result = new ElementStyle();
        //    var dict = new Dictionary<int, StyleElement.PropertyValue>();
        //    foreach (var original in instance.field_Public_Dictionary_2_Int32_PropertyValue_0)
        //    {
        //        var key = original.key;
        //        var Orig_Style = original.value;
        //        dict.Add(key, Orig_Style.SetColor(color, OverrideAlpha));

        //    }
        //    instance.field_Public_Dictionary_2_Int32_PropertyValue_0.Clear(); ;
        //    Result.field_Public_Int32_0 = instance.field_Public_Int32_0;
        //    Result.field_Public_UInt64_0 = instance.field_Public_UInt64_0;
        //    Result.field_Public_Selector_0 = instance.field_Public_Selector_0;
        //    Result.field_Public_Dictionary_2_Int32_PropertyValue_0 = dict;
        //    return Result;
        //}

        //internal static StyleElement.PropertyValue SetColor(this StyleElement.PropertyValue instance, Color color, bool OverrideAlpha = true)
        //{
        //    if(instance != null)
        //    {
        //        var newProperty = new StyleElement.PropertyValue();
        //        if(newProperty != null)
        //        {
        //            if(OverrideAlpha)
        //            {
        //                newProperty.field_Public_Color_0 = color;
        //            }
        //            else
        //            {
        //                newProperty.field_Public_Color_0 = new Color(color.r, color.g, color.b, instance.field_Public_Color_0.a);
        //            }
        //            newProperty.field_Public_Boolean_0 = instance.field_Public_Boolean_0;
        //            newProperty.field_Public_Int32_0 = instance.field_Public_Int32_0;
        //            newProperty.field_Public_Int32_1 = instance.field_Public_Int32_1;
        //            newProperty.field_Public_Object_0 = instance.field_Public_Object_0;
        //            newProperty.field_Public_Object_1 = instance.field_Public_Object_1;
        //            newProperty.field_Public_Single_0 = instance.field_Public_Single_0;
        //            return newProperty;
        //        }
        //    }
        //    return new StyleElement.PropertyValue
        //    {
        //        field_Public_Color_0 = new Color(color.r, color.g, color.b, color.a)
        //    };
        //}
    }
}