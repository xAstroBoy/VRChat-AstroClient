namespace AstroClient.AstroMonos.Components.Malicious.Orbit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using CustomMono;
    using UnhollowerBaseLib.Attributes;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using static Variables.InstanceBuilder;
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

        internal static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> OrbitBehaviours;
        internal static float Offset = 0f;

        internal void Start()
        {
            OrbitBehaviours = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        internal static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "OrbitManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<OrbitManager_Old>();
                DontDestroyOnLoad(gameobj);
                if (Instance != null) ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                else ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
            }
        }

        internal static void RemoveOrbitObjectsBoundToPlayer(APIUser player)
        {
            int i = 0;
            if (player != null)
            {
                foreach (var obj in GetOrbitObjects())
                {
                    if (obj != null)
                    {
                        var orbit = obj.GetComponent<Orbit>();
                        if (orbit != null && orbit.player.prop_APIUser_0.id == player.id)
                        {
                            orbit.DestroyMeLocal();
                            i++;
                            continue;
                        }
                    }
                }
                ModConsole.Log("Found and destroyed " + i + " Orbits.");
            }
        }

        internal static void RemoveFromList(GameObject obj)
        {
            if (obj != null && _OrbitObjects.Contains(obj)) _ = _OrbitObjects.Remove(obj);
        }

        internal static void RegisterObject(GameObject obj)
        {
            if (obj != null && !_OrbitObjects.Contains(obj)) _OrbitObjects.Add(obj);
        }

        internal static void AddOrbitObject(GameObject obj, Player player)
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

        internal static void Update()
        {
        }

        internal static void RemoveAllOrbitObjects()
        {
            foreach (var obj in GetOrbitObjects())
            {
                if (obj != null)
                {
                    var orbit = obj.GetComponent<Orbit>();
                    if (orbit != null) orbit.DestroyMeLocal();
                }
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            ClearList();
            _OrbitObjects.Clear();
            if (OrbitObjects != null) OrbitObjects = null;
        }

        internal static void Register(Orbit orbitBehaviour)
        {
            OrbitBehaviours.Add(orbitBehaviour);
        }

        internal static void Deregister(Orbit orbitBehaviour)
        {
            _ = OrbitBehaviours.Remove(orbitBehaviour);
        }

        internal static void ClearList()
        {
            OrbitBehaviours.Clear();
        }

        internal static List<GameObject> GetOrbitObjects()
        {
            OrbitObjects = new List<GameObject>();
            OrbitObjects = _OrbitObjects.ToList();
            return OrbitObjects;
        }

        private static List<GameObject> _OrbitObjects = new List<GameObject>();
        private static List<GameObject> OrbitObjects;
        internal static OrbitManager_Old Instance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        #endregion Module
    }
}