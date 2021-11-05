namespace AstroClient.Components
{
    using AstroClient.GameObjectDebug;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;

    public class Orbit : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public Orbit(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public Orbit(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<Orbit>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~Orbit()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Behaviour

        internal OrbitManager_Old Instance = null;

        internal Quaternion FirstRotation = Quaternion.identity;
        internal Vector3 FirstPosition = Vector3.zero;
        internal Vector3 Position = Vector3.zero;

        internal float x = 1.5f;
        internal float y = 1.5f;
        internal float z = 0f;
        internal Vector3 Offset = Vector3.zero;

        private Transform CenterPoint = null;
        internal Player player;
        internal Rigidbody body;
        internal GameObject obj;

        internal float RotationSpeed = 2f;
        internal bool RotateClockwise = true;
        internal RotationMode Mode = RotationMode.CircleWithRotation; // DEFAULT : CircleWithRotation

        internal float UpdateTimer = 0f;
        internal float Timer = 0f;
        internal float TimerOffset = 0f;

        private float InterpolationMaxY = 1f;
        private float InterpolationMinY = -1f;
        private float InterpolationTempY = 0f;

        private float InterpolationMaxX = 1.5f;
        private float InterpolationMinX = 1f;
        private float InterpolationTempX = 0f;
        private PickupController pickup;

        internal void Start()
        {
            FirstRotation = transform.rotation;
            FirstPosition = transform.position;
            body = GetComponent<Rigidbody>();
            obj = body.gameObject;
            pickup = GetComponent<PickupController>();
            pickup ??= obj.AddComponent<PickupController>();
            OrbitManager_Old.Register(this);
            //OnlineEditor.TakeObjectOwnership(obj);
        }

        internal void Update()
        {
            if (player == null)
            {
                Destroy(this);
                return;
            }

            if (pickup.IsHeld) return;

            CenterPoint ??= BonesUtils.Get_Player_Bone_Transform(player, HumanBodyBones.Head);

            if (CenterPoint != null)
            {
                x = Lerp(InterpolationMinX, InterpolationMaxX, InterpolationTempX);
                Offset = new Vector3(0f, Lerp(InterpolationMinY, InterpolationMaxY, InterpolationTempY), 0f);

                InterpolationTempX += 0.25f * Time.deltaTime;
                InterpolationTempY += 0.25f * Time.deltaTime;

                if (InterpolationTempX > 1.5f)
                {
                    float temp = InterpolationMaxX;
                    InterpolationMaxX = InterpolationMinX;
                    InterpolationMinX = temp;
                    InterpolationTempX = 0f;
                }

                if (InterpolationTempY > 1f)
                {
                    float temp = InterpolationMaxY;
                    InterpolationMaxY = InterpolationMinY;
                    InterpolationMinY = temp;
                    InterpolationTempY = 0f;
                }

                if (!pickup.IsHeld && !pickup.IsHeld)
				{
					gameObject.TryTakeOwnership();
					Timer += (Time.deltaTime * RotationSpeed) + TimerOffset;
					Rotate();
					UpdateTimer -= Time.deltaTime;
					if (UpdateTimer <= 0f)
					{
						transform.position = Position;
						transform.LookAt(CenterPoint);
						UpdateTimer = Time.deltaTime * 2f;
					}
				}

                //VRCPlayerApi playerApi = Player.prop_Player_0.prop_VRCPlayerApi_0;
                //if (playerApi != null && !Networking.IsOwner(playerApi, obj))
                //{
                //	OnlineEditor.TakeObjectOwnership(obj);
                //	//VrcPickup.DisallowTheft = true;
                //}

                //Timer += (Time.deltaTime * RotationSpeed) + TimerOffset;
                //Rotate();
                //UpdateTimer -= Time.deltaTime;
                //if (UpdateTimer <= 0f)
                //{
                //	transform.position = Position;
                //	transform.LookAt(CenterPoint);
                //	UpdateTimer = Time.deltaTime * 2f;
                //}
            }
        }

        private void OnDestroy()
        {
            GameObjectMenu.RestoreOriginalLocation(obj, false);
            OnlineEditor.RemoveOwnerShip(obj);
            OrbitManager_Old.RemoveFromList(obj);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Rotate()
        {
            switch (Mode)
            {
                case RotationMode.Circle:
                    CircularRotation();
                    break;
                case RotationMode.Ellipse:
                    EllipseRotation();
                    break;
                case RotationMode.CircleWithRotation:
                    CircleWithRotation();
                    break;
                case RotationMode.BackAndForth:
                    BackAndForthRotation();
                    break;
                default:
                    break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CircularRotation()
        {
            if (RotateClockwise)
            {
                float x = ((float)-Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Sin(Timer) * this.x) + Offset.x;
                Position = new Vector3(x, y + Offset.y, z) + CenterPoint.position;
            }
            else
            {
                float x = ((float)Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Sin(Timer) * this.x) + Offset.x;
                Position = new Vector3(x, y + Offset.y, z) + CenterPoint.position;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EllipseRotation()
        {
            if (RotateClockwise)
            {
                float x = ((float)-Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Sin(Timer) * this.z) + Offset.z;
                Position = new Vector3(x, y + Offset.y, z) + CenterPoint.position;
            }
            else
            {
                float x = ((float)Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Sin(Timer) * this.z) + Offset.z;
                Position = new Vector3(x, y + Offset.y, z) + CenterPoint.position;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CircleWithRotation()
        {
            //Tilted Circle
            if (RotateClockwise)
            {
                float x = ((float)-Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Sin(Timer) * this.x) + Offset.x;
                Position = new Vector3(x, x + Offset.y, z) + CenterPoint.position;
            }
            else
            {
                float x = ((float)Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Sin(Timer) * this.x) + Offset.x;
                Position = new Vector3(x, x + Offset.y, z) + CenterPoint.position;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void BackAndForthRotation()
        {
            if (RotateClockwise)
            {
                float x = ((float)-Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Tan(Timer) * this.z) + Offset.z;
                Position = new Vector3(x, y + Offset.y, z) + CenterPoint.position;
            }
            else
            {
                float x = ((float)Math.Cos(Timer) * this.x) + Offset.x;
                float z = ((float)Math.Tan(Timer) * this.z) + Offset.z;
                Position = new Vector3(x, y + Offset.y, z) + CenterPoint.position;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float Clamp(float val)
        {
            float result;
            switch (val)
            {
                case > 1f:
                    result = 1f;
                    break;
                case < 0f:
                    result = 0f;
                    break;
                default:
                    result = val;
                    break;
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float Lerp(float a, float b, float t) => a + ((b - a) * Clamp(t));

        internal enum RotationMode : byte
        {
            Circle,
            Ellipse,
            CircleWithRotation,
            BackAndForth
        }

        #endregion Behaviour
    }
}