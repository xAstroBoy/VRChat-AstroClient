namespace AstroClient
{
	using AstroLibrary.Console;
	#region Imports

	using UnityEngine;

	#endregion Imports

	public class CheetoPage
	{
		public GameObject GetGameObject { get; private set; }

		public CheetoPage(Transform parent)
		{
			GetGameObject = new GameObject("CheetoPage");
			GetGameObject.AddComponent<RectTransform>();
			GetGameObject.transform.parent = parent;
			_ = new CheetoText(GetGameObject.transform, "Page Content");

			var button = new CheetoButton(GetGameObject.transform, "Test Button", () => { ModConsole.Log("Test Button Clicked!"); });
			button.GetGameObject.transform.position = new Vector3(200, 200, 0);
		}
	}
}