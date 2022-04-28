using System;
using AstroClient.ClientActions;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;
using AstroClient.WorldModifications.WorldsIds;

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
    public class PrisonEscape_CollisionDetector : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_CollisionDetector(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        void Start()
        {
            if (!WorldUtils.WorldID.Equals(WorldIds.PrisonEscape)) Destroy(this);
            HasSubscribed = true;
            // This will act as Collider to detect where the assigned player is spawned and correct the ESP system.
        }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        void OnDestroy()
        {
            HasSubscribed = false;
        }
        void OnTriggerStay(Collider other)
        {
            OnColliderHit(other);
        }
        internal PrisonEscape_Roles AssignedRole { get; set; }  = PrisonEscape_Roles.Dead;


        

        private void OnColliderHit(Collider col)
        {
            if (col != null)
            {
                var root = col.transform.root;
                if (root.name.Contains("VRCPlayer"))
                {
                    var player = root.GetComponent<Player>();
                    if (player != null)
                    {
                        var PrisonESP = player.gameObject.GetOrAddComponent<PrisonEscape_ESP>();
                        if (PrisonESP != null)
                        {
                            PrisonESP.UpdateRoleFromCollider(AssignedRole);
                        }
                    }
                }
                else
                {
                    foreach(var item in col.GetComponents<Collider>())
                    {
                        if (item != null)
                        {
                            foreach (var col2 in gameObject.GetComponents<Collider>())
                            {
                                Physics.IgnoreCollision(item, col, true);
                            }
                        }
                    }
                }
            }
        }

    }
}