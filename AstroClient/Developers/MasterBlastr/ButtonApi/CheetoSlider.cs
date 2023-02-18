namespace CheetoClient.UIElements;

#region Usings
using UnityEngine;
#endregion

public class CheetoSlider : CheetoElement
{
	public CheetoSlider(Transform parent) : base(QMTemplates.Slider.gameObject, parent)
	{
		Self.name = $"CS-{ID}";
	}
}