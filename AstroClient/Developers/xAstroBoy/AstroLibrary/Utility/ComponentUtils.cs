namespace AstroClient.xAstroBoy.Utility
{
    using Tools.Extensions;
    using UnityEngine;

    public static class ComponentUtils
    {

        public static T GetGetInChildrens_OrAddComponent<T>(this GameObject obj) where T : Component
        {
            if (obj == null) return null;
            var result = obj.GetComponent<T>();
            if (result == null)
                result = obj.GetComponentInChildren<T>(true);
            if (result == null)
                result = obj.AddComponent<T>();
            return result;
        }

        public static T GetGetInChildrens<T>(this GameObject obj) where T : Component
        {
            if (obj == null) return null;
            var result = obj.GetComponent<T>();
            if (result == null)
                result = obj.GetComponentInChildren<T>(true);
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
        public static void RemoveComponent<T>(this Transform obj) where T : Component
        {
            obj.gameObject.RemoveComponent<T>();
        }

        public static T GetOrAddComponent<T>(this Transform obj) where T : Component
        {
            return obj.gameObject.GetOrAddComponent<T>();
        }
        internal static T AddComponent<T>(this Component c) where T : Component
        {
            return c.gameObject.AddComponent<T>();
        }

        internal static T GetOrAddComponent<T>(this Component c) where T : Component
        {
            if (c == null) return null;
            var existing = c.GetComponent<T>();
            if (existing) return existing;
            return c.gameObject.AddComponent<T>();
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

    }
}