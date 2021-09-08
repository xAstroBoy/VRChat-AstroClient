namespace AstroClient
{
    #region Imports

    using System;
    using UnityEngine;

    #endregion Imports

    public static class Astro_Interactable_Extensions
    {
        public static void AddAstroInteractable(this GameObject gameObject, Action action)
        {
            _ = gameObject.AddComponent<Astro_Interactable>();
            gameObject.GetComponent<Astro_Interactable>().Action = action;
        }
    }
}