namespace AstroClient.xAstroBoy.Utility
{
    using Tools.Extensions;
    using UnityEngine;

    public static class ComponentUtils
    {
        #region  GameObject

        public static T GetGetInChildrens_OrAddComponent<T>(this GameObject obj, bool IncludeInactive = false) where T : Component
        {
            if (obj == null) return null;
            var result = obj.GetComponent<T>();
            if (result == null)
                result = obj.GetComponentInChildren<T>(IncludeInactive);
            if (result == null)
                result = obj.AddComponent<T>();
            return result;
        }

        public static T GetGetInChildrens<T>(this GameObject obj, bool IncludeInactive = false) where T : Component
        {
            if (obj == null) return null;
            var result = obj.GetComponent<T>();
            if (result == null)
                result = obj.GetComponentInChildren<T>(IncludeInactive);
            return result;
        }

        public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
        {
            if (obj == null) return null;
            var result = obj.GetComponent<T>();
            if (result == null)
                result = obj.AddComponent<T>();
            return result;
        }
        internal static void RemoveComponent<T>(this GameObject obj) where T : Component
        {
            if (obj != null)
            {
                var existing = obj.GetComponent<T>();
                if (existing)
                {
                    existing.DestroyMeLocal();
                }
            }
        }
        internal static void RemoveComponents<T>(this GameObject obj) where T : Component
        {
            if (obj != null)
            {
                var all = obj.GetComponents<T>();
                foreach (var exist in all)
                {
                    if (exist)
                    {
                        exist.DestroyMeLocal();
                    }
                }
            }
        }

        #endregion

        #region  Transform
        public static T GetGetInChildrens_OrAddComponent<T>(this Transform obj, bool IncludeInactive = false) where T : Component
        {
            return obj.gameObject.GetGetInChildrens_OrAddComponent<T>(IncludeInactive);
        }

        public static T GetGetInChildrens<T>(this Transform obj, bool IncludeInactive = false) where T : Component
        {
            return obj.gameObject.GetGetInChildrens<T>(IncludeInactive);
        }

        public static T GetOrAddComponent<T>(this Transform obj) where T : Component
        {
            return obj.gameObject.GetOrAddComponent<T>();
        }
        internal static void RemoveComponent<T>(this Transform obj) where T : Component
        {
            obj.gameObject.RemoveComponent<T>();
        }

        #endregion

        #region  component

        internal static T AddComponent<T>(this Component c) where T : Component
        {
            return c.gameObject.AddComponent<T>();
        }

        internal static T GetOrAddComponent<T>(this Component c) where T : Component
        {
            if (c == null) return null;
            var existing = c.GetComponent<T>();
            if (existing) return existing;
            return c.transform.AddComponent<T>();
        }

        internal static void RemoveComponent<T>(this Component c) where T : Component
        {
            if (c != null)
            {
                var existing = c.GetComponent<T>();
                if (existing)
                {
                    existing.DestroyMeLocal();
                }
            }
        }
        #endregion 

    }
}