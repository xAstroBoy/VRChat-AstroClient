namespace AstroClient.Constants
{
    using System;
    using System.Collections.Generic;
    using Tools.Extensions;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;

    internal class CustomLists : AstroEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            RendererSaverIndex.Clear();
            ColliderCheck.Clear();
            ScaleCheck.Clear();
        }

        internal class UdonBehaviour_Cached
        {
            internal UdonBehaviour UdonBehaviour { get; set; }
            internal string EventKey { get; set; }

            internal UdonBehaviour_Cached(UdonBehaviour udonBehaviour, string eventKey)
            {
                UdonBehaviour = udonBehaviour;
                EventKey = eventKey;
            }

            internal void InvokeBehaviour()
            {
                if (UdonBehaviour != null)
                {
                    if (EventKey.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        if (EventKey.StartsWith("_"))
                        {
                            UdonBehaviour.SendCustomEvent(EventKey);
                        }
                        else
                        {
                            UdonBehaviour.SendCustomNetworkEvent(NetworkEventTarget.All, EventKey);
                        }
                    }
                }
            }
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