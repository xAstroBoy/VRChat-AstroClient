using System.Collections.Generic;
using AstroClient.febucci.Utilities;

namespace AstroClient.febucci.Core
{
    /// <summary>
    /// TextAnimator's typewriter action
    /// </summary>
    public struct TypewriterAction
    {
        /// <summary>
        /// ID of the action without the tag symbols, eg. 'waitfor'
        /// </summary>
        public string actionID;

        /// <summary>
        /// Contains all the parameters passed via the rich text tag
        /// </summary>
        /// <example>
        /// If you write <waitfor=5> in the text, the following code will result in:
        /// <code>
        /// float waitTime;
        /// Febucci.UI.Core.FormatUtils.TryGetFloat(action.parameters, 0, 1f, out waitTime);
        /// //waitTime is now 5
        /// </code>
        /// </example>
        /// <see cref="FormatUtils.ParseFloat"/>
        public List<string> parameters;
    }
}