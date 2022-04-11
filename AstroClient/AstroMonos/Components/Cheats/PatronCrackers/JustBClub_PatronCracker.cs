namespace AstroClient.AstroMonos.Components.Cheats.PatronCrackers;

using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using ClientAttributes;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using WorldModifications.WorldsIds;
using xAstroBoy.Utility;
using IntPtr = System.IntPtr;

[RegisterComponent]
public class JustBClub_PatronCracker : AstroMonoBehaviour
{
    private readonly List<Object> AntiGarbageCollection = new();

    public JustBClub_PatronCracker(IntPtr ptr) : base(ptr)
    {
        AntiGarbageCollection.Add(this);
    }

    internal override void OnRoomLeft()
    {
        Destroy(this);
    }

    private void OnDestroy()
    {
        Cleanup_PatreonSystem();
    }

    internal void Start()
    {
        if (WorldUtils.WorldID.Equals(WorldIds.JustBClub))
        {
            var system = gameObject.FindUdonEvent("IsElite");
            if (system != null)
            {
                PatreonSystem = system.RawItem;
                Initialize_PatreonSystem();
                Log.Debug("Added Patron Cracker to This Patron System Successfully!");
            }
            else
            {
                Log.Error("Can't Find PatronControl behaviour, Unable to Add Reader Component, did the author update the world?");
                Destroy(this);
            }
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if(!__0_isPatron_Boolean.GetValueOrDefault(false))
        {
            __0_isPatron_Boolean = true;
        }
        if(!__0_isElite_Boolean.GetValueOrDefault(false))
        {
            __0_isElite_Boolean = true;
        }
    }

    // TODO: Bind UdonBehaviour with this section
    // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!
    // TODO: READER FOR UDONBEHAVIOUR Patreon!
    private RawUdonBehaviour PatreonSystem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    private void Initialize_PatreonSystem()
    {
        Private___33_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__33_const_intnl_SystemString");
        Private___0_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PatreonSystem, "__0_intnl_TMProTextMeshProUGUI");
        Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__23_intnl_SystemBoolean");
        Private___32_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__32_intnl_SystemInt32");
        Private_utilities = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "utilities");
        Private___48_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__48_const_intnl_SystemString");
        Private___0_intnl_interpolatedStr_String = new AstroUdonVariable<string>(PatreonSystem, "__0_intnl_interpolatedStr_String");
        Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__15_intnl_SystemInt32");
        Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatreonSystem, "__0_intnl_VRCSDKBaseVRCPlayerApiArray");
        Private___1_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__1_intnl_UnityEngineGameObject");
        Private___3_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "__3_mp_player_VRCPlayerApi");
        Private___21_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__21_const_intnl_exitJumpLoc_UInt32");
        Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__12_intnl_SystemInt32");
        Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__3_const_intnl_SystemString");
        Private_vipBadParticle = new AstroUdonVariable<UnityEngine.ParticleSystem>(PatreonSystem, "vipBadParticle");
        Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__3_const_intnl_exitJumpLoc_UInt32");
        Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__26_intnl_SystemBoolean");
        Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__0_const_intnl_SystemBoolean");
        Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__41_intnl_SystemBoolean");
        Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(PatreonSystem, "__1_intnl_UnityEngineTransform");
        Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__1_const_intnl_SystemInt32");
        Private___49_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__49_const_intnl_SystemString");
        Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__1_intnl_SystemInt32");
        Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__16_const_intnl_exitJumpLoc_UInt32");
        Private_ownFlairEnabled = new AstroUdonVariable<bool>(PatreonSystem, "ownFlairEnabled");
        Private___1_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__1_intnl_SystemString");
        Private_vipOnlyButton = new AstroUdonVariable<UnityEngine.MeshRenderer>(PatreonSystem, "vipOnlyButton");
        Private___1_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__1_i_Int32");
        Private___1_x_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__1_x_Int32");
        Private___0_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__0_i_Int32");
        Private___0_x_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__0_x_Int32");
        Private___0_y_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__0_y_Int32");
        Private___3_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__3_i_Int32");
        Private___2_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__2_i_Int32");
        Private___2_x_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__2_x_Int32");
        Private___5_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__5_i_Int32");
        Private___4_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__4_i_Int32");
        Private___7_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__7_i_Int32");
        Private___6_i_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__6_i_Int32");
        Private___2_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "__2_intnl_VRCSDKBaseVRCPlayerApi");
        Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__0_const_intnl_SystemString");
        Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__42_intnl_SystemBoolean");
        Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(PatreonSystem, "__0_const_intnl_SystemSingle");
        Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__29_intnl_SystemBoolean");
        Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(PatreonSystem, "__1_intnl_SystemSingle");
        Private___48_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__48_intnl_SystemString");
        Private___0_mp_elites_StringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_mp_elites_StringArray");
        Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__5_intnl_SystemBoolean");
        Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__10_const_intnl_exitJumpLoc_UInt32");
        Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__5_intnl_SystemInt32");
        Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__0_const_intnl_exitJumpLoc_UInt32");
        Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__15_intnl_SystemBoolean");
        Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "__1_intnl_VRCSDKBaseVRCPlayerApi");
        Private___6_intnl_UnityEngineMaterial = new AstroUdonVariable<UnityEngine.Material>(PatreonSystem, "__6_intnl_UnityEngineMaterial");
        Private___24_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__24_const_intnl_exitJumpLoc_UInt32");
        Private___20_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__20_intnl_SystemString");
        Private___5_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__5_intnl_SystemString");
        Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__34_intnl_SystemBoolean");
        Private___28_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__28_const_intnl_SystemString");
        Private___2_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(PatreonSystem, "__2_intnl_UnityEngineTransform");
        Private___1_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__1_intnl_SystemStringArray");
        Private___1_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatreonSystem, "__1_const_intnl_SystemCharArray");
        Private_elitesInInstance = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatreonSystem, "elitesInInstance");
        Private___28_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__28_const_intnl_exitJumpLoc_UInt32");
        Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__6_const_intnl_SystemString");
        Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__21_intnl_SystemBoolean");
        Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__5_const_intnl_exitJumpLoc_UInt32");
        Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__13_intnl_SystemBoolean");
        Private_vipFlairs = new AstroUdonVariable<UnityEngine.GameObject[]>(PatreonSystem, "vipFlairs");
        Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__1_const_intnl_SystemString");
        Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__4_const_intnl_SystemInt32");
        Private___40_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__40_const_intnl_SystemString");
        Private___29_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__29_const_intnl_SystemString");
        Private___0_const_intnl_SystemChar = new AstroUdonVariable<char>(PatreonSystem, "__0_const_intnl_SystemChar");
        Private___23_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__23_const_intnl_exitJumpLoc_UInt32");
        Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__2_const_intnl_exitJumpLoc_UInt32");
        Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__18_intnl_SystemInt32");
        Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__16_intnl_SystemBoolean");
        Private_vipGoodAudio = new AstroUdonVariable<UnityEngine.AudioSource>(PatreonSystem, "vipGoodAudio");
        Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__14_const_intnl_SystemString");
        Private___4_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__4_intnl_UnityEngineGameObject");
        Private___41_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__41_const_intnl_SystemString");
        Private___0_elitesArray2_StringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_elitesArray2_StringArray");
        Private___46_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__46_const_intnl_SystemString");
        Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__7_intnl_SystemBoolean");
        Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__20_intnl_SystemInt32");
        Private___0_this_intnl_Patreon = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "__0_this_intnl_Patreon");
        Private___3_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__3_intnl_SystemStringArray");
        Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__22_intnl_SystemBoolean");
        Private_patrons = new AstroUdonVariable<string[]>(PatreonSystem, "patrons");
        Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__7_const_intnl_exitJumpLoc_UInt32");
        Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__23_intnl_SystemInt32");
        Private___0_divider_String = new AstroUdonVariable<string>(PatreonSystem, "__0_divider_String");
        Private_playerLocator = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "playerLocator");
        Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__7_const_intnl_SystemString");
        Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__15_const_intnl_SystemString");
        Private_ownFlairButtonMeshes = new AstroUdonVariable<UnityEngine.MeshRenderer[]>(PatreonSystem, "ownFlairButtonMeshes");
        Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PatreonSystem, "__refl_const_intnl_udonTypeID");
        Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__4_intnl_SystemBoolean");
        Private___43_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__43_const_intnl_SystemString");
        Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__19_intnl_SystemBoolean");
        Private_teleports = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "teleports");
        Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PatreonSystem, "__refl_const_intnl_udonTypeName");
        Private___1_const_intnl_SystemChar = new AstroUdonVariable<char>(PatreonSystem, "__1_const_intnl_SystemChar");
        Private_eliteFlairs = new AstroUdonVariable<UnityEngine.GameObject[]>(PatreonSystem, "eliteFlairs");
        Private___0_vip_String = new AstroUdonVariable<string>(PatreonSystem, "__0_vip_String");
        Private___0_intnl_SystemObject = new AstroUdonVariable<string>(PatreonSystem, "__0_intnl_SystemObject");
        Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__1_intnl_SystemBoolean");
        Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__38_intnl_SystemBoolean");
        Private___31_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__31_intnl_SystemInt32");
        Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__14_intnl_SystemInt32");
        Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__12_const_intnl_exitJumpLoc_UInt32");
        Private___34_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__34_const_intnl_SystemString");
        Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__17_const_intnl_SystemString");
        Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__11_intnl_SystemInt32");
        Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__17_intnl_SystemInt32");
        Private___26_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__26_const_intnl_exitJumpLoc_UInt32");
        Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__4_const_intnl_SystemString");
        Private___31_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__31_const_intnl_exitJumpLoc_UInt32");
        Private___10_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__10_intnl_SystemString");
        Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__20_const_intnl_SystemString");
        Private___50_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__50_const_intnl_SystemString");
        Private___0_yPos_Single = new AstroUdonVariable<float>(PatreonSystem, "__0_yPos_Single");
        Private___35_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__35_const_intnl_SystemString");
        Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__11_intnl_SystemBoolean");
        Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__2_intnl_SystemInt32");
        Private_patronsTxt = new AstroUdonVariable<UnityEngine.TextAsset>(PatreonSystem, "patronsTxt");
        Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__4_const_intnl_exitJumpLoc_UInt32");
        Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__30_intnl_SystemBoolean");
        Private___26_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__26_intnl_SystemInt32");
        Private___2_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__2_intnl_SystemString");
        Private___0_visibleVips_String = new AstroUdonVariable<string>(PatreonSystem, "__0_visibleVips_String");
        Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__21_const_intnl_SystemString");
        Private___51_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__51_const_intnl_SystemString");
        Private___26_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__26_const_intnl_SystemString");
        Private_eliteIds = new AstroUdonVariable<int[]>(PatreonSystem, "eliteIds");
        Private___44_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__44_intnl_SystemString");
        Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__9_const_intnl_exitJumpLoc_UInt32");
        Private___0_mp_adding_Boolean = new AstroUdonVariable<bool>(PatreonSystem, "__0_mp_adding_Boolean");
        Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__37_intnl_SystemBoolean");
        Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__20_const_intnl_exitJumpLoc_UInt32");
        Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__9_intnl_SystemInt32");
        Private_flairOffset = new AstroUdonVariable<float>(PatreonSystem, "flairOffset");
        Private___37_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__37_const_intnl_SystemString");
        Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(PatreonSystem, "__2_intnl_SystemSingle");
        Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__5_const_intnl_SystemString");
        Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__3_intnl_SystemBoolean");
        Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PatreonSystem, "__0_intnl_returnValSymbol_Boolean");
        Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__12_intnl_SystemBoolean");
        Private___9_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__9_intnl_SystemString");
        Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__6_const_intnl_exitJumpLoc_UInt32");
        Private___18_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__18_intnl_SystemString");
        Private___0_vipsArray3_StringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_vipsArray3_StringArray");
        Private_playerList = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "playerList");
        Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__23_const_intnl_SystemString");
        Private_myInstance = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "myInstance");
        Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__6_intnl_SystemInt32");
        Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__44_intnl_SystemBoolean");
        Private_elitesCamera = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "elitesCamera");
        Private___6_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__6_intnl_SystemString");
        Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__0_intnl_SystemBoolean");
        Private___4_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatreonSystem, "__4_intnl_UnityEngineVector3");
        Private_ejectParticle = new AstroUdonVariable<UnityEngine.ParticleSystem>(PatreonSystem, "ejectParticle");
        Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__12_const_intnl_SystemString");
        Private___0_tmpGO_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__0_tmpGO_GameObject");
        Private___0_this_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__0_this_intnl_UnityEngineGameObject");
        Private___3_intnl_SystemObject = new AstroUdonVariable<UnityEngine.Material>(PatreonSystem, "__3_intnl_SystemObject");
        Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__8_const_intnl_SystemString");
        Private_vipsInInstance = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatreonSystem, "vipsInInstance");
        Private_ready = new AstroUdonVariable<bool>(PatreonSystem, "ready");
        Private___49_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__49_intnl_SystemString");
        Private___0_canvasGO_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__0_canvasGO_GameObject");
        Private_onPlayerJoinedPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "onPlayerJoinedPlayer");
        Private___24_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__24_intnl_SystemString");
        Private___0_isPatron_Boolean = new AstroUdonVariable<bool>(PatreonSystem, "__0_isPatron_Boolean");
        Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__15_const_intnl_exitJumpLoc_UInt32");
        Private_vipOnlyLocal = new AstroUdonVariable<bool>(PatreonSystem, "vipOnlyLocal");
        Private___3_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatreonSystem, "__3_const_intnl_SystemCharArray");
        Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__19_const_intnl_exitJumpLoc_UInt32");
        Private_eliteBellDefault = new AstroUdonVariable<UnityEngine.AudioClip>(PatreonSystem, "eliteBellDefault");
        Private___21_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__21_intnl_SystemString");
        Private___0_ownFlairButton_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__0_ownFlairButton_GameObject");
        Private___13_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__13_intnl_SystemString");
        Private___32_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__32_const_intnl_SystemString");
        Private___29_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__29_intnl_SystemInt32");
        Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__35_intnl_SystemBoolean");
        Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__8_const_intnl_exitJumpLoc_UInt32");
        Private___7_intnl_SystemObject = new AstroUdonVariable<bool>(PatreonSystem, "__7_intnl_SystemObject");
        Private___0_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatreonSystem, "__0_const_intnl_SystemCharArray");
        Private___22_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__22_const_intnl_exitJumpLoc_UInt32");
        Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__24_intnl_SystemBoolean");
        Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__9_const_intnl_SystemString");
        Private_ownFlairButtons = new AstroUdonVariable<UnityEngine.GameObject[]>(PatreonSystem, "ownFlairButtons");
        Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__0_intnl_SystemInt32");
        Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__0_intnl_returnTarget_UInt32");
        Private_vipWall = new AstroUdonVariable<UnityEngine.UI.Text>(PatreonSystem, "vipWall");
        Private___0_elite_String = new AstroUdonVariable<string>(PatreonSystem, "__0_elite_String");
        Private___0_rootPos_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatreonSystem, "__0_rootPos_Vector3");
        Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__48_intnl_SystemBoolean");
        Private___30_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__30_intnl_SystemInt32");
        Private___44_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__44_const_intnl_SystemString");
        Private___0_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__0_intnl_SystemString");
        Private___0_trimmedElite_String = new AstroUdonVariable<string>(PatreonSystem, "__0_trimmedElite_String");
        Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__33_intnl_SystemBoolean");
        Private_vipBadAudio = new AstroUdonVariable<UnityEngine.AudioSource>(PatreonSystem, "vipBadAudio");
        Private___3_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__3_intnl_UnityEngineGameObject");
        Private___33_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__33_intnl_SystemInt32");
        Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__10_intnl_SystemInt32");
        Private___47_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__47_intnl_SystemString");
        Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__0_const_intnl_SystemUInt32");
        Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__9_intnl_SystemBoolean");
        Private_eliteNameplates = new AstroUdonVariable<UnityEngine.GameObject[]>(PatreonSystem, "eliteNameplates");
        Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__13_intnl_SystemInt32");
        Private___2_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "__2_mp_player_VRCPlayerApi");
        Private___45_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__45_const_intnl_SystemString");
        Private_vipOnly = new AstroUdonVariable<bool>(PatreonSystem, "vipOnly");
        Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__36_intnl_SystemBoolean");
        Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(PatreonSystem, "__0_intnl_SystemSingle");
        Private___12_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__12_intnl_SystemString");
        Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__40_intnl_SystemBoolean");
        Private___8_intnl_SystemObject = new AstroUdonVariable<bool>(PatreonSystem, "__8_intnl_SystemObject");
        Private___0_wallText_String = new AstroUdonVariable<string>(PatreonSystem, "__0_wallText_String");
        Private___25_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__25_intnl_SystemInt32");
        Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__18_const_intnl_SystemString");
        Private___4_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__4_intnl_SystemStringArray");
        Private___6_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__6_intnl_SystemStringArray");
        Private_elites = new AstroUdonVariable<string[]>(PatreonSystem, "elites");
        Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__22_intnl_SystemInt32");
        Private___0_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "__0_mp_player_VRCPlayerApi");
        Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__4_intnl_SystemInt32");
        Private_vipOnlyIndicator = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "vipOnlyIndicator");
        Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatreonSystem, "__3_intnl_UnityEngineVector3");
        Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__47_intnl_SystemBoolean");
        Private___4_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__4_intnl_SystemString");
        Private___47_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__47_const_intnl_SystemString");
        Private___4_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(PatreonSystem, "__4_intnl_UnityEngineTransform");
        Private_eliteBells = new AstroUdonVariable<UnityEngine.AudioClip[]>(PatreonSystem, "eliteBells");
        Private___14_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__14_intnl_SystemString");
        Private___0_elitesArray3_StringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_elitesArray3_StringArray");
        Private___46_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__46_intnl_SystemString");
        Private___9_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "__9_intnl_VRCSDKBaseVRCPlayerApi");
        Private___0_playerName_String = new AstroUdonVariable<string>(PatreonSystem, "__0_playerName_String");
        Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__19_const_intnl_SystemString");
        Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__17_const_intnl_exitJumpLoc_UInt32");
        Private___1_playerName_String = new AstroUdonVariable<string>(PatreonSystem, "__1_playerName_String");
        Private___30_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__30_const_intnl_exitJumpLoc_UInt32");
        Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__39_intnl_SystemBoolean");
        Private___0_players_VRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatreonSystem, "__0_players_VRCPlayerApiArray");
        Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__28_intnl_SystemBoolean");
        Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__6_intnl_SystemBoolean");
        Private___11_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__11_intnl_SystemString");
        Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__24_const_intnl_SystemString");
        Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__16_intnl_SystemInt32");
        Private___38_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__38_const_intnl_SystemString");
        Private___0_vipsArray_StringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_vipsArray_StringArray");
        Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__14_intnl_SystemBoolean");
        Private_vipIds = new AstroUdonVariable<int[]>(PatreonSystem, "vipIds");
        Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PatreonSystem, "__1_intnl_returnValSymbol_Boolean");
        Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__3_intnl_SystemInt32");
        Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__31_intnl_SystemBoolean");
        Private_materials = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "materials");
        Private___25_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__25_const_intnl_SystemString");
        Private___5_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__5_intnl_UnityEngineGameObject");
        Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__11_const_intnl_exitJumpLoc_UInt32");
        Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__8_intnl_SystemBoolean");
        Private___45_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__45_intnl_SystemString");
        Private___1_intnl_interpolatedStr_String = new AstroUdonVariable<string>(PatreonSystem, "__1_intnl_interpolatedStr_String");
        Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__20_intnl_SystemBoolean");
        Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatreonSystem, "__2_intnl_UnityEngineVector3");
        Private___3_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__3_intnl_SystemString");
        Private___39_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__39_const_intnl_SystemString");
        Private___0_eliteName_String = new AstroUdonVariable<string>(PatreonSystem, "__0_eliteName_String");
        Private___0_useCanvas_Boolean = new AstroUdonVariable<bool>(PatreonSystem, "__0_useCanvas_Boolean");
        Private___25_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__25_const_intnl_exitJumpLoc_UInt32");
        Private___0_mp_patronsToProcess_String = new AstroUdonVariable<string>(PatreonSystem, "__0_mp_patronsToProcess_String");
        Private___29_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__29_const_intnl_exitJumpLoc_UInt32");
        Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatreonSystem, "__1_intnl_UnityEngineVector3");
        Private___2_const_intnl_SystemChar = new AstroUdonVariable<char>(PatreonSystem, "__2_const_intnl_SystemChar");
        Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__27_intnl_SystemBoolean");
        Private___19_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__19_intnl_SystemString");
        Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__2_const_intnl_SystemInt32");
        Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(PatreonSystem, "__3_intnl_SystemSingle");
        Private___0_isElite_Boolean = new AstroUdonVariable<bool>(PatreonSystem, "__0_isElite_Boolean");
        Private___0_const_intnl_UnityEngineHumanBodyBones = new AstroUdonVariable<UnityEngine.HumanBodyBones>(PatreonSystem, "__0_const_intnl_UnityEngineHumanBodyBones");
        Private___27_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__27_const_intnl_SystemString");
        Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatreonSystem, "__0_intnl_UnityEngineVector3");
        Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__10_const_intnl_SystemString");
        Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__32_intnl_SystemBoolean");
        Private___4_intnl_UnityEngineMaterial = new AstroUdonVariable<UnityEngine.Material>(PatreonSystem, "__4_intnl_UnityEngineMaterial");
        Private___42_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__42_const_intnl_SystemString");
        Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__45_intnl_SystemBoolean");
        Private___28_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__28_intnl_SystemInt32");
        Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__7_intnl_SystemInt32");
        Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__1_const_intnl_SystemBoolean");
        Private___0_mp_vips_String = new AstroUdonVariable<string>(PatreonSystem, "__0_mp_vips_String");
        Private___0_patronId_Int32 = new AstroUdonVariable<int>(PatreonSystem, "__0_patronId_Int32");
        Private___7_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__7_intnl_SystemString");
        Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__11_const_intnl_SystemString");
        Private___0_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_intnl_SystemStringArray");
        Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__16_const_intnl_SystemString");
        Private___2_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__2_intnl_SystemStringArray");
        Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__43_intnl_SystemBoolean");
        Private___0_vipsArray2_StringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_vipsArray2_StringArray");
        Private___5_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(PatreonSystem, "__5_intnl_UnityEngineTransform");
        Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__18_intnl_SystemBoolean");
        Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__2_intnl_SystemBoolean");
        Private___0_groups_StringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__0_groups_StringArray");
        Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__14_const_intnl_exitJumpLoc_UInt32");
        Private___3_const_intnl_SystemChar = new AstroUdonVariable<char>(PatreonSystem, "__3_const_intnl_SystemChar");
        Private__localPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatreonSystem, "_localPlayer");
        Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__3_const_intnl_SystemInt32");
        Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(PatreonSystem, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
        Private___25_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__25_intnl_SystemString");
        Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__18_const_intnl_exitJumpLoc_UInt32");
        Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__46_intnl_SystemBoolean");
        Private___17_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__17_intnl_SystemString");
        Private___30_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__30_const_intnl_SystemString");
        Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__13_const_intnl_SystemString");
        Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__8_intnl_SystemInt32");
        Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__19_intnl_SystemInt32");
        Private___2_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatreonSystem, "__2_const_intnl_SystemCharArray");
        Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__24_intnl_SystemInt32");
        Private___8_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__8_intnl_SystemString");
        Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__13_const_intnl_exitJumpLoc_UInt32");
        Private___3_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(PatreonSystem, "__3_intnl_UnityEngineTransform");
        Private___2_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatreonSystem, "__2_intnl_UnityEngineGameObject");
        Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__10_intnl_SystemBoolean");
        Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__2_const_intnl_SystemString");
        Private___31_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__31_const_intnl_SystemString");
        Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__21_intnl_SystemInt32");
        Private___27_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__27_const_intnl_exitJumpLoc_UInt32");
        Private___27_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__27_intnl_SystemInt32");
        Private___36_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__36_const_intnl_SystemString");
        Private_rooms = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "rooms");
        Private___5_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatreonSystem, "__5_intnl_SystemStringArray");
        Private_readRenderTexture = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatreonSystem, "readRenderTexture");
        Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatreonSystem, "__0_const_intnl_SystemInt32");
        Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatreonSystem, "__1_const_intnl_exitJumpLoc_UInt32");
        Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__25_intnl_SystemBoolean");
        Private_ejectAudio = new AstroUdonVariable<UnityEngine.AudioSource>(PatreonSystem, "ejectAudio");
        Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__22_const_intnl_SystemString");
        Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatreonSystem, "__17_intnl_SystemBoolean");
        Private___16_intnl_SystemString = new AstroUdonVariable<string>(PatreonSystem, "__16_intnl_SystemString");
    }

    private void Cleanup_PatreonSystem()
    {
        Private___33_const_intnl_SystemString = null;
        Private___0_intnl_TMProTextMeshProUGUI = null;
        Private___23_intnl_SystemBoolean = null;
        Private___32_intnl_SystemInt32 = null;
        Private_utilities = null;
        Private___48_const_intnl_SystemString = null;
        Private___0_intnl_interpolatedStr_String = null;
        Private___15_intnl_SystemInt32 = null;
        Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = null;
        Private___1_intnl_UnityEngineGameObject = null;
        Private___3_mp_player_VRCPlayerApi = null;
        Private___21_const_intnl_exitJumpLoc_UInt32 = null;
        Private___12_intnl_SystemInt32 = null;
        Private___3_const_intnl_SystemString = null;
        Private_vipBadParticle = null;
        Private___3_const_intnl_exitJumpLoc_UInt32 = null;
        Private___26_intnl_SystemBoolean = null;
        Private___0_const_intnl_SystemBoolean = null;
        Private___41_intnl_SystemBoolean = null;
        Private___1_intnl_UnityEngineTransform = null;
        Private___1_const_intnl_SystemInt32 = null;
        Private___49_const_intnl_SystemString = null;
        Private___1_intnl_SystemInt32 = null;
        Private___16_const_intnl_exitJumpLoc_UInt32 = null;
        Private_ownFlairEnabled = null;
        Private___1_intnl_SystemString = null;
        Private_vipOnlyButton = null;
        Private___1_i_Int32 = null;
        Private___1_x_Int32 = null;
        Private___0_i_Int32 = null;
        Private___0_x_Int32 = null;
        Private___0_y_Int32 = null;
        Private___3_i_Int32 = null;
        Private___2_i_Int32 = null;
        Private___2_x_Int32 = null;
        Private___5_i_Int32 = null;
        Private___4_i_Int32 = null;
        Private___7_i_Int32 = null;
        Private___6_i_Int32 = null;
        Private___2_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___0_const_intnl_SystemString = null;
        Private___42_intnl_SystemBoolean = null;
        Private___0_const_intnl_SystemSingle = null;
        Private___29_intnl_SystemBoolean = null;
        Private___1_intnl_SystemSingle = null;
        Private___48_intnl_SystemString = null;
        Private___0_mp_elites_StringArray = null;
        Private___5_intnl_SystemBoolean = null;
        Private___10_const_intnl_exitJumpLoc_UInt32 = null;
        Private___5_intnl_SystemInt32 = null;
        Private___0_const_intnl_exitJumpLoc_UInt32 = null;
        Private___15_intnl_SystemBoolean = null;
        Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___6_intnl_UnityEngineMaterial = null;
        Private___24_const_intnl_exitJumpLoc_UInt32 = null;
        Private___20_intnl_SystemString = null;
        Private___5_intnl_SystemString = null;
        Private___34_intnl_SystemBoolean = null;
        Private___28_const_intnl_SystemString = null;
        Private___2_intnl_UnityEngineTransform = null;
        Private___1_intnl_SystemStringArray = null;
        Private___1_const_intnl_SystemCharArray = null;
        Private_elitesInInstance = null;
        Private___28_const_intnl_exitJumpLoc_UInt32 = null;
        Private___6_const_intnl_SystemString = null;
        Private___21_intnl_SystemBoolean = null;
        Private___5_const_intnl_exitJumpLoc_UInt32 = null;
        Private___13_intnl_SystemBoolean = null;
        Private_vipFlairs = null;
        Private___1_const_intnl_SystemString = null;
        Private___4_const_intnl_SystemInt32 = null;
        Private___40_const_intnl_SystemString = null;
        Private___29_const_intnl_SystemString = null;
        Private___0_const_intnl_SystemChar = null;
        Private___23_const_intnl_exitJumpLoc_UInt32 = null;
        Private___2_const_intnl_exitJumpLoc_UInt32 = null;
        Private___18_intnl_SystemInt32 = null;
        Private___16_intnl_SystemBoolean = null;
        Private_vipGoodAudio = null;
        Private___14_const_intnl_SystemString = null;
        Private___4_intnl_UnityEngineGameObject = null;
        Private___41_const_intnl_SystemString = null;
        Private___0_elitesArray2_StringArray = null;
        Private___46_const_intnl_SystemString = null;
        Private___7_intnl_SystemBoolean = null;
        Private___20_intnl_SystemInt32 = null;
        Private___0_this_intnl_Patreon = null;
        Private___3_intnl_SystemStringArray = null;
        Private___22_intnl_SystemBoolean = null;
        Private_patrons = null;
        Private___7_const_intnl_exitJumpLoc_UInt32 = null;
        Private___23_intnl_SystemInt32 = null;
        Private___0_divider_String = null;
        Private_playerLocator = null;
        Private___7_const_intnl_SystemString = null;
        Private___15_const_intnl_SystemString = null;
        Private_ownFlairButtonMeshes = null;
        Private___refl_const_intnl_udonTypeID = null;
        Private___4_intnl_SystemBoolean = null;
        Private___43_const_intnl_SystemString = null;
        Private___19_intnl_SystemBoolean = null;
        Private_teleports = null;
        Private___refl_const_intnl_udonTypeName = null;
        Private___1_const_intnl_SystemChar = null;
        Private_eliteFlairs = null;
        Private___0_vip_String = null;
        Private___0_intnl_SystemObject = null;
        Private___1_intnl_SystemBoolean = null;
        Private___38_intnl_SystemBoolean = null;
        Private___31_intnl_SystemInt32 = null;
        Private___14_intnl_SystemInt32 = null;
        Private___12_const_intnl_exitJumpLoc_UInt32 = null;
        Private___34_const_intnl_SystemString = null;
        Private___17_const_intnl_SystemString = null;
        Private___11_intnl_SystemInt32 = null;
        Private___17_intnl_SystemInt32 = null;
        Private___26_const_intnl_exitJumpLoc_UInt32 = null;
        Private___4_const_intnl_SystemString = null;
        Private___31_const_intnl_exitJumpLoc_UInt32 = null;
        Private___10_intnl_SystemString = null;
        Private___20_const_intnl_SystemString = null;
        Private___50_const_intnl_SystemString = null;
        Private___0_yPos_Single = null;
        Private___35_const_intnl_SystemString = null;
        Private___11_intnl_SystemBoolean = null;
        Private___2_intnl_SystemInt32 = null;
        Private_patronsTxt = null;
        Private___4_const_intnl_exitJumpLoc_UInt32 = null;
        Private___30_intnl_SystemBoolean = null;
        Private___26_intnl_SystemInt32 = null;
        Private___2_intnl_SystemString = null;
        Private___0_visibleVips_String = null;
        Private___21_const_intnl_SystemString = null;
        Private___51_const_intnl_SystemString = null;
        Private___26_const_intnl_SystemString = null;
        Private_eliteIds = null;
        Private___44_intnl_SystemString = null;
        Private___9_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_mp_adding_Boolean = null;
        Private___37_intnl_SystemBoolean = null;
        Private___20_const_intnl_exitJumpLoc_UInt32 = null;
        Private___9_intnl_SystemInt32 = null;
        Private_flairOffset = null;
        Private___37_const_intnl_SystemString = null;
        Private___2_intnl_SystemSingle = null;
        Private___5_const_intnl_SystemString = null;
        Private___3_intnl_SystemBoolean = null;
        Private___0_intnl_returnValSymbol_Boolean = null;
        Private___12_intnl_SystemBoolean = null;
        Private___9_intnl_SystemString = null;
        Private___6_const_intnl_exitJumpLoc_UInt32 = null;
        Private___18_intnl_SystemString = null;
        Private___0_vipsArray3_StringArray = null;
        Private_playerList = null;
        Private___23_const_intnl_SystemString = null;
        Private_myInstance = null;
        Private___6_intnl_SystemInt32 = null;
        Private___44_intnl_SystemBoolean = null;
        Private_elitesCamera = null;
        Private___6_intnl_SystemString = null;
        Private___0_intnl_SystemBoolean = null;
        Private___4_intnl_UnityEngineVector3 = null;
        Private_ejectParticle = null;
        Private___12_const_intnl_SystemString = null;
        Private___0_tmpGO_GameObject = null;
        Private___0_this_intnl_UnityEngineGameObject = null;
        Private___3_intnl_SystemObject = null;
        Private___8_const_intnl_SystemString = null;
        Private_vipsInInstance = null;
        Private_ready = null;
        Private___49_intnl_SystemString = null;
        Private___0_canvasGO_GameObject = null;
        Private_onPlayerJoinedPlayer = null;
        Private___24_intnl_SystemString = null;
        Private___0_isPatron_Boolean = null;
        Private___15_const_intnl_exitJumpLoc_UInt32 = null;
        Private_vipOnlyLocal = null;
        Private___3_const_intnl_SystemCharArray = null;
        Private___19_const_intnl_exitJumpLoc_UInt32 = null;
        Private_eliteBellDefault = null;
        Private___21_intnl_SystemString = null;
        Private___0_ownFlairButton_GameObject = null;
        Private___13_intnl_SystemString = null;
        Private___32_const_intnl_SystemString = null;
        Private___29_intnl_SystemInt32 = null;
        Private___35_intnl_SystemBoolean = null;
        Private___8_const_intnl_exitJumpLoc_UInt32 = null;
        Private___7_intnl_SystemObject = null;
        Private___0_const_intnl_SystemCharArray = null;
        Private___22_const_intnl_exitJumpLoc_UInt32 = null;
        Private___24_intnl_SystemBoolean = null;
        Private___9_const_intnl_SystemString = null;
        Private_ownFlairButtons = null;
        Private___0_intnl_SystemInt32 = null;
        Private___0_intnl_returnTarget_UInt32 = null;
        Private_vipWall = null;
        Private___0_elite_String = null;
        Private___0_rootPos_Vector3 = null;
        Private___48_intnl_SystemBoolean = null;
        Private___30_intnl_SystemInt32 = null;
        Private___44_const_intnl_SystemString = null;
        Private___0_intnl_SystemString = null;
        Private___0_trimmedElite_String = null;
        Private___33_intnl_SystemBoolean = null;
        Private_vipBadAudio = null;
        Private___3_intnl_UnityEngineGameObject = null;
        Private___33_intnl_SystemInt32 = null;
        Private___10_intnl_SystemInt32 = null;
        Private___47_intnl_SystemString = null;
        Private___0_const_intnl_SystemUInt32 = null;
        Private___9_intnl_SystemBoolean = null;
        Private_eliteNameplates = null;
        Private___13_intnl_SystemInt32 = null;
        Private___2_mp_player_VRCPlayerApi = null;
        Private___45_const_intnl_SystemString = null;
        Private_vipOnly = null;
        Private___36_intnl_SystemBoolean = null;
        Private___0_intnl_SystemSingle = null;
        Private___12_intnl_SystemString = null;
        Private___40_intnl_SystemBoolean = null;
        Private___8_intnl_SystemObject = null;
        Private___0_wallText_String = null;
        Private___25_intnl_SystemInt32 = null;
        Private___18_const_intnl_SystemString = null;
        Private___4_intnl_SystemStringArray = null;
        Private___6_intnl_SystemStringArray = null;
        Private_elites = null;
        Private___22_intnl_SystemInt32 = null;
        Private___0_mp_player_VRCPlayerApi = null;
        Private___4_intnl_SystemInt32 = null;
        Private_vipOnlyIndicator = null;
        Private___3_intnl_UnityEngineVector3 = null;
        Private___47_intnl_SystemBoolean = null;
        Private___4_intnl_SystemString = null;
        Private___47_const_intnl_SystemString = null;
        Private___4_intnl_UnityEngineTransform = null;
        Private_eliteBells = null;
        Private___14_intnl_SystemString = null;
        Private___0_elitesArray3_StringArray = null;
        Private___46_intnl_SystemString = null;
        Private___9_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___0_playerName_String = null;
        Private___19_const_intnl_SystemString = null;
        Private___17_const_intnl_exitJumpLoc_UInt32 = null;
        Private___1_playerName_String = null;
        Private___30_const_intnl_exitJumpLoc_UInt32 = null;
        Private___39_intnl_SystemBoolean = null;
        Private___0_players_VRCPlayerApiArray = null;
        Private___28_intnl_SystemBoolean = null;
        Private___6_intnl_SystemBoolean = null;
        Private___11_intnl_SystemString = null;
        Private___24_const_intnl_SystemString = null;
        Private___16_intnl_SystemInt32 = null;
        Private___38_const_intnl_SystemString = null;
        Private___0_vipsArray_StringArray = null;
        Private___14_intnl_SystemBoolean = null;
        Private_vipIds = null;
        Private___1_intnl_returnValSymbol_Boolean = null;
        Private___3_intnl_SystemInt32 = null;
        Private___31_intnl_SystemBoolean = null;
        Private_materials = null;
        Private___25_const_intnl_SystemString = null;
        Private___5_intnl_UnityEngineGameObject = null;
        Private___11_const_intnl_exitJumpLoc_UInt32 = null;
        Private___8_intnl_SystemBoolean = null;
        Private___45_intnl_SystemString = null;
        Private___1_intnl_interpolatedStr_String = null;
        Private___20_intnl_SystemBoolean = null;
        Private___2_intnl_UnityEngineVector3 = null;
        Private___3_intnl_SystemString = null;
        Private___39_const_intnl_SystemString = null;
        Private___0_eliteName_String = null;
        Private___0_useCanvas_Boolean = null;
        Private___25_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_mp_patronsToProcess_String = null;
        Private___29_const_intnl_exitJumpLoc_UInt32 = null;
        Private___1_intnl_UnityEngineVector3 = null;
        Private___2_const_intnl_SystemChar = null;
        Private___27_intnl_SystemBoolean = null;
        Private___19_intnl_SystemString = null;
        Private___2_const_intnl_SystemInt32 = null;
        Private___3_intnl_SystemSingle = null;
        Private___0_isElite_Boolean = null;
        Private___0_const_intnl_UnityEngineHumanBodyBones = null;
        Private___27_const_intnl_SystemString = null;
        Private___0_intnl_UnityEngineVector3 = null;
        Private___10_const_intnl_SystemString = null;
        Private___32_intnl_SystemBoolean = null;
        Private___4_intnl_UnityEngineMaterial = null;
        Private___42_const_intnl_SystemString = null;
        Private___45_intnl_SystemBoolean = null;
        Private___28_intnl_SystemInt32 = null;
        Private___7_intnl_SystemInt32 = null;
        Private___1_const_intnl_SystemBoolean = null;
        Private___0_mp_vips_String = null;
        Private___0_patronId_Int32 = null;
        Private___7_intnl_SystemString = null;
        Private___11_const_intnl_SystemString = null;
        Private___0_intnl_SystemStringArray = null;
        Private___16_const_intnl_SystemString = null;
        Private___2_intnl_SystemStringArray = null;
        Private___43_intnl_SystemBoolean = null;
        Private___0_vipsArray2_StringArray = null;
        Private___5_intnl_UnityEngineTransform = null;
        Private___18_intnl_SystemBoolean = null;
        Private___2_intnl_SystemBoolean = null;
        Private___0_groups_StringArray = null;
        Private___14_const_intnl_exitJumpLoc_UInt32 = null;
        Private___3_const_intnl_SystemChar = null;
        Private__localPlayer = null;
        Private___3_const_intnl_SystemInt32 = null;
        Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = null;
        Private___25_intnl_SystemString = null;
        Private___18_const_intnl_exitJumpLoc_UInt32 = null;
        Private___46_intnl_SystemBoolean = null;
        Private___17_intnl_SystemString = null;
        Private___30_const_intnl_SystemString = null;
        Private___13_const_intnl_SystemString = null;
        Private___8_intnl_SystemInt32 = null;
        Private___19_intnl_SystemInt32 = null;
        Private___2_const_intnl_SystemCharArray = null;
        Private___24_intnl_SystemInt32 = null;
        Private___8_intnl_SystemString = null;
        Private___13_const_intnl_exitJumpLoc_UInt32 = null;
        Private___3_intnl_UnityEngineTransform = null;
        Private___2_intnl_UnityEngineGameObject = null;
        Private___10_intnl_SystemBoolean = null;
        Private___2_const_intnl_SystemString = null;
        Private___31_const_intnl_SystemString = null;
        Private___21_intnl_SystemInt32 = null;
        Private___27_const_intnl_exitJumpLoc_UInt32 = null;
        Private___27_intnl_SystemInt32 = null;
        Private___36_const_intnl_SystemString = null;
        Private_rooms = null;
        Private___5_intnl_SystemStringArray = null;
        Private_readRenderTexture = null;
        Private___0_const_intnl_SystemInt32 = null;
        Private___1_const_intnl_exitJumpLoc_UInt32 = null;
        Private___25_intnl_SystemBoolean = null;
        Private_ejectAudio = null;
        Private___22_const_intnl_SystemString = null;
        Private___17_intnl_SystemBoolean = null;
        Private___16_intnl_SystemString = null;
    }

    #region Getter / Setters AstroUdonVariables  of PatreonSystem

    internal string __33_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___33_const_intnl_SystemString != null)
            {
                return Private___33_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___33_const_intnl_SystemString != null)
            {
                Private___33_const_intnl_SystemString.Value = value;
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

    internal int? __32_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___32_intnl_SystemInt32 != null)
            {
                return Private___32_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___32_intnl_SystemInt32 != null)
                {
                    Private___32_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal VRC.Udon.UdonBehaviour utilities
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_utilities != null)
            {
                return Private_utilities.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_utilities != null)
            {
                Private_utilities.Value = value;
            }
        }
    }

    internal string __48_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___48_const_intnl_SystemString != null)
            {
                return Private___48_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___48_const_intnl_SystemString != null)
            {
                Private___48_const_intnl_SystemString.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi[] __0_intnl_VRCSDKBaseVRCPlayerApiArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApiArray != null)
            {
                return Private___0_intnl_VRCSDKBaseVRCPlayerApiArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApiArray != null)
            {
                Private___0_intnl_VRCSDKBaseVRCPlayerApiArray.Value = value;
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

    internal UnityEngine.ParticleSystem vipBadParticle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipBadParticle != null)
            {
                return Private_vipBadParticle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipBadParticle != null)
            {
                Private_vipBadParticle.Value = value;
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

    internal bool? __41_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___41_intnl_SystemBoolean != null)
            {
                return Private___41_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___41_intnl_SystemBoolean != null)
                {
                    Private___41_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.RectTransform __1_intnl_UnityEngineTransform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_UnityEngineTransform != null)
            {
                return Private___1_intnl_UnityEngineTransform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_UnityEngineTransform != null)
            {
                Private___1_intnl_UnityEngineTransform.Value = value;
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

    internal string __49_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___49_const_intnl_SystemString != null)
            {
                return Private___49_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___49_const_intnl_SystemString != null)
            {
                Private___49_const_intnl_SystemString.Value = value;
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

    internal bool? ownFlairEnabled
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_ownFlairEnabled != null)
            {
                return Private_ownFlairEnabled.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_ownFlairEnabled != null)
                {
                    Private_ownFlairEnabled.Value = value.Value;
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

    internal UnityEngine.MeshRenderer vipOnlyButton
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

    internal int? __1_x_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_x_Int32 != null)
            {
                return Private___1_x_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_x_Int32 != null)
                {
                    Private___1_x_Int32.Value = value.Value;
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

    internal int? __0_x_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_x_Int32 != null)
            {
                return Private___0_x_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_x_Int32 != null)
                {
                    Private___0_x_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_y_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_y_Int32 != null)
            {
                return Private___0_y_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_y_Int32 != null)
                {
                    Private___0_y_Int32.Value = value.Value;
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

    internal int? __2_x_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_x_Int32 != null)
            {
                return Private___2_x_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_x_Int32 != null)
                {
                    Private___2_x_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __5_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_i_Int32 != null)
            {
                return Private___5_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___5_i_Int32 != null)
                {
                    Private___5_i_Int32.Value = value.Value;
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

    internal int? __7_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_i_Int32 != null)
            {
                return Private___7_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___7_i_Int32 != null)
                {
                    Private___7_i_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __6_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_i_Int32 != null)
            {
                return Private___6_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___6_i_Int32 != null)
                {
                    Private___6_i_Int32.Value = value.Value;
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

    internal bool? __42_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___42_intnl_SystemBoolean != null)
            {
                return Private___42_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___42_intnl_SystemBoolean != null)
                {
                    Private___42_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal float? __0_const_intnl_SystemSingle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemSingle != null)
            {
                return Private___0_const_intnl_SystemSingle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_SystemSingle != null)
                {
                    Private___0_const_intnl_SystemSingle.Value = value.Value;
                }
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

    internal float? __1_intnl_SystemSingle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemSingle != null)
            {
                return Private___1_intnl_SystemSingle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_SystemSingle != null)
                {
                    Private___1_intnl_SystemSingle.Value = value.Value;
                }
            }
        }
    }

    internal string __48_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___48_intnl_SystemString != null)
            {
                return Private___48_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___48_intnl_SystemString != null)
            {
                Private___48_intnl_SystemString.Value = value;
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

    internal UnityEngine.Material __6_intnl_UnityEngineMaterial
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_intnl_UnityEngineMaterial != null)
            {
                return Private___6_intnl_UnityEngineMaterial.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___6_intnl_UnityEngineMaterial != null)
            {
                Private___6_intnl_UnityEngineMaterial.Value = value;
            }
        }
    }

    internal uint? __24_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___24_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___24_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___24_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___24_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
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

    internal bool? __34_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___34_intnl_SystemBoolean != null)
            {
                return Private___34_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___34_intnl_SystemBoolean != null)
                {
                    Private___34_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string __28_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___28_const_intnl_SystemString != null)
            {
                return Private___28_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___28_const_intnl_SystemString != null)
            {
                Private___28_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal UnityEngine.RectTransform __2_intnl_UnityEngineTransform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_UnityEngineTransform != null)
            {
                return Private___2_intnl_UnityEngineTransform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_UnityEngineTransform != null)
            {
                Private___2_intnl_UnityEngineTransform.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi[] elitesInInstance
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_elitesInInstance != null)
            {
                return Private_elitesInInstance.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_elitesInInstance != null)
            {
                Private_elitesInInstance.Value = value;
            }
        }
    }

    internal uint? __28_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___28_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___28_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___28_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___28_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
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

    internal UnityEngine.GameObject[] vipFlairs
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipFlairs != null)
            {
                return Private_vipFlairs.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipFlairs != null)
            {
                Private_vipFlairs.Value = value;
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

    internal int? __4_const_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_const_intnl_SystemInt32 != null)
            {
                return Private___4_const_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___4_const_intnl_SystemInt32 != null)
                {
                    Private___4_const_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __40_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___40_const_intnl_SystemString != null)
            {
                return Private___40_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___40_const_intnl_SystemString != null)
            {
                Private___40_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __29_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___29_const_intnl_SystemString != null)
            {
                return Private___29_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___29_const_intnl_SystemString != null)
            {
                Private___29_const_intnl_SystemString.Value = value;
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

    internal uint? __23_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___23_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___23_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___23_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___23_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
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

    internal UnityEngine.AudioSource vipGoodAudio
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipGoodAudio != null)
            {
                return Private_vipGoodAudio.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipGoodAudio != null)
            {
                Private_vipGoodAudio.Value = value;
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

    internal UnityEngine.GameObject __4_intnl_UnityEngineGameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_UnityEngineGameObject != null)
            {
                return Private___4_intnl_UnityEngineGameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_intnl_UnityEngineGameObject != null)
            {
                Private___4_intnl_UnityEngineGameObject.Value = value;
            }
        }
    }

    internal string __41_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___41_const_intnl_SystemString != null)
            {
                return Private___41_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___41_const_intnl_SystemString != null)
            {
                Private___41_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __0_elitesArray2_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_elitesArray2_StringArray != null)
            {
                return Private___0_elitesArray2_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_elitesArray2_StringArray != null)
            {
                Private___0_elitesArray2_StringArray.Value = value;
            }
        }
    }

    internal string __46_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___46_const_intnl_SystemString != null)
            {
                return Private___46_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___46_const_intnl_SystemString != null)
            {
                Private___46_const_intnl_SystemString.Value = value;
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

    internal VRC.Udon.UdonBehaviour __0_this_intnl_Patreon
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_this_intnl_Patreon != null)
            {
                return Private___0_this_intnl_Patreon.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_this_intnl_Patreon != null)
            {
                Private___0_this_intnl_Patreon.Value = value;
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

    internal string[] patrons
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patrons != null)
            {
                return Private_patrons.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_patrons != null)
            {
                Private_patrons.Value = value;
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

    internal int? __23_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___23_intnl_SystemInt32 != null)
            {
                return Private___23_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___23_intnl_SystemInt32 != null)
                {
                    Private___23_intnl_SystemInt32.Value = value.Value;
                }
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

    internal VRC.Udon.UdonBehaviour playerLocator
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_playerLocator != null)
            {
                return Private_playerLocator.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_playerLocator != null)
            {
                Private_playerLocator.Value = value;
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

    internal UnityEngine.MeshRenderer[] ownFlairButtonMeshes
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_ownFlairButtonMeshes != null)
            {
                return Private_ownFlairButtonMeshes.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_ownFlairButtonMeshes != null)
            {
                Private_ownFlairButtonMeshes.Value = value;
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

    internal string __43_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___43_const_intnl_SystemString != null)
            {
                return Private___43_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___43_const_intnl_SystemString != null)
            {
                Private___43_const_intnl_SystemString.Value = value;
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

    internal VRC.Udon.UdonBehaviour teleports
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_teleports != null)
            {
                return Private_teleports.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_teleports != null)
            {
                Private_teleports.Value = value;
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

    internal UnityEngine.GameObject[] eliteFlairs
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteFlairs != null)
            {
                return Private_eliteFlairs.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteFlairs != null)
            {
                Private_eliteFlairs.Value = value;
            }
        }
    }

    internal string __0_vip_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_vip_String != null)
            {
                return Private___0_vip_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_vip_String != null)
            {
                Private___0_vip_String.Value = value;
            }
        }
    }

    internal string __0_intnl_SystemObject
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

    internal bool? __38_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___38_intnl_SystemBoolean != null)
            {
                return Private___38_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___38_intnl_SystemBoolean != null)
                {
                    Private___38_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __31_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___31_intnl_SystemInt32 != null)
            {
                return Private___31_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___31_intnl_SystemInt32 != null)
                {
                    Private___31_intnl_SystemInt32.Value = value.Value;
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

    internal string __34_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___34_const_intnl_SystemString != null)
            {
                return Private___34_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___34_const_intnl_SystemString != null)
            {
                Private___34_const_intnl_SystemString.Value = value;
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

    internal uint? __26_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___26_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___26_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___26_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___26_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

    internal uint? __31_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___31_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___31_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___31_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___31_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __10_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___10_intnl_SystemString != null)
            {
                return Private___10_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___10_intnl_SystemString != null)
            {
                Private___10_intnl_SystemString.Value = value;
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

    internal string __50_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___50_const_intnl_SystemString != null)
            {
                return Private___50_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___50_const_intnl_SystemString != null)
            {
                Private___50_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal float? __0_yPos_Single
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_yPos_Single != null)
            {
                return Private___0_yPos_Single.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_yPos_Single != null)
                {
                    Private___0_yPos_Single.Value = value.Value;
                }
            }
        }
    }

    internal string __35_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___35_const_intnl_SystemString != null)
            {
                return Private___35_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___35_const_intnl_SystemString != null)
            {
                Private___35_const_intnl_SystemString.Value = value;
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

    internal UnityEngine.TextAsset patronsTxt
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patronsTxt != null)
            {
                return Private_patronsTxt.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_patronsTxt != null)
            {
                Private_patronsTxt.Value = value;
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

    internal int? __26_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___26_intnl_SystemInt32 != null)
            {
                return Private___26_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___26_intnl_SystemInt32 != null)
                {
                    Private___26_intnl_SystemInt32.Value = value.Value;
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

    internal string __0_visibleVips_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_visibleVips_String != null)
            {
                return Private___0_visibleVips_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_visibleVips_String != null)
            {
                Private___0_visibleVips_String.Value = value;
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

    internal string __51_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___51_const_intnl_SystemString != null)
            {
                return Private___51_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___51_const_intnl_SystemString != null)
            {
                Private___51_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __26_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___26_const_intnl_SystemString != null)
            {
                return Private___26_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___26_const_intnl_SystemString != null)
            {
                Private___26_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal int[] eliteIds
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

    internal string __44_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___44_intnl_SystemString != null)
            {
                return Private___44_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___44_intnl_SystemString != null)
            {
                Private___44_intnl_SystemString.Value = value;
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

    internal bool? __0_mp_adding_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_adding_Boolean != null)
            {
                return Private___0_mp_adding_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_mp_adding_Boolean != null)
                {
                    Private___0_mp_adding_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __37_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___37_intnl_SystemBoolean != null)
            {
                return Private___37_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___37_intnl_SystemBoolean != null)
                {
                    Private___37_intnl_SystemBoolean.Value = value.Value;
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

    internal float? flairOffset
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_flairOffset != null)
            {
                return Private_flairOffset.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_flairOffset != null)
                {
                    Private_flairOffset.Value = value.Value;
                }
            }
        }
    }

    internal string __37_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___37_const_intnl_SystemString != null)
            {
                return Private___37_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___37_const_intnl_SystemString != null)
            {
                Private___37_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal float? __2_intnl_SystemSingle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_SystemSingle != null)
            {
                return Private___2_intnl_SystemSingle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_intnl_SystemSingle != null)
                {
                    Private___2_intnl_SystemSingle.Value = value.Value;
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

    internal string[] __0_vipsArray3_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_vipsArray3_StringArray != null)
            {
                return Private___0_vipsArray3_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_vipsArray3_StringArray != null)
            {
                Private___0_vipsArray3_StringArray.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour playerList
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_playerList != null)
            {
                return Private_playerList.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_playerList != null)
            {
                Private_playerList.Value = value;
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

    internal bool? __44_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___44_intnl_SystemBoolean != null)
            {
                return Private___44_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___44_intnl_SystemBoolean != null)
                {
                    Private___44_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject elitesCamera
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_elitesCamera != null)
            {
                return Private_elitesCamera.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_elitesCamera != null)
            {
                Private_elitesCamera.Value = value;
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

    internal UnityEngine.Vector3? __4_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_UnityEngineVector3 != null)
            {
                return Private___4_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___4_intnl_UnityEngineVector3 != null)
                {
                    Private___4_intnl_UnityEngineVector3.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.ParticleSystem ejectParticle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_ejectParticle != null)
            {
                return Private_ejectParticle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_ejectParticle != null)
            {
                Private_ejectParticle.Value = value;
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

    internal UnityEngine.GameObject __0_tmpGO_GameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_tmpGO_GameObject != null)
            {
                return Private___0_tmpGO_GameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_tmpGO_GameObject != null)
            {
                Private___0_tmpGO_GameObject.Value = value;
            }
        }
    }

    internal UnityEngine.GameObject __0_this_intnl_UnityEngineGameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_this_intnl_UnityEngineGameObject != null)
            {
                return Private___0_this_intnl_UnityEngineGameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_this_intnl_UnityEngineGameObject != null)
            {
                Private___0_this_intnl_UnityEngineGameObject.Value = value;
            }
        }
    }

    internal UnityEngine.Material __3_intnl_SystemObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemObject != null)
            {
                return Private___3_intnl_SystemObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_intnl_SystemObject != null)
            {
                Private___3_intnl_SystemObject.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi[] vipsInInstance
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipsInInstance != null)
            {
                return Private_vipsInInstance.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipsInInstance != null)
            {
                Private_vipsInInstance.Value = value;
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

    internal string __49_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___49_intnl_SystemString != null)
            {
                return Private___49_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___49_intnl_SystemString != null)
            {
                Private___49_intnl_SystemString.Value = value;
            }
        }
    }

    internal UnityEngine.GameObject __0_canvasGO_GameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_canvasGO_GameObject != null)
            {
                return Private___0_canvasGO_GameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_canvasGO_GameObject != null)
            {
                Private___0_canvasGO_GameObject.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi onPlayerJoinedPlayer
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_onPlayerJoinedPlayer != null)
            {
                return Private_onPlayerJoinedPlayer.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_onPlayerJoinedPlayer != null)
            {
                Private_onPlayerJoinedPlayer.Value = value;
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

    internal bool? __0_isPatron_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_isPatron_Boolean != null)
            {
                return Private___0_isPatron_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_isPatron_Boolean != null)
                {
                    Private___0_isPatron_Boolean.Value = value.Value;
                }
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

    internal bool? vipOnlyLocal
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipOnlyLocal != null)
            {
                return Private_vipOnlyLocal.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_vipOnlyLocal != null)
                {
                    Private_vipOnlyLocal.Value = value.Value;
                }
            }
        }
    }

    internal char[] __3_const_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_const_intnl_SystemCharArray != null)
            {
                return Private___3_const_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_const_intnl_SystemCharArray != null)
            {
                Private___3_const_intnl_SystemCharArray.Value = value;
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

    internal UnityEngine.AudioClip eliteBellDefault
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteBellDefault != null)
            {
                return Private_eliteBellDefault.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteBellDefault != null)
            {
                Private_eliteBellDefault.Value = value;
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

    internal UnityEngine.GameObject __0_ownFlairButton_GameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_ownFlairButton_GameObject != null)
            {
                return Private___0_ownFlairButton_GameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_ownFlairButton_GameObject != null)
            {
                Private___0_ownFlairButton_GameObject.Value = value;
            }
        }
    }

    internal string __13_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___13_intnl_SystemString != null)
            {
                return Private___13_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___13_intnl_SystemString != null)
            {
                Private___13_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __32_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___32_const_intnl_SystemString != null)
            {
                return Private___32_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___32_const_intnl_SystemString != null)
            {
                Private___32_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal int? __29_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___29_intnl_SystemInt32 != null)
            {
                return Private___29_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___29_intnl_SystemInt32 != null)
                {
                    Private___29_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __35_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___35_intnl_SystemBoolean != null)
            {
                return Private___35_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___35_intnl_SystemBoolean != null)
                {
                    Private___35_intnl_SystemBoolean.Value = value.Value;
                }
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

    internal bool? __7_intnl_SystemObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_intnl_SystemObject != null)
            {
                return Private___7_intnl_SystemObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___7_intnl_SystemObject != null)
                {
                    Private___7_intnl_SystemObject.Value = value.Value;
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

    internal uint? __22_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___22_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___22_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___22_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___22_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
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

    internal UnityEngine.GameObject[] ownFlairButtons
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_ownFlairButtons != null)
            {
                return Private_ownFlairButtons.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_ownFlairButtons != null)
            {
                Private_ownFlairButtons.Value = value;
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

    internal UnityEngine.UI.Text vipWall
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipWall != null)
            {
                return Private_vipWall.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipWall != null)
            {
                Private_vipWall.Value = value;
            }
        }
    }

    internal string __0_elite_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_elite_String != null)
            {
                return Private___0_elite_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_elite_String != null)
            {
                Private___0_elite_String.Value = value;
            }
        }
    }

    internal UnityEngine.Vector3? __0_rootPos_Vector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_rootPos_Vector3 != null)
            {
                return Private___0_rootPos_Vector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_rootPos_Vector3 != null)
                {
                    Private___0_rootPos_Vector3.Value = value.Value;
                }
            }
        }
    }

    internal bool? __48_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___48_intnl_SystemBoolean != null)
            {
                return Private___48_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___48_intnl_SystemBoolean != null)
                {
                    Private___48_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __30_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___30_intnl_SystemInt32 != null)
            {
                return Private___30_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___30_intnl_SystemInt32 != null)
                {
                    Private___30_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __44_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___44_const_intnl_SystemString != null)
            {
                return Private___44_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___44_const_intnl_SystemString != null)
            {
                Private___44_const_intnl_SystemString.Value = value;
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

    internal string __0_trimmedElite_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_trimmedElite_String != null)
            {
                return Private___0_trimmedElite_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_trimmedElite_String != null)
            {
                Private___0_trimmedElite_String.Value = value;
            }
        }
    }

    internal bool? __33_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___33_intnl_SystemBoolean != null)
            {
                return Private___33_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___33_intnl_SystemBoolean != null)
                {
                    Private___33_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.AudioSource vipBadAudio
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipBadAudio != null)
            {
                return Private_vipBadAudio.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipBadAudio != null)
            {
                Private_vipBadAudio.Value = value;
            }
        }
    }

    internal UnityEngine.GameObject __3_intnl_UnityEngineGameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_UnityEngineGameObject != null)
            {
                return Private___3_intnl_UnityEngineGameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_intnl_UnityEngineGameObject != null)
            {
                Private___3_intnl_UnityEngineGameObject.Value = value;
            }
        }
    }

    internal int? __33_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___33_intnl_SystemInt32 != null)
            {
                return Private___33_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___33_intnl_SystemInt32 != null)
                {
                    Private___33_intnl_SystemInt32.Value = value.Value;
                }
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

    internal string __47_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___47_intnl_SystemString != null)
            {
                return Private___47_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___47_intnl_SystemString != null)
            {
                Private___47_intnl_SystemString.Value = value;
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

    internal UnityEngine.GameObject[] eliteNameplates
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteNameplates != null)
            {
                return Private_eliteNameplates.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteNameplates != null)
            {
                Private_eliteNameplates.Value = value;
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

    internal string __45_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___45_const_intnl_SystemString != null)
            {
                return Private___45_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___45_const_intnl_SystemString != null)
            {
                Private___45_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? vipOnly
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipOnly != null)
            {
                return Private_vipOnly.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_vipOnly != null)
                {
                    Private_vipOnly.Value = value.Value;
                }
            }
        }
    }

    internal bool? __36_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___36_intnl_SystemBoolean != null)
            {
                return Private___36_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___36_intnl_SystemBoolean != null)
                {
                    Private___36_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal float? __0_intnl_SystemSingle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemSingle != null)
            {
                return Private___0_intnl_SystemSingle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_SystemSingle != null)
                {
                    Private___0_intnl_SystemSingle.Value = value.Value;
                }
            }
        }
    }

    internal string __12_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___12_intnl_SystemString != null)
            {
                return Private___12_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___12_intnl_SystemString != null)
            {
                Private___12_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __40_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___40_intnl_SystemBoolean != null)
            {
                return Private___40_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___40_intnl_SystemBoolean != null)
                {
                    Private___40_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal bool? __8_intnl_SystemObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_intnl_SystemObject != null)
            {
                return Private___8_intnl_SystemObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___8_intnl_SystemObject != null)
                {
                    Private___8_intnl_SystemObject.Value = value.Value;
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

    internal int? __25_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___25_intnl_SystemInt32 != null)
            {
                return Private___25_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___25_intnl_SystemInt32 != null)
                {
                    Private___25_intnl_SystemInt32.Value = value.Value;
                }
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

    internal int? __22_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___22_intnl_SystemInt32 != null)
            {
                return Private___22_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___22_intnl_SystemInt32 != null)
                {
                    Private___22_intnl_SystemInt32.Value = value.Value;
                }
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

    internal UnityEngine.GameObject vipOnlyIndicator
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipOnlyIndicator != null)
            {
                return Private_vipOnlyIndicator.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipOnlyIndicator != null)
            {
                Private_vipOnlyIndicator.Value = value;
            }
        }
    }

    internal UnityEngine.Vector3? __3_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_UnityEngineVector3 != null)
            {
                return Private___3_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_intnl_UnityEngineVector3 != null)
                {
                    Private___3_intnl_UnityEngineVector3.Value = value.Value;
                }
            }
        }
    }

    internal bool? __47_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___47_intnl_SystemBoolean != null)
            {
                return Private___47_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___47_intnl_SystemBoolean != null)
                {
                    Private___47_intnl_SystemBoolean.Value = value.Value;
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

    internal string __47_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___47_const_intnl_SystemString != null)
            {
                return Private___47_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___47_const_intnl_SystemString != null)
            {
                Private___47_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal UnityEngine.RectTransform __4_intnl_UnityEngineTransform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_UnityEngineTransform != null)
            {
                return Private___4_intnl_UnityEngineTransform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_intnl_UnityEngineTransform != null)
            {
                Private___4_intnl_UnityEngineTransform.Value = value;
            }
        }
    }

    internal UnityEngine.AudioClip[] eliteBells
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_eliteBells != null)
            {
                return Private_eliteBells.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_eliteBells != null)
            {
                Private_eliteBells.Value = value;
            }
        }
    }

    internal string __14_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___14_intnl_SystemString != null)
            {
                return Private___14_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___14_intnl_SystemString != null)
            {
                Private___14_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __0_elitesArray3_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_elitesArray3_StringArray != null)
            {
                return Private___0_elitesArray3_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_elitesArray3_StringArray != null)
            {
                Private___0_elitesArray3_StringArray.Value = value;
            }
        }
    }

    internal string __46_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___46_intnl_SystemString != null)
            {
                return Private___46_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___46_intnl_SystemString != null)
            {
                Private___46_intnl_SystemString.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __9_intnl_VRCSDKBaseVRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                return Private___9_intnl_VRCSDKBaseVRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___9_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                Private___9_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

    internal string __1_playerName_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_playerName_String != null)
            {
                return Private___1_playerName_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_playerName_String != null)
            {
                Private___1_playerName_String.Value = value;
            }
        }
    }

    internal uint? __30_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___30_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___30_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___30_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___30_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal bool? __39_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___39_intnl_SystemBoolean != null)
            {
                return Private___39_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___39_intnl_SystemBoolean != null)
                {
                    Private___39_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi[] __0_players_VRCPlayerApiArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_players_VRCPlayerApiArray != null)
            {
                return Private___0_players_VRCPlayerApiArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_players_VRCPlayerApiArray != null)
            {
                Private___0_players_VRCPlayerApiArray.Value = value;
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

    internal string __11_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___11_intnl_SystemString != null)
            {
                return Private___11_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___11_intnl_SystemString != null)
            {
                Private___11_intnl_SystemString.Value = value;
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

    internal string __38_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___38_const_intnl_SystemString != null)
            {
                return Private___38_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___38_const_intnl_SystemString != null)
            {
                Private___38_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string[] __0_vipsArray_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_vipsArray_StringArray != null)
            {
                return Private___0_vipsArray_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_vipsArray_StringArray != null)
            {
                Private___0_vipsArray_StringArray.Value = value;
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

    internal int[] vipIds
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_vipIds != null)
            {
                return Private_vipIds.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_vipIds != null)
            {
                Private_vipIds.Value = value;
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

    internal VRC.Udon.UdonBehaviour materials
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_materials != null)
            {
                return Private_materials.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_materials != null)
            {
                Private_materials.Value = value;
            }
        }
    }

    internal string __25_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___25_const_intnl_SystemString != null)
            {
                return Private___25_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___25_const_intnl_SystemString != null)
            {
                Private___25_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal UnityEngine.GameObject __5_intnl_UnityEngineGameObject
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_intnl_UnityEngineGameObject != null)
            {
                return Private___5_intnl_UnityEngineGameObject.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___5_intnl_UnityEngineGameObject != null)
            {
                Private___5_intnl_UnityEngineGameObject.Value = value;
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

    internal string __45_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___45_intnl_SystemString != null)
            {
                return Private___45_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___45_intnl_SystemString != null)
            {
                Private___45_intnl_SystemString.Value = value;
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

    internal UnityEngine.Vector3? __2_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_UnityEngineVector3 != null)
            {
                return Private___2_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_intnl_UnityEngineVector3 != null)
                {
                    Private___2_intnl_UnityEngineVector3.Value = value.Value;
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

    internal string __39_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___39_const_intnl_SystemString != null)
            {
                return Private___39_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___39_const_intnl_SystemString != null)
            {
                Private___39_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal string __0_eliteName_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_eliteName_String != null)
            {
                return Private___0_eliteName_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_eliteName_String != null)
            {
                Private___0_eliteName_String.Value = value;
            }
        }
    }

    internal bool? __0_useCanvas_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_useCanvas_Boolean != null)
            {
                return Private___0_useCanvas_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_useCanvas_Boolean != null)
                {
                    Private___0_useCanvas_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal uint? __25_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___25_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___25_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___25_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___25_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
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

    internal uint? __29_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___29_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___29_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___29_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___29_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
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

    internal float? __3_intnl_SystemSingle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemSingle != null)
            {
                return Private___3_intnl_SystemSingle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_intnl_SystemSingle != null)
                {
                    Private___3_intnl_SystemSingle.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0_isElite_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_isElite_Boolean != null)
            {
                return Private___0_isElite_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_isElite_Boolean != null)
                {
                    Private___0_isElite_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.HumanBodyBones? __0_const_intnl_UnityEngineHumanBodyBones
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_UnityEngineHumanBodyBones != null)
            {
                return Private___0_const_intnl_UnityEngineHumanBodyBones.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___0_const_intnl_UnityEngineHumanBodyBones != null)
                {
                    Private___0_const_intnl_UnityEngineHumanBodyBones.Value = value.Value;
                }
            }
        }
    }

    internal string __27_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___27_const_intnl_SystemString != null)
            {
                return Private___27_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___27_const_intnl_SystemString != null)
            {
                Private___27_const_intnl_SystemString.Value = value;
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

    internal UnityEngine.Material __4_intnl_UnityEngineMaterial
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_UnityEngineMaterial != null)
            {
                return Private___4_intnl_UnityEngineMaterial.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_intnl_UnityEngineMaterial != null)
            {
                Private___4_intnl_UnityEngineMaterial.Value = value;
            }
        }
    }

    internal string __42_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___42_const_intnl_SystemString != null)
            {
                return Private___42_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___42_const_intnl_SystemString != null)
            {
                Private___42_const_intnl_SystemString.Value = value;
            }
        }
    }

    internal bool? __45_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___45_intnl_SystemBoolean != null)
            {
                return Private___45_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___45_intnl_SystemBoolean != null)
                {
                    Private___45_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal int? __28_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___28_intnl_SystemInt32 != null)
            {
                return Private___28_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___28_intnl_SystemInt32 != null)
                {
                    Private___28_intnl_SystemInt32.Value = value.Value;
                }
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

    internal string __0_mp_vips_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_vips_String != null)
            {
                return Private___0_mp_vips_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_vips_String != null)
            {
                Private___0_mp_vips_String.Value = value;
            }
        }
    }

    internal int? __0_patronId_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_patronId_Int32 != null)
            {
                return Private___0_patronId_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_patronId_Int32 != null)
                {
                    Private___0_patronId_Int32.Value = value.Value;
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

    internal bool? __43_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___43_intnl_SystemBoolean != null)
            {
                return Private___43_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___43_intnl_SystemBoolean != null)
                {
                    Private___43_intnl_SystemBoolean.Value = value.Value;
                }
            }
        }
    }

    internal string[] __0_vipsArray2_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_vipsArray2_StringArray != null)
            {
                return Private___0_vipsArray2_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_vipsArray2_StringArray != null)
            {
                Private___0_vipsArray2_StringArray.Value = value;
            }
        }
    }

    internal UnityEngine.RectTransform __5_intnl_UnityEngineTransform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_intnl_UnityEngineTransform != null)
            {
                return Private___5_intnl_UnityEngineTransform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___5_intnl_UnityEngineTransform != null)
            {
                Private___5_intnl_UnityEngineTransform.Value = value;
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

    internal char? __3_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_const_intnl_SystemChar != null)
            {
                return Private___3_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_const_intnl_SystemChar != null)
                {
                    Private___3_const_intnl_SystemChar.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi _localPlayer
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private__localPlayer != null)
            {
                return Private__localPlayer.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private__localPlayer != null)
            {
                Private__localPlayer.Value = value;
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

    internal VRC.Udon.Common.Interfaces.NetworkEventTarget? __0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget != null)
            {
                return Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget != null)
                {
                    Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget.Value = value.Value;
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

    internal bool? __46_intnl_SystemBoolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___46_intnl_SystemBoolean != null)
            {
                return Private___46_intnl_SystemBoolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___46_intnl_SystemBoolean != null)
                {
                    Private___46_intnl_SystemBoolean.Value = value.Value;
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

    internal string __30_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___30_const_intnl_SystemString != null)
            {
                return Private___30_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___30_const_intnl_SystemString != null)
            {
                Private___30_const_intnl_SystemString.Value = value;
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

    internal int? __24_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___24_intnl_SystemInt32 != null)
            {
                return Private___24_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___24_intnl_SystemInt32 != null)
                {
                    Private___24_intnl_SystemInt32.Value = value.Value;
                }
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

    internal UnityEngine.RectTransform __3_intnl_UnityEngineTransform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_UnityEngineTransform != null)
            {
                return Private___3_intnl_UnityEngineTransform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_intnl_UnityEngineTransform != null)
            {
                Private___3_intnl_UnityEngineTransform.Value = value;
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

    internal string __31_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___31_const_intnl_SystemString != null)
            {
                return Private___31_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___31_const_intnl_SystemString != null)
            {
                Private___31_const_intnl_SystemString.Value = value;
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

    internal uint? __27_const_intnl_exitJumpLoc_UInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___27_const_intnl_exitJumpLoc_UInt32 != null)
            {
                return Private___27_const_intnl_exitJumpLoc_UInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___27_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    Private___27_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                }
            }
        }
    }

    internal int? __27_intnl_SystemInt32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___27_intnl_SystemInt32 != null)
            {
                return Private___27_intnl_SystemInt32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___27_intnl_SystemInt32 != null)
                {
                    Private___27_intnl_SystemInt32.Value = value.Value;
                }
            }
        }
    }

    internal string __36_const_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___36_const_intnl_SystemString != null)
            {
                return Private___36_const_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___36_const_intnl_SystemString != null)
            {
                Private___36_const_intnl_SystemString.Value = value;
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

    internal VRC.Udon.UdonBehaviour readRenderTexture
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_readRenderTexture != null)
            {
                return Private_readRenderTexture.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_readRenderTexture != null)
            {
                Private_readRenderTexture.Value = value;
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

    internal UnityEngine.AudioSource ejectAudio
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_ejectAudio != null)
            {
                return Private_ejectAudio.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_ejectAudio != null)
            {
                Private_ejectAudio.Value = value;
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

    internal string __16_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___16_intnl_SystemString != null)
            {
                return Private___16_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___16_intnl_SystemString != null)
            {
                Private___16_intnl_SystemString.Value = value;
            }
        }
    }

    #endregion Getter / Setters AstroUdonVariables  of PatreonSystem

    #region AstroUdonVariables  of PatreonSystem

    private AstroUdonVariable<string> Private___33_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___0_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___32_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_utilities { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___48_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_intnl_VRCSDKBaseVRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___1_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___3_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___21_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.ParticleSystem> Private_vipBadParticle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.RectTransform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___49_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___16_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_ownFlairEnabled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.MeshRenderer> Private_vipOnlyButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_x_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_x_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_y_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_x_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___5_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___7_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___6_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___2_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___48_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_mp_elites_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Material> Private___6_intnl_UnityEngineMaterial { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___24_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___20_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___28_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.RectTransform> Private___2_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___1_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___1_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private_elitesInInstance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___28_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_vipFlairs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___40_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___29_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___0_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___23_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioSource> Private_vipGoodAudio { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___4_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___41_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_elitesArray2_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___46_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_Patreon { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___3_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_patrons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___23_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_divider_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerLocator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.MeshRenderer[]> Private_ownFlairButtonMeshes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___43_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_teleports { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___1_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_eliteFlairs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_vip_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___31_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___12_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___34_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___26_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___31_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___50_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___0_yPos_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___35_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.TextAsset> Private_patronsTxt { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___26_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_visibleVips_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___51_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___26_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int[]> Private_eliteIds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___44_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_mp_adding_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___20_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private_flairOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___37_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___18_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_vipsArray3_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___23_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_myInstance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_elitesCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___4_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.ParticleSystem> Private_ejectParticle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_tmpGO_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_this_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Material> Private___3_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private_vipsInInstance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_ready { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___49_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_canvasGO_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_onPlayerJoinedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___24_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_isPatron_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___15_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_vipOnlyLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___3_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___19_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip> Private_eliteBellDefault { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___21_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_ownFlairButton_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___13_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___32_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___29_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___7_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___0_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___22_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_ownFlairButtons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.UI.Text> Private_vipWall { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_elite_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___0_rootPos_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___30_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___44_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_trimmedElite_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioSource> Private_vipBadAudio { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___3_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___33_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___47_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject[]> Private_eliteNameplates { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___2_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___45_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_vipOnly { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___8_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_wallText_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___25_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___4_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___6_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_elites { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___22_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_vipOnlyIndicator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___47_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.RectTransform> Private___4_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioClip[]> Private_eliteBells { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___14_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_elitesArray3_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___46_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___9_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_playerName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___17_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_playerName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___30_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_players_VRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___24_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___38_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_vipsArray_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int[]> Private_vipIds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_materials { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___25_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___5_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___45_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___39_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_eliteName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_useCanvas_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___25_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_mp_patronsToProcess_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___29_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___2_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___19_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_isElite_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.HumanBodyBones> Private___0_const_intnl_UnityEngineHumanBodyBones { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___27_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Material> Private___4_intnl_UnityEngineMaterial { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___42_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___28_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_mp_vips_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_patronId_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___2_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_vipsArray2_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.RectTransform> Private___5_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_groups_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___14_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___3_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private__localPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___25_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___18_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___17_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___30_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___2_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___24_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___13_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.RectTransform> Private___3_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___2_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___31_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___27_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___27_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___36_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_rooms { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___5_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_readRenderTexture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.AudioSource> Private_ejectAudio { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___16_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    #endregion AstroUdonVariables  of PatreonSystem

}