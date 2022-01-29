namespace AstroClient.WorldModifications.Modifications
{
    using MelonLoader;
    using System;
    using System.Collections;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;

    internal class UdonBehaviour_Cached : AstroEvents
    {
        internal UdonBehaviour UdonBehaviour { get; set; }
        internal string EventKey { get; set; }

        private Action BeforeInvoking { get; set; } = null;
        private Action AfterInvoking { get; set; } = null;
        private Action OnFinish { get; set; } = null;

        internal UdonBehaviour_Cached(UdonBehaviour udonBehaviour, string eventKey)
        {
            UdonBehaviour = udonBehaviour;
            EventKey = eventKey;
        }

        internal void Set_BeforeInvoking_Action(Action action)
        {
            BeforeInvoking = action;
        }
        internal void Set_AfterInvoking_Action(Action action)
        {
            AfterInvoking = action;
        }
        internal void Set_OnFinish_Action(Action action)
        {
            OnFinish = action;
        }

        // Not needed really, but to be safe lol
        internal override void OnRoomLeft()
        {
            if (InvokeOnLoopObject != null)
            {
                MelonCoroutines.Stop(InvokeOnLoopObject);
            }
            if (InvokeBehaviourRepeater != null)
            {
                MelonCoroutines.Stop(InvokeBehaviourRepeater);
            }

            // Empty the behaviour as everything is null now!

            UdonBehaviour = null;
            EventKey = null;
        }
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

        private object InvokeOnLoopObject { get; set; }

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
                        UdonBehaviour.SendCustomNetworkEvent(NetworkEventTarget.All, EventKey);
                    }
                }
            }
        }

        internal void StopRepeatingBehaviourInvoking()
        {
            if (InvokeBehaviourRepeater != null)
            {
                MelonCoroutines.Stop(InvokeBehaviourRepeater);
            }

            InvokeBehaviourRepeater = null;
        }

        internal object RepeatInvokeBehaviour(int amount)
        {
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
                if (BeforeInvoking != null)
                {
                    BeforeInvoking();
                }

                InvokeBehaviour();
                if (AfterInvoking != null)
                {
                    AfterInvoking();
                }
                yield return new WaitForSeconds(LoopDelay);
            }
            if (OnFinish != null)
            {
                OnFinish();
            }
            yield return null;
        }

        private IEnumerator RepeatInvokeBehaviourRoutine(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (BeforeInvoking != null)
                {
                    BeforeInvoking();
                }

                InvokeBehaviour();
                if (AfterInvoking != null)
                {
                    AfterInvoking();
                }
                yield return new WaitForSeconds(RepeatDelay);
            }
            if (OnFinish != null)
            {
                OnFinish();
            }

            InvokeBehaviourRepeater = null;
            yield return null;
        }
    }
}