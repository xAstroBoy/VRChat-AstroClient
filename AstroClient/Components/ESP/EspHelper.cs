﻿using UnhollowerBaseLib.Attributes;

namespace AstroClient.Components
{
    using System.Collections.Generic;
    using UnityEngine;

    internal class EspHelper : GameEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            foreach (var item in SpawnedESPsHolders)
            {
                Object.DestroyImmediate(item);
            }
            SpawnedESPsHolders.Clear();
        }

        private static GameObject _HighlightFXCamera;

        internal static GameObject HighLightFXCamera
        {
            [HideFromIl2Cpp]
            get
            {
                if (_HighlightFXCamera == null)
                {
                    var obj = HighlightsFX.prop_HighlightsFX_0.gameObject;
                    if (obj != null)
                    {
                        _HighlightFXCamera = obj;
                    }
                    return obj;
                }
                else
                {
                    return _HighlightFXCamera;
                }
            }
        }

        internal static List<HighlightsFXStandalone> SpawnedESPsHolders = new List<HighlightsFXStandalone>();
    }
}