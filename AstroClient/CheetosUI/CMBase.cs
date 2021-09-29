namespace AstroClient
{
    #region Imports

    using UnityEngine;

    #endregion Imports

    internal class CMBase
    {
        public GameObject GetGameObject { get; private set; }

        public CMBase(Transform parent, Vector2 position)
        {
            GetGameObject = new GameObject($"CMBase");
            _ = GetGameObject.AddComponent<CanvasRenderer>();
            _ = GetGameObject.AddComponent<RectTransform>();
            GetGameObject.transform.SetParent(parent, false);
            GetGameObject.GetComponent<RectTransform>().position = position;
            GetGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            GetGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            GetGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
        }
    }
}