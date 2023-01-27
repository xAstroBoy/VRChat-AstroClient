using AstroClient.Tools.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace AstroClient._1245.WorldAPI.ButtonAPI.QM.Controls
{
    internal class ButtonGrp : Root
    {
        internal GameObject headerGameObject { get; set; }
        internal RectMask2D parentMenuMask { get; set; }
        internal bool WasNoText { get; set; }

        /// <summary>
        ///  Remove Buttons, Toggles, anything that was put on this ButtnGrp
        /// </summary>
        internal void RemoveAllChildren() =>
            gameObject.transform.DestroyChildren();
        

    }
}
