using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Appearance_Effects.Base;
using AstroClient.febucci.Utilities;

namespace AstroClient.febucci.Effects.Appearance_Effects.Defaults
{
    [EffectInfo(tag: TAnimTags.ap_Size)]
    class SizeAppearance : AppearanceBase
    {
        float amplitude;
        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            effectDuration = data.defaults.sizeDuration;
            amplitude = data.defaults.sizeAmplitude * -1 + 1;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.LerpUnclamped(
                data.vertices.GetMiddlePos(),
                Utilities.Tween.EaseIn(1 - (data.passedTime / effectDuration)) * amplitude
                );
        }

        public override void SetModifier(string modifierName, string modifierValue)
        {
            base.SetModifier(modifierName, modifierValue);
            switch (modifierName)
            {
                case "a": ApplyModifierTo(ref amplitude, modifierValue); break;
            }
        }
    }
}