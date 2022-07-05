using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Appearance_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Appearance_Effects.Defaults
{
    [EffectInfo(tag: TAnimTags.ap_Offset)]
    class OffsetAppearance : AppearanceBase
    {

        float amount;
        Vector2 direction;

        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            direction = data.defaults.offsetDir;
            amount = data.defaults.offsetAmplitude * uniformIntensity;
            effectDuration = data.defaults.offsetDuration;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            //Moves all towards a direction
            data.vertices.MoveChar(direction * amount * Utilities.Tween.EaseIn(1 - data.passedTime / effectDuration));
        }

        public override void SetModifier(string modifierName, string modifierValue)
        {
            base.SetModifier(modifierName, modifierValue);
            switch (modifierName)
            {
                case "a": ApplyModifierTo(ref amount, modifierValue); break;
            }
        }
    }

}