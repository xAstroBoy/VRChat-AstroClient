namespace AstroClient
{
	#region Imports

	using UnityEngine;
	using UnityEngine.UI;
	#endregion Imports

	public class CheetoPage
	{
		public GameObject Page;

		public CheetoPage(Transform parent)
		{
			Page = new GameObject("CheetoPage");
			Page.transform.parent = parent;
			Page.AddComponent<CanvasRenderer>();
			Page.AddComponent<Image>();
			Page.GetComponent<Image>().sprite = null;
			Page.GetComponent<Image>().fillAmount = 0.75f;
			Page.GetComponent<Image>().color = Color.gray;
		}
	}
}