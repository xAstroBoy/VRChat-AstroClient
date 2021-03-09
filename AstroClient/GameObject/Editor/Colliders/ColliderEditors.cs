using System.Linq;
using UnityEngine;

#region AstroClient Imports

using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports

namespace AstroClient
{
    public class ColliderEditors
    {
        public static bool HasAlreadyAColliderAdded(GameObject obj)
        {
            return ColliderCheck.Where(x => x.TargetObj == obj).Select(x => x.HasCustomCollider).DefaultIfEmpty(false).First();
        }

        public static void CustomColliderHasBeenAdded(GameObject obj, bool HasColliderAdded)
        {
            if (obj != null)
            {
                var item = new ColliderChecker(obj, HasColliderAdded);
                if (!ColliderCheck.Contains(item))
                {
                    ColliderCheck.Add(item);
                    ColliderDisplay.UpdateColliders(false);
                }
            }
        }

        public static void AddCollider(GameObject obj)
        {
            var Missing_boxCollider = obj.GetComponent<BoxCollider>();
            var Missing_CapsuleCollider = obj.GetComponent<CapsuleCollider>();
            var Missing_SphereCollider = obj.GetComponent<SphereCollider>();
            if (Missing_boxCollider == null && Missing_SphereCollider == null && Missing_CapsuleCollider == null)
            {
                var item = obj.AddComponent<BoxCollider>();
                if (item != null)
                {
                    item.enabled = true;
                    CustomColliderHasBeenAdded(obj, true);
                }
            }
            else
            {
                if (Missing_boxCollider != null)
                {
                    var item = obj.AddComponent<BoxCollider>();
                    if (item != null)
                    {
                        item.enabled = true;
                        CustomColliderHasBeenAdded(obj, true);
                    }
                }
                else if (Missing_CapsuleCollider != null)
                {
                    var item = obj.AddComponent<CapsuleCollider>();
                    if (item != null)
                    {
                        item.radius = Missing_CapsuleCollider.radius;
                        item.center = Missing_CapsuleCollider.center;
                        item.height = Missing_CapsuleCollider.height;
                        item.direction = Missing_CapsuleCollider.direction;
                        item.transform.localScale = Missing_CapsuleCollider.transform.localScale;
                        item.enabled = true;
                        CustomColliderHasBeenAdded(obj, true);
                    }
                }
                else if (Missing_SphereCollider != null)
                {
                    var item = obj.AddComponent<SphereCollider>();
                    if (item != null)
                    {
                        item.center = Missing_SphereCollider.center;
                        item.contactOffset = Missing_SphereCollider.contactOffset;
                        item.transform.localScale = Missing_SphereCollider.transform.localScale;
                        item.enabled = true;
                        CustomColliderHasBeenAdded(obj, true);
                    }
                }
            }
        }

        public static void AddBoxCollider(GameObject obj, Vector3 size)
        {
            var Missing_boxCollider = obj.GetComponent<BoxCollider>();
            if (Missing_boxCollider == null)
            {
                var item = obj.AddComponent<BoxCollider>();
                if (item != null)
                {
                    item.enabled = true;
                    item.size = size;

                    CustomColliderHasBeenAdded(obj, true);
                }
            }
        }
    }
}