﻿namespace AstroActionMenu.Pedals
{
    using System;
    using Types;
    using UnityEngine;

    public sealed class PedalButton : PedalStruct
    {
        public PedalButton(string text, Texture2D icon, Action triggerEvent, bool locked = false)
        {
            this.text = text;
            this.icon = icon;
            this.triggerEvent = triggerEvent;
            Type = PedalType.Button;
            this.locked = locked;
        }
    }
}