using AstroClient.xAstroBoy.UIPaths;
using BestHTTP.Extensions;

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
    public class LaserPointer : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public LaserPointer(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private LineRenderer Laser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private Vector3 endPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal bool ReportHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        internal bool UseRaycast { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;
        internal Color Defaultcolor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = SystemColors.Orange;
        internal Color ColliderHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = SystemColors.OrangeRed;

        internal Color PlayerHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = SystemColors.Red;


        internal void SetLaserColor(Color color)
        {
            Laser.startColor = color;
            Laser.endColor = color;

        }

        internal bool ChangeOnPlayerHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        void Start()
        {
            Laser = gameObject.AddComponent<LineRenderer>();
            if(Laser != null)
            {
                Laser.material = new Material(Shader.Find("Sprites/Default"));
                Laser.startWidth = 0.01f;
                Laser.endWidth = 0.01f;
                Laser.widthMultiplier = 0.2f;
                Laser.startColor = Defaultcolor;
                Laser.endColor = Defaultcolor;
            }
        }

        void Update()
        {
            CheckLaser();
        }


        void CheckLaser()
        {
            if(Laser != null)
            {
                if (UseRaycast)
                {
                    // Are we hitting any colliders?
                    RaycastHit hit;
                    if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, float.MaxValue, ~0, QueryTriggerInteraction.Ignore))
                    {
                        // If yes, then set endpoint to hit-point.
                        endPoint = hit.point;
                        if (hit.collider.transform.root.GetComponentInChildren<Player>() != null)
                        {
                            if (ChangeOnPlayerHit)
                            {
                                SetLaserColor(PlayerHit);
                            }
                        }
                        else
                        {
                            SetLaserColor(ColliderHit);
                        }
                        if (ReportHit)
                        {
                            ModConsole.DebugLog($"Laser is Hitting GameObject {hit.collider.gameObject.name} in Root {hit.collider.gameObject.transform.root.name}");
                        }
                    }
                    else
                    {
                        SetLaserColor(Defaultcolor);
                        endPoint = this.transform.position + this.transform.forward * 6000f; // This should Make the laser not have a stuck effect when Raycast doesn't touch anything.
                    }
                }
                else
                {
                    SetLaserColor(Defaultcolor);
                    endPoint = this.transform.position + this.transform.forward * 6000f; // This should Make the laser not have a stuck effect when Raycast doesn't touch anything.
                }

                // Set end point of laser.
                Laser.SetPosition(0, this.transform.position);
                Laser.SetPosition(1, endPoint);
            }
        }
        void OnEnable()
        {
            Laser.enabled = true;
        }

        void OnDisable()
        {
            Laser.enabled = false;
        }

        void OnDestroy()
        {
            Laser.DestroyMeLocal();
        }
    }
}