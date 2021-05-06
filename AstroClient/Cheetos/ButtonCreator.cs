namespace AstroClient
{
	using TMPro;
	using UnityEngine;

	public static class ButtonCreator
	{
		public static GameObject Create(Vector3 position, Quaternion rotation)
		{
			var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			go.transform.position = position;
			go.transform.rotation = rotation;
			go.transform.localScale = new Vector3(0.2f, 0.1f, 0.1f);

			var textObject = new GameObject("Text");
			var rect = textObject.AddComponent<RectTransform>();
			rect.sizeDelta = new Vector2(1f, 1f);
			rect.transform.position = go.transform.position;
			rect.transform.rotation = go.transform.rotation;
			rect.transform.localScale = new Vector3(0.09999999f, 0.09999999f, 1);
			rect.transform.position += new Vector3(0, 0, -0.51f);
			var text = textObject.AddComponent<TextMeshPro>();
			text.text = "Button";
			text.color = Color.black;
			text.autoSizeTextContainer = true;

			return go;
		}
	}
}
