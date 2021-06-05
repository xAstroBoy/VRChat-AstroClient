namespace AstroClient.Extensions
{
	using AstroClient.AstroUtils.ItemTweaker;
	using System.Collections.Generic;
	using UnityEngine;

	public static class ItemTweaker_ext
    {
        public static void AddToWorldUtilsMenu(this GameObject obj)
        {
            if (obj != null)
            {
                ItemTweakerMain.AddToWorldUtilsMenu(obj);
            }
        }

        public static void AddToWorldUtilsMenu(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemTweakerMain.AddToWorldUtilsMenu(obj);
                }
            }
        }

        public static void SetObjectToEdit(this GameObject obj)
        {
            if (obj != null)
            {
                ItemTweakerV2.Tweaker_Object.SetObjectToEdit(obj);
            }
        }
    }
}