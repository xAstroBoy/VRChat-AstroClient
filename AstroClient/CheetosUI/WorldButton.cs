namespace AstroClient
{
    using AstroLibrary;
    using HarmonyLib;
    using System;
    using System.Reflection;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using AstroClient.Components;
    using AstroLibrary.Utility;

    public class WorldButton
    {
        private GameObject gameObject;

        private VRC_AstroUdonTrigger interactable;

        public WorldButton(Vector3 position, Quaternion rotation, string label, Action action)
        {
            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.name = $"AstroWorldButton: {label}";

            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            gameObject.transform.localScale = new Vector3(0.25f, 0.1f, 0.1f);

            var front = GameObject.CreatePrimitive(PrimitiveType.Quad);
            front.name = "Front";

            front.transform.parent = gameObject.transform;
            front.transform.position = gameObject.transform.position;
            front.transform.localPosition -= new Vector3(0f, 0f, 0.51f);
            front.transform.rotation = gameObject.transform.rotation;
            front.transform.localScale = new Vector3(1f, 1f, 1f);

            MiscUtils.DelayFunction(0.2f, () =>
            {
                var AstroTrigger = front.AddComponent<VRC_AstroUdonTrigger>();
                if (AstroTrigger != null)
                {
                    AstroTrigger.interactText = label;
                    AstroTrigger.OnInteract = action;
                }
            });
            var front_renderer = front.GetComponent<Renderer>();
            front_renderer.material = new Material(Shader.Find("Standard"))
            {
                mainTexture = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.button.png"))
            };
            front_renderer.material.EnableKeyword("_EMISSION");
            front_renderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            front_renderer.material.SetTexture("_EmissionMap", CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.button.png")));
            front_renderer.material.SetFloat("_EmissionScaleUI", 1f);
            front_renderer.material.SetColor("_EmissionColor", Color.white);

            var front_canvas = new GameObject("Canvas");

            front_canvas.transform.parent = front.transform;
            front_canvas.transform.position = front.transform.position;
            front_canvas.transform.localPosition -= new Vector3(0f, 0f, 0.001f);
            front_canvas.transform.rotation = front.transform.rotation;
            front_canvas.layer = LayerMask.NameToLayer("UI");
            _ = front_canvas.AddComponent<Canvas>();
            _ = front_canvas.AddComponent<CanvasScaler>();


            var textObject = new GameObject("Text");

            textObject.transform.parent = front_canvas.transform;
            textObject.transform.position = front_canvas.transform.position;
            textObject.transform.rotation = front_canvas.transform.rotation;
            textObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.004f);
            textObject.layer = LayerMask.NameToLayer("UI");
            _ = textObject.AddComponent<CanvasRenderer>();

            var front_text = textObject.AddComponent<TextMeshPro>();
            front_text.color = Color.black;
            front_text.text = label;
            front_text.richText = true;
            front_text.alignment = TextAlignmentOptions.Center;
            front_text.enableAutoSizing = true;
            front_text.fontSizeMin = 0f;
            front_text.fontSizeMax = 72f;
        }
    }
}
