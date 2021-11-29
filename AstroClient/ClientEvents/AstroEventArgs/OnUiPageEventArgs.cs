namespace AstroClient.AstroEventArgs
{
    using System;
    using VRC.UI.Elements;

    internal class OnUiPageEventArgs : EventArgs
    {
        internal UIPage Page;
        internal bool Toggle;
        internal UIPage.TransitionType TransitionType;

        internal OnUiPageEventArgs(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            this.Page = Page;
            this.Toggle = Toggle;
            this.TransitionType = TransitionType;
        }
    }
}