namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using System;
	using UnityEngine;
	using UnityEngine.UI;

	#endregion Imports

	public class CMButton : CMBase
    {
        public CMButton(Transform parent, Vector2 position, string text, Action action) : base(parent, position)
        {
			GetGameObject.name = $"CMButton-{text}";

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

            _ = new CMLabel(GetGameObject.transform, new Vector2(0, 0), text);
        }
    }
}