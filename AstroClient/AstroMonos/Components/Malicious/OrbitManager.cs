﻿namespace AstroClient.AstroMonos.Components.Malicious
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.Extensions.Components_exts;
    using AstroClient.Tools.ObjectEditor;
    using AstroClient.Tools.ObjectEditor.Online;
    using MelonLoader;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static Constants.InstanceBuilder;

    public class OrbitManager : AstroMonoBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public OrbitManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
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
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        internal static OrbitManager Instance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Player target;
        private bool isEnabled;
        private bool isLooping;
        private Transform centerPoint = null;
        private List<VRC.SDKBase.VRC_Pickup> pickups = new List<VRC.SDKBase.VRC_Pickup>();

        internal static bool IsEnabled
        {
            [HideFromIl2Cpp]
            get => Instance.isEnabled;
            [HideFromIl2Cpp]
            set => Instance.isEnabled = value;
        }

        internal void Start()
        {
            Instance = this;
            Log.Write($"[OrbitManager] Initialized");
        }

        internal void RefreshPickups()
        {
            pickups.Clear();
            var list = WorldUtils.Pickups;
            for (int i = 0; i < list.Count; i++)
            {
                var found = list[i];
                pickups.Add(found);
            }
            Log.Write($"[OrbitManager] Refreshed: {pickups.Count} pickups found");
        }

        internal static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "OrbitManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<OrbitManager>();
                DontDestroyOnLoad(gameobj);
                if (Instance != null) Log.Debug("[ " + name.ToUpper() + " STATUS ] : READY", System.Drawing.Color.LawnGreen);
                else Log.Debug("[ " + name.ToUpper() + " STATUS ] : ERROR", System.Drawing.Color.OrangeRed);
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            RefreshPickups();
        }

        internal static void OrbitPlayer(Player target)
        {
            if (Instance != null && target != null && Instance.target == null)
            {
                Instance.target = target;
                Instance.isEnabled = true;

                Instance.centerPoint ??= BonesUtils.Get_Player_Bone_Transform(target, HumanBodyBones.Head);

                _ = MelonCoroutines.Start(LoopPickups());

                Log.Write($"[OrbitManager] Orbiting Player: {Instance.target.DisplayName()}");
            }
            else
            {
                ModConsole.Error("[OrbitManager] Orbit Failed!");
            }
        }

        internal static void DisableOrbit()
        {
            if (Instance == null) return;

            for (int i = 0; i < Instance.pickups.Count; i++)
            {
                var pickup = Instance.pickups[i];
                pickup.gameObject.Pickup_RestoreOriginalProperties();
                GameObjectMenu.RestoreOriginalLocation(pickup.gameObject, true);
                OnlineEditor.RemoveOwnerShip(pickup.gameObject);
            }
            Instance.target = null;
            Instance.isEnabled = false;
            Log.Write($"[OrbitManager] Orbit Disabled");
        }

        internal static IEnumerator LoopPickups()
        {
            for (; ; )
            {
                if (!IsEnabled || Instance.target == null)
                {
                    DisableOrbit();
                    yield break;
                }

                for (int i = 0; i < Instance.pickups.Count; i++)
                {
                    var pickup = Instance.pickups[i];
                    if (!pickup.gameObject.isLocalPlayerOwner())
                    {
                        pickup.gameObject.TryTakeOwnership();
                        pickup.gameObject.RigidBody_Set_Gravity(false);
                        pickup.gameObject.RigidBody_Set_DetectCollisions(true);
                        pickup.gameObject.RigidBody_Set_isKinematic(false);
                    }

                    pickup.transform.position = Instance.centerPoint.position + (Instance.centerPoint.forward * 0.3f);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}