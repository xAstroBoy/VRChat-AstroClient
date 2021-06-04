namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using UnityEngine;

	#endregion Imports

	public class CheetoPage
    {
        public GameObject GetGameObject { get; private set; }

        public CheetoPage(Transform parent)
        {
            GetGameObject = new GameObject("CheetoPage");
            GetGameObject.transform.SetParent(parent, false);
            GetGameObject.AddComponent<RectTransform>();
            _ = new CheetoText(GetGameObject.transform, "Page Content");

            var button = new CheetoButton(GetGameObject.transform, "Test Button", () => ModConsole.Log("Test Button Clicked!"));
            button.GetGameObject.transform.position = new Vector3(32, 32, 0);
        }
    }
}