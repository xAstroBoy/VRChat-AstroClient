using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Udon;

namespace AstroClient.variables
{
    public class CustomLists : Overridables
    {
        public override void OnLevelLoaded()
        {
            RendererSaverIndex.Clear();
            ColliderCheck.Clear();
            RigidBodyCheck.Clear();
            ScaleCheck.Clear();
        }

        public class CachedUdonEvent
        {
            public UdonBehaviour Action { get; set; }
            public string EventKey { get; set; }

            public CachedUdonEvent(UdonBehaviour Action, string Key)
            {
                this.Action = Action;
                this.EventKey = Key;
            }
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


        public static List<RendererSaver> RendererSaverIndex = new List<RendererSaver>();
        public static List<ColliderChecker> ColliderCheck = new List<ColliderChecker>();
        public static List<RigidBodyChecker> RigidBodyCheck = new List<RigidBodyChecker>();
        public static List<GameObjScales> ScaleCheck = new List<GameObjScales>();

    }
}