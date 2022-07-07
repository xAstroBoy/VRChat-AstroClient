namespace CheetoClient.Utils;

#region Imports
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
#endregion

public static partial class QM
{
	internal static class Fixer
	{

		// Whitelist all the essential components for UI Buttons to work.
		private static List<string> _protectedComponents { get; } = new List<string>()
		{
			typeof(Button).FullName,
			typeof(LayoutElement).FullName,
			typeof(CanvasGroup).FullName,
			typeof(Image).FullName,
			typeof(TextMeshProUGUI).FullName,
			typeof(RectTransform).FullName,
			typeof(CanvasRenderer).FullName,
			typeof(StyleElement).FullName,
			typeof(VRC.UI.Elements.Tooltips.UiToggleTooltip).FullName,
			typeof(VRC.UI.Elements.Tooltips.UiTooltip).FullName,
			typeof(Toggle).FullName,
			typeof(UIInvisibleGraphic).FullName,
		};

		internal static void EnableButtonComponents(GameObject parent)
		{
			#region Button

			var Button = parent.GetComponent<Button>();
			if (Button != null)
			{
				Button.enabled = true;
			}

			var Buttons_List = parent.GetComponentsInChildren<Button>(true);
			for (var i = 0; i < Buttons_List.Count; i++)
			{
				var item = Buttons_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion Button

			#region LayoutElement

			var LayoutElement = parent.GetComponent<LayoutElement>();
			if (LayoutElement != null)
			{
				LayoutElement.enabled = true;
			}

			var LayoutElements_List = parent.GetComponentsInChildren<LayoutElement>(true);
			for (var i = 0; i < LayoutElements_List.Count; i++)
			{
				var item = LayoutElements_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion LayoutElement

			#region StyleElement

			var StyleElement = parent.GetComponent<StyleElement>();
			if (StyleElement != null)
			{
				StyleElement.enabled = true;
			}

			var StyleElements_List = parent.GetComponentsInChildren<StyleElement>(true);
			for (var i = 0; i < StyleElements_List.Count; i++)
			{
				var item = StyleElements_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion StyleElement

			#region CanvasGroup

			var CanvasGroup = parent.GetComponent<CanvasGroup>();
			if (CanvasGroup != null)
			{
				CanvasGroup.enabled = true;
			}

			var CanvasGroups_List = parent.GetComponentsInChildren<CanvasGroup>(true);
			for (var i = 0; i < CanvasGroups_List.Count; i++)
			{
				var item = CanvasGroups_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion CanvasGroup

			#region Image

			var Image = parent.GetComponent<Image>();
			if (Image != null)
			{
				Image.enabled = true;
			}

			var Images_List = parent.GetComponentsInChildren<Image>(true);
			for (var i = 0; i < Images_List.Count; i++)
			{
				var item = Images_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion Image

			#region TextMeshProUGUI

			var TextMeshProUGUI = parent.GetComponent<TextMeshProUGUI>();
			if (TextMeshProUGUI != null)
			{
				TextMeshProUGUI.enabled = true;
			}

			var TextMeshProUGUIs_List = parent.GetComponentsInChildren<TextMeshProUGUI>(true);
			for (var i = 0; i < TextMeshProUGUIs_List.Count; i++)
			{
				var item = TextMeshProUGUIs_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion TextMeshProUGUI

			#region UiTooltip

			var UiTooltip = parent.GetComponent<UiTooltip>();
			if (UiTooltip != null)
			{
				UiTooltip.enabled = true;
			}

			var UiTooltips_List = parent.GetComponentsInChildren<UiTooltip>(true);
			for (var i = 0; i < UiTooltips_List.Count; i++)
			{
				var item = UiTooltips_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion UiTooltip

			#region Toggle

			var Toggle = parent.GetComponent<Toggle>();
			if (Toggle != null)
			{
				Toggle.enabled = true;
			}

			var Toggles_List = parent.GetComponentsInChildren<Toggle>(true);
			for (var i = 0; i < Toggles_List.Count; i++)
			{
				var item = Toggles_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion Toggle

			#region UIInvisibleGraphic

			var UIInvisibleGraphic = parent.GetComponent<UIInvisibleGraphic>();
			if (UIInvisibleGraphic != null)
			{
				UIInvisibleGraphic.enabled = true;
			}

			var UIInvisibleGraphics_List = parent.GetComponentsInChildren<UIInvisibleGraphic>(true);
			for (var i = 0; i < UIInvisibleGraphics_List.Count; i++)
			{
				var item = UIInvisibleGraphics_List[i];
				if (item != null)
				{
					item.enabled = true;
				}
			}

			#endregion UIInvisibleGraphic

			var parentcomps = parent.GetComponents<Component>();
			for (int i = 0; i < parentcomps.Count; i++)
			{
				var name = parentcomps[i].GetIl2CppType().FullName;
				//Log.Debug($"Found {name}");
				if (!_protectedComponents.Contains(name))
				{
					Object.DestroyImmediate(parentcomps[i]);
				}
			}

			var childs = parent.GetComponentsInChildren<Component>(true);
			for (int i = 0; i < childs.Count; i++)
			{
				var name = childs[i].GetIl2CppType().FullName;
				//Log.Debug($"Found {name}");
				if (!_protectedComponents.Contains(name))
				{
					Object.DestroyImmediate(childs[i]);
				}
			}
		}
	}
}