namespace AstroClient.Cheetos
{
    using AstroLibrary.Console;
    using System;
    using UnityEngine;

    public class AntiCrash : GameEvents
    {
        public override void OnAvatarSpawn(VRCAvatarManager avatarManager, GameObject avatar)
        {
            if (avatarManager == null || avatar == null) throw new ArgumentNullException();
            ModConsole.Log($"[AntiCrash] Scanning Avatar");
        }
    }
}