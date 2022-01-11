namespace AstroClient.CheetosUI
{
    using System;
    using AstroMonos.AstroUdons;
    using ClientResources.Loaders;
    using TMPro;
    using Tools.Extensions;
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.Utility;

    internal class WorldButton
    {
        internal GameObject ButtonObject { get; set; }
        internal GameObject Front { get; set; }
        internal GameObject front_canvas { get; set; }
        internal GameObject textObject { get; set; }

        internal VRC_AstroInteract AstroTrigger { get; set; }

        internal Rigidbody RigidBody { get; set; }

        internal TextMeshPro front_text { get; set; }

        internal Renderer front_renderer { get; set; }

        internal void DestroyMe()
        {
            if (ButtonObject != null) ButtonObject.DestroyMeLocal();
            if (Front != null) Front.DestroyMeLocal();
            if (front_renderer != null) front_renderer.DestroyMeLocal();
            if (textObject != null) textObject.DestroyMeLocal();

            if (AstroTrigger != null) AstroTrigger.DestroyMeLocal();
            if (RigidBody != null) RigidBody.DestroyMeLocal();
            if (front_text != null) front_text.DestroyMeLocal();
            if (front_canvas != null) front_canvas.DestroyMeLocal();
        }
        internal WorldButton(Vector3 position, Quaternion rotation, string label, Action action)
        {
            ButtonObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ButtonObject.name = $"AstroWorldButton: {label}";

            ButtonObject.transform.position = position;
            ButtonObject.transform.rotation = rotation;
            ButtonObject.transform.localScale = new Vector3(0.25f, 0.1f, 0.1f);
            RigidBody = ButtonObject.GetOrAddComponent<Rigidbody>();
            RigidBody.isKinematic = true;

            Front = GameObject.CreatePrimitive(PrimitiveType.Quad);
            Front.name = "Front";

            Front.transform.parent = ButtonObject.transform;
            Front.transform.position = ButtonObject.transform.position;
            Front.transform.localPosition -= new Vector3(0f, 0f, 0.51f);
            Front.transform.rotation = ButtonObject.transform.rotation;
            Front.transform.localScale = new Vector3(1f, 1f, 1f);
            Front.Set_Colliders_isTrigger(true);
            MiscUtils.DelayFunction(0.2f, () =>
            {
                AstroTrigger = Front.AddComponent<VRC_AstroInteract>();
                if (AstroTrigger != null)
                {
                    AstroTrigger.interactText = label;
                    AstroTrigger.OnInteract = action;
                }
            });
            front_renderer = Front.GetComponent<Renderer>();
            front_renderer.material = new Material(Shader.Find("Standard"))
            {
                mainTexture = Icons.button
            };
            front_renderer.material.EnableKeyword("_EMISSION");
            front_renderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            front_renderer.material.SetTexture("_EmissionMap", Icons.button);
            front_renderer.material.SetFloat("_EmissionScaleUI", 1f);
            front_renderer.material.SetColor("_EmissionColor", Color.white);

            front_canvas = new GameObject("Canvas");

            front_canvas.transform.parent = Front.transform;
            front_canvas.transform.position = Front.transform.position;
            front_canvas.transform.localPosition -= new Vector3(0f, 0f, 0.001f);
            front_canvas.transform.rotation = Front.transform.rotation;
            front_canvas.layer = LayerMask.NameToLayer("UI");
            _ = front_canvas.AddComponent<Canvas>();
            _ = front_canvas.AddComponent<CanvasScaler>();
            front_canvas.Set_Colliders_isTrigger(true);

            textObject = new GameObject("Text");

            textObject.transform.parent = front_canvas.transform;
            textObject.transform.position = front_canvas.transform.position;
            textObject.transform.rotation = front_canvas.transform.rotation;
            textObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.004f);
            textObject.layer = LayerMask.NameToLayer("UI");
            _ = textObject.AddComponent<CanvasRenderer>();
            textObject.Set_Colliders_isTrigger(true);
            front_text = textObject.AddComponent<TextMeshPro>();
            front_text.color = Color.black;
            front_text.text = label;
            front_text.richText = true;
            front_text.alignment = TextAlignmentOptions.Center;
            front_text.enableAutoSizing = true;
            front_text.fontSizeMin = 0f;
            front_text.fontSizeMax = 72f;

            // Avoid button repelling you like bruh

            Physics.IgnoreCollision(GameInstances.LocalPlayer.gameObject.GetComponent<Collider>(), ButtonObject.GetComponent<Collider>());
            Physics.IgnoreCollision(GameInstances.LocalPlayer.gameObject.GetComponent<Collider>(), Front.GetComponent<Collider>());
            Physics.IgnoreCollision(GameInstances.LocalPlayer.gameObject.GetComponent<Collider>(), front_canvas.GetComponent<Collider>());
            Physics.IgnoreCollision(GameInstances.LocalPlayer.gameObject.GetComponent<Collider>(), textObject.GetComponent<Collider>());

        }
    }
}