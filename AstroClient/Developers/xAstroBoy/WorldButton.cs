using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientResources.Loaders;
using AstroClient.febucci;
using AstroClient.febucci.Utilities;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.xAstroBoy.Utility;
using TMPro;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.xAstroBoy
{
    internal class WorldButton
    {
        internal GameObject ButtonBody { get; set; }
        internal GameObject Front { get; set; }
        internal GameObject Canvas { get; set; }
        internal GameObject Text { get; set; }

        internal VRC_AstroInteract AstroTrigger { get; set; }

        internal Rigidbody RigidBody { get; set; }

        internal TextMeshPro TextMesh { get; set; }
        internal TextAnimator Animator { get; set; }
        internal void DestroyMe()
        {
            if (ButtonBody != null) ButtonBody.DestroyMeLocal();
        }


        internal void RegisterToWorldMenu()
        {
            ButtonBody.AddToWorldUtilsMenu();
        }

        internal void MakePickupable()
        {
            FixPlayercollisions();
            ButtonBody.Pickup_Set_ForceComponent();
            ButtonBody.Pickup_Set_AutoHoldMode(VRC_Pickup.AutoHoldMode.Yes);
            ButtonBody.RigidBody_Override_isKinematic(true);
            ButtonBody.Pickup_Set_Pickupable(true);

            ButtonBody.SetMesh_IsConvex(true);
            Front.SetMesh_IsConvex(false);
            Text.SetMesh_IsConvex(false);

        }

        internal void FixPlayercollisions()
        {
            ButtonBody.IgnoreLocalPlayerCollision(true, true);
            Front.IgnoreLocalPlayerCollision(true, true);
            Text.IgnoreLocalPlayerCollision(true, true);
            ButtonBody.SetMesh_IsConvex(false);
            Front.SetMesh_IsConvex(false);
            Text.SetMesh_IsConvex(false);
        }

        internal WorldButton(Vector3 position, Vector3 rotation, string label, Action action)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton, position, Quaternion.Euler(rotation));
            InitializeButton(label, action);
        }
        internal WorldButton(Vector3 position, Quaternion rotation, string label, Action action)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton, position, rotation);
            InitializeButton(label, action);
        }


        internal WorldButton(Vector3 position, Vector3 rotation, Transform parent, string label, Action action)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton, position, Quaternion.Euler(rotation), parent);
            InitializeButton(label, action);

        }
        internal WorldButton(Vector3 position, Quaternion rotation, Transform parent, string label, Action action)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton, position, rotation, parent);
            InitializeButton(label, action);
        }
        internal void RotateButton(float Rotate)
        {
            ButtonBody.transform.eulerAngles = new Vector3(0, Rotate, 0);
        }
        internal void SetScale(Vector3 Scale)
        {
            ButtonBody.transform.localScale = Scale;
        }

        internal void SetText(string text)
        {
            if(text.NeedsTextAnimator())
            {
                if(Animator == null)
                {
                    Animator = TextMesh.GetOrAddComponent<TextAnimator>();
                }
                if (Animator.Fulltext == text) return;
                //TextMesh.text = text;
                Animator.Safe_SetText(text);

            }
            else
            {
                if (Animator != null)
                {
                    Animator.DestroyMeLocal(true);
                }
                if (TextMesh.text == text) return;
                TextMesh.text = text;
            }
        }

        
        internal void SetAction(Action action)
        {
            if (Front != null)
            {
                AstroTrigger = ComponentUtils.GetOrAddComponent<VRC_AstroInteract>(Front);
                if (AstroTrigger != null)
                {
                    AstroTrigger.OnInteract = action;
                }
            }
        }
        internal void SetInteractText(string text)
        {
            if (Front != null)
            {
                AstroTrigger = ComponentUtils.GetOrAddComponent<VRC_AstroInteract>(Front);
                if (AstroTrigger != null)
                {
                    AstroTrigger.interactText = text;
                }
            }
        }
        internal void SetTextColor(Color color)
        {
            TextMesh.color = color;
        }
        internal void RemoveInteractions()
        {
            AstroTrigger.DestroyMeLocal(true);
        }

        private void InitializeButton(string label, Action action)
        {
            ButtonBody.name = $"AstroWorldButton: {label}";
            ButtonBody.transform.localScale = new Vector3(0.15f, 0.1f, 0.3f);
            ButtonBody.GetComponent<Renderer>().material = Materials.fabric_padded_005;
            Front = ButtonBody.FindObject("Front");
            Canvas = Front.FindObject("Canvas");
            Text = Canvas.FindObject("Text");
            TextMesh = Text.GetComponent<TextMeshPro>();
            if (Front != null)
            {
                AstroTrigger = Front.AddComponent<VRC_AstroInteract>();
                if (AstroTrigger != null)
                {
                    AstroTrigger.interactText = label;
                    AstroTrigger.OnInteract = action;
                }
            }

            if (TextMesh != null)
            {
                TextMesh.color = Color.black;
                TextMesh.richText = true;
                SetText(label);
                if(Animator != null)
                {
                    AstroTrigger.interactText = Animator.text;
                }
            }
            FixPlayercollisions();
        }
    }
}