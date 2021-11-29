namespace AstroClient.AstroMonos.Components.Tools.FreezeLocation
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.Extensions.Components_exts;
    using AstroClient.Tools.ObjectEditor.Online;
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

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

        private RigidBodyController CurrentRigidbody
        {
            [HideFromIl2Cpp]
            get
            {
                if (_RigidBodyController == null)
                {
                    return _RigidBodyController = gameObject.GetOrAddComponent<RigidBodyController>();
                }

                return _RigidBodyController;
            }
        }

        private PickupController _Pickup { [HideFromIl2Cpp] get; set; }

        private PickupController Pickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Pickup == null)
                {
                    return _Pickup = gameObject.GetOrAddComponent<PickupController>();
                }

                return _Pickup;
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
                if (IsEnabled)
                {
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
                if (CurrentRigidbody != null)
                {
                    CurrentRigidbody.EditMode = false;

                    var will_it_fall_throught = CurrentRigidbody.RigidBody_Will_It_fall_throught();
                    if (!will_it_fall_throught)
                    {
                        CurrentRigidbody.isKinematic = false;
                        CurrentRigidbody.Override_isKinematic(false);
                    }
                    CurrentRigidbody.Override_UseGravity(true);
                    HasFrozen = false;
                }
                else
                {
                    HasFrozen = true;
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
                HasFrozen = true;
            }
        }

        private void FreezeItem()
        {
            try
            {
                if (!HasFrozen)
                {
                    if (CurrentRigidbody != null)
                    {
                        if (!CurrentRigidbody.EditMode)
                        {
                            CurrentRigidbody.EditMode = true;
                        }

                        CurrentRigidbody.isKinematic = true;
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
                HasFrozen = false;
                ModConsole.ErrorExc(e);
            }
        }


        // Use this for initialization
        private void Start()
        {
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace()) OriginalText_Use = Pickup.UseText;
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += OnPickup;
                VRC_AstroPickup.OnPickupUseDown += OnPickupUseDown;
                VRC_AstroPickup.OnDrop += onDrop;
                if (IsEnabled) VRC_AstroPickup.UseText = "Toggle Off Freeze";
                else VRC_AstroPickup.UseText = "Toggle On Freeze";
            }

            if (IsEnabled)
            {
                FreezeItem();
                Capture();
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
                if (CurrentRigidbody == null)
                {
                    FreezePos = gameObject.transform.position;
                    FreezeRot = gameObject.transform.rotation;
                }
                else
                {
                    FreezePos = CurrentRigidbody.position;
                    FreezeRot = CurrentRigidbody.rotation;
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

                if (CurrentRigidbody.position != FreezePos)
                {
                    CurrentRigidbody.position = FreezePos;
                   // RigidBodyController.MovePosition(FreezePos);
                }

                if (CurrentRigidbody.rotation != FreezeRot)
                {
                    CurrentRigidbody.rotation = FreezeRot;
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
                Pickup.UseText = OriginalText_Use;
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

    }
}