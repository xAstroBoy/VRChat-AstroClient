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
    public class ButtonGrp : Root
    {
        public GameObject headerGameObject { get; internal set; }
        public RectMask2D parentMenuMask { get; internal set; }
        public bool WasNoText { get; internal set; }

        /// <summary>
        ///  Remove Buttons, Toggles, anything that was put on this ButtnGrp
        /// </summary>
        public void RemoveAllChildren() =>
            gameObject.transform.DestroyChildren();
        

    }
}
