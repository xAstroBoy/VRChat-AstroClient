using AstroClient.ClientActions;
using AstroClient.Tools.UdonSearcher;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AstroClient.AstroMonos.Components.Cheats.PatronCrackers;

using AstroClient.Tools.UdonEditor;
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
        }
        if (ProcessPatronsRaw == null)
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        Cleanup_ProcessPatronsRaw();
        HasSubscribed = false;
    }

    private void Initialize_ProcessPatronsRaw()
    {
        Private___3_intnl_interpolatedStr_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__3_intnl_interpolatedStr_String");
        Private___0_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(ProcessPatronsRaw, "__0_intnl_TMProTextMeshProUGUI");
        Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__23_intnl_SystemBoolean");
        Private___0_intnl_interpolatedStr_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_intnl_interpolatedStr_String");
        Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__15_intnl_SystemInt32");
        Private___1_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(ProcessPatronsRaw, "__1_intnl_UnityEngineGameObject");
        Private___3_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__3_mp_player_VRCPlayerApi");
        Private___21_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__21_const_intnl_exitJumpLoc_UInt32");
        Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__12_intnl_SystemInt32");
        Private___7_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__7_intnl_SystemStringArray");
        Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__3_const_intnl_SystemString");
        Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__3_const_intnl_exitJumpLoc_UInt32");
        Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__26_intnl_SystemBoolean");
        Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_const_intnl_SystemBoolean");
        Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__1_const_intnl_SystemInt32");
        Private___32_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__32_intnl_SystemString");
        Private___0_mp_vips_StringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__0_mp_vips_StringArray");
        Private_creatorFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "creatorFlair");
        Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__1_intnl_SystemInt32");
        Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__16_const_intnl_exitJumpLoc_UInt32");
        Private_eliteFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "eliteFlair");
        Private_eliteColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "eliteColor");
        Private___1_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__1_intnl_SystemString");
        Private___1_i_Int32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__1_i_Int32");
        Private___0_j_Int32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__0_j_Int32");
        Private___0_i_Int32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__0_i_Int32");
        Private___3_i_Int32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__3_i_Int32");
        Private___2_i_Int32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__2_i_Int32");
        Private___4_i_Int32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__4_i_Int32");
        Private___2_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__2_intnl_VRCSDKBaseVRCPlayerApi");
        Private___34_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__34_intnl_SystemString");
        Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_const_intnl_SystemString");
        Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__29_intnl_SystemBoolean");
        Private___0_mp_elites_StringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__0_mp_elites_StringArray");
        Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__5_intnl_SystemBoolean");
        Private___31_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__31_intnl_SystemString");
        Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__10_const_intnl_exitJumpLoc_UInt32");
        Private___2_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__2_intnl_returnValSymbol_Boolean");
        Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__5_intnl_SystemInt32");
        Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__0_const_intnl_exitJumpLoc_UInt32");
        Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__15_intnl_SystemBoolean");
        Private_eliteTexts = new AstroUdonVariable<TMPro.TextMeshProUGUI[]>(ProcessPatronsRaw, "eliteTexts");
        Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__1_intnl_VRCSDKBaseVRCPlayerApi");
        Private___20_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__20_intnl_SystemString");
        Private___2_mp_names_StringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__2_mp_names_StringArray");
        Private___5_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__5_intnl_SystemString");
        Private___1_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__1_intnl_SystemStringArray");
        Private___1_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__1_const_intnl_SystemCharArray");
        Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__6_const_intnl_SystemString");
        Private_testPatrons = new AstroUdonVariable<UnityEngine.TextAsset>(ProcessPatronsRaw, "testPatrons");
        Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__21_intnl_SystemBoolean");
        Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__5_const_intnl_exitJumpLoc_UInt32");
        Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__13_intnl_SystemBoolean");
        Private___7_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__7_mp_player_VRCPlayerApi");
        Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__1_const_intnl_SystemString");
        Private___8_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__8_intnl_SystemStringArray");
        Private___0_intnl_Player = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__0_intnl_Player");
        Private___0_const_intnl_SystemChar = new AstroUdonVariable<char>(ProcessPatronsRaw, "__0_const_intnl_SystemChar");
        Private_vipText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(ProcessPatronsRaw, "vipText");
        Private___0_x_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_x_String");
        Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__2_const_intnl_exitJumpLoc_UInt32");
        Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__18_intnl_SystemInt32");
        Private___1_mp_names_StringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__1_mp_names_StringArray");
        Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__16_intnl_SystemBoolean");
        Private_vipObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(ProcessPatronsRaw, "vipObjects");
        Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__14_const_intnl_SystemString");
        Private___10_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__10_intnl_SystemStringArray");
        Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__7_intnl_SystemBoolean");
        Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__20_intnl_SystemInt32");
        Private___1_intnl_SystemInt64 = new AstroUdonVariable<long>(ProcessPatronsRaw, "__1_intnl_SystemInt64");
        Private___3_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__3_intnl_SystemStringArray");
        Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__22_intnl_SystemBoolean");
        Private___0_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(ProcessPatronsRaw, "__0_intnl_UnityEngineComponentArray");
        Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__7_const_intnl_exitJumpLoc_UInt32");
        Private___28_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__28_intnl_SystemString");
        Private_nonVipObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(ProcessPatronsRaw, "nonVipObjects");
        Private___0_newOn_Boolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_newOn_Boolean");
        Private___2_intnl_interpolatedStr_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__2_intnl_interpolatedStr_String");
        Private___0_divider_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_divider_String");
        Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__7_const_intnl_SystemString");
        Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__15_const_intnl_SystemString");
        Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(ProcessPatronsRaw, "__refl_const_intnl_udonTypeID");
        Private_cyan = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "cyan");
        Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__4_intnl_SystemBoolean");
        Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__19_intnl_SystemBoolean");
        Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(ProcessPatronsRaw, "__refl_const_intnl_udonTypeName");
        Private___1_const_intnl_SystemChar = new AstroUdonVariable<char>(ProcessPatronsRaw, "__1_const_intnl_SystemChar");
        Private___0_intnl_SystemObject = new AstroUdonVariable<UnityEngine.GameObject>(ProcessPatronsRaw, "__0_intnl_SystemObject");
        Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__1_intnl_SystemBoolean");
        Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__14_intnl_SystemInt32");
        Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__12_const_intnl_exitJumpLoc_UInt32");
        Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__17_const_intnl_SystemString");
        Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__11_intnl_SystemInt32");
        Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__17_intnl_SystemInt32");
        Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__4_const_intnl_SystemString");
        Private_vips = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "vips");
        Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__20_const_intnl_SystemString");
        Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__11_intnl_SystemBoolean");
        Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__2_intnl_SystemInt32");
        Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__4_const_intnl_exitJumpLoc_UInt32");
        Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__30_intnl_SystemBoolean");
        Private___2_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__2_intnl_SystemString");
        Private_joinSoundElite = new AstroUdonVariable<UnityEngine.AudioClip>(ProcessPatronsRaw, "joinSoundElite");
        Private___0_intnl_JetDogUIInteractionUI_Interaction = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__0_intnl_JetDogUIInteractionUI_Interaction");
        Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__21_const_intnl_SystemString");
        Private_players = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "players");
        Private___23_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__23_intnl_SystemString");
        Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__9_const_intnl_exitJumpLoc_UInt32");
        Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__20_const_intnl_exitJumpLoc_UInt32");
        Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__9_intnl_SystemInt32");
        Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__5_const_intnl_SystemString");
        Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__3_intnl_SystemBoolean");
        Private___0_player_Player = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__0_player_Player");
        Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_intnl_returnValSymbol_Boolean");
        Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__12_intnl_SystemBoolean");
        Private___9_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__9_intnl_SystemString");
        Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__6_const_intnl_exitJumpLoc_UInt32");
        Private___18_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__18_intnl_SystemString");
        Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__23_const_intnl_SystemString");
        Private_myInstance = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "myInstance");
        Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__6_intnl_SystemInt32");
        Private___0_mp_names_StringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__0_mp_names_StringArray");
        Private___6_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__6_intnl_SystemString");
        Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_intnl_SystemBoolean");
        Private___22_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__22_intnl_SystemString");
        Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__12_const_intnl_SystemString");
        Private___0_isSupporter_Boolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_isSupporter_Boolean");
        Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(ProcessPatronsRaw, "__0_intnl_UnityEngineGameObject");
        Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__8_const_intnl_SystemString");
        Private___3_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__3_intnl_returnValSymbol_Boolean");
        Private___9_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__9_intnl_SystemStringArray");
        Private_ready = new AstroUdonVariable<bool>(ProcessPatronsRaw, "ready");
        Private_vipColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "vipColor");
        Private___24_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__24_intnl_SystemString");
        Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__15_const_intnl_exitJumpLoc_UInt32");
        Private_joinSoundVip = new AstroUdonVariable<UnityEngine.AudioClip>(ProcessPatronsRaw, "joinSoundVip");
        Private___1_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__1_mp_player_VRCPlayerApi");
        Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__19_const_intnl_exitJumpLoc_UInt32");
        Private_param = new AstroUdonVariable<string>(ProcessPatronsRaw, "param");
        Private___21_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__21_intnl_SystemString");
        Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__8_const_intnl_exitJumpLoc_UInt32");
        Private___0_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__0_const_intnl_SystemCharArray");
        Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__24_intnl_SystemBoolean");
        Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__9_const_intnl_SystemString");
        Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__0_intnl_SystemInt32");
        Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__0_intnl_returnTarget_UInt32");
        Private___0_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_intnl_SystemString");
        Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__10_intnl_SystemInt32");
        Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__0_const_intnl_SystemUInt32");
        Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__9_intnl_SystemBoolean");
        Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__13_intnl_SystemInt32");
        Private___2_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__2_mp_player_VRCPlayerApi");
        Private_vipFlair = new AstroUdonVariable<UnityEngine.Sprite>(ProcessPatronsRaw, "vipFlair");
        Private___29_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__29_intnl_SystemString");
        Private___0_intnl_returnValSymbol_Color = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "__0_intnl_returnValSymbol_Color");
        Private___0_wallText_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_wallText_String");
        Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__18_const_intnl_SystemString");
        Private___4_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__4_intnl_SystemStringArray");
        Private___6_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__6_intnl_SystemStringArray");
        Private_elites = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "elites");
        Private___0_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__0_mp_player_VRCPlayerApi");
        Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__4_intnl_SystemInt32");
        Private___4_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__4_intnl_SystemString");
        Private___0_playerName_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_playerName_String");
        Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__19_const_intnl_SystemString");
        Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__17_const_intnl_exitJumpLoc_UInt32");
        Private___0_playerGO_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(ProcessPatronsRaw, "__0_playerGO_GameObject");
        Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__28_intnl_SystemBoolean");
        Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__6_intnl_SystemBoolean");
        Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__24_const_intnl_SystemString");
        Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__16_intnl_SystemInt32");
        Private___0_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__0_intnl_VRCSDKBaseVRCPlayerApi");
        Private___27_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__27_intnl_SystemString");
        Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__14_intnl_SystemBoolean");
        Private___0_intnl_SystemInt64 = new AstroUdonVariable<long>(ProcessPatronsRaw, "__0_intnl_SystemInt64");
        Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__1_intnl_returnValSymbol_Boolean");
        Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__3_intnl_SystemInt32");
        Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__31_intnl_SystemBoolean");
        Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__11_const_intnl_exitJumpLoc_UInt32");
        Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__8_intnl_SystemBoolean");
        Private___1_intnl_interpolatedStr_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__1_intnl_interpolatedStr_String");
        Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__20_intnl_SystemBoolean");
        Private___3_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__3_intnl_SystemString");
        Private___1_intnl_SystemObject = new AstroUdonVariable<long>(ProcessPatronsRaw, "__1_intnl_SystemObject");
        Private_elitePlates = new AstroUdonVariable<UnityEngine.GameObject[]>(ProcessPatronsRaw, "elitePlates");
        Private___0_mp_patronsToProcess_String = new AstroUdonVariable<string>(ProcessPatronsRaw, "__0_mp_patronsToProcess_String");
        Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(ProcessPatronsRaw, "__1_intnl_UnityEngineVector3");
        Private___2_const_intnl_SystemChar = new AstroUdonVariable<char>(ProcessPatronsRaw, "__2_const_intnl_SystemChar");
        Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__27_intnl_SystemBoolean");
        Private_specialColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "specialColor");
        Private___19_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__19_intnl_SystemString");
        Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__2_const_intnl_SystemInt32");
        Private___4_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "__4_mp_player_VRCPlayerApi");
        Private___26_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__26_intnl_SystemString");
        Private_vipAndMasterButtons = new AstroUdonVariable<UnityEngine.Component[]>(ProcessPatronsRaw, "vipAndMasterButtons");
        Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(ProcessPatronsRaw, "__0_intnl_UnityEngineVector3");
        Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__10_const_intnl_SystemString");
        Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__32_intnl_SystemBoolean");
        Private___0_button_UI_Interaction = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__0_button_UI_Interaction");
        Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__7_intnl_SystemInt32");
        Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(ProcessPatronsRaw, "__0_intnl_UnityEngineTransform");
        Private_localPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(ProcessPatronsRaw, "localPlayer");
        Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__1_const_intnl_SystemBoolean");
        Private___7_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__7_intnl_SystemString");
        Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__11_const_intnl_SystemString");
        Private___0_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__0_intnl_SystemStringArray");
        Private___1_intnl_Player = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__1_intnl_Player");
        Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__16_const_intnl_SystemString");
        Private___2_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__2_intnl_SystemStringArray");
        Private_defaultColor = new AstroUdonVariable<UnityEngine.Color>(ProcessPatronsRaw, "defaultColor");
        Private___0_const_intnl_SystemInt64 = new AstroUdonVariable<long>(ProcessPatronsRaw, "__0_const_intnl_SystemInt64");
        Private___0_mp_newOn_Boolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__0_mp_newOn_Boolean");
        Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__18_intnl_SystemBoolean");
        Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__2_intnl_SystemBoolean");
        Private___0_groups_StringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__0_groups_StringArray");
        Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__14_const_intnl_exitJumpLoc_UInt32");
        Private___0_mp_list_StringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__0_mp_list_StringArray");
        Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__3_const_intnl_SystemInt32");
        Private___25_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__25_intnl_SystemString");
        Private_eliteJoinSounds = new AstroUdonVariable<UnityEngine.AudioClip[]>(ProcessPatronsRaw, "eliteJoinSounds");
        Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__18_const_intnl_exitJumpLoc_UInt32");
        Private___17_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__17_intnl_SystemString");
        Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__13_const_intnl_SystemString");
        Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__8_intnl_SystemInt32");
        Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__19_intnl_SystemInt32");
        Private___2_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(ProcessPatronsRaw, "__2_const_intnl_SystemCharArray");
        Private___8_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__8_intnl_SystemString");
        Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__13_const_intnl_exitJumpLoc_UInt32");
        Private___2_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(ProcessPatronsRaw, "__2_intnl_UnityEngineGameObject");
        Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__10_intnl_SystemBoolean");
        Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__2_const_intnl_SystemString");
        Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__21_intnl_SystemInt32");
        Private___5_intnl_SystemStringArray = new AstroUdonVariable<string[]>(ProcessPatronsRaw, "__5_intnl_SystemStringArray");
        Private___1_const_intnl_SystemInt64 = new AstroUdonVariable<long>(ProcessPatronsRaw, "__1_const_intnl_SystemInt64");
        Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(ProcessPatronsRaw, "__0_const_intnl_SystemInt32");
        Private___33_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__33_intnl_SystemString");
        Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(ProcessPatronsRaw, "__1_const_intnl_exitJumpLoc_UInt32");
        Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__25_intnl_SystemBoolean");
        Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(ProcessPatronsRaw, "__22_const_intnl_SystemString");
        Private___0_obj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(ProcessPatronsRaw, "__0_obj_GameObject");
        Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(ProcessPatronsRaw, "__17_intnl_SystemBoolean");
        Private___0_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(ProcessPatronsRaw, "__0_intnl_UnityEngineComponent");
    }

    private void Cleanup_ProcessPatronsRaw()
    {
        Private___3_intnl_interpolatedStr_String = null;
        Private___0_intnl_TMProTextMeshProUGUI = null;
        Private___23_intnl_SystemBoolean = null;
        Private___0_intnl_interpolatedStr_String = null;
        Private___15_intnl_SystemInt32 = null;
        Private___1_intnl_UnityEngineGameObject = null;
        Private___3_mp_player_VRCPlayerApi = null;
        Private___21_const_intnl_exitJumpLoc_UInt32 = null;
        Private___12_intnl_SystemInt32 = null;
        Private___7_intnl_SystemStringArray = null;
        Private___3_const_intnl_SystemString = null;
        Private___3_const_intnl_exitJumpLoc_UInt32 = null;
        Private___26_intnl_SystemBoolean = null;
        Private___0_const_intnl_SystemBoolean = null;
        Private___1_const_intnl_SystemInt32 = null;
        Private___32_intnl_SystemString = null;
        Private___0_mp_vips_StringArray = null;
        Private_creatorFlair = null;
        Private___1_intnl_SystemInt32 = null;
        Private___16_const_intnl_exitJumpLoc_UInt32 = null;
        Private_eliteFlair = null;
        Private_eliteColor = null;
        Private___1_intnl_SystemString = null;
        Private___1_i_Int32 = null;
        Private___0_j_Int32 = null;
        Private___0_i_Int32 = null;
        Private___3_i_Int32 = null;
        Private___2_i_Int32 = null;
        Private___4_i_Int32 = null;
        Private___2_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___34_intnl_SystemString = null;
        Private___0_const_intnl_SystemString = null;
        Private___29_intnl_SystemBoolean = null;
        Private___0_mp_elites_StringArray = null;
        Private___5_intnl_SystemBoolean = null;
        Private___31_intnl_SystemString = null;
        Private___10_const_intnl_exitJumpLoc_UInt32 = null;
        Private___2_intnl_returnValSymbol_Boolean = null;
        Private___5_intnl_SystemInt32 = null;
        Private___0_const_intnl_exitJumpLoc_UInt32 = null;
        Private___15_intnl_SystemBoolean = null;
        Private_eliteTexts = null;
        Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___20_intnl_SystemString = null;
        Private___2_mp_names_StringArray = null;
        Private___5_intnl_SystemString = null;
        Private___1_intnl_SystemStringArray = null;
        Private___1_const_intnl_SystemCharArray = null;
        Private___6_const_intnl_SystemString = null;
        Private_testPatrons = null;
        Private___21_intnl_SystemBoolean = null;
        Private___5_const_intnl_exitJumpLoc_UInt32 = null;
        Private___13_intnl_SystemBoolean = null;
        Private___7_mp_player_VRCPlayerApi = null;
        Private___1_const_intnl_SystemString = null;
        Private___8_intnl_SystemStringArray = null;
        Private___0_intnl_Player = null;
        Private___0_const_intnl_SystemChar = null;
        Private_vipText = null;
        Private___0_x_String = null;
        Private___2_const_intnl_exitJumpLoc_UInt32 = null;
        Private___18_intnl_SystemInt32 = null;
        Private___1_mp_names_StringArray = null;
        Private___16_intnl_SystemBoolean = null;
        Private_vipObjects = null;
        Private___14_const_intnl_SystemString = null;
        Private___10_intnl_SystemStringArray = null;
        Private___7_intnl_SystemBoolean = null;
        Private___20_intnl_SystemInt32 = null;
        Private___1_intnl_SystemInt64 = null;
        Private___3_intnl_SystemStringArray = null;
        Private___22_intnl_SystemBoolean = null;
        Private___0_intnl_UnityEngineComponentArray = null;
        Private___7_const_intnl_exitJumpLoc_UInt32 = null;
        Private___28_intnl_SystemString = null;
        Private_nonVipObjects = null;
        Private___0_newOn_Boolean = null;
        Private___2_intnl_interpolatedStr_String = null;
        Private___0_divider_String = null;
        Private___7_const_intnl_SystemString = null;
        Private___15_const_intnl_SystemString = null;
        Private___refl_const_intnl_udonTypeID = null;
        Private_cyan = null;
        Private___4_intnl_SystemBoolean = null;
        Private___19_intnl_SystemBoolean = null;
        Private___refl_const_intnl_udonTypeName = null;
        Private___1_const_intnl_SystemChar = null;
        Private___0_intnl_SystemObject = null;
        Private___1_intnl_SystemBoolean = null;
        Private___14_intnl_SystemInt32 = null;
        Private___12_const_intnl_exitJumpLoc_UInt32 = null;
        Private___17_const_intnl_SystemString = null;
        Private___11_intnl_SystemInt32 = null;
        Private___17_intnl_SystemInt32 = null;
        Private___4_const_intnl_SystemString = null;
        Private_vips = null;
        Private___20_const_intnl_SystemString = null;
        Private___11_intnl_SystemBoolean = null;
        Private___2_intnl_SystemInt32 = null;
        Private___4_const_intnl_exitJumpLoc_UInt32 = null;
        Private___30_intnl_SystemBoolean = null;
        Private___2_intnl_SystemString = null;
        Private_joinSoundElite = null;
        Private___0_intnl_JetDogUIInteractionUI_Interaction = null;
        Private___21_const_intnl_SystemString = null;
        Private_players = null;
        Private___23_intnl_SystemString = null;
        Private___9_const_intnl_exitJumpLoc_UInt32 = null;
        Private___20_const_intnl_exitJumpLoc_UInt32 = null;
        Private___9_intnl_SystemInt32 = null;
        Private___5_const_intnl_SystemString = null;
        Private___3_intnl_SystemBoolean = null;
        Private___0_player_Player = null;
        Private___0_intnl_returnValSymbol_Boolean = null;
        Private___12_intnl_SystemBoolean = null;
        Private___9_intnl_SystemString = null;
        Private___6_const_intnl_exitJumpLoc_UInt32 = null;
        Private___18_intnl_SystemString = null;
        Private___23_const_intnl_SystemString = null;
        Private_myInstance = null;
        Private___6_intnl_SystemInt32 = null;
        Private___0_mp_names_StringArray = null;
        Private___6_intnl_SystemString = null;
        Private___0_intnl_SystemBoolean = null;
        Private___22_intnl_SystemString = null;
        Private___12_const_intnl_SystemString = null;
        Private___0_isSupporter_Boolean = null;
        Private___0_intnl_UnityEngineGameObject = null;
        Private___8_const_intnl_SystemString = null;
        Private___3_intnl_returnValSymbol_Boolean = null;
        Private___9_intnl_SystemStringArray = null;
        Private_ready = null;
        Private_vipColor = null;
        Private___24_intnl_SystemString = null;
        Private___15_const_intnl_exitJumpLoc_UInt32 = null;
        Private_joinSoundVip = null;
        Private___1_mp_player_VRCPlayerApi = null;
        Private___19_const_intnl_exitJumpLoc_UInt32 = null;
        Private_param = null;
        Private___21_intnl_SystemString = null;
        Private___8_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_const_intnl_SystemCharArray = null;
        Private___24_intnl_SystemBoolean = null;
        Private___9_const_intnl_SystemString = null;
        Private___0_intnl_SystemInt32 = null;
        Private___0_intnl_returnTarget_UInt32 = null;
        Private___0_intnl_SystemString = null;
        Private___10_intnl_SystemInt32 = null;
        Private___0_const_intnl_SystemUInt32 = null;
        Private___9_intnl_SystemBoolean = null;
        Private___13_intnl_SystemInt32 = null;
        Private___2_mp_player_VRCPlayerApi = null;
        Private_vipFlair = null;
        Private___29_intnl_SystemString = null;
        Private___0_intnl_returnValSymbol_Color = null;
        Private___0_wallText_String = null;
        Private___18_const_intnl_SystemString = null;
        Private___4_intnl_SystemStringArray = null;
        Private___6_intnl_SystemStringArray = null;
        Private_elites = null;
        Private___0_mp_player_VRCPlayerApi = null;
        Private___4_intnl_SystemInt32 = null;
        Private___4_intnl_SystemString = null;
        Private___0_playerName_String = null;
        Private___19_const_intnl_SystemString = null;
        Private___17_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_playerGO_GameObject = null;
        Private___28_intnl_SystemBoolean = null;
        Private___6_intnl_SystemBoolean = null;
        Private___24_const_intnl_SystemString = null;
        Private___16_intnl_SystemInt32 = null;
        Private___0_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___27_intnl_SystemString = null;
        Private___14_intnl_SystemBoolean = null;
        Private___0_intnl_SystemInt64 = null;
        Private___1_intnl_returnValSymbol_Boolean = null;
        Private___3_intnl_SystemInt32 = null;
        Private___31_intnl_SystemBoolean = null;
        Private___11_const_intnl_exitJumpLoc_UInt32 = null;
        Private___8_intnl_SystemBoolean = null;
        Private___1_intnl_interpolatedStr_String = null;
        Private___20_intnl_SystemBoolean = null;
        Private___3_intnl_SystemString = null;
        Private___1_intnl_SystemObject = null;
        Private_elitePlates = null;
        Private___0_mp_patronsToProcess_String = null;
        Private___1_intnl_UnityEngineVector3 = null;
        Private___2_const_intnl_SystemChar = null;
        Private___27_intnl_SystemBoolean = null;
        Private_specialColor = null;
        Private___19_intnl_SystemString = null;
        Private___2_const_intnl_SystemInt32 = null;
        Private___4_mp_player_VRCPlayerApi = null;
        Private___26_intnl_SystemString = null;
        Private_vipAndMasterButtons = null;
        Private___0_intnl_UnityEngineVector3 = null;
        Private___10_const_intnl_SystemString = null;
        Private___32_intnl_SystemBoolean = null;
        Private___0_button_UI_Interaction = null;
        Private___7_intnl_SystemInt32 = null;
        Private___0_intnl_UnityEngineTransform = null;
        Private_localPlayer = null;
        Private___1_const_intnl_SystemBoolean = null;
        Private___7_intnl_SystemString = null;
        Private___11_const_intnl_SystemString = null;
        Private___0_intnl_SystemStringArray = null;
        Private___1_intnl_Player = null;
        Private___16_const_intnl_SystemString = null;
        Private___2_intnl_SystemStringArray = null;
        Private_defaultColor = null;
        Private___0_const_intnl_SystemInt64 = null;
        Private___0_mp_newOn_Boolean = null;
        Private___18_intnl_SystemBoolean = null;
        Private___2_intnl_SystemBoolean = null;
        Private___0_groups_StringArray = null;
        Private___14_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_mp_list_StringArray = null;
        Private___3_const_intnl_SystemInt32 = null;
        Private___25_intnl_SystemString = null;
        Private_eliteJoinSounds = null;
        Private___18_const_intnl_exitJumpLoc_UInt32 = null;
        Private___17_intnl_SystemString = null;
        Private___13_const_intnl_SystemString = null;
        Private___8_intnl_SystemInt32 = null;
        Private___19_intnl_SystemInt32 = null;
        Private___2_const_intnl_SystemCharArray = null;
        Private___8_intnl_SystemString = null;
        Private___13_const_intnl_exitJumpLoc_UInt32 = null;
        Private___2_intnl_UnityEngineGameObject = null;
        Private___10_intnl_SystemBoolean = null;
        Private___2_const_intnl_SystemString = null;
        Private___21_intnl_SystemInt32 = null;
        Private___5_intnl_SystemStringArray = null;
        Private___1_const_intnl_SystemInt64 = null;
        Private___0_const_intnl_SystemInt32 = null;
        Private___33_intnl_SystemString = null;
        Private___1_const_intnl_exitJumpLoc_UInt32 = null;
        Private___25_intnl_SystemBoolean = null;
        Private___22_const_intnl_SystemString = null;
        Private___0_obj_GameObject = null;
        Private___17_intnl_SystemBoolean = null;
        Private___0_intnl_UnityEngineComponent = null;
    }

    #region Getter / Setters AstroUdonVariables  of ProcessPatronsRaw

    internal string __3_intnl_interpolatedStr_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_interpolatedStr_String != null)
            {
                return Private___3_intnl_interpolatedStr_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_intnl_interpolatedStr_String != null)
            {
                Private___3_intnl_interpolatedStr_String.Value = value;
            }
        }
    }

    internal TMPro.TextMeshProUGUI __0_intnl_TMProTextMeshProUGUI
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_TMProTextMeshProUGUI != null)
            {
                return Private___0_intnl_TMProTextMeshProUGUI.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_TMProTextMeshProUGUI != null)
            {
                Private___0_intnl_TMProTextMeshProUGUI.Value = value;
            }
        }
    }

    internal bool? __23_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___23_intnl_SystemBoolean != null)
            {
                return Private___23_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___23_intnl_SystemBoolean != null)
                {
                    Private___23_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __0_intnl_interpolatedStr_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_interpolatedStr_String != null)
            {
                return Private___0_intnl_interpolatedStr_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_interpolatedStr_String != null)
            {
                Private___0_intnl_interpolatedStr_String.Value = value;
            }
        }
    }

    internal int? __15_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___15_intnl_SystemInt32 != null)
            {
                return Private___15_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___15_intnl_SystemInt32 != null)
                {
                    Private___15_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject __1_intnl_UnityEngineGameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_UnityEngineGameObject != null)
            {
                return Private___1_intnl_UnityEngineGameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_UnityEngineGameObject != null)
            {
                Private___1_intnl_UnityEngineGameObject.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __3_mp_player_VRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_mp_player_VRCPlayerApi != null)
            {
                return Private___3_mp_player_VRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_mp_player_VRCPlayerApi != null)
            {
                Private___3_mp_player_VRCPlayerApi.Value = value;
            }
        }
    }

    internal uint? __21_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___21_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___21_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___21_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___21_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal int? __12_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___12_intnl_SystemInt32 != null)
            {
                return Private___12_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___12_intnl_SystemInt32 != null)
                {
                    Private___12_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string[] __7_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_intnl_SystemStringArray != null)
            {
                return Private___7_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___7_intnl_SystemStringArray != null)
            {
                Private___7_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal string __3_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_const_intnl_SystemString != null)
            {
                return Private___3_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_const_intnl_SystemString != null)
            {
                Private___3_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __3_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___3_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___3_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __26_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___26_intnl_SystemBoolean != null)
            {
                return Private___26_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___26_intnl_SystemBoolean != null)
                {
                    Private___26_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0_const_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemBoolean != null)
            {
                return Private___0_const_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_SystemBoolean != null)
                {
                    Private___0_const_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __1_const_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemInt32 != null)
            {
                return Private___1_const_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_const_intnl_SystemInt32 != null)
                {
                    Private___1_const_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __32_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___32_intnl_SystemString != null)
            {
                return Private___32_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___32_intnl_SystemString != null)
            {
                Private___32_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __0_mp_vips_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_vips_StringArray != null)
            {
                return Private___0_mp_vips_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_vips_StringArray != null)
            {
                Private___0_mp_vips_StringArray.Value = value;
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

    internal int? __1_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemInt32 != null)
            {
                return Private___1_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_SystemInt32 != null)
                {
                    Private___1_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __16_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___16_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___16_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___16_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___16_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

    internal string __1_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemString != null)
            {
                return Private___1_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_SystemString != null)
            {
                Private___1_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __1_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_i_Int32 != null)
            {
                return Private___1_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_i_Int32 != null)
                {
                    Private___1_i_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_j_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_j_Int32 != null)
            {
                return Private___0_j_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_j_Int32 != null)
                {
                    Private___0_j_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_i_Int32 != null)
            {
                return Private___0_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_i_Int32 != null)
                {
                    Private___0_i_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __3_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_i_Int32 != null)
            {
                return Private___3_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_i_Int32 != null)
                {
                    Private___3_i_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __2_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_i_Int32 != null)
            {
                return Private___2_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_i_Int32 != null)
                {
                    Private___2_i_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __4_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_i_Int32 != null)
            {
                return Private___4_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___4_i_Int32 != null)
                {
                    Private___4_i_Int32.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __2_intnl_VRCSDKBaseVRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                return Private___2_intnl_VRCSDKBaseVRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                Private___2_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
            }
        }
    }

    internal string __34_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___34_intnl_SystemString != null)
            {
                return Private___34_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___34_intnl_SystemString != null)
            {
                Private___34_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __0_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemString != null)
            {
                return Private___0_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_const_intnl_SystemString != null)
            {
                Private___0_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __29_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___29_intnl_SystemBoolean != null)
            {
                return Private___29_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___29_intnl_SystemBoolean != null)
                {
                    Private___29_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string[] __0_mp_elites_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_elites_StringArray != null)
            {
                return Private___0_mp_elites_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_elites_StringArray != null)
            {
                Private___0_mp_elites_StringArray.Value = value;
            }
        }
    }

    internal bool? __5_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_intnl_SystemBoolean != null)
            {
                return Private___5_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___5_intnl_SystemBoolean != null)
                {
                    Private___5_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __31_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___31_intnl_SystemString != null)
            {
                return Private___31_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___31_intnl_SystemString != null)
            {
                Private___31_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __10_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___10_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___10_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___10_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___10_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __2_intnl_returnValSymbol_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_returnValSymbol_Boolean != null)
            {
                return Private___2_intnl_returnValSymbol_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_intnl_returnValSymbol_Boolean != null)
                {
                    Private___2_intnl_returnValSymbol_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __5_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_intnl_SystemInt32 != null)
            {
                return Private___5_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___5_intnl_SystemInt32 != null)
                {
                    Private___5_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __0_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___0_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___0_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __15_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___15_intnl_SystemBoolean != null)
            {
                return Private___15_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___15_intnl_SystemBoolean != null)
                {
                    Private___15_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal TMPro.TextMeshProUGUI[] eliteTexts
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteTexts != null)
            {
                return Private_eliteTexts.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteTexts != null)
            {
                Private_eliteTexts.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __1_intnl_VRCSDKBaseVRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                return Private___1_intnl_VRCSDKBaseVRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                Private___1_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
            }
        }
    }

    internal string __20_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___20_intnl_SystemString != null)
            {
                return Private___20_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___20_intnl_SystemString != null)
            {
                Private___20_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __2_mp_names_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_mp_names_StringArray != null)
            {
                return Private___2_mp_names_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_mp_names_StringArray != null)
            {
                Private___2_mp_names_StringArray.Value = value;
            }
        }
    }

    internal string __5_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_intnl_SystemString != null)
            {
                return Private___5_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___5_intnl_SystemString != null)
            {
                Private___5_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __1_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemStringArray != null)
            {
                return Private___1_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_SystemStringArray != null)
            {
                Private___1_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal char[] __1_const_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemCharArray != null)
            {
                return Private___1_const_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_const_intnl_SystemCharArray != null)
            {
                Private___1_const_intnl_SystemCharArray.Value = value;
            }
        }
    }

    internal string __6_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_const_intnl_SystemString != null)
            {
                return Private___6_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___6_const_intnl_SystemString != null)
            {
                Private___6_const_intnl_SystemString.Value = value;
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

    internal bool? __21_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___21_intnl_SystemBoolean != null)
            {
                return Private___21_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___21_intnl_SystemBoolean != null)
                {
                    Private___21_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal uint? __5_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___5_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___5_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___5_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __13_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___13_intnl_SystemBoolean != null)
            {
                return Private___13_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___13_intnl_SystemBoolean != null)
                {
                    Private___13_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __7_mp_player_VRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_mp_player_VRCPlayerApi != null)
            {
                return Private___7_mp_player_VRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___7_mp_player_VRCPlayerApi != null)
            {
                Private___7_mp_player_VRCPlayerApi.Value = value;
            }
        }
    }

    internal string __1_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemString != null)
            {
                return Private___1_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_const_intnl_SystemString != null)
            {
                Private___1_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __8_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_intnl_SystemStringArray != null)
            {
                return Private___8_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___8_intnl_SystemStringArray != null)
            {
                Private___8_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __0_intnl_Player
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_Player != null)
            {
                return Private___0_intnl_Player.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_Player != null)
            {
                Private___0_intnl_Player.Value = value;
            }
        }
    }

    internal char? __0_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemChar != null)
            {
                return Private___0_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_SystemChar != null)
                {
                    Private___0_const_intnl_SystemChar.Value = value.Value;
                }
            }
        }
    }

    internal TMPro.TextMeshProUGUI vipText
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipText != null)
            {
                return Private_vipText.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipText != null)
            {
                Private_vipText.Value = value;
            }
        }
    }

    internal string __0_x_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_x_String != null)
            {
                return Private___0_x_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_x_String != null)
            {
                Private___0_x_String.Value = value;
            }
        }
    }

    internal uint? __2_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___2_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___2_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal int? __18_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___18_intnl_SystemInt32 != null)
            {
                return Private___18_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___18_intnl_SystemInt32 != null)
                {
                    Private___18_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string[] __1_mp_names_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_mp_names_StringArray != null)
            {
                return Private___1_mp_names_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_mp_names_StringArray != null)
            {
                Private___1_mp_names_StringArray.Value = value;
            }
        }
    }

    internal bool? __16_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___16_intnl_SystemBoolean != null)
            {
                return Private___16_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___16_intnl_SystemBoolean != null)
                {
                    Private___16_intnl_SystemBoolean.Value = value.Value;
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

    internal string __14_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___14_const_intnl_SystemString != null)
            {
                return Private___14_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___14_const_intnl_SystemString != null)
            {
                Private___14_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __10_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___10_intnl_SystemStringArray != null)
            {
                return Private___10_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___10_intnl_SystemStringArray != null)
            {
                Private___10_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal bool? __7_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_intnl_SystemBoolean != null)
            {
                return Private___7_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___7_intnl_SystemBoolean != null)
                {
                    Private___7_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __20_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___20_intnl_SystemInt32 != null)
            {
                return Private___20_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___20_intnl_SystemInt32 != null)
                {
                    Private___20_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal long? __1_intnl_SystemInt64
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemInt64 != null)
            {
                return Private___1_intnl_SystemInt64.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_SystemInt64 != null)
                {
                    Private___1_intnl_SystemInt64.Value = value.Value;
                }
            }
        }
    }

    internal string[] __3_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemStringArray != null)
            {
                return Private___3_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_intnl_SystemStringArray != null)
            {
                Private___3_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal bool? __22_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___22_intnl_SystemBoolean != null)
            {
                return Private___22_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___22_intnl_SystemBoolean != null)
                {
                    Private___22_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Component[] __0_intnl_UnityEngineComponentArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineComponentArray != null)
            {
                return Private___0_intnl_UnityEngineComponentArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_UnityEngineComponentArray != null)
            {
                Private___0_intnl_UnityEngineComponentArray.Value = value;
            }
        }
    }

    internal uint? __7_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___7_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___7_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___7_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __28_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___28_intnl_SystemString != null)
            {
                return Private___28_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___28_intnl_SystemString != null)
            {
                Private___28_intnl_SystemString.Value = value;
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

    internal bool? __0_newOn_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_newOn_Boolean != null)
            {
                return Private___0_newOn_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_newOn_Boolean != null)
                {
                    Private___0_newOn_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal string __2_intnl_interpolatedStr_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_interpolatedStr_String != null)
            {
                return Private___2_intnl_interpolatedStr_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_interpolatedStr_String != null)
            {
                Private___2_intnl_interpolatedStr_String.Value = value;
            }
        }
    }

    internal string __0_divider_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_divider_String != null)
            {
                return Private___0_divider_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_divider_String != null)
            {
                Private___0_divider_String.Value = value;
            }
        }
    }

    internal string __7_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_const_intnl_SystemString != null)
            {
                return Private___7_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___7_const_intnl_SystemString != null)
            {
                Private___7_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __15_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___15_const_intnl_SystemString != null)
            {
                return Private___15_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___15_const_intnl_SystemString != null)
            {
                Private___15_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal long? __refl_const_intnl_udonTypeID
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___refl_const_intnl_udonTypeID != null)
            {
                return Private___refl_const_intnl_udonTypeID.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___refl_const_intnl_udonTypeID != null)
                {
                    Private___refl_const_intnl_udonTypeID.Value = value.Value;
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

    internal bool? __4_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_SystemBoolean != null)
            {
                return Private___4_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___4_intnl_SystemBoolean != null)
                {
                    Private___4_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __19_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___19_intnl_SystemBoolean != null)
            {
                return Private___19_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___19_intnl_SystemBoolean != null)
                {
                    Private___19_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __refl_const_intnl_udonTypeName
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___refl_const_intnl_udonTypeName != null)
            {
                return Private___refl_const_intnl_udonTypeName.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___refl_const_intnl_udonTypeName != null)
            {
                Private___refl_const_intnl_udonTypeName.Value = value;
            }
        }
    }

    internal char? __1_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemChar != null)
            {
                return Private___1_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_const_intnl_SystemChar != null)
                {
                    Private___1_const_intnl_SystemChar.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject __0_intnl_SystemObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemObject != null)
            {
                return Private___0_intnl_SystemObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_SystemObject != null)
            {
                Private___0_intnl_SystemObject.Value = value;
            }
        }
    }

    internal bool? __1_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemBoolean != null)
            {
                return Private___1_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_SystemBoolean != null)
                {
                    Private___1_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __14_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___14_intnl_SystemInt32 != null)
            {
                return Private___14_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___14_intnl_SystemInt32 != null)
                {
                    Private___14_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __12_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___12_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___12_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___12_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___12_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __17_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___17_const_intnl_SystemString != null)
            {
                return Private___17_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___17_const_intnl_SystemString != null)
            {
                Private___17_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __11_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___11_intnl_SystemInt32 != null)
            {
                return Private___11_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___11_intnl_SystemInt32 != null)
                {
                    Private___11_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal int? __17_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___17_intnl_SystemInt32 != null)
            {
                return Private___17_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___17_intnl_SystemInt32 != null)
                {
                    Private___17_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __4_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_const_intnl_SystemString != null)
            {
                return Private___4_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_const_intnl_SystemString != null)
            {
                Private___4_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] vips
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vips != null)
            {
                return Private_vips.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vips != null)
            {
                Private_vips.Value = value;
            }
        }
    }

    internal string __20_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___20_const_intnl_SystemString != null)
            {
                return Private___20_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___20_const_intnl_SystemString != null)
            {
                Private___20_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __11_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___11_intnl_SystemBoolean != null)
            {
                return Private___11_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___11_intnl_SystemBoolean != null)
                {
                    Private___11_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __2_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_SystemInt32 != null)
            {
                return Private___2_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_intnl_SystemInt32 != null)
                {
                    Private___2_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __4_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___4_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___4_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___4_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __30_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___30_intnl_SystemBoolean != null)
            {
                return Private___30_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___30_intnl_SystemBoolean != null)
                {
                    Private___30_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __2_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_SystemString != null)
            {
                return Private___2_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_SystemString != null)
            {
                Private___2_intnl_SystemString.Value = value;
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

    internal VRC.Udon.UdonBehaviour __0_intnl_JetDogUIInteractionUI_Interaction
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_JetDogUIInteractionUI_Interaction != null)
            {
                return Private___0_intnl_JetDogUIInteractionUI_Interaction.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_JetDogUIInteractionUI_Interaction != null)
            {
                Private___0_intnl_JetDogUIInteractionUI_Interaction.Value = value;
            }
        }
    }

    internal string __21_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___21_const_intnl_SystemString != null)
            {
                return Private___21_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___21_const_intnl_SystemString != null)
            {
                Private___21_const_intnl_SystemString.Value = value;
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

    internal string __23_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___23_intnl_SystemString != null)
            {
                return Private___23_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___23_intnl_SystemString != null)
            {
                Private___23_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __9_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___9_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___9_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___9_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __20_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___20_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___20_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___20_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___20_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal int? __9_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_intnl_SystemInt32 != null)
            {
                return Private___9_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___9_intnl_SystemInt32 != null)
                {
                    Private___9_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __5_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_const_intnl_SystemString != null)
            {
                return Private___5_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___5_const_intnl_SystemString != null)
            {
                Private___5_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __3_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemBoolean != null)
            {
                return Private___3_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_intnl_SystemBoolean != null)
                {
                    Private___3_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __0_player_Player
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_player_Player != null)
            {
                return Private___0_player_Player.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_player_Player != null)
            {
                Private___0_player_Player.Value = value;
            }
        }
    }

    internal bool? __0_intnl_returnValSymbol_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_returnValSymbol_Boolean != null)
            {
                return Private___0_intnl_returnValSymbol_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_returnValSymbol_Boolean != null)
                {
                    Private___0_intnl_returnValSymbol_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __12_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___12_intnl_SystemBoolean != null)
            {
                return Private___12_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___12_intnl_SystemBoolean != null)
                {
                    Private___12_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __9_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_intnl_SystemString != null)
            {
                return Private___9_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___9_intnl_SystemString != null)
            {
                Private___9_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __6_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___6_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___6_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___6_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __18_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___18_intnl_SystemString != null)
            {
                return Private___18_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___18_intnl_SystemString != null)
            {
                Private___18_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __23_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___23_const_intnl_SystemString != null)
            {
                return Private___23_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___23_const_intnl_SystemString != null)
            {
                Private___23_const_intnl_SystemString.Value = value;
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

    internal int? __6_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_intnl_SystemInt32 != null)
            {
                return Private___6_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___6_intnl_SystemInt32 != null)
                {
                    Private___6_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string[] __0_mp_names_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_names_StringArray != null)
            {
                return Private___0_mp_names_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_names_StringArray != null)
            {
                Private___0_mp_names_StringArray.Value = value;
            }
        }
    }

    internal string __6_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_intnl_SystemString != null)
            {
                return Private___6_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___6_intnl_SystemString != null)
            {
                Private___6_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __0_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemBoolean != null)
            {
                return Private___0_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_SystemBoolean != null)
                {
                    Private___0_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __22_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___22_intnl_SystemString != null)
            {
                return Private___22_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___22_intnl_SystemString != null)
            {
                Private___22_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __12_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___12_const_intnl_SystemString != null)
            {
                return Private___12_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___12_const_intnl_SystemString != null)
            {
                Private___12_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __0_isSupporter_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_isSupporter_Boolean != null)
            {
                return Private___0_isSupporter_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_isSupporter_Boolean != null)
                {
                    Private___0_isSupporter_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject __0_intnl_UnityEngineGameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineGameObject != null)
            {
                return Private___0_intnl_UnityEngineGameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_UnityEngineGameObject != null)
            {
                Private___0_intnl_UnityEngineGameObject.Value = value;
            }
        }
    }

    internal string __8_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_const_intnl_SystemString != null)
            {
                return Private___8_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___8_const_intnl_SystemString != null)
            {
                Private___8_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __3_intnl_returnValSymbol_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_returnValSymbol_Boolean != null)
            {
                return Private___3_intnl_returnValSymbol_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_intnl_returnValSymbol_Boolean != null)
                {
                    Private___3_intnl_returnValSymbol_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal string[] __9_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_intnl_SystemStringArray != null)
            {
                return Private___9_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___9_intnl_SystemStringArray != null)
            {
                Private___9_intnl_SystemStringArray.Value = value;
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

    internal string __24_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___24_intnl_SystemString != null)
            {
                return Private___24_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___24_intnl_SystemString != null)
            {
                Private___24_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __15_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___15_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___15_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___15_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___15_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

    internal VRC.SDKBase.VRCPlayerApi __1_mp_player_VRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_mp_player_VRCPlayerApi != null)
            {
                return Private___1_mp_player_VRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_mp_player_VRCPlayerApi != null)
            {
                Private___1_mp_player_VRCPlayerApi.Value = value;
            }
        }
    }

    internal uint? __19_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___19_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___19_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___19_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___19_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

    internal string __21_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___21_intnl_SystemString != null)
            {
                return Private___21_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___21_intnl_SystemString != null)
            {
                Private___21_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __8_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___8_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___8_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___8_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal char[] __0_const_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemCharArray != null)
            {
                return Private___0_const_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_const_intnl_SystemCharArray != null)
            {
                Private___0_const_intnl_SystemCharArray.Value = value;
            }
        }
    }

    internal bool? __24_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___24_intnl_SystemBoolean != null)
            {
                return Private___24_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___24_intnl_SystemBoolean != null)
                {
                    Private___24_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __9_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_const_intnl_SystemString != null)
            {
                return Private___9_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___9_const_intnl_SystemString != null)
            {
                Private___9_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __0_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemInt32 != null)
            {
                return Private___0_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_SystemInt32 != null)
                {
                    Private___0_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __0_intnl_returnTarget_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_returnTarget_UInt32 != null)
            {
                return Private___0_intnl_returnTarget_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_returnTarget_UInt32 != null)
                {
                    Private___0_intnl_returnTarget_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __0_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemString != null)
            {
                return Private___0_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_SystemString != null)
            {
                Private___0_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __10_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___10_intnl_SystemInt32 != null)
            {
                return Private___10_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___10_intnl_SystemInt32 != null)
                {
                    Private___10_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal uint? __0_const_intnl_SystemUInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemUInt32 != null)
            {
                return Private___0_const_intnl_SystemUInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_SystemUInt32 != null)
                {
                    Private___0_const_intnl_SystemUInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __9_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_intnl_SystemBoolean != null)
            {
                return Private___9_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___9_intnl_SystemBoolean != null)
                {
                    Private___9_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __13_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___13_intnl_SystemInt32 != null)
            {
                return Private___13_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___13_intnl_SystemInt32 != null)
                {
                    Private___13_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __2_mp_player_VRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_mp_player_VRCPlayerApi != null)
            {
                return Private___2_mp_player_VRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_mp_player_VRCPlayerApi != null)
            {
                Private___2_mp_player_VRCPlayerApi.Value = value;
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

    internal string __29_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___29_intnl_SystemString != null)
            {
                return Private___29_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___29_intnl_SystemString != null)
            {
                Private___29_intnl_SystemString.Value = value;
            }
        }
    }

    internal UnityEngine.Color? __0_intnl_returnValSymbol_Color
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_returnValSymbol_Color != null)
            {
                return Private___0_intnl_returnValSymbol_Color.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_returnValSymbol_Color != null)
                {
                    Private___0_intnl_returnValSymbol_Color.Value = value.Value;
                }
            }
        }
    }

    internal string __0_wallText_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_wallText_String != null)
            {
                return Private___0_wallText_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_wallText_String != null)
            {
                Private___0_wallText_String.Value = value;
            }
        }
    }

    internal string __18_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___18_const_intnl_SystemString != null)
            {
                return Private___18_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___18_const_intnl_SystemString != null)
            {
                Private___18_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __4_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_SystemStringArray != null)
            {
                return Private___4_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_intnl_SystemStringArray != null)
            {
                Private___4_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal string[] __6_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_intnl_SystemStringArray != null)
            {
                return Private___6_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___6_intnl_SystemStringArray != null)
            {
                Private___6_intnl_SystemStringArray.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi __0_mp_player_VRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_player_VRCPlayerApi != null)
            {
                return Private___0_mp_player_VRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_player_VRCPlayerApi != null)
            {
                Private___0_mp_player_VRCPlayerApi.Value = value;
            }
        }
    }

    internal int? __4_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_SystemInt32 != null)
            {
                return Private___4_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___4_intnl_SystemInt32 != null)
                {
                    Private___4_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __4_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_SystemString != null)
            {
                return Private___4_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_intnl_SystemString != null)
            {
                Private___4_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __0_playerName_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_playerName_String != null)
            {
                return Private___0_playerName_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_playerName_String != null)
            {
                Private___0_playerName_String.Value = value;
            }
        }
    }

    internal string __19_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___19_const_intnl_SystemString != null)
            {
                return Private___19_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___19_const_intnl_SystemString != null)
            {
                Private___19_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __17_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___17_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___17_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___17_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___17_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject __0_playerGO_GameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_playerGO_GameObject != null)
            {
                return Private___0_playerGO_GameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_playerGO_GameObject != null)
            {
                Private___0_playerGO_GameObject.Value = value;
            }
        }
    }

    internal bool? __28_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___28_intnl_SystemBoolean != null)
            {
                return Private___28_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___28_intnl_SystemBoolean != null)
                {
                    Private___28_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __6_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_intnl_SystemBoolean != null)
            {
                return Private___6_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___6_intnl_SystemBoolean != null)
                {
                    Private___6_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __24_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___24_const_intnl_SystemString != null)
            {
                return Private___24_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___24_const_intnl_SystemString != null)
            {
                Private___24_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __16_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___16_intnl_SystemInt32 != null)
            {
                return Private___16_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___16_intnl_SystemInt32 != null)
                {
                    Private___16_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __0_intnl_VRCSDKBaseVRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                return Private___0_intnl_VRCSDKBaseVRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                Private___0_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
            }
        }
    }

    internal string __27_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___27_intnl_SystemString != null)
            {
                return Private___27_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___27_intnl_SystemString != null)
            {
                Private___27_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __14_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___14_intnl_SystemBoolean != null)
            {
                return Private___14_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___14_intnl_SystemBoolean != null)
                {
                    Private___14_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal long? __0_intnl_SystemInt64
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemInt64 != null)
            {
                return Private___0_intnl_SystemInt64.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_SystemInt64 != null)
                {
                    Private___0_intnl_SystemInt64.Value = value.Value;
                }
            }
        }
    }

    internal bool? __1_intnl_returnValSymbol_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_returnValSymbol_Boolean != null)
            {
                return Private___1_intnl_returnValSymbol_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_returnValSymbol_Boolean != null)
                {
                    Private___1_intnl_returnValSymbol_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __3_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemInt32 != null)
            {
                return Private___3_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_intnl_SystemInt32 != null)
                {
                    Private___3_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __31_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___31_intnl_SystemBoolean != null)
            {
                return Private___31_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___31_intnl_SystemBoolean != null)
                {
                    Private___31_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal uint? __11_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___11_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___11_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___11_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___11_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __8_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_intnl_SystemBoolean != null)
            {
                return Private___8_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___8_intnl_SystemBoolean != null)
                {
                    Private___8_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __1_intnl_interpolatedStr_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_interpolatedStr_String != null)
            {
                return Private___1_intnl_interpolatedStr_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_interpolatedStr_String != null)
            {
                Private___1_intnl_interpolatedStr_String.Value = value;
            }
        }
    }

    internal bool? __20_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___20_intnl_SystemBoolean != null)
            {
                return Private___20_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___20_intnl_SystemBoolean != null)
                {
                    Private___20_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __3_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemString != null)
            {
                return Private___3_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_intnl_SystemString != null)
            {
                Private___3_intnl_SystemString.Value = value;
            }
        }
    }

    internal long? __1_intnl_SystemObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemObject != null)
            {
                return Private___1_intnl_SystemObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_SystemObject != null)
                {
                    Private___1_intnl_SystemObject.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject[] elitePlates
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_elitePlates != null)
            {
                return Private_elitePlates.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_elitePlates != null)
            {
                Private_elitePlates.Value = value;
            }
        }
    }

    internal string __0_mp_patronsToProcess_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_patronsToProcess_String != null)
            {
                return Private___0_mp_patronsToProcess_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_patronsToProcess_String != null)
            {
                Private___0_mp_patronsToProcess_String.Value = value;
            }
        }
    }

    internal UnityEngine.Vector3? __1_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_UnityEngineVector3 != null)
            {
                return Private___1_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_UnityEngineVector3 != null)
                {
                    Private___1_intnl_UnityEngineVector3.Value = value.Value;
                }
            }
        }
    }

    internal char? __2_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_SystemChar != null)
            {
                return Private___2_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_const_intnl_SystemChar != null)
                {
                    Private___2_const_intnl_SystemChar.Value = value.Value;
                }
            }
        }
    }

    internal bool? __27_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___27_intnl_SystemBoolean != null)
            {
                return Private___27_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___27_intnl_SystemBoolean != null)
                {
                    Private___27_intnl_SystemBoolean.Value = value.Value;
                }
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

    internal string __19_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___19_intnl_SystemString != null)
            {
                return Private___19_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___19_intnl_SystemString != null)
            {
                Private___19_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __2_const_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_SystemInt32 != null)
            {
                return Private___2_const_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_const_intnl_SystemInt32 != null)
                {
                    Private___2_const_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __4_mp_player_VRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_mp_player_VRCPlayerApi != null)
            {
                return Private___4_mp_player_VRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_mp_player_VRCPlayerApi != null)
            {
                Private___4_mp_player_VRCPlayerApi.Value = value;
            }
        }
    }

    internal string __26_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___26_intnl_SystemString != null)
            {
                return Private___26_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___26_intnl_SystemString != null)
            {
                Private___26_intnl_SystemString.Value = value;
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

    internal UnityEngine.Vector3? __0_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineVector3 != null)
            {
                return Private___0_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_UnityEngineVector3 != null)
                {
                    Private___0_intnl_UnityEngineVector3.Value = value.Value;
                }
            }
        }
    }

    internal string __10_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___10_const_intnl_SystemString != null)
            {
                return Private___10_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___10_const_intnl_SystemString != null)
            {
                Private___10_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __32_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___32_intnl_SystemBoolean != null)
            {
                return Private___32_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___32_intnl_SystemBoolean != null)
                {
                    Private___32_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __0_button_UI_Interaction
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_button_UI_Interaction != null)
            {
                return Private___0_button_UI_Interaction.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_button_UI_Interaction != null)
            {
                Private___0_button_UI_Interaction.Value = value;
            }
        }
    }

    internal int? __7_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_intnl_SystemInt32 != null)
            {
                return Private___7_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___7_intnl_SystemInt32 != null)
                {
                    Private___7_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Transform __0_intnl_UnityEngineTransform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineTransform != null)
            {
                return Private___0_intnl_UnityEngineTransform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_UnityEngineTransform != null)
            {
                Private___0_intnl_UnityEngineTransform.Value = value;
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

    internal bool? __1_const_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemBoolean != null)
            {
                return Private___1_const_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_const_intnl_SystemBoolean != null)
                {
                    Private___1_const_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __7_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_intnl_SystemString != null)
            {
                return Private___7_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___7_intnl_SystemString != null)
            {
                Private___7_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __11_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___11_const_intnl_SystemString != null)
            {
                return Private___11_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___11_const_intnl_SystemString != null)
            {
                Private___11_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __0_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemStringArray != null)
            {
                return Private___0_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_SystemStringArray != null)
            {
                Private___0_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __1_intnl_Player
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_Player != null)
            {
                return Private___1_intnl_Player.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_Player != null)
            {
                Private___1_intnl_Player.Value = value;
            }
        }
    }

    internal string __16_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___16_const_intnl_SystemString != null)
            {
                return Private___16_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___16_const_intnl_SystemString != null)
            {
                Private___16_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __2_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_SystemStringArray != null)
            {
                return Private___2_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_SystemStringArray != null)
            {
                Private___2_intnl_SystemStringArray.Value = value;
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

    internal long? __0_const_intnl_SystemInt64
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemInt64 != null)
            {
                return Private___0_const_intnl_SystemInt64.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_SystemInt64 != null)
                {
                    Private___0_const_intnl_SystemInt64.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0_mp_newOn_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_newOn_Boolean != null)
            {
                return Private___0_mp_newOn_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_mp_newOn_Boolean != null)
                {
                    Private___0_mp_newOn_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __18_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___18_intnl_SystemBoolean != null)
            {
                return Private___18_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___18_intnl_SystemBoolean != null)
                {
                    Private___18_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __2_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_SystemBoolean != null)
            {
                return Private___2_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_intnl_SystemBoolean != null)
                {
                    Private___2_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string[] __0_groups_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_groups_StringArray != null)
            {
                return Private___0_groups_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_groups_StringArray != null)
            {
                Private___0_groups_StringArray.Value = value;
            }
        }
    }

    internal uint? __14_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___14_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___14_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___14_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___14_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal string[] __0_mp_list_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_list_StringArray != null)
            {
                return Private___0_mp_list_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_list_StringArray != null)
            {
                Private___0_mp_list_StringArray.Value = value;
            }
        }
    }

    internal int? __3_const_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_const_intnl_SystemInt32 != null)
            {
                return Private___3_const_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_const_intnl_SystemInt32 != null)
                {
                    Private___3_const_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __25_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___25_intnl_SystemString != null)
            {
                return Private___25_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___25_intnl_SystemString != null)
            {
                Private___25_intnl_SystemString.Value = value;
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

    internal uint? __18_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___18_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___18_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___18_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___18_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __17_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___17_intnl_SystemString != null)
            {
                return Private___17_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___17_intnl_SystemString != null)
            {
                Private___17_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __13_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___13_const_intnl_SystemString != null)
            {
                return Private___13_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___13_const_intnl_SystemString != null)
            {
                Private___13_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __8_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_intnl_SystemInt32 != null)
            {
                return Private___8_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___8_intnl_SystemInt32 != null)
                {
                    Private___8_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal int? __19_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___19_intnl_SystemInt32 != null)
            {
                return Private___19_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___19_intnl_SystemInt32 != null)
                {
                    Private___19_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal char[] __2_const_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_SystemCharArray != null)
            {
                return Private___2_const_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_const_intnl_SystemCharArray != null)
            {
                Private___2_const_intnl_SystemCharArray.Value = value;
            }
        }
    }

    internal string __8_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_intnl_SystemString != null)
            {
                return Private___8_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___8_intnl_SystemString != null)
            {
                Private___8_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __13_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___13_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___13_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___13_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___13_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject __2_intnl_UnityEngineGameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_UnityEngineGameObject != null)
            {
                return Private___2_intnl_UnityEngineGameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_UnityEngineGameObject != null)
            {
                Private___2_intnl_UnityEngineGameObject.Value = value;
            }
        }
    }

    internal bool? __10_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___10_intnl_SystemBoolean != null)
            {
                return Private___10_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___10_intnl_SystemBoolean != null)
                {
                    Private___10_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __2_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_SystemString != null)
            {
                return Private___2_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_const_intnl_SystemString != null)
            {
                Private___2_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __21_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___21_intnl_SystemInt32 != null)
            {
                return Private___21_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___21_intnl_SystemInt32 != null)
                {
                    Private___21_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string[] __5_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_intnl_SystemStringArray != null)
            {
                return Private___5_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___5_intnl_SystemStringArray != null)
            {
                Private___5_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal long? __1_const_intnl_SystemInt64
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemInt64 != null)
            {
                return Private___1_const_intnl_SystemInt64.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_const_intnl_SystemInt64 != null)
                {
                    Private___1_const_intnl_SystemInt64.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_const_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemInt32 != null)
            {
                return Private___0_const_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_SystemInt32 != null)
                {
                    Private___0_const_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __33_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___33_intnl_SystemString != null)
            {
                return Private___33_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___33_intnl_SystemString != null)
            {
                Private___33_intnl_SystemString.Value = value;
            }
        }
    }

    internal uint? __1_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___1_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___1_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __25_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___25_intnl_SystemBoolean != null)
            {
                return Private___25_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___25_intnl_SystemBoolean != null)
                {
                    Private___25_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __22_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___22_const_intnl_SystemString != null)
            {
                return Private___22_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___22_const_intnl_SystemString != null)
            {
                Private___22_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal UnityEngine.GameObject __0_obj_GameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_obj_GameObject != null)
            {
                return Private___0_obj_GameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_obj_GameObject != null)
            {
                Private___0_obj_GameObject.Value = value;
            }
        }
    }

    internal bool? __17_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___17_intnl_SystemBoolean != null)
            {
                return Private___17_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___17_intnl_SystemBoolean != null)
                {
                    Private___17_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __0_intnl_UnityEngineComponent
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineComponent != null)
            {
                return Private___0_intnl_UnityEngineComponent.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_UnityEngineComponent != null)
            {
                Private___0_intnl_UnityEngineComponent.Value = value;
            }
        }
    }

    #endregion Getter / Setters AstroUdonVariables  of ProcessPatronsRaw

    #region AstroUdonVariables  of ProcessPatronsRaw

    private AstroUdonVariable<string> Private___3_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___0_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___1_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___3_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___21_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___7_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___32_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_mp_vips_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_creatorFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___16_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_eliteFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_eliteColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_j_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___2_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___34_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_mp_elites_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___31_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___2_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI[]> Private_eliteTexts { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___20_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___2_mp_names_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___1_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___1_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.TextAsset> Private_testPatrons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___7_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___8_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___0_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_vipText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_x_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___1_mp_names_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_vipObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___10_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___1_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___3_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Component[]> Private___0_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___28_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_nonVipObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_newOn_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_divider_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_cyan { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___1_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___12_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_vips { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip> Private_joinSoundElite { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_JetDogUIInteractionUI_Interaction { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_players { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___23_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___20_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_player_Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___18_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___23_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_myInstance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_mp_names_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___22_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_isSupporter_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___3_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___9_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_ready { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_vipColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___24_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___15_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip> Private_joinSoundVip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___19_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___21_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___0_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___2_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Sprite> Private_vipFlair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___29_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_returnValSymbol_Color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_wallText_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___4_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___6_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_elites { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_playerName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___17_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_playerGO_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___24_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___27_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___0_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___1_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_elitePlates { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_mp_patronsToProcess_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___2_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_specialColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___19_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___4_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___26_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Component[]> Private_vipAndMasterButtons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_button_UI_Interaction { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_localPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___2_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private_defaultColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___0_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_mp_newOn_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_groups_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___14_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_mp_list_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___25_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip[]> Private_eliteJoinSounds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___18_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___17_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___2_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___13_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___2_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___5_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___1_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___33_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_obj_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    #endregion AstroUdonVariables  of ProcessPatronsRaw

    // Use this for initialization
}