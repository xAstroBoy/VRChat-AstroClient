using UnityEngine;

namespace AstroClient.febucci.Effects.Presets_Base
{
    [System.Serializable]
    internal class ColorCurve
    {

#pragma warning disable 0649 //disabling the error or unity will throw "field is never assigned" [..], because we actually assign the variables from the custom drawers
         public bool enabled;
         protected Gradient gradient;
         private protected float _duration;
        protected float duration
        {
            get => _duration;
            set
            {
                _duration = Mathf.Clamp(value, 0.1f, float.MaxValue);
            }
        }


        private protected  float _charsTimeOffset; 
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

        #pragma warning restore 0649

        public float GetDuration()
        {
            return duration;
        }

        bool isAppearance;

        public void Initialize(bool isAppearance)
        {
            this.isAppearance = isAppearance;
            if (duration < .1f)
            {
                duration = .1f;
            }
        }

        public Color32 GetColor(float time, int characterIndex)
        {
            if (isAppearance)
                return gradient.Evaluate(Mathf.Clamp01(time / duration));

            return gradient.Evaluate(((time / duration) % 1f + characterIndex * (charsTimeOffset / 100f)) % 1f);
        }
    }
}