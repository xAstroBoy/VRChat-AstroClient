namespace AstroClient.Constants
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MelonLoader;
    using Tools.Extensions;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;
    using Object = System.Object;

    internal class CustomLists : AstroEvents
    {
        internal override void OnRoomLeft()
        {
            RendererSaverIndex.Clear();
            ColliderCheck.Clear();
            ScaleCheck.Clear();
        }

        internal class ColliderChecker
        {
            internal GameObject TargetObj { get; set; }
            internal bool HasCustomCollider { get; set; }

            internal ColliderChecker(GameObject obj, bool collider)
            {
                TargetObj = obj;
                HasCustomCollider = collider;
            }
        }

        internal class GameObjScales
        {
            internal GameObject TargetObj { get; set; }
            internal Vector3 OriginalScale { get; set; }

            internal bool HasBeenStored { get; set; }

            internal GameObjScales(GameObject obj, Vector3 scale, bool stored)
            {
                TargetObj = obj;
                OriginalScale = scale;
                HasBeenStored = stored;
            }
        }

        internal class RendererSaver
        {
            internal GameObject TargetObj { get; set; }
            internal int OriglightmapIndex { get; set; }

            internal bool IsSavedObj { get; set; }

            internal RendererSaver(GameObject obj, int lightmapIndex, bool isSaved = true)
            {
                TargetObj = obj;
                OriglightmapIndex = lightmapIndex;
                IsSavedObj = isSaved;
            }
        }

        internal static List<RendererSaver> RendererSaverIndex = new List<RendererSaver>();
        internal static List<ColliderChecker> ColliderCheck = new List<ColliderChecker>();
        internal static List<GameObjScales> ScaleCheck = new List<GameObjScales>();
    }
}