using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC;
using Delegate = System.Delegate;
using Time = UnityEngine.Time;
using AstroClient.GameObjectDebug;

#region AstroClient Imports

using AstroClient.ConsoleUtils;

#endregion AstroClient Imports

namespace AstroClient.components
{
    public class PlayerWatcher : MonoBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public PlayerWatcher(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        public PlayerWatcher(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<PlayerWatcher>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~PlayerWatcher()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        // Use this for initialization
        private void Start()
        {
            try
            {
                obj = gameObject;

                body = GetComponent<Rigidbody>();
                if (body == null)
                {
                    body = obj.AddComponent<Rigidbody>();
                }
                control = GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                pickup = GetComponent<PickupController>();
                if (pickup == null)
                {
                    pickup = obj.AddComponent<PickupController>();
                }
                HasRequiredSettings = false;

                if (GetComponent<PickupController>() == null)
                {
                    ModConsole.Log("PlayerWatcher : Object Still Has No PickupController (Probably Udon World) , Watcher Will be broken!");
                }

                if (GetComponent<RigidBodyController>() == null)
                {
                    ModConsole.Log("PlayerWatcher : Object Still Has No RigidBody (Probably Udon World) , Watcher Will be broken!");
                }


                if (player == null)
                {
                    ModConsole.Log("PlayerWatcher : ERROR , Player Is not registered!");
                }

                if (this == null)
                {
                    ModConsole.Log("Is This actually supposed to be null?");
                }
            }
            catch
            { }

            PlayerWatcherManager.Register(this);
            OnlineEditor.TakeObjectOwnership(obj);
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (IsLockDeactivated)
                {
                    if (player == null)
                    {
                        Destroy(this);
                        return;
                    }

                    if (pickup.isHeld)
                    {
                        if (HasRequiredSettings)
                        {
                            control.RestoreOriginalBody();
                            HasRequiredSettings = false;
                        }
                        return;
                    }

                    if ((Time.time - LastTimeCheck2 > 0.9f))
                    {
                        if (!HasRequiredSettings)
                        {
                            if (!control.EditMode)
                            {
                                control.EditMode = true;
                            }
                            if (!OnlineEditor.IsLocalPlayerOwner(obj))
                            {
                                control.Constraints = RigidbodyConstraints.None;
                                obj.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
                                OnlineEditor.TakeObjectOwnership(obj);
                            }
                            else
                            {
                                control.Constraints = RigidbodyConstraints.FreezeRotation;
                                obj.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
                                if (control != null)
                                {
                                    control.Constraints = RigidbodyConstraints.None;
                                }
                            }
                            LastTimeCheck2 = Time.time;
                            HasRequiredSettings = true;
                        }
                    }

                    OnlineEditor.TakeObjectOwnership(obj);
                    obj.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);

                }
                
            }
            catch
            {
            }
        }


        void OnDestroy()
        {
                control.RestoreOriginalBody();
                GameObjectUtils.RestoreOriginalLocation(obj, false);
                PlayerWatcherManager.RemoveSelf(obj);
                OnlineEditor.RemoveOwnerShip(obj);
                PlayerWatcherManager.Deregister(this);
        }


        public static Transform PositionOfBone(Player player, HumanBodyBones bone)
        {
            Transform bonePosition = player.transform;
            VRCAvatarManager avatarManager = player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0;
            if (!avatarManager)
                return bonePosition;
            Animator animator = avatarManager.field_Private_Animator_0;
            if (!animator)
                return bonePosition;
            Transform boneTransform = animator.GetBoneTransform(bone);
            if (!boneTransform)
                return bonePosition;

            return boneTransform;
        }

        public PlayerWatcherManager Manager = null;
        public float TimerOffset = 0f;
        private float LastTimeCheck2 = 0;
        private bool HasRequiredSettings = false;


        internal Player player;
        internal bool IsLockDeactivated = false;
        private GameObject obj = null;
        private Rigidbody body = null;
        private RigidBodyController control;
        private PickupController pickup;

    }
}