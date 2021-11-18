﻿namespace AstroClient.xAstroBoy.Extensions
{
    using UnityEngine;
    using Utility;
    using VRC;

    public static class ButtonStringExtensions
    {
        public static string Generate_TeleportToMe_ButtonText(this GameObject obj) => $"Teleport to you:\n{(obj != null ? obj.name : "null")}";

        public static string Generate_TeleportToTarget_ButtonText(GameObject obj, Player Target) => $"Teleport\n {(obj != null ? obj.name : "null")} to:\n {(Target != null ? Target.GetAPIUser().displayName : "null")}";
    }
}