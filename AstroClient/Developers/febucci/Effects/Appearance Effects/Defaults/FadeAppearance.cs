using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Appearance_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Appearance_Effects.Defaults
{
    [EffectInfo(tag: TAnimTags.ap_Fade)]
    class FadeAppearance : AppearanceBase
    {

        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            effectDuration = data.defaults.fadeDuration;
        }

        Color32 temp;

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            //from transparent to real color
            for (int i = 0; i < TextUtilities.verticesPerChar; i++)
            {
                temp = data.colors[i];
                temp.a = 0;

                data.colors[i] = Color32.LerpUnclamped(data.colors[i], temp,
                    Utilities.Tween.EaseInOut(1 - (data.passedTime / effectDuration)));
            }
        }
    }

}