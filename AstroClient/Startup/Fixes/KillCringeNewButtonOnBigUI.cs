using AstroClient.ClientActions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using UnityEngine;

namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class KillCringeNewButtonOnBigUI : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnBigMenuOpen += PatchBigMenu;
        }

        private void PatchBigMenu()
        {
            CleanPageAndHelpInfoNotify();
            ClientEventActions.OnBigMenuOpen -= PatchBigMenu;
        }

        private static Transform _PageHelpAndInfo;
        internal static Transform PageHelpAndInfo
        {
            get
            {
                if (_PageHelpAndInfo == null) _PageHelpAndInfo = QuickMenuTools.Canvas_MainMenu.FindObject("Container/PageButtons/HorizontalLayoutGroup/Page_Help&Info");
                return _PageHelpAndInfo;
            }
        }


        internal void CleanPageAndHelpInfoNotify()
        {
            // Fuck off VRChat
            if(PageHelpAndInfo != null)
            {
                var NewIcon = PageHelpAndInfo.FindObject("Tab_Badge");
                if (NewIcon != null)
                {
                    NewIcon.gameObject.SetActive(false);
                }
                    
            }

        }

    }
}
