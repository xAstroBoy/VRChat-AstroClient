namespace AstroLibrary.Extensions
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Handlers;
    using System.Collections.Generic;
    using UnityEngine;

    internal static class ItemTweaker_ext
    {
        internal static void AddToWorldUtilsMenu(this GameObject obj)
        {
            if (obj != null)
            {
                AstroClient.ItemTweakerV2.Submenus.ScrollMenus.WorldObjectsScrollMenu.AddToWorldUtilsMenu(obj);
            }
        }

        internal static void AddToWorldUtilsMenu(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    AstroClient.ItemTweakerV2.Submenus.ScrollMenus.WorldObjectsScrollMenu.AddToWorldUtilsMenu(obj);
                }
            }
        }

        internal static void Set_As_Object_To_Edit(this GameObject obj)
        {
            if (obj != null)
            {
                AstroClient.ItemTweakerV2.Selector.Tweaker_Object.SetObjectToEdit(obj);
            }
        }

        internal static bool isCurrentObjectToEdit(this GameObject obj)
        {
            if(obj != null)
            {
                return obj.Equals(AstroClient.ItemTweakerV2.Selector.Tweaker_Object.CurrentObjectToEdit);
            }
            return false;
        }

        internal static bool isCurrentObjectToEdit(this Component obj)
        {
            if (obj != null)
            {
                return obj.gameObject.Equals(AstroClient.ItemTweakerV2.Selector.Tweaker_Object.CurrentObjectToEdit);
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
    }
}