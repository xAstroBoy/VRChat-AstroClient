using System;
using AstroActionMenu.Types;
using UnityEngine;

namespace AstroActionMenu.Pedals
{
    public abstract class PedalStruct
    {
        public string text { get; set; }
        public Texture2D icon { get; set; }
        public Action triggerEvent { get; protected set; }
        public PedalType Type { get; protected set; }
        public bool locked { get; set; }
        public bool shouldAdd { get; set; } = true;
    }
}