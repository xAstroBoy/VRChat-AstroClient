namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using static AstroClient.Variables.InstanceBuilder;
    using Color = System.Drawing.Color;

    public class OrbitManager_Old : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public OrbitManager_Old(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public OrbitManager_Old(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<OrbitManager_Old>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~OrbitManager_Old()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        public static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> OrbitBehaviours;
        public static float Offset = 0f;

        public void Start()
        {
            OrbitBehaviours = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "OrbitManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<OrbitManager_Old>();
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

        public static void RemoveOrbitObjectsBoundToPlayer(APIUser player)
        {
            int i = 0;
            if (player != null)
            {
                foreach (var obj in GetOrbitObjects())
                {
                    if (obj != null)
                    {
                        var orbit = obj.GetComponent<Orbit>();
                        if (orbit != null)
                        {
                            if (orbit.player.prop_APIUser_0.id == player.id)
                            {
                                orbit.DestroyMeLocal();
                                i++;
                                continue;
                            }
                        }
                    }
                }
                ModConsole.Log("Found and destroyed " + i + " Orbits.");
            }
        }

        public static void RemoveFromList(GameObject obj)
        {
            if (obj != null)
            {
                if (_OrbitObjects.Contains(obj))
                {
                    _ = _OrbitObjects.Remove(obj);
                }
            }
        }

        public static void RegisterObject(GameObject obj)
        {
            if (obj != null)
            {
                if (!_OrbitObjects.Contains(obj))
                {
                    _OrbitObjects.Add(obj);
                }
            }
        }

        public static void AddOrbitObject(GameObject obj, Player player)
        {
            if (obj != null && player != null && obj.GetComponent<Orbit>() == null)
            {
                RegisterObject(obj);
                var orbit = obj.AddComponent<Orbit>();
                if (orbit != null)
                {
                    orbit.player = player;
                    orbit.Instance = Instance;
                    orbit.TimerOffset += Offset += 0.0001f;
                    orbit.enabled = true;
                }
            }
        }

        public static void Update()
        {
        }

        public static void RemoveAllOrbitObjects()
        {
            foreach (var obj in GetOrbitObjects())
            {
                if (obj != null)
                {
                    var orbit = obj.GetComponent<Orbit>();
                    if (orbit != null)
                    {
                        orbit.DestroyMeLocal();
                    }
                }
            }
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            ClearList();
            _OrbitObjects.Clear();
            if (OrbitObjects != null)
            {
                OrbitObjects = null;
            }
        }

        public static void Register(Orbit orbitBehaviour)
        {
            OrbitBehaviours.Add(orbitBehaviour);
        }

        public static void Deregister(Orbit orbitBehaviour)
        {
            _ = OrbitBehaviours.Remove(orbitBehaviour);
        }

        public static void ClearList()
        {
            OrbitBehaviours.Clear();
        }

        public static List<GameObject> GetOrbitObjects()
        {
            OrbitObjects = new List<GameObject>();
            OrbitObjects = _OrbitObjects.ToList();
            return OrbitObjects;
        }

        private static List<GameObject> _OrbitObjects = new List<GameObject>();
        private static List<GameObject> OrbitObjects;
        public static OrbitManager_Old Instance { get; set; }

        #endregion Module
    }
}