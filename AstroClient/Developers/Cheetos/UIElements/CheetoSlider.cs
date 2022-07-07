namespace CheetoClient;

#region Imports
using UnityEngine;
using Utils;
#endregion

public class CheetoSlider : CheetoElement
{
	public CheetoSlider(Transform parent) : base(QM.Templates.Slider.gameObject, parent)
	{
		Self.name = $"CS-{ID}";
	}
}