namespace CheetoLibrary.ButtonAPI
{
    using System;
    using UnityEngine;

    public class Button : ButtonBase
    {
        public Button(Transform parent, string label, string tooltip, Action action, byte[] icon = null, bool jump = false) : base(parent, label, tooltip, icon, action, jump)
        {
        }
    }
}