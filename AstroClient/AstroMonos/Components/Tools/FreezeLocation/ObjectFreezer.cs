namespace AstroClient.AstroMonos.Components.Custom.Random
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

    [RegisterComponent]
    public class ObjectFreezer : AstroMonoBehaviour
    {

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



        private RigidBodyController _RigidBodyController { [HideFromIl2Cpp] get; set; }

        private RigidBodyController RigidBodyController
        {
            [HideFromIl2Cpp]
            get
            {
                if (_RigidBodyController == null)
                {
                    _RigidBodyController = gameObject.GetOrAddComponent<RigidBodyController>();
                }

                return _RigidBodyController;
            }
        }

        private PickupController _PickupController { [HideFromIl2Cpp] get; set; }

        private PickupController PickupController
        {
            [HideFromIl2Cpp]
            get
            {
                if (_PickupController == null)
                {
                    _PickupController = gameObject.GetOrAddComponent<PickupController>();
                }

                return _PickupController;
            }
        }
        private VRC_AstroPickup VRC_AstroPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool HasCaptured { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private string OriginalText_Use { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool HasFrozen { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private bool _isPaused { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private bool isPaused
        {
            [HideFromIl2Cpp] get => _isPaused;
            [HideFromIl2Cpp]
            set
            {
                _isPaused = value;
                if (value)
                {
                    RestoreToOriginal();
                }
                else
                {
                    FreezeItem();
                    Capture();
                }
            }
        }

        internal Vector3 FreezePos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Quaternion FreezeRot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }



        private bool _IsEnabled = true;
        internal bool IsEnabled
        {
            [HideFromIl2Cpp] get => _IsEnabled;
            [HideFromIl2Cpp]
            set
            {
                Capture();
                _IsEnabled = value;
                if (VRC_AstroPickup != null)
                {
                    if (value) VRC_AstroPickup.UseText = "Toggle Off Freeze";
                    else VRC_AstroPickup.UseText = "Toggle On Freeze";
                }
                if (value)
                {
                    FreezeItem();
                    Capture();
                }
                else
                {
                    RestoreToOriginal();
                }
            }
        }

        private void RestoreToOriginal()
        {
            try
            {
                HasFrozen = false;
                if (RigidBodyController != null)
                {
                    var will_it_fall_throught = RigidBodyController.RigidBody_Will_It_fall_throught();
                    if (!will_it_fall_throught)
                    {
                        RigidBodyController.Override_isKinematic(false);
                    }

                    RigidBodyController.Override_UseGravity(true);
                    RigidBodyController.useGravity = true;
                    RigidBodyController.EditMode = false;
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private void FreezeItem()
        {
            try
            {
                if (!HasFrozen)
                {
                    if (RigidBodyController != null)
                    {
                        if (!RigidBodyController.EditMode)
                        {
                            RigidBodyController.EditMode = true;
                        }

                        RigidBodyController.isKinematic = true;
                        HasFrozen = true;
                    }
                    else
                    {
                        HasFrozen = false;
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }


        // Use this for initialization
        private void Start()
        {
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace()) OriginalText_Use = PickupController.UseText;
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += OnPickup;
                VRC_AstroPickup.OnPickupUseDown += OnPickupUseDown;
                VRC_AstroPickup.OnDrop += onDrop;
                if (IsEnabled) VRC_AstroPickup.UseText = "Toggle Off Freeze";
                else VRC_AstroPickup.UseText = "Toggle On Freeze";
            }

        }

        /// <summary>
        /// Flag it To Semi-permanently freeze A Gameobject to that position (Disable future captures)
        /// </summary>
        internal bool LockPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        /// <summary>
        /// Calling this will Refresh Position/rotation capture of the current gameobject
        /// </summary>
        internal void Capture()
        {
            if (!LockPosition)
            {
                if (RigidBodyController == null)
                {
                    FreezePos = gameObject.transform.position;
                    FreezeRot = gameObject.transform.rotation;
                }
                else
                {
                    FreezePos = RigidBodyController.position;
                    FreezeRot = RigidBodyController.rotation;
                }
            }
            HasCaptured = true;
        }
        internal void Capture(Vector3 Position, Quaternion Rotation)
        {
            if (!LockPosition)
            {
                FreezePos = Position;
                FreezeRot = Rotation;
            }
            HasCaptured = true;
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
            isPaused = false;
        }

        private void Update()
        {
            if (!IsEnabled || isPaused)
            {
                return;
            }

            if (HasCaptured)
            {
                gameObject.TakeOwnership();
                if (!HasFrozen)
                {
                    FreezeItem(); // Freeze!
                }
                if (RigidBodyController.position != FreezePos)
                {
                    RigidBodyController.position = FreezePos;
                   // RigidBodyController.MovePosition(FreezePos);
                }

                if (RigidBodyController.rotation != FreezeRot)
                {
                    RigidBodyController.rotation = FreezeRot;
                    //RigidBodyController.MoveRotation(FreezeRot);
                }
            }
        }

        private void OnDestroy()
        {
            try
            {
                RestoreToOriginal();
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