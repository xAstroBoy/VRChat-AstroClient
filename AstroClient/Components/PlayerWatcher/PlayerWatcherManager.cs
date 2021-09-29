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

    [RegisterComponent]
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
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        internal static  Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> PlayerWatcherBehaviors;

        internal void Start()
        {
            PlayerWatcherBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        internal static  void MakeInstance()
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

        internal static  void Update()
        {
        }

        internal static  void AddObject(GameObject obj, Player player)
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

        internal static  void RemovePickupsWatchersBoundToPlayer(APIUser player)
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

        internal static  void RemoveAttacker(GameObject obj)
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

        internal static  void RemoveSelf(GameObject obj)
        {
            if (OriginalPlayerWatchers.Contains(obj))
            {
                _ = OriginalPlayerWatchers.Remove(obj);
            }
        }

        internal static  void KillPlayerWatchers()
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

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            OriginalPlayerWatchers.Clear();
            if (SnapshotPlayerWatchers != null)
            {
                SnapshotPlayerWatchers.Clear();
            }
            ClearList();
        }

        internal static  void Register(PlayerWatcher PlayerWatcherBehaviour)
        {
            PlayerWatcherBehaviors.Add(PlayerWatcherBehaviour);
        }

        internal static  void Deregister(PlayerWatcher PlayerWatcherBehaviour)
        {
            _ = PlayerWatcherBehaviors.Remove(PlayerWatcherBehaviour);
        }

        internal static  void ClearList()
        {
            PlayerWatcherBehaviors.Clear();
        }

        internal static  List<GameObject> GetAllAttackers()
        {
            SnapshotPlayerWatchers = new List<GameObject>();
            SnapshotPlayerWatchers = OriginalPlayerWatchers.ToList();
            return SnapshotPlayerWatchers;
        }

        private static List<GameObject> OriginalPlayerWatchers = new List<GameObject>();

        private static List<GameObject> SnapshotPlayerWatchers;
        internal static  PlayerWatcherManager Instance { get; set; }

        #endregion Module
    }
}