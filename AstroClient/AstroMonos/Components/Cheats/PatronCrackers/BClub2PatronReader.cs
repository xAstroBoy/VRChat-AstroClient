using System.Linq;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.Udon;
using Object = UnityEngine.Object;

namespace AstroClient.AstroMonos.Components.Cheats.PatronCrackers;

using AstroClient.Tools.UdonEditor;
using AstroClient.xAstroBoy.Extensions;
using ClientAttributes;
using UnhollowerBaseLib.Attributes;
using IntPtr = System.IntPtr;

[RegisterComponent]
public class BClub2PatronReader : MonoBehaviour
{
    private readonly Il2CppSystem.Collections.Generic.List<Object> AntiGarbageCollection = new();

    public BClub2PatronReader(IntPtr ptr) : base(ptr)
    {
        AntiGarbageCollection.Add(this);
    }

    private bool _HasSubscribed = false;

    private bool HasSubscribed
    {
        [HideFromIl2Cpp]
        get => _HasSubscribed;
        [HideFromIl2Cpp]
        set
        {
            if (_HasSubscribed != value)
            {
                if (value)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                }
                else
                {
                    ClientEventActions.OnRoomLeft -= OnRoomLeft;
                }
            }
            _HasSubscribed = value;
        }
    }

    private void UdonSendCustomEvent(UdonBehaviour arg1, string arg2)
    {
        if(arg1 != null)
        {
            if (arg1.gameObject.name == gameObject.name)
            {
                HijackUdon();
            }
        }
    }

    private void OnRoomLeft()
    {
        Destroy(this);
    }

    private RawUdonBehaviour ProcessPatronsRaw { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    internal void Start()
    {
        var cam = UdonSearch.FindUdonEvent(this.gameObject, "_ProcessPatrons");
        if (cam != null)
        {
            ProcessPatronsRaw = cam.RawItem;
        }
        if (ProcessPatronsRaw != null)
        {
            HasSubscribed = true;
            Initialize_ProcessPatronsRaw();
            HijackUdon();
        }
        if (ProcessPatronsRaw == null)
        {
            Destroy(this);
        }
    }

    
  
    private string PatchList(string list, string FieldName)
    {
        if (list.IsNotNullOrEmptyOrWhiteSpace())
        {
            bool HasBeenModified = false;
            var result = list.ReadLines().ToList();
            if (result != null && result.Count != 0)
            {
                if (!result.Contains(PlayerSpooferUtils.Original_DisplayName))
                {
                    Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in {FieldName}..");
                    result.Insert(0, PlayerSpooferUtils.Original_DisplayName);
                    result.Insert(result.Count, PlayerSpooferUtils.Original_DisplayName);
                    HasBeenModified = true;
                }
                if (GameInstances.LocalPlayer != null)
                {
                    if (!result.Contains(GameInstances.LocalPlayer.displayName))
                    {
                        Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in {FieldName}..");
                        result.Insert(1, GameInstances.LocalPlayer.displayName);
                        result.Insert(result.Count, GameInstances.LocalPlayer.displayName);
                        HasBeenModified = true;
                    }
                }
            }
            if (HasBeenModified)
            {
                return string.Join("\n", result); ;
            }
        }
        return list;
    }
    internal void HijackUdon()
    {
        
        //if(__0___0__IsSupporter__ret != null)
        //{
        //    if (__0___0__IsSupporter__ret.HasValue)
        //    {
        //        if (!__0___0__IsSupporter__ret.Value)
        //        {
        //            __0___0__IsSupporter__ret = true;
        //        }
        //    }
        //}
        //if (__0___0__IsLegend__ret != null)
        //{
        //    if (__0___0__IsLegend__ret.HasValue)
        //    {
        //        if (!__0___0__IsLegend__ret.Value)
        //        {
        //            __0___0__IsLegend__ret = true;
        //        }
        //    }
        //}
        //if (__0___0__IsVip__ret != null)
        //{
        //    if (__0___0__IsVip__ret.HasValue)
        //    {
        //        if (!__0___0__IsVip__ret.Value)
        //        {
        //            __0___0__IsVip__ret = true;
        //        }
        //    }
        //}
        //if (__0___0__IsElite__ret != null)
        //{
        //    if (__0___0__IsElite__ret.HasValue)
        //    {
        //        if (!__0___0__IsElite__ret.Value)
        //        {
        //            __0___0__IsElite__ret = true;
        //        }
        //    }
        //}
        ////if (__0___0__IsExecutive__ret != null)
        ////{
        ////    if (__0___0__IsExecutive__ret.HasValue)
        ////    {
        ////        if (!__0___0__IsExecutive__ret.Value)
        ////        {
        ////            __0___0__IsExecutive__ret = true;
        ////        }
        ////    }
        ////}
        //if (__0___0__IsMod__ret != null)
        //{
        //    if (__0___0__IsMod__ret.HasValue)
        //    {
        //        if (!__0___0__IsMod__ret.Value)
        //        {
        //            __0___0__IsMod__ret = true;
        //        }
        //    }
        //}

        if (__0_patronsToProcess__param != null)
        {
            var patch = PatchList(__0_patronsToProcess__param, "__0_patronsToProcess__param");
            __0_patronsToProcess__param = patch;
        }
        if (__intnl_SystemString_7 != null)
        {
            var patch = PatchList(__intnl_SystemString_7, "__intnl_SystemString_7");
            __intnl_SystemString_7 = patch;

        }

        if (__intnl_SystemString_8 != null)
        {
            var patch = PatchList(__intnl_SystemString_8, "__intnl_SystemString_8");
            __intnl_SystemString_8 = patch;

        }
        if (__intnl_SystemString_9 != null)
        {
            var patch = PatchList(__intnl_SystemString_9, "__intnl_SystemString_9");
            __intnl_SystemString_9 = patch;

        }


    }
    private void OnDestroy()
    {
        Cleanup_ProcessPatronsRaw();
        HasSubscribed = false;
    }

    private void Initialize_ProcessPatronsRaw()
    {
        Private_modFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "modFlair");
        Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_13");
        Private___intnl_SystemBoolean_23 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_23");
        Private___intnl_SystemBoolean_33 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_33");
        Private___intnl_SystemBoolean_43 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_43");
        Private___gintnl_SystemUInt32_56 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_56");
        Private___gintnl_SystemUInt32_46 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_46");
        Private___gintnl_SystemUInt32_66 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_66");
        Private___gintnl_SystemUInt32_16 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_16");
        Private___gintnl_SystemUInt32_36 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_36");
        Private___gintnl_SystemUInt32_26 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_26");
        Private___intnl_SystemInt32_15 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_15");
        Private___intnl_SystemInt32_35 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_35");
        Private___intnl_SystemInt32_25 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_25");
        Private___intnl_SystemInt32_55 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_55");
        Private___intnl_SystemInt32_45 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_45");
        Private___const_SystemInt64_0 = new AstroUdonVariable<long>(ProcessPatronsRaw, "__const_SystemInt64_0");
        Private___7_player__param = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__7_player__param");
        Private___intnl_SystemString_1 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_1");
        Private___const_SystemString_46 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_46");
        Private___const_SystemString_47 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_47");
        Private___const_SystemString_44 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_44");
        Private___const_SystemString_45 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_45");
        Private___const_SystemString_42 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_42");
        Private___const_SystemString_43 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_43");
        Private___const_SystemString_40 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_40");
        Private___const_SystemString_41 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_41");
        Private___const_SystemString_48 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_48");
        Private___const_SystemString_49 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_49");
        Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(ProcessPatronsRaw, "__intnl_SystemSingle_0");
        Private___const_SystemChar_2 = new AstroUdonVariable<char>(ProcessPatronsRaw, "__const_SystemChar_2");
        Private___intnl_SystemObject_0 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemObject_0");
        Private_creatorFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "creatorFlair");
        Private___0_get_VipOnly__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_get_VipOnly__ret");
        Private_eliteFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "eliteFlair");
        Private_eliteColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "eliteColor");
        Private___const_SystemString_0 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_0");
        Private___intnl_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(ProcessPatronsRaw, "__intnl_UnityEngineTransform_0");
        Private_vipOnlyButton = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "vipOnlyButton");
        Private___gintnl_SystemCharArray_2 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_2");
        Private___gintnl_SystemCharArray_9 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_9");
        Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_16");
        Private___intnl_SystemBoolean_26 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_26");
        Private___intnl_SystemBoolean_36 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_36");
        Private___lcl_j_SystemInt32_0 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__lcl_j_SystemInt32_0");
        Private___intnl_SystemInt32_12 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_12");
        Private___intnl_SystemInt32_32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_32");
        Private___intnl_SystemInt32_22 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_22");
        Private___intnl_SystemInt32_52 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_52");
        Private___intnl_SystemInt32_42 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_42");
        Private___0_newOn__param = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_newOn__param");
        Private___intnl_SystemString_9 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_9");
        Private___gintnl_SystemUInt32_9 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_9");
        Private___gintnl_SystemUInt32_8 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_8");
        Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_5");
        Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_4");
        Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_7");
        Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_6");
        Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_1");
        Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_0");
        Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_3");
        Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_2");
        Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__const_SystemBoolean_0");
        Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__const_SystemBoolean_1");
        Private___0_value__param = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_value__param");
        Private_eliteNames = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "eliteNames");
        Private_executiveColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "executiveColor");
        Private___const_SystemString_5 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_5");
        Private_testPatrons = new AstroUdonVariable<UnityEngine.TextAsset>(ProcessPatronsRaw, "testPatrons");
        Private___gintnl_SystemCharArray_1 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_1");
        Private___0___0__IsElite__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0___0__IsElite__ret");
        Private___0_patronsToProcess__param = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_patronsToProcess__param");
        Private___gintnl_SystemUInt32_53 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_53");
        Private___gintnl_SystemUInt32_43 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_43");
        Private___gintnl_SystemUInt32_63 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_63");
        Private___gintnl_SystemUInt32_13 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_13");
        Private___gintnl_SystemUInt32_33 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_33");
        Private___gintnl_SystemUInt32_23 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_23");
        Private___0_get_TierIndex__ret = new AstroUdonVariable<int>(ProcessPatronsRaw, "__0_get_TierIndex__ret");
        Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(ProcessPatronsRaw, "__const_VRCUdonCommonInterfacesNetworkEventTarget_0");
        Private___intnl_SystemString_6 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_6");
        Private___0_roleVisible__param = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_roleVisible__param");
        Private_vipObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(ProcessPatronsRaw, "vipObjects");
        Private___const_SystemString_16 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_16");
        Private___const_SystemString_17 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_17");
        Private___const_SystemString_14 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_14");
        Private___const_SystemString_15 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_15");
        Private___const_SystemString_12 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_12");
        Private___const_SystemString_13 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_13");
        Private___const_SystemString_10 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_10");
        Private___const_SystemString_11 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_11");
        Private___const_SystemString_18 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_18");
        Private___const_SystemString_19 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_19");
        Private___intnl_VRCSDKBaseVRCPlayerApi_0 = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__intnl_VRCSDKBaseVRCPlayerApi_0");
        Private___refl_typeid = new AstroUdonVariable<long>(ProcessPatronsRaw, "__refl_typeid");
        Private_nonVipObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(ProcessPatronsRaw, "nonVipObjects");
        Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__const_SystemUInt32_0");
        Private___lcl_isPatron_SystemBoolean_0 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__lcl_isPatron_SystemBoolean_0");
        Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_11");
        Private___intnl_SystemBoolean_21 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_21");
        Private___intnl_SystemBoolean_31 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_31");
        Private___intnl_SystemBoolean_41 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_41");
        Private_cyan = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "cyan");
        Private___gintnl_SystemUInt32_54 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_54");
        Private___gintnl_SystemUInt32_44 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_44");
        Private___gintnl_SystemUInt32_64 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_64");
        Private___gintnl_SystemUInt32_14 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_14");
        Private___gintnl_SystemUInt32_34 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_34");
        Private___gintnl_SystemUInt32_24 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_24");
        Private___const_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(ProcessPatronsRaw, "__const_UnityEngineVector3_0");
        Private___intnl_SystemInt32_17 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_17");
        Private___intnl_SystemInt32_37 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_37");
        Private___intnl_SystemInt32_27 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_27");
        Private___intnl_SystemInt32_57 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_57");
        Private___intnl_SystemInt32_47 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_47");
        Private_vipOnlyObjs = new AstroUdonVariable<UnityEngine.GameObject[]>(ProcessPatronsRaw, "vipOnlyObjs");
        Private___intnl_SystemString_3 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_3");
        Private___lcl_button_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__lcl_button_VRCUdonUdonBehaviour_0");
        Private_AvatarImageDecoder = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "AvatarImageDecoder");
        Private___const_SystemString_60 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_60");
        Private___const_SystemString_2 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_2");
        Private___gintnl_SystemCharArray_4 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_4");
        Private_joinSoundCreator = new AstroUdonVariable<UnityEngine.AudioClip>(ProcessPatronsRaw, "joinSoundCreator");
        Private___intnl_SystemBoolean_19 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_19");
        Private___intnl_SystemBoolean_29 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_29");
        Private___intnl_SystemBoolean_39 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_39");
        Private___intnl_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(ProcessPatronsRaw, "__intnl_UnityEngineVector3_0");
        Private_joinSoundElite = new AstroUdonVariable<UnityEngine.AudioClip>(ProcessPatronsRaw, "joinSoundElite");
        Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_14");
        Private___intnl_SystemBoolean_24 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_24");
        Private___intnl_SystemBoolean_34 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_34");
        Private___intnl_SystemInt32_14 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_14");
        Private___intnl_SystemInt32_34 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_34");
        Private___intnl_SystemInt32_24 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_24");
        Private___intnl_SystemInt32_54 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_54");
        Private___intnl_SystemInt32_44 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_44");
        Private_players = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "players");
        Private___0_names__param = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__0_names__param");
        Private_eliteIds = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "eliteIds");
        Private___intnl_SystemInt32_19 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_19");
        Private___intnl_SystemInt32_39 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_39");
        Private___intnl_SystemInt32_29 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_29");
        Private___intnl_SystemInt32_49 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_49");
        Private___intnl_SystemString_0 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_0");
        Private___0___0__IsLegend__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0___0__IsLegend__ret");
        Private___const_SystemChar_1 = new AstroUdonVariable<char>(ProcessPatronsRaw, "__const_SystemChar_1");
        Private___lcl_groups_SystemStringArray_0 = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__lcl_groups_SystemStringArray_0");
        Private_myInstance = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "myInstance");
        Private___0___0__IsInList__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0___0__IsInList__ret");
        Private___const_SystemString_7 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_7");
        Private___gintnl_SystemCharArray_3 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_3");
        Private___gintnl_SystemUInt32_51 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_51");
        Private___gintnl_SystemUInt32_41 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_41");
        Private___gintnl_SystemUInt32_61 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_61");
        Private___gintnl_SystemUInt32_11 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_11");
        Private___gintnl_SystemUInt32_31 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_31");
        Private___gintnl_SystemUInt32_21 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_21");
        Private___intnl_SystemBoolean_17 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_17");
        Private___intnl_SystemBoolean_27 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_27");
        Private___intnl_SystemBoolean_37 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_37");
        Private___const_VRCUdonCommonEnumsEventTiming_0 = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(ProcessPatronsRaw, "__const_VRCUdonCommonEnumsEventTiming_0");
        Private___intnl_SystemInt32_11 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_11");
        Private___intnl_SystemInt32_31 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_31");
        Private___intnl_SystemInt32_21 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_21");
        Private___intnl_SystemInt32_51 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_51");
        Private___intnl_SystemInt32_41 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_41");
        Private___lcl_allElites_SystemStringArray_0 = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__lcl_allElites_SystemStringArray_0");
        Private_mods = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "mods");
        Private___intnl_SystemString_8 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_8");
        Private___lcl_newOn_SystemBoolean_0 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__lcl_newOn_SystemBoolean_0");
        Private___0___0__IsSupporter__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0___0__IsSupporter__ret");
        Private___const_SystemString_36 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_36");
        Private___const_SystemString_37 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_37");
        Private___const_SystemString_34 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_34");
        Private___const_SystemString_35 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_35");
        Private___const_SystemString_32 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_32");
        Private___const_SystemString_33 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_33");
        Private___const_SystemString_30 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_30");
        Private___const_SystemString_31 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_31");
        Private___const_SystemString_38 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_38");
        Private___const_SystemString_39 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_39");
        Private_ready = new AstroUdonVariable<bool>(ProcessPatronsRaw, "ready");
        Private___0___0__IsVip__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0___0__IsVip__ret");
        Private___intnl_SystemInt64_0 = new AstroUdonVariable<long>(ProcessPatronsRaw, "__intnl_SystemInt64_0");
        Private_vipColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "vipColor");
        Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__intnl_returnJump_SystemUInt32_0");
        Private_joinSoundVip = new AstroUdonVariable<UnityEngine.AudioClip>(ProcessPatronsRaw, "joinSoundVip");
        Private__old__vipOnly = new AstroUdonVariable<bool>(ProcessPatronsRaw, "_old__vipOnly");
        Private___const_SystemString_4 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_4");
        Private___lcl_result_SystemBoolean_0 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__lcl_result_SystemBoolean_0");
        Private___gintnl_SystemUInt32_59 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_59");
        Private___gintnl_SystemUInt32_49 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_49");
        Private___gintnl_SystemUInt32_19 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_19");
        Private___gintnl_SystemUInt32_39 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_39");
        Private___gintnl_SystemUInt32_29 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_29");
        Private_param = new AstroUdonVariable<string>(ProcessPatronsRaw, "param");
        Private___gintnl_SystemUInt32_52 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_52");
        Private___gintnl_SystemUInt32_42 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_42");
        Private___gintnl_SystemUInt32_62 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_62");
        Private___gintnl_SystemUInt32_12 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_12");
        Private___gintnl_SystemUInt32_32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_32");
        Private___gintnl_SystemUInt32_22 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_22");
        Private___lcl_i_SystemInt32_1 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__lcl_i_SystemInt32_1");
        Private___lcl_i_SystemInt32_0 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__lcl_i_SystemInt32_0");
        Private___lcl_i_SystemInt32_3 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__lcl_i_SystemInt32_3");
        Private___lcl_i_SystemInt32_2 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__lcl_i_SystemInt32_2");
        Private___lcl_i_SystemInt32_5 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__lcl_i_SystemInt32_5");
        Private___lcl_i_SystemInt32_4 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__lcl_i_SystemInt32_4");
        Private___intnl_SystemString_5 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_5");
        Private___intnl_SystemStringArray_1 = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__intnl_SystemStringArray_1");
        Private___intnl_SystemStringArray_0 = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__intnl_SystemStringArray_0");
        Private___gintnl_SystemCharArray_6 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_6");
        Private___const_SystemString_9 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_9");
        Private_vipFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "vipFlair");
        Private___intnl_SystemString_49 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_49");
        Private___intnl_SystemString_44 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_44");
        Private___intnl_SystemString_45 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_45");
        Private___intnl_SystemString_43 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_43");
        Private___intnl_SystemString_40 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_40");
        Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_12");
        Private___intnl_SystemBoolean_22 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_22");
        Private___intnl_SystemBoolean_32 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_32");
        Private___intnl_SystemBoolean_42 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_42");
        Private___gintnl_SystemUInt32_57 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_57");
        Private___gintnl_SystemUInt32_47 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_47");
        Private___gintnl_SystemUInt32_67 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_67");
        Private___gintnl_SystemUInt32_17 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_17");
        Private___gintnl_SystemUInt32_37 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_37");
        Private___gintnl_SystemUInt32_27 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_27");
        Private___const_UnityEngineVector3_1 = new AstroUdonVariable<UnityEngine.Vector3>(ProcessPatronsRaw, "__const_UnityEngineVector3_1");
        Private___intnl_SystemInt32_16 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_16");
        Private___intnl_SystemInt32_36 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_36");
        Private___intnl_SystemInt32_26 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_26");
        Private___intnl_SystemInt32_56 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_56");
        Private___intnl_SystemInt32_46 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_46");
        Private___refl_typename = new AstroUdonVariable<string>(ProcessPatronsRaw, "__refl_typename");
        Private_elites = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "elites");
        Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_1");
        Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_0");
        Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_3");
        Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_2");
        Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_5");
        Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_4");
        Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_7");
        Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_6");
        Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_9");
        Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_8");
        Private_legendFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "legendFlair");
        Private_patreonBoard = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "patreonBoard");
        Private___const_SystemString_56 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_56");
        Private___const_SystemString_57 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_57");
        Private___const_SystemString_54 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_54");
        Private___const_SystemString_55 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_55");
        Private___const_SystemString_52 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_52");
        Private___const_SystemString_53 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_53");
        Private___const_SystemString_50 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_50");
        Private___const_SystemString_51 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_51");
        Private___const_SystemString_58 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_58");
        Private___const_SystemString_59 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_59");
        Private___gintnl_SystemCharArray_20 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_20");
        Private___gintnl_SystemCharArray_21 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_21");
        Private___gintnl_SystemCharArray_22 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_22");
        Private___const_SystemChar_3 = new AstroUdonVariable<char>(ProcessPatronsRaw, "__const_SystemChar_3");
        Private___lcl_targetID_SystemInt64_0 = new AstroUdonVariable<long>(ProcessPatronsRaw, "__lcl_targetID_SystemInt64_0");
        Private___const_SystemString_1 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_1");
        Private___gintnl_SystemCharArray_5 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_5");
        Private___intnl_SystemString_14 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_14");
        Private___intnl_SystemString_15 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_15");
        Private___intnl_SystemString_12 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_12");
        Private___intnl_SystemString_13 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_13");
        Private___intnl_SystemString_10 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_10");
        Private___intnl_SystemString_11 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_11");
        Private___gintnl_SystemCharArray_8 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_8");
        Private__old__tierIndex = new AstroUdonVariable<int>(ProcessPatronsRaw, "_old__tierIndex");
        Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_15");
        Private___intnl_SystemBoolean_25 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_25");
        Private___intnl_SystemBoolean_35 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_35");
        Private___intnl_SystemInt32_13 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_13");
        Private___intnl_SystemInt32_33 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_33");
        Private___intnl_SystemInt32_23 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_23");
        Private___intnl_SystemInt32_53 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_53");
        Private___intnl_SystemInt32_43 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_43");
        Private___intnl_SystemInt32_18 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_18");
        Private___intnl_SystemInt32_38 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_38");
        Private___intnl_SystemInt32_28 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_28");
        Private___intnl_SystemInt32_58 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_58");
        Private___intnl_SystemInt32_48 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_48");
        Private___gintnl_SystemCharArray_14 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_14");
        Private___gintnl_SystemCharArray_15 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_15");
        Private___gintnl_SystemCharArray_16 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_16");
        Private___gintnl_SystemCharArray_17 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_17");
        Private___gintnl_SystemCharArray_10 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_10");
        Private___gintnl_SystemCharArray_11 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_11");
        Private___gintnl_SystemCharArray_12 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_12");
        Private___gintnl_SystemCharArray_13 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_13");
        Private___gintnl_SystemCharArray_18 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_18");
        Private___gintnl_SystemCharArray_19 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_19");
        Private___const_SystemChar_0 = new AstroUdonVariable<char>(ProcessPatronsRaw, "__const_SystemChar_0");
        Private___0___0__IsMod__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0___0__IsMod__ret");
        Private_audio2d = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "audio2d");
        Private___const_SystemString_6 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_6");
        Private___gintnl_SystemCharArray_0 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_0");
        Private_specialColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "specialColor");
        Private_modColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "modColor");
        Private___gintnl_SystemUInt32_50 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_50");
        Private___gintnl_SystemUInt32_40 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_40");
        Private___gintnl_SystemUInt32_60 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_60");
        Private___gintnl_SystemUInt32_10 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_10");
        Private___gintnl_SystemUInt32_30 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_30");
        Private___gintnl_SystemUInt32_20 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_20");
        Private_vipAndMasterButtons = new AstroUdonVariable<UnityEngine.Component[]>(ProcessPatronsRaw, "vipAndMasterButtons");
        Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_10");
        Private___intnl_SystemInt32_30 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_30");
        Private___intnl_SystemInt32_20 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_20");
        Private___intnl_SystemInt32_50 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_50");
        Private___intnl_SystemInt32_40 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__intnl_SystemInt32_40");
        Private___0___0__IsExecutive__ret = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0___0__IsExecutive__ret");
        Private___intnl_SystemString_7 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_7");
        Private_localPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "localPlayer");
        Private___0___0__GetColor__ret = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "__0___0__GetColor__ret");
        Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(ProcessPatronsRaw, "__this_UnityEngineGameObject_0");
        Private___1_value__param = new AstroUdonVariable<int>(ProcessPatronsRaw, "__1_value__param");
        Private___const_SystemString_26 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_26");
        Private___const_SystemString_27 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_27");
        Private___const_SystemString_24 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_24");
        Private___const_SystemString_25 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_25");
        Private___const_SystemString_22 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_22");
        Private___const_SystemString_23 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_23");
        Private___const_SystemString_20 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_20");
        Private___const_SystemString_21 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_21");
        Private___const_SystemString_28 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_28");
        Private___const_SystemString_29 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_29");
        Private_defaultColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "defaultColor");
        Private___lcl_isSupporter_SystemBoolean_0 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__lcl_isSupporter_SystemBoolean_0");
        Private___lcl_hiddenElites_SystemStringArray_0 = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__lcl_hiddenElites_SystemStringArray_0");
        Private___gintnl_SystemUInt32_58 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_58");
        Private___gintnl_SystemUInt32_48 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_48");
        Private___gintnl_SystemUInt32_18 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_18");
        Private___gintnl_SystemUInt32_38 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_38");
        Private___gintnl_SystemUInt32_28 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_28");
        Private___lcl_x_SystemString_0 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__lcl_x_SystemString_0");
        Private_eliteJoinSounds = new AstroUdonVariable<UnityEngine.AudioClip[]>(ProcessPatronsRaw, "eliteJoinSounds");
        Private_legendColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "legendColor");
        Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_10");
        Private___intnl_SystemBoolean_20 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_20");
        Private___intnl_SystemBoolean_30 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_30");
        Private___intnl_SystemBoolean_40 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_40");
        Private___lcl_name_SystemString_0 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__lcl_name_SystemString_0");
        Private___gintnl_SystemUInt32_55 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_55");
        Private___gintnl_SystemUInt32_45 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_45");
        Private___gintnl_SystemUInt32_65 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_65");
        Private___gintnl_SystemUInt32_15 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_15");
        Private___gintnl_SystemUInt32_35 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_35");
        Private___gintnl_SystemUInt32_25 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__gintnl_SystemUInt32_25");
        Private___const_SystemInt32_1 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_1");
        Private___const_SystemInt32_0 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_0");
        Private___const_SystemInt32_3 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_3");
        Private___const_SystemInt32_2 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_2");
        Private___const_SystemInt32_5 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_5");
        Private___const_SystemInt32_4 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_4");
        Private___const_SystemInt32_7 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_7");
        Private___const_SystemInt32_6 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__const_SystemInt32_6");
        Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_8");
        Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_9");
        Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_0");
        Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_1");
        Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_2");
        Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_3");
        Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_4");
        Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_5");
        Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_6");
        Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_7");
        Private_executiveFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "executiveFlair");
        Private___intnl_SystemString_4 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_4");
        Private__tierIndex = new AstroUdonVariable<int>(ProcessPatronsRaw, "_tierIndex");
        Private__vipOnly = new AstroUdonVariable<bool>(ProcessPatronsRaw, "_vipOnly");
        Private_rooms = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "rooms");
        Private_vipOnlyForNonVipsObjs = new AstroUdonVariable<UnityEngine.GameObject[]>(ProcessPatronsRaw, "vipOnlyForNonVipsObjs");
        Private___const_SystemString_3 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_3");
        Private___this_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__this_VRCUdonUdonBehaviour_3");
        Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__this_VRCUdonUdonBehaviour_2");
        Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__this_VRCUdonUdonBehaviour_1");
        Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__this_VRCUdonUdonBehaviour_0");
        Private___this_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__this_VRCUdonUdonBehaviour_4");
        Private___2_names__param = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__2_names__param");
        Private___gintnl_SystemCharArray_7 = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__gintnl_SystemCharArray_7");
        Private___const_SystemString_8 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__const_SystemString_8");
        Private___intnl_SystemBoolean_18 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_18");
        Private___intnl_SystemBoolean_28 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_28");
        Private___intnl_SystemBoolean_38 = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__intnl_SystemBoolean_38");
        Private___intnl_SystemString_39 = new AstroUdonVariable<string>(ProcessPatronsRaw, "__intnl_SystemString_39");
    }

    private void Cleanup_ProcessPatronsRaw()
    {
        Private_modFlair = null;
        Private___intnl_SystemBoolean_13 = null;
        Private___intnl_SystemBoolean_23 = null;
        Private___intnl_SystemBoolean_33 = null;
        Private___intnl_SystemBoolean_43 = null;
        Private___gintnl_SystemUInt32_56 = null;
        Private___gintnl_SystemUInt32_46 = null;
        Private___gintnl_SystemUInt32_66 = null;
        Private___gintnl_SystemUInt32_16 = null;
        Private___gintnl_SystemUInt32_36 = null;
        Private___gintnl_SystemUInt32_26 = null;
        Private___intnl_SystemInt32_15 = null;
        Private___intnl_SystemInt32_35 = null;
        Private___intnl_SystemInt32_25 = null;
        Private___intnl_SystemInt32_55 = null;
        Private___intnl_SystemInt32_45 = null;
        Private___const_SystemInt64_0 = null;
        Private___7_player__param = null;
        Private___intnl_SystemString_1 = null;
        Private___const_SystemString_46 = null;
        Private___const_SystemString_47 = null;
        Private___const_SystemString_44 = null;
        Private___const_SystemString_45 = null;
        Private___const_SystemString_42 = null;
        Private___const_SystemString_43 = null;
        Private___const_SystemString_40 = null;
        Private___const_SystemString_41 = null;
        Private___const_SystemString_48 = null;
        Private___const_SystemString_49 = null;
        Private___intnl_SystemSingle_0 = null;
        Private___const_SystemChar_2 = null;
        Private___intnl_SystemObject_0 = null;
        Private_creatorFlair = null;
        Private___0_get_VipOnly__ret = null;
        Private_eliteFlair = null;
        Private_eliteColor = null;
        Private___const_SystemString_0 = null;
        Private___intnl_UnityEngineTransform_0 = null;
        Private_vipOnlyButton = null;
        Private___gintnl_SystemCharArray_2 = null;
        Private___gintnl_SystemCharArray_9 = null;
        Private___intnl_SystemBoolean_16 = null;
        Private___intnl_SystemBoolean_26 = null;
        Private___intnl_SystemBoolean_36 = null;
        Private___lcl_j_SystemInt32_0 = null;
        Private___intnl_SystemInt32_12 = null;
        Private___intnl_SystemInt32_32 = null;
        Private___intnl_SystemInt32_22 = null;
        Private___intnl_SystemInt32_52 = null;
        Private___intnl_SystemInt32_42 = null;
        Private___0_newOn__param = null;
        Private___intnl_SystemString_9 = null;
        Private___gintnl_SystemUInt32_9 = null;
        Private___gintnl_SystemUInt32_8 = null;
        Private___gintnl_SystemUInt32_5 = null;
        Private___gintnl_SystemUInt32_4 = null;
        Private___gintnl_SystemUInt32_7 = null;
        Private___gintnl_SystemUInt32_6 = null;
        Private___gintnl_SystemUInt32_1 = null;
        Private___gintnl_SystemUInt32_0 = null;
        Private___gintnl_SystemUInt32_3 = null;
        Private___gintnl_SystemUInt32_2 = null;
        Private___const_SystemBoolean_0 = null;
        Private___const_SystemBoolean_1 = null;
        Private___0_value__param = null;
        Private_eliteNames = null;
        Private_executiveColor = null;
        Private___const_SystemString_5 = null;
        Private_testPatrons = null;
        Private___gintnl_SystemCharArray_1 = null;
        Private___0___0__IsElite__ret = null;
        Private___0_patronsToProcess__param = null;
        Private___gintnl_SystemUInt32_53 = null;
        Private___gintnl_SystemUInt32_43 = null;
        Private___gintnl_SystemUInt32_63 = null;
        Private___gintnl_SystemUInt32_13 = null;
        Private___gintnl_SystemUInt32_33 = null;
        Private___gintnl_SystemUInt32_23 = null;
        Private___0_get_TierIndex__ret = null;
        Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = null;
        Private___intnl_SystemString_6 = null;
        Private___0_roleVisible__param = null;
        Private_vipObjects = null;
        Private___const_SystemString_16 = null;
        Private___const_SystemString_17 = null;
        Private___const_SystemString_14 = null;
        Private___const_SystemString_15 = null;
        Private___const_SystemString_12 = null;
        Private___const_SystemString_13 = null;
        Private___const_SystemString_10 = null;
        Private___const_SystemString_11 = null;
        Private___const_SystemString_18 = null;
        Private___const_SystemString_19 = null;
        Private___intnl_VRCSDKBaseVRCPlayerApi_0 = null;
        Private___refl_typeid = null;
        Private_nonVipObjects = null;
        Private___const_SystemUInt32_0 = null;
        Private___lcl_isPatron_SystemBoolean_0 = null;
        Private___intnl_SystemBoolean_11 = null;
        Private___intnl_SystemBoolean_21 = null;
        Private___intnl_SystemBoolean_31 = null;
        Private___intnl_SystemBoolean_41 = null;
        Private_cyan = null;
        Private___gintnl_SystemUInt32_54 = null;
        Private___gintnl_SystemUInt32_44 = null;
        Private___gintnl_SystemUInt32_64 = null;
        Private___gintnl_SystemUInt32_14 = null;
        Private___gintnl_SystemUInt32_34 = null;
        Private___gintnl_SystemUInt32_24 = null;
        Private___const_UnityEngineVector3_0 = null;
        Private___intnl_SystemInt32_17 = null;
        Private___intnl_SystemInt32_37 = null;
        Private___intnl_SystemInt32_27 = null;
        Private___intnl_SystemInt32_57 = null;
        Private___intnl_SystemInt32_47 = null;
        Private_vipOnlyObjs = null;
        Private___intnl_SystemString_3 = null;
        Private___lcl_button_VRCUdonUdonBehaviour_0 = null;
        Private_AvatarImageDecoder = null;
        Private___const_SystemString_60 = null;
        Private___const_SystemString_2 = null;
        Private___gintnl_SystemCharArray_4 = null;
        Private_joinSoundCreator = null;
        Private___intnl_SystemBoolean_19 = null;
        Private___intnl_SystemBoolean_29 = null;
        Private___intnl_SystemBoolean_39 = null;
        Private___intnl_UnityEngineVector3_0 = null;
        Private_joinSoundElite = null;
        Private___intnl_SystemBoolean_14 = null;
        Private___intnl_SystemBoolean_24 = null;
        Private___intnl_SystemBoolean_34 = null;
        Private___intnl_SystemInt32_14 = null;
        Private___intnl_SystemInt32_34 = null;
        Private___intnl_SystemInt32_24 = null;
        Private___intnl_SystemInt32_54 = null;
        Private___intnl_SystemInt32_44 = null;
        Private_players = null;
        Private___0_names__param = null;
        Private_eliteIds = null;
        Private___intnl_SystemInt32_19 = null;
        Private___intnl_SystemInt32_39 = null;
        Private___intnl_SystemInt32_29 = null;
        Private___intnl_SystemInt32_49 = null;
        Private___intnl_SystemString_0 = null;
        Private___0___0__IsLegend__ret = null;
        Private___const_SystemChar_1 = null;
        Private___lcl_groups_SystemStringArray_0 = null;
        Private_myInstance = null;
        Private___0___0__IsInList__ret = null;
        Private___const_SystemString_7 = null;
        Private___gintnl_SystemCharArray_3 = null;
        Private___gintnl_SystemUInt32_51 = null;
        Private___gintnl_SystemUInt32_41 = null;
        Private___gintnl_SystemUInt32_61 = null;
        Private___gintnl_SystemUInt32_11 = null;
        Private___gintnl_SystemUInt32_31 = null;
        Private___gintnl_SystemUInt32_21 = null;
        Private___intnl_SystemBoolean_17 = null;
        Private___intnl_SystemBoolean_27 = null;
        Private___intnl_SystemBoolean_37 = null;
        Private___const_VRCUdonCommonEnumsEventTiming_0 = null;
        Private___intnl_SystemInt32_11 = null;
        Private___intnl_SystemInt32_31 = null;
        Private___intnl_SystemInt32_21 = null;
        Private___intnl_SystemInt32_51 = null;
        Private___intnl_SystemInt32_41 = null;
        Private___lcl_allElites_SystemStringArray_0 = null;
        Private_mods = null;
        Private___intnl_SystemString_8 = null;
        Private___lcl_newOn_SystemBoolean_0 = null;
        Private___0___0__IsSupporter__ret = null;
        Private___const_SystemString_36 = null;
        Private___const_SystemString_37 = null;
        Private___const_SystemString_34 = null;
        Private___const_SystemString_35 = null;
        Private___const_SystemString_32 = null;
        Private___const_SystemString_33 = null;
        Private___const_SystemString_30 = null;
        Private___const_SystemString_31 = null;
        Private___const_SystemString_38 = null;
        Private___const_SystemString_39 = null;
        Private_ready = null;
        Private___0___0__IsVip__ret = null;
        Private___intnl_SystemInt64_0 = null;
        Private_vipColor = null;
        Private___intnl_returnJump_SystemUInt32_0 = null;
        Private_joinSoundVip = null;
        Private__old__vipOnly = null;
        Private___const_SystemString_4 = null;
        Private___lcl_result_SystemBoolean_0 = null;
        Private___gintnl_SystemUInt32_59 = null;
        Private___gintnl_SystemUInt32_49 = null;
        Private___gintnl_SystemUInt32_19 = null;
        Private___gintnl_SystemUInt32_39 = null;
        Private___gintnl_SystemUInt32_29 = null;
        Private_param = null;
        Private___gintnl_SystemUInt32_52 = null;
        Private___gintnl_SystemUInt32_42 = null;
        Private___gintnl_SystemUInt32_62 = null;
        Private___gintnl_SystemUInt32_12 = null;
        Private___gintnl_SystemUInt32_32 = null;
        Private___gintnl_SystemUInt32_22 = null;
        Private___lcl_i_SystemInt32_1 = null;
        Private___lcl_i_SystemInt32_0 = null;
        Private___lcl_i_SystemInt32_3 = null;
        Private___lcl_i_SystemInt32_2 = null;
        Private___lcl_i_SystemInt32_5 = null;
        Private___lcl_i_SystemInt32_4 = null;
        Private___intnl_SystemString_5 = null;
        Private___intnl_SystemStringArray_1 = null;
        Private___intnl_SystemStringArray_0 = null;
        Private___gintnl_SystemCharArray_6 = null;
        Private___const_SystemString_9 = null;
        Private_vipFlair = null;
        Private___intnl_SystemString_49 = null;
        Private___intnl_SystemString_44 = null;
        Private___intnl_SystemString_45 = null;
        Private___intnl_SystemString_43 = null;
        Private___intnl_SystemString_40 = null;
        Private___intnl_SystemBoolean_12 = null;
        Private___intnl_SystemBoolean_22 = null;
        Private___intnl_SystemBoolean_32 = null;
        Private___intnl_SystemBoolean_42 = null;
        Private___gintnl_SystemUInt32_57 = null;
        Private___gintnl_SystemUInt32_47 = null;
        Private___gintnl_SystemUInt32_67 = null;
        Private___gintnl_SystemUInt32_17 = null;
        Private___gintnl_SystemUInt32_37 = null;
        Private___gintnl_SystemUInt32_27 = null;
        Private___const_UnityEngineVector3_1 = null;
        Private___intnl_SystemInt32_16 = null;
        Private___intnl_SystemInt32_36 = null;
        Private___intnl_SystemInt32_26 = null;
        Private___intnl_SystemInt32_56 = null;
        Private___intnl_SystemInt32_46 = null;
        Private___refl_typename = null;
        Private_elites = null;
        Private___intnl_SystemInt32_1 = null;
        Private___intnl_SystemInt32_0 = null;
        Private___intnl_SystemInt32_3 = null;
        Private___intnl_SystemInt32_2 = null;
        Private___intnl_SystemInt32_5 = null;
        Private___intnl_SystemInt32_4 = null;
        Private___intnl_SystemInt32_7 = null;
        Private___intnl_SystemInt32_6 = null;
        Private___intnl_SystemInt32_9 = null;
        Private___intnl_SystemInt32_8 = null;
        Private_legendFlair = null;
        Private_patreonBoard = null;
        Private___const_SystemString_56 = null;
        Private___const_SystemString_57 = null;
        Private___const_SystemString_54 = null;
        Private___const_SystemString_55 = null;
        Private___const_SystemString_52 = null;
        Private___const_SystemString_53 = null;
        Private___const_SystemString_50 = null;
        Private___const_SystemString_51 = null;
        Private___const_SystemString_58 = null;
        Private___const_SystemString_59 = null;
        Private___gintnl_SystemCharArray_20 = null;
        Private___gintnl_SystemCharArray_21 = null;
        Private___gintnl_SystemCharArray_22 = null;
        Private___const_SystemChar_3 = null;
        Private___lcl_targetID_SystemInt64_0 = null;
        Private___const_SystemString_1 = null;
        Private___gintnl_SystemCharArray_5 = null;
        Private___intnl_SystemString_14 = null;
        Private___intnl_SystemString_15 = null;
        Private___intnl_SystemString_12 = null;
        Private___intnl_SystemString_13 = null;
        Private___intnl_SystemString_10 = null;
        Private___intnl_SystemString_11 = null;
        Private___gintnl_SystemCharArray_8 = null;
        Private__old__tierIndex = null;
        Private___intnl_SystemBoolean_15 = null;
        Private___intnl_SystemBoolean_25 = null;
        Private___intnl_SystemBoolean_35 = null;
        Private___intnl_SystemInt32_13 = null;
        Private___intnl_SystemInt32_33 = null;
        Private___intnl_SystemInt32_23 = null;
        Private___intnl_SystemInt32_53 = null;
        Private___intnl_SystemInt32_43 = null;
        Private___intnl_SystemInt32_18 = null;
        Private___intnl_SystemInt32_38 = null;
        Private___intnl_SystemInt32_28 = null;
        Private___intnl_SystemInt32_58 = null;
        Private___intnl_SystemInt32_48 = null;
        Private___gintnl_SystemCharArray_14 = null;
        Private___gintnl_SystemCharArray_15 = null;
        Private___gintnl_SystemCharArray_16 = null;
        Private___gintnl_SystemCharArray_17 = null;
        Private___gintnl_SystemCharArray_10 = null;
        Private___gintnl_SystemCharArray_11 = null;
        Private___gintnl_SystemCharArray_12 = null;
        Private___gintnl_SystemCharArray_13 = null;
        Private___gintnl_SystemCharArray_18 = null;
        Private___gintnl_SystemCharArray_19 = null;
        Private___const_SystemChar_0 = null;
        Private___0___0__IsMod__ret = null;
        Private_audio2d = null;
        Private___const_SystemString_6 = null;
        Private___gintnl_SystemCharArray_0 = null;
        Private_specialColor = null;
        Private_modColor = null;
        Private___gintnl_SystemUInt32_50 = null;
        Private___gintnl_SystemUInt32_40 = null;
        Private___gintnl_SystemUInt32_60 = null;
        Private___gintnl_SystemUInt32_10 = null;
        Private___gintnl_SystemUInt32_30 = null;
        Private___gintnl_SystemUInt32_20 = null;
        Private_vipAndMasterButtons = null;
        Private___intnl_SystemInt32_10 = null;
        Private___intnl_SystemInt32_30 = null;
        Private___intnl_SystemInt32_20 = null;
        Private___intnl_SystemInt32_50 = null;
        Private___intnl_SystemInt32_40 = null;
        Private___0___0__IsExecutive__ret = null;
        Private___intnl_SystemString_7 = null;
        Private_localPlayer = null;
        Private___0___0__GetColor__ret = null;
        Private___this_UnityEngineGameObject_0 = null;
        Private___1_value__param = null;
        Private___const_SystemString_26 = null;
        Private___const_SystemString_27 = null;
        Private___const_SystemString_24 = null;
        Private___const_SystemString_25 = null;
        Private___const_SystemString_22 = null;
        Private___const_SystemString_23 = null;
        Private___const_SystemString_20 = null;
        Private___const_SystemString_21 = null;
        Private___const_SystemString_28 = null;
        Private___const_SystemString_29 = null;
        Private_defaultColor = null;
        Private___lcl_isSupporter_SystemBoolean_0 = null;
        Private___lcl_hiddenElites_SystemStringArray_0 = null;
        Private___gintnl_SystemUInt32_58 = null;
        Private___gintnl_SystemUInt32_48 = null;
        Private___gintnl_SystemUInt32_18 = null;
        Private___gintnl_SystemUInt32_38 = null;
        Private___gintnl_SystemUInt32_28 = null;
        Private___lcl_x_SystemString_0 = null;
        Private_eliteJoinSounds = null;
        Private_legendColor = null;
        Private___intnl_SystemBoolean_10 = null;
        Private___intnl_SystemBoolean_20 = null;
        Private___intnl_SystemBoolean_30 = null;
        Private___intnl_SystemBoolean_40 = null;
        Private___lcl_name_SystemString_0 = null;
        Private___gintnl_SystemUInt32_55 = null;
        Private___gintnl_SystemUInt32_45 = null;
        Private___gintnl_SystemUInt32_65 = null;
        Private___gintnl_SystemUInt32_15 = null;
        Private___gintnl_SystemUInt32_35 = null;
        Private___gintnl_SystemUInt32_25 = null;
        Private___const_SystemInt32_1 = null;
        Private___const_SystemInt32_0 = null;
        Private___const_SystemInt32_3 = null;
        Private___const_SystemInt32_2 = null;
        Private___const_SystemInt32_5 = null;
        Private___const_SystemInt32_4 = null;
        Private___const_SystemInt32_7 = null;
        Private___const_SystemInt32_6 = null;
        Private___intnl_SystemBoolean_8 = null;
        Private___intnl_SystemBoolean_9 = null;
        Private___intnl_SystemBoolean_0 = null;
        Private___intnl_SystemBoolean_1 = null;
        Private___intnl_SystemBoolean_2 = null;
        Private___intnl_SystemBoolean_3 = null;
        Private___intnl_SystemBoolean_4 = null;
        Private___intnl_SystemBoolean_5 = null;
        Private___intnl_SystemBoolean_6 = null;
        Private___intnl_SystemBoolean_7 = null;
        Private_executiveFlair = null;
        Private___intnl_SystemString_4 = null;
        Private__tierIndex = null;
        Private__vipOnly = null;
        Private_rooms = null;
        Private_vipOnlyForNonVipsObjs = null;
        Private___const_SystemString_3 = null;
        Private___this_VRCUdonUdonBehaviour_3 = null;
        Private___this_VRCUdonUdonBehaviour_2 = null;
        Private___this_VRCUdonUdonBehaviour_1 = null;
        Private___this_VRCUdonUdonBehaviour_0 = null;
        Private___this_VRCUdonUdonBehaviour_4 = null;
        Private___2_names__param = null;
        Private___gintnl_SystemCharArray_7 = null;
        Private___const_SystemString_8 = null;
        Private___intnl_SystemBoolean_18 = null;
        Private___intnl_SystemBoolean_28 = null;
        Private___intnl_SystemBoolean_38 = null;
        Private___intnl_SystemString_39 = null;
    }

    #region Getter / Setters AstroUdonVariables  of ProcessPatronsRaw

    internal UnityEngine.Sprite modFlair
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_modFlair != null)
            {
                return Private_modFlair.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_modFlair != null)
            {
                Private_modFlair.Value = value;
            }
        }
    }

    internal bool? __intnl_SystemBoolean_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_13 != null)
            {
                return Private___intnl_SystemBoolean_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_13 != null)
                {
                    Private___intnl_SystemBoolean_13.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_23
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_23 != null)
            {
                return Private___intnl_SystemBoolean_23.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_23 != null)
                {
                    Private___intnl_SystemBoolean_23.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_33
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_33 != null)
            {
                return Private___intnl_SystemBoolean_33.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_33 != null)
                {
                    Private___intnl_SystemBoolean_33.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_43
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_43 != null)
            {
                return Private___intnl_SystemBoolean_43.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_43 != null)
                {
                    Private___intnl_SystemBoolean_43.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_56
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_56 != null)
            {
                return Private___gintnl_SystemUInt32_56.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_56 != null)
                {
                    Private___gintnl_SystemUInt32_56.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_46
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_46 != null)
            {
                return Private___gintnl_SystemUInt32_46.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_46 != null)
                {
                    Private___gintnl_SystemUInt32_46.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_66
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_66 != null)
            {
                return Private___gintnl_SystemUInt32_66.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_66 != null)
                {
                    Private___gintnl_SystemUInt32_66.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_16
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_16 != null)
            {
                return Private___gintnl_SystemUInt32_16.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_16 != null)
                {
                    Private___gintnl_SystemUInt32_16.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_36
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_36 != null)
            {
                return Private___gintnl_SystemUInt32_36.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_36 != null)
                {
                    Private___gintnl_SystemUInt32_36.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_26
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_26 != null)
            {
                return Private___gintnl_SystemUInt32_26.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_26 != null)
                {
                    Private___gintnl_SystemUInt32_26.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_15 != null)
            {
                return Private___intnl_SystemInt32_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_15 != null)
                {
                    Private___intnl_SystemInt32_15.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_35
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_35 != null)
            {
                return Private___intnl_SystemInt32_35.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_35 != null)
                {
                    Private___intnl_SystemInt32_35.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_25
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_25 != null)
            {
                return Private___intnl_SystemInt32_25.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_25 != null)
                {
                    Private___intnl_SystemInt32_25.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_55
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_55 != null)
            {
                return Private___intnl_SystemInt32_55.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_55 != null)
                {
                    Private___intnl_SystemInt32_55.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_45
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_45 != null)
            {
                return Private___intnl_SystemInt32_45.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_45 != null)
                {
                    Private___intnl_SystemInt32_45.Value = value.Value;
                }
            }
        }
    }

    internal long? __const_SystemInt64_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt64_0 != null)
            {
                return Private___const_SystemInt64_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt64_0 != null)
                {
                    Private___const_SystemInt64_0.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __7_player__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_player__param != null)
            {
                return Private___7_player__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___7_player__param != null)
            {
                Private___7_player__param.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_1 != null)
            {
                return Private___intnl_SystemString_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_1 != null)
            {
                Private___intnl_SystemString_1.Value = value;
            }
        }
    }

    internal string __const_SystemString_46
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_46 != null)
            {
                return Private___const_SystemString_46.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_46 != null)
            {
                Private___const_SystemString_46.Value = value;
            }
        }
    }

    internal string __const_SystemString_47
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_47 != null)
            {
                return Private___const_SystemString_47.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_47 != null)
            {
                Private___const_SystemString_47.Value = value;
            }
        }
    }

    internal string __const_SystemString_44
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_44 != null)
            {
                return Private___const_SystemString_44.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_44 != null)
            {
                Private___const_SystemString_44.Value = value;
            }
        }
    }

    internal string __const_SystemString_45
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_45 != null)
            {
                return Private___const_SystemString_45.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_45 != null)
            {
                Private___const_SystemString_45.Value = value;
            }
        }
    }

    internal string __const_SystemString_42
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_42 != null)
            {
                return Private___const_SystemString_42.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_42 != null)
            {
                Private___const_SystemString_42.Value = value;
            }
        }
    }

    internal string __const_SystemString_43
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_43 != null)
            {
                return Private___const_SystemString_43.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_43 != null)
            {
                Private___const_SystemString_43.Value = value;
            }
        }
    }

    internal string __const_SystemString_40
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_40 != null)
            {
                return Private___const_SystemString_40.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_40 != null)
            {
                Private___const_SystemString_40.Value = value;
            }
        }
    }

    internal string __const_SystemString_41
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_41 != null)
            {
                return Private___const_SystemString_41.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_41 != null)
            {
                Private___const_SystemString_41.Value = value;
            }
        }
    }

    internal string __const_SystemString_48
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_48 != null)
            {
                return Private___const_SystemString_48.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_48 != null)
            {
                Private___const_SystemString_48.Value = value;
            }
        }
    }

    internal string __const_SystemString_49
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_49 != null)
            {
                return Private___const_SystemString_49.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_49 != null)
            {
                Private___const_SystemString_49.Value = value;
            }
        }
    }

    internal float? __intnl_SystemSingle_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemSingle_0 != null)
            {
                return Private___intnl_SystemSingle_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemSingle_0 != null)
                {
                    Private___intnl_SystemSingle_0.Value = value.Value;
                }
            }
        }
    }

    internal char? __const_SystemChar_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemChar_2 != null)
            {
                return Private___const_SystemChar_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemChar_2 != null)
                {
                    Private___const_SystemChar_2.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemObject_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemObject_0 != null)
            {
                return Private___intnl_SystemObject_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemObject_0 != null)
            {
                Private___intnl_SystemObject_0.Value = value;
            }
        }
    }

    internal UnityEngine.Sprite creatorFlair
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_creatorFlair != null)
            {
                return Private_creatorFlair.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_creatorFlair != null)
            {
                Private_creatorFlair.Value = value;
            }
        }
    }

    internal bool? __0_get_VipOnly__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_get_VipOnly__ret != null)
            {
                return Private___0_get_VipOnly__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_get_VipOnly__ret != null)
                {
                    Private___0_get_VipOnly__ret.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Sprite eliteFlair
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteFlair != null)
            {
                return Private_eliteFlair.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteFlair != null)
            {
                Private_eliteFlair.Value = value;
            }
        }
    }

    internal UnityEngine.Color? eliteColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteColor != null)
            {
                return Private_eliteColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_eliteColor != null)
                {
                    Private_eliteColor.Value = value.Value;
                }
            }
        }
    }

    internal string __const_SystemString_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_0 != null)
            {
                return Private___const_SystemString_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_0 != null)
            {
                Private___const_SystemString_0.Value = value;
            }
        }
    }

    internal UnityEngine.Transform __intnl_UnityEngineTransform_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineTransform_0 != null)
            {
                return Private___intnl_UnityEngineTransform_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_UnityEngineTransform_0 != null)
            {
                Private___intnl_UnityEngineTransform_0.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour vipOnlyButton
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipOnlyButton != null)
            {
                return Private_vipOnlyButton.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipOnlyButton != null)
            {
                Private_vipOnlyButton.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_2 != null)
            {
                return Private___gintnl_SystemCharArray_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_2 != null)
            {
                Private___gintnl_SystemCharArray_2.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_9
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_9 != null)
            {
                return Private___gintnl_SystemCharArray_9.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_9 != null)
            {
                Private___gintnl_SystemCharArray_9.Value = value;
            }
        }
    }

    internal bool? __intnl_SystemBoolean_16
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_16 != null)
            {
                return Private___intnl_SystemBoolean_16.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_16 != null)
                {
                    Private___intnl_SystemBoolean_16.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_26
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_26 != null)
            {
                return Private___intnl_SystemBoolean_26.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_26 != null)
                {
                    Private___intnl_SystemBoolean_26.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_36
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_36 != null)
            {
                return Private___intnl_SystemBoolean_36.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_36 != null)
                {
                    Private___intnl_SystemBoolean_36.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_j_SystemInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_j_SystemInt32_0 != null)
            {
                return Private___lcl_j_SystemInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_j_SystemInt32_0 != null)
                {
                    Private___lcl_j_SystemInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_12 != null)
            {
                return Private___intnl_SystemInt32_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_12 != null)
                {
                    Private___intnl_SystemInt32_12.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_32 != null)
            {
                return Private___intnl_SystemInt32_32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_32 != null)
                {
                    Private___intnl_SystemInt32_32.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_22
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_22 != null)
            {
                return Private___intnl_SystemInt32_22.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_22 != null)
                {
                    Private___intnl_SystemInt32_22.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_52
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_52 != null)
            {
                return Private___intnl_SystemInt32_52.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_52 != null)
                {
                    Private___intnl_SystemInt32_52.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_42
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_42 != null)
            {
                return Private___intnl_SystemInt32_42.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_42 != null)
                {
                    Private___intnl_SystemInt32_42.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0_newOn__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_newOn__param != null)
            {
                return Private___0_newOn__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_newOn__param != null)
                {
                    Private___0_newOn__param.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemString_9
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_9 != null)
            {
                return Private___intnl_SystemString_9.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_9 != null)
            {
                Private___intnl_SystemString_9.Value = value;
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_9
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_9 != null)
            {
                return Private___gintnl_SystemUInt32_9.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_9 != null)
                {
                    Private___gintnl_SystemUInt32_9.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_8
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_8 != null)
            {
                return Private___gintnl_SystemUInt32_8.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_8 != null)
                {
                    Private___gintnl_SystemUInt32_8.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_5 != null)
            {
                return Private___gintnl_SystemUInt32_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_5 != null)
                {
                    Private___gintnl_SystemUInt32_5.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_4 != null)
            {
                return Private___gintnl_SystemUInt32_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_4 != null)
                {
                    Private___gintnl_SystemUInt32_4.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_7
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_7 != null)
            {
                return Private___gintnl_SystemUInt32_7.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_7 != null)
                {
                    Private___gintnl_SystemUInt32_7.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_6
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_6 != null)
            {
                return Private___gintnl_SystemUInt32_6.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_6 != null)
                {
                    Private___gintnl_SystemUInt32_6.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_1 != null)
            {
                return Private___gintnl_SystemUInt32_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_1 != null)
                {
                    Private___gintnl_SystemUInt32_1.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_0 != null)
            {
                return Private___gintnl_SystemUInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_0 != null)
                {
                    Private___gintnl_SystemUInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_3 != null)
            {
                return Private___gintnl_SystemUInt32_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_3 != null)
                {
                    Private___gintnl_SystemUInt32_3.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_2 != null)
            {
                return Private___gintnl_SystemUInt32_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_2 != null)
                {
                    Private___gintnl_SystemUInt32_2.Value = value.Value;
                }
            }
        }
    }

    internal bool? __const_SystemBoolean_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemBoolean_0 != null)
            {
                return Private___const_SystemBoolean_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemBoolean_0 != null)
                {
                    Private___const_SystemBoolean_0.Value = value.Value;
                }
            }
        }
    }

    internal bool? __const_SystemBoolean_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemBoolean_1 != null)
            {
                return Private___const_SystemBoolean_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemBoolean_1 != null)
                {
                    Private___const_SystemBoolean_1.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0_value__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_value__param != null)
            {
                return Private___0_value__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_value__param != null)
                {
                    Private___0_value__param.Value = value.Value;
                }
            }
        }
    }

    internal string[] eliteNames
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteNames != null)
            {
                return Private_eliteNames.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteNames != null)
            {
                Private_eliteNames.Value = value;
            }
        }
    }

    internal UnityEngine.Color? executiveColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_executiveColor != null)
            {
                return Private_executiveColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_executiveColor != null)
                {
                    Private_executiveColor.Value = value.Value;
                }
            }
        }
    }

    internal string __const_SystemString_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_5 != null)
            {
                return Private___const_SystemString_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_5 != null)
            {
                Private___const_SystemString_5.Value = value;
            }
        }
    }

    internal UnityEngine.TextAsset testPatrons
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_testPatrons != null)
            {
                return Private_testPatrons.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_testPatrons != null)
            {
                Private_testPatrons.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_1 != null)
            {
                return Private___gintnl_SystemCharArray_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_1 != null)
            {
                Private___gintnl_SystemCharArray_1.Value = value;
            }
        }
    }

    internal bool? __0___0__IsElite__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__IsElite__ret != null)
            {
                return Private___0___0__IsElite__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__IsElite__ret != null)
                {
                    Private___0___0__IsElite__ret.Value = value.Value;
                }
            }
        }
    }

    internal string __0_patronsToProcess__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_patronsToProcess__param != null)
            {
                return Private___0_patronsToProcess__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_patronsToProcess__param != null)
            {
                Private___0_patronsToProcess__param.Value = value;
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_53
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_53 != null)
            {
                return Private___gintnl_SystemUInt32_53.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_53 != null)
                {
                    Private___gintnl_SystemUInt32_53.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_43
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_43 != null)
            {
                return Private___gintnl_SystemUInt32_43.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_43 != null)
                {
                    Private___gintnl_SystemUInt32_43.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_63
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_63 != null)
            {
                return Private___gintnl_SystemUInt32_63.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_63 != null)
                {
                    Private___gintnl_SystemUInt32_63.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_13 != null)
            {
                return Private___gintnl_SystemUInt32_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_13 != null)
                {
                    Private___gintnl_SystemUInt32_13.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_33
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_33 != null)
            {
                return Private___gintnl_SystemUInt32_33.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_33 != null)
                {
                    Private___gintnl_SystemUInt32_33.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_23
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_23 != null)
            {
                return Private___gintnl_SystemUInt32_23.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_23 != null)
                {
                    Private___gintnl_SystemUInt32_23.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_get_TierIndex__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_get_TierIndex__ret != null)
            {
                return Private___0_get_TierIndex__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_get_TierIndex__ret != null)
                {
                    Private___0_get_TierIndex__ret.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.Common.Interfaces.NetworkEventTarget? __const_VRCUdonCommonInterfacesNetworkEventTarget_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 != null)
            {
                return Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 != null)
                {
                    Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemString_6
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_6 != null)
            {
                return Private___intnl_SystemString_6.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_6 != null)
            {
                Private___intnl_SystemString_6.Value = value;
            }
        }
    }

    internal bool? __0_roleVisible__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_roleVisible__param != null)
            {
                return Private___0_roleVisible__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_roleVisible__param != null)
                {
                    Private___0_roleVisible__param.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject[] vipObjects
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipObjects != null)
            {
                return Private_vipObjects.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipObjects != null)
            {
                Private_vipObjects.Value = value;
            }
        }
    }

    internal string __const_SystemString_16
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_16 != null)
            {
                return Private___const_SystemString_16.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_16 != null)
            {
                Private___const_SystemString_16.Value = value;
            }
        }
    }

    internal string __const_SystemString_17
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_17 != null)
            {
                return Private___const_SystemString_17.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_17 != null)
            {
                Private___const_SystemString_17.Value = value;
            }
        }
    }

    internal string __const_SystemString_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_14 != null)
            {
                return Private___const_SystemString_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_14 != null)
            {
                Private___const_SystemString_14.Value = value;
            }
        }
    }

    internal string __const_SystemString_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_15 != null)
            {
                return Private___const_SystemString_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_15 != null)
            {
                Private___const_SystemString_15.Value = value;
            }
        }
    }

    internal string __const_SystemString_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_12 != null)
            {
                return Private___const_SystemString_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_12 != null)
            {
                Private___const_SystemString_12.Value = value;
            }
        }
    }

    internal string __const_SystemString_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_13 != null)
            {
                return Private___const_SystemString_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_13 != null)
            {
                Private___const_SystemString_13.Value = value;
            }
        }
    }

    internal string __const_SystemString_10
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_10 != null)
            {
                return Private___const_SystemString_10.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_10 != null)
            {
                Private___const_SystemString_10.Value = value;
            }
        }
    }

    internal string __const_SystemString_11
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_11 != null)
            {
                return Private___const_SystemString_11.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_11 != null)
            {
                Private___const_SystemString_11.Value = value;
            }
        }
    }

    internal string __const_SystemString_18
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_18 != null)
            {
                return Private___const_SystemString_18.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_18 != null)
            {
                Private___const_SystemString_18.Value = value;
            }
        }
    }

    internal string __const_SystemString_19
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_19 != null)
            {
                return Private___const_SystemString_19.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_19 != null)
            {
                Private___const_SystemString_19.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __intnl_VRCSDKBaseVRCPlayerApi_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_VRCSDKBaseVRCPlayerApi_0 != null)
            {
                return Private___intnl_VRCSDKBaseVRCPlayerApi_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_VRCSDKBaseVRCPlayerApi_0 != null)
            {
                Private___intnl_VRCSDKBaseVRCPlayerApi_0.Value = value;
            }
        }
    }

    internal long? __refl_typeid
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___refl_typeid != null)
            {
                return Private___refl_typeid.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___refl_typeid != null)
                {
                    Private___refl_typeid.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject[] nonVipObjects
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_nonVipObjects != null)
            {
                return Private_nonVipObjects.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_nonVipObjects != null)
            {
                Private_nonVipObjects.Value = value;
            }
        }
    }

    internal uint? __const_SystemUInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemUInt32_0 != null)
            {
                return Private___const_SystemUInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemUInt32_0 != null)
                {
                    Private___const_SystemUInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal bool? __lcl_isPatron_SystemBoolean_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_isPatron_SystemBoolean_0 != null)
            {
                return Private___lcl_isPatron_SystemBoolean_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_isPatron_SystemBoolean_0 != null)
                {
                    Private___lcl_isPatron_SystemBoolean_0.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_11
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_11 != null)
            {
                return Private___intnl_SystemBoolean_11.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_11 != null)
                {
                    Private___intnl_SystemBoolean_11.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_21
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_21 != null)
            {
                return Private___intnl_SystemBoolean_21.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_21 != null)
                {
                    Private___intnl_SystemBoolean_21.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_31
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_31 != null)
            {
                return Private___intnl_SystemBoolean_31.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_31 != null)
                {
                    Private___intnl_SystemBoolean_31.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_41
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_41 != null)
            {
                return Private___intnl_SystemBoolean_41.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_41 != null)
                {
                    Private___intnl_SystemBoolean_41.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour cyan
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_cyan != null)
            {
                return Private_cyan.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_cyan != null)
            {
                Private_cyan.Value = value;
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_54
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_54 != null)
            {
                return Private___gintnl_SystemUInt32_54.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_54 != null)
                {
                    Private___gintnl_SystemUInt32_54.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_44
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_44 != null)
            {
                return Private___gintnl_SystemUInt32_44.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_44 != null)
                {
                    Private___gintnl_SystemUInt32_44.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_64
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_64 != null)
            {
                return Private___gintnl_SystemUInt32_64.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_64 != null)
                {
                    Private___gintnl_SystemUInt32_64.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_14 != null)
            {
                return Private___gintnl_SystemUInt32_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_14 != null)
                {
                    Private___gintnl_SystemUInt32_14.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_34
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_34 != null)
            {
                return Private___gintnl_SystemUInt32_34.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_34 != null)
                {
                    Private___gintnl_SystemUInt32_34.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_24
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_24 != null)
            {
                return Private___gintnl_SystemUInt32_24.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_24 != null)
                {
                    Private___gintnl_SystemUInt32_24.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Vector3? __const_UnityEngineVector3_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_UnityEngineVector3_0 != null)
            {
                return Private___const_UnityEngineVector3_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_UnityEngineVector3_0 != null)
                {
                    Private___const_UnityEngineVector3_0.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_17
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_17 != null)
            {
                return Private___intnl_SystemInt32_17.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_17 != null)
                {
                    Private___intnl_SystemInt32_17.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_37
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_37 != null)
            {
                return Private___intnl_SystemInt32_37.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_37 != null)
                {
                    Private___intnl_SystemInt32_37.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_27
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_27 != null)
            {
                return Private___intnl_SystemInt32_27.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_27 != null)
                {
                    Private___intnl_SystemInt32_27.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_57
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_57 != null)
            {
                return Private___intnl_SystemInt32_57.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_57 != null)
                {
                    Private___intnl_SystemInt32_57.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_47
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_47 != null)
            {
                return Private___intnl_SystemInt32_47.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_47 != null)
                {
                    Private___intnl_SystemInt32_47.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject[] vipOnlyObjs
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipOnlyObjs != null)
            {
                return Private_vipOnlyObjs.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipOnlyObjs != null)
            {
                Private_vipOnlyObjs.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_3 != null)
            {
                return Private___intnl_SystemString_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_3 != null)
            {
                Private___intnl_SystemString_3.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __lcl_button_VRCUdonUdonBehaviour_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_button_VRCUdonUdonBehaviour_0 != null)
            {
                return Private___lcl_button_VRCUdonUdonBehaviour_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_button_VRCUdonUdonBehaviour_0 != null)
            {
                Private___lcl_button_VRCUdonUdonBehaviour_0.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour AvatarImageDecoder
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_AvatarImageDecoder != null)
            {
                return Private_AvatarImageDecoder.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_AvatarImageDecoder != null)
            {
                Private_AvatarImageDecoder.Value = value;
            }
        }
    }

    internal string __const_SystemString_60
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_60 != null)
            {
                return Private___const_SystemString_60.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_60 != null)
            {
                Private___const_SystemString_60.Value = value;
            }
        }
    }

    internal string __const_SystemString_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_2 != null)
            {
                return Private___const_SystemString_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_2 != null)
            {
                Private___const_SystemString_2.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_4 != null)
            {
                return Private___gintnl_SystemCharArray_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_4 != null)
            {
                Private___gintnl_SystemCharArray_4.Value = value;
            }
        }
    }

    internal UnityEngine.AudioClip joinSoundCreator
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_joinSoundCreator != null)
            {
                return Private_joinSoundCreator.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_joinSoundCreator != null)
            {
                Private_joinSoundCreator.Value = value;
            }
        }
    }

    internal bool? __intnl_SystemBoolean_19
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_19 != null)
            {
                return Private___intnl_SystemBoolean_19.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_19 != null)
                {
                    Private___intnl_SystemBoolean_19.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_29
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_29 != null)
            {
                return Private___intnl_SystemBoolean_29.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_29 != null)
                {
                    Private___intnl_SystemBoolean_29.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_39
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_39 != null)
            {
                return Private___intnl_SystemBoolean_39.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_39 != null)
                {
                    Private___intnl_SystemBoolean_39.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Vector3? __intnl_UnityEngineVector3_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineVector3_0 != null)
            {
                return Private___intnl_UnityEngineVector3_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_UnityEngineVector3_0 != null)
                {
                    Private___intnl_UnityEngineVector3_0.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.AudioClip joinSoundElite
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_joinSoundElite != null)
            {
                return Private_joinSoundElite.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_joinSoundElite != null)
            {
                Private_joinSoundElite.Value = value;
            }
        }
    }

    internal bool? __intnl_SystemBoolean_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_14 != null)
            {
                return Private___intnl_SystemBoolean_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_14 != null)
                {
                    Private___intnl_SystemBoolean_14.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_24
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_24 != null)
            {
                return Private___intnl_SystemBoolean_24.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_24 != null)
                {
                    Private___intnl_SystemBoolean_24.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_34
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_34 != null)
            {
                return Private___intnl_SystemBoolean_34.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_34 != null)
                {
                    Private___intnl_SystemBoolean_34.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_14 != null)
            {
                return Private___intnl_SystemInt32_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_14 != null)
                {
                    Private___intnl_SystemInt32_14.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_34
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_34 != null)
            {
                return Private___intnl_SystemInt32_34.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_34 != null)
                {
                    Private___intnl_SystemInt32_34.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_24
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_24 != null)
            {
                return Private___intnl_SystemInt32_24.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_24 != null)
                {
                    Private___intnl_SystemInt32_24.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_54
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_54 != null)
            {
                return Private___intnl_SystemInt32_54.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_54 != null)
                {
                    Private___intnl_SystemInt32_54.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_44
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_44 != null)
            {
                return Private___intnl_SystemInt32_44.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_44 != null)
                {
                    Private___intnl_SystemInt32_44.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour players
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_players != null)
            {
                return Private_players.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_players != null)
            {
                Private_players.Value = value;
            }
        }
    }

    internal string[] __0_names__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_names__param != null)
            {
                return Private___0_names__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_names__param != null)
            {
                Private___0_names__param.Value = value;
            }
        }
    }

    internal string[] eliteIds
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteIds != null)
            {
                return Private_eliteIds.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteIds != null)
            {
                Private_eliteIds.Value = value;
            }
        }
    }

    internal int? __intnl_SystemInt32_19
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_19 != null)
            {
                return Private___intnl_SystemInt32_19.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_19 != null)
                {
                    Private___intnl_SystemInt32_19.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_39
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_39 != null)
            {
                return Private___intnl_SystemInt32_39.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_39 != null)
                {
                    Private___intnl_SystemInt32_39.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_29
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_29 != null)
            {
                return Private___intnl_SystemInt32_29.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_29 != null)
                {
                    Private___intnl_SystemInt32_29.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_49
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_49 != null)
            {
                return Private___intnl_SystemInt32_49.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_49 != null)
                {
                    Private___intnl_SystemInt32_49.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemString_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_0 != null)
            {
                return Private___intnl_SystemString_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_0 != null)
            {
                Private___intnl_SystemString_0.Value = value;
            }
        }
    }

    internal bool? __0___0__IsLegend__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__IsLegend__ret != null)
            {
                return Private___0___0__IsLegend__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__IsLegend__ret != null)
                {
                    Private___0___0__IsLegend__ret.Value = value.Value;
                }
            }
        }
    }

    internal char? __const_SystemChar_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemChar_1 != null)
            {
                return Private___const_SystemChar_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemChar_1 != null)
                {
                    Private___const_SystemChar_1.Value = value.Value;
                }
            }
        }
    }

    internal string[] __lcl_groups_SystemStringArray_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_groups_SystemStringArray_0 != null)
            {
                return Private___lcl_groups_SystemStringArray_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_groups_SystemStringArray_0 != null)
            {
                Private___lcl_groups_SystemStringArray_0.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour myInstance
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_myInstance != null)
            {
                return Private_myInstance.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_myInstance != null)
            {
                Private_myInstance.Value = value;
            }
        }
    }

    internal bool? __0___0__IsInList__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__IsInList__ret != null)
            {
                return Private___0___0__IsInList__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__IsInList__ret != null)
                {
                    Private___0___0__IsInList__ret.Value = value.Value;
                }
            }
        }
    }

    internal string __const_SystemString_7
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_7 != null)
            {
                return Private___const_SystemString_7.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_7 != null)
            {
                Private___const_SystemString_7.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_3 != null)
            {
                return Private___gintnl_SystemCharArray_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_3 != null)
            {
                Private___gintnl_SystemCharArray_3.Value = value;
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_51
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_51 != null)
            {
                return Private___gintnl_SystemUInt32_51.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_51 != null)
                {
                    Private___gintnl_SystemUInt32_51.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_41
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_41 != null)
            {
                return Private___gintnl_SystemUInt32_41.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_41 != null)
                {
                    Private___gintnl_SystemUInt32_41.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_61
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_61 != null)
            {
                return Private___gintnl_SystemUInt32_61.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_61 != null)
                {
                    Private___gintnl_SystemUInt32_61.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_11
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_11 != null)
            {
                return Private___gintnl_SystemUInt32_11.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_11 != null)
                {
                    Private___gintnl_SystemUInt32_11.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_31
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_31 != null)
            {
                return Private___gintnl_SystemUInt32_31.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_31 != null)
                {
                    Private___gintnl_SystemUInt32_31.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_21
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_21 != null)
            {
                return Private___gintnl_SystemUInt32_21.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_21 != null)
                {
                    Private___gintnl_SystemUInt32_21.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_17
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_17 != null)
            {
                return Private___intnl_SystemBoolean_17.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_17 != null)
                {
                    Private___intnl_SystemBoolean_17.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_27
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_27 != null)
            {
                return Private___intnl_SystemBoolean_27.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_27 != null)
                {
                    Private___intnl_SystemBoolean_27.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_37
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_37 != null)
            {
                return Private___intnl_SystemBoolean_37.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_37 != null)
                {
                    Private___intnl_SystemBoolean_37.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.Common.Enums.EventTiming? __const_VRCUdonCommonEnumsEventTiming_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_VRCUdonCommonEnumsEventTiming_0 != null)
            {
                return Private___const_VRCUdonCommonEnumsEventTiming_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_VRCUdonCommonEnumsEventTiming_0 != null)
                {
                    Private___const_VRCUdonCommonEnumsEventTiming_0.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_11
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_11 != null)
            {
                return Private___intnl_SystemInt32_11.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_11 != null)
                {
                    Private___intnl_SystemInt32_11.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_31
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_31 != null)
            {
                return Private___intnl_SystemInt32_31.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_31 != null)
                {
                    Private___intnl_SystemInt32_31.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_21
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_21 != null)
            {
                return Private___intnl_SystemInt32_21.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_21 != null)
                {
                    Private___intnl_SystemInt32_21.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_51
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_51 != null)
            {
                return Private___intnl_SystemInt32_51.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_51 != null)
                {
                    Private___intnl_SystemInt32_51.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_41
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_41 != null)
            {
                return Private___intnl_SystemInt32_41.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_41 != null)
                {
                    Private___intnl_SystemInt32_41.Value = value.Value;
                }
            }
        }
    }

    internal string[] __lcl_allElites_SystemStringArray_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_allElites_SystemStringArray_0 != null)
            {
                return Private___lcl_allElites_SystemStringArray_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_allElites_SystemStringArray_0 != null)
            {
                Private___lcl_allElites_SystemStringArray_0.Value = value;
            }
        }
    }

    internal string[] mods
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_mods != null)
            {
                return Private_mods.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_mods != null)
            {
                Private_mods.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_8
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_8 != null)
            {
                return Private___intnl_SystemString_8.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_8 != null)
            {
                Private___intnl_SystemString_8.Value = value;
            }
        }
    }

    internal bool? __lcl_newOn_SystemBoolean_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_newOn_SystemBoolean_0 != null)
            {
                return Private___lcl_newOn_SystemBoolean_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_newOn_SystemBoolean_0 != null)
                {
                    Private___lcl_newOn_SystemBoolean_0.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0___0__IsSupporter__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__IsSupporter__ret != null)
            {
                return Private___0___0__IsSupporter__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__IsSupporter__ret != null)
                {
                    Private___0___0__IsSupporter__ret.Value = value.Value;
                }
            }
        }
    }

    internal string __const_SystemString_36
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_36 != null)
            {
                return Private___const_SystemString_36.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_36 != null)
            {
                Private___const_SystemString_36.Value = value;
            }
        }
    }

    internal string __const_SystemString_37
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_37 != null)
            {
                return Private___const_SystemString_37.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_37 != null)
            {
                Private___const_SystemString_37.Value = value;
            }
        }
    }

    internal string __const_SystemString_34
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_34 != null)
            {
                return Private___const_SystemString_34.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_34 != null)
            {
                Private___const_SystemString_34.Value = value;
            }
        }
    }

    internal string __const_SystemString_35
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_35 != null)
            {
                return Private___const_SystemString_35.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_35 != null)
            {
                Private___const_SystemString_35.Value = value;
            }
        }
    }

    internal string __const_SystemString_32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_32 != null)
            {
                return Private___const_SystemString_32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_32 != null)
            {
                Private___const_SystemString_32.Value = value;
            }
        }
    }

    internal string __const_SystemString_33
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_33 != null)
            {
                return Private___const_SystemString_33.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_33 != null)
            {
                Private___const_SystemString_33.Value = value;
            }
        }
    }

    internal string __const_SystemString_30
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_30 != null)
            {
                return Private___const_SystemString_30.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_30 != null)
            {
                Private___const_SystemString_30.Value = value;
            }
        }
    }

    internal string __const_SystemString_31
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_31 != null)
            {
                return Private___const_SystemString_31.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_31 != null)
            {
                Private___const_SystemString_31.Value = value;
            }
        }
    }

    internal string __const_SystemString_38
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_38 != null)
            {
                return Private___const_SystemString_38.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_38 != null)
            {
                Private___const_SystemString_38.Value = value;
            }
        }
    }

    internal string __const_SystemString_39
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_39 != null)
            {
                return Private___const_SystemString_39.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_39 != null)
            {
                Private___const_SystemString_39.Value = value;
            }
        }
    }

    internal bool? ready
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_ready != null)
            {
                return Private_ready.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_ready != null)
                {
                    Private_ready.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0___0__IsVip__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__IsVip__ret != null)
            {
                return Private___0___0__IsVip__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__IsVip__ret != null)
                {
                    Private___0___0__IsVip__ret.Value = value.Value;
                }
            }
        }
    }

    internal long? __intnl_SystemInt64_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt64_0 != null)
            {
                return Private___intnl_SystemInt64_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt64_0 != null)
                {
                    Private___intnl_SystemInt64_0.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Color? vipColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipColor != null)
            {
                return Private_vipColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_vipColor != null)
                {
                    Private_vipColor.Value = value.Value;
                }
            }
        }
    }

    internal uint? __intnl_returnJump_SystemUInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_returnJump_SystemUInt32_0 != null)
            {
                return Private___intnl_returnJump_SystemUInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_returnJump_SystemUInt32_0 != null)
                {
                    Private___intnl_returnJump_SystemUInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.AudioClip joinSoundVip
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_joinSoundVip != null)
            {
                return Private_joinSoundVip.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_joinSoundVip != null)
            {
                Private_joinSoundVip.Value = value;
            }
        }
    }

    internal bool? _old__vipOnly
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private__old__vipOnly != null)
            {
                return Private__old__vipOnly.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private__old__vipOnly != null)
                {
                    Private__old__vipOnly.Value = value.Value;
                }
            }
        }
    }

    internal string __const_SystemString_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_4 != null)
            {
                return Private___const_SystemString_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_4 != null)
            {
                Private___const_SystemString_4.Value = value;
            }
        }
    }

    internal bool? __lcl_result_SystemBoolean_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_result_SystemBoolean_0 != null)
            {
                return Private___lcl_result_SystemBoolean_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_result_SystemBoolean_0 != null)
                {
                    Private___lcl_result_SystemBoolean_0.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_59
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_59 != null)
            {
                return Private___gintnl_SystemUInt32_59.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_59 != null)
                {
                    Private___gintnl_SystemUInt32_59.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_49
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_49 != null)
            {
                return Private___gintnl_SystemUInt32_49.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_49 != null)
                {
                    Private___gintnl_SystemUInt32_49.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_19
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_19 != null)
            {
                return Private___gintnl_SystemUInt32_19.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_19 != null)
                {
                    Private___gintnl_SystemUInt32_19.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_39
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_39 != null)
            {
                return Private___gintnl_SystemUInt32_39.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_39 != null)
                {
                    Private___gintnl_SystemUInt32_39.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_29
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_29 != null)
            {
                return Private___gintnl_SystemUInt32_29.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_29 != null)
                {
                    Private___gintnl_SystemUInt32_29.Value = value.Value;
                }
            }
        }
    }

    internal string param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_param != null)
            {
                return Private_param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_param != null)
            {
                Private_param.Value = value;
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_52
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_52 != null)
            {
                return Private___gintnl_SystemUInt32_52.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_52 != null)
                {
                    Private___gintnl_SystemUInt32_52.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_42
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_42 != null)
            {
                return Private___gintnl_SystemUInt32_42.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_42 != null)
                {
                    Private___gintnl_SystemUInt32_42.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_62
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_62 != null)
            {
                return Private___gintnl_SystemUInt32_62.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_62 != null)
                {
                    Private___gintnl_SystemUInt32_62.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_12 != null)
            {
                return Private___gintnl_SystemUInt32_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_12 != null)
                {
                    Private___gintnl_SystemUInt32_12.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_32 != null)
            {
                return Private___gintnl_SystemUInt32_32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_32 != null)
                {
                    Private___gintnl_SystemUInt32_32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_22
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_22 != null)
            {
                return Private___gintnl_SystemUInt32_22.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_22 != null)
                {
                    Private___gintnl_SystemUInt32_22.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_i_SystemInt32_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_i_SystemInt32_1 != null)
            {
                return Private___lcl_i_SystemInt32_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_i_SystemInt32_1 != null)
                {
                    Private___lcl_i_SystemInt32_1.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_i_SystemInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_i_SystemInt32_0 != null)
            {
                return Private___lcl_i_SystemInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_i_SystemInt32_0 != null)
                {
                    Private___lcl_i_SystemInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_i_SystemInt32_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_i_SystemInt32_3 != null)
            {
                return Private___lcl_i_SystemInt32_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_i_SystemInt32_3 != null)
                {
                    Private___lcl_i_SystemInt32_3.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_i_SystemInt32_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_i_SystemInt32_2 != null)
            {
                return Private___lcl_i_SystemInt32_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_i_SystemInt32_2 != null)
                {
                    Private___lcl_i_SystemInt32_2.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_i_SystemInt32_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_i_SystemInt32_5 != null)
            {
                return Private___lcl_i_SystemInt32_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_i_SystemInt32_5 != null)
                {
                    Private___lcl_i_SystemInt32_5.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_i_SystemInt32_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_i_SystemInt32_4 != null)
            {
                return Private___lcl_i_SystemInt32_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_i_SystemInt32_4 != null)
                {
                    Private___lcl_i_SystemInt32_4.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemString_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_5 != null)
            {
                return Private___intnl_SystemString_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_5 != null)
            {
                Private___intnl_SystemString_5.Value = value;
            }
        }
    }

    internal string[] __intnl_SystemStringArray_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemStringArray_1 != null)
            {
                return Private___intnl_SystemStringArray_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemStringArray_1 != null)
            {
                Private___intnl_SystemStringArray_1.Value = value;
            }
        }
    }

    internal string[] __intnl_SystemStringArray_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemStringArray_0 != null)
            {
                return Private___intnl_SystemStringArray_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemStringArray_0 != null)
            {
                Private___intnl_SystemStringArray_0.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_6
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_6 != null)
            {
                return Private___gintnl_SystemCharArray_6.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_6 != null)
            {
                Private___gintnl_SystemCharArray_6.Value = value;
            }
        }
    }

    internal string __const_SystemString_9
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_9 != null)
            {
                return Private___const_SystemString_9.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_9 != null)
            {
                Private___const_SystemString_9.Value = value;
            }
        }
    }

    internal UnityEngine.Sprite vipFlair
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipFlair != null)
            {
                return Private_vipFlair.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipFlair != null)
            {
                Private_vipFlair.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_49
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_49 != null)
            {
                return Private___intnl_SystemString_49.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_49 != null)
            {
                Private___intnl_SystemString_49.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_44
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_44 != null)
            {
                return Private___intnl_SystemString_44.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_44 != null)
            {
                Private___intnl_SystemString_44.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_45
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_45 != null)
            {
                return Private___intnl_SystemString_45.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_45 != null)
            {
                Private___intnl_SystemString_45.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_43
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_43 != null)
            {
                return Private___intnl_SystemString_43.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_43 != null)
            {
                Private___intnl_SystemString_43.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_40
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_40 != null)
            {
                return Private___intnl_SystemString_40.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_40 != null)
            {
                Private___intnl_SystemString_40.Value = value;
            }
        }
    }

    internal bool? __intnl_SystemBoolean_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_12 != null)
            {
                return Private___intnl_SystemBoolean_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_12 != null)
                {
                    Private___intnl_SystemBoolean_12.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_22
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_22 != null)
            {
                return Private___intnl_SystemBoolean_22.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_22 != null)
                {
                    Private___intnl_SystemBoolean_22.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_32 != null)
            {
                return Private___intnl_SystemBoolean_32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_32 != null)
                {
                    Private___intnl_SystemBoolean_32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_42
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_42 != null)
            {
                return Private___intnl_SystemBoolean_42.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_42 != null)
                {
                    Private___intnl_SystemBoolean_42.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_57
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_57 != null)
            {
                return Private___gintnl_SystemUInt32_57.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_57 != null)
                {
                    Private___gintnl_SystemUInt32_57.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_47
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_47 != null)
            {
                return Private___gintnl_SystemUInt32_47.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_47 != null)
                {
                    Private___gintnl_SystemUInt32_47.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_67
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_67 != null)
            {
                return Private___gintnl_SystemUInt32_67.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_67 != null)
                {
                    Private___gintnl_SystemUInt32_67.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_17
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_17 != null)
            {
                return Private___gintnl_SystemUInt32_17.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_17 != null)
                {
                    Private___gintnl_SystemUInt32_17.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_37
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_37 != null)
            {
                return Private___gintnl_SystemUInt32_37.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_37 != null)
                {
                    Private___gintnl_SystemUInt32_37.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_27
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_27 != null)
            {
                return Private___gintnl_SystemUInt32_27.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_27 != null)
                {
                    Private___gintnl_SystemUInt32_27.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Vector3? __const_UnityEngineVector3_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_UnityEngineVector3_1 != null)
            {
                return Private___const_UnityEngineVector3_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_UnityEngineVector3_1 != null)
                {
                    Private___const_UnityEngineVector3_1.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_16
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_16 != null)
            {
                return Private___intnl_SystemInt32_16.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_16 != null)
                {
                    Private___intnl_SystemInt32_16.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_36
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_36 != null)
            {
                return Private___intnl_SystemInt32_36.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_36 != null)
                {
                    Private___intnl_SystemInt32_36.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_26
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_26 != null)
            {
                return Private___intnl_SystemInt32_26.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_26 != null)
                {
                    Private___intnl_SystemInt32_26.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_56
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_56 != null)
            {
                return Private___intnl_SystemInt32_56.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_56 != null)
                {
                    Private___intnl_SystemInt32_56.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_46
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_46 != null)
            {
                return Private___intnl_SystemInt32_46.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_46 != null)
                {
                    Private___intnl_SystemInt32_46.Value = value.Value;
                }
            }
        }
    }

    internal string __refl_typename
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___refl_typename != null)
            {
                return Private___refl_typename.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___refl_typename != null)
            {
                Private___refl_typename.Value = value;
            }
        }
    }

    internal string[] elites
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_elites != null)
            {
                return Private_elites.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_elites != null)
            {
                Private_elites.Value = value;
            }
        }
    }

    internal int? __intnl_SystemInt32_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_1 != null)
            {
                return Private___intnl_SystemInt32_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_1 != null)
                {
                    Private___intnl_SystemInt32_1.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_0 != null)
            {
                return Private___intnl_SystemInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_0 != null)
                {
                    Private___intnl_SystemInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_3 != null)
            {
                return Private___intnl_SystemInt32_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_3 != null)
                {
                    Private___intnl_SystemInt32_3.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_2 != null)
            {
                return Private___intnl_SystemInt32_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_2 != null)
                {
                    Private___intnl_SystemInt32_2.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_5 != null)
            {
                return Private___intnl_SystemInt32_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_5 != null)
                {
                    Private___intnl_SystemInt32_5.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_4 != null)
            {
                return Private___intnl_SystemInt32_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_4 != null)
                {
                    Private___intnl_SystemInt32_4.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_7
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_7 != null)
            {
                return Private___intnl_SystemInt32_7.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_7 != null)
                {
                    Private___intnl_SystemInt32_7.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_6
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_6 != null)
            {
                return Private___intnl_SystemInt32_6.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_6 != null)
                {
                    Private___intnl_SystemInt32_6.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_9
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_9 != null)
            {
                return Private___intnl_SystemInt32_9.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_9 != null)
                {
                    Private___intnl_SystemInt32_9.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_8
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_8 != null)
            {
                return Private___intnl_SystemInt32_8.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_8 != null)
                {
                    Private___intnl_SystemInt32_8.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Sprite legendFlair
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_legendFlair != null)
            {
                return Private_legendFlair.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_legendFlair != null)
            {
                Private_legendFlair.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour patreonBoard
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patreonBoard != null)
            {
                return Private_patreonBoard.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_patreonBoard != null)
            {
                Private_patreonBoard.Value = value;
            }
        }
    }

    internal string __const_SystemString_56
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_56 != null)
            {
                return Private___const_SystemString_56.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_56 != null)
            {
                Private___const_SystemString_56.Value = value;
            }
        }
    }

    internal string __const_SystemString_57
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_57 != null)
            {
                return Private___const_SystemString_57.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_57 != null)
            {
                Private___const_SystemString_57.Value = value;
            }
        }
    }

    internal string __const_SystemString_54
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_54 != null)
            {
                return Private___const_SystemString_54.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_54 != null)
            {
                Private___const_SystemString_54.Value = value;
            }
        }
    }

    internal string __const_SystemString_55
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_55 != null)
            {
                return Private___const_SystemString_55.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_55 != null)
            {
                Private___const_SystemString_55.Value = value;
            }
        }
    }

    internal string __const_SystemString_52
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_52 != null)
            {
                return Private___const_SystemString_52.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_52 != null)
            {
                Private___const_SystemString_52.Value = value;
            }
        }
    }

    internal string __const_SystemString_53
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_53 != null)
            {
                return Private___const_SystemString_53.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_53 != null)
            {
                Private___const_SystemString_53.Value = value;
            }
        }
    }

    internal string __const_SystemString_50
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_50 != null)
            {
                return Private___const_SystemString_50.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_50 != null)
            {
                Private___const_SystemString_50.Value = value;
            }
        }
    }

    internal string __const_SystemString_51
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_51 != null)
            {
                return Private___const_SystemString_51.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_51 != null)
            {
                Private___const_SystemString_51.Value = value;
            }
        }
    }

    internal string __const_SystemString_58
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_58 != null)
            {
                return Private___const_SystemString_58.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_58 != null)
            {
                Private___const_SystemString_58.Value = value;
            }
        }
    }

    internal string __const_SystemString_59
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_59 != null)
            {
                return Private___const_SystemString_59.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_59 != null)
            {
                Private___const_SystemString_59.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_20
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_20 != null)
            {
                return Private___gintnl_SystemCharArray_20.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_20 != null)
            {
                Private___gintnl_SystemCharArray_20.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_21
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_21 != null)
            {
                return Private___gintnl_SystemCharArray_21.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_21 != null)
            {
                Private___gintnl_SystemCharArray_21.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_22
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_22 != null)
            {
                return Private___gintnl_SystemCharArray_22.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_22 != null)
            {
                Private___gintnl_SystemCharArray_22.Value = value;
            }
        }
    }

    internal char? __const_SystemChar_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemChar_3 != null)
            {
                return Private___const_SystemChar_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemChar_3 != null)
                {
                    Private___const_SystemChar_3.Value = value.Value;
                }
            }
        }
    }

    internal long? __lcl_targetID_SystemInt64_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_targetID_SystemInt64_0 != null)
            {
                return Private___lcl_targetID_SystemInt64_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_targetID_SystemInt64_0 != null)
                {
                    Private___lcl_targetID_SystemInt64_0.Value = value.Value;
                }
            }
        }
    }

    internal string __const_SystemString_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_1 != null)
            {
                return Private___const_SystemString_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_1 != null)
            {
                Private___const_SystemString_1.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_5 != null)
            {
                return Private___gintnl_SystemCharArray_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_5 != null)
            {
                Private___gintnl_SystemCharArray_5.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_14 != null)
            {
                return Private___intnl_SystemString_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_14 != null)
            {
                Private___intnl_SystemString_14.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_15 != null)
            {
                return Private___intnl_SystemString_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_15 != null)
            {
                Private___intnl_SystemString_15.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_12 != null)
            {
                return Private___intnl_SystemString_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_12 != null)
            {
                Private___intnl_SystemString_12.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_13 != null)
            {
                return Private___intnl_SystemString_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_13 != null)
            {
                Private___intnl_SystemString_13.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_10
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_10 != null)
            {
                return Private___intnl_SystemString_10.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_10 != null)
            {
                Private___intnl_SystemString_10.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_11
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_11 != null)
            {
                return Private___intnl_SystemString_11.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_11 != null)
            {
                Private___intnl_SystemString_11.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_8
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_8 != null)
            {
                return Private___gintnl_SystemCharArray_8.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_8 != null)
            {
                Private___gintnl_SystemCharArray_8.Value = value;
            }
        }
    }

    internal int? _old__tierIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private__old__tierIndex != null)
            {
                return Private__old__tierIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private__old__tierIndex != null)
                {
                    Private__old__tierIndex.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_15 != null)
            {
                return Private___intnl_SystemBoolean_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_15 != null)
                {
                    Private___intnl_SystemBoolean_15.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_25
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_25 != null)
            {
                return Private___intnl_SystemBoolean_25.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_25 != null)
                {
                    Private___intnl_SystemBoolean_25.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_35
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_35 != null)
            {
                return Private___intnl_SystemBoolean_35.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_35 != null)
                {
                    Private___intnl_SystemBoolean_35.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_13 != null)
            {
                return Private___intnl_SystemInt32_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_13 != null)
                {
                    Private___intnl_SystemInt32_13.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_33
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_33 != null)
            {
                return Private___intnl_SystemInt32_33.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_33 != null)
                {
                    Private___intnl_SystemInt32_33.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_23
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_23 != null)
            {
                return Private___intnl_SystemInt32_23.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_23 != null)
                {
                    Private___intnl_SystemInt32_23.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_53
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_53 != null)
            {
                return Private___intnl_SystemInt32_53.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_53 != null)
                {
                    Private___intnl_SystemInt32_53.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_43
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_43 != null)
            {
                return Private___intnl_SystemInt32_43.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_43 != null)
                {
                    Private___intnl_SystemInt32_43.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_18
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_18 != null)
            {
                return Private___intnl_SystemInt32_18.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_18 != null)
                {
                    Private___intnl_SystemInt32_18.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_38
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_38 != null)
            {
                return Private___intnl_SystemInt32_38.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_38 != null)
                {
                    Private___intnl_SystemInt32_38.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_28
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_28 != null)
            {
                return Private___intnl_SystemInt32_28.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_28 != null)
                {
                    Private___intnl_SystemInt32_28.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_58
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_58 != null)
            {
                return Private___intnl_SystemInt32_58.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_58 != null)
                {
                    Private___intnl_SystemInt32_58.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_48
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_48 != null)
            {
                return Private___intnl_SystemInt32_48.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_48 != null)
                {
                    Private___intnl_SystemInt32_48.Value = value.Value;
                }
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_14 != null)
            {
                return Private___gintnl_SystemCharArray_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_14 != null)
            {
                Private___gintnl_SystemCharArray_14.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_15 != null)
            {
                return Private___gintnl_SystemCharArray_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_15 != null)
            {
                Private___gintnl_SystemCharArray_15.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_16
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_16 != null)
            {
                return Private___gintnl_SystemCharArray_16.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_16 != null)
            {
                Private___gintnl_SystemCharArray_16.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_17
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_17 != null)
            {
                return Private___gintnl_SystemCharArray_17.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_17 != null)
            {
                Private___gintnl_SystemCharArray_17.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_10
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_10 != null)
            {
                return Private___gintnl_SystemCharArray_10.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_10 != null)
            {
                Private___gintnl_SystemCharArray_10.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_11
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_11 != null)
            {
                return Private___gintnl_SystemCharArray_11.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_11 != null)
            {
                Private___gintnl_SystemCharArray_11.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_12 != null)
            {
                return Private___gintnl_SystemCharArray_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_12 != null)
            {
                Private___gintnl_SystemCharArray_12.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_13 != null)
            {
                return Private___gintnl_SystemCharArray_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_13 != null)
            {
                Private___gintnl_SystemCharArray_13.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_18
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_18 != null)
            {
                return Private___gintnl_SystemCharArray_18.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_18 != null)
            {
                Private___gintnl_SystemCharArray_18.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_19
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_19 != null)
            {
                return Private___gintnl_SystemCharArray_19.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_19 != null)
            {
                Private___gintnl_SystemCharArray_19.Value = value;
            }
        }
    }

    internal char? __const_SystemChar_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemChar_0 != null)
            {
                return Private___const_SystemChar_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemChar_0 != null)
                {
                    Private___const_SystemChar_0.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0___0__IsMod__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__IsMod__ret != null)
            {
                return Private___0___0__IsMod__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__IsMod__ret != null)
                {
                    Private___0___0__IsMod__ret.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour audio2d
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_audio2d != null)
            {
                return Private_audio2d.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_audio2d != null)
            {
                Private_audio2d.Value = value;
            }
        }
    }

    internal string __const_SystemString_6
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_6 != null)
            {
                return Private___const_SystemString_6.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_6 != null)
            {
                Private___const_SystemString_6.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_0 != null)
            {
                return Private___gintnl_SystemCharArray_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_0 != null)
            {
                Private___gintnl_SystemCharArray_0.Value = value;
            }
        }
    }

    internal UnityEngine.Color? specialColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_specialColor != null)
            {
                return Private_specialColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_specialColor != null)
                {
                    Private_specialColor.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Color? modColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_modColor != null)
            {
                return Private_modColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_modColor != null)
                {
                    Private_modColor.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_50
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_50 != null)
            {
                return Private___gintnl_SystemUInt32_50.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_50 != null)
                {
                    Private___gintnl_SystemUInt32_50.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_40
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_40 != null)
            {
                return Private___gintnl_SystemUInt32_40.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_40 != null)
                {
                    Private___gintnl_SystemUInt32_40.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_60
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_60 != null)
            {
                return Private___gintnl_SystemUInt32_60.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_60 != null)
                {
                    Private___gintnl_SystemUInt32_60.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_10
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_10 != null)
            {
                return Private___gintnl_SystemUInt32_10.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_10 != null)
                {
                    Private___gintnl_SystemUInt32_10.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_30
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_30 != null)
            {
                return Private___gintnl_SystemUInt32_30.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_30 != null)
                {
                    Private___gintnl_SystemUInt32_30.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_20
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_20 != null)
            {
                return Private___gintnl_SystemUInt32_20.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_20 != null)
                {
                    Private___gintnl_SystemUInt32_20.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Component[] vipAndMasterButtons
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipAndMasterButtons != null)
            {
                return Private_vipAndMasterButtons.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipAndMasterButtons != null)
            {
                Private_vipAndMasterButtons.Value = value;
            }
        }
    }

    internal int? __intnl_SystemInt32_10
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_10 != null)
            {
                return Private___intnl_SystemInt32_10.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_10 != null)
                {
                    Private___intnl_SystemInt32_10.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_30
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_30 != null)
            {
                return Private___intnl_SystemInt32_30.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_30 != null)
                {
                    Private___intnl_SystemInt32_30.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_20
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_20 != null)
            {
                return Private___intnl_SystemInt32_20.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_20 != null)
                {
                    Private___intnl_SystemInt32_20.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_50
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_50 != null)
            {
                return Private___intnl_SystemInt32_50.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_50 != null)
                {
                    Private___intnl_SystemInt32_50.Value = value.Value;
                }
            }
        }
    }

    internal int? __intnl_SystemInt32_40
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_40 != null)
            {
                return Private___intnl_SystemInt32_40.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_40 != null)
                {
                    Private___intnl_SystemInt32_40.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0___0__IsExecutive__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__IsExecutive__ret != null)
            {
                return Private___0___0__IsExecutive__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__IsExecutive__ret != null)
                {
                    Private___0___0__IsExecutive__ret.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemString_7
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_7 != null)
            {
                return Private___intnl_SystemString_7.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_7 != null)
            {
                Private___intnl_SystemString_7.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi localPlayer
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_localPlayer != null)
            {
                return Private_localPlayer.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_localPlayer != null)
            {
                Private_localPlayer.Value = value;
            }
        }
    }

    internal UnityEngine.Color? __0___0__GetColor__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0___0__GetColor__ret != null)
            {
                return Private___0___0__GetColor__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0___0__GetColor__ret != null)
                {
                    Private___0___0__GetColor__ret.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject __this_UnityEngineGameObject_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___this_UnityEngineGameObject_0 != null)
            {
                return Private___this_UnityEngineGameObject_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___this_UnityEngineGameObject_0 != null)
            {
                Private___this_UnityEngineGameObject_0.Value = value;
            }
        }
    }

    internal int? __1_value__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_value__param != null)
            {
                return Private___1_value__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_value__param != null)
                {
                    Private___1_value__param.Value = value.Value;
                }
            }
        }
    }

    internal string __const_SystemString_26
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_26 != null)
            {
                return Private___const_SystemString_26.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_26 != null)
            {
                Private___const_SystemString_26.Value = value;
            }
        }
    }

    internal string __const_SystemString_27
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_27 != null)
            {
                return Private___const_SystemString_27.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_27 != null)
            {
                Private___const_SystemString_27.Value = value;
            }
        }
    }

    internal string __const_SystemString_24
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_24 != null)
            {
                return Private___const_SystemString_24.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_24 != null)
            {
                Private___const_SystemString_24.Value = value;
            }
        }
    }

    internal string __const_SystemString_25
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_25 != null)
            {
                return Private___const_SystemString_25.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_25 != null)
            {
                Private___const_SystemString_25.Value = value;
            }
        }
    }

    internal string __const_SystemString_22
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_22 != null)
            {
                return Private___const_SystemString_22.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_22 != null)
            {
                Private___const_SystemString_22.Value = value;
            }
        }
    }

    internal string __const_SystemString_23
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_23 != null)
            {
                return Private___const_SystemString_23.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_23 != null)
            {
                Private___const_SystemString_23.Value = value;
            }
        }
    }

    internal string __const_SystemString_20
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_20 != null)
            {
                return Private___const_SystemString_20.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_20 != null)
            {
                Private___const_SystemString_20.Value = value;
            }
        }
    }

    internal string __const_SystemString_21
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_21 != null)
            {
                return Private___const_SystemString_21.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_21 != null)
            {
                Private___const_SystemString_21.Value = value;
            }
        }
    }

    internal string __const_SystemString_28
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_28 != null)
            {
                return Private___const_SystemString_28.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_28 != null)
            {
                Private___const_SystemString_28.Value = value;
            }
        }
    }

    internal string __const_SystemString_29
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_29 != null)
            {
                return Private___const_SystemString_29.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_29 != null)
            {
                Private___const_SystemString_29.Value = value;
            }
        }
    }

    internal UnityEngine.Color? defaultColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_defaultColor != null)
            {
                return Private_defaultColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_defaultColor != null)
                {
                    Private_defaultColor.Value = value.Value;
                }
            }
        }
    }

    internal bool? __lcl_isSupporter_SystemBoolean_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_isSupporter_SystemBoolean_0 != null)
            {
                return Private___lcl_isSupporter_SystemBoolean_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_isSupporter_SystemBoolean_0 != null)
                {
                    Private___lcl_isSupporter_SystemBoolean_0.Value = value.Value;
                }
            }
        }
    }

    internal string[] __lcl_hiddenElites_SystemStringArray_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_hiddenElites_SystemStringArray_0 != null)
            {
                return Private___lcl_hiddenElites_SystemStringArray_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_hiddenElites_SystemStringArray_0 != null)
            {
                Private___lcl_hiddenElites_SystemStringArray_0.Value = value;
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_58
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_58 != null)
            {
                return Private___gintnl_SystemUInt32_58.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_58 != null)
                {
                    Private___gintnl_SystemUInt32_58.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_48
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_48 != null)
            {
                return Private___gintnl_SystemUInt32_48.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_48 != null)
                {
                    Private___gintnl_SystemUInt32_48.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_18
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_18 != null)
            {
                return Private___gintnl_SystemUInt32_18.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_18 != null)
                {
                    Private___gintnl_SystemUInt32_18.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_38
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_38 != null)
            {
                return Private___gintnl_SystemUInt32_38.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_38 != null)
                {
                    Private___gintnl_SystemUInt32_38.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_28
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_28 != null)
            {
                return Private___gintnl_SystemUInt32_28.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_28 != null)
                {
                    Private___gintnl_SystemUInt32_28.Value = value.Value;
                }
            }
        }
    }

    internal string __lcl_x_SystemString_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_x_SystemString_0 != null)
            {
                return Private___lcl_x_SystemString_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_x_SystemString_0 != null)
            {
                Private___lcl_x_SystemString_0.Value = value;
            }
        }
    }

    internal UnityEngine.AudioClip[] eliteJoinSounds
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteJoinSounds != null)
            {
                return Private_eliteJoinSounds.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteJoinSounds != null)
            {
                Private_eliteJoinSounds.Value = value;
            }
        }
    }

    internal UnityEngine.Color? legendColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_legendColor != null)
            {
                return Private_legendColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_legendColor != null)
                {
                    Private_legendColor.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_10
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_10 != null)
            {
                return Private___intnl_SystemBoolean_10.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_10 != null)
                {
                    Private___intnl_SystemBoolean_10.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_20
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_20 != null)
            {
                return Private___intnl_SystemBoolean_20.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_20 != null)
                {
                    Private___intnl_SystemBoolean_20.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_30
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_30 != null)
            {
                return Private___intnl_SystemBoolean_30.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_30 != null)
                {
                    Private___intnl_SystemBoolean_30.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_40
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_40 != null)
            {
                return Private___intnl_SystemBoolean_40.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_40 != null)
                {
                    Private___intnl_SystemBoolean_40.Value = value.Value;
                }
            }
        }
    }

    internal string __lcl_name_SystemString_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_name_SystemString_0 != null)
            {
                return Private___lcl_name_SystemString_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_name_SystemString_0 != null)
            {
                Private___lcl_name_SystemString_0.Value = value;
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_55
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_55 != null)
            {
                return Private___gintnl_SystemUInt32_55.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_55 != null)
                {
                    Private___gintnl_SystemUInt32_55.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_45
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_45 != null)
            {
                return Private___gintnl_SystemUInt32_45.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_45 != null)
                {
                    Private___gintnl_SystemUInt32_45.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_65
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_65 != null)
            {
                return Private___gintnl_SystemUInt32_65.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_65 != null)
                {
                    Private___gintnl_SystemUInt32_65.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_15 != null)
            {
                return Private___gintnl_SystemUInt32_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_15 != null)
                {
                    Private___gintnl_SystemUInt32_15.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_35
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_35 != null)
            {
                return Private___gintnl_SystemUInt32_35.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_35 != null)
                {
                    Private___gintnl_SystemUInt32_35.Value = value.Value;
                }
            }
        }
    }

    internal uint? __gintnl_SystemUInt32_25
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemUInt32_25 != null)
            {
                return Private___gintnl_SystemUInt32_25.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___gintnl_SystemUInt32_25 != null)
                {
                    Private___gintnl_SystemUInt32_25.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_1 != null)
            {
                return Private___const_SystemInt32_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_1 != null)
                {
                    Private___const_SystemInt32_1.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_0 != null)
            {
                return Private___const_SystemInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_0 != null)
                {
                    Private___const_SystemInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_3 != null)
            {
                return Private___const_SystemInt32_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_3 != null)
                {
                    Private___const_SystemInt32_3.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_2 != null)
            {
                return Private___const_SystemInt32_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_2 != null)
                {
                    Private___const_SystemInt32_2.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_5 != null)
            {
                return Private___const_SystemInt32_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_5 != null)
                {
                    Private___const_SystemInt32_5.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_4 != null)
            {
                return Private___const_SystemInt32_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_4 != null)
                {
                    Private___const_SystemInt32_4.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_7
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_7 != null)
            {
                return Private___const_SystemInt32_7.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_7 != null)
                {
                    Private___const_SystemInt32_7.Value = value.Value;
                }
            }
        }
    }

    internal int? __const_SystemInt32_6
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemInt32_6 != null)
            {
                return Private___const_SystemInt32_6.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___const_SystemInt32_6 != null)
                {
                    Private___const_SystemInt32_6.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_8
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_8 != null)
            {
                return Private___intnl_SystemBoolean_8.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_8 != null)
                {
                    Private___intnl_SystemBoolean_8.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_9
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_9 != null)
            {
                return Private___intnl_SystemBoolean_9.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_9 != null)
                {
                    Private___intnl_SystemBoolean_9.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_0 != null)
            {
                return Private___intnl_SystemBoolean_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_0 != null)
                {
                    Private___intnl_SystemBoolean_0.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_1 != null)
            {
                return Private___intnl_SystemBoolean_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_1 != null)
                {
                    Private___intnl_SystemBoolean_1.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_2 != null)
            {
                return Private___intnl_SystemBoolean_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_2 != null)
                {
                    Private___intnl_SystemBoolean_2.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_3 != null)
            {
                return Private___intnl_SystemBoolean_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_3 != null)
                {
                    Private___intnl_SystemBoolean_3.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_4 != null)
            {
                return Private___intnl_SystemBoolean_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_4 != null)
                {
                    Private___intnl_SystemBoolean_4.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_5 != null)
            {
                return Private___intnl_SystemBoolean_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_5 != null)
                {
                    Private___intnl_SystemBoolean_5.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_6
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_6 != null)
            {
                return Private___intnl_SystemBoolean_6.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_6 != null)
                {
                    Private___intnl_SystemBoolean_6.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_7
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_7 != null)
            {
                return Private___intnl_SystemBoolean_7.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_7 != null)
                {
                    Private___intnl_SystemBoolean_7.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Sprite executiveFlair
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_executiveFlair != null)
            {
                return Private_executiveFlair.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_executiveFlair != null)
            {
                Private_executiveFlair.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_4 != null)
            {
                return Private___intnl_SystemString_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_4 != null)
            {
                Private___intnl_SystemString_4.Value = value;
            }
        }
    }

    internal int? _tierIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private__tierIndex != null)
            {
                return Private__tierIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private__tierIndex != null)
                {
                    Private__tierIndex.Value = value.Value;
                }
            }
        }
    }

    internal bool? _vipOnly
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private__vipOnly != null)
            {
                return Private__vipOnly.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private__vipOnly != null)
                {
                    Private__vipOnly.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour rooms
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_rooms != null)
            {
                return Private_rooms.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_rooms != null)
            {
                Private_rooms.Value = value;
            }
        }
    }

    internal UnityEngine.GameObject[] vipOnlyForNonVipsObjs
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipOnlyForNonVipsObjs != null)
            {
                return Private_vipOnlyForNonVipsObjs.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipOnlyForNonVipsObjs != null)
            {
                Private_vipOnlyForNonVipsObjs.Value = value;
            }
        }
    }

    internal string __const_SystemString_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_3 != null)
            {
                return Private___const_SystemString_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_3 != null)
            {
                Private___const_SystemString_3.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___this_VRCUdonUdonBehaviour_3 != null)
            {
                return Private___this_VRCUdonUdonBehaviour_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___this_VRCUdonUdonBehaviour_3 != null)
            {
                Private___this_VRCUdonUdonBehaviour_3.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___this_VRCUdonUdonBehaviour_2 != null)
            {
                return Private___this_VRCUdonUdonBehaviour_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___this_VRCUdonUdonBehaviour_2 != null)
            {
                Private___this_VRCUdonUdonBehaviour_2.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___this_VRCUdonUdonBehaviour_1 != null)
            {
                return Private___this_VRCUdonUdonBehaviour_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___this_VRCUdonUdonBehaviour_1 != null)
            {
                Private___this_VRCUdonUdonBehaviour_1.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___this_VRCUdonUdonBehaviour_0 != null)
            {
                return Private___this_VRCUdonUdonBehaviour_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___this_VRCUdonUdonBehaviour_0 != null)
            {
                Private___this_VRCUdonUdonBehaviour_0.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___this_VRCUdonUdonBehaviour_4 != null)
            {
                return Private___this_VRCUdonUdonBehaviour_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___this_VRCUdonUdonBehaviour_4 != null)
            {
                Private___this_VRCUdonUdonBehaviour_4.Value = value;
            }
        }
    }

    internal string[] __2_names__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_names__param != null)
            {
                return Private___2_names__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_names__param != null)
            {
                Private___2_names__param.Value = value;
            }
        }
    }

    internal char[] __gintnl_SystemCharArray_7
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___gintnl_SystemCharArray_7 != null)
            {
                return Private___gintnl_SystemCharArray_7.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___gintnl_SystemCharArray_7 != null)
            {
                Private___gintnl_SystemCharArray_7.Value = value;
            }
        }
    }

    internal string __const_SystemString_8
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___const_SystemString_8 != null)
            {
                return Private___const_SystemString_8.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___const_SystemString_8 != null)
            {
                Private___const_SystemString_8.Value = value;
            }
        }
    }

    internal bool? __intnl_SystemBoolean_18
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_18 != null)
            {
                return Private___intnl_SystemBoolean_18.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_18 != null)
                {
                    Private___intnl_SystemBoolean_18.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_28
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_28 != null)
            {
                return Private___intnl_SystemBoolean_28.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_28 != null)
                {
                    Private___intnl_SystemBoolean_28.Value = value.Value;
                }
            }
        }
    }

    internal bool? __intnl_SystemBoolean_38
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemBoolean_38 != null)
            {
                return Private___intnl_SystemBoolean_38.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemBoolean_38 != null)
                {
                    Private___intnl_SystemBoolean_38.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemString_39
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_39 != null)
            {
                return Private___intnl_SystemString_39.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_39 != null)
            {
                Private___intnl_SystemString_39.Value = value;
            }
        }
    }

    #endregion Getter / Setters AstroUdonVariables  of ProcessPatronsRaw

    #region AstroUdonVariables  of ProcessPatronsRaw

    private AstroUdonVariable<UnityEngine.Sprite> Private_modFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_66 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___const_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___7_player__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___intnl_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___const_SystemChar_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_creatorFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_get_VipOnly__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_eliteFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_eliteColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_vipOnlyButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_j_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_newOn__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___const_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___const_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_eliteNames { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_executiveColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.TextAsset> Private_testPatrons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0___0__IsElite__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_patronsToProcess__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_get_TierIndex__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_roleVisible__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_vipObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___intnl_VRCSDKBaseVRCPlayerApi_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_nonVipObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___lcl_isPatron_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_cyan { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___const_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_vipOnlyObjs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_button_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_AvatarImageDecoder { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip> Private_joinSoundCreator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip> Private_joinSoundElite { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_players { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_names__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_eliteIds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0___0__IsLegend__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___const_SystemChar_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___lcl_groups_SystemStringArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_myInstance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0___0__IsInList__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___const_VRCUdonCommonEnumsEventTiming_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___lcl_allElites_SystemStringArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_mods { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___lcl_newOn_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0___0__IsSupporter__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_ready { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0___0__IsVip__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___intnl_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_vipColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip> Private_joinSoundVip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private__old__vipOnly { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___lcl_result_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_vipFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_67 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___const_UnityEngineVector3_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_elites { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_legendFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_patreonBoard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___const_SystemChar_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private__old__tierIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___const_SystemChar_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0___0__IsMod__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_audio2d { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_specialColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_modColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Component[]> Private_vipAndMasterButtons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0___0__IsExecutive__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_localPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private___0___0__GetColor__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_defaultColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___lcl_isSupporter_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___lcl_hiddenElites_SystemStringArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___lcl_x_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip[]> Private_eliteJoinSounds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_legendColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___lcl_name_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_65 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_executiveFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private__tierIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private__vipOnly { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_rooms { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_vipOnlyForNonVipsObjs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___2_names__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    #endregion AstroUdonVariables  of ProcessPatronsRaw

    // Use this for initialization
}