namespace AstroClient
{
	#region Imports

	using UnityEngine;
	using UnityEngine.UI;

	#endregion

	public class CheetoText
	{
		public GameObject GetGameObject { get; private set; }

		public CheetoText(Transform parent, string text)
		{
			GetGameObject = new GameObject("Text");
			GetGameObject.AddComponent<RectTransform>();
			GetGameObject.transform.SetParent(parent, false);
			GetGameObject.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
			GetGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
			GetGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
			GetGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
			GetGameObject.AddComponent<CanvasRenderer>();
			GetGameObject.AddComponent<Text>();
			GetGameObject.GetComponent<Text>().text = text;
			GetGameObject.GetComponent<Text>().font = Font.GetDefault();
			GetGameObject.GetComponent<Text>().resizeTextForBestFit = true;
			GetGameObject.GetComponent<Text>().resizeTextMaxSize = 70;
			GetGameObject.GetComponent<Text>().color = Color.blue;
			GetGameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		}
	}
}