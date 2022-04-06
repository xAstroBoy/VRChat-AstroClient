﻿namespace AstroClient.Tools.ColliderViewer
{
    using System.Collections.Generic;
    using UnityEngine;

    internal static class ColliderToggler
    {
        internal static void ReenableAll()
        {
            int num = 0;
            int num2 = 0;
            foreach (Collider collider in ToggledColliders)
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
            ToggledColliders.Clear();
            Log.Write(string.Format("Reenabled {0} colliders, skipped {1} colliders", num, num2));
        }

        private static void ToggleCollider(Collider collider)
        {
            bool flag = collider == null;
            if (!flag)
            {
                collider.enabled = false;
                ToggledColliders.Add(collider);
                string colliderName = GetColliderName(collider);
                Log.Write("Toggled collider " + colliderName);
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