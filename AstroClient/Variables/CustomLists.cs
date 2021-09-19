﻿namespace AstroClient.Variables
{
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.Udon;

    public class CustomLists : GameEvents
    {
        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            RendererSaverIndex.Clear();
            ColliderCheck.Clear();
            RigidBodyCheck.Clear();
            ScaleCheck.Clear();
        }

        public class UdonBehaviour_Cached
        {
            public UdonBehaviour UdonBehaviour { get; set; }
            public string EventKey { get; set; }

            public UdonBehaviour_Cached(UdonBehaviour udonBehaviour, string eventKey)
            {
                UdonBehaviour = udonBehaviour;
                EventKey = eventKey;
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

            public GameObjScales(GameObject obj, Vector3 scale, bool stored)
            {
                TargetObj = obj;
                OriginalScale = scale;
                HasBeenStored = stored;
            }
        }

        public class RendererSaver
        {
            public GameObject TargetObj { get; set; }
            public int OriglightmapIndex { get; set; }

            public bool IsSavedObj { get; set; }

            public RendererSaver(GameObject obj, int lightmapIndex, bool isSaved = true)
            {
                TargetObj = obj;
                OriglightmapIndex = lightmapIndex;
                IsSavedObj = isSaved;
            }
        }

        public static List<RendererSaver> RendererSaverIndex = new List<RendererSaver>();
        public static List<ColliderChecker> ColliderCheck = new List<ColliderChecker>();
        public static List<RigidBodyChecker> RigidBodyCheck = new List<RigidBodyChecker>();
        public static List<GameObjScales> ScaleCheck = new List<GameObjScales>();
    }
}