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
            SetName($"CheetoLibrary-{CheetoButtonAPI.UIElements.Count}-Button:{label}");

            Self.transform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            Self.transform.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            Self.transform.GetComponentInChildren<Button>().onClick.AddListener(new Action(() => MelonLogger.Msg($"[Debug] Button Clicked: {Self.name}")));
            Self.transform.GetComponentInChildren<Button>().onClick.AddListener(action);

            CheetoButtonAPI.UIElements.Add(Self);
        }
    }
}