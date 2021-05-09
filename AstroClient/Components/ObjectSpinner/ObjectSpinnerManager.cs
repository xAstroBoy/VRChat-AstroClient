namespace AstroClient.components
{
	using AstroClient.ConsoleUtils;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using static AstroClient.variables.InstanceBuilder;
	using Color = System.Drawing.Color;

	public class ObjectSpinnerManager : GameEventsBehaviour
	{
		#region Internal

		public Delegate ReferencedDelegate;
		public IntPtr MethodInfo;
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public ObjectSpinnerManager(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		public ObjectSpinnerManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ObjectSpinnerManager>())
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
			AntiGcList.Remove(this);
			AntiGcList = null;
		}

		#endregion Internal

		#region Module

		public static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> ObjectSpinnerBehaviors;

		public void Start()
		{
			ObjectSpinnerBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
			Instance = this;
		}

		public static void MakeInstance()
		{
			if (Instance == null)
			{
				string name = "ObjectSpinnerManager";
				var gameobj = GetInstanceHolder(name);
				Instance = gameobj.AddComponent<ObjectSpinnerManager>() as ObjectSpinnerManager;
				UnityEngine.Object.DontDestroyOnLoad(gameobj);
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

		public static void UpdateSpinnerButton(GameObject obj)
		{
			var spin = obj.GetComponent<ObjectSpinner>();
			if (spin != null)
			{
				SpinAmountTell.setButtonText("X : " + spin.ForceX + " Y : " + spin.ForceY + " Z :" + spin.ForceZ);
			}
			else
			{
				SpinAmountTell.setButtonText("X : " + "0" + " Y : " + "0" + " Z :" + "0");
			}
		}

		public static void RemoveObject(GameObject obj)
		{
			if (ObjectSpinners.Contains(obj))
			{
				ObjectSpinners.Remove(obj);
			}
		}

		public static void UpdateTimerButton(GameObject obj)
		{
			var Timer = obj.GetComponent<ObjectSpinner>();
			if (Timer != null)
			{
				SpinnerTimerBtn.setButtonText("Timer : " + Timer.SpinnerTimer);
			}
			else
			{
				SpinnerTimerBtn.setButtonText("Timer : " + "0");
			}
		}

		public static void KillObjectSpinners()
		{
			foreach (var obj in ObjectSpinners)
			{
				var spinner = obj.GetComponent<ObjectSpinner>();
				if (spinner != null)
				{
					spinner.SelfDestroy();
				}
			}

			ObjectSpinners.Clear();
		}

		public override void OnLevelLoaded()
		{
			ObjectSpinners.Clear();
			ClearList();
			if (SpinnerTimerBtn != null)
			{
				SpinnerTimerBtn.setButtonText("none");
			}
			if (SpinAmountTell != null)
			{
				SpinAmountTell.setButtonText("none");
			}
		}

		public static void IncreaseObjTimer(GameObject obj)
		{
			var TuneTime = obj.GetComponent<ObjectSpinner>();
			if (TuneTime != null)
			{
				TuneTime.SpinnerTimer = TuneTime.SpinnerTimer + 0.01f;
				UpdateTimerButton(obj);
			}
		}

		public static void DecreaseObjTimer(GameObject obj)
		{
			var TuneTime = obj.GetComponent<ObjectSpinner>();
			if (TuneTime != null)
			{
				TuneTime.SpinnerTimer = TuneTime.SpinnerTimer - 0.01f;
				UpdateTimerButton(obj);
			}
		}

		public static void Register(ObjectSpinner ObjectSpinnerBehaviour)
		{
			ObjectSpinnerBehaviors.Add(ObjectSpinnerBehaviour);
		}

		public static void Deregister(ObjectSpinner ObjectSpinnerBehaviour)
		{
			ObjectSpinnerBehaviors.Remove(ObjectSpinnerBehaviour);
		}

		public static void ClearList()
		{
			ObjectSpinnerBehaviors.Clear();
		}

		public static List<GameObject> ObjectSpinners = new List<GameObject>();

		public static ObjectSpinnerManager Instance { get; set; }

		public static QMSingleButton SpinnerTimerBtn;
		public static QMSingleButton SpinAmountTell;

		#endregion Module
	}
}