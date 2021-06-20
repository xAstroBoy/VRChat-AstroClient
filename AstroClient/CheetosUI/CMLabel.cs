namespace AstroClient
{
	#region Imports

	using UnityEngine;
	using UnityEngine.UI;

	#endregion Imports

	public class CMLabel : CMBase
	{
        public CMLabel(Transform parent, Vector2 position, string text) : base(parent, position)
        {
            GetGameObject.name = "CMLabel";
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