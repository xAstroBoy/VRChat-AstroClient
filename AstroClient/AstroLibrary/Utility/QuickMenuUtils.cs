// Credits to Blaze and DayOfThePlay

namespace AstroLibrary.Utility
{
    using Transmtn.DTO.Notifications;
    using UnityEngine;
    using VRC;
    using VRC.Core;

    public static class QuickMenuUtils
    {
        public static QuickMenu QuickMenu => QuickMenu.prop_QuickMenu_0;

        #region SelectPlayer
        public static void SelectPlayer(VRCPlayer instance)
        {
            QuickMenu.SelectPlayer(instance);
        }

        public static void SelectPlayer(APIUser instance)
        {
            QuickMenu.SelectPlayer(instance);
        }

        public static void SelectPlayer(this QuickMenu instance, APIUser instance2)
        {
            instance.Method_Public_Void_Player_0(instance2.GetPlayer());
        }

        public static void SelectPlayer(this QuickMenu instance, VRCPlayer instance2)
        {
            instance.Method_Public_Void_Player_0(instance2.GetPlayer());
        }
        #endregion

        #region GetSelected

        public static Player SelectedPlayer => QuickMenu.field_Private_Player_0;

        public static APIUser SelectedUser => QuickMenu.field_Private_APIUser_0;

        public static VRCPlayer SelectedVRCPlayer => QuickMenu.field_Private_Player_0.GetVRCPlayer();

        #endregion

        public static void OpenQM()
        {
            QuickMenu.prop_QuickMenu_0.Method_Private_Void_Boolean_0(true);
        }

        public static void CloseQM()
        {
            QuickMenu.prop_QuickMenu_0.Method_Private_Void_Boolean_0(false);
        }

        #region ToggleQuickMenu
        public static void ToggleQuickMenu(bool state)
        {
            QuickMenu.ToggleQuickMenu(state);
        }

        public static void ToggleQuickMenu(this QuickMenu instance, bool state)
        {
            instance.Method_Public_Void_Boolean_0(state);
        }
        #endregion

        public static Notification Notification(this QuickMenu instance)
        {
            return instance.field_Private_Notification_0;
        }

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