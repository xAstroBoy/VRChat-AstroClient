namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Variables.InstanceBuilder;
    using Color = System.Drawing.Color;

    [RegisterComponent]
    public class CrazyObjectManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public CrazyObjectManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public CrazyObjectManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<CrazyObjectManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~CrazyObjectManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        internal static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> CrazyObjectBehaviors;

        internal void Start()
        {
            CrazyObjectBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        internal static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "CrazyObjectManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<CrazyObjectManager>();
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

        internal static void AddObject(GameObject obj, bool ShouldFloat)
        {
            if (obj != null)
            {
                if (Instance != null)
                {
                    if (!CrazyObjects.Contains(obj))
                    {
                        CrazyObject crazy = obj.AddComponent<CrazyObject>();
                        if (crazy != null)
                        {
                            crazy.Manager = Instance;
                            crazy.UseGravity = !ShouldFloat;
                            CrazyObjects.Add(obj);
                            UpdateTimeButton(obj);
                        }
                    }
                }
                else
                {
                    ModConsole.Error("CrazyObjectManager Instance is Null!");
                }
            }
        }

        internal static void IncreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<CrazyObject>();
            if (TuneTime != null)
            {
                TuneTime.CrazyTimer += 0.01f;
                UpdateTimeButton(obj);
            }
        }

        internal static void DecreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<CrazyObject>();
            if (TuneTime != null)
            {
                TuneTime.CrazyTimer -= 0.01f;
                UpdateTimeButton(obj);
            }
        }

        internal static void UpdateTimeButton(GameObject obj)
        {
            try
            {
                var Timer = obj.GetComponent<CrazyObject>();
                if (Timer != null)
                {
                    CrazyTimerBtn.SetButtonText("Timer : " + Timer.CrazyTimer);
                }
                else
                {
                    CrazyTimerBtn.SetButtonText("Timer : " + "0");
                }
            }
            catch (Exception) { }
        }

        internal static void RemoveObject(GameObject obj)
        {
            if (CrazyObjects.Contains(obj))
            {
                _ = CrazyObjects.Remove(obj);
            }
        }

        internal static void KillCrazyObjects()
        {
            foreach (var obj in CrazyObjects)
            {
                var crazyObject = obj.GetComponent<CrazyObject>();
                if (crazyObject != null)
                {
                    crazyObject.DestroyMeLocal();
                }
            }
            CrazyObjects.Clear();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            CrazyObjects.Clear();
            ClearList();
            if (CrazyTimerBtn != null)
            {
                CrazyTimerBtn.SetButtonText("none");
            }
        }

        internal static void Register(CrazyObject CrazyObjectBehaviour)
        {
            CrazyObjectBehaviors.Add(CrazyObjectBehaviour);
        }

        internal static void Deregister(CrazyObject CrazyObjectBehaviour)
        {
            _ = CrazyObjectBehaviors.Remove(CrazyObjectBehaviour);
        }

        internal static void ClearList()
        {
            CrazyObjectBehaviors.Clear();
        }

        internal static List<GameObject> CrazyObjects = new List<GameObject>();

        internal static CrazyObjectManager Instance { get; set; }
        internal static QMSingleButton CrazyTimerBtn;

        #endregion Module
    }
}