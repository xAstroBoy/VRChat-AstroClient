using AstroClient.ClientActions;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Utility;

    // TODO : Fix this Crap Again ( Backupping mechanism doesn't work!)
    [RegisterComponent]
    public class RigidBodyController : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public RigidBodyController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        internal void Start()
        {
            SyncPhysics = gameObject.GetGetInChildrens<SyncPhysics>(true);
            if (SyncPhysics == null)
            {
                Rigidbody = gameObject.GetComponent<Rigidbody>();
            }
            else
            {
                Rigidbody = SyncPhysics.GetRigidBody();
                if (Rigidbody == null) Rigidbody = gameObject.GetComponent<Rigidbody>();
            }
            HasSubscribed = true;
            Log.Debug("Attacked Successfully RigidBodyController to object " + gameObject.name);
            BackupBasicBody();
            InvokeRepeating(nameof(BodyUpdate), 0.1f, 0.3f);
        }

        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        void OnDestroy()
        {
            HasSubscribed = false;
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }
        private void BodyUpdate()
        {

            if (gameObject != null)
                Run_OnRigidbodyControllerOnUpdate();
            if (gameObject.active && isActiveAndEnabled)
                if (isBackupping)
                    return;
            if (!EditMode)
            {
                // Add a Sync Mechanism if Edit Mode is off and is not Applying edits anymore.

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
                }
            }
        }

        internal void BackupBasicBody()
        {
            _EditMode = true; // To be sure to backup the original properties without writing them .
            isBackupping = true;
            Log.Debug($"Backupping from RigidBody properties for object  {gameObject.name}");
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
            isBackupping = false;
            _EditMode = false;
        }

        internal void RestoreOriginalBody() // Restore only if Editmode is already active, and Activate sync mode Once Restored.
        {
            _EditMode = true;
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

        #region Forced Rigidbody Method

        private void Force_RigidBody()
        {
            if (gameObject.GetComponent<Rigidbody>() == null && Rigidbody == null)
            {
                Log.Debug($"RigidBodyController : Object {gameObject.name} Spawned Rigidbody..");
                Rigidbody = gameObject.AddComponent<Rigidbody>();
                isKinematic = true;
                Original_isKinematic = true;
            }
        }

        #endregion Forced Rigidbody Method

        #region Rigidbody Reflected Properties

        #region Internal Reflection (Private Values, Do Not Edit.)

        private int _solverVelocityIterationCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 _inertiaTensor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion _inertiaTensorRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 _centerOfMass { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private CollisionDetectionMode _collisionDetectionMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RigidbodyConstraints _constraints { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _freezeRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _maxDepenetrationVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _detectCollisions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _useGravity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;
        private float _mass { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private int _solverIterationCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _angularDrag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _drag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 _angularVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 _velocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _isKinematic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _sleepVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _sleepThreshold { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _maxAngularVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private int _solverVelocityIterations { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RigidbodyInterpolation _interpolation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _sleepAngularVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool _useConeFriction { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private int _solverIterations { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        #endregion Internal Reflection (Private Values, Do Not Edit.)

        internal int solverVelocityIterationCount
        {
            [HideFromIl2Cpp]
            get => _solverVelocityIterationCount;
            [HideFromIl2Cpp]
            set
            {
                _solverVelocityIterationCount = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverVelocityIterationCount = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 inertiaTensor
        {
            [HideFromIl2Cpp]
            get => _inertiaTensor;
            [HideFromIl2Cpp]
            set
            {
                _inertiaTensor = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.inertiaTensor = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Quaternion inertiaTensorRotation
        {
            [HideFromIl2Cpp]
            get => _inertiaTensorRotation;
            [HideFromIl2Cpp]
            set
            {
                _inertiaTensorRotation = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.inertiaTensorRotation = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 centerOfMass
        {
            [HideFromIl2Cpp]
            get => _centerOfMass;
            [HideFromIl2Cpp]
            set
            {
                _centerOfMass = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.centerOfMass = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal CollisionDetectionMode collisionDetectionMode
        {
            [HideFromIl2Cpp]
            get => _collisionDetectionMode;
            [HideFromIl2Cpp]
            set
            {
                _collisionDetectionMode = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.collisionDetectionMode = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal RigidbodyConstraints constraints
        {
            [HideFromIl2Cpp]
            get => _constraints;
            [HideFromIl2Cpp]
            set
            {
                _constraints = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.constraints = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool freezeRotation
        {
            [HideFromIl2Cpp]
            get => _freezeRotation;
            [HideFromIl2Cpp]
            set
            {
                _freezeRotation = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.freezeRotation = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float maxDepenetrationVelocity
        {
            [HideFromIl2Cpp]
            get => _maxDepenetrationVelocity;
            [HideFromIl2Cpp]
            set
            {
                _maxDepenetrationVelocity = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.maxDepenetrationVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool detectCollisions
        {
            [HideFromIl2Cpp]
            get => _detectCollisions;
            [HideFromIl2Cpp]
            set
            {
                _detectCollisions = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.detectCollisions = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool useGravity
        {
            [HideFromIl2Cpp]
            get => _useGravity;
            [HideFromIl2Cpp]
            set
            {
                _useGravity = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.useGravity = value;
                        SyncPhysics.RefreshProperties();
                        if (!isPublic)
                        {
                            SyncPhysics.SetGravity(value);
                        }
                        else
                        {
                            SyncPhysics.SetGravityForEveryone(value);
                        }
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float mass
        {
            [HideFromIl2Cpp]
            get => _mass;
            [HideFromIl2Cpp]
            set
            {
                _mass = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.mass = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal int solverIterationCount
        {
            [HideFromIl2Cpp]
            get => _solverIterationCount;
            [HideFromIl2Cpp]
            set
            {
                _solverIterationCount = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverIterationCount = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float angularDrag
        {
            [HideFromIl2Cpp]
            get => _angularDrag;
            [HideFromIl2Cpp]
            set
            {
                _angularDrag = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.angularDrag = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float drag
        {
            [HideFromIl2Cpp]
            get => _drag;
            [HideFromIl2Cpp]
            set
            {
                _drag = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.drag = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 angularVelocity
        {
            [HideFromIl2Cpp]
            get => _angularVelocity;
            [HideFromIl2Cpp]
            set
            {
                _angularVelocity = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.angularVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 velocity
        {
            [HideFromIl2Cpp]
            get => _velocity;
            [HideFromIl2Cpp]
            set
            {
                _velocity = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.velocity = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool isKinematic
        {
            [HideFromIl2Cpp]
            get => _isKinematic;
            [HideFromIl2Cpp]
            set
            {
                _isKinematic = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.isKinematic = value;
                        SyncPhysics.RefreshProperties();
                        if (!isPublic)
                        {
                            SyncPhysics.SetKinematic(value);
                        }
                        else
                        {
                            SyncPhysics.SetKinematicForEveryone(value);
                        }
                    }
                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float sleepVelocity
        {
            [HideFromIl2Cpp]
            get => _sleepVelocity;
            [HideFromIl2Cpp]
            set
            {
                _sleepVelocity = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.sleepVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float sleepThreshold
        {
            [HideFromIl2Cpp]
            get => _sleepThreshold;
            [HideFromIl2Cpp]
            set
            {
                _sleepThreshold = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.sleepThreshold = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal float maxAngularVelocity
        {
            [HideFromIl2Cpp]
            get => _maxAngularVelocity;
            [HideFromIl2Cpp]
            set
            {
                _maxAngularVelocity = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.maxAngularVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal int solverVelocityIterations
        {
            [HideFromIl2Cpp]
            get => _solverVelocityIterations;
            [HideFromIl2Cpp]
            set
            {
                _solverVelocityIterations = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverVelocityIterations = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal RigidbodyInterpolation interpolation
        {
            [HideFromIl2Cpp]
            get => _interpolation;
            [HideFromIl2Cpp]
            set
            {
                _interpolation = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.interpolation = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal Vector3 position
        {
            [HideFromIl2Cpp]
            get => Rigidbody.position;
            [HideFromIl2Cpp]
            set
            {
                if (Rigidbody != null)
                {
                    Rigidbody.position = value;
                    SyncPhysics.RefreshProperties();
                }
            }
        }

        internal Quaternion rotation
        {
            [HideFromIl2Cpp]
            get => Rigidbody.rotation;
            [HideFromIl2Cpp]
            set
            {
                if (Rigidbody != null)
                {
                    Rigidbody.rotation = value;
                    SyncPhysics.RefreshProperties();
                }
            }
        }

        internal float sleepAngularVelocity
        {
            [HideFromIl2Cpp]
            get => _sleepAngularVelocity;
            [HideFromIl2Cpp]
            set
            {
                _sleepAngularVelocity = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.sleepAngularVelocity = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal bool useConeFriction
        {
            [HideFromIl2Cpp]
            get => _useConeFriction;
            [HideFromIl2Cpp]
            set
            {
                _useConeFriction = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.useConeFriction = value;
                        SyncPhysics.RefreshProperties();
                    }

                Run_OnRigidBodyPropertyChanged();
            }
        }

        internal int solverIterations
        {
            [HideFromIl2Cpp]
            get => _solverIterations;
            [HideFromIl2Cpp]
            set
            {
                _solverIterations = value;
                if (EditMode)
                    if (Rigidbody != null)
                    {
                        Rigidbody.solverIterations = value;
                        SyncPhysics.RefreshProperties();
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
                if (Rigidbody != null) return Rigidbody.worldCenterOfMass;
                return Vector3.zero;
            }
        }

        #endregion Rigidbody Reflected Properties

        #region Backupped Properties

        private int Original_solverVelocityIterationCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 Original_inertiaTensor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion Original_inertiaTensorRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 Original_centerOfMass { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private CollisionDetectionMode Original_collisionDetectionMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RigidbodyConstraints Original_constraints { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = RigidbodyConstraints.None;
        private bool Original_freezeRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Original_maxDepenetrationVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool Original_detectCollisions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool Original_useGravity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;
        private float Original_mass { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private int Original_solverIterationCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Original_angularDrag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Original_drag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 Original_angularVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 Original_velocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool Original_isKinematic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private float Original_sleepVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Original_sleepThreshold { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Original_maxAngularVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private int Original_solverVelocityIterations { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RigidbodyInterpolation Original_interpolation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Original_sleepAngularVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool Original_useConeFriction { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private int Original_solverIterations { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

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

        #region Override Methods

        /// <summary>
        /// Bypass EditMode and sets Cached values and Rigidbody Kinematic
        /// </summary>

        internal void Override_isKinematic(bool value) // this Bypasses EditMode
        {
            Original_isKinematic = value;
            _isKinematic = value;
            if (Rigidbody != null)
            {
                Rigidbody.isKinematic = value;
                SyncPhysics.RefreshProperties();
                if (!isPublic)
                {
                    SyncPhysics.SetKinematic(value);
                }
                else
                {
                    SyncPhysics.SetKinematicForEveryone(value);
                }

            }

            Run_OnRigidBodyPropertyChanged();
        }

        /// <summary>
        /// Bypass EditMode and sets Cached values and Rigidbody gravity
        /// </summary>

        internal void Override_UseGravity(bool value) // this Bypasses EditMode
        {
            Original_useGravity = value;
            _useGravity = value;
            if (Rigidbody != null)
            {
                Rigidbody.useGravity = value;
                SyncPhysics.RefreshProperties();
                if (!isPublic)
                {
                    SyncPhysics.SetGravity(value);
                }
                else
                {
                    SyncPhysics.SetGravityForEveryone(value);
                }
            }

            Run_OnRigidBodyPropertyChanged();
        }

        #endregion Random Methods

        #region Rigidbody Methods Reflection

        internal void MovePosition(Vector3 value)
        {
            Rigidbody.MovePosition(value);
            SyncPhysics.RefreshProperties();
        }

        internal void MoveRotation(Quaternion value)
        {
            Rigidbody.MoveRotation(value);
            SyncPhysics.RefreshProperties();
        }

        #endregion

        #region Essential Variables.

        internal Rigidbody Rigidbody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal SyncPhysics SyncPhysics { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private bool _EditMode;
        private bool isBackupping;
        internal bool RestoreOriginalOnEditModeReset = true;

        internal bool EditMode
        {
            [HideFromIl2Cpp]
            get => _EditMode;
            [HideFromIl2Cpp]
            set
            {
                if (value != _EditMode)
                {
                    if (!value)
                    {
                        if (RestoreOriginalOnEditModeReset)
                        {
                            RestoreOriginalBody();
                        }
                        else
                        {
                            RestoreOriginalOnEditModeReset = true;
                        }
                    }

                }

                Run_OnRigidBodyPropertyChanged();

                _EditMode = value;
            }
        }

        private bool _Forced_RigidBody;

        internal bool Forced_Rigidbody
        {
            [HideFromIl2Cpp]
            get => _Forced_RigidBody;
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
                    if (_Forced_RigidBody) return;
                }
            }
        }

        private bool _isPublic = false;

        internal bool isPublic
        {
            get
            {
                return _isPublic;
            }
            set
            {
                _isPublic = value;
                if (value)
                {
                    SyncPhysics.SetKinematicForEveryone(_isKinematic);
                    SyncPhysics.SetGravityForEveryone(_useGravity);
                }
            }
        }

        #endregion Essential Variables.
    }
}