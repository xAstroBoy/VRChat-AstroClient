using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Behavior_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Behavior_Effects.Defaults
{
    
    [EffectInfo(tag: TAnimTags.bh_Swing)]
    
    class SwingBehavior : BehaviorSine
    {

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.swingAmplitude;
            frequency = data.defaults.swingFrequency;
            waveSize = data.defaults.swingWaveSize;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.RotateChar(Mathf.Cos(time.timeSinceStart * frequency + charIndex * waveSize) * amplitude);
        }
    }
}