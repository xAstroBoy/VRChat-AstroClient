namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using AstroMonos.Components.Custom.Random;
    using ClientUI.Menu.ItemTweakerV2.Handlers;
    using ClientUI.Menu.ItemTweakerV2.ScrollMenus.WorldObjects;
    using ClientUI.Menu.ItemTweakerV2.Selector;
    using UnityEngine;

    internal static class ItemTweaker_ext
    {
        internal static void AddToWorldUtilsMenu(this GameObject obj)
        {
            if (obj != null)
            {
                WorldObjectsScrollMenu.AddToWorldUtilsMenu(obj);
            }
        }

        internal static void AddToWorldUtilsMenu(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    WorldObjectsScrollMenu.AddToWorldUtilsMenu(obj);
                }
            }
        }

        internal static void Set_As_Object_To_Edit(this GameObject obj)
        {
            if (obj != null)
            {
                Tweaker_Object.SetObjectToEdit(obj);
            }
        }

        internal static bool isCurrentObjectToEdit(this GameObject obj)
        {
            if (obj != null)
            {
                return obj.Equals(Tweaker_Selector.SelectedObject);
            }
            return false;
        }

        internal static bool isCurrentObjectToEdit(this Component obj)
        {
            if (obj != null)
            {
                return obj.gameObject.Equals(Tweaker_Selector.SelectedObject);
            }
            return false;
        }

        internal static void FocusOnTweaker(this SpinnerBehaviour instance)
        {
            SpinnerBehaviourHandler.FocusPageOnSpinner(instance);
        }

        internal static void FocusOnTweaker(this RocketBehaviour instance)
        {
            RocketBehaviourHandler.FocusPageOnRocket(instance);
        }

        internal static void FocusOnTweaker(this CrazyBehaviour instance)
        {
            CrazyBehaviourHandler.FocusPageOnCrazy(instance);
        }

        internal static void FocusOnTweaker(this InflaterBehaviour instance)
        {
            InflaterBehaviourHandler.FocusPageOnInflater(instance);
        }
    }
}