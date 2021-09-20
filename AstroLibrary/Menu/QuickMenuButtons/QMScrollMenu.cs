namespace RubyButtonAPI
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Button = UnityEngine.UI.Button;

    public class QMScrollMenu
    {
        public class ScrollObject
        {
            public QMButtonBase ButtonBase;
            public int Index;
        }

        public QMNestedButton BaseMenu;
        public QMSingleButton NextButton;
        public QMSingleButton BackButton;
        public QMSingleButton IndexButton;
        public List<ScrollObject> QMButtons = new List<ScrollObject>();
        private int Posx = 1;
        private int Posy = 0;
        private int Pos = 0;
        private int Index = 0;
        private Action<QMScrollMenu> OpenAction;
        public int currentMenuIndex = 0;

        public bool ShouldChangePos = true;
        public bool AllowOverStepping = false;
        public bool IgnoreEverything = false;

        public QMScrollMenu(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action<QMScrollMenu> MenuOpenAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            BaseMenu = new QMNestedButton(btnMenu, btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetAction(MenuOpenAction);
            IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
            IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
            IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
            BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
            {
                ShowMenu(currentMenuIndex - 1);
            }, "Go Back", null, null, true);
            NextButton = new QMSingleButton(BaseMenu, 5, 1.5f, "Next", delegate
            {
                ShowMenu(currentMenuIndex + 1);
            }, "Go Next", null, null, true);
        }

        public QMScrollMenu(QMNestedButton basemenu)
        {
            BaseMenu = basemenu;
            IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
            IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
            IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
            BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
            {
                ShowMenu(currentMenuIndex - 1);
            }, "Go Back", null, null, true);
            NextButton = new QMSingleButton(BaseMenu, 5, 1.5f, "Next", delegate
            {
                ShowMenu(currentMenuIndex + 1);
            }, "Go Next", null, null, true);
        }

        public void ShowMenu(int MenuIndex)
        {
            if (!AllowOverStepping && (MenuIndex < 0 || MenuIndex > Index))
                return;

            foreach (var item in QMButtons)
            {
                if (item.Index == MenuIndex)
                    item.ButtonBase?.SetActive(true);
                else
                    item.ButtonBase?.SetActive(false);
            }
            currentMenuIndex = MenuIndex;
            IndexButton.SetButtonText("Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString());
        }

        public void SetAction(Action<QMScrollMenu> Open, bool shouldClear = true)
        {
            try
            {
                OpenAction = Open;
                BaseMenu.GetMainButton().SetAction(new Action(() =>
                {
                    if (shouldClear) Clear();
                    OpenAction.Invoke(this);
                    QuickMenuStuff.ShowQuickmenuPage(BaseMenu.GetMenuName());
                    ShowMenu(0);
                }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Refresh()
        {
            Clear();
            OpenAction?.Invoke(this);
            QuickMenuStuff.ShowQuickmenuPage(BaseMenu.GetMenuName());
            ShowMenu(0);
        }

        public void DestroyMe()
        {
            foreach (var item in QMButtons)
            {
                UnityEngine.Object.Destroy(item.ButtonBase.GetGameObject());
            }
            QMButtons.Clear();
            if (BaseMenu.GetBackButton() != null)
                BaseMenu.GetBackButton().DestroyMe();
            if (IndexButton != null)
                IndexButton.DestroyMe();
            if (BackButton != null)
                BackButton.DestroyMe();
            if (NextButton != null)
                NextButton.DestroyMe();
        }

        public void Clear()
        {
            try
            {
                foreach (var item in QMButtons)
                {
                    UnityEngine.Object.Destroy(item.ButtonBase.GetGameObject());
                }
                QMButtons.Clear();
                Posx = 1;
                Posy = 0;
                Pos = 0;
                Index = 0;
                currentMenuIndex = 0;
            }
            catch { }
        }

        public void Add(QMButtonBase Button)
        {
            if (!IgnoreEverything)
            {
                if (Posx < 6)
                {
                    Posx++;
                }
                if (Posx > 5 && Posy < 3)
                {
                    Posx = 2;
                    Posy++;
                }
                if (Pos == 12)
                {
                    Posx = 2;
                    Posy = 0;
                    Pos = 0;
                    Index++;
                }
            }
            if (!IgnoreEverything)
                Pos++;

            if (ShouldChangePos)
                Button.SetLocation(Posx, Posy);
            Button.SetActive(false);
            QMButtons.Add(new ScrollObject()
            {
                ButtonBase = Button,
                Index = Index
            });
        }

        public void Add(QMButtonBase Button, int Page, float POSX = 0, float POSY = 0)
        {
            Button.SetLocation(POSX, POSY);
            Button.SetActive(false);
            QMButtons.Add(new ScrollObject()
            {
                ButtonBase = Button,
                Index = Page
            });
            if (!IgnoreEverything)
            {
                if (Page > Index)
                {
                    Index = Page;
                }
            }
        }
    }
}