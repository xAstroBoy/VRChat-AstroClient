namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using AstroClient.Tools.Extensions;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class RigidBodyController : AstroMonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public RigidBodyController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        internal void Start()
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
            EditMode = false;
            InvokeRepeating(nameof(BodyUpdate), 0.1f, 0.3f);

        }

        private void BodyUpdate()
        {
            if (gameObject != null)
            {
                if (gameObject.active && this.isActiveAndEnabled)
                {
                    if (!EditMode)
                    {   // Add a Sync Mechanism if Edit Mode is off and is not Applying edits anymore.
                        Run_OnRigidbodyControllerOnUpdate();

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

        internal void FixedUpdate()
        {

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
            [HideFromIl2Cpp]
            get
            {
                return _solverVelocityIterationCount;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _inertiaTensor;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _inertiaTensorRotation;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _centerOfMass;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _collisionDetectionMode;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _constraints;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _freezeRotation;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _maxDepenetrationVelocity;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _detectCollisions;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _useGravity;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _mass;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _solverIterationCount;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _angularDrag;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _drag;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _angularVelocity;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _velocity;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _isKinematic;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _sleepVelocity;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _sleepThreshold;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _maxAngularVelocity;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _solverVelocityIterations;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _interpolation;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _sleepAngularVelocity;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _useConeFriction;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _solverIterations;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
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

        internal bool UpdateKinematic(bool isKinematic)
        {
            this.isKinematic = isKinematic;
            return this.isKinematic == isKinematic;
        }

        internal void OverrideInternalKinematic(bool isKinematic)
        {
            Original_isKinematic = isKinematic;
        }

        internal bool UpdateAngularDrag(float angularDrag)
        {
            this.angularDrag = angularDrag;
            return this.angularDrag == angularDrag;
        }

        internal bool UpdateDrag(float drag)
        {
            this.drag = drag;
            return this.drag == drag;
        }

        #endregion Random Methods

        #region Essential Variables.

        internal Rigidbody Rigidbody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal SyncPhysics SyncPhysics { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private bool _EditMode = false;

        private bool IsActived = false;

        internal bool EditMode
        {
            [HideFromIl2Cpp]
            get
            {
                return _EditMode;
            }
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get
            {
                return _Forced_RigidBody;
            }
            [HideFromIl2Cpp]
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