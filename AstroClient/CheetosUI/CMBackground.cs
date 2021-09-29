namespace AstroClient
{
    #region Imports

    using UnityEngine;
    using UnityEngine.UI;

    #endregion Imports

    internal class CMBackground
    {
        internal GameObject GetGameObject { get; private set; }

        internal CMBackground(Transform parent, Color color)
        {
            GetGameObject = new GameObject("Background");
            _ = GetGameObject.AddComponent<RectTransform>();
            GetGameObject.transform.SetParent(parent, false);
            GetGameObject.GetComponent<RectTransform>().position = new Vector3(0f, 0f, 0f);
            GetGameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
            GetGameObject.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
            GetGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            _ = GetGameObject.AddComponent<CanvasRenderer>();
            _ = GetGameObject.AddComponent<Image>();
            GetGameObject.GetComponent<Image>().sprite = null;
            GetGameObject.GetComponent<Image>().fillAmount = 1f;
            GetGameObject.GetComponent<Image>().color = color;
        }
    }
}