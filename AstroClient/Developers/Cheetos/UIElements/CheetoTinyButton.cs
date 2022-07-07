namespace CheetoClient;

#region Imports
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#endregion

public class CheetoTinyButton : CheetoElement
{
	public CheetoTinyButton() : base(Utils.QM.Templates.TinyButton.gameObject, Utils.QM.Templates.TinyButton.parent)
	{
		Self.name = $"CTB-{ID}";

		Object.Destroy(Self.GetComponent<Toggle>());
		//Object.Destroy(Self.GetComponent<SafeModeToggle>());
		Object.Destroy(Self.GetComponent<EventTrigger>());

		Image icon = Self.transform.Find("Icon").GetComponent<Image>();
		icon.overrideSprite = Icons.CheetoSprite;

		// temp stuff
		var rect = Self.GetComponent<RectTransform>();
		rect.localPosition += new Vector3(100f, 0, 0);
	}
}
