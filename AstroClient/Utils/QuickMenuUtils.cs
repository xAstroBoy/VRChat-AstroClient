using UnityEngine;
using VRC.Core;

namespace AstroClient
{
    public class QuickMenuUtils : GameEvents
    {
        public static APIUser GetSelectedUser()
        {
            return QuickMenu.prop_QuickMenu_0.prop_APIUser_0;
        }

        public static void SetQuickMenuBackGround(float x, float y)
        {
            Transform transform = QuickMenu.prop_QuickMenu_0.transform.Find("QuickMenu_NewElements/_Background");
            RectTransform rectTransform = transform.GetComponent<RectTransform>();
            rectTransform.sizeDelta += new Vector2(x * 840, y * 840);
        }

        public static void SetQuickMenuCollider(float x, float y)
        {
            QuickMenuCollider.size += new Vector3(x * 840, y * 840);
            CorrectedSize = QuickMenuCollider.size;
            HasQuickMenuBoxColliderCalled = true;
        }

        public override void OnUpdate()
        {
            if (HasQuickMenuBoxColliderCalled)
            {
                if (QuickMenuCollider.size.x != CorrectedSize.x)
                {
                    QuickMenuCollider.size = CorrectedSize;
                }

                if (QuickMenuCollider.size.y != CorrectedSize.y)
                {
                    QuickMenuCollider.size += CorrectedSize;
                }
            }
        }

        private static bool HasQuickMenuBoxColliderCalled = false;

        private static Vector3 CorrectedSize;

        private static BoxCollider _QuickMenuCollider;

        public static BoxCollider QuickMenuCollider
        {
            get
            {
                if (_QuickMenuCollider != null)
                {
                    return _QuickMenuCollider;
                }
                else
                {
                    return _QuickMenuCollider = QuickMenu.prop_QuickMenu_0.GetComponent<BoxCollider>();
                }
            }
        }
    }
}