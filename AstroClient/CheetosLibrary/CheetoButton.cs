namespace CheetosLibrary
{
    using MelonLoader;
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class CheetoButton : CheetoElement
    {
        public CheetoButton(Transform parent, string label, Action action) : base()
        {
            var buttonBase = GameObject.Find(UIPaths.WorldButton);

            var go = GameObject.Instantiate(buttonBase);
            Self = go;
            Parent = parent.gameObject;

            SetName($"CheetoLibrary-{CheetoButtonAPI.UIElements.Count}-Button:{label}");
            ApplyFixes();

            go.transform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            go.transform.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            go.transform.GetComponentInChildren<Button>().onClick.AddListener(new Action(() => MelonLogger.Msg($"[Debug] Button Clicked: {go.name}")));
            go.transform.GetComponentInChildren<Button>().onClick.AddListener(action);

            CheetoButtonAPI.UIElements.Add(go);
        }
    }
}