namespace AstroClient
{
	#region Imports

	using UnityEngine;

	#endregion Imports

	public class CheetoPage
	{
		public GameObject Page;

		public CheetoPage(Transform parent)
		{
			Page = new GameObject("CheetoPage");
			Page.AddComponent<RectTransform>();
			Page.transform.parent = parent;
			_ = new CheetoText(Page.transform);
		}
	}
}