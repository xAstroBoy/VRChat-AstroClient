namespace AstroClient.Cheetos
{
    using AstroLibrary.Console;
    using System;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    internal class AntiCrash : GameEvents
    {
        internal override void OnAvatarSpawn(Player Player, GameObject Avatar, VRCAvatarManager VRCAvatarManager, VRC_AvatarDescriptor VRC_AvatarDescriptor)
        {
            if (VRCAvatarManager == null || Avatar == null) throw new ArgumentNullException();
            ModConsole.DebugLog($"[AntiCrash] Scanning Avatar");
        }
    }
}