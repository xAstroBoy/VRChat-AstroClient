using AstroClient.febucci.Effects.Appearance_Effects.Defaults;
using AstroClient.febucci.Effects.Appearance_Effects.Presets;
using AstroClient.febucci.Effects.Behavior_Effects.Presets;
using UnityEngine;

namespace AstroClient.febucci.Core
{

    [System.Serializable]
    //Do not touch this script

    public class AppearanceDefaultValues
    {
        #region Default Effects' values
        private const float defDuration = .3f;
        [System.Serializable]
        public class Defaults
        {

            public float sizeDuration = defDuration;
            public float sizeAmplitude = 2;

            public float fadeDuration = defDuration;

            public float verticalExpandDuration = defDuration;
            public bool verticalFromBottom = false;

            public float horizontalExpandDuration = defDuration;
             internal HorizontalExpandAppearance.ExpType horizontalExpandStart = HorizontalExpandAppearance.ExpType.Left;

            public float diagonalExpandDuration = defDuration;
            public bool diagonalFromBttmLeft = false;

            public Vector2 offsetDir = Vector2.one;
            public float offsetDuration = defDuration;
            public float offsetAmplitude = 1f;

            public float rotationDuration = defDuration;
            public float rotationStartAngle = 180;
            
            
            public float randomDirDuration = defDuration;
            public float randomDirAmplitude = 1f;
        }


        public Defaults defaults = new Defaults();

        #endregion

        internal PresetAppearanceValues[] presets = new PresetAppearanceValues[0];
    }

    [System.Serializable]
    //Do not touch this script
    public class BehaviorDefaultValues
    {
        #region Default Effects' values

        [System.Serializable]
        public class Defaults
        {
            //wiggle
            public float wiggleAmplitude = 0.15f;
            public float wiggleFrequency = 7.67f;

            //wave
            public float waveFrequency = 4.78f;
            public float waveAmplitude = .2f;
            public float waveWaveSize = .18f;

            //rot
            public float angleSpeed = 180;
            public float angleDiffBetweenChars = 10;

            //swing
            public float swingAmplitude = 27.5f;
            public float swingFrequency = 5f;
            public float swingWaveSize = 0;

            //shake
            public float shakeStrength = 0.085f;
            public float shakeDelay = .04f;

            //size
            public float sizeAmplitude = 1.4f;
            public float sizeFrequency = 4.84f;
            public float sizeWaveSize = .18f;

            //slide
            public float slideAmplitude = 0.12f;
            public float slideFrequency = 5;
            public float slideWaveSize = 0;

            //bounce
            public float bounceAmplitude = .08f;
            public float bounceFrequency = 1f;
            public float bounceWaveSize = 0.08f;

            //rainb
            public float hueShiftSpeed = 0.8f;
            public float hueShiftWaveSize = 0.08f;

            //fade
            public float fadeDelay = 1.2f;

            //dangle
            public float dangleAmplitude = .13f;
            public float dangleFrequency = 2.41f;
            public float dangleWaveSize = 0.18f;
            public bool dangleAnchorBottom = false;

            //pendulum
            public float pendAmplitude = 25;
            public float pendFrequency = 3;
            public float pendWaveSize = .2f;
            public bool pendInverted = false;
        }

        public Defaults defaults = new Defaults();

        #endregion

        internal PresetBehaviorValues[] presets = new PresetBehaviorValues[0];
    }

}