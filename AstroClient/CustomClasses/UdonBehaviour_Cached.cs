using AstroClient.xAstroBoy.Utility;
using UnityEngine.UI;

namespace AstroClient.CustomClasses
{
    using MelonLoader;
    using System;
    using System.Collections;
    using Tools.UdonEditor;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;

    internal class UdonBehaviour_Cached
    {
        /// <summary>
        /// Assigned UdonBehaviour.
        /// </summary>

        internal UdonBehaviour UdonBehaviour { get; set; }

        /// <summary>
        /// Assigned UdonBehaviour Event
        /// (Unsafe to edit unless you input a valid event).
        /// (Invoking a invalid event will cause a client crash!)
        /// </summary>

        internal string EventKey { get; set; }

        /// <summary>
        /// Sets Action Before Running InvokeBehaviour()
        /// </summary>

        internal Action BeforeInvoking { get; set; }
        /// <summary>
        /// Sets Action After Running InvokeBehaviour()
        /// </summary>
        internal Action AfterInvoking { get; set; }


        /// <summary>
        /// Sets Finish Action on Loop/Repeating stop.
        /// </summary>
        internal Action OnFinish { get; set; } = null;

        /// <summary>
        /// Default is  NetworkEventTarget.All
        /// NetworkEventTarget.All  ( Affects everybody).
        ///  NetworkEventTarget.Owner (Affects only gameobject owner.)
        /// </summary>

        internal NetworkEventTarget EventTarget { get; set; } = NetworkEventTarget.All;

        /// <summary>
        /// Sets RepeatInvokeBehaviour() Delay.
        ///  0.05f is the  Minimum required to not trigger VRChat Unusual client behaviour kick
        /// </summary>

        internal float RepeatDelay { get; set; } = 0.05f;

        /// <summary>
        /// Sets InvokeOnLoop Delay.
        ///  0.05f is the  Minimum required to not trigger VRChat Unusual client behaviour kick
        /// </summary>
        internal float LoopDelay { get; set; } = 0.05f; // Minimum required to not trigger VRChat Unusual client behaviour kick.

        private object InvokeBehaviourRepeater { get; set; }
        private bool _InvokeOnLoop { get; set; }
        private object InvokeOnLoopObject { get; set; }

        /// <summary>
        /// Generate By providing a UdonBehaviour and a working EventKey
        /// </summary>

        internal UdonBehaviour_Cached(UdonBehaviour udonBehaviour, string eventKey)
        {
            UdonBehaviour = udonBehaviour;

            // TODO: Make a EventKey Verifier (Default is on, but Make it disable the verify if is being added from UdonSearch class)
            EventKey = eventKey;
        }

        /// <summary>
        /// Cleans and halts any Coroutine running
        /// This will Nullify Everything as well!
        /// </summary>
        internal void Cleanup()
        {
            if (InvokeOnLoop) InvokeOnLoop = false;
            if (InvokeOnLoopObject != null)
            {
                MelonCoroutines.Stop(InvokeOnLoopObject);
            }

            if (InvokeBehaviourRepeater != null)
            {
                MelonCoroutines.Stop(InvokeBehaviourRepeater);
            }

            if (UdonBehaviour != null)
            {
                // Empty the behaviour as everything is null now!
                UdonBehaviour = null;
            }
            EventKey = null;
            _RawItem = null;
        }

        /// <summary>
        /// Starts a Loop that keeps invoking the behaviour.
        /// (This will end RepatInvokeBehaviour)
        /// </summary>
        internal bool InvokeOnLoop
        {
            get
            {
                return _InvokeOnLoop;
            }
            set
            {
                _InvokeOnLoop = value;
                if (value)
                {
                    Stop_RepeatInvoke();
                    if (InvokeOnLoopObject == null)
                    {
                        InvokeOnLoopObject = MelonCoroutines.Start(InvokeOnLoopRoutine());
                    }
                }
                else
                {
                    if (InvokeOnLoopObject != null)
                    {
                        MelonCoroutines.Stop(InvokeOnLoopObject);
                    }

                    InvokeOnLoopObject = null;
                }
            }
        }

        /// <summary>
        /// Manually Invoke UdonBehaviour Event (will clean itself if it detects the behaviour is null!)
        /// </summary>

        internal void Invoke()
        {
            if (UdonBehaviour != null)
            {
                if (EventKey.IsNotNullOrEmptyOrWhiteSpace())
                {
                    if(BeforeInvoking != null)
                    {
                        BeforeInvoking.SafetyRaise();
                        MiscUtils.DelayFunction(0.6f, () =>
                        {
                            UdonBehaviour.SendUdonEvent(EventKey, EventTarget);
                        });
                    }
                    else
                    {
                        UdonBehaviour.SendUdonEvent(EventKey, EventTarget);
                    }
                    AfterInvoking.SafetyRaise();
                }
            }
            else
            {
                Cleanup();
            }
        }
        /// <summary>
        /// Returns The UdonBehaviour GameObject
        /// </summary>

        internal GameObject gameObject
        {
            get
            {
                return UdonBehaviour.gameObject;
            }
        }

        /// <summary>
        /// Returns The UdonBehaviour Transform
        /// </summary>

        internal Transform transform
        {
            get
            {
                return UdonBehaviour.transform;
            }
        }
        /// <summary>
        /// Returns The UdonBehaviour name
        /// </summary>

        internal string name
        {
            get
            {
                return UdonBehaviour.name;
            }
        }
        /// <summary>
        /// Toggles DisableInteractive on the UdonBehaviour
        /// </summary>

        internal bool? DisableInteractive
        {
            get
            {
                if (UdonBehaviour != null)
                {
                    return UdonBehaviour.DisableInteractive;
                }
                return null;
            }
            set
            {
                if (UdonBehaviour != null)
                {
                    if (value.HasValue)
                    {
                        UdonBehaviour.DisableInteractive = value.Value;
                    }
                }
            }
        }

        private RawUdonBehaviour _RawItem;

        /// <summary>
        /// Returns The Raw UdonBehaviour (needed to do Heap patching)
        /// </summary>
        internal RawUdonBehaviour RawItem
        {
            get
            {
                if (_RawItem == null)
                {
                    _RawItem = UdonBehaviour.ToRawUdonBehaviour();
                }
                return _RawItem;
            }
        }
        /// <summary>
        /// Halts InvokeOnLoop Routine.
        /// </summary>

        internal void Stop_InvokeLoop()
        {
            if (InvokeOnLoopObject != null)
            {
                MelonCoroutines.Stop(InvokeOnLoopObject);
            }

            InvokeOnLoopObject = null;
        }

        /// <summary>
        /// Halts RepeatInvokeBehaviour Routine.
        /// </summary>

        internal void Stop_RepeatInvoke()
        {
            if (InvokeBehaviourRepeater != null)
            {
                MelonCoroutines.Stop(InvokeBehaviourRepeater);
            }

            InvokeBehaviourRepeater = null;
        }

        /// <summary>
        /// This invokes the Behaviour Event for a certain amount (This will halt the Repeat loop).
        /// </summary>
        internal object RepeatInvoke(int amount)
        {
            InvokeOnLoop = false;
            // Avoid To spam the same routine.
            if (InvokeBehaviourRepeater == null)
            {
                return InvokeBehaviourRepeater = MelonCoroutines.Start(RepeatInvokeRoutine(amount));
            }
            return InvokeBehaviourRepeater;
        }

        private IEnumerator InvokeOnLoopRoutine()
        {
            while (InvokeOnLoop)
            {
                BeforeInvoking?.Invoke();
                Invoke();
                AfterInvoking?.Invoke();
                yield return new WaitForSeconds(LoopDelay);
            }
            OnFinish?.Invoke();
            InvokeOnLoopObject = null;
            yield return null;
        }

        private IEnumerator RepeatInvokeRoutine(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                BeforeInvoking?.Invoke();
                Invoke();
                AfterInvoking?.Invoke();
                yield return new WaitForSeconds(RepeatDelay);
            }

            OnFinish?.Invoke();

            InvokeBehaviourRepeater = null;
            yield return null;
        }
    }
}