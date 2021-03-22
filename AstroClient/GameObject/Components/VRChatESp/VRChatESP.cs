using AstroClient.ConsoleUtils;
using System;
using UnityEngine;

namespace AstroClient.components
{
    public class VRChatESP : MonoBehaviour
    {
        public VRChatESP(IntPtr ptr) : base(ptr)
        {
        }

        // Use this for initialization
        public void Start()
        {
            try
            {
                var rend = GetComponentInChildren<MeshRenderer>(true);
                if (rend != null)
                {
                    ModConsole.DebugError("Added ESP to object : " + this.gameObject.name);
                    renderer = rend;
                }
                else
                {
                    ModConsole.DebugError("Error adding ESP to object : " + this.gameObject.name);
                    UnityEngine.Object.Destroy(this);
                }
            }
            catch { }
        }

        public void OnDestroy()
        {
            if (renderer != null)
            {
                HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(renderer, false);
            }
        }

        // Update is called once per frame
        public void Update()
        {
            if (renderer != null)
            {
                HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(renderer, true);
            }
            else
            {
                ModConsole.Error("Unable to Keep ESP to : " + this.gameObject.name + " As MeshRenderer is Missing");
                UnityEngine.Object.Destroy(this);
            }
        }

        private MeshRenderer renderer;
    }
}