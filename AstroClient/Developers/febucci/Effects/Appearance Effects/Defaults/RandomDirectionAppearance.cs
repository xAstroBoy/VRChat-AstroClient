using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Appearance_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Appearance_Effects.Defaults
{
    [EffectInfo(tag: TAnimTags.ap_RandomDir)]
    class RandomDirectionAppearance : AppearanceBase
    {

        float amount;
        Vector3[] directions;

        public override void Initialize(int charactersCount)
        {
            base.Initialize(charactersCount);

            directions = new Vector3[charactersCount];

            //Calculates a random direction for each character (which won't change)
            for(int i = 0; i < charactersCount; i++)
            {
                directions[i] = TextUtilities.fakeRandoms[Random.Range(0, TextUtilities.fakeRandomsCount - 1)] * Mathf.Sign(Mathf.Sin(i));
            }
        }


        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            amount = data.defaults.randomDirAmplitude;
            effectDuration = data.defaults.randomDirDuration;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            //Moves all towards a direction
            data.vertices.MoveChar(directions[charIndex] * amount * uniformIntensity * Utilities.Tween.EaseIn(1 - data.passedTime / effectDuration));
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