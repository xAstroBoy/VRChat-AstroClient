namespace CheetoClient;

using UnityEngine;

public class ElementStyle
{
	public Sprite Icon = null;
	public Color? Color;

	public ElementStyle(Sprite icon = null, Color? color = null)
	{
		Icon = icon;
		Color = color;
	}
}
