namespace CheetosLibrary
{
    using MelonLoader;
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class CheetoButton : CheetoElement
    {
        public CheetoButton(Transform parent, string label, Action action) : base(GameObject.Find(UIPaths.WorldButton), parent)
        {
            SetName($"CheetoLibrary-{CheetoButtonAPI.UIElements.Count}-CheetoButton:{label}");

            Self.transform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            SetAction(action);
        }
    }
}