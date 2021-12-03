namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using System;
    using System.Collections.Generic;
    using Tools;
    using UnityEngine;
    using Object = UnityEngine.Object;

    internal class QMHalfScroll
    {
        internal bool AllowOverStepping = false;
        internal QMNestedButton BaseMenu;
        internal int currentMenuIndex;
        internal bool IgnoreEverything = false;
        private Action<QMHalfScroll> OpenAction;
        private int Pos;
        private float Posx;
        private float Posy;

        internal List<ScrollObject> QMButtons = new();
        internal bool ShouldChangePos = true;

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
                if (item.Index == MenuIndex)
                    item.ButtonBase?.QMButtonBase_SetActive(true);
                else
                    item.ButtonBase?.QMButtonBase_SetActive(false);
            currentMenuIndex = MenuIndex;
        }

        internal void SetAction(Action<QMHalfScroll> Open, bool shouldClear = true)
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
            foreach (var item in QMButtons) Object.Destroy(item.ButtonBase.QMButtonBase_GetGameObject());
            QMButtons.Clear();
            if (BaseMenu.GetBackButton() != null)
                Object.Destroy(BaseMenu.GetBackButton());
        }

        internal void Clear()
        {
            try
            {
                foreach (var item in QMButtons) Object.Destroy(item.ButtonBase.QMButtonBase_GetGameObject());
                QMButtons.Clear();
                Posx = 0f;
                Posy = 0f;
                Pos = 0;
                currentMenuIndex = 0;
            }
            catch
            {
            }
        }

        internal void AddExtraButton(QMButtonBase Button)
        {
            QMButtons.Add(new ScrollObject
            {
                ButtonBase = Button
            });
        }

        internal void Add(QMButtonBase Button)
        {
            if (!IgnoreEverything)
            {
                if (Posx < 6) Posx++;
                if (Posx > 5)
                {
                    Posx = 1;
                    Posy += 0.5f;
                }
            }

            if (!IgnoreEverything)
                Pos++;

            if (ShouldChangePos)
                Button.QMButtonBase_SetLocation(Posx, Posy);
            Button.QMButtonBase_SetActive(false);
            QMButtons.Add(new ScrollObject
            {
                ButtonBase = Button
            });
        }

        internal void Add(QMButtonBase Button, int Page, float POSX = 0, float POSY = 0)
        {
            Button.QMButtonBase_SetLocation(POSX, POSY);
            Button.QMButtonBase_SetActive(false);
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