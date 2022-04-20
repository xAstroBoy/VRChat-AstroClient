﻿namespace AstroClient.AstroMonos.Components.ESP
{
    using System.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    internal class EspHelper : AstroEvents
    {
        internal override void OnRoomLeft()
        {
            for (int i = 0; i < SpawnedESPsHolders.Count; i++)
            {
                Object.DestroyImmediate(SpawnedESPsHolders[i]);
            }
            SpawnedESPsHolders.Clear();
        }

        private static GameObject _HighlightFXCamera;

        internal static GameObject HighlightFXCamera
        {
            [HideFromIl2Cpp]
            get
            {
                if (_HighlightFXCamera == null)
                {
                    return _HighlightFXCamera = HighlightsFX.prop_HighlightsFX_0.gameObject;
                }
                return _HighlightFXCamera;

            }
        }

        internal static List<HighlightsFXStandalone> SpawnedESPsHolders = new List<HighlightsFXStandalone>();
    }
}