using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static AstroClient.variables.CustomLists;

namespace AstroClient.extensions
{
    public static class CustomListExtensions
    {

        public static void RemoveObjFromCustomLists(this GameObject obj)
        {
            var objectcollider = ColliderCheck.FirstOrDefault(item => item.TargetObj == obj);
            var objectRigidBody = RigidBodyCheck.FirstOrDefault(item => item.TargetObj == obj);
            if (objectcollider != null)
            {
                if (ColliderCheck.Contains(objectcollider))
                {
                    ColliderCheck.Remove(objectcollider);
                }
            }
            if (objectRigidBody != null)
            {
                if (RigidBodyCheck.Contains(objectRigidBody))
                {
                    RigidBodyCheck.Remove(objectRigidBody);
                }
            }
        }

        public static int GetOriginalLightMapIndex(this GameObject obj)
        {
            return RendererSaverIndex.Where(x => x.TargetObj == obj).Select(x => x.OriglightmapIndex).DefaultIfEmpty(-999999999).First();
        }

        public static bool RenderisSaved(this GameObject obj)
        {
            return RendererSaverIndex.Where(x => x.TargetObj == obj).Select(x => x.isSavedObj).DefaultIfEmpty(false).First();
        }


    }
}
