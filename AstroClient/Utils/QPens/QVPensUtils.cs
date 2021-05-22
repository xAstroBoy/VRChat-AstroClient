namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using static AstroClient.variables.CustomLists;
	using VRC.Udon;

	public class QVPensUtils : GameEvents
	{
		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			FindQVPenSetTriggers();
			FindUdonPensEvents();
		}

		public override void OnLevelLoaded()
		{
			if (PenManagers != null)
			{
				PenManagers.Clear();
			}
			if (TriggerSDKBase != null)
			{
				TriggerSDKBase.Clear();
			}
			if (TriggerSDK2 != null)
			{
				TriggerSDK2.Clear();
			}
			if(ClearPensUdonEvents != null)
			{
				ClearPensUdonEvents.Clear();
			}
		}

		public static void FindQVPenSetTriggers()
		{
			foreach (var obj in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (obj.name.ToLower().Contains("penmanager"))
				{
					if (PenManagers != null)
					{
						if (!PenManagers.Contains(obj))
						{
							PenManagers.Add(obj);
						}
					}
				}
			}
			if (PenManagers.Count() != 0)
			{
				ModConsole.Log("Found " + PenManagers.Count() + " Pen Managers!, Registering Clear Trigger!");
				GetAllResetGlobals();
			}
		}

		public static void GetAllResetGlobals()
		{
			foreach (var pen in PenManagers)
			{
				if (pen != null)
				{
					foreach (var obj in pen.GetComponentsInChildren<VRC.SDKBase.VRC_Trigger>(true))
					{
						if (obj.gameObject.name.ToLower().Contains("interact_clear"))
						{
							if (!TriggerSDKBase.Contains(obj))
							{
								TriggerSDKBase.Add(obj);
							}
						}
					}

					foreach (var obj in pen.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true))
					{
						if (obj.gameObject.name.ToLower().Contains("interact_clear"))
						{
							if (!TriggerSDK2.Contains(obj))
							{
								TriggerSDK2.Add(obj);
							}
						}
					}
				}
			}

			ModConsole.Log("Found " + TriggerSDKBase.Count() + " QVPens Clear SDKBase Triggers.");
			ModConsole.Log("Found " + TriggerSDK2.Count() + " QVPens Clear VRCSDK2 Triggers.");
		}

		public static void FindUdonPensEvents()
		{
			foreach (var item in Resources.FindObjectsOfTypeAll<UdonBehaviour>())
			{
				if(item != null)
				{
					if(item.name.ToLower().Contains("penmanager"))
					{
						var action = item.FindUdonEvent("ClearAll");
						if(action != null)
						{
							if (!ClearPensUdonEvents.Contains(action))
							{
								ClearPensUdonEvents.Add(action);
							}
						}
					}
					if(item.name.ToLower().Equals("pen"))
					{
						var action = item.FindUdonEvent("Clear");
						if (action != null)
						{
							if (!ClearPensUdonEvents.Contains(action))
							{
								ClearPensUdonEvents.Add(action);
							}
						}
					}	
				}
			}
			ModConsole.Log("Found " + ClearPensUdonEvents.Count() + " Clear Pens Udon Events.");
		}


		public static void ResetQPensGlobal()
		{
			if (TriggerSDKBase.Count() != 0)
			{
				foreach (var item in TriggerSDKBase)
				{
					if (item != null)
					{
						item.gameObject.TriggerClick();
					}
				}
			}
			if (TriggerSDK2.Count() != 0)
			{
				foreach (var item in TriggerSDK2)
				{
					if (item != null)
					{
						item.gameObject.TriggerClick();
					}
				}
			}
			if(ClearPensUdonEvents.Count() != 0)
			{
				ClearPensUdonEvents.ExecuteUdonEvent();
			}

		}

		public static List<GameObject> PenManagers = new List<GameObject>();
		public static List<VRC.SDKBase.VRC_Trigger> TriggerSDKBase = new List<VRC.SDKBase.VRC_Trigger>();
		public static List<VRCSDK2.VRC_Trigger> TriggerSDK2 = new List<VRCSDK2.VRC_Trigger>();
		public static List<CachedUdonEvent> ClearPensUdonEvents = new List<CachedUdonEvent>();
	}
}