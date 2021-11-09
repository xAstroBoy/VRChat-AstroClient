namespace AstroButtonAPI
{
    using System;
    using System.Collections.Generic;
    using QuickMenuAPI;
    using UnityEngine;
    using UnityEngine.UI;

    internal class QMScrollMenu
    {
        internal class ScrollObject
        {
            internal QMButtonBase ButtonBase;
            internal int Index;
        }

        internal QMNestedButton BaseMenu;
        internal QMSingleButton BackButton;
        internal QMSingleButton IndexButton;
        internal List<ScrollObject> QMButtons = new List<ScrollObject>();
        private int Posx = 1;
        private int Posy = 0;
        private int Pos = 0;
        private int Index = 0;
        private Action<QMScrollMenu> OpenAction;
        internal int currentMenuIndex = 0;

        internal bool ShouldChangePos = true;
        internal bool AllowOverStepping = false;
        internal bool IgnoreEverything = false;

        internal QMScrollMenu(QMNestedButton Parent, float btnXLocation, float btnYLocation, Action<QMScrollMenu> Open, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            BaseMenu = new QMNestedButton(Parent, btnXLocation, btnYLocation, btnText, Title, btnToolTip, TextColor, LoadSprite);
            SetAction(Open);
            IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
            IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
            IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
            BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
            {
                ShowMenu(currentMenuIndex - 1);
            }, "Go Back");
        }

        internal QMScrollMenu(QMNestedButton basemenu)
        {
            BaseMenu = basemenu;
            IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
            IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
            IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
            BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
            {
                ShowMenu(currentMenuIndex - 1);
            }, "Go Back");
        }

        internal void ShowMenu(int MenuIndex)
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

        internal void SetAction(Action<QMScrollMenu> Open, bool shouldClear = true)
        {
            try
            {
                OpenAction = Open;
                //  SetAction
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

        internal void Refresh()
        {
            Clear();
            OpenAction?.Invoke(this);
            QuickMenuStuff.ShowQuickmenuPage(BaseMenu.GetMenuName());
            ShowMenu(0);
        }

        internal void DestroyMe()
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
        }

        internal void Clear()
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

        internal void Add(QMButtonBase Button)
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

        internal void Add(QMButtonBase Button, int Page, float POSX = 0, float POSY = 0)
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