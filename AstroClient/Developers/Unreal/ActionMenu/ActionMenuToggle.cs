using System;
using AstroClient.ClientResources.Loaders;
using UnityEngine;

namespace AstroClient.Unreal;

internal class ActionMenuToggle 
{
    internal ActionMenuToggle(CustomActionMenu.BaseMenu baseMenu, string buttonText, bool startingState, Action<bool> onToggle)
    {
        this.ButtonText = buttonText;
        this.typeToggleOn = Icons.check;
        this.typeToggleOff = Icons.cancel;
        this.ToggleState = startingState;
        if (startingState)
            SetIcon(typeToggleOn);
        else
            SetIcon(typeToggleOff);

        onToggle += delegate (bool value)
        {
            startingState = !startingState;
            if (startingState)
                SetIcon(typeToggleOn);
            else
                SetIcon(typeToggleOff);
            onToggle.Invoke(startingState);
        };
        this.ButtonAction = onToggle;
        if (baseMenu == CustomActionMenu.BaseMenu.MainMenu)
        {
            CustomActionMenu.ToggleButtons.Add(this);
        }
    }

    internal ActionMenuToggle(ActionMenuPage basePage, string buttonText, bool startingState, Action<bool> onToggle)
    {
        
        this.ButtonText = buttonText;
        this.typeToggleOn = Icons.check;
        this.typeToggleOff = Icons.cancel;
        this.ToggleState = startingState;
        if (startingState) 
            SetIcon(typeToggleOn);
        else
            SetIcon(typeToggleOff);

        onToggle += delegate(bool value)
        {
            startingState = !startingState;
            if (startingState)
                SetIcon(typeToggleOn);
            else
                SetIcon(typeToggleOff);
            onToggle.Invoke(startingState);
        };
        this.ButtonAction = onToggle;
        basePage.Toggles.Add(this);
    }

    internal void SetButtonText(string newText)
    {
        this.ButtonText = newText;
        if (this.currentPedalOption != null)
        {
            this.currentPedalOption.prop_String_0 = newText;
        }
    }

    private void SetIcon(Texture2D newTexture)
    {
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

    internal bool ToggleState { get; set; }
    internal string ButtonText { get; set; }
    internal bool IsEnabled { get; set; }
    internal System.Action<bool> ButtonAction { get; set; }
    internal PedalOption currentPedalOption { get; set; }
    
    internal Texture2D typeToggleOff { get; set; }
    internal Texture2D typeToggleOn { get; set; }

}
