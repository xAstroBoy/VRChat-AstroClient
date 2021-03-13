using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace AstroClient.ButtonShortcut
{
    public static class CheatsShortcutButton
    {

        private static QMSingleButton WorldCheatsShortcut;


        public static void Init_Cheats_ShortcutBtn(float x, float y, bool btnHalf)
        {
           WorldCheatsShortcut = new QMSingleButton("ShortcutMenu", x, y, "Cheats Shortcut", null, "Cheats Shortcut", null, null, btnHalf);
            
        }

        public static void SetButtonText(string ButtonText)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setButtonText(ButtonText);
                WorldCheatsShortcut.setToolTip(ButtonText + " Shortcut.");
            }
        }
        public static void SetButtonText(string ButtonText, string ButtonToolTip)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setButtonText(ButtonText);
                WorldCheatsShortcut.setToolTip(ButtonToolTip + " Shortcut.");
            }
        }

        public static void SetButtonColor(Color color)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setTextColor(color);
            }
        }

        public static void SetButtonShortcut(QMNestedButton btn)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setAction(new Action(() => { btn.getMainButton().getGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }


        public static void SetButtonShortcut(QMSingleButton btn)
        {
            if(WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setAction(new Action(() => { btn.getGameObject().GetComponent<Button>().onClick.Invoke(); }));
            }
        }



        public static void ClearButtonAction()
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setAction(null);
            }
        }

        public static void SetActive(bool isActive)
        {
            if (WorldCheatsShortcut != null)
            {
                WorldCheatsShortcut.setActive(isActive);
            }
        }


    }
}
