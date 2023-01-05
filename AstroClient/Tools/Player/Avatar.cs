namespace AstroClient.Tools.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
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
            Log.Debug("Getting ApiContainer Data...");
            Get_ApiContainerData(avatar, (ContainerData) =>
            {
                if (ContainerData != null)
                {
                    Log.Debug("Got Converted ApiContainer!");
                    Log.Debug("Generating AvatarDict Object...");
                    ToAvatarDict(ContainerData, (avatardata) =>
                    {
                        Log.Debug("Generated AvatarDict!");
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

            var container = avtr.MakeModelContainer();
            if (container != null)
            {
                var ContainerData = container.Data.Cast<Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>>();
                if (ContainerData == null)
                {
                    Log.Debug("ApiContainer Data is null (Failed!)");
                    return;
                }
                else
                {
                    Log.Debug("ApiContainer Data Has been Converted !");
                   Log.Debug( $"OnFailure Converted Data : \n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(ContainerData), Newtonsoft.Json.Formatting.Indented)}");

                    callback(ContainerData);
                }

            }



        }

        private static void ToAvatarDict(
            Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object> container,
            System.Action<Il2CppSystem.Object> callback)
        {
            if (container != null)
            {
                Log.Debug("Got ApiContainer Data! Generating AvatarDict!");
            }
            else
            {
                Log.Debug("Got a Empty ApiContainer Data! Failed!");
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
                //    //Log.Debug($"Generated AvatarDict \n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(result), Newtonsoft.Json.Formatting.Indented)}");
                callback(result);
            }
        }


        internal static Il2CppSystem.Object ToAvatarDict2(ApiAvatar avatar)
        {
            
            if (avatar != null)
            {
                Log.Debug("Got ApiAvatar! Generating AvatarDict!");
            }
            else
            {
                Log.Debug("Got a Empty ApiAvatar! Failed!");
                return null;
            }

            var result = new Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>();
            if (result != null)
            {
                result.System_Collections_IDictionary_Add("id", avatar.id);
                result.System_Collections_IDictionary_Add("assetUrl", "");
                result.System_Collections_IDictionary_Add("authorId", avatar.authorId);
                result.System_Collections_IDictionary_Add("authorName", avatar.authorName);
                result.System_Collections_IDictionary_Add("updated_at", avatar.updated_at.ToString());
                result.System_Collections_IDictionary_Add("description", avatar.description);
                if (avatar.featured)
                {
                    result.System_Collections_IDictionary_Add("featured", avatar.featured.ToString());
                }
                result.System_Collections_IDictionary_Add("imageUrl", avatar.imageUrl);
                result.System_Collections_IDictionary_Add("thumbnailImageUrl", avatar.thumbnailImageUrl);
                result.System_Collections_IDictionary_Add("name", avatar.name);
                result.System_Collections_IDictionary_Add("releaseStatus", avatar.releaseStatus);
                result.System_Collections_IDictionary_Add("version", Il2CppConverter.Generate_Il2CPPObject(avatar.version));
                if(avatar.tags != null)
                {
                    result.System_Collections_IDictionary_Add("tags", avatar.tags);
                }
                else
                {
                    result.System_Collections_IDictionary_Add("tags", new Il2CppSystem.Collections.Generic.List<string>());
                }


                result.System_Collections_IDictionary_Add("unityPackages", BuildUnityPackages(avatar));
                
                Log.Debug($"Generated AvatarDict \n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(result), Newtonsoft.Json.Formatting.Indented)}");
                return result;
            }
            return null;
        }



        private static Il2CppSystem.Object BuildUnityPackages(ApiAvatar avatar)
        {
            if (avatar != null)
            {
                var unityPackages = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

                var UnityPackage1 = new Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>();
                if(UnityPackage1 != null)
                {
                    UnityPackage1.System_Collections_IDictionary_Add("assetUrl", avatar.assetUrl);
                    UnityPackage1.System_Collections_IDictionary_Add("unityVersion", avatar.unityVersion);
                    UnityPackage1.System_Collections_IDictionary_Add("unitySortNumber", Il2CppConverter.Generate_Il2CPPObject(GetUnitySortNumber(avatar.unityVersion)));
                    UnityPackage1.System_Collections_IDictionary_Add("assetVersion", Il2CppConverter.Generate_Il2CPPObject(avatar.assetVersion.ApiVersion));
                    UnityPackage1.System_Collections_IDictionary_Add("platform", avatar.platform);
                    unityPackages.System_Collections_IList_Add(UnityPackage1);
                }
                var UnityPackage2 = new Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>();
                if (UnityPackage2 != null)
                {
                    UnityPackage2.System_Collections_IDictionary_Add("platform", "android");
                    UnityPackage2.System_Collections_IDictionary_Add("unityVersion", "2019.4.31f1");
                    unityPackages.System_Collections_IList_Add(UnityPackage2);
                }





                return unityPackages;
            }
            return null;
        }

        private static double GetUnitySortNumber(string UnityVersion)
        {
            if(UnityVersion.StartsWith("2017"))
            {
                return (double)201704150000;
            }
            if (UnityVersion.StartsWith("2018"))
            {
                return (double)20180420000;
            }
            if (UnityVersion.StartsWith("2019"))
            {
                return (double)201904310000;
            }
            return default(double);
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