﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WorldAPI.ButtonAPI.Controls
{
    internal class ToggleControl : Root
    {
        internal Toggle ToggleCompnt { get; set; }
        internal Action<bool> Listener { get; set; }
        internal Image OnImage { get; set; }
        internal Image OffImage { get; set; }

        internal bool State
        {
            get => ToggleCompnt.isOn;
            set => ToggleCompnt.isOn = value;
        }

        internal void SetAction(Action<bool> newAction) {
            ToggleCompnt.onValueChanged = new Toggle.ToggleEvent();
            ToggleCompnt.onValueChanged.AddListener(newAction);
        }

        internal (Sprite, Sprite) SetImages(Sprite onSprite = null, Sprite offSprite = null) {
            OffImage.sprite = offSprite;
            OnImage.sprite = onSprite;
            return (onSprite, offSprite);
        }

        internal void SetInteractable(bool val) => ToggleCompnt.interactable = val;

        internal (Sprite, Sprite) SetImages(bool checkForNull, Sprite onSprite = null, Sprite offSprite = null)
        {
            if (checkForNull) {
                if (onSprite == null) onSprite = APIBase.OnSprite;
                if (offSprite == null) offSprite = APIBase.OffSprite;
            }
            if (offSprite != null)
                OffImage.sprite = offSprite;
            if (onSprite != null)
                OnImage.sprite = onSprite;
            return (onSprite, offSprite);
        }

        internal void TurnHalf(Vector3 TogglePoz, float FontSize = 24f) {
            gameObject.transform.localPosition = TogglePoz;
            TurnHalf(FontSize);
        }

        internal void TurnHalf(float FontSize = 24f) {
            OnImage.transform.localScale = new Vector3(0.86f, 0.86f, 0.86f);
            OnImage.transform.localPosition = new Vector3(-52.22f, 30.18f, 0f);
            OnImage.gameObject.SetActive(ToggleCompnt.isOn);
            OffImage.transform.localScale = new Vector3(0.86f, 0.86f, 0.86f);
            OffImage.transform.localPosition = new Vector3(-52.22f, 30.18f, 0f);
            OffImage.gameObject.SetActive(!ToggleCompnt.isOn);

            TMProCompnt.fontSize = FontSize;
            TMProCompnt.transform.localPosition = new Vector3(34.42f, -22, 0);
            TMProCompnt.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 50f);
            gameObject.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -80);
            if (gameObject.transform.Find("Bg") != null)
                gameObject.transform.Find("Bg").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -80);
            ToggleCompnt.onValueChanged.AddListener(new Action<bool>((val) => { // Adding Listener, so we dont have to reset it
                OffImage.gameObject.active = !val;
                OnImage.gameObject.active = val;
            }));

        }

        internal string SetToolTip(string tip, string tip2)
        {
            gameObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = tip;
            gameObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tip2;
            return tip;
        }
    }
}
