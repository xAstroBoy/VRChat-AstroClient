using System;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace AstroClient._1245.WorldAPI.ButtonAPI.WIng.Controls;

internal class WingTglControls : Root
{
    internal Action<bool> Listener { get; set; }
    internal Image OnImage { get; set; }
    internal Image OffImage { get; set; }

    internal (Sprite, Sprite) SetImages(Sprite onSprite = null, Sprite offSprite = null)
    {
        OffImage.sprite = offSprite;
        OnImage.sprite = onSprite;
        return (onSprite, offSprite);
    }

    internal (Sprite, Sprite) SetImages(bool checkForNull, Sprite onSprite = null, Sprite offSprite = null)
    {
        if (checkForNull)
        {
            if (offSprite == null) offSprite = APIBase.OffSprite;
            if (onSprite == null) onSprite = APIBase.OnSprite;
        }
        if (offSprite != null)
            OffImage.sprite = offSprite;
        if (onSprite != null)
            OnImage.sprite = onSprite;
        return (onSprite, offSprite);
    }

    internal string SetToolTip(string tip)
    {
        gameObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = tip;
        gameObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tip;
        return tip;
    }
}