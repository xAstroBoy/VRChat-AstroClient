using AstroClient.ConsoleUtils;
using System.Collections.Generic;
using UnityEngine;

namespace AstroClient
{
    internal static class ColliderToggler
    {
        public static void ReenableAll()
        {
            int num = 0;
            int num2 = 0;
            foreach (Collider collider in ColliderToggler.ToggledColliders)
            {
                bool flag = collider == null;
                if (flag)
                {
                    num2++;
                }
                else
                {
                    num++;
                    collider.enabled = true;
                }
            }
            ColliderToggler.ToggledColliders.Clear();
            ModConsole.Log(string.Format("Reenabled {0} colliders, skipped {1} colliders", num, num2));
        }

        private static void ToggleCollider(Collider collider)
        {
            bool flag = collider == null;
            if (!flag)
            {
                collider.enabled = false;
                ColliderToggler.ToggledColliders.Add(collider);
                string colliderName = ColliderToggler.GetColliderName(collider);
                ModConsole.Log("Toggled collider " + colliderName);
            }
        }

        private static string GetColliderName(Collider collider)
        {
            Transform transform = collider.transform;
            List<string> list = new List<string>
            {
                collider.GetType().Name
            };
            do
            {
                list.Add(transform.gameObject.name);
                transform = transform.parent;
            }
            while (transform != null);
            list.Reverse();
            return string.Join("/", list);
        }

        private static readonly List<Collider> ToggledColliders = new List<Collider>();
    }
}