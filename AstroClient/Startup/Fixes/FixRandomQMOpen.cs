using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using UnityEngine;
using VRC.UI.Elements;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Reflection;
    
    using Cheetos;
    using HarmonyLib;
    using MelonLoader;
    using Tools.Extensions;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class FixRandomQMOpen : AstroEvents
    {

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(FixRandomQMOpen).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(MenuStateController).GetMethod(nameof(MenuStateController.Method_Public_Void_String_Boolean_Boolean_2)), GetPatch(nameof(BlockAndReport)));

        }


        private static bool BlockAndReport(string __0, bool __1, bool __2)
        {
            if (IsVRChatPage(__0))
            {
                return true;
            }
            return false;
        }



        private static bool IsVRChatPage(string pagename)
        {
            switch (pagename)
            {
                case "Modal_ConfirmDialog":
                case "Modal_HoveredUser":
                case "Modal_QM_ShowAvatarInteractionInfo":
                case "Modal_ConfirmListDialog":
                case "Modal_QM_ViewPhoto":
                case "Modal_QM_MoreActions":
                case "Modal_QM_AddAvatarToFavorites":
                case "Modal_AddWorldToPlaylist":
                case "Modal_AddMessage":
                case "Menu_QM_AvatarDetails":
                case "Menu_ChangeAudioInputDevice":
                case "Menu_UserIconCamera":
                case "Menu_QM_GiftVRCPlus":
                case "Menu_QM_Report_Details":
                case "Menu_QM_Report_Issue":
                case "Menu_QM_Gallery":
                case "Menu_InviteResponse":
                case "Menu_SelectedUser_Remote":
                case "Menu_SelectedUser_Local":
                case "Menu_DevTools":
                case "Menu_QM_Emojis":
                case "Menu_AudioSettings":
                case "Menu_Settings":
                case "Menu_Here":
                case "Menu_Camera":
                case "Menu_Notifications":
                case "Menu_Dashboard":
                case "Wing_Menu_Worlds_Filter":
                case "Wing_Menu_Worlds":

                    return true;


                default:
                    return false;
            }



        }
    }
}