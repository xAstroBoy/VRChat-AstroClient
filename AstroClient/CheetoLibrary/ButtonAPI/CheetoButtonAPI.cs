namespace CheetoLibrary.ButtonAPI
{
    using MelonLoader;
    using System;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    /// <summary>
    /// CBA - Cheeto's Button API (Can't Be Assed)
    /// This ButtonAPI has contributions from, Unreal and RinLovesYou
    /// </summary>
    internal static class CheetoButtonAPI
    {
        internal static string Indentifier = "AstroClient";
        internal static List<GameObject> UIElements = new List<GameObject>();

        internal static void CreateNewDashboardSubMenu(string header)
        {
            var headerBase = GameObject.Find(UIUtils.HeaderQuickActions);
            var buttonsBase = GameObject.Find(UIUtils.ButtonsQuickActions);

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
                if (go.name.ToLower().Contains("button"))
                {
                    GameObject.Destroy(go);
                }
            }

            hgo.transform.SetSiblingIndex(0);
            buttons.transform.SetSiblingIndex(1);
            _ = new NestedButton(buttons.transform, "Nested Button", "Hello <3");
            _ = new Button(buttons.transform, "Test Button #2", "", () => { MelonLogger.Msg("Bam!"); });
        }

        internal static void CreateNewDashboardTopIcon()
        {
            var expandBase = GameObject.Find(UIUtils.ExpandButton);

            var go = GameObject.Instantiate(expandBase);
            go.name = $"CheetoLibrary-{UIElements.Count}-TopIcon";
            go.transform.parent = expandBase.transform.parent;
            go.transform.rotation = expandBase.transform.rotation;
            go.transform.localPosition = new Vector3(0, 0, 0);
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.SetSiblingIndex(0);

            go.transform.GetComponentInChildren<UnityEngine.UI.Button>().onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            go.transform.GetComponentInChildren<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => MelonLogger.Msg($"TopIcon Clicked {go.name}")));

            UIElements.Add(go);
        }

        internal static void CreateNewDashboardMenu(string header)
        {
            //_ = new DashMenu(header);
        }
    }
}