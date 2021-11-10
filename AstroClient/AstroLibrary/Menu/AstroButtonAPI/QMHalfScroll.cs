namespace AstroButtonAPI
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    // TODO : ADD TWO ACTIONS THAT CAN RUN WHEN THE SCROLL IS OPEN OR CLOSED.
    internal class QMHalfScroll
    {
        internal class ScrollObject
        {
            internal QMButtonBase ButtonBase;
            internal int Index;
        }

        internal QMNestedButton BaseMenu;
        internal QMSingleButton NextButton;
        internal QMSingleButton BackButton;
        internal QMSingleButton IndexButton;
        internal List<ScrollObject> QMButtons = new List<ScrollObject>();
        private float Posx = 1;
        private float Posy = 0f;
        private int Pos = 0;
        private int Index = 0;
        private Action<QMHalfScroll> OpenAction;
        internal int currentMenuIndex = 0;

        internal bool ShouldChangePos = true;
        internal bool AllowOverStepping = false;
        internal bool IgnoreEverything = false;

        internal QMHalfScroll(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action<QMHalfScroll> MenuOpenAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            BaseMenu = new QMNestedButton(btnMenu, btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetAction(MenuOpenAction);
            IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "", null, null, false);
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

        internal QMHalfScroll(QMNestedButton basemenu)
        {
            BaseMenu = basemenu;
            IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "", null, null, false);
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

        internal void SetAction(Action<QMHalfScroll> Open, bool shouldClear = true)
        {
            try
            {
                OpenAction = Open;
                BaseMenu.GetMainButton().SetAction(new Action(() =>
                {
                    if (shouldClear) Clear();
                    OpenAction.Invoke(this);
                    QuickMenuTools.ShowQuickmenuPage(BaseMenu.GetMenuName());
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
            QuickMenuTools.ShowQuickmenuPage(BaseMenu.GetMenuName());
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
                UnityEngine.Object.Destroy(BaseMenu.GetBackButton());
            if (IndexButton != null)
                IndexButton.DestroyMe();
            if (BackButton != null)
                BackButton.DestroyMe();
            if (NextButton != null)
                NextButton.DestroyMe();
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
                Posx = 1f;
                Posy = 0f;
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
                if (Posx > 5 && Posy < 2.5)
                {
                    Posx = 2;
                    Posy += 0.5f;
                }
                if (Pos == 24)
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

        internal void AddExtraButton(QMButtonBase Button)
        {
            QMButtons.Add(new ScrollObject()
            {
                ButtonBase = Button,
                Index = Index
            });
        }

        internal void Add(QMButtonBase Button, int Page, bool ShouldChangePos, float POSX = 0f, float POSY = 0f)
        {
            if (ShouldChangePos)
            {
                Button.SetLocation(POSX, POSY);
            }
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

        internal void Add(QMButtonBase Button, int Page, float POSX = 0, float POSY = 0)
        {
            if (ShouldChangePos)
                Button.SetLocation(Posx, Posy);
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