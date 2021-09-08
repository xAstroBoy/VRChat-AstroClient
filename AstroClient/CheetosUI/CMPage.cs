namespace AstroClient
{
    #region Imports

    using AstroLibrary.Console;
    using UnityEngine;

    #endregion Imports

    public class CMPage
    {
        public GameObject GetGameObject { get; private set; }

        public CMPage(Transform parent)
        {
            GetGameObject = new GameObject("CMPage");
            GetGameObject.transform.SetParent(parent, false);
            _ = GetGameObject.AddComponent<RectTransform>();
            _ = new CMLabel(GetGameObject.transform, new Vector2(-200, 0), "Page Content");

            var button = new CMButton(GetGameObject.transform, new Vector2(0, 0), "Test Button", () => ModConsole.Log("Test Button Clicked!"));
            button.GetGameObject.transform.position = new Vector3(32, 32, 0);
        }
    }
}