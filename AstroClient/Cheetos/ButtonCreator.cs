namespace AstroClient
{
    using AstroClient.Components;
    using AstroLibrary.Extensions;
    using TMPro;
    using UnityEngine;

    internal static  class ButtonCreator
    {
        internal static  GameObject Create(string text, Vector3 position, Quaternion rotation, System.Action action)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Button " + text;
            go.transform.position = position;
            go.transform.rotation = rotation;
            go.transform.localScale = new Vector3(0.2f, 0.1f, 0.1f);
            var AstroTrigger = go.AddComponent<VRC_AstroInteract>();
            if (AstroTrigger != null)
            {
                AstroTrigger.interactText = text;
                AstroTrigger.OnInteract = action;
            }
            var textObject = new GameObject("Text");
            textObject.transform.parent = go.transform;
            var rect = textObject.AddComponent<RectTransform>();
            rect.sizeDelta = new Vector2(1f, 1f);
            textObject.transform.parent = textObject.transform;
            textObject.transform.localPosition = new Vector3(0, 0, -0.51f);
            textObject.transform.rotation = go.transform.rotation;
            textObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            var textComp = textObject.AddComponent<TextMeshPro>();
            textComp.text = text;
            textComp.color = Color.black;
            textComp.autoSizeTextContainer = true;
            go.RemoveAllColliders();
            go.AddTriggerCollider();
            return go;
        }
    }
}