using AstroClient.xAstroBoy.UIPaths;

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
        private Vector3 origin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 endPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool ReportHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        void Start()
        {
            Laser = gameObject.AddComponent<LineRenderer>();
            if(Laser != null)
            {
                Laser.material = new Material(Shader.Find("Sprites/Default"));
                Laser.startWidth = 0.1f;
                Laser.endWidth = 0.1f;
                Laser.widthMultiplier = 0.3f;
                Laser.startColor = Color.red;
                Laser.endColor = Color.red;
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
                // Are we hitting any colliders?
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, float.MaxValue))
                {
                    // If yes, then set endpoint to hit-point.
                    endPoint = hit.point;
                    if (ReportHit)
                    {
                        ModConsole.DebugLog($"Laser is Hitting {hit.collider.name} in GameObject {hit.collider.gameObject.name} in Root {hit.collider.gameObject.transform.root.name}");
                    }
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