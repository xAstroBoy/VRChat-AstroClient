namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using System;
	using UnityEngine;
	using UnityEngine.UI;

	#endregion Imports

	public class CMButton
    {
        public GameObject GetGameObject { get; private set; }

        public CMButton(Transform parent, Vector2 position, string text, Action action)
        {
            GetGameObject = new GameObject($"CMButton-{text}");
            GetGameObject.AddComponent<RectTransform>();
            GetGameObject.transform.SetParent(parent, false);
            GetGameObject.GetComponent<RectTransform>().position = position;
            GetGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            GetGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            GetGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
            GetGameObject.AddComponent<CanvasRenderer>();
            GetGameObject.AddComponent<Image>();
            GetGameObject.GetComponent<Image>().sprite = null;
            GetGameObject.GetComponent<Image>().color = Color.cyan;
            GetGameObject.GetComponent<Image>().fillAmount = 1f;
            GetGameObject.AddComponent<Button>();
            GetGameObject.GetComponent<Button>().interactable = true;
            GetGameObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();

            if (action != null)
            {
                GetGameObject.GetComponent<Button>().onClick.AddListener(new Action(() => { action?.Invoke(); }));
            }
            else
            {
                ModConsole.Error($"Failed to put action on CheetoButton: {GetGameObject.name}");
            }

            _ = new CMLabel(GetGameObject.transform, text);
        }
    }
}