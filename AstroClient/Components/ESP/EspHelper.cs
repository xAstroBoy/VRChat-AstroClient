using AstroClient.Finder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AstroClient.components
{
    class EspHelper : GameEvents
    {
        public override void OnLevelLoaded()
        {
            foreach(var item in SpawnedESPsHolders)
            {
                UnityEngine.Object.DestroyImmediate(item);
            }
            SpawnedESPsHolders.Clear();
        }


        private static GameObject _HighlightFXCamera;

        public static GameObject HighLightFXCamera
        {
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


        public static List<HighlightsFXStandalone> SpawnedESPsHolders = new List<HighlightsFXStandalone>();
    }
}
