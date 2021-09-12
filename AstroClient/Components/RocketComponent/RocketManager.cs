namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Variables.InstanceBuilder;
    using Color = System.Drawing.Color;

    [RegisterComponent]
    public class RocketManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public RocketManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public RocketManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<RocketManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~RocketManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        public static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> RocketBehaviours;

        public void Start()
        {
            RocketBehaviours = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                var stopwatch = Stopwatch.StartNew();
                string name = "RocketManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<RocketManager>();
                DontDestroyOnLoad(gameobj);
                stopwatch.Stop();
                if (Instance != null)
                {
                    ModConsole.DebugLog($"[ {name.ToUpper()} STATUS ] : READY : {stopwatch.ElapsedMilliseconds}ms", Color.LawnGreen);
                }
                else
                {
                    ModConsole.DebugLog($"[ {name.ToUpper()} STATUS ] : ERROR : {stopwatch.ElapsedMilliseconds}ms", Color.OrangeRed);
                }
            }
        }

        public static void Update()
        {
        }

        public static void AddObject(GameObject obj, bool ShouldFloat, bool HasRelativeForce = true)
        {
            if (obj != null)
            {
                if (Instance != null)
                {
                    if (!Rockets.Contains(obj))
                    {
                        var rocketObject = obj.AddComponent<RocketObject>();
                        rocketObject.Manager = Instance;
                        if (rocketObject != null)
                        {
                            rocketObject.UseGravity = !ShouldFloat;
                        }
                        if (rocketObject != null && !HasRelativeForce)
                        {
                            rocketObject.ShouldBeAlwaysUp = true;
                        }
                        Rockets.Add(obj);
                        UpdateButton(obj);
                    }
                }
                else
                {
                    ModConsole.Error("RocketManager Instance is Null!");
                }
            }
        }

        public static void RemoveObject(GameObject obj)
        {
            if (Rockets.Contains(obj))
            {
                _ = Rockets.Remove(obj);
            }
        }

        public static void IncreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<RocketObject>();
            if (TuneTime != null)
            {
                TuneTime.RocketTimer += 0.01f;
            }
        }

        public static void DecreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<RocketObject>();
            if (TuneTime != null)
            {
                TuneTime.RocketTimer -= 0.01f;
            }
        }

        public static void UpdateButton(GameObject obj)
        {
            var Timer = obj.GetComponent<RocketObject>();
            if (Timer != null)
            {
                RocketTimer.SetButtonText("Timer : " + Timer.RocketTimer);
            }
            else
            {
                RocketTimer.SetButtonText("Timer : 0");
            }
        }

        public static void KillRockets()
        {
            foreach (var obj in Rockets)
            {
                var rocket = obj.GetComponent<RocketObject>();
                if (rocket != null)
                {
                    rocket.DestroyMeLocal();
                }
            }
            Rockets.Clear();
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Rockets.Clear();
            ClearList();
            if (RocketTimer != null)
            {
                RocketTimer.SetButtonText("none");
            }
        }

        public static void Register(RocketObject RocketBehaviour)
        {
            RocketBehaviours.Add(RocketBehaviour);
        }

        public static void Deregister(RocketObject RocketBehaviour)
        {
            _ = RocketBehaviours.Remove(RocketBehaviour);
        }

        public static void ClearList()
        {
            RocketBehaviours.Clear();
        }

        public static List<GameObject> Rockets = new List<GameObject>();

        public static RocketManager Instance { get; set; }
        public static QMSingleButton RocketTimer;

        #endregion Module
    }
}