﻿namespace AstroClient
{
	#region Imports

	using UnityEngine;
	using UnityEngine.UI;

	#endregion

	public class CheetoBackground
	{
		public GameObject GetGameObject { get; private set; }

		public CheetoBackground(Transform parent)
		{
			GetGameObject = new GameObject("Background");
			GetGameObject.AddComponent<RectTransform>();
			GetGameObject.transform.SetParent(parent, false);
			GetGameObject.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
			GetGameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
			GetGameObject.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
			GetGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
			GetGameObject.AddComponent<CanvasRenderer>();
			GetGameObject.AddComponent<Image>();
			GetGameObject.GetComponent<Image>().sprite = null;
			GetGameObject.GetComponent<Image>().fillAmount = 1f;
			GetGameObject.GetComponent<Image>().color = Color.gray;
		}
	}
}