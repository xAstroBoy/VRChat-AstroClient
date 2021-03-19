using AstroClient;
using AstroClient.ConsoleUtils;
using DayClientML2.Utility.Extensions;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace DayClientML2.Utility.ButtonApi
{
    internal class VRCMenu
    {
        public VRCMenu(Transform Parent, MenuButtonType buttonType, string name, float x, float y, Action OnPageShown = null, Action OnPageClose = null)
        {
            try
            {
                Instance = this;
                GameObject SettingsPage = GameObject.Find("UserInterface/MenuContent/Screens/Settings");
                Page = GameObject.Instantiate(SettingsPage, SettingsPage.transform.parent);
                Page.name = "Menu_" + name + BuildInfo.Name;
                //UnityEngine.Object.Destroy(Page.GetComponent<PageAvatar>());
                //VRCUiPage = Page.AddComponent<VRCUiPage>();
                VRCUiPage = Page.GetComponent<VRCUiPageSettings>();
                Page.GetComponent<VRCUiPageSettings>().enabled = true;
                //VRCUiPage.field_Protected_CanvasGroup_0 = Page.GetComponent<CanvasGroup>();
                //VRCUiPage.screenType = "SCREEN";
                VRCUiPage.field_Public_Action_0 = new Action(() =>
                {
                    Page.active = true;
                    Page.SetActive(true);
                    Page.GetComponent<VRCUiPageSettings>().enabled = true;
                    Page.GetComponent<VRCUiPageSettings>().field_Protected_Boolean_0 = true;
                    VRCUiPage.enabled = true;
                    VRCUiPage.field_Protected_Boolean_0 = true;
                    OnPageShown?.Invoke();
                    //VRCUiCursorManager.Method_Public_Static_Void_Boolean_0(true);
                });
                VRCUiPage.field_Public_Action_1 = new Action(() =>
                {
                });
                Il2CppSystem.Collections.IEnumerator enumerator = Page.transform.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Il2CppSystem.Object obj = enumerator.Current;
                    Transform btnEnum = obj.Cast<Transform>();
                    if (!btnEnum.name.ToLower().Contains("depth"))
                        UnityEngine.Object.Destroy(btnEnum.gameObject);
                }
            }
            catch (Exception e) { ModConsole.Error($"VRCMenu Error: {e}"); }
            try
            {
                //ScreenPath = MiscUtility.GetPath(Page);
                MenuButton = new MenuButton(Parent, buttonType, name, x, y, new Action(() =>
                {
                    if (Instance.VRCUiPage != null)
                    {
                        Utils.VRCUiManager.ShowScreen(Instance.VRCUiPage);
                    }
                    else
                    {
                        Console.WriteLine("Day Your Fucked mate");
                    }
                }));
            }
            catch (Exception e) { ModConsole.Error($"VRCMenu 2 Error: {e}"); }
        }

        public VRCMenu(string name, Action OnPageShown = null, Action OnPageClose = null)
        {
            try
            {
                Instance = this;
                GameObject SettingsPage = GameObject.Find("UserInterface/MenuContent/Screens/Settings");
                Page = GameObject.Instantiate(SettingsPage, SettingsPage.transform.parent);
                Page.name = "Menu_" + name + BuildInfo.Name;
                //UnityEngine.Object.Destroy(Page.GetComponent<PageAvatar>());
                //VRCUiPage = Page.AddComponent<VRCUiPage>();
                VRCUiPage = Page.GetComponent<VRCUiPageSettings>();
                Page.GetComponent<VRCUiPageSettings>().enabled = true;
                //VRCUiPage.field_Protected_CanvasGroup_0 = Page.GetComponent<CanvasGroup>();
                //VRCUiPage.screenType = "SCREEN";
                VRCUiPage.field_Public_Action_0 = new Action(() =>
                {
                    Page.active = true;
                    Page.SetActive(true);
                    Page.GetComponent<VRCUiPageSettings>().enabled = true;
                    Page.GetComponent<VRCUiPageSettings>().field_Protected_Boolean_0 = true;
                    VRCUiPage.enabled = true;
                    VRCUiPage.field_Protected_Boolean_0 = true;
                    OnPageShown?.Invoke();
                    //VRCUiCursorManager.Method_Public_Static_Void_Boolean_0(true);
                });
                VRCUiPage.field_Public_Action_1 = new Action(() =>
                {
                });
                Il2CppSystem.Collections.IEnumerator enumerator = Page.transform.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Il2CppSystem.Object obj = enumerator.Current;
                    Transform btnEnum = obj.Cast<Transform>();
                    if (!btnEnum.name.ToLower().Contains("depth"))
                        UnityEngine.Object.Destroy(btnEnum.gameObject);
                }
            }
            catch (Exception e) { ModConsole.Error($"VRCMenu Error: {e}"); }
        }

        public string ScreenPath { get; set; }
        public MenuButton MenuButton { get; set; }
        public GameObject Page { get; set; }
        public VRCUiPage VRCUiPage { get; set; }
        public VRCMenu Instance { get; set; }
    }

    internal class VRCMenuPanel
    {
        public VRCMenuPanel(Transform transform, string text, float PosX, float PosY, float SizeX, float SizeY)
        {
            try
            {
                Panel = GameObject.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/AudioDevicePanel"), transform);
                Panel.name = "Panel_" + text + BuildInfo.Name;
                Panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(PosX, PosY);
                Panel.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeX, SizeY);
                TitleText = Panel.transform.Find("TitleText").gameObject;
                TitleText.GetComponent<Text>().text = text;
                TitleText.name = $"TitleText_{text}";
                Il2CppSystem.Collections.IEnumerator enumerator = Panel.transform.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Il2CppSystem.Object obj = enumerator.Current;
                    Transform btnEnum = obj.Cast<Transform>();
                    if (btnEnum != null && !MiscUtility.GetPath(btnEnum.gameObject).Contains("TitleText") && !MiscUtility.GetPath(btnEnum.gameObject).Contains("Panel_Header"))
                    {
                        UnityEngine.Object.Destroy(btnEnum.gameObject);
                    }
                }
                //  UnityEngine.Object.Destroy(Panel.GetComponent<UIDeviceSelector>());
            }
            catch (Exception e) { ModConsole.Error($"VRCPanel Error: {e}"); }
        }

        //unused -- Might be used in the future for closing content of a panel
        public VRCMenuPanel(Transform transform, string text, float PosX, float PosY, float SizeX, float SizeY, bool DefaultActive)
        {
            try
            {
                Panel = GameObject.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/AudioDevicePanel"), transform);
                Panel.name = "VRCMenuPanel_" + text + BuildInfo.Name;
                Panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(PosX, PosY);
                Panel.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeX, SizeY);
                TitleText = Panel.transform.Find("TitleText").gameObject;
                TitleText.GetComponent<Text>().text = text;
                TitleText.name = $"TitleText_{text}";
                DefaultActiveToggle = new MenuCheckbox(TitleText.transform, "Expand", 150f, -25f, true, new Action<bool>((value) =>
                {
                    for (int i = 0; i < Panel.transform.childCount; i++)
                    {
                        var child = Panel.transform.GetChild(i);
                        if (child != null && !MiscUtility.GetPath(child.gameObject).Contains("TitleText") && !MiscUtility.GetPath(child.gameObject).Contains("Panel_Header"))
                        {
                            child.gameObject.SetActive(value);
                        }
                    }
                })); //Replace Action with if child contents.isActive then isActive false;
                Il2CppSystem.Collections.IEnumerator enumerator = Panel.transform.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Il2CppSystem.Object obj = enumerator.Current;
                    Transform btnEnum = obj.Cast<Transform>();
                    if (btnEnum != null && !MiscUtility.GetPath(btnEnum.gameObject).Contains("TitleText") && !MiscUtility.GetPath(btnEnum.gameObject).Contains("Panel_Header"))
                    {
                        UnityEngine.Object.Destroy(btnEnum.gameObject);
                    }
                }
                //UnityEngine.Object.Destroy(Panel.GetComponent<UIDeviceSelector>());
            }
            catch (Exception e) { ModConsole.Error($"VRCPanel Error: {e}"); }
        }

        public static MenuCheckbox DefaultActiveToggle;
        public bool DefaultActive;
        public GameObject Panel;
        public GameObject TitleText;
    }
}

//
//                GameObject DefaultActiveToggle = new GameObject();
//                DefaultActiveToggle.transform.SetParent(Panel.transform);