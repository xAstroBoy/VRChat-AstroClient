namespace AstroClient.CheetosUI
{
    #region Imports

    using UnityEngine;
    using UnityEngine.UI;

    #endregion Imports

    internal class CMLabel : CMBase
    {
        internal CMLabel(Transform parent, Vector2 position, string text, Color? color = null, int minTextSize = 12, int maxTextSize = 70) : base(parent, position)
        {
            Color _color = color == null ? Color.black : (Color)color;

            GetGameObject.name = "CMLabel";
            _ = GetGameObject.AddComponent<Text>();
            GetGameObject.GetComponent<Text>().text = text;
            GetGameObject.GetComponent<Text>().font = Font.GetDefault();
            GetGameObject.GetComponent<Text>().resizeTextForBestFit = true;
            GetGameObject.GetComponent<Text>().supportRichText = true;
            GetGameObject.GetComponent<Text>().resizeTextMinSize = minTextSize;
            GetGameObject.GetComponent<Text>().resizeTextMaxSize = maxTextSize;
            GetGameObject.GetComponent<Text>().color = _color;
            GetGameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        }

        internal CMLabel SetText(string text)
        {
            GetGameObject.GetComponent<Text>().text = text;
            return this;
        }

        internal CMLabel SetColor(Color color)
        {
            GetGameObject.GetComponent<Text>().color = color;
            return this;
        }
    }
}