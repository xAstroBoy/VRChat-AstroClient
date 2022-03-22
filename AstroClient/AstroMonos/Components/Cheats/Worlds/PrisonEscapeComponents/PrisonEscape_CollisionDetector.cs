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
    public class PrisonEscape_CollisionDetector : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_CollisionDetector(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        void Start()
        {

            // This will act as Collider to detect where the assigned player is spawned and correct the ESP system.
            foreach (var col in gameObject.GetComponents<Collider>())
            {
                col.isTrigger = true;
            }

            foreach (var rend in gameObject.GetComponents<Renderer>())
            {
                rend.DestroyMeLocal();
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            UpdateCollider(other);
        }

        void OnTriggerExit(Collider other)
        {
            UpdateCollider(other);
        }

        internal PrisonEscape.PrisonEscape_Roles AssignedColliderRole { get; set; }




        internal void UpdateCollider(Collider col)
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
                            PrisonESP.UpdateRoleFromCollider(AssignedColliderRole);
                        }
                    }
                }
            }
        }

    }
}