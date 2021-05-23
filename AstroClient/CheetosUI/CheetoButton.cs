namespace AstroClient
{
	using System;
	#region Imports

	using UnityEngine;
	using UnityEngine.UI;

	#endregion

	public class CheetoButton
	{
		public GameObject GetGameObject { get; private set; }

		public Action ButtonAction;

		public CheetoButton(Transform parent, string text, Action action)
		{
			GetGameObject = new GameObject("Button");
			GetGameObject.AddComponent<RectTransform>();
			GetGameObject.transform.SetParent(parent, false);
			GetGameObject.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
			GetGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
			GetGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
			GetGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
			GetGameObject.AddComponent<CanvasRenderer>();
			GetGameObject.AddComponent<Button>();
			GetGameObject.GetComponent<Button>().onClick.AddListener(action);

			_ = new CheetoText(GetGameObject.transform, text);
		}

	}
}