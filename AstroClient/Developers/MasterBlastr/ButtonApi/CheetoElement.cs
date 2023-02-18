namespace CheetoClient;

#region Imports
using UnityEngine;
#endregion

public class CheetoElement
{
	public int ID;
	public readonly GameObject Self;

	public CheetoElement(GameObject prefab, Transform parent)
	{
		Self = Object.Instantiate(prefab, parent, true);
		ID = UIManager.GetFreeID();
		UIManager.Elements.Add(this);
	}

	private VRC.UI.Elements.Tooltips.UiTooltip _toolTipCache;
	public VRC.UI.Elements.Tooltips.UiTooltip ToolTip
	{
		get
		{
			if (_toolTipCache != null) return _toolTipCache;
			var attempt1 = (Self.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>() ?? Self.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true)) ?? Self.AddComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
			return attempt1 != null ? _toolTipCache = attempt1 : _toolTipCache;
		}
	}
}
