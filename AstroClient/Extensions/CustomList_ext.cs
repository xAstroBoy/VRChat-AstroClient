﻿namespace AstroLibrary.Extensions
{
    using System.Linq;
    using UnityEngine;
    using static AstroClient.Variables.CustomLists;

    internal static class CustomList_ext
    {
        internal static void RemoveObjFromCustomLists(this GameObject obj)
        {
            var objectcollider = ColliderCheck.FirstOrDefault(item => item.TargetObj == obj);
            var objectRigidBody = RigidBodyCheck.FirstOrDefault(item => item.TargetObj == obj);
            if (objectcollider != null)
            {
                if (ColliderCheck.Contains(objectcollider))
                {
                    _ = ColliderCheck.Remove(objectcollider);
                }
            }

            if (objectRigidBody != null)
            {
                if (RigidBodyCheck.Contains(objectRigidBody))
                {
                    _ = RigidBodyCheck.Remove(objectRigidBody);
                }
            }
        }

        internal static int GetOriginalLightMapIndex(this GameObject obj)
        {
            return RendererSaverIndex.Where(x => x.TargetObj == obj).Select(x => x.OriglightmapIndex).DefaultIfEmpty(-999999999).First();
        }

        internal static bool RenderisSaved(this GameObject obj)
        {
            return RendererSaverIndex.Where(x => x.TargetObj == obj).Select(x => x.IsSavedObj).DefaultIfEmpty(false).First();
        }
    }
}