namespace AstroClient.Components
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC.Core;
    using VRC;
    using System.Linq;
    using AstroLibrary.Extensions;
    using Color = System.Drawing.Color;

    #region AstroClient Imports

    using AstroLibrary.Console;

    #endregion AstroClient Imports

    using static AstroClient.Variables.InstanceBuilder;

    public class PlayerAttackerManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerAttackerManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public PlayerAttackerManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<PlayerAttackerManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~PlayerAttackerManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        internal static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> PlayerAttackerBehaviors;

        internal void Start()
        {
            PlayerAttackerBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        internal static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "PlayerAttackerManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<PlayerAttackerManager>();
                DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                }
                else
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
                }
            }
        }

        internal static void Update()
        {
        }

        internal static void AddObject(GameObject obj, Player player)
        {
            if (obj == null)
            {
                ModConsole.DebugWarning("Object is null");
                return;
            }
            if (player == null)
            {
                ModConsole.DebugWarning("player is null");
                return;
            }

            if (Instance == null)
            {
                ModConsole.Error("Player Attacker Instance is null");
            }
            if (Instance != null)
            {
                if (obj.GetComponent<PlayerAttacker>() == null)
                {
                    if (!OriginalPlayerAttackers.Contains(obj))
                    {
                        OriginalPlayerAttackers.Add(obj);
                    }
                    var Attacker = obj.AddComponent<PlayerAttacker>();
                    if (Attacker != null)
                    {
                        Attacker.player = player;
                        Attacker.Manager = Instance;
                        Attacker.IsLockDeactivated = true;
                    }
                }
            }
            else
            {
                ModConsole.Warning("PlayerAttackerManager Instance is Null!");
            }
        }

        internal static void RemovePickupsAttackerBoundToPlayer(APIUser player)
        {
            int i = 0;
            if (player != null)
            {
                foreach (var obj in GetAllAttackers())
                {
                    if (obj != null)
                    {
                        var component = obj.GetComponent<PlayerAttacker>();
                        if (component != null)
                        {
                            if (component.player.prop_APIUser_0.id == player.id)
                            {
                                Destroy(component);
                                i++;
                                continue;
                            }
                        }
                    }
                }
                ModConsole.Log("Found and destroyed " + i + " Attackers.");
            }
        }

        internal static void RemoveAttacker(GameObject obj)
        {
            if (obj != null)
            {
                var attacker = obj.GetComponent<PlayerAttacker>();
                if (attacker != null)
                {
                    attacker.DestroyMeLocal();
                }
            }
        }

        internal static void RemoveSelf(GameObject obj)
        {
            if (OriginalPlayerAttackers.Contains(obj))
            {
                _ = OriginalPlayerAttackers.Remove(obj);
            }
        }

        internal static void KillPlayerAttackers()
        {
            foreach (var obj in GetAllAttackers())
            {
                if (obj != null)
                {
                    var attacker = obj.GetComponent<PlayerAttacker>();
                    if (attacker != null)
                    {
                        Destroy(attacker);
                        attacker.DestroyMeLocal();
                    }
                }
            }
            OriginalPlayerAttackers.Clear();
            if (SnapshotPlayerAttackers != null)
            {
                SnapshotPlayerAttackers.Clear();
            }
            ClearList();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            OriginalPlayerAttackers.Clear();
            if (SnapshotPlayerAttackers != null)
            {
                SnapshotPlayerAttackers.Clear();
            }
            ClearList();
        }

        internal static void Register(PlayerAttacker PlayerAttackerBehaviour)
        {
            PlayerAttackerBehaviors.Add(PlayerAttackerBehaviour);
        }

        internal static void Deregister(PlayerAttacker PlayerAttackerBehaviour)
        {
            _ = PlayerAttackerBehaviors.Remove(PlayerAttackerBehaviour);
        }

        internal static void ClearList()
        {
            PlayerAttackerBehaviors.Clear();
        }

        internal static List<GameObject> GetAllAttackers()
        {
            SnapshotPlayerAttackers = new List<GameObject>();
            SnapshotPlayerAttackers = OriginalPlayerAttackers.ToList();
            return SnapshotPlayerAttackers;
        }

        private static List<GameObject> OriginalPlayerAttackers = new List<GameObject>();

        private static List<GameObject> SnapshotPlayerAttackers;
        internal static PlayerAttackerManager Instance { get; set; }

        #endregion Module
    }
}