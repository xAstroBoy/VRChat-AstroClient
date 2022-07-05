using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Presets_Base
{
    [System.Serializable]
    internal class FloatCurve : EffectEvaluator
    {
#pragma warning disable 0649 //disabling the error or unity will throw "field is never assigned" [..], because we actually assign the variables from the custom drawers
        public bool enabled;

         protected float amplitude;
         protected AnimationCurve curve;

         protected float defaultReturn;

        private protected float _charsTimeOffset;
        /// <summary>
        /// clamping to 100 because it repeates the behavior after it
        /// </summary>
        protected float charsTimeOffset
        {
            get => _charsTimeOffset;
            set
            {
                _charsTimeOffset = Mathf.Clamp(value, 0, 100f);
            }
        }

        [System.NonSerialized] float calculatedDuration;
#pragma warning restore 0649

        public bool isEnabled => enabled;

        public float GetDuration()
        {
            return calculatedDuration;
        }

        bool isAppearance;

        public void Initialize(int type)
        {
            calculatedDuration = curve.CalculateCurveDuration();

            isAppearance = type >= 3;

            switch (type)
            {
                //mov
                default:
                case 0: defaultReturn = 0; break;

                //scale
                case 1: defaultReturn = 1; break;

                //rot
                case 2: defaultReturn = 0; break;

                //app mov
                case 3: defaultReturn = 0; break;

                //app scale
                case 4: defaultReturn = 1; break;

                //app rot
                case 5: defaultReturn = 0; break;

            }
        }

        public float Evaluate(float time, int characterIndex)
        {
            if (!enabled)
                return defaultReturn;

            if (isAppearance)
            {
                return Mathf.LerpUnclamped(amplitude, defaultReturn, curve.Evaluate(time) * Mathf.Cos(Deg2Rad * (characterIndex * charsTimeOffset / 2f)));
            }


            //behavior
            return curve.Evaluate(time + characterIndex * (charsTimeOffset / 100f)) * amplitude;
        }

        public const float Deg2Rad = 0.01745329f;

    }
}