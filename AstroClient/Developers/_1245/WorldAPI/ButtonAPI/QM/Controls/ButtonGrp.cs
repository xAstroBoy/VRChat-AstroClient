using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroClient.Tools.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WorldAPI.ButtonAPI.Buttons;
using WorldAPI.ButtonAPI.Extras;
using WorldAPI.Buttons;

namespace WorldAPI.ButtonAPI.Controls
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
