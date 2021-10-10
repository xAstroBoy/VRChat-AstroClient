namespace CheetosLibrary
{
    using MelonLoader;
    using System;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public static class CheetoButtonAPI
    {
        public static List<GameObject> UIElements = new List<GameObject>();

        public static void CreateNewDashboardMenu(string header)
        {
            var headerBase = GameObject.Find(UIPaths.HeaderQuickActions);
            var buttonsBase = GameObject.Find(UIPaths.ButtonsQuickActions);

            var hgo = GameObject.Instantiate(headerBase);
            hgo.name = $"CheetoLibrary-{UIElements.Count}-DashboardHeader:{header}";
            hgo.transform.parent = headerBase.transform.parent;
            hgo.transform.rotation = headerBase.transform.rotation;
            hgo.transform.localPosition = new Vector3(0, 0, 0);
            hgo.transform.localScale = new Vector3(1, 1, 1);
            UIElements.Add(hgo);

            var text = hgo.GetComponentInChildren<TextMeshProUGUI>();
            text.text = header;

            var buttons = GameObject.Instantiate(buttonsBase);
            buttons.name = $"CheetoLibrary-{UIElements.Count}-DashboardMenu:{header}";
            buttons.transform.parent = buttonsBase.transform.parent;
            buttons.transform.rotation = buttonsBase.transform.rotation;
            buttons.transform.localPosition = new Vector3(0, 0, 0);
            buttons.transform.localScale = new Vector3(1, 1, 1);
            UIElements.Add(buttons);

            var children = buttons.transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in children)
            {
                var go = child.gameObject;
                if (go != buttons && go.name.ToLower().Contains("button"))
                {
                    GameObject.Destroy(go);
                }
            }

            hgo.transform.SetSiblingIndex(0);
            buttons.transform.SetSiblingIndex(1);
            _ = new CheetoButton(buttons.transform, "Test Button #1", () => { MelonLogger.Msg("Boom!"); });
            _ = new CheetoButton(buttons.transform, "Test Button #2", () => { MelonLogger.Msg("Bam!"); });
        }

        public static void CreateNewDashboardTopIcon()
        {
            var expandBase = GameObject.Find(UIPaths.ExpandButton);

            var go = GameObject.Instantiate(expandBase);
            go.name = $"CheetoLibrary-{UIElements.Count}-TopIcon";
            go.transform.parent = expandBase.transform.parent;
            go.transform.rotation = expandBase.transform.rotation;
            go.transform.localPosition = new Vector3(0, 0, 0);
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.SetSiblingIndex(0);

            go.transform.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            go.transform.GetComponentInChildren<Button>().onClick.AddListener(new Action(() => MelonLogger.Msg($"TopIcon Clicked {go.name}")));

            UIElements.Add(go);
        }

        public static void CreateNewTabButton()
        {
            var tabBase = GameObject.Find(UIPaths.LaunchPadTab);

            var go = GameObject.Instantiate(tabBase);
            go.name = $"CheetoLibrary-{UIElements.Count}-TabButton";
            go.transform.parent = tabBase.transform.parent;
            go.transform.rotation = tabBase.transform.rotation;
            go.transform.localPosition = new Vector3(0, 0, 0);
            go.transform.localScale = new Vector3(1, 1, 1);

            go.transform.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            go.transform.GetComponentInChildren<Button>().onClick.AddListener(new Action(() => MelonLogger.Msg($"TabButton Clicked {go.name}")));
            go.transform.SetSiblingIndex(1);

            UIElements.Add(go);
        }
    }
}