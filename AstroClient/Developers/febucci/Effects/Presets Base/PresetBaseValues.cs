using UnityEngine;

namespace AstroClient.febucci.Effects.Presets_Base
{
    [System.Serializable]
    internal class PresetBaseValues
    {

#pragma warning disable 0649 //disabling the error or unity will throw "field is never assigned" [..], because we actually assign the variables from the custom drawers
        public string effectTag;

        public FloatCurve movementX;
        public FloatCurve movementY;
        public FloatCurve movementZ;

        public FloatCurve scaleX;
        public FloatCurve scaleY;

        public FloatCurve rotX;
        public FloatCurve rotY;
        public FloatCurve rotZ;

        public ColorCurve color;
#pragma warning restore 0649

        public float GetMaxDuration()
        {
            float GetEffectEvaluatorDuration(EffectEvaluator effect)
            {
                if (effect.isEnabled)
                    return effect.GetDuration();
                return 0;
            }

            float GetColorDuration(ColorCurve c)
            {
                if (c.enabled)
                {
                    c.GetDuration();
                }
                return 0;
            }
            return Mathf.Max
                (
                    GetEffectEvaluatorDuration(movementX) +
                    GetEffectEvaluatorDuration(movementY) +
                    GetEffectEvaluatorDuration(movementZ) +
                    GetEffectEvaluatorDuration(scaleX) +
                    GetEffectEvaluatorDuration(scaleY),
                     GetColorDuration(color)
                );
        }

        public virtual void Initialize(bool isAppearance)
        {
            int baseIdentifier = isAppearance ? 3 : 0;

            movementX.Initialize(baseIdentifier);
            movementY.Initialize(baseIdentifier);
            movementZ.Initialize(baseIdentifier);

            scaleX.Initialize(baseIdentifier + 1);
            scaleY.Initialize(baseIdentifier + 1);

            rotX.Initialize(baseIdentifier + 2);
            rotY.Initialize(baseIdentifier + 2);
            rotZ.Initialize(baseIdentifier + 2);

            color.Initialize(isAppearance);
        }
    }
}