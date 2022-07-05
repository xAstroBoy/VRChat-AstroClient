using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Behavior_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Behavior_Effects.Defaults
{
    
    [EffectInfo(tag: TAnimTags.bh_Wave)]
    
    class WaveBehavior : BehaviorSine
    {

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.waveAmplitude;
            frequency = data.defaults.waveFrequency;
            waveSize = data.defaults.waveWaveSize;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.MoveChar(Vector3.up * Mathf.Sin(time.timeSinceStart * frequency + charIndex * waveSize) * amplitude * uniformIntensity);
        }
    }

}