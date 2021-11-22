namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenu
{
    using System;
    using System.Collections.Generic;
    using Tools;
    using UnityEngine;
    using Object = UnityEngine.Object;

    internal class QMScrollMenu
    {
        internal bool AllowOverStepping = false;
        internal QMNestedButton BaseMenu;
        internal int currentMenuIndex;
        internal bool IgnoreEverything = false;
        private Action<QMScrollMenu> OpenAction;
        private int Posx;
        private int Posy;

        internal List<ScrollObject> QMButtons = new();
        internal bool ShouldChangePos = true;

        internal QMScrollMenu(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action<QMScrollMenu> MenuOpenAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            BaseMenu = new QMNestedButton(btnMenu, btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetAction(MenuOpenAction);
        }

        internal QMScrollMenu(QMNestedButton basemenu)
        {
            BaseMenu = basemenu;
        }

        internal void ShowMenu(int MenuIndex)
        {
            foreach (var item in QMButtons)
                if (item.Index == MenuIndex)
                    item.ButtonBase?.SetActive(true);
                else
                    item.ButtonBase?.SetActive(false);
            currentMenuIndex = MenuIndex;
        }

        internal void SetAction(Action<QMScrollMenu> Open, bool shouldClear = true)
        {
            try
            {
                OpenAction = Open;
                BaseMenu.GetMainButton().SetAction(() =>
                {
                    if (shouldClear) Clear();
                    OpenAction.Invoke(this);
                    QuickMenuTools.ShowQuickmenuPage(BaseMenu.GetMenuName());
                    ShowMenu(0);
                });
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
            foreach (var item in QMButtons) Object.Destroy(item.ButtonBase.GetGameObject());
            QMButtons.Clear();
            if (BaseMenu.GetBackButton() != null)
                Object.Destroy(BaseMenu.GetBackButton());
        }

        internal void Clear()
        {
            try
            {
                foreach (var item in QMButtons) Object.Destroy(item.ButtonBase.GetGameObject());
                QMButtons.Clear();
                Posx = 0;
                Posy = 0;
                currentMenuIndex = 0;
            }
            catch
            {
            }
        }

        internal void Add(QMButtonBase Button)
        {
            if (!IgnoreEverything)
            {
                if (Posx < 6) Posx++;
                if (Posx > 5)
                {
                    Posx = 0;
                    Posy++;
                }
            }

            if (ShouldChangePos)
                Button.SetLocation(Posx, Posy);
            Button.SetActive(false);
            QMButtons.Add(new ScrollObject
            {
                ButtonBase = Button
            });
        }

        internal void Add(QMButtonBase Button, int Page, float POSX = 0, float POSY = 0)
        {
            Button.SetLocation(POSX, POSY);
            Button.SetActive(false);
            QMButtons.Add(new ScrollObject
            {
                ButtonBase = Button,
                Index = Page
            });
        }

        internal class ScrollObject
        {
            internal QMButtonBase ButtonBase;
            internal int Index;
        }
    }
}