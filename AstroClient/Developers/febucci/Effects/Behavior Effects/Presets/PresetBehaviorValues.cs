using AstroClient.febucci.Effects.Presets_Base;

namespace AstroClient.febucci.Effects.Behavior_Effects.Presets
{
    [System.Serializable]
    internal class PresetBehaviorValues : PresetBaseValues
    {
#pragma warning disable 0649 //disabling the error or unity will throw "field is never assigned" [..], because we actually assign the variables from the custom drawers
         public EmissionControl emission;
#pragma warning restore 0649

        public override void Initialize(bool isAppearance)
        {
            base.Initialize(isAppearance);
            emission.Initialize(GetMaxDuration());

        }
    }

}