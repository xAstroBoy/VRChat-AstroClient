// Credits to Blaze and DayOfThePlay

namespace AstroLibrary.Utility
{
    using AstroButtonAPI;
    using Transmtn.DTO.Notifications;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Menus;

    public static class QuickMenuUtils
    {
        public static QuickMenu QuickMenu => QuickMenuStuff.GetQuickMenuInstance();



        #region SelectPlayer


        public static void OpenUserInQuickMenu(this APIUser user)
        {
            UiManager.OpenUserInQuickMenu(user);
        }
        public static void OpenUserInUserInfoPage(this APIUser user)
        {
            UiManager.OpenUserInUserInfoPage(user.ToIUser());
        }
        public static void OpenUserInQuickMenu(this Player user)
        {
            UiManager.OpenUserInQuickMenu(user.GetAPIUser());
        }
        public static void OpenUserInUserInfoPage(this Player user)
        {
            UiManager.OpenUserInUserInfoPage(user.GetAPIUser().ToIUser());
        }

        #endregion

        #region GetSelected

        public static Player SelectedPlayer => QuickMenuStuff.GetSelectedUserQMInstance().GetSelectedPlayer();

        public static APIUser SelectedUser => QuickMenuStuff.GetSelectedUserQMInstance().GetSelectedApiUser();

        public static VRCPlayer SelectedVRCPlayer => QuickMenuStuff.GetSelectedUserQMInstance().GetSelectedPlayer().GetVRCPlayer();

        #endregion

        //public static void OpenQM()
        //{
        //    QuickMenu.prop_QuickMenu_0.Method_Private_Void_Boolean_0(true);
        //}

        //public static void CloseQM()
        //{
        //    QuickMenu.prop_QuickMenu_0.Method_Private_Void_Boolean_0(false);
        //}


        //public static Notification Notification(this QuickMenu instance)
        //{
        //    return instance.field_Private_Notification_0;
        //}

        public static void SetQuickMenuBackground(this QuickMenu instance, float x, float y, bool doublesided = true)
        {
            Transform transform = QuickMenu.transform.Find("QuickMenu_NewElements/_Background");
            RectTransform rectTransform = transform.GetComponent<RectTransform>();
            if (doublesided)
                rectTransform.sizeDelta += new Vector2(x * 840, y * 840);
            else
            {
                rectTransform.sizeDelta += new Vector2(x * 420, y * 420);
                rectTransform.anchoredPosition += new Vector2(-x * 210, -y * 210);
            }
        }

        #region Collider
        public static void ResizeCollider(Vector3 size)
        {
            QuickMenu.GetComponent<BoxCollider>().size = size;
        }

        public static void SetQuickMenuCollider(this QuickMenu instance, float x, float y, bool doublesided = true)
        {
            var Collider = QuickMenu.GetComponent<BoxCollider>();
            if (doublesided)
                Collider.size += new Vector3(x * 840, y * 840);
            else
            {
                Collider.size += new Vector3(x * 420, y * 420);
                Collider.center += new Vector3(-x * 210, -y * 210);
            }
        }

        public static void ResetCollider()
        {
            QuickMenu.GetComponent<BoxCollider>().size = new Vector3(2517.34f, 1671.213f, 1f);
        }
        #endregion
    }
}