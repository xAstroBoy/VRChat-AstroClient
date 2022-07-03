using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using Boo.Lang.Compiler.Ast;
using UnityEngine.Animations;
using VRC.SDK3.Components;
using VRCSDK2;
using VRCStation = VRC.SDKBase.VRCStation;

namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
    using ClientResources.Loaders;
    using Il2CppSystem.Collections.Generic;
    using Spawnables.Enderpearl;
    using System;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class EightBallController : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public EightBallController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private GameObject innertrigger;
            private bool isheld;
            public float lerpamount;
            public Animator fortuneanimator;
            public int fortunenumber;
            private float shaketimer;
            public float shakeendtimer;
            private bool shaken;
            private float movementdetection;

            public override void InputMoveHorizontal(float value, UdonInputEventArgs args)
            {
                movementdetection = value;
            }

            public override void InputMoveVertical(float value, UdonInputEventArgs args)
            {
                movementdetection = value;
            }

            public override void OnPickup()
            {
                if (Networking.IsOwner(gameObject))
                {
                    isheld = true;
                }
                else
                {
                    SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "OnPickup");
                }
            }

            public override void OnDrop()
            {
                isheld = false;
            }

            public void Update()
            {
                if (isheld || shaken)
                {
                    if (shaken)
                    {
                        if (shaketimer >= shakeendtimer)
                        {
                            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "FortuneResetSync");
                        }
                        else
                        {
                            shaketimer += Time.deltaTime;
                            innertrigger.transform.position = transform.position;
                        }
                    }
                    else
                    {
                        innertrigger.transform.position = Vector3.Lerp(innertrigger.transform.position, transform.position, lerpamount);
                    }
                }
            }

            private void OnTriggerExit(Collider other)
            {
                if (innertrigger == other.gameObject)
                {
                    if (!shaken && movementdetection == 0)
                    {
                        if (Networking.IsOwner(gameObject))
                        {
                            fortunenumber = Random.Range(0, 19);
                            SendCustomEventDelayedSeconds("FortuneSync", 0.7f);
                            shaken = true;
                        }
                    }
                }
            }

            public void FortuneResult()
            {
                fortuneanimator.SetBool("Shaken", true);
                fortuneanimator.SetInteger("FortuneInt", fortunenumber);
                shaken = true;
            }
            public void FortuneResetSync()
            {
                shaken = false;
                shaketimer = 0;
                fortuneanimator.SetBool("Shaken", false);
            }
            public void FortuneSync()
            {
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "FortuneResult");
            }
        }

    }
}