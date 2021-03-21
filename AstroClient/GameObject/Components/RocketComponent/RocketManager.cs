using AstroClient.ConsoleUtils;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using Color = System.Drawing.Color;

using static AstroClient.variables.InstanceBuilder;

namespace AstroClient.components
{
    public class RocketManager : MonoBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public RocketManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
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
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        public static Il2CppSystem.Collections.Generic.List<MonoBehaviour> RocketBehaviours;

        public void Start()
        {
            RocketBehaviours = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>();
            Instance = this;
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "RocketManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<RocketManager>() as RocketManager;
                UnityEngine.Object.DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.Log("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                }
                else
                {
                    ModConsole.Log("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
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
                Rockets.Remove(obj);
            }
        }

        public static void IncreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<RocketObject>();
            if (TuneTime != null)
            {
                TuneTime.RocketTimer = TuneTime.RocketTimer + 0.01f;
            }
        }

        public static void DecreaseObjTimer(GameObject obj)
        {
            var TuneTime = obj.GetComponent<RocketObject>();
            if (TuneTime != null)
            {
                TuneTime.RocketTimer = TuneTime.RocketTimer - 0.01f;
            }
        }

        public static void UpdateButton(GameObject obj)
        {
            var Timer = obj.GetComponent<RocketObject>();
            if (Timer != null)
            {
                RocketTimer.setButtonText( "Timer : " + Timer.RocketTimer);
            }
            else
            {
                RocketTimer.setButtonText("Timer : 0");
            }
        }

        public static void KillRockets()
        {
            foreach (var obj in Rockets)
            {
                var rocket = obj.GetComponent<RocketObject>();
                if (rocket != null)
                {
                    rocket.SelfDestroy();
                }
                var control = obj.GetComponent<RigidBodyController>();
                if (control != null)
                {
                    control.RestoreOriginalBody();
                }
            }
            Rockets.Clear();
        }

        public static void OnLevelLoad()
        {
            Rockets.Clear();
            ClearList();
            if (RocketTimer != null)
            {
                RocketTimer.setButtonText( "none");
            }
        }

        public static void Register(RocketObject RocketBehaviour)
        {
            RocketBehaviours.Add(RocketBehaviour);
        }

        public static void Deregister(RocketObject RocketBehaviour)
        {
            RocketBehaviours.Remove(RocketBehaviour);
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