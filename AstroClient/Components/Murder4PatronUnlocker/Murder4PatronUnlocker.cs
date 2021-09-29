namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using System;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC;
	using VRC.Udon;
	using static AstroClient.variables.CustomLists;

	internal class Murder4PatronUnlocker : GameEventsBehaviour
	{
		internal Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		internal Murder4PatronUnlocker(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		private bool DebugMode = true;

		[HideFromIl2Cpp]
		private void Debug(string msg)
		{
			if (DebugMode)
			{
				ModConsole.DebugLog($"[Murder4PatronUnlocker Debug] : {msg}");
			}
		}

		// Use this for initialization
		internal void Start()
		{
			LocalObject = this.gameObject;
			Debug($"Finding Skin Events for pickup {LocalObject.name}");
			pickup = LocalObject.GetComponent<PickupController>();
			if (pickup == null)
			{
				pickup = LocalObject.GetComponent<PickupController>();
			}
			foreach (var item in LocalObject.GetComponentsInChildren<UdonBehaviour>(true))
			{
				foreach (var item2 in item._eventTable)
				{
					if (_SyncNonPatronSkin == null)
					{
						if (item2.key == "SyncNonPatronSkin")
						{
							_SyncNonPatronSkin = new CachedUdonEvent(item, item2.key);
						}
					}

					if (_SyncPatronSkin == null)
					{
						if (item2.key == "SyncPatronSkin")
						{
							_SyncPatronSkin = new CachedUdonEvent(item, item2.key);
						}
					}

					if (_SyncPatronSkin != null && _SyncNonPatronSkin != null)
					{
						break;
					}
				}

				if (_SyncPatronSkin != null && _SyncNonPatronSkin != null)
				{
					Debug("Found all The required Events!");
					break;
				}
			}
		}

		internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
		{
			try
			{
				if (!IgnoreEventReceiver)
				{
					if (obj == LocalObject)
					{
						if (Murder4Cheats.EveryoneHasPatreonPerk)
						{
							if (action == _SyncNonPatronSkin.EventKey)
							{
								// Fight back by disabling receiver and sending a delayed event after.
								MiscUtility.DelayFunction(0.2f, new Action(() =>
								{
									if (_SyncPatronSkin != null)
									{
										IgnoreEventReceiver = true;
										_SyncPatronSkin.ExecuteUdonEvent();
										IgnoreEventReceiver = false;
									}
								}));
							}
						}
						if (Murder4Cheats.OnlySelfHasPatreonPerk)
						{
							if (sender == Utils.LocalPlayer.GetPlayer())
							{
								if (action == _SyncNonPatronSkin.EventKey)
								{
									// Fight back by disabling receiver and sending a delayed event after.
									MiscUtility.DelayFunction(0.2f, new Action(() =>
									{
										if (_SyncPatronSkin != null)
										{
											IgnoreEventReceiver = true;
											_SyncPatronSkin.ExecuteUdonEvent();
											IgnoreEventReceiver = false;
										}
									}));
								}
							}
						}
					}
				}
			}
			catch { }
		}

		internal void SendPublicPatreonSkinEvent()
		{
			if (_SyncPatronSkin != null)
			{
				IgnoreEventReceiver = true;
				_SyncPatronSkin.ExecuteUdonEvent();
				IgnoreEventReceiver = false;
			}
		}

		internal void SendPublicNonPatreonSkinEvent()
		{
			if (_SyncPatronSkin != null)
			{
				IgnoreEventReceiver = true;
				_SyncNonPatronSkin.ExecuteUdonEvent();
				IgnoreEventReceiver = false;
			}
		}

		internal void SendOnlySelfNonPatreonSkinEvent()
		{
			if (pickup != null)
			{
				if (pickup.IsHeld)
				{
					if (pickup.CurrentObjectHolderPlayer == Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi())
					{
						if (_SyncPatronSkin != null)
						{
							IgnoreEventReceiver = true;
							_SyncNonPatronSkin.ExecuteUdonEvent();
							IgnoreEventReceiver = false;
						}
					}
				}
			}
		}

		internal void SendOnlySelfPatreonSkinEvent()
		{
			if (pickup != null)
			{
				if (pickup.IsHeld)
				{
					if (pickup.CurrentObjectHolderPlayer == Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi())
					{
						if (_SyncPatronSkin != null)
						{
							IgnoreEventReceiver = true;
							_SyncPatronSkin.ExecuteUdonEvent();
							IgnoreEventReceiver = false;
						}
					}
				}
			}
		}

		internal CachedUdonEvent SyncNonPatronSkin
		{
			get
			{
				return _SyncNonPatronSkin;
			}
		}

		internal CachedUdonEvent SyncPatronSkin
		{
			get
			{
				return _SyncPatronSkin;
			}
		}

		private PickupController pickup;
		private GameObject LocalObject;
		private bool IgnoreEventReceiver;
		private CachedUdonEvent _SyncNonPatronSkin;
		private CachedUdonEvent _SyncPatronSkin;
	}
}