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

    public class PlayerWatcherManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerWatcherManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public PlayerWatcherManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<PlayerWatcherManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~PlayerWatcherManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        public static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> PlayerWatcherBehaviors;

        public void Start()
        {
            PlayerWatcherBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "PlayerWatcherManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<PlayerWatcherManager>();
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

        public static void Update()
        {
        }

        public static void AddObject(GameObject obj, Player player)
        {
            if (obj == null)
            {
                ModConsole.Log("Object is null");
                return;
            }
            if (player == null)
            {
                ModConsole.Log("player is null");
                return;
            }

            if (Instance == null)
            {
                ModConsole.Log("Instance is null");
            }
            if (Instance != null)
            {
                if (obj.GetComponent<PlayerWatcher>() == null)
                {
                    if (!OriginalPlayerWatchers.Contains(obj))
                    {
                        OriginalPlayerWatchers.Add(obj);
                    }
                    var Attacker = obj.AddComponent<PlayerWatcher>();
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
                ModConsole.Error("PlayerWatcherManager Instance is Null!");
            }
        }

        public static void RemovePickupsWatchersBoundToPlayer(APIUser player)
        {
            int i = 0;
            if (player != null)
            {
                foreach (var obj in GetAllAttackers())
                {
                    if (obj != null)
                    {
                        var component = obj.GetComponent<PlayerWatcher>();
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

        public static void RemoveAttacker(GameObject obj)
        {
            if (obj != null)
            {
                var attacker = obj.GetComponent<PlayerWatcher>();
                if (attacker != null)
                {
                    attacker.DestroyMeLocal();
                }
            }
        }

        public static void RemoveSelf(GameObject obj)
        {
            if (OriginalPlayerWatchers.Contains(obj))
            {
                OriginalPlayerWatchers.Remove(obj);
            }
        }

        public static void KillPlayerWatchers()
        {
            foreach (var obj in GetAllAttackers())
            {
                if (obj != null)
                {
                    var attacker = obj.GetComponent<PlayerWatcher>();
                    if (attacker != null)
                    {
                        Destroy(attacker);
                        attacker.DestroyMeLocal();
                    }
                }
            }
            OriginalPlayerWatchers.Clear();
            if (SnapshotPlayerWatchers != null)
            {
                SnapshotPlayerWatchers.Clear();
            }
            ClearList();
        }

        public override void OnLevelLoaded()
        {
            OriginalPlayerWatchers.Clear();
            if (SnapshotPlayerWatchers != null)
            {
                SnapshotPlayerWatchers.Clear();
            }
            ClearList();
        }

        public static void Register(PlayerWatcher PlayerWatcherBehaviour)
        {
            PlayerWatcherBehaviors.Add(PlayerWatcherBehaviour);
        }

        public static void Deregister(PlayerWatcher PlayerWatcherBehaviour)
        {
            PlayerWatcherBehaviors.Remove(PlayerWatcherBehaviour);
        }

        public static void ClearList()
        {
            PlayerWatcherBehaviors.Clear();
        }

        public static List<GameObject> GetAllAttackers()
        {
            SnapshotPlayerWatchers = new List<GameObject>();
            SnapshotPlayerWatchers = OriginalPlayerWatchers.ToList();
            return SnapshotPlayerWatchers;
        }

        private static List<GameObject> OriginalPlayerWatchers = new List<GameObject>();

        private static List<GameObject> SnapshotPlayerWatchers;
        public static PlayerWatcherManager Instance { get; set; }

        #endregion Module
    }
}