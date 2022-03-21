namespace AstroClient.Tools.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using FavCat.Modules;
    using Il2CppSystem;
    using Il2CppSystem.Net;
    using Startup.Hooks;
    using UdonEditor;
    using UnhollowerBaseLib.Runtime;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using xAstroBoy;
    using xAstroBoy.Utility;
    using Object = Il2CppSystem.Object;

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
                if (player._vrcplayer != null && PlayerUtils.GetApiAvatar((VRCPlayer)player._vrcplayer) != null)
                {
                    return PlayerUtils.GetApiAvatar((VRCPlayer)player._vrcplayer).id;
                }
            }

            return null;
        }

        //internal static void CloneLocalAvatar(this ApiAvatar avatar)
        //{
        //    SoftCloneHook.LocalCloneAvatar(avatar);
        //}

        internal static void ToAvatarDict(this ApiAvatar avatar, System.Action<Il2CppSystem.Object> avatardict)
        {
            if (avatar == null) return;
            ModConsole.DebugLog("Getting ApiContainer Data...");
            Get_ApiContainerData(avatar, (ContainerData) =>
            {
                if (ContainerData != null)
                {
                    ModConsole.DebugLog("Got Converted ApiContainer!");
                    ModConsole.DebugLog("Generating AvatarDict Object...");
                    ToAvatarDict(ContainerData, (avatardata) =>
                    {
                        ModConsole.DebugLog("Generated AvatarDict!");
                        avatardict(avatardata);
                    });
                }

            });
        }

        private static void Get_ApiContainerData(ApiAvatar avtr,
            System.Action<Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>> callback)
        {
            if (avtr == null)
                return; // or throw exception
            avtr.Get(true, new System.Action<ApiContainer>(container =>
            {
                ModConsole.DebugLog("OnSuccess ApiContainer action.");
                if (container == null)
                {
                    ModConsole.DebugLog("ApiContainer is null (Failed!)");
                    return;
                }

                if (container.Data == null)
                {
                    ModConsole.DebugLog("ApiContainer Data is null (Failed!)");
                    return; // you may want to call the callback but with null
                }

                var data =
                    container.Data.Cast<Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>>();
                if (data == null)
                {
                    ModConsole.DebugLog("ApiContainer Data is null (Failed!)");
                    return;
                }
                else
                {
                    ModConsole.DebugLog("ApiContainer Data Has been Converted !");
                    callback(data);
                }

            }), new System.Action<ApiContainer>(container2 =>
            {
                ModConsole.DebugLog("OnFailure ApiContainer action.");
                if (container2 == null)
                {
                    ModConsole.DebugLog("ApiContainer is null (Failed!)");
                    return;
                }

                if (container2.Data == null)
                {
                    ModConsole.DebugLog("ApiContainer Data is null (Failed!)");
                    return; // you may want to call the callback but with null
                }

                var data2 = container2.Data
                    .Cast<Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>>();
                if (data2 == null)
                {
                    ModConsole.DebugLog("ApiContainer Data is null (Failed!)");
                    return;
                }
                else
                {
                    ModConsole.DebugLog("ApiContainer Data Has been Converted !");
                    try
                    {
                        ModConsole.DebugLog(
                            $"OnFailure Converted Data : \n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(container2.Data), Newtonsoft.Json.Formatting.Indented)}");
                    }
                    catch
                    {
                    }

                    callback(data2);
                }
            }), null, false);
        }

        private static void ToAvatarDict(
            Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object> container,
            System.Action<Il2CppSystem.Object> callback)
        {
            if (container != null)
            {
                ModConsole.DebugLog("Got ApiContainer Data! Generating AvatarDict!");
            }
            else
            {
                ModConsole.DebugLog("Got a Empty ApiContainer Data! Failed!");
                return;
            }

            var result = new Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>();
            if (result != null)
            {
                result.System_Collections_IDictionary_Add("id", container["id"]);
                result.System_Collections_IDictionary_Add("assetUrl", container["assetUrl"]);
                result.System_Collections_IDictionary_Add("authorId", container["authorId"]);
                result.System_Collections_IDictionary_Add("authorName", container["authorName"]);
                result.System_Collections_IDictionary_Add("updated_at", container["updated_at"]);
                result.System_Collections_IDictionary_Add("description", container["description"]);
                result.System_Collections_IDictionary_Add("featured", container["featured"]);
                result.System_Collections_IDictionary_Add("imageUrl", container["imageUrl"]);
                result.System_Collections_IDictionary_Add("thumbnailImageUrl", container["thumbnailImageUrl"]);
                result.System_Collections_IDictionary_Add("name", container["name"]);
                result.System_Collections_IDictionary_Add("releaseStatus", container["releaseStatus"]);
                result.System_Collections_IDictionary_Add("version", container["version"]);
                result.System_Collections_IDictionary_Add("tags", container["tags"]);
                result.System_Collections_IDictionary_Add("unityPackages", container["unityPackages"]);
                //    //ModConsole.DebugLog($"Generated AvatarDict \n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(result), Newtonsoft.Json.Formatting.Indented)}");
                callback(result);
            }
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

        internal static List<Collider> GetAllCollidersOnPlayer(Player player)
        {
            var region = player.transform.Find("SelectRegion");
            if (region != null)
            {
                var regioncapsule = player.GetComponent<CapsuleCollider>();
                if (regioncapsule != null)
                {
                    Vector3 pos0 = regioncapsule.transform.position + regioncapsule.transform.up * ((regioncapsule.height / 2) - 2 * regioncapsule.radius);
                    Vector3 pos1 = regioncapsule.transform.position + regioncapsule.transform.up * ((regioncapsule.height / 2) - 2 * regioncapsule.radius) * -1;
                    float radius = regioncapsule.radius;
                    return Physics.OverlapCapsule(pos0, pos1, radius).ToList();
                }

            }

            return null;
        }
    }
}