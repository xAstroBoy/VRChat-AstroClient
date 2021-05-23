namespace AstroClient
{
	#region Imports

	using UnityEngine;
	using UnityEngine.UI;

	#endregion

	public class CheetoText
	{
		public GameObject Text;

		public CheetoText(Transform parent)
		{
			Text = new GameObject("Text");
			Text.AddComponent<RectTransform>();
			Text.transform.SetParent(parent, false);
			Text.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
			Text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
			Text.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
			Text.AddComponent<CanvasRenderer>();
			Text.AddComponent<Text>();
			Text.GetComponent<Text>().text = "AstroClient Menu";
			Text.GetComponent<Text>().font = Font.GetDefault();
			Text.GetComponent<Text>().resizeTextForBestFit = true;
			Text.GetComponent<Text>().resizeTextMaxSize = 70;
			Text.GetComponent<Text>().color = Color.blue;
			Text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		}

	}
}