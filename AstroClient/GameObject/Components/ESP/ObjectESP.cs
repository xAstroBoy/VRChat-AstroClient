using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AstroClient.components
{
    public class ObjectESP : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ObjectESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[ObjectESP Debug] : {msg}");
            }
        }

        // Use this for initialization
        public void Start()
        {
            obj = this.gameObject;
            ObjRenderer = obj.GetComponentInChildren<Renderer>(true);
            if (ObjRenderer == null)
            {
                ObjMeshRenderer = obj.GetComponentInChildren<MeshRenderer>(true);
            }
            if (ObjMeshRenderer == null && ObjRenderer == null)
            {
                ModConsole.DebugError($"Unable to add ObjectESP to  {obj.name} due to MeshRenderer and Renderer Being null");
                Object.Destroy(this);
                return;
            }
            else
            {
                Debug($"Found Renderer in {obj.name}, Activating ESP !");
                if (HighLightOptions == null)
                {
                    HighLightOptions = HighlightsFX.prop_HighlightsFX_0.gameObject.AddComponent<HighlightsFXStandalone>();
                }
                if (HighLightOptions != null)
                {
                    if (ObjRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjRenderer, Color.green, true);
                    }
                    else if (ObjMeshRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjMeshRenderer, Color.green, true);
                    }
                }
            }
        }

        public void OnDestroy()
        {
            if (ObjRenderer != null)
            {
                HighLightOptions.SetHighLighter(ObjRenderer, false);
            }
            else if (ObjMeshRenderer != null)
            {
                HighLightOptions.SetHighLighter(ObjMeshRenderer, false);
            }
            HighLightOptions.DestroyMeLocal();
        }

        
        public void OnEnable()
        {
            if (ObjRenderer != null)
            {
                HighLightOptions.SetHighLighter(ObjRenderer, true);
            }
            else if (ObjMeshRenderer != null)
            {
                HighLightOptions.SetHighLighter(ObjMeshRenderer, true);
            }
        }

        public void OnDisable()
        {
            if (ObjRenderer != null)
            {
                HighLightOptions.SetHighLighter(ObjRenderer, false);
            }
            else if (ObjMeshRenderer != null)
            {
                HighLightOptions.SetHighLighter(ObjMeshRenderer, false);
            }
        }

        internal void ChangeColor(Color newcolor)
        {
            if (ObjRenderer != null)
            {
                HighLightOptions.SetHighLighterColor(newcolor);
            }
            else if (ObjMeshRenderer != null)
            {
                HighLightOptions.SetHighLighterColor(newcolor);
            }
        }

        internal Color GetCurrentESPColor
        {
            get
            {
                return HighLightOptions.highlightColor;
            }
        }

        private GameObject obj;
        private Renderer ObjRenderer;
        private MeshRenderer ObjMeshRenderer;
        private HighlightsFXStandalone HighLightOptions;

        internal GameObject AssignedObject
        {
            get
            {
                return obj;
            }
        }
    }
}