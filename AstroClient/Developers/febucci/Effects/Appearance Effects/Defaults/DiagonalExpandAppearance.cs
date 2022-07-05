using AstroClient.febucci.Core;
using AstroClient.febucci.Core.Base;
using AstroClient.febucci.Effects.Appearance_Effects.Base;
using AstroClient.febucci.Utilities;
using UnityEngine;

namespace AstroClient.febucci.Effects.Appearance_Effects.Defaults
{
    [EffectInfo(tag: TAnimTags.ap_DiagExp)]
    class DiagonalExpandAppearance : AppearanceBase
    {
        int targetA;
        int targetB;
        
        //--Temp variables--
        Vector3 middlePos;
        float pct;

        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            effectDuration = data.defaults.diagonalExpandDuration;

            SetOrientation(data.defaults.diagonalFromBttmLeft);
        }

        void SetOrientation(bool btmLeft)
        {
            if (btmLeft) //expands bottom left and top right
            {
                targetA = 0;
                targetB = 2;
            }
            else //expands bottom right and top left
            {
                targetA = 1;
                targetB = 3;
            }
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            middlePos = data.vertices.GetMiddlePos();
            pct = Utilities.Tween.EaseInOut(data.passedTime / effectDuration);

            data.vertices[targetA] = Vector3.LerpUnclamped(middlePos, data.vertices[targetA], pct);
            //top right copies from bottom right
            data.vertices[targetB] = Vector3.LerpUnclamped(middlePos, data.vertices[targetB], pct);
        }

        public override void SetModifier(string modifierName, string modifierValue)
        {
            base.SetModifier(modifierName, modifierValue);
            switch (modifierName)
            {
                case "bot": SetOrientation(modifierValue == "1"); break;
            }
        }
    }

}