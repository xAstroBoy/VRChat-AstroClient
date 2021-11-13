namespace AstroClient
{
    using AstroButtonAPI;
    using System.Collections.Generic;
    using VRC.UI.Elements;

    internal class AudioSourceSubMenu : GameEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMToggleButton> GeneratedButtons = new List<QMToggleButton>();
        private static bool isOpen;

        internal override void OnRoomLeft()
        {
            DestroyGeneratedButtons();
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "AudioSources", "Toggle AudioSources", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                if (WingMenu != null)
                {
                    WingMenu.SetActive(true);
                    WingMenu.ShowLeftWingPage();
                }
                Regenerate();
            });
            InitWingPage();
        }

        private static void Regenerate()
        {
            foreach (var obj in WorldUtils_Old.Get_AudioSources())
            {
                var btn = new QMToggleButton(CurrentScrollMenu, $"Toggle {obj.name}", null, $"Toggle {obj.name}", null, $"Toggle {obj.name}", null, null, $"Toggle AudioSource {obj.name}", obj.enabled);
                btn.SetAction(() =>
                {
                    obj.enabled = true;
                    btn.SetToggleState(obj.enabled);
                }, () =>
                {
                    obj.enabled = false;
                    btn.SetToggleState(obj.enabled);
                });

                //var listener = obj.gameObject.AddComponent<ScrollMenuListener_AudioSource>();
                //if (listener != null)
                //{
                //    listener.Assignedbtn = btn;
                //    listener.source = obj;
                //    listener.Lock = false;
                //}
                GeneratedButtons.Add(btn);
            }
        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowLeftWingPage();
            }
        }

        private static void OnCloseMenu()
        {
            isOpen = false;
            WingMenu.SetActive(false);
            WingMenu.ClickBackButton();
            DestroyGeneratedButtons();
        }

        private static void DestroyGeneratedButtons()
        {
            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (!isOpen) return;
            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1010, true, "AudioSources", "AudioSources Control");
            new QMWingSingleButton(WingMenu, "Refresh", () => { DestroyGeneratedButtons(); Regenerate(); }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}