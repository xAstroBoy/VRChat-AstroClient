using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //ObjRenderers = obj.GetComponentsInChildren<Renderer>(true).ToList();
            ObjMeshRenderers = obj.GetComponentsInChildren<MeshRenderer>(true).ToList();

            if (ObjMeshRenderers == null  && ObjMeshRenderers.Count() == 0) 
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
                    HighLightOptions = EspHelper.HighLightFXCamera.AddHighlighter();
                }
                if (HighLightOptions != null)
                {
                    //foreach (var ObjRenderer in ObjRenderers)
                    //{
                    //    if (ObjRenderer != null)
                    //    {
                    //        HighLightOptions.SetHighLighter(ObjRenderer, Color.green, true);
                    //    }
                    //}
                    foreach (var ObjMeshRenderer in ObjMeshRenderers)
                    {
                        if (ObjMeshRenderer != null)
                        {
                            HighLightOptions.SetHighLighter(ObjMeshRenderer, Color.green, true);
                        }
                    }
                }
                HighLightOptions.enabled = obj.active;

            }
        }

        //public void Update()
        //{
        //    if (obj != null)
        //    {

        //        if (HighLightOptions != null)
        //        {
        //            if (HighLightOptions.enabled != obj.active)
        //            {
        //                HighLightOptions.enabled = obj.active;
        //            }
        //        }
        //    }
        //}

        public void OnDestroy()
        {
            if (HighLightOptions != null)
            {
                //foreach (var ObjRenderer in ObjRenderers)
                //{
                //    if (ObjRenderer != null)
                //    {
                //        HighLightOptions.SetHighLighter(ObjRenderer, false);
                //    }
                //}
                foreach (var ObjMeshRenderer in ObjMeshRenderers)
                {
                    if (ObjMeshRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjMeshRenderer, false);
                    }
                }
            }
            HighLightOptions.DestroyHighlighter();
        }

        
        public void OnEnable()
        {
            if (HighLightOptions != null)
            {
                //foreach (var ObjRenderer in ObjRenderers)
                //{
                //    if (ObjRenderer != null)
                //    {
                //        HighLightOptions.SetHighLighter(ObjRenderer, true);
                //    }
                //}
                foreach (var ObjMeshRenderer in ObjMeshRenderers)
                {
                    if (ObjMeshRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjMeshRenderer, true);
                    }
                }
            }
        }

        public void OnDisable()
        {
            if (HighLightOptions != null)
            {
                //foreach (var ObjRenderer in ObjRenderers)
                //{
                //    if (ObjRenderer != null)
                //    {
                //        HighLightOptions.SetHighLighter(ObjRenderer, false);
                //    }
                //}
                foreach (var ObjMeshRenderer in ObjMeshRenderers)
                {
                    if (ObjMeshRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjMeshRenderer, false);
                    }
                }
            }
        }


        internal void ChangeColor(Color newcolor)
        {
            HighLightOptions.SetHighLighterColor(newcolor);
        }

        internal Color GetCurrentESPColor
        {
            get
            {
                return HighLightOptions.highlightColor;
            }
        }



        private GameObject obj;
        //private List<Renderer> ObjRenderers = new List<Renderer>();
        private List<MeshRenderer> ObjMeshRenderers = new List<MeshRenderer>();
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