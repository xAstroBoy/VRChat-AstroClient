using AstroClient.febucci.Effects.Appearance_Effects.Presets;
using AstroClient.febucci.Effects.Behavior_Effects.Presets;
using UnityEngine;
using TagFormatting = AstroClient.febucci.Core.TAnimBuilder.TagFormatting;

namespace AstroClient.febucci.Core
{
    /// <summary>
    /// Stores TextAnimator's global data, shared in all your project (eg. Global Behaviors and Appearances).<br/>
    /// Must be placed inside the Resources Path <see cref="resourcesPath"/><br/>
    /// - Manual: <see href="https://www.febucci.com/text2-animator-unity/docs/creating-effects-in-the-inspector/#global-effects">Creating Global Effects</see>
    /// </summary>
    
    [System.Serializable]
    public class TAnimGlobalDataScriptable : ScriptableObject
    {
        /// <summary>
        /// Resources Path where the scriptable object must be stored
        /// </summary>
        public const string resourcesPath = "TextAnimator GlobalData";

        
        internal PresetBehaviorValues[] globalBehaviorPresets = new PresetBehaviorValues[0];

        
        internal PresetAppearanceValues[] globalAppearancePresets = new PresetAppearanceValues[0];

        
        internal string[] customActions = new string[0];


         internal bool customTagsFormatting = false;
         internal TagFormatting tagInfo_behaviors = new TagFormatting('<', '>');
         internal TagFormatting tagInfo_appearances = new TagFormatting('{', '}');
    }

}