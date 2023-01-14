﻿using System;
using System.Linq;
using AstroClient;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
using WorldAPI.ButtonAPI.Extras;
using Object = UnityEngine.Object;

namespace WorldAPI.ButtonAPI.MM;

public class MMPage
{
    public UIPage page;
    public Transform menuContents;
    public int Pageint;
    public GameObject gameObject;
    public Transform transform;

    public string MenuName { get; internal set; }

    public MMPage(string menuName) {
        if (!APIBase.IsReady()) throw new Exception();
        if (APIBase.MMMpageTemplate == null) {
            Log.Error("Fatal Error: MMMpageTemplate Is Null!");
            return;
        }
        var region = 0; // Idea from https://github.com/PlagueVRC/PlagueButtonAPI/blob/new-ui/PlagueButtonAPI/PlagueButtonAPI/Pages/MenuPage.cs

        try {
            gameObject = Object.Instantiate(APIBase.MMMpageTemplate, APIBase.MMMpageTemplate.transform.parent);
            transform = gameObject.transform;
            gameObject.name = menuName;
            gameObject.transform.Find("Loading_Display").gameObject.active = false;
            MenuName = menuName;
            gameObject.transform.Find("Header_MM_UserName/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>().text = MenuName;
            page = gameObject.GetComponent<UIPage>();
            page.field_Public_String_0 = menuName;
            page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            page.field_Private_List_1_UIPage_0.Add(page);
            region++;
            QuickMenuTools.MainMenuStateController.field_Private_Dictionary_2_String_UIPage_0.Add(menuName, page);
            region++;

            var list = QuickMenuTools.MainMenuStateController.field_Public_ArrayOf_UIPage_0.ToList();
            list.Add(page);
            QuickMenuTools.MainMenuStateController.field_Public_ArrayOf_UIPage_0 = list.ToArray();
            Pageint = QuickMenuTools.MainMenuStateController.field_Public_ArrayOf_UIPage_0.Count;

            page.GetComponent<UnityEngine.Canvas>().enabled = true;
            page.GetComponent<CanvasGroup>().enabled = true;
            page.GetComponent<UIPage>().enabled = true;
            page.GetComponent<GraphicRaycaster>().enabled = true;
            page.transform.Find("ScrollRect").GetComponent<VRC.UI.Elements.Controls.ScrollRectEx>().field_Public_Boolean_0 = true;
            menuContents = gameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            Engine_ext.DestroyChildren(menuContents);
            gameObject.SetActive(false); // Set it off, as we had to enable the page comps, that shows the page, and it will be overlapping - but the controller fixes it when u select and deselect the menu
        }
        catch (Exception ex) {
            throw new Exception("Exception Caught When Making Page At Region: " + region + "\n\n" + ex);
        }
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        QuickMenuTools.MainMenuStateController.ShowTabContent(page.field_Public_String_0);
    }

}