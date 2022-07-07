namespace CheetoClient.UI;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Color = Cheetah.Color;

public static class Extensions
{
	public static TextMeshProUGUI NewText(this GameObject Parent, string search)
	{
		var text = new TextMeshProUGUI();

		var TextTop = Parent.GetComponentsInChildren<TextMeshProUGUI>();
		for (int i = 0; i < TextTop.Count; i++)
		{
			TextMeshProUGUI texto = TextTop[i];
			if (texto.name == search)
				text = texto;
		}

		return text;
	}

	public static void LoadSprite(this GameObject Parent, Sprite sprite, string name)
	{
		var list = Parent.GetComponentsInChildren<Image>(true);
		for (int i = 0; i < list.Count; i++)
		{
			Image image = list[i];
			if (image.name == name) // allows background image change
			{
				if (sprite != null)
				{
					image.gameObject.SetActive(true);
					image.overrideSprite = sprite;
					image.MakeImageMoreSolid();
				}
				else
				{
					image.gameObject.SetActive(false);
					image.overrideSprite = null;
				}
			}
		}
	}

	public static void CleanButtonsNestedMenu(this GameObject Parent)
	{
		var ButtonToDelete = Parent.GetComponentsInChildren<Button>(true);
		for (int i = 0; i < ButtonToDelete.Count; i++)
		{
			Button Button = ButtonToDelete[i];
			if (Button.name.Contains("Camera") || Button.name == "Button_Panorama" || Button.name == "Button_Screenshot"
				|| Button.name == "Button_VrChivePano" || Button.name == "Button_DynamicLight")
				Object.Destroy(Button.gameObject);
		}

		var ButtonToDelete2 = Parent.GetComponentsInChildren<Toggle>(true);
		for (int i1 = 0; i1 < ButtonToDelete2.Count; i1++)
		{
			Toggle Button = ButtonToDelete2[i1];
			if (Button.name == "Button_Steadycam")
				Object.Destroy(Button.gameObject);
		}
	}

	/// <summary>
	///  this kills The blue effect of vrchat GUI by Destroying StyleElement if present
	/// </summary>
	/// <param name="image"></param>
	public static void MakeImageMoreSolid(this Image image)
	{
		var StyleElement = image.GetComponent<VRC.UI.Core.Styles.StyleElement>();
		if (StyleElement != null)
		{
			Object.DestroyImmediate(StyleElement);
		}

		// White
		image.color = Color.White;
	}

	public static void MakeTextMoreSolid(this TextMeshProUGUI text)
	{
		var StyleElement = text.GetComponent<VRC.UI.Core.Styles.StyleElement>();
		if (StyleElement != null)
		{
			Object.DestroyImmediate(StyleElement);
		}

		// White
		text.color = Color.White;
	}

	public static void MakeTextMoreSolid(this Text text)
	{
		var StyleElement = text.GetComponent<VRC.UI.Core.Styles.StyleElement>();
		if (StyleElement != null)
		{
			Object.DestroyImmediate(StyleElement);
		}

		// White
		text.color = Color.White;
	}
}