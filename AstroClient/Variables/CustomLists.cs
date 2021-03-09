using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;

namespace AstroClient.variables
{
    public static class CustomLists
    {
        public static void OnLevelLoad()
        {
            RendererSaverIndex.Clear();
            ColliderCheck.Clear();
            RigidBodyCheck.Clear();
            ScaleCheck.Clear();
        }

        public class ColliderChecker
        {
            public GameObject TargetObj { get; set; }
            public bool HasCustomCollider { get; set; }

            public ColliderChecker(GameObject obj, bool collider)
            {
                TargetObj = obj;
                HasCustomCollider = collider;
            }
        }


        public class RigidBodyChecker
        {
            public GameObject TargetObj { get; set; }
            public bool HasRigidBodyReplaced { get; set; }

            public RigidBodyChecker(GameObject obj, bool RigidBody)
            {
                TargetObj = obj;
                HasRigidBodyReplaced = RigidBody;
            }
        }

        public class GameObjScales
        {
            public GameObject TargetObj { get; set; }
            public Vector3 OriginalScale { get; set; }

            public bool HasBeenStored { get; set; }

            public GameObjScales(GameObject obj, Vector3 Scale, bool Stored)
            {
                TargetObj = obj;
                OriginalScale = Scale;
                HasBeenStored = Stored;
            }
        }

        public class RendererSaver
        {
            public GameObject TargetObj { get; set; }
            public int OriglightmapIndex { get; set; }

            public bool isSavedObj { get; set; }

            public RendererSaver(GameObject obj, int lightmapIndex, bool isSaved = true)
            {
                TargetObj = obj;
                OriglightmapIndex = lightmapIndex;
                isSavedObj = isSaved;
            }
        }

        public static void RemoveObjFromLists(this GameObject obj)
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

        public static List<RendererSaver> RendererSaverIndex = new List<RendererSaver>();
        public static List<ColliderChecker> ColliderCheck = new List<ColliderChecker>();
        public static List<RigidBodyChecker> RigidBodyCheck = new List<RigidBodyChecker>();
        public static List<GameObjScales> ScaleCheck = new List<GameObjScales>();
    }
}