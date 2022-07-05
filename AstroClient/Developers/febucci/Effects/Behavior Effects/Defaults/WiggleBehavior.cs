﻿using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Behavior_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Behavior_Effects.Defaults
{
    
    [EffectInfo(tag: TAnimTags.bh_Wiggle)]
    class WiggleBehavior : BehaviorBase
    {

        float amplitude = 0.15f;
        float frequency = 7.67f;

        Vector3[] directions;

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.wiggleAmplitude;
            frequency = data.defaults.wiggleFrequency;
        }

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

        public override void SetModifier(string modifierName, string modifierValue)
        {
            switch (modifierName)
            {
                //amplitude
                case "a": ApplyModifierTo(ref amplitude, modifierValue); break;
                //frequency
                case "f": ApplyModifierTo(ref frequency, modifierValue); break;
            }
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.MoveChar(directions[charIndex] * Mathf.Sin(time.timeSinceStart* frequency + charIndex) * amplitude * uniformIntensity);
        }


        public override string ToString()
        {
            return $"freq: {frequency}\n" +
                $"ampl: {amplitude}" +
                $"\n{ base.ToString()}";
        }

    }
}