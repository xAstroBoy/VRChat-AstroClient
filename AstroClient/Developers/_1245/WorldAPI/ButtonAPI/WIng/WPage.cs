using System;
using AstroClient._1245.WorldAPI.ButtonAPI.WIng.Buttons;
using AstroClient.xAstroBoy.AstroButtonAPI.PageGenerators;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using static AstroClient._1245.WorldAPI.ButtonAPI.APIBase;
using Object = UnityEngine.Object;

namespace AstroClient._1245.WorldAPI.ButtonAPI.WIng;

internal class WPage
{
    internal WingSide wingSide { get; set; }
    internal UIPage page  { get; set; }
    internal GameObject gameObject  { get; set; }
    internal Transform transform  { get; set; }
    internal Transform menuContents  { get; set; }

    internal WPage(string pageName, WingSide WingSide)
    {
        wingSide = WingSide;

        gameObject = Object.Instantiate(APIBase.WPageTemplate, APIBase.WPageTemplate.transform.parent);
        transform = gameObject.transform;
        gameObject.name = pageName;
        page = gameObject.GetComponent<UIPage>();
        page.field_Public_String_0 = pageName;
        page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
        page.field_Private_List_1_UIPage_0.Add(page);
        menuContents = gameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
        menuContents.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = true;
        menuContents.DestroyChildren();
        gameObject.transform.Find("WngHeader_H1/LeftItemContainer/Text_QM_H2 (1)").GetComponent<TextMeshProUGUI>().text = pageName;
        if (wingSide == WingSide.Left)
            QuickMenuTools.WingMenuStateControllerLeft.AddPage(page);
        else
            QuickMenuTools.WingMenuStateControllerRight.AddPage(page);

        page.transform.Find("ScrollRect").GetComponent<VRC.UI.Elements.Controls.ScrollRectEx>().field_Public_Boolean_0 = true;
        page.GetComponent<Canvas>().enabled = true;
        page.GetComponent<CanvasGroup>().enabled = true;
        page.GetComponent<UIPage>().enabled = true;
        page.GetComponent<GraphicRaycaster>().enabled = true;
        gameObject.SetActive(false);  // Set off as enabling the comps above makes the page visable, but we dont want that so we set it off, once we go into and out of the menu it syncs
    }

    internal void OpenMenu()
    {
        gameObject.SetActive(true);
        if (wingSide == WingSide.Left)
            QuickMenuTools.Wing_Left.ShowWingPage(page.field_Public_String_0);
        else QuickMenuTools.Wing_Right.ShowWingPage(page.field_Public_String_0);
    }

    internal WButton AddButton(string buttonName, Action listener, string toolTip, Sprite Icon = null, bool SubMenu = false, string Header = "") => new(this, buttonName, listener, toolTip, Icon, SubMenu, Header);

    internal WToggle AddToggle(string text, Action<bool> listener, bool DefaultState = false,
            string OffTooltip = null, string OnToolTip = null,
            Sprite onimage = null, Sprite offimage = null) => new(this, text, listener, DefaultState, OffTooltip, OnToolTip, onimage, offimage);
}