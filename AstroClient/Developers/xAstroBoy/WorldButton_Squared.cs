using System;
using System.Web.UI;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientResources.Loaders;
using AstroClient.febucci;
using AstroClient.febucci.Utilities;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.xAstroBoy.Utility;
using ReimajoBoothAssets;
using TMPro;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.xAstroBoy
{
    internal class WorldButton_Squared
    {


        internal GameObject ButtonBody { get; set; }
        internal ButtonController Controller { get; set; }
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
            //ButtonBody.Pickup_Set_ForceComponent();
            //ButtonBody.Pickup_Set_AutoHoldMode(VRC_Pickup.AutoHoldMode.Yes);
            //ButtonBody.RigidBody_Override_isKinematic(true);
            //ButtonBody.Pickup_Set_Pickupable(true);
            ////Button.SetMesh_IsConvex(true);
            
        }


        internal WorldButton_Squared(Vector3 position, Vector3 rotation, string label, Action OnButtonDown = null, Action OnButtonUp = null)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton_Squared, position, Quaternion.Euler(rotation));
            InitializeButton(label, OnButtonDown, OnButtonUp);
        }
        internal WorldButton_Squared(Vector3 position, Quaternion rotation, string label, Action OnButtonDown = null, Action OnButtonUp = null)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton_Squared, position, rotation);
            InitializeButton(label, OnButtonDown, OnButtonUp);
        }


        internal WorldButton_Squared(Vector3 position, Vector3 rotation, Transform parent, string label, Action OnButtonDown = null, Action OnButtonUp = null)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton_Squared, position, Quaternion.Euler(rotation), parent);
            InitializeButton(label, OnButtonDown, OnButtonUp);

        }
        internal WorldButton_Squared(Vector3 position, Quaternion rotation, Transform parent, string label, Action OnButtonDown = null, Action OnButtonUp = null)
        {
            ButtonBody = GameObject.Instantiate(Prefabs.WorldButton_Squared, position, rotation, parent);
            InitializeButton(label, OnButtonDown, OnButtonUp);
        }
        internal void RotateButton(float Rotate)
        {
            ButtonBody.transform.eulerAngles = new Vector3(0, Rotate, 0);
        }
        internal void RotateButton(Vector3 Rotate)
        {
            ButtonBody.transform.eulerAngles = Rotate;
        }

        internal void SetScale(Vector3 Scale)
        {
            ButtonBody.transform.localScale = Scale;
        }
        internal void SetScale(float Scale)
        {
            ButtonBody.transform.localScale = new Vector3(Scale, Scale, Scale);
        }

        internal void SetText(string text)
        {
            Controller.SetText(text);
            ButtonBody.name = $"AstroWorldSquaredButton: {text}";
        }
        internal void Set_OnButtonDown(Action action)
        {
            if (Controller != null)
            {
                Controller.OnButtonDown += action;
            }
        }
        internal void Set_OnButtonUp(Action action)
        {
            if (Controller != null)
            {
                Controller.OnButtonUp += action;
            }
        }


        private void InitializeButton(string label, Action OnButtonDown, Action OnButtonUp)
        {
            ButtonBody.name = $"AstroWorldSquaredButton: {label}";
            SetScale(new Vector3(2, 2, 2));
            Controller = ButtonBody.FindObject("ButtonScript").GetOrAddComponent<ButtonController>();
            if(Controller != null)
            {
                Controller.OnButtonDown += OnButtonDown;
                Controller.OnButtonUp += OnButtonUp;
                Controller.SetText(label);
            }


        }
    }
}