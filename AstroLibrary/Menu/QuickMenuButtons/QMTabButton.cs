namespace RubyButtonAPI
{
	using System;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.UI;
	using Button = UnityEngine.UI.Button;

	public class QMTabButton : QMTabBase
	{
		public QMTabButton(float btnXLocation, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, string ImageURL = null)
		{
			InitButton(btnXLocation, btnAction, btnToolTip, btnBackgroundColor, ImageURL);
		}

		public QMTabButton(float btnXLocation, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, byte[] ImageData = null)
		{
			InitButton(btnXLocation, btnAction, btnToolTip, btnBackgroundColor, ImageData);
		}

		private void InitButton(float btnXLocation, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, string ImageURL = null)
		{
			btnType = "QMTabButton";
			button = UnityEngine.Object.Instantiate(QuickMenuStuff.TabButtonTemplate(), QuickMenuStuff.TabButtonTemplate().transform.parent, true);

			initShift[0] = 0;
			initShift[1] = 0;
			SetLocation(btnXLocation);
			SetToolTip(btnToolTip);
			SetAction(btnAction);

			if (btnBackgroundColor != null)
				SetBackgroundColor((Color)btnBackgroundColor);
			else
				OrigBackground = button.GetComponent<Image>().color;

			if (ImageURL != null)
				LoadSprite(ImageURL);

			SetActive(true);
		}

		private void InitButton(float btnXLocation, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, byte[] ImageData = null)
		{
			btnType = "QMTabButton";
			button = UnityEngine.Object.Instantiate(QuickMenuStuff.TabButtonTemplate(), QuickMenuStuff.TabButtonTemplate().transform.parent, true);

			initShift[0] = 0;
			initShift[1] = 0;
			SetLocation(btnXLocation);
			SetToolTip(btnToolTip);
			SetAction(btnAction);

			if (btnBackgroundColor != null)
				SetBackgroundColor((Color)btnBackgroundColor);
			else
				OrigBackground = button.GetComponent<Image>().color;

			if (ImageData != null)
				LoadSprite(ImageData);

			SetActive(true);
		}

		public void SetAction(Action buttonAction)
		{
			button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
			if (buttonAction != null)
				button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
		}

		public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
		{
			//button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
			if (save)
				OrigBackground = buttonBackgroundColor;
			button.GetComponentInChildren<Button>().colors = new ColorBlock()
			{
				colorMultiplier = 1f,
				disabledColor = Color.grey,
				highlightedColor = buttonBackgroundColor * 1.5f,
				normalColor = buttonBackgroundColor / 1.5f,
				pressedColor = Color.grey * 1.5f
			};
		}
	}
}