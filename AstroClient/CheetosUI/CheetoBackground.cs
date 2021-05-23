namespace AstroClient
{
	#region Imports

	using UnityEngine;
	using UnityEngine.UI;

	#endregion

	public class CheetoBackground
	{
		public GameObject Background;

		public CheetoBackground(Transform parent)
		{
			Background = new GameObject("Background");
			Background.AddComponent<RectTransform>();
			Background.transform.SetParent(parent, false);
			Background.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
			Background.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
			Background.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
			Background.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
			Background.AddComponent<CanvasRenderer>();
			Background.AddComponent<Image>();
			Background.GetComponent<Image>().sprite = null;
			Background.GetComponent<Image>().fillAmount = 1f;
			Background.GetComponent<Image>().color = Color.gray;
		}
	}
}