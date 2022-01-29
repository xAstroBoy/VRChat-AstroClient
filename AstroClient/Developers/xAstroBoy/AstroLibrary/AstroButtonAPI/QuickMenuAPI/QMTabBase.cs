﻿namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using CheetoLibrary.Utility;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;

    internal class QMTabBase
    {
        protected string btnQMLoc;
        protected string btnTag;
        protected string btnType;
        protected GameObject button;
        protected GameObject Icon;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;

        internal GameObject GetGameObject()
        {
            return button;
        }

        internal GameObject GetIcon()
        {
            if (Icon == null)
                Icon = button.transform.Find("Icon").gameObject;
            return Icon;
        }

        internal void SetActive(bool isActive)
        {
            button.gameObject.SetActive(isActive);
        }

        internal void SetIntractable(bool isIntractable)
        {
            if (isIntractable)
                SetBackgroundColor(OrigBackground);
            else
                SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1));
            button.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        internal void SetLocation(float buttonXLoc)
        {
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (210 * (buttonXLoc + initShift[0]));
            //button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));
            button.transform.SetSiblingIndex((int)buttonXLoc);
            btnTag = "(" + buttonXLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void SetToolTip(string buttonToolTip)
        {
            button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;
            button.GetComponent<UiTooltip>().field_Public_String_1 = buttonToolTip;
        }

        internal void DestroyMe()
        {
            button.DestroyMeLocal(true);
        }

        internal void LoadSprite(Sprite sprite)
        {
            var image = GetIcon().GetComponent<Image>();
            image.sprite = sprite;
            image.color = Color.white;
        }

        internal void LoadSprite(byte[] data)
        {
            var image = GetIcon().GetComponent<Image>();
            var texture = CheetoUtils.LoadPNG(data);
            image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image.color = Color.white;
        }

        internal void SetParent(QMNestedButton Parent)
        {
            button.transform.SetParent(QuickMenuTools.QuickMenuTransform.Find(Parent.GetMenuName()));
        }

        internal void SetParent(Transform Parent)
        {
            button.transform.SetParent(Parent);
        }

        internal virtual void SetBackgroundColor(Color buttonBackgroundColor)
        {
        }
    }
}