using AstroClient;
using AstroClient.xAstroBoy;

namespace CheetoClient.Utils;

using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;

public static partial class QM
{
	/// <summary>
	/// Various templates for the Quick Menu.
	/// </summary>
	public static class Templates
	{
		private static Transform _nestedMenu;
		public static Transform NestedMenu
		{
			get
			{
				if (Transform == null) return null;
				if (_nestedMenu == null)
				{
					var Buttons = Instance.GetComponentsInChildren<Transform>(true);
					for (int i = 0; i < Buttons.Count; i++)
					{
						Transform button = Buttons[i];
						if (button.name == "Menu_Camera")
						{
							return _nestedMenu = button;
						}
					}
				}

				return _nestedMenu;
			}
		}

		private static Transform _nestedPages;
		public static Transform NestedPages
		{
			get
			{
				if (_nestedPages == null)
				{
					_nestedPages = Finder.Find("UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent").transform;
					if (_nestedPages == null)
					{
						Log.Warn("Failed to find QMParent");
					}
				}

				return _nestedPages;
			}
		}

		private static Transform _singleButton;
		public static Transform SingleButton
		{
			get
			{
				if (_singleButton == null)
				{
					var Buttons = Transform.GetComponentsInChildren<Button>(true);
					for (int i = 0; i < Buttons.Count; i++)
					{
						Button button = Buttons[i];
						if (button.name == "Button_VoteKick")
							_singleButton = button.transform;
					}
				}

				return _singleButton;
			}
		}
		
		private static Transform _wingButton;
		public static Transform WingButton
		{
			get
			{
				if (_wingButton == null)
				{
					_wingButton = Finder.Find("UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Emotes").transform;;
					if (_wingButton == null)
					{
						Log.Warn("Failed to find Wing Button");
					}
				}

				return _wingButton;
			}
		}

		private static Transform _tinyButton;
		public static Transform TinyButton
		{
			get
			{
				if (_tinyButton == null)
				{
					var Buttons = Transform.GetComponentsInChildren<Image>(true);
					for (int i = 0; i < Buttons.Count; i++)
					{
						Image button = Buttons[i];
						if (button.name == "Toggle_SafeMode")
							_tinyButton = button.transform;
					}
				}

				return _tinyButton;
			}
		}



		private static Transform _gridLayoutGroup;
		public static Transform GridLayoutGroup
		{
			get
			{
				if (_gridLayoutGroup == null)
				{
					var groups = Transform.GetComponentsInChildren<GridLayoutGroup>(true);
					for (int i = 0; i < groups.Count; i++)
					{
						GridLayoutGroup group = groups[i];
						if (group.name == "Buttons")
							_gridLayoutGroup = group.transform;
					}
				}

				return _gridLayoutGroup;
			}
		}

		private static Transform _expandButton;
		public static Transform ExpandButton
		{
			get
			{
				if (_expandButton == null)
				{
					var Buttons = Transform.GetComponentsInChildren<Button>(true);
					for (int i = 0; i < Buttons.Count; i++)
					{
						Button button = Buttons[i];
						if (button.name == "Button_QM_Expand")
							_expandButton = button.transform;
					}
				}

				return _expandButton;
			}
		}

		private static Transform _panelInfo;
		public static Transform PanelInfo
		{
			get
			{
				if (_panelInfo == null)
				{
					var panels = Transform.GetComponentsInChildren<Image>(true);
					for (int i = 0; i < panels.Count; i++)
					{
						Image panel = panels[i];
						if (panel.name == "Panel_Info")
							_panelInfo = panel.transform;
					}
				}

				return _panelInfo;
			}
		}

		private static Transform _menuDashboard_ButtonsSection;
		public static Transform MenuDashboard_ButtonsSection
		{
			get
			{
				if (_menuDashboard_ButtonsSection == null)
				{
					var Buttons = Transform.GetComponentsInChildren<Transform>(true);
					for (int i = 0; i < Buttons.Count; i++)
					{
						Transform button = Buttons[i];
						if (button.name == "Buttons_QuickActions")
						{
							_menuDashboard_ButtonsSection = button;
							break;
						}
					}
				}

				return _menuDashboard_ButtonsSection;
			}
		}

		private static Transform _avatarMenu;
		public static Transform AvatarMenu
		{
			get
			{
				if (_avatarMenu == null)
				{
					_avatarMenu = Finder.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List").transform;
					if (_avatarMenu == null)
					{
						Log.Warn("Failed to find Avatar Menu");
					}
				}

				return _avatarMenu;
			}
		}

		private static Transform _volumeLabel;
		public static Transform VolumeLabel
		{
			get
			{
				if (_volumeLabel == null)
				{
					_volumeLabel = Finder.Find("UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_AudioSettings/Content/Header_H2").transform;
					if (_volumeLabel == null)
					{
						Log.Warn("Failed to find Volume Label");
					}
				}

				return _volumeLabel;
			}
		}

		private static Transform _slider;
		public static Transform Slider
		{
			get
			{
				if (_slider == null)
				{
					_slider = Finder.Find("UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_AudioSettings/Content/Audio/VolumeSlider_World").transform;
					if (_slider == null)
					{
						Log.Warn("Failed to find Slider");
					}
				}

				return _slider;
			}
		}
	}
}