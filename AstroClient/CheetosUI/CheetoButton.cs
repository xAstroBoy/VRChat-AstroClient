namespace AstroClient
{
	#region Imports

	using System;
	using UnityEngine;
	using UnityEngine.UI;

	#endregion

	public class CheetoButton
	{
		public GameObject GetGameObject { get; private set; }

		public CheetoButton(Transform parent, string text)
		{
			GetGameObject = new GameObject("Button");
			GetGameObject.AddComponent<RectTransform>();
			GetGameObject.transform.SetParent(parent, false);
			GetGameObject.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
			GetGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
			GetGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
			GetGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
			GetGameObject.AddComponent<CanvasRenderer>();
			GetGameObject.AddComponent<Image>();
			GetGameObject.GetComponent<Image>().sprite = null;
			GetGameObject.GetComponent<Image>().color = Color.cyan;
			GetGameObject.GetComponent<Image>().fillAmount = 1f;
			GetGameObject.AddComponent<Button>();
			GetGameObject.AddComponent<Button>().interactable = true;

			_ = new CheetoText(GetGameObject.transform, text);
		}
	}
}