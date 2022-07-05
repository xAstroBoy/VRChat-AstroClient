using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Behavior_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Behavior_Effects.Defaults
{
    
    [EffectInfo(tag: TAnimTags.bh_Incr)]
    
    sealed class SizeBehavior : BehaviorSine
    {
        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.sizeAmplitude * -1 + 1;
            frequency = data.defaults.sizeFrequency;
            waveSize = data.defaults.sizeWaveSize;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.LerpUnclamped(
                data.vertices.GetMiddlePos(),
                (Mathf.Cos(time.timeSinceStart* frequency + charIndex * waveSize) + 1) / 2f * amplitude);
        }
    }
}