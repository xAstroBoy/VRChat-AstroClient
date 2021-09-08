namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class RigidBodyController : GameEventsBehaviour
    {
        public RigidBodyController(IntPtr ptr) : base(ptr)
        {
        }

        // Use this for initialization
        public void Start()
        {
            SyncPhysics = gameObject.GetComponent<SyncPhysics>();
            if (SyncPhysics == null)
            {
                Rigidbody = gameObject.GetComponent<Rigidbody>();
            }
            else
            {
                Rigidbody = SyncPhysics.GetRigidBody();
                if (Rigidbody == null)
                {
                    Rigidbody = gameObject.GetComponent<Rigidbody>();
                }
            }
            ModConsole.DebugLog("Attacked Successfully RigidBodyController to object " + gameObject.name);
            InvokeRepeating(nameof(Updater), 0.1f, 0.3f);
            EditMode = false;
        }

        private void BackupBasicBody()
        {
            if (Rigidbody != null)
            {
                if (_EditMode)
                {
                    _EditMode = false; // To be sure to backup the original properties without writing them .
                }
                ModConsole.DebugLog($"Backupping from RigidBody properties for object  {gameObject.name}");
                solverVelocityIterationCount = Rigidbody.solverVelocityIterationCount;
                inertiaTensor = Rigidbody.inertiaTensor;
                inertiaTensorRotation = Rigidbody.inertiaTensorRotation;
                centerOfMass = Rigidbody.centerOfMass;
                collisionDetectionMode = Rigidbody.collisionDetectionMode;
                constraints = Rigidbody.constraints;
                freezeRotation = Rigidbody.freezeRotation;
                maxDepenetrationVelocity = Rigidbody.maxDepenetrationVelocity;
                detectCollisions = Rigidbody.detectCollisions;
                useGravity = Rigidbody.useGravity;
                mass = Rigidbody.mass;
                solverIterationCount = Rigidbody.solverIterationCount;
                angularDrag = Rigidbody.angularDrag;
                drag = Rigidbody.drag;
                angularVelocity = Rigidbody.angularVelocity;
                velocity = Rigidbody.velocity;
                isKinematic = Rigidbody.isKinematic;
                sleepVelocity = Rigidbody.sleepVelocity;
                sleepThreshold = Rigidbody.sleepThreshold;
                maxAngularVelocity = Rigidbody.maxAngularVelocity;
                solverVelocityIterations = Rigidbody.solverVelocityIterations;
                interpolation = Rigidbody.interpolation;
                sleepAngularVelocity = Rigidbody.sleepAngularVelocity;
                useConeFriction = Rigidbody.useConeFriction;
                solverIterations = Rigidbody.solverIterations;

                Original_solverVelocityIterationCount = Rigidbody.solverVelocityIterationCount;
                Original_inertiaTensor = Rigidbody.inertiaTensor;
                Original_inertiaTensorRotation = Rigidbody.inertiaTensorRotation;
                Original_centerOfMass = Rigidbody.centerOfMass;
                Original_collisionDetectionMode = Rigidbody.collisionDetectionMode;
                Original_constraints = Rigidbody.constraints;
                Original_freezeRotation = Rigidbody.freezeRotation;
                Original_maxDepenetrationVelocity = Rigidbody.maxDepenetrationVelocity;
                Original_detectCollisions = Rigidbody.detectCollisions;
                Original_useGravity = Rigidbody.useGravity;
                Original_mass = Rigidbody.mass;
                Original_solverIterationCount = Rigidbody.solverIterationCount;
                Original_angularDrag = Rigidbody.angularDrag;
                Original_drag = Rigidbody.drag;
                Original_angularVelocity = Rigidbody.angularVelocity;
                Original_velocity = Rigidbody.velocity;
                Original_isKinematic = Rigidbody.isKinematic;
                Original_sleepVelocity = Rigidbody.sleepVelocity;
                Original_sleepThreshold = Rigidbody.sleepThreshold;
                Original_maxAngularVelocity = Rigidbody.maxAngularVelocity;
                Original_solverVelocityIterations = Rigidbody.solverVelocityIterations;
                Original_interpolation = Rigidbody.interpolation;
                Original_sleepAngularVelocity = Rigidbody.sleepAngularVelocity;
                Original_useConeFriction = Rigidbody.useConeFriction;
                Original_solverIterations = Rigidbody.solverIterations;
            }
            _EditMode = false;
        }

        internal void RestoreOriginalBody() // Restore only if Editmode is already active, and Activate sync mode Once Restored.
        {
            if (!_EditMode)
            {
                _EditMode = true;
            }
            if (_EditMode)
            {
                solverVelocityIterationCount = Original_solverVelocityIterationCount;
                inertiaTensor = Original_inertiaTensor;
                inertiaTensorRotation = Original_inertiaTensorRotation;
                centerOfMass = Original_centerOfMass;
                collisionDetectionMode = Original_collisionDetectionMode;
                constraints = Original_constraints;
                freezeRotation = Original_freezeRotation;
                maxDepenetrationVelocity = Original_maxDepenetrationVelocity;
                detectCollisions = Original_detectCollisions;
                useGravity = Original_useGravity;
                mass = Original_mass;
                solverIterationCount = Original_solverIterationCount;
                angularDrag = Original_angularDrag;
                drag = Original_drag;
                angularVelocity = Original_angularVelocity;
                velocity = Original_velocity;
                isKinematic = Original_isKinematic;
                sleepVelocity = Original_sleepVelocity;
                sleepThreshold = Original_sleepThreshold;
                maxAngularVelocity = Original_maxAngularVelocity;
                solverVelocityIterations = Original_solverVelocityIterations;
                interpolation = Original_interpolation;
                sleepAngularVelocity = Original_sleepAngularVelocity;
                useConeFriction = Original_useConeFriction;
                solverIterations = Original_solverIterations;
                _EditMode = false;
            }
        }

        public void Updater()
        {
            if (gameObject != null)
            {
                if (gameObject.active && this.isActiveAndEnabled)
                {
                    // Add a Sync Mechanism if Edit Mode is off and is not Applying edits anymore.
                    Run_OnRigidbodyControllerOnUpdate();
                    if (!EditMode)
                    {
                        // Makes sure if EditMode is OFF. As long is off it keeps updating the properties.
                        if (Rigidbody != null)
                        {
                            solverVelocityIterationCount = Rigidbody.solverVelocityIterationCount;
                            inertiaTensor = Rigidbody.inertiaTensor;
                            inertiaTensorRotation = Rigidbody.inertiaTensorRotation;
                            centerOfMass = Rigidbody.centerOfMass;
                            collisionDetectionMode = Rigidbody.collisionDetectionMode;
                            constraints = Rigidbody.constraints;
                            freezeRotation = Rigidbody.freezeRotation;
                            maxDepenetrationVelocity = Rigidbody.maxDepenetrationVelocity;
                            detectCollisions = Rigidbody.detectCollisions;
                            useGravity = Rigidbody.useGravity;
                            mass = Rigidbody.mass;
                            solverIterationCount = Rigidbody.solverIterationCount;
                            angularDrag = Rigidbody.angularDrag;
                            drag = Rigidbody.drag;
                            angularVelocity = Rigidbody.angularVelocity;
                            velocity = Rigidbody.velocity;
                            isKinematic = Rigidbody.isKinematic;
                            sleepVelocity = Rigidbody.sleepVelocity;
                            sleepThreshold = Rigidbody.sleepThreshold;
                            maxAngularVelocity = Rigidbody.maxAngularVelocity;
                            solverVelocityIterations = Rigidbody.solverVelocityIterations;
                            interpolation = Rigidbody.interpolation;
                            sleepAngularVelocity = Rigidbody.sleepAngularVelocity;
                            useConeFriction = Rigidbody.useConeFriction;
                            solverIterations = Rigidbody.solverIterations;

                            Original_solverVelocityIterationCount = Rigidbody.solverVelocityIterationCount;
                            Original_inertiaTensor = Rigidbody.inertiaTensor;
                            Original_inertiaTensorRotation = Rigidbody.inertiaTensorRotation;
                            Original_centerOfMass = Rigidbody.centerOfMass;
                            Original_collisionDetectionMode = Rigidbody.collisionDetectionMode;
                            Original_constraints = Rigidbody.constraints;
                            Original_freezeRotation = Rigidbody.freezeRotation;
                            Original_maxDepenetrationVelocity = Rigidbody.maxDepenetrationVelocity;
                            Original_detectCollisions = Rigidbody.detectCollisions;
                            Original_useGravity = Rigidbody.useGravity;
                            Original_mass = Rigidbody.mass;
                            Original_solverIterationCount = Rigidbody.solverIterationCount;
                            Original_angularDrag = Rigidbody.angularDrag;
                            Original_drag = Rigidbody.drag;
                            Original_angularVelocity = Rigidbody.angularVelocity;
                            Original_velocity = Rigidbody.velocity;
                            Original_isKinematic = Rigidbody.isKinematic;
                            Original_sleepVelocity = Rigidbody.sleepVelocity;
                            Original_sleepThreshold = Rigidbody.sleepThreshold;
                            Original_maxAngularVelocity = Rigidbody.maxAngularVelocity;
                            Original_solverVelocityIterations = Rigidbody.solverVelocityIterations;
                            Original_interpolation = Rigidbody.interpolation;
                            Original_sleepAngularVelocity = Rigidbody.sleepAngularVelocity;
                            Original_useConeFriction = Rigidbody.useConeFriction;
                            Original_solverIterations = Rigidbody.solverIterations;
                        }
                    }
                }
            }
        }

        #region Rigidbody Reflected Properties

        #region Internal Reflection (Private Values, Do Not Edit.)

        private int _solverVelocityIterationCount;
        private Vector3 _inertiaTensor;
        private Quaternion _inertiaTensorRotation;
        private Vector3 _centerOfMass;
        private CollisionDetectionMode _collisionDetectionMode;
        private RigidbodyConstraints _constraints;
        private bool _freezeRotation;
        private float _maxDepenetrationVelocity;
        private bool _detectCollisions;
        private bool _useGravity;
        private float _mass;
        private int _solverIterationCount;
        private float _angularDrag;
        private float _drag;
        private Vector3 _angularVelocity;
        private Vector3 _velocity;
        private bool _isKinematic;
        private float _sleepVelocity;
        private float _sleepThreshold;
        private float _maxAngularVelocity;
        private int _solverVelocityIterations;
        private RigidbodyInterpolation _interpolation;
        private float _sleepAngularVelocity;
        private bool _useConeFriction;
        private int _solverIterations;

        #endregion Internal Reflection (Private Values, Do Not Edit.)

        internal int solverVelocityIterationCount
        {
            get
            {
                return _solverVelocityIterationCount;
            }
            set
            {
                _solverVelocityIterationCount = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverVelocityIterationCount = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 inertiaTensor
        {
            get
            {
                return _inertiaTensor;
            }
            set
            {
                _inertiaTensor = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.inertiaTensor = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Quaternion inertiaTensorRotation
        {
            get
            {
                return _inertiaTensorRotation;
            }
            set
            {
                _inertiaTensorRotation = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.inertiaTensorRotation = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 centerOfMass
        {
            get
            {
                return _centerOfMass;
            }
            set
            {
                _centerOfMass = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.centerOfMass = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal CollisionDetectionMode collisionDetectionMode
        {
            get
            {
                return _collisionDetectionMode;
            }
            set
            {
                _collisionDetectionMode = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.collisionDetectionMode = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal RigidbodyConstraints constraints
        {
            get
            {
                return _constraints;
            }
            set
            {
                _constraints = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.constraints = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool freezeRotation
        {
            get
            {
                return _freezeRotation;
            }
            set
            {
                _freezeRotation = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.freezeRotation = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float maxDepenetrationVelocity
        {
            get
            {
                return _maxDepenetrationVelocity;
            }
            set
            {
                _maxDepenetrationVelocity = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.maxDepenetrationVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool detectCollisions
        {
            get
            {
                return _detectCollisions;
            }
            set
            {
                _detectCollisions = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.detectCollisions = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool useGravity
        {
            get
            {
                return _useGravity;
            }
            set
            {
                _useGravity = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.useGravity = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float mass
        {
            get
            {
                return _mass;
            }
            set
            {
                _mass = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.mass = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal int solverIterationCount
        {
            get
            {
                return _solverIterationCount;
            }
            set
            {
                _solverIterationCount = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverIterationCount = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float angularDrag
        {
            get
            {
                return _angularDrag;
            }
            set
            {
                _angularDrag = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.angularDrag = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float drag
        {
            get
            {
                return _drag;
            }
            set
            {
                _drag = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.drag = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 angularVelocity
        {
            get
            {
                return _angularVelocity;
            }
            set
            {
                _angularVelocity = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.angularVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.velocity = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool isKinematic
        {
            get
            {
                return _isKinematic;
            }
            set
            {
                _isKinematic = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.isKinematic = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }



        internal float sleepVelocity
        {
            get
            {
                return _sleepVelocity;
            }
            set
            {
                _sleepVelocity = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.sleepVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float sleepThreshold
        {
            get
            {
                return _sleepThreshold;
            }
            set
            {
                _sleepThreshold = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.sleepThreshold = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float maxAngularVelocity
        {
            get
            {
                return _maxAngularVelocity;
            }
            set
            {
                _maxAngularVelocity = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.maxAngularVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal int solverVelocityIterations
        {
            get
            {
                return _solverVelocityIterations;
            }
            set
            {
                _solverVelocityIterations = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverVelocityIterations = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal RigidbodyInterpolation interpolation
        {
            get
            {
                return _interpolation;
            }
            set
            {
                _interpolation = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.interpolation = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float sleepAngularVelocity
        {
            get
            {
                return _sleepAngularVelocity;
            }
            set
            {
                _sleepAngularVelocity = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.sleepAngularVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool useConeFriction
        {
            get
            {
                return _useConeFriction;
            }
            set
            {
                _useConeFriction = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.useConeFriction = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal int solverIterations
        {
            get
            {
                return _solverIterations;
            }
            set
            {
                _solverIterations = value;
                if (EditMode)
                {
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverIterations = value;
                        SyncPhysics.RefreshProperties();
                    }
                }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        // Only getters
        internal Vector3 worldCenterOfMass
        {
            get
            {
                if (Rigidbody != null)
                {
                    return Rigidbody.worldCenterOfMass;
                }
                return Vector3.zero;
            }
        }

        #endregion Rigidbody Reflected Properties

        #region Backupped Properties

        private int Original_solverVelocityIterationCount;
        private Vector3 Original_inertiaTensor;
        private Quaternion Original_inertiaTensorRotation;
        private Vector3 Original_centerOfMass;
        private CollisionDetectionMode Original_collisionDetectionMode;
        private RigidbodyConstraints Original_constraints;
        private bool Original_freezeRotation;
        private float Original_maxDepenetrationVelocity;
        private bool Original_detectCollisions;
        private bool Original_useGravity;
        private float Original_mass;
        private int Original_solverIterationCount;
        private float Original_angularDrag;
        private float Original_drag;
        private Vector3 Original_angularVelocity;
        private Vector3 Original_velocity;
        private bool Original_isKinematic;
        private float Original_sleepVelocity;
        private float Original_sleepThreshold;
        private float Original_maxAngularVelocity;
        private int Original_solverVelocityIterations;
        private RigidbodyInterpolation Original_interpolation;
        private float Original_sleepAngularVelocity;
        private bool Original_useConeFriction;
        private int Original_solverIterations;

        #endregion Backupped Properties

        #region Actions To Bind

        private void Run_OnRigidBodyPropertyChanged()
        {
            OnRigidBodyPropertyChanged?.Invoke();
        }

        private void Run_OnRigidbodyControllerOnUpdate()
        {
            OnRigidbodyControllerOnUpdate?.Invoke();
        }

        internal void SetRigidBodyPropertyChanged(Action action)
        {
            OnRigidBodyPropertyChanged += action;
        }

        internal void SetOnRigidbodyControllerOnUpdate(Action action)
        {
            OnRigidbodyControllerOnUpdate += action;
        }

        internal void RemoveActionEvents()
        {
            OnRigidBodyPropertyChanged = null;
            OnRigidbodyControllerOnUpdate = null;
        }

        private event Action? OnRigidbodyControllerOnUpdate;

        private event Action? OnRigidBodyPropertyChanged;

        #endregion Actions To Bind

        #region Forced Rigidbody Method

        private void Force_RigidBody()
        {
            if (gameObject.GetComponent<Rigidbody>() == null && Rigidbody == null)
            {
                ModConsole.DebugLog($"RigidBodyController : Object {gameObject.name} Spawned Rigidbody..");
                Rigidbody = gameObject.AddComponent<Rigidbody>();
                isKinematic = true;
                Original_isKinematic = true;
            }
        }

        #endregion Forced Rigidbody Method

        #region Random Methods
        [HideFromIl2Cpp]
        internal bool UpdateKinematic(bool isKinematic)
        {
            this.isKinematic = isKinematic;
            return this.isKinematic == isKinematic;
        }

        [HideFromIl2Cpp]
        internal void OverrideInternalKinematic(bool isKinematic)
        {
            Original_isKinematic = isKinematic;
        }

        [HideFromIl2Cpp]
        internal bool UpdateAngularDrag(float angularDrag)
        {
            this.angularDrag = angularDrag;
            return this.angularDrag == angularDrag;
        }

        [HideFromIl2Cpp]
        internal bool UpdateDrag(float drag)
        {
            this.drag = drag;
            return this.drag == drag;
        }

        #endregion

        // TODO : Move it to PickupController...

        #region anti-grab method

        internal void PreventOthersFromHolding()
        {
            if (PreventOthersFromGrabbing)
            {
                if (!OnlineEditor.IsLocalPlayerOwner(gameObject))
                {
                    OnlineEditor.TakeObjectOwnership(gameObject);
                }
            }
        }

        private bool _PreventOthersFromGrabbing = false;

        internal bool PreventOthersFromGrabbing
        {
            get
            {
                return _PreventOthersFromGrabbing;
            }
            set
            {
                _PreventOthersFromGrabbing = value;
                Run_OnRigidBodyPropertyChanged();
            }
        }

        #endregion anti-grab method

        #region Essential Variables.

        internal Rigidbody Rigidbody { get; private set; }
        internal SyncPhysics SyncPhysics { get; private set; }
        private bool _EditMode = false;

        private bool IsActived = false;

        internal bool EditMode
        {
            get
            {
                return _EditMode;
            }
            set
            {
                if (value != _EditMode)
                {
                    if (value)
                    {
                        BackupBasicBody();
                    }
                    else
                    {
                        RestoreOriginalBody();
                    }
                    Run_OnRigidBodyPropertyChanged();
                }
                _EditMode = value;
            }
        }

        private bool _Forced_RigidBody;

        internal bool Forced_Rigidbody
        {
            get
            {
                return _Forced_RigidBody;
            }
            set
            {
                if (value)
                {
                    if (!Forced_Rigidbody)
                    {
                        Force_RigidBody();
                        _Forced_RigidBody = true;
                    }
                }
                else
                {
                    if (_Forced_RigidBody)
                    {
                        return;
                    }
                }
            }
        }

        #endregion Essential Variables.
    }
}