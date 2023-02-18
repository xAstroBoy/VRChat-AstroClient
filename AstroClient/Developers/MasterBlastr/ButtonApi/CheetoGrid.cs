namespace CheetoClient;

using QM;
using UnityEngine;
using UnityEngine.UI;

public class CheetoGrid : CheetoElement
{
	public CheetoGrid(Transform parent) : base(QMTemplates.GridLayoutGroup.gameObject, parent)
	{
		try
		{
			Self.GetComponent<GridLayoutGroup>().enabled = true;
			Self.name = $"CG-{ID}";
			Self.gameObject.SetActive(true);
			Self.gameObject.transform.DestroyChildren();
		}
		catch
		{
			Log.Error("0x014B");
		}
	}

	public CheetoGrid(CheetoElement parent) : this(parent.Self.transform)
	{
	}
}