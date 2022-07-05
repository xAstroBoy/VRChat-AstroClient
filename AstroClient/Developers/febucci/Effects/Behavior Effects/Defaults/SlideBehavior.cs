using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Behavior_Effects.Base;
using UnityEngine;

namespace AstroClient.febucci.Effects.Behavior_Effects.Defaults
{
    
    [EffectInfo(tag: TAnimTags.bh_Slide)]
    
    class SlideBehavior : BehaviorSine
    {
        float sin;

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.slideAmplitude;
            frequency = data.defaults.slideFrequency;
            waveSize = data.defaults.slideWaveSize;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            sin = Mathf.Sin(frequency * time.timeSinceStart + charIndex * waveSize) * amplitude * uniformIntensity;

            //bottom, torwards one direction
            data.vertices[0] += Vector3.right * sin;
            data.vertices[3] += Vector3.right * sin;
            //top, torwards the opposite dir
            data.vertices[1] += Vector3.right * -sin;
            data.vertices[2] += Vector3.right * -sin;
        }
    }
}