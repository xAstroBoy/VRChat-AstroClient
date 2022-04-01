using AstroClient.xAstroBoy;

namespace AstroClient.CheetosUI
{
    using System;
    using AstroMonos.AstroUdons;
    using ClientResources.Loaders;
    using TMPro;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.Utility;

    internal class WorldButton
    {
        internal GameObject ButtonBody { get; set; }
        internal GameObject Front { get; set; }
        internal GameObject Canvas { get; set; }
        internal GameObject Text { get; set; }

        internal VRC_AstroInteract AstroTrigger { get; set; }

        internal Rigidbody RigidBody { get; set; }

        internal TextMeshPro TextMesh { get; set; }

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
            ButtonBody.RigidBody_Override_isKinematic(true);
            ButtonBody.Pickup_Set_Pickupable(true);

        }

        internal void FixPlayercollisions()
        {
            ButtonBody.IgnoreLocalPlayerCollision(true, true);
            Front.IgnoreLocalPlayerCollision(true, true);
            Text.IgnoreLocalPlayerCollision(true, true);
        }

        internal WorldButton(Vector3 position, Quaternion rotation, string label, Action action)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton, position, rotation);
            ButtonBody.name = $"AstroWorldButton: {label}";

            ButtonBody.transform.localScale = new Vector3(0.15f, 0.1f, 0.3f);
            ButtonBody.GetComponent<Renderer>().material = Materials.fabric_padded_005;

            Front = ButtonBody.FindObject("Front");
            Canvas = Front.FindObject("Canvas");
            Text = Canvas.FindObject("Text");

            TextMesh = Text.GetComponent<TextMeshPro>();


            if (Front != null)
            {
                MiscUtils.DelayFunction(0.2f, () =>
                {
                    AstroTrigger = Front.AddComponent<VRC_AstroInteract>();
                    if (AstroTrigger != null)
                    {
                        AstroTrigger.interactText = label;
                        AstroTrigger.OnInteract = action;
                    }
                });
            }

            if(TextMesh != null)
            {
                TextMesh.color = Color.black;
                TextMesh.text =  label;
                TextMesh.richText = true;
            }
            FixPlayercollisions(); 

        }
    }
}