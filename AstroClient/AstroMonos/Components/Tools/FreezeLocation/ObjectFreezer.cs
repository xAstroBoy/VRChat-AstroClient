﻿namespace AstroClient.AstroMonos.Components.Custom.Random
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.Extensions.Components_exts;
    using AstroClient.Tools.ObjectEditor.Online;
    using AstroClient.xAstroBoy.Utility;
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using static AstroClient.Tools.ObjectEditor.Editor.Forces.Forces;
    using Random = UnityEngine.Random;

    [RegisterComponent]
    public class ObjectFreezer : AstroMonoBehaviour
    {

        private bool _IsEnabled;
        public List<AstroMonoBehaviour> AntiGcList;

        public ObjectFreezer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }



        private RigidBodyController RigidBodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PickupController PickupController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup VRC_AstroPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private string OriginalText_Use { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool isPaused { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 FreezePos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion FreezeRot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool IsEnabled
        {
            [HideFromIl2Cpp] get => _IsEnabled;
            [HideFromIl2Cpp]
            set
            {

                if (VRC_AstroPickup != null)
                {
                    if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace()) OriginalText_Use = PickupController.UseText;
                    if (value) VRC_AstroPickup.UseText = "Toggle Off Freeze";
                    else VRC_AstroPickup.UseText = "Toggle On Freeze";
                }
                FreezePos = gameObject.transform.position;
                FreezeRot = gameObject.transform.rotation;
                if (value.Equals(_IsEnabled)) return;
                _IsEnabled = value;
                if (value)
                {
                    if (RigidBodyController != null)
                    {
                        RigidBodyController.RigidBody_Set_isKinematic(true);
                    }
                }
                else
                {
                    RigidBodyController.RestoreOriginalBody();
                }

            }
        }

        // Use this for initialization
        private void Start()
        {
            RigidBodyController = gameObject.GetOrAddComponent<RigidBodyController>();
            PickupController = gameObject.GetOrAddComponent<PickupController>();
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += OnPickup;
                VRC_AstroPickup.OnPickupUseDown += OnPickupUseDown;
                VRC_AstroPickup.OnDrop += onDrop;
            }


            IsEnabled = false;
        }

        private void OnPickup()
        {
            isPaused = true;
        }
        private void OnPickupUseDown()
        {
            IsEnabled = !IsEnabled;
        }

        private void onDrop()
        {
            FreezePos = gameObject.transform.position;
            FreezeRot = gameObject.transform.rotation;
            isPaused = false;
        }

        private void FixedUpdate()
        {
            if (!IsEnabled || isPaused)
            {
                return;
            }

            gameObject.TryTakeOwnership();
            if (gameObject.transform.position != FreezePos)
            {
                gameObject.transform.position = FreezePos;
            }
            if (gameObject.transform.rotation != FreezeRot)
            {
                gameObject.transform.rotation = FreezeRot;
            }

        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                if (gameObject.IsOwner()) OnlineEditor.RemoveOwnerShip(gameObject);
                if (VRC_AstroPickup != null) Destroy(VRC_AstroPickup);
                PickupController.UseText = OriginalText_Use;
            }
            catch
            {
            }
        }

    }
}