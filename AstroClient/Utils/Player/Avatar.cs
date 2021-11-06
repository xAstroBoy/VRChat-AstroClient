namespace AstroClient.AvatarMods
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using UnityEngine;
    using VRC;

    internal static class AvatarUtils
    {
        internal static Transform Get_Avatar(this Transform obj)
        {
            return obj.FindObject("ForwardDirection/Avatar");
        }

        internal static Transform Get_Armature(this Transform obj)
        {
            return obj.FindObject("ForwardDirection/Avatar/Armature");
        }

        internal static Transform Get_Body(this Transform obj)
        {
            return obj.FindObject("ForwardDirection/Avatar/Body");
        }

        internal static Transform Get_root_of_avatar_child(this Transform obj)
        {
            var root = obj.root;
            if (root != null)
            {
                var avatar = root.Get_Avatar();
                if (avatar != null)
                {
                    List<Transform> list = avatar.Get_Childs();
                    for (int i = 0; i < list.Count; i++)
                    {
                        Transform child = list[i];
                        if (obj.IsChildOf(child))
                        {
                            return child;
                        }
                    }
                }
            }
            return null;
        }


        internal static string GetAvatarID(this Player player)
        {
            if (player != null)
            {
                if (player._vrcplayer != null && player._vrcplayer.GetApiAvatar() != null)
                {
                    return player._vrcplayer.GetApiAvatar().id;
                }
            }
            return null;
        }

       

        

        internal static IEnumerator ReloadAllAvatars()
        {
            foreach (var player in WorldUtils.Players)
            {
                if (player != null)
                {
                    player.ReloadAvatar();
                    yield return new WaitForSeconds(0.001f);
                }
            }
            yield break;
        }
    }
}