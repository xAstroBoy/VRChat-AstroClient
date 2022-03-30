using AstroClient.ClientAttributes;
using AstroClient.Tools.Colors;
using AstroClient.Tools.Extensions;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Tools
{
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

        /// <summary>
        /// Current Used Line Renderer.
        /// </summary>
        private LineRenderer Laser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        
        /// <summary>
        /// Endpoint vector
        /// </summary>
        private Vector3 endPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        internal bool ReportHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        /// <summary>
        /// If this is on, it will increase Accuracy
        /// If is off, it will just use the transform.foward
        /// </summary>
        internal bool UseRaycast { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        /// <summary>
        /// Default Color (Used when there's no hits)
        /// </summary>
        internal Color Defaultcolor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = SystemColors.Orange;

        /// <summary>
        /// Only When a collider is hit.
        /// </summary>
        internal Color ColliderHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = SystemColors.OrangeRed;

        /// <summary>
        /// When a Player is Hit.
        /// </summary>
        internal Color PlayerHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = SystemColors.Red;


        /// <summary>
        /// Should Only hit Players?
        /// </summary>
        internal bool HitOnlyPlayers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        /// <summary>
        /// Make it ignore The trigger colliders on hit?
        /// </summary>
        internal bool IgnoreTriggerColliders { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        private float _SphereSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.2f;

        /// <summary>
        /// Change the Endpoint Sphere Size.
        /// </summary>
        internal float SphereSize
        {[HideFromIl2Cpp]
            get
            {
                return _SphereSize;
            }
            [HideFromIl2Cpp]
            set
            {
                _SphereSize = value;
                if(EndPointSphere != null)
                {
                    EndPointSphere.transform.localScale = new Vector3(value, value, value);
                }
            }
        }

        /// <summary>
        ///How Far the laser should go without raycast hits.
        /// </summary>

        internal float Distance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10000f;

        /// <summary>
        ///This should Make the laser not have a stuck effect when Raycast doesn't touch anything.
        /// </summary>
        internal Vector3 DefaultEndPoint
        {
            [HideFromIl2Cpp]
            get
            {
                return this.transform.position + this.transform.forward * Distance;
            }
        }

        /// <summary>
        /// Change LineRenderer Color (including EndPoint sphere)
        /// </summary>
        /// <param name="color"></param>
        internal void SetLaserColor(Color color)
        {
            Laser.startColor = color;
            Laser.endColor = color;
            if(EndPointSphere != null)
            {
                var rend = EndPointSphere.GetComponent<Renderer>();
                if(rend != null)
                {
                    rend.material.SetColor("_Color", color);
                }
            }
        }

        /// <summary>
        /// Spawn a EndPoint sphere
        /// </summary>
        private void SpawnEndPointSphere()
        {
            if (EndPointSphere == null)
            {
                EndPointSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                EndPointSphere.transform.parent = this.transform;
                EndPointSphere.name = "Laser Pointer EndPoint Sphere";
                EndPointSphere.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);
                EndPointSphere.RemoveAllColliders();
            }

        }

        private bool _ShowEndPointSphere { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal GameObject EndPointSphere { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;


        /// <summary>
        /// Shows the Endpoint sphere Or removes it
        /// </summary>
        internal bool ShowEndPointSphere
        { [HideFromIl2Cpp]
            get
            {
                return _ShowEndPointSphere;
            }
            [HideFromIl2Cpp]
            set
            {
                _ShowEndPointSphere = value;
                if(value)
                {
                    SpawnEndPointSphere();
                }
                else
                {
                    if(EndPointSphere != null)
                    {
                        EndPointSphere.DestroyMeLocal();
                    }
                }
            }
        }

        /// <summary>
        /// Change Color on Player Collider Hit?
        /// </summary>
        internal bool ChangeOnPlayerHit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;


        private void Start()
        {
            Laser = gameObject.AddComponent<LineRenderer>();
            if (Laser != null)
            {
                Laser.material = new Material(Shader.Find("VRChat/UI/Additive"));
                Laser.startWidth = 0.01f;
                Laser.endWidth = 0.01f;
                Laser.widthMultiplier = 0.4f;
                Laser.startColor = Defaultcolor;
                Laser.endColor = Defaultcolor;
                //Laser.useWorldSpace = true;
            }
        }

        private void Update()
        {
            CheckLaser();
        }

        /// <summary>
        ///  Check if Hit is a Player
        ///  Checks For PlayerLocal, Player LayerMasks or the VRC.Player component if present.
        /// </summary>
        /// <param name="hit"></param>
        /// <returns></returns>
        private bool isPlayer(Collider hit)
        {
            if (hit != null)
            {
                if (hit.transform.root.GetComponentInChildren<VRC.Player>() != null ||
                    hit.gameObject.GetComponentInChildren<VRC.Player>() != null ||
                    isLayer(hit, "PlayerLocal")||
                    isLayer(hit, "Player"))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Small utility to check if the Layer exists.
        /// </summary>
        /// <param name="LayerName"></param>
        /// <returns></returns>
        private bool LayerExists(string LayerName)
        {
            var newLayer = LayerMask.NameToLayer(LayerName);
            if (newLayer > -1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if the gameobject or root has the layer assigned.
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="LayerName"></param>
        /// <returns></returns>
        private bool isLayer(Collider hit, string LayerName)
        {
            if (LayerExists(LayerName))
            {
                if (hit != null)
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer(LayerName) ||
                        hit.transform.gameObject.layer == LayerMask.NameToLayer(LayerName) ||
                        hit.transform.root.gameObject.layer == LayerMask.NameToLayer(LayerName) ||
                        hit.transform.root.gameObject.layer == LayerMask.NameToLayer(LayerName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        

        /// <summary>
        /// Spammy, used only for debug purposes, but it reports Layer, Collider is Trigger  and collider and root Transforms name
        /// </summary>
        /// <param name="collider"></param>
        private void ReportHitResult(Collider collider)
        {
            if (ReportHit)
            {
                ModConsole.DebugLog(
                    $"Laser is Hitting GameObject {collider.gameObject.name}  in Root {collider.gameObject.transform.root.name}\n" + 
                        $"Collider is Trigger : {collider.isTrigger}\n"+
                        $"Gameobject with layer {collider.gameObject.layer}, having name {LayerMask.LayerToName(collider.gameObject.layer)} \n" +
                        $"Gameobject Root with layer {collider.gameObject.transform.root.gameObject.layer}, having name {LayerMask.LayerToName(collider.gameObject.transform.root.gameObject.layer)}");
            }

        }

        
        /// <summary>
        /// Used for Setting Endpoint Vector
        /// </summary>
        /// <param name="hit"></param>
        private void SetEndPoint(RaycastHit hit)
        {
            if (isPlayer(hit.collider))
            {
                if (ChangeOnPlayerHit)
                {
                    SetLaserColor(PlayerHit);
                }
                endPoint = hit.point;
                if (EndPointSphere != null)
                {
                    EndPointSphere.transform.position = hit.point;
                }
            }
            else
            {
                if (HitOnlyPlayers)
                {
                    SetLaserColor(Defaultcolor);
                    endPoint = DefaultEndPoint;
                    if (EndPointSphere != null)
                    {
                        EndPointSphere.transform.position = DefaultEndPoint;
                    }
                }
                else
                {
                    if (!hit.collider.isTrigger)
                    {
                        SetLaserColor(ColliderHit);
                        endPoint = hit.point;
                        if (EndPointSphere != null)
                        {
                            EndPointSphere.transform.position = hit.point;
                        }

                    }
                    else
                    {
                        if (IgnoreTriggerColliders)
                        {
                            SetLaserColor(Defaultcolor);
                            endPoint = DefaultEndPoint; 
                            if(EndPointSphere != null)
                            {
                                EndPointSphere.transform.position = DefaultEndPoint;
                            }
                        }
                        else
                        {
                            SetLaserColor(ColliderHit);
                            if (!isLayer(hit.collider, "MirrorReflection")) // Ignore Mirror reflection and other mirror layers (who tf needs em)
                            {
                                endPoint = hit.point;
                                if (EndPointSphere != null)
                                {
                                    EndPointSphere.transform.position = hit.point;
                                }
                            }
                            else
                            {
                                SetLaserColor(Defaultcolor);
                                endPoint = DefaultEndPoint;
                                if (EndPointSphere != null)
                                {
                                    EndPointSphere.transform.position = DefaultEndPoint;
                                }
                            }
                        }
                    }
                }

            }

        }


        private void CheckLaser()
        {
            if (Laser != null)
            {
                if (UseRaycast)
                {
                    // Are we hitting any colliders?
                    RaycastHit hit;
                    //Debug.DrawRay(this.transform.position, this.transform.forward, Color.green);
                    if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, float.MaxValue,  ~(1 << LayerMask.NameToLayer("MirrorReflection") | 1 << LayerMask.NameToLayer("UI"))))
                    {
                        ReportHitResult(hit.collider);
                        SetEndPoint(hit);
                    }
                    else
                    {
                        SetLaserColor(Defaultcolor);
                        endPoint = DefaultEndPoint;
                        if (EndPointSphere != null)
                        {
                            EndPointSphere.transform.position = DefaultEndPoint;
                        }
                    }
                }
                else
                {
                    SetLaserColor(Defaultcolor);
                    endPoint = DefaultEndPoint;
                    if (EndPointSphere != null)
                    {
                        EndPointSphere.transform.position = DefaultEndPoint;
                    }
                }

                // Set end point of laser.
                Laser.SetPosition(0, this.transform.position);
                Laser.SetPosition(1, endPoint);
            }
        }

        private void OnEnable()
        {
            Laser.enabled = true;
            if (ShowEndPointSphere)
            {
                SpawnEndPointSphere();
            }
            if (EndPointSphere != null)
            {
                EndPointSphere.SetActive(true);
            }
        }

        private void OnDisable()
        {
            Laser.enabled = false;
            if(ShowEndPointSphere)
            {
                SpawnEndPointSphere();
            }
            if (EndPointSphere != null)
            {
                EndPointSphere.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            Laser.DestroyMeLocal();
            if(EndPointSphere != null)
            {
                EndPointSphere.DestroyMeLocal();
            }
        }
    }
}