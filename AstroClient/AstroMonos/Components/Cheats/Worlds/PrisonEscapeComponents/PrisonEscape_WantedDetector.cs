namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using Boo.Lang.Compiler.Ast;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using Tools.Listeners;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using WorldModifications.WorldHacks;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class PrisonEscape_WantedDetector : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_WantedDetector(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEvent(other);
        }




        

        private void OnTriggerEvent(Collider col)
        {
            if (col != null)
            {
                var root = col.transform.root;
                if (root.name.Contains("VRCPlayer"))
                {
                    var player = root.GetComponent<Player>();
                    if (player != null)
                    {
                        var PrisonESP = player.gameObject.GetComponent<PrisonEscape_ESP>();
                        if (PrisonESP != null)
                        {
                            PrisonESP.isWanted = true;
                        }
                    }
                }
            }
        }
  

    }
}