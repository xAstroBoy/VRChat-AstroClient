namespace AstroClientCore.Events
{
    using System;
    using VRC;
    using VRC.UI.Elements;

    internal class OnUiPageEventArgs : EventArgs
    {
        internal UIPage Page;
        internal bool Toggle;

        internal OnUiPageEventArgs(UIPage Page, bool Toggle)
        {
            this.Page = Page;
            this.Toggle = Toggle;
        }
    }
}