using System;
using AstroClient;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;
using Object = UnityEngine.Object;
using AstroClient.xAstroBoy.Utility;

namespace WorldAPI.ButtonAPI.MM;

internal class MMTab
{
    internal MenuTab menuTab { get; set; }
    internal GameObject gameObject { get; set; }
    internal static Action OnClick { get; set; }
    internal MMPage Menu { get; set; }

    internal MMTab(MMPage page, string toolTip = "", Sprite sprite = null)
    {
        if (!APIBase.IsReady()) throw new Exception();
        if (APIBase.MMMTabTemplate == null)
        {
            Log.Error("Fatal Error: MMMpageTemplate Is Null!");
            return;
        }
        gameObject = Object.Instantiate(APIBase.MMMTabTemplate, APIBase.MMMTabTemplate.transform.parent);
        menuTab = gameObject.GetComponent<MenuTab>();
        menuTab.field_Private_AnalyticsController_0 = null;
        menuTab.field_Public_Int32_0 = page.Pageint - 1;
        Menu = page;
        //menuTab.field_Public_String_0 = page.MenuName; // Dont Do this
        if (sprite != null)
        {
            gameObject.transform.Find("Icon").GetComponent<UIWidgets.ImageAdvanced>().sprite = sprite;
            gameObject.transform.Find("Icon").GetComponent<UIWidgets.ImageAdvanced>().overrideSprite = sprite;
        }
        else gameObject.transform.Find("Icon").gameObject.active = false;

        gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = toolTip;
        gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = toolTip;

        gameObject.GetOrAddComponent<StyleElement>().field_Private_Selectable_0 = gameObject.GetOrAddComponent<Button>();
        gameObject.GetOrAddComponent<Button>().onClick.AddListener(new Action(() => Menu.gameObject.SetActive(true)));
    }
}