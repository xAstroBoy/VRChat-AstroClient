using AstroClient.ConsoleUtils;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;
using Color = System.Drawing.Color;

#region AstroClient Imports

using static AstroClient.variables.InstanceBuilder;

#endregion AstroClient Imports

namespace AstroClient.components
{
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
			AntiGcList.Remove(this);
			AntiGcList = null;
		}

		#endregion Internal

		#region Module

		public static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> CrazyObjectBehaviors;

		public void Start()
		{
			CrazyObjectBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
			Instance = this;
		}

		public static void MakeInstance()
		{
			if (Instance == null)
			{
				string name = "CrazyObjectManager";
				var gameobj = GetInstanceHolder(name);
				Instance = gameobj.AddComponent<CrazyObjectManager>() as CrazyObjectManager;
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

		public static void AddObject(GameObject obj, bool ShouldFloat)
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

		public static void IncreaseObjTimer(GameObject obj)
		{
			var TuneTime = obj.GetComponent<CrazyObject>();
			if (TuneTime != null)
			{
				TuneTime.CrazyTimer = TuneTime.CrazyTimer + 0.01f;
				UpdateTimeButton(obj);
			}
		}

		public static void DecreaseObjTimer(GameObject obj)
		{
			var TuneTime = obj.GetComponent<CrazyObject>();
			if (TuneTime != null)
			{
				TuneTime.CrazyTimer = TuneTime.CrazyTimer - 0.01f;
				UpdateTimeButton(obj);
			}
		}

		public static void UpdateTimeButton(GameObject obj)
		{
			try
			{
				var Timer = obj.GetComponent<CrazyObject>();
				if (Timer != null)
				{
					CrazyTimerBtn.setButtonText("Timer : " + Timer.CrazyTimer);
				}
				else
				{
					CrazyTimerBtn.setButtonText("Timer : " + "0");
				}
			}
			catch (Exception) { }
		}

		public static void RemoveObject(GameObject obj)
		{
			if (CrazyObjects.Contains(obj))
			{
				CrazyObjects.Remove(obj);
			}
		}

		public static void KillCrazyObjects()
		{
			foreach (var obj in CrazyObjects)
			{
				var crazyObject = obj.GetComponent<CrazyObject>();
				if (crazyObject != null)
				{
					crazyObject.SelfDestroy();
				}
			}
			CrazyObjects.Clear();
		}

		public override void OnLevelLoaded()
		{
			CrazyObjects.Clear();
			ClearList();
			if (CrazyTimerBtn != null)
			{
				CrazyTimerBtn.setButtonText("none");
			}
		}

		public static void Register(CrazyObject CrazyObjectBehaviour)
		{
			CrazyObjectBehaviors.Add(CrazyObjectBehaviour);
		}

		public static void Deregister(CrazyObject CrazyObjectBehaviour)
		{
			CrazyObjectBehaviors.Remove(CrazyObjectBehaviour);
		}

		public static void ClearList()
		{
			CrazyObjectBehaviors.Clear();
		}

		public static List<GameObject> CrazyObjects = new List<GameObject>();

		public static CrazyObjectManager Instance { get; set; }
		public static QMSingleButton CrazyTimerBtn;

		#endregion Module
	}
}