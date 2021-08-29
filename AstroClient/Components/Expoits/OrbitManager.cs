﻿namespace AstroClient.Components
{
    using AstroClient.GameObjectDebug;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;
    using VRC.Udon;
    using static AstroClient.Variables.InstanceBuilder;

    public class OrbitManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public OrbitManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public OrbitManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<OrbitManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~OrbitManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        public static OrbitManager Instance { get; set; }
        private Player target;
        private bool isEnabled;
        private bool isLooping;
        private Transform centerPoint = null;
        private List<PickupController> pickups = new List<PickupController>();
        private float updateTimer;

        public static bool IsEnabled
        {
            get => Instance.isEnabled;
            set => Instance.isEnabled = value;
        }

        public void Start()
        {
            Instance = this;
            RefreshPickups();
            ModConsole.Log($"[OrbitManager] Initialized");
        }

        public void RefreshPickups()
        {
            pickups.Clear();
            var list = WorldUtils.GetPickups();
            for (int i = 0; i < list.Count; i++)
            {
                var found = list[i];
                var body = found.GetComponent<Rigidbody>();
                var controller = GetComponent<PickupController>();
                var obj = body.gameObject;

                if (controller == null)
                {
                    controller = obj.AddComponent<PickupController>();
                }

                pickups.Add(controller);
            }
            ModConsole.Log($"[OrbitManager] Refreshed: {pickups.Count} pickups found");
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "OrbitManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<OrbitManager>();
                DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", System.Drawing.Color.LawnGreen);
                }
                else
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", System.Drawing.Color.OrangeRed);
                }
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            RefreshPickups();
        }

        public static void OrbitPlayer(Player target)
        {
            if (Instance != null && target != null)
            {
                Instance.target = target;
                Instance.isEnabled = true;
                ModConsole.Log($"[OrbitManager] Orbiting Player: {Instance.target.DisplayName()}");
            }
            else
            {
                ModConsole.Error("[OrbitManager] Orbit Failed!");
            }
        }

        public static void DisableOrbit()
        {
            if (Instance == null) return;

            for (int i = 0; i < Instance.pickups.Count; i++)
            {
                PickupController pickup = Instance.pickups[i];
                pickup.RestoreOriginalProperties();
                GameObjectMenu.RestoreOriginalLocation(pickup.gameObject, true);
                OnlineEditor.RemoveOwnerShip(pickup.gameObject);
            }
            Instance.isEnabled = false;
            ModConsole.Log($"[OrbitManager] Orbit Disabled");
        }

        public void FixedUpdate()
        {
            if (IsEnabled && target == null) DisableOrbit();

            if (isEnabled && !isLooping)
            {
                if (!WorldUtils.IsInWorld())
                {
                    DisableOrbit();
                    return;
                }

                if (centerPoint == null)
                {
                    centerPoint = PositionOfBone(target, HumanBodyBones.Head);
                }

                isLooping = true;

                MelonCoroutines.Start(LoopPickups());
            }
        }

        public IEnumerator LoopPickups()
        {
            if (!IsEnabled || target == null) yield break;

            for (int i = 0; i < pickups.Count; i++)
            {
                PickupController pickup = pickups[i];
                if (!pickup.gameObject.IsOwner())
                {
                    pickup.gameObject.TakeOwnership();
                }

                var rb = pickup.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.useGravity = false;
                    rb.detectCollisions = false;
                }
                else
                {
                    ModConsole.Error("OrbitManager was not able to find pickup's RigidBody!");
                    DisableOrbit();
                    yield break;
                }

                pickup.transform.position = centerPoint.position;
                yield return null;
            }

            isLooping = false;
            yield break;
        }

        public static Transform PositionOfBone(Player player, HumanBodyBones bone)
        {
            Transform bonePosition = player.transform;
            VRCAvatarManager avatarManager = player.GetVRCPlayer().GetAvatarManager();
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
    }
}
