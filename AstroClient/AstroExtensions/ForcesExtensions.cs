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
    public static class ForcesExtensions
    {
        public static void KillForces(this GameObject obj)
        {
            RemoveForces(obj, TakeOwnership);
        }

        public static void Left(this GameObject obj)
        {
            ApplyLeftForce(obj, TakeOwnership);
        }

        public static void Right(this GameObject obj)
        {
            ApplyRightForce(obj, TakeOwnership);
        }

        public static void Foward(this GameObject obj)
        {
            ApplyFowardForce(obj, TakeOwnership);
        }

        public static void Backward(this GameObject obj)
        {
            ApplyBackwardsForce(obj, TakeOwnership);
        }

        public static void Push(this GameObject obj)
        {
            PushObject(obj, TakeOwnership);
        }

        public static void Pull(this GameObject obj)
        {
            PullObject(obj, TakeOwnership);
        }

        public static void SpinX(this GameObject obj)
        {
            SpinObjectX(obj, TakeOwnership);
        }

        public static void SpinY(this GameObject obj)
        {
            SpinObjectY(obj, TakeOwnership);
        }

        public static void SpinZ(this GameObject obj)
        {
            SpinObjectZ(obj, TakeOwnership);
        }









    }
}
