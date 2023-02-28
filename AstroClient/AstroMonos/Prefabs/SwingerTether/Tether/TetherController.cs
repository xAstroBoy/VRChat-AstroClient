using System;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.UdonUtils.UdonSharp;
using AstroClient.xAstroBoy.Utility;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Tether
{
    /// <summary>
    /// Controller for tethering player to an object or tethering rigidbodies to the player.
    /// </summary>
    [RegisterComponent]
    public class TetherController : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();
        public TetherController(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal float tetherInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.0f;
        internal bool tethering { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        internal bool tetheringRigidbody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        internal Vector3 tetherPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = Vector3.zero;
        internal Vector3 tetherNormal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = Vector3.zero;
        internal GameObject tetherObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Rigidbody tetherRigidbody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float tetherLength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float tetherUnwindRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        internal void Update()
        {
            if (tetherInput > TetherProperties.tetherInputDeadzone)
            {
                if (!tethering)
                {
                    bool detected = false;
                    RaycastHit hit = new RaycastHit();

                    // auto aim in incremental sizes
                    detected = Physics.Raycast(transform.position, transform.forward, out hit, TetherProperties.tetherMaximumLength, TetherProperties.tetherDetectionMask);
                    if (!detected)
                    {
                        for (int i = TetherProperties.tetherDetectionIncrements; detected == false && i > 0; i--)
                        {
                            detected = Physics.SphereCast(transform.position, TetherProperties.tetherDetectionSize / i, transform.forward, out hit, TetherProperties.tetherMaximumLength, TetherProperties.tetherDetectionMask);
                        }
                    }

                    if (detected)
                    {
                        // store tether point as local coords to game object so the gameobject can move and we will stay tethered
                        tetherObject = hit.collider.gameObject;
                        tetherRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                        tetherPoint = tetherObject.transform.InverseTransformPoint(hit.point);
                        tetherNormal = hit.normal;
                        tetherLength = Vector3.Distance(transform.position, hit.point);

                        tethering = true;
                        tetheringRigidbody = TetherProperties.manipulatesRigidbodies && tetherRigidbody != null;
                        if (tetheringRigidbody)
                        {
                            tetherObject.TakeOwnership();
                        }
                    }
                }

                if (tethering)
                {
                    // unreeling
                    if (TetherProperties.allowUnwinding && !IsInputHeld())
                    {
                        tetherUnwindRate = TetherProperties.unwindRate * (1.0f - ((tetherInput - TetherProperties.tetherInputDeadzone) / (TetherProperties.tetherHoldDeadzone - TetherProperties.tetherInputDeadzone)));
                        tetherLength = Mathf.Clamp(tetherLength + tetherUnwindRate * Time.deltaTime, 0.0f, TetherProperties.tetherMaximumLength);
                    }

                    Vector3 worldTetherPoint = GetTetherPoint();
                    float distance = Vector3.Distance(transform.position, worldTetherPoint);

                    // we are beyond the tether length, so project our velocity along the invisible sphere and push us back inside
                    if (distance > tetherLength)
                    {
                        if (!tetheringRigidbody || (tetheringRigidbody && TetherProperties.playerMass <= tetherRigidbody.mass))
                        {
                            Vector3 normal = worldTetherPoint - transform.position;
                            normal = normal.normalized;

                            Vector3 spring = normal * (distance - tetherLength) * TetherProperties.tetherSpringFactor;
                            spring = Vector3.ClampMagnitude(spring * Time.deltaTime, TetherProperties.tetherMaximumSpringForce);

                            Vector3 velocity = GameInstances.LocalPlayer.GetVelocity();
                            Vector3 projected = Vector3.ProjectOnPlane(velocity, normal);
                            GameInstances.LocalPlayer.SetVelocity(Vector3.MoveTowards(velocity, projected, TetherProperties.tetherProjectionRate * Time.deltaTime) + spring);
                        }
                    }
                }
            }
            else
            {
                if (tethering)
                {
                    tethering = false;
                    tetheringRigidbody = false;
                }
            }

        }

        internal void FixedUpdate()
        {
            if (tetheringRigidbody)
            {
                Vector3 worldTetherPoint = GetTetherPoint();

                float distance = Vector3.Distance(transform.position, worldTetherPoint);

                // tether for rigidbodies that weigh less than us
                if (distance > tetherLength)
                {
                    Vector3 normal = transform.position - worldTetherPoint;
                    normal = normal.normalized;

                    Vector3 spring = normal * (distance - tetherLength) * TetherProperties.rigidbodySpringFactor * TetherProperties.playerMass;
                    spring = Vector3.ClampMagnitude(spring, TetherProperties.rigidbodyMaximumSpringForce * TetherProperties.playerMass);

                    Vector3 projected = Vector3.ProjectOnPlane(tetherRigidbody.velocity, normal);
                    tetherRigidbody.gameObject.TakeOwnership();
                    tetherRigidbody.velocity = Vector3.MoveTowards(tetherRigidbody.velocity, projected, TetherProperties.rigidbodyProjectionRate * TetherProperties.playerMass * Time.deltaTime);
                    tetherRigidbody.AddForceAtPosition(spring, worldTetherPoint);
                }
            }
        }

        internal void OnDisable()
        {
            tethering = false;
            tetheringRigidbody = false;
        }

        internal float GetInput()
        {
            return tetherInput > TetherProperties.tetherInputDeadzone ? tetherInput : 0.0f;
        }

        internal void SetInput(float value)
        {
            tetherInput = value;
        }

        internal bool IsInputHeld()
        {
            return tetherInput > TetherProperties.tetherHoldDeadzone;
        }

        internal bool GetTethering()
        {
            return tethering;
        }

        internal float GetTetherLength()
        {
            if (!tethering)
            {
                return 1.0f;
            }
            return tetherLength / TetherProperties.tetherMaximumLength;
        }

        internal float GetActualTetherLength()
        {
            if (!tethering)
            {
                return 0.0f;
            }
            return tetherLength;
        }

        internal GameObject GetTetherObject()
        {
            return tetherObject;
        }

        internal Vector3 GetTetherStartPoint()
        {
            return transform.position;
        }

        internal Vector3 GetTetherPoint()
        {
            return tetherObject.transform.TransformPoint(tetherPoint);
        }

        internal Vector3 GetTetherNormal()
        {
            return tetherNormal;
        }

        internal float GetTetherUnwindRate()
        {
            return tetherUnwindRate == 0.0f ? 0.0f : tetherUnwindRate / TetherProperties.unwindRate;
        }
    }
}