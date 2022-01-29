namespace AstroClient.CustomClasses
{
    using MelonLoader;
    using System;
    using System.Collections;
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

        private Action BeforeInvoking { get; set; } = null;
        private Action AfterInvoking { get; set; } = null;
        private Action OnFinish { get; set; } = null;

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

        internal UdonBehaviour_Cached(UdonBehaviour udonBehaviour, string eventKey)
        {
            UdonBehaviour = udonBehaviour;
            EventKey = eventKey;
        }

        /// <summary>
        /// Sets Action Before Running InvokeBehaviour()
        /// </summary>

        internal void Set_BeforeInvoking_Action(Action action)
        {
            BeforeInvoking = action;
        }

        /// <summary>
        /// Sets Action After Running InvokeBehaviour()
        /// </summary>
        internal void Set_AfterInvoking_Action(Action action)
        {
            AfterInvoking = action;
        }

        /// <summary>
        /// Sets Finish Action on Loop/Repeating stop.
        /// </summary>

        internal void Set_OnFinish_Action(Action action)
        {
            OnFinish = action;
        }

        // Not needed really, but to be safe lol
        private void Cleanup()
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
                EventKey = null;
            }
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
                    StopRepeatingBehaviourInvoking();
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
                }
            }
        }

        /// <summary>
        /// Manually Invoke UdonBehaviour Event (will clean itself if it detects the behaviour is null!)
        /// </summary>

        internal void InvokeBehaviour()
        {
            if (UdonBehaviour != null)
            {
                if (EventKey.IsNotNullOrEmptyOrWhiteSpace())
                {
                    if (EventKey.StartsWith("_"))
                    {
                        UdonBehaviour.SendCustomEvent(EventKey);
                    }
                    else
                    {
                        UdonBehaviour.SendCustomNetworkEvent(EventTarget, EventKey);
                    }
                }
            }
            else
            {
                Cleanup();
            }
        }
        /// <summary>
        /// Halts RepeatInvokeBehaviour.
        /// </summary>

        internal void StopRepeatingBehaviourInvoking()
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
        internal object RepeatInvokeBehaviour(int amount)
        {
            InvokeOnLoop = false;
            // Avoid To spam the same routine.
            if (InvokeBehaviourRepeater == null)
            {
                return InvokeBehaviourRepeater = MelonCoroutines.Start(RepeatInvokeBehaviourRoutine(amount));
            }
            return null;
        }

        private IEnumerator InvokeOnLoopRoutine()
        {
            while (InvokeOnLoop)
            {
                BeforeInvoking?.Invoke();
                InvokeBehaviour();
                AfterInvoking?.Invoke();
                yield return new WaitForSeconds(LoopDelay);
            }
            OnFinish?.Invoke();
            InvokeOnLoopObject = null;
            yield return null;
        }

        private IEnumerator RepeatInvokeBehaviourRoutine(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                BeforeInvoking?.Invoke();
                InvokeBehaviour();
                AfterInvoking?.Invoke();
                yield return new WaitForSeconds(RepeatDelay);
            }

            OnFinish?.Invoke();

            InvokeBehaviourRepeater = null;
            yield return null;
        }
    }
}