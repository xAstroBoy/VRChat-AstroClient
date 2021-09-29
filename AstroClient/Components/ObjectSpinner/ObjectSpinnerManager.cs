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
    internal class ObjectSpinnerManager : GameEventsBehaviour
    {
        #region Internal

        internal Delegate ReferencedDelegate;
        internal IntPtr MethodInfo;
        internal Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        internal ObjectSpinnerManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal ObjectSpinnerManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ObjectSpinnerManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~ObjectSpinnerManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        internal static  Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> ObjectSpinnerBehaviors;

        internal void Start()
        {
            ObjectSpinnerBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        internal static  void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "ObjectSpinnerManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<ObjectSpinnerManager>();
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

        internal static  void UpdateSpinnerButton(GameObject obj)
        {
            var spin = obj.GetComponent<ObjectSpinner>();
            if (spin != null)
            {
                SpinAmountTell.SetButtonText("X : " + spin.ForceX + " Y : " + spin.ForceY + " Z :" + spin.ForceZ);
            }
            else
            {
                SpinAmountTell.SetButtonText("X : " + "0" + " Y : " + "0" + " Z :" + "0");
            }
        }

        internal static  void RemoveObject(GameObject obj)
        {
            if (ObjectSpinners.Contains(obj))
            {
                _ = ObjectSpinners.Remove(obj);
            }
        }

        internal static  void UpdateTimerButton(GameObject obj)
        {
            var Timer = obj.GetComponent<ObjectSpinner>();
            if (Timer != null)
            {
                SpinnerTimerBtn.SetButtonText("Timer : " + Timer.SpinnerTimer);
            }
            else
            {
                SpinnerTimerBtn.SetButtonText("Timer : " + "0");
            }
        }

        internal static  void KillObjectSpinners()
        {
            foreach (var obj in ObjectSpinners)
            {
                var spinner = obj.GetComponent<ObjectSpinner>();
                if (spinner != null)
                {
                    spinner.DestroyMeLocal();
                }
            }

            ObjectSpinners.Clear();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            ObjectSpinners.Clear();
            ClearList();
            if (SpinnerTimerBtn != null)
            {
                SpinnerTimerBtn.SetButtonText("none");
            }
            if (SpinAmountTell != null)
            {
                SpinAmountTell.SetButtonText("none");
            }
        }

        internal static  void IncreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<ObjectSpinner>();
            if (TuneTime != null)
            {
                TuneTime.SpinnerTimer += 0.01f;
                UpdateTimerButton(obj);
            }
        }

        internal static  void DecreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<ObjectSpinner>();
            if (TuneTime != null)
            {
                TuneTime.SpinnerTimer -= 0.01f;
                UpdateTimerButton(obj);
            }
        }

        internal static  void Register(ObjectSpinner ObjectSpinnerBehaviour)
        {
            ObjectSpinnerBehaviors.Add(ObjectSpinnerBehaviour);
        }

        internal static  void Deregister(ObjectSpinner ObjectSpinnerBehaviour)
        {
            _ = ObjectSpinnerBehaviors.Remove(ObjectSpinnerBehaviour);
        }

        internal static  void ClearList()
        {
            ObjectSpinnerBehaviors.Clear();
        }

        internal static  List<GameObject> ObjectSpinners = new List<GameObject>();

        internal static  ObjectSpinnerManager Instance { get; set; }

        internal static  QMSingleButton SpinnerTimerBtn;
        internal static  QMSingleButton SpinAmountTell;

        #endregion Module
    }
}