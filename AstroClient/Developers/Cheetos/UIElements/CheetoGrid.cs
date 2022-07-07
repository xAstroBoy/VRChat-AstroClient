namespace CheetoClient;

using UnityEngine;
using UnityEngine.UI;

public class CheetoGrid : CheetoElement
{
	public CheetoGrid(Transform parent) : base(Utils.QM.Templates.GridLayoutGroup.gameObject, parent)
	{
		try
		{
			Self.GetComponent<GridLayoutGroup>().enabled = true;
			Self.name = $"CG-{ID}";
			Self.gameObject.SetActive(true);

			var list = Self.GetChildren();
			for (int i = 0; i < list.Count; i++)
			{
				Transform child = list[i];
				Object.Destroy(child.gameObject);
			}
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