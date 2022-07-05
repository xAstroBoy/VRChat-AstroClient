using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Appearance_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Appearance_Effects.Defaults
{
    [EffectInfo(tag: TAnimTags.ap_Rot)]
    class RotatingAppearance : AppearanceBase
    {

        float targetAngle;
        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            effectDuration = data.defaults.rotationDuration;
            targetAngle = data.defaults.rotationStartAngle;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {

            data.vertices.RotateChar(
                Mathf.Lerp(
                    targetAngle,
                    0,
                    Utilities.Tween.EaseInOut(data.passedTime / effectDuration)
                    )
                );
        }

        public override void SetModifier(string modifierName, string modifierValue)
        {
            base.SetModifier(modifierName, modifierValue);
            switch (modifierName)
            {
                case "a": ApplyModifierTo(ref targetAngle, modifierValue); break;
            }
        }

    }

}