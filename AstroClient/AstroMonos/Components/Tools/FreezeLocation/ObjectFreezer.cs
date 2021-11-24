namespace AstroClient.AstroMonos.Components.Custom.Random
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.ObjectEditor.Online;
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

        private float CheckisOwnerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private float CheckisOwnerDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 16f;
        private bool CheckisOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private float FreezeTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _FreezeTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.07f;

        internal float FreezeTimer
        {
            [HideFromIl2Cpp]
            get => _FreezeTimer;
            [HideFromIl2Cpp]
            set
            {
                _FreezeTimer = value;
            }
        }



        private bool isCurrentOwner
        {
            [HideFromIl2Cpp]
            get
            {
                if (CheckisOwner) return gameObject.TryTakeOwnership();
                return true;
            }
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
                _IsEnabled = value;
                if (VRC_AstroPickup != null)
                {
                    if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace()) OriginalText_Use = PickupController.UseText;
                    if (value) VRC_AstroPickup.UseText = "Toggle Off Freeze";
                    else VRC_AstroPickup.UseText = "Toggle On Freeze";
                }

                if (value)
                {
                    if (RigidBodyController != null)
                    {
                        RigidBodyController.EditMode = true;
                        RigidBodyController.isKinematic = true;
                    }

                    FreezePos = gameObject.transform.position;
                    FreezeRot = gameObject.transform.rotation;
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
            RigidBodyController = GetComponent<RigidBodyController>();
            RigidBodyController ??= gameObject.AddComponent<RigidBodyController>();
            PickupController = GetComponent<PickupController>();
            PickupController ??= gameObject.AddComponent<PickupController>();
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += () => { isPaused = true; };
                VRC_AstroPickup.OnPickupUseDown += () => { IsEnabled = !IsEnabled; };
                VRC_AstroPickup.OnDrop += () => { isPaused = false; };
            }


            IsEnabled = false;
        }

        private void Update()
        {
            if (!IsEnabled || isPaused)
            {
                return;
            }

            if (!CheckisOwner)
                if (Time.time - CheckisOwnerTimeCheck > CheckisOwnerDelay)
                {
                    CheckisOwner = true;
                    CheckisOwnerTimeCheck = Time.time;
                }

            if (Time.time - FreezeTimeCheck > FreezeTimer)
            {
                if (isCurrentOwner)
                {
                    if (gameObject.transform.position != FreezePos)
                    {
                        gameObject.transform.position = FreezePos;
                    }
                    if (gameObject.transform.rotation != FreezeRot)
                    {
                        gameObject.transform.rotation = FreezeRot;
                    }
                }

                FreezeTimeCheck = Time.time;
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