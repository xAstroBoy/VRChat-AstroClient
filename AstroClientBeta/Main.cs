namespace AstroClient
{
    using CheetosLibrary;
    using MelonLoader;
    using System;
    using System.Collections;
    using UnityEngine;

    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("AstroClient");

            _ = MelonCoroutines.Start(OnUiManagerInitCoro(() => { AfterUI(); }));
        }

        private void AfterUI()
        {
            var junk = GameObject.Find(UIPaths.Banner);
            if (junk != null) junk.SetActive(false);

            Utils.TryRun(new Action[]
            {
                () => CheetoButtonAPI.CreateNewDashboardMenu("AstroClient"),
                () => CheetoButtonAPI.CreateNewDashboardTopIcon(),
            });

            MelonLogger.Msg("UI Initialized.");
        }

        private IEnumerator OnUiManagerInitCoro(Action code)
        {
            while (GameObject.Find(UIPaths.QuickMenu) == null)
                yield return new WaitForSeconds(0.001f);

            code();
        }
    }
}

namespace CheetosLibrary
{
    using MelonLoader;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class Utils
    {
        public static void TryRun(Action[] actions)
        {
            foreach (var action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    MelonLogger.Error(e);
                }
            }
        }
    }

    // TODO: Finish
    public class CheetoElement
    {
        public CheetoElement()
        {
        }
    }

    // TODO: Finish
    public class CheetoButton : CheetoElement
    {
        public CheetoButton() : base()
        {
        }
    }

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

            CreateNewButton(buttons.transform, "Test Button #1");
            CreateNewButton(buttons.transform, "Test Button #2");
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

            go.transform.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            go.transform.GetComponentInChildren<Button>().onClick.AddListener(new Action(() => MelonLogger.Msg($"TopIcon Clicked {go.name}")));

            UIElements.Add(go);
        }

        // TODO: Move to CheetoButton
        public static void CreateNewButton(Transform parent, string label)
        {
            var buttonBase = GameObject.Find(UIPaths.WorldButton);

            var go = GameObject.Instantiate(buttonBase);
            go.name = $"CheetoLibrary-{UIElements.Count}-Button:{label}";
            go.transform.parent = parent.transform;
            go.transform.rotation = parent.transform.rotation;
            go.transform.localPosition = new Vector3(0, 0, 0);
            go.transform.localScale = new Vector3(1, 1, 1);

            go.transform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            go.transform.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            go.transform.GetComponentInChildren<Button>().onClick.AddListener(new Action(() => MelonLogger.Msg($"Button Clicked: {go.name}")));

            UIElements.Add(go);
        }
    }
}
