using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Behavior_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Behavior_Effects.Defaults
{
    
    [EffectInfo(tag: TAnimTags.bh_Bounce)]
    
    class BounceBehavior : BehaviorSine
    {

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.bounceAmplitude;
            frequency = data.defaults.bounceFrequency;
            waveSize = data.defaults.bounceWaveSize;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {

            //Calculates the tween percentage
            float BounceTween(float t)
            {
                const float stillTime = .2f;
                const float easeIn = .2f;
                const float bounce = 1 - stillTime - easeIn;

                if (t <= easeIn)
                    return Utilities.Tween.EaseInOut(t / easeIn);
                t -= easeIn;

                if (t <= bounce)
                    return 1 - Utilities.Tween.BounceOut(t / bounce);

                return 0;
            }

            data.vertices.MoveChar(Vector3.up * uniformIntensity * BounceTween((Mathf.Repeat(time.timeSinceStart * frequency - waveSize * charIndex, 1))) * amplitude);
        }
    }

}