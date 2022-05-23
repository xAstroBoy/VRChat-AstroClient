namespace AstroClient.AstroMonos.Components.Malicious
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

    public class OrbitManager : MonoBehaviour
    {
        #region Internal

        public int MaxItems = 30;
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;
        public object Toggle;

        public OrbitManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
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
        private Transform centerPoint = null;
        private List<VRC.SDKBase.VRC_Pickup> pickups = new List<VRC.SDKBase.VRC_Pickup>();

        internal void Start()
        {
            Instance = this;
            Log.Write($"[OrbitManager] Initialized");
        }

        internal void RefreshPickups()
        {
            pickups.Clear();
            var list = WorldUtils.Pickups;
            int max = MaxItems;
            if (max >= list.Count)
            {
                max = list.Count;
            }
            for (int i = 0; i < max; i++)
            {
                var found = list[i];
                found.gameObject.RigidBody_Set_Gravity(false);
                found.gameObject.RigidBody_Set_DetectCollisions(true);
                found.gameObject.RigidBody_Set_isKinematic(false);
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
        
        public static void OrbitPlayer(Player target)
        {
            if (Instance != null && target != null)
            {
                Instance.target = target;
                Instance.centerPoint = BonesUtils.Get_Player_Bone_Transform(target, HumanBodyBones.Head);
                Instance.Toggle = MelonCoroutines.Start(LoopPickups());
                Log.Write($"[OrbitManager] Orbiting Player: {Instance.target.DisplayName()}");
            }
            else
            {
                Log.Error("[OrbitManager] Orbit Failed!");
            }
        }

        public static void DisableOrbit()
        {
            if (Instance == null) return;

            for (int i = 0; i < Instance.pickups.Count; i++)
            {
                var pickup = Instance.pickups[i].gameObject;
                pickup.Pickup_RestoreOriginalProperties();
                pickup.RespawnPickup(true);
                OnlineEditor.RemoveOwnerShip(pickup);
            }
            MelonCoroutines.Stop(Instance.Toggle);
            Instance.pickups.Clear();
            Instance.target = null;
            Log.Write($"[OrbitManager] Orbit Disabled");
        }
        
        private static IEnumerator LoopPickups()
        {
            Instance.RefreshPickups();
            
            for (; ; )
            {
                if (Instance.target == null)
                {
                    Log.Write("[OrbitManager] Target is null, disabling orbit");
                    MelonCoroutines.Stop(Instance.Toggle);
                    yield break;
                }
                
                if (Instance.centerPoint == null)
                {
                    Log.Write("[OrbitManager] Target Lost, Retrying....");
                    Instance.centerPoint = BonesUtils.Get_Player_Bone_Transform(Instance.target, HumanBodyBones.Head);
                    yield return new WaitForSeconds(0.1f);
                }

                for (int i = 0; i < Instance.pickups.Count; i++)
                {
                    var pickup = Instance.pickups[i];
                    if (!pickup.gameObject.isLocalPlayerOwner())
                    {
                        pickup.gameObject.TryTakeOwnership();
                    }

                    pickup.transform.position = Instance.centerPoint.position + (Instance.centerPoint.forward * (0.3f));
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
