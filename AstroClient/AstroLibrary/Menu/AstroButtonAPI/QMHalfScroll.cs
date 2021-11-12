namespace AstroButtonAPI
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Entities;
    using UnityEngine;
    using UnityEngine.UI;
    using Button = UnityEngine.UI.Button;

    internal class QMHalfScroll
    {
        internal class ScrollObject
        {
            internal QMButtonBase ButtonBase;
            internal int Index;
        }

        internal List<ScrollObject> QMButtons = new List<ScrollObject>();
        private float Posx = 0;
        private float Posy = 0;
        private int Pos = 0;
        private Action<QMHalfScroll> OpenAction;
        internal int currentMenuIndex = 0;
        internal QMNestedButton BaseMenu;
        internal bool ShouldChangePos = true;
        internal bool AllowOverStepping = false;
        internal bool IgnoreEverything = false;

        internal QMHalfScroll(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action<QMHalfScroll> MenuOpenAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            BaseMenu = new QMNestedButton(btnMenu, btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetAction(MenuOpenAction);
        }

        internal QMHalfScroll(QMNestedButton basemenu)
        {
            BaseMenu = basemenu;
        }

        internal void ShowMenu(int MenuIndex)
        {
            foreach (var item in QMButtons)
            {
                if (item.Index == MenuIndex)
                    item.ButtonBase?.SetActive(true);
                else
                    item.ButtonBase?.SetActive(false);
            }
            currentMenuIndex = MenuIndex;
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
                Posx = 0f;
                Posy = 0f;
                Pos = 0;
                currentMenuIndex = 0;
            }
            catch { }
        }

        internal void AddExtraButton(QMButtonBase Button)
        {
            QMButtons.Add(new ScrollObject()
            {
                ButtonBase = Button,
            });
        }



        internal void Add(QMButtonBase Button)
        {
            if (!IgnoreEverything)
            {
                if (Posx < 6)
                {
                    Posx++;
                }
                if (Posx > 5)
                {
                    Posx = 1;
                    Posy += 0.5f;
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
        }
    }
}