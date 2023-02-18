namespace CheetoClient;

using System;

public class ElementOptions
{
	public string Title;
	public ButtonTypes Type;
	public Action PrimaryAction;
	public Action SecondaryAction;
	public Action OnClick;
	public string ToolTip;

	public enum ButtonTypes
	{
		REGULAR, NESTED, TOGGLE
	}

	public ElementOptions(string title, string tooltip, ButtonTypes type = ButtonTypes.REGULAR, Action primary = null, Action secondary = null)
	{
		Title = title;
		Type = type;
		PrimaryAction = primary;
		SecondaryAction = secondary;
		ToolTip = tooltip;
	}
}
