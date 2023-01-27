﻿using System;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Controls;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Extras;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AstroClient._1245.WorldAPI.ButtonAPI.WIng.Controls;

internal class WingBtnControls : Root
{
    internal Transform transform { get; set; }
    internal Button ButtonCompnt { get; set; }
    internal Image ImgCompnt { get; set; }
    internal Action onClickAction { get; set; }
    internal TextMeshProUGUI HeaderTMProCompnt { get; set; }

    internal void RecolorBackGrn(string hexColor, string path = "Container/Background")
    {
        var bg = gameObject.transform.Find(path);

        if (bg.transform.parent.Find("Bg") == null)
        { // In case if we have already Colored it
            var Btn = Object.Instantiate(bg.gameObject, bg.transform.parent);
            Btn.name = "Bg";
            Btn.GetComponent<RectTransform>().SetSiblingIndex(1);
            bg.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            bg.gameObject.active = false;
        }

        Image component3 = bg.transform.parent.Find("Bg").GetComponent<Image>();
        component3.color = QMUtils.HexToColor(hexColor); // new Color(0.18f, 0.18f, 0.18f, 1f);
    }
}