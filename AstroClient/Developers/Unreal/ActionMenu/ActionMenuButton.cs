using System;
using UnityEngine;

namespace AstroClient.Unreal;

internal class ActionMenuButton
{
    internal ActionMenuButton(CustomActionMenu.BaseMenu baseMenu, string buttonText, Action buttonAction, Texture2D buttonIcon = null)
    {
        this.ButtonText = buttonText;
        this.ButtonAction = buttonAction;
        this.ButtonIcon = buttonIcon;
        SetIcon(buttonIcon);
        SetButtonText(buttonText);
        if (baseMenu == CustomActionMenu.BaseMenu.MainMenu)
        {
            CustomActionMenu.SingleButtons.Add(this);
        }
    }

    internal ActionMenuButton(ActionMenuPage basePage, string buttonText, System.Action buttonAction, Texture2D buttonIcon = null)
    {
        this.ButtonText = buttonText;
        this.ButtonAction += buttonAction;
        this.ButtonIcon = buttonIcon;
        basePage.buttons.Add(this);
    }

    internal void SetButtonText(string newText)
    {
        this.ButtonText = newText;
        if (this.currentPedalOption != null)
        {
            this.currentPedalOption.prop_String_0 = newText;
        }
    }

    internal void SetIcon(Texture2D newTexture)
    {
        this.ButtonIcon = newTexture;
        if (this.currentPedalOption != null)
        {
            currentPedalOption.prop_Texture2D_0 = newTexture;
        }
    }

    internal void SetEnabled(bool enabled)
    {
        this.IsEnabled = enabled;
        if (this.currentPedalOption != null)
        {
            this.currentPedalOption.Method_Public_Void_Boolean_0(!enabled);
        }
    }

    internal string ButtonText { get; set; }
    internal bool IsEnabled  { get; set; }
    internal System.Action ButtonAction  { get; set; }
    internal Texture2D ButtonIcon  { get; set; }
    internal PedalOption currentPedalOption  { get; set; }
}