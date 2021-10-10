namespace CheetosLibrary
{
    using MelonLoader;
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    // TODO: Make it so you can specify which wing
    public class CheetoWingButton : CheetoElement
    {
        public CheetoWingButton(string label, Action action) : base(GameObject.Find(UIPaths.ProfileButton), GameObject.Find(UIPaths.LeftWingContainer).transform)
        {
            SetName($"CheetoLibrary-{CheetoButtonAPI.UIElements.Count}-CheetoWingButton:{label}");
            Self.transform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            SetAction(action);
        }
    }
}