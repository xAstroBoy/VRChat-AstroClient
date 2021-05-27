namespace AstroClient
{
	#region Imports

	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.ButtonShortcut;
	using AstroClient.Components;
	using AstroLibrary.Console;
	using AstroClient.GameObjectDebug;
	using AstroClient.Startup.Buttons;
	using AstroClient.variables;
	using AstroClient.WorldLights;
	using AstroClient.Worlds;
	using MelonLoader;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using UnhollowerBaseLib;
	using System.Windows.Forms;
	using UnityEngine;
	using Button = UnityEngine.UI.Button;
	using VRC;
	using System.Linq;
	using AstroClient.AvatarMods;
	using VRC.UI;
	using VRC.Core;

	#endregion Imports

	public class Main : MelonMod
	{
		//public static event EventHandler Event_OnApplicationStart;

		public static event EventHandler Event_OnUpdate;

		public static event EventHandler Event_LateUpdate;

		public static event EventHandler Event_VRChat_OnUiManagerInit;

		public static event EventHandler Event_OnLevelLoaded;

		public static event EventHandler Event_OnApplicationQuit;


		public static List<GameEvents> Overridable_List = new List<GameEvents>();

		public override void OnApplicationStart()
		{
			ModConsole.ModName = "AstroClient";
			LogSupport.RemoveAllHandlers();
			ConfigManager.Validate();
			ConfigManager.Load();
			if (ModConsole.DebugMode != ConfigManager.General.DebugLog)
			{
				ModConsole.DebugMode = ConfigManager.General.DebugLog;
			}
#if OFFLINE
			KeyManager.IsAuthed = true;
			Bools.IsDeveloper = true;
#else
			KeyManager.ReadKey();
			AstroNetworkClient.Initialize();

			while (!KeyManager.IsAuthed)
			{
			}
#endif

			//try
			//{
			//	Console.WriteFigletWithGradient(FigletFont.LoadFromAssembly("Larry3D.flf"), BuildInfo.Name, System.Drawing.Color.LightBlue, System.Drawing.Color.MidnightBlue);
			//}
			//catch (Exception e)
			//{
			//	ModConsole.Error("Failed To generate Gradient, the Embeded file doesn't exist!");
			//	ModConsole.ErrorExc(e);
			//}

			InitializeOverridables();
			//Event_OnApplicationStart?.Invoke(this, new EventArgs());
		}


		public override void OnApplicationQuit()
		{
			Event_OnApplicationQuit?.Invoke(this, new EventArgs());
		}


		public override void OnPreferencesSaved()
		{
			if (KeyManager.IsAuthed)
			{
				ConfigManager.Save_All();
			}
		}

		public static void InitializeOverridables()
		{
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				var btype = type.BaseType;

				if (btype != null && btype.Equals(typeof(GameEvents)))
				{
					GameEvents component = Assembly.GetExecutingAssembly().CreateInstance(type.ToString(), true) as GameEvents;
					component.ExecutePriorityPatches(); // NEEDED TO DO PATCHING EVENT

					component.OnApplicationStart();
					Overridable_List.Add(component);
				}
			}
		}

		public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			switch (buildIndex)
			{
				case 0: // app
				case 1: // ui
					break;

				default:
					//Task.Run(() => {  });
					Event_OnLevelLoaded?.Invoke(this, new EventArgs());
					if (ToggleDebugInfo != null)
					{
						ToggleDebugInfo.SetToggleState(Bools.IsDebugMode);
					}
					break;
			}
		}

		public override void OnUpdate()
		{
			//if (Application.targetFrameRate != int.MaxValue)
			//{
			//Application.targetFrameRate = int.MaxValue;
			//}
			Event_OnUpdate?.Invoke(this, new EventArgs());
		}

		public override void OnLateUpdate()
		{
			Event_LateUpdate?.Invoke(this, new EventArgs());
		}

		public override void VRChat_OnUiManagerInit()
		{
			if (KeyManager.IsAuthed == true)
			{
				QuickMenuUtils.SetQuickMenuCollider(5, 5);
				UserInteractMenuBtns.InitButtons(1, 3, true); //UserMenu Main Button

				InitMainsButtons(5, 0, true);
				ItemTweakerMain.InitButtons(5, 0.5f, true); //ItemTweaker Main Button
				new QMSingleButton("ShortcutMenu", 5, 2, "GameObject Toggler", new Action(() =>
				{ GameObjMenu.ReturnToRoot(); GameObjMenu.gameobjtogglermenu.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke(); }
				), "Advanced GameObject Toggler", null, null, true);
				CheatsShortcutButton.Init_Cheats_ShortcutBtn(5, 1.5f, true);

				Event_VRChat_OnUiManagerInit?.Invoke(this, new EventArgs());
			}
		}

		public static void InitMainsButtons(float x, float y, bool btnHalf)
		{
			if (KeyManager.IsAuthed == true)
			{
				//QMNestedButton AstroClient = new QMNestedButton("ShortcutMenu", x, y, "AstroClient Menu", "AstroClient Menu", null, null, null, null, btnHalf);  // Menu Main Button
				QMTabMenu AstroClient = new QMTabMenu(1f, "AstroClient Menu", null, null, null, "AstroClient.Resources.planet.png");
				ToggleDebugInfo = new QMSingleToggleButton(AstroClient, 4, 2.5f, "Debug Console ON", new Action(() => { Bools.IsDebugMode = true; }), "Debug Console OFF", new Action(() => { Bools.IsDebugMode = false; }), "Shows Client Details in Melonloader's console", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);

				CopyIDButton = new QMSingleButton(AstroClient, 5, -1, "Copy\nInstance ID", delegate () { Clipboard.SetText($"{RoomManager.field_Internal_Static_ApiWorld_0.id}:{RoomManager.field_Internal_Static_ApiWorldInstance_0.idWithTags}"); }, "Copy the ID of the current instance.", null, null, true);
				JoinInstanceButton = new QMSingleButton(AstroClient, 5, -0.5f, "Join\nInstance", delegate () { new PortalInternal().Method_Private_Void_String_String_PDM_0(Clipboard.GetText().Split(':')[0], Clipboard.GetText().Split(':')[1]); }, "Join an instance via your clipboard.", null, null, true);
				VRam = new QMSingleButton(AstroClient, 5, 0, "Clear\nVRAM", delegate () { var currentAvatars = (from player in PlayerManager.prop_PlayerManager_0.prop_ArrayOf_Player_0 where player != null select player.prop_ApiAvatar_0 into apiAvatar where apiAvatar != null select apiAvatar.assetUrl).ToList(); var dict = new Dictionary<string, Il2CppSystem.Object>(); var abdm = AssetBundleDownloadManager.prop_AssetBundleDownloadManager_0; foreach (var key in abdm.field_Private_Dictionary_2_String_Object_0.Keys) { dict.Add(key, abdm.field_Private_Dictionary_2_String_Object_0[key]); } foreach (var key in dict.Keys.Where(key => !abdm.field_Private_Dictionary_2_String_Object_0[key].name.Contains("vrcw") && !currentAvatars.Contains(key))) { abdm.field_Private_Dictionary_2_String_AssetBundleDownload_0.Remove(key); abdm.field_Private_Dictionary_2_String_Object_0.Remove(key); } dict.Clear(); System.GC.Collect(System.GC.MaxGeneration, GCCollectionMode.Forced, true, true); Il2CppSystem.GC.Collect(Il2CppSystem.GC.MaxGeneration, Il2CppSystem.GCCollectionMode.Forced, true, true); Resources.UnloadUnusedAssets(); ; }, "Clear VRAM.", null, null, true);
				avatar = new QMSingleButton(AstroClient, 5, 0.5f, "Avatar\nBy ID", delegate () { string text = Clipboard.GetText(); if (text.StartsWith("avtr_")) new PageAvatar { field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal { field_Internal_ApiAvatar_0 = new ApiAvatar { id = text } } }.ChangeToSelectedAvatar(); else MelonLogger.Error("Clipboard does not contains Avatar ID!"); }, "Alows you to change into a public avatar with its id.", null, null, true); ;

				FlightMenu.InitButtons(AstroClient, 1, 0, true);
				ExploitsMenu.InitButtons(AstroClient, 1, 0, true);
				WorldsCheats.InitButtons(AstroClient, 1, 0, true);
				LightControl.InitButtons(AstroClient, 1, 0.5f, true);
				AvatarModifier.InitQMMenu(AstroClient, 1, 1, true);
				GameObjectUtils.InitButtons(AstroClient, 1, 1.5f, true);
				EmojiUtils.InitButton(AstroClient, 1, 2, true);
				if (Bools.IsDeveloper)
				{
					MapEditorMenu.InitButtons(AstroClient, 1, 2.5f, true);
				}
				WorldPickupsBtn.InitButtons(AstroClient, 2, 0, true);
				ComponentsBtn.InitButtons(AstroClient, 2, 0.5f, true);

				Headlight.Headlight.HeadlightButtonInit(AstroClient, 3, 0, true);

				SettingsMenuBtn.InitButtons(AstroClient, 3, 2.5f, true);
			}
		}

		public static QMSingleToggleButton ToggleDebugInfo;

		public static QMSingleButton CopyIDButton;
		public static QMSingleButton JoinIns;
	    public static QMSingleButton avatar;
        public static QMSingleButton VRam;
        public static QMSingleButton JoinInstanceButton;
	}
}