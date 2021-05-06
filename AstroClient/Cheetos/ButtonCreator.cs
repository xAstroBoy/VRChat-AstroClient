namespace AstroClient
{
	using TMPro;
	using UnityEngine;

	public static class ButtonCreator
	{
		public static GameObject Create()
		{
			var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

			var textObject = new GameObject("Text");
			var rect = textObject.AddComponent<RectTransform>();
			rect.transform.position += new Vector3(0, 0, -0.51f);
			var text = textObject.AddComponent<TextMeshPro>();
			text.text = "Button";

			return go;
		}
	}
}
