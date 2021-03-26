using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using AstroClient.components;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using System.Reflection;
using RubyButtonAPI;
using UnityEngine.UI;
using DayClientML2.Utility.Extensions;
using AstroClient.AstroUtils.ItemTweaker;
using static AstroClient.Forces;
using VRC.SDK3.Components;
using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports


namespace AstroClient.extensions
{
    public static class ScaleExtensions
    {


        public static void IncreaseHoldItemScale(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.IncreaseHoldItemScale(obj);
            }
        }

        public static void RestoreOriginalScaleItem(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.RestoreOriginalScaleItem(obj);
            }
        }

        public static void DecreaseHoldItemScale(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.DecreaseHoldItemScale(obj);
            }
        }




    }
}
