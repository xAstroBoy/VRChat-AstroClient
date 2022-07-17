using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.Infested
{
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class Infested_GameManager : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public Infested_GameManager(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Infested))
            {
                var obj = gameObject.FindUdonEvent("DropLegendaryWeapons");
                if (obj != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    GameManager = obj.RawItem;
                    Initialize_GameManager();
                    InvokeRepeating(nameof(UnlimitedAmmos), 0.1f, 0.1f);
                    InvokeRepeating(nameof(UnlimitedMoney), 0.1f, 0.1f);

                }
                else
                {
                    Log.Error("Can't Find GameManager behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        private  void UnlimitedAmmos()
        {
            if(WorldModifications.WorldHacks.NoLife1942.Infested.UnlimitedAmmo)
            {
                ammoReserve = System.Int32.MaxValue;
                maxAmmo = System.Int32.MaxValue;
            }
        }

        private void UnlimitedMoney()
        {
            if (WorldModifications.WorldHacks.NoLife1942.Infested.UnlimitedMoney)
            {
                currency = System.Int32.MaxValue;
                maxMoney = System.Int32.MaxValue;
            }
        }


        private void OnDestroy()
        {
            ClientEventActions.OnRoomLeft -= OnRoomLeft;
            Cleanup_GameManager();
        }

        // TODO: Bind UdonBehaviour with this section
        // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!
        // TODO: READER FOR UDONBEHAVIOUR GameManager!
        private RawUdonBehaviour GameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_GameManager()
        {
            Private___35_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__35_intnl_SystemInt32");
            Private___0_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_NL_PlayerCharacter");
            Private___33_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__33_const_intnl_SystemString");
            Private_allWorkshopManagers = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "allWorkshopManagers");
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__23_intnl_SystemBoolean");
            Private___32_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__32_intnl_SystemInt32");
            Private___77_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__77_intnl_SystemBoolean");
            Private___1_const_intnl_VRCSDKBaseVRC_PickupPickupHand = new AstroUdonVariable<VRC.SDKBase.VRC_Pickup.PickupHand>(GameManager, "__1_const_intnl_VRCSDKBaseVRC_PickupPickupHand");
            Private___29_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__29_intnl_SystemInt16");
            Private___48_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__48_const_intnl_SystemString");
            Private___7_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__7_intnl_SystemInt64");
            Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__15_intnl_SystemInt32");
            Private___21_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__21_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__3_intnl_SystemInt16");
            Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__12_intnl_SystemInt32");
            Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__52_intnl_SystemBoolean");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__3_const_intnl_SystemString");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___12_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__12_intnl_VRCSDKBaseVRCPlayerApi");
            Private___93_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__93_const_intnl_SystemString");
            Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__26_intnl_SystemBoolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__0_const_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(GameManager, "__1_intnl_UnityEngineQuaternion");
            Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__41_intnl_SystemBoolean");
            Private___30_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__30_intnl_SystemInt16");
            Private_humanJumpHeight = new AstroUdonVariable<float>(GameManager, "humanJumpHeight");
            Private___3_const_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__3_const_intnl_SystemSingle");
            Private___118_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__118_intnl_SystemBoolean");
            Private_identityRevealTime = new AstroUdonVariable<int>(GameManager, "identityRevealTime");
            Private___0_intnl_NL_WorkshopManagerArray = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "__0_intnl_NL_WorkshopManagerArray");
            Private___0_intnl_NL_PlayerCharacterArray = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "__0_intnl_NL_PlayerCharacterArray");
            Private___95_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__95_intnl_SystemBoolean");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__1_const_intnl_SystemInt32");
            Private___13_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__13_intnl_NL_PlayerCharacter");
            Private___49_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__49_const_intnl_SystemString");
            Private___13_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__13_intnl_VRCSDKBaseVRCPlayerApi");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__1_intnl_SystemInt32");
            Private___33_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__33_intnl_SystemInt16");
            Private___10_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__10_intnl_SystemInt16");
            Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__16_const_intnl_exitJumpLoc_UInt32");
            Private___72_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__72_const_intnl_SystemString");
            Private___119_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__119_intnl_SystemBoolean");
            Private___35_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__35_intnl_SystemObject");
            Private___2_intnl_SystemObject = new AstroUdonVariable<bool>(GameManager, "__2_intnl_SystemObject");
            Private___45_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__45_intnl_SystemInt32");
            Private___1_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__1_intnl_SystemString");
            Private___50_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__50_intnl_SystemInt32");
            Private___1_i_Int32 = new AstroUdonVariable<int>(GameManager, "__1_i_Int32");
            Private___0_i_Int32 = new AstroUdonVariable<int>(GameManager, "__0_i_Int32");
            Private___13_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__13_intnl_SystemInt16");
            Private___42_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__42_intnl_SystemInt32");
            Private_spectateCharacters = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "spectateCharacters");
            Private___2_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__2_intnl_VRCSDKBaseVRCPlayerApi");
            Private___6_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__6_intnl_VRCSDKBaseVRCPlayerApi");
            Private___3_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__3_intnl_UnityEngineComponent");
            Private___93_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__93_intnl_SystemBoolean");
            Private___53_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__53_intnl_SystemInt32");
            Private___4_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__4_const_intnl_SystemInt64");
            Private___8_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__8_intnl_SystemInt64");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__0_const_intnl_SystemString");
            Private_ammoSpawnDelay = new AstroUdonVariable<int>(GameManager, "ammoSpawnDelay");
            Private___1_workshop_NL_WorkshopManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_workshop_NL_WorkshopManager");
            Private_weaponManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "weaponManager");
            Private___12_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__12_intnl_NL_PlayerCharacter");
            Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__42_intnl_SystemBoolean");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__0_const_intnl_SystemSingle");
            Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__29_intnl_SystemBoolean");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__1_intnl_SystemSingle");
            Private___7_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__7_intnl_SystemInt16");
            Private_killRewards = new AstroUdonVariable<int>(GameManager, "killRewards");
            Private___22_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__22_intnl_SystemInt16");
            Private___96_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__96_intnl_SystemBoolean");
            Private___34_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__34_intnl_VRCSDKBaseVRCPlayerApi");
            Private___9_intnl_SystemObject = new AstroUdonVariable<bool>(GameManager, "__9_intnl_SystemObject");
            Private___0_this_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "__0_this_intnl_UnityEngineTransform");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__5_intnl_SystemBoolean");
            Private___65_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__65_intnl_SystemInt32");
            Private___85_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__85_intnl_SystemBoolean");
            Private_playerIndex = new AstroUdonVariable<int>(GameManager, "playerIndex");
            Private___62_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__62_intnl_SystemInt32");
            Private___0_spawnPoint_Transform = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "__0_spawnPoint_Transform");
            Private___1_itemInHand_VRC_Pickup = new AstroUdonVariable<VRC.SDK3.Components.VRCPickup>(GameManager, "__1_itemInHand_VRC_Pickup");
            Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__10_const_intnl_exitJumpLoc_UInt32");
            Private___104_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__104_intnl_SystemBoolean");
            Private___2_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(GameManager, "__2_intnl_returnValSymbol_Boolean");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___103_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__103_intnl_SystemBoolean");
            Private___1_gunInHand_NL_Gun = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_gunInHand_NL_Gun");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__15_intnl_SystemBoolean");
            Private_humanPlayerCount = new AstroUdonVariable<int>(GameManager, "humanPlayerCount");
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__1_intnl_VRCSDKBaseVRCPlayerApi");
            Private___5_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__5_intnl_VRCSDKBaseVRCPlayerApi");
            Private_initialMoney = new AstroUdonVariable<int>(GameManager, "initialMoney");
            Private___24_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__24_const_intnl_exitJumpLoc_UInt32");
            Private___2_mp_delta_Int32 = new AstroUdonVariable<int>(GameManager, "__2_mp_delta_Int32");
            Private___6_intnl_SystemObject = new AstroUdonVariable<bool>(GameManager, "__6_intnl_SystemObject");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__5_intnl_SystemString");
            Private___105_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__105_intnl_SystemBoolean");
            Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__34_intnl_SystemBoolean");
            Private___28_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__28_const_intnl_SystemString");
            Private___2_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "__2_intnl_UnityEngineTransform");
            Private_cameraSpectate = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "cameraSpectate");
            Private___1_character_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_character_NL_PlayerCharacter");
            Private___58_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__58_const_intnl_SystemString");
            Private___83_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__83_intnl_SystemBoolean");
            Private_initialAmmo = new AstroUdonVariable<int>(GameManager, "initialAmmo");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__6_const_intnl_SystemString");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__21_intnl_SystemBoolean");
            Private___138_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__138_intnl_SystemBoolean");
            Private___75_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__75_intnl_SystemBoolean");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_returnValSymbol_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__3_intnl_returnValSymbol_NL_PlayerCharacter");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__13_intnl_SystemBoolean");
            Private_isJoinedGame = new AstroUdonVariable<bool>(GameManager, "isJoinedGame");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__4_const_intnl_SystemInt32");
            Private___1_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_intnl_UnityEngineComponent");
            Private___64_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__64_intnl_SystemBoolean");
            Private___40_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__40_const_intnl_SystemString");
            Private___8_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__8_intnl_SystemInt16");
            Private___139_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__139_intnl_SystemBoolean");
            Private___99_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__99_intnl_SystemBoolean");
            Private___38_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__38_intnl_SystemInt32");
            Private___0_mp_damageTake_Int32 = new AstroUdonVariable<int>(GameManager, "__0_mp_damageTake_Int32");
            Private___25_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__25_intnl_SystemInt16");
            Private___86_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__86_intnl_SystemBoolean");
            Private___29_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__29_const_intnl_SystemString");
            Private___1_const_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__1_const_intnl_SystemSingle");
            Private___23_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__23_const_intnl_exitJumpLoc_UInt32");
            Private___59_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__59_const_intnl_SystemString");
            Private___0_resultCharacter_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_resultCharacter_NL_PlayerCharacter");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__5_intnl_SystemSingle");
            Private___84_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__84_const_intnl_SystemString");
            Private___56_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__56_intnl_SystemInt32");
            Private___5_character_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__5_character_NL_PlayerCharacter");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__18_intnl_SystemInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__16_intnl_SystemBoolean");
            Private___73_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__73_intnl_SystemBoolean");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__14_const_intnl_SystemString");
            Private___41_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__41_const_intnl_SystemString");
            Private___46_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__46_const_intnl_SystemString");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__7_intnl_SystemBoolean");
            Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__20_intnl_SystemInt32");
            Private___1_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__1_intnl_SystemInt64");
            Private___85_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__85_const_intnl_SystemString");
            Private___64_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__64_const_intnl_SystemString");
            Private___9_character_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__9_character_NL_PlayerCharacter");
            Private___1_intnl_NL_UpdateManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_intnl_NL_UpdateManager");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__22_intnl_SystemBoolean");
            Private___20_intnl_SystemObject = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__20_intnl_SystemObject");
            Private___1_intnl_NLI_PlayerSlotUI = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_intnl_NLI_PlayerSlotUI");
            Private___0_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "__0_intnl_UnityEngineComponentArray");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___76_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__76_intnl_SystemBoolean");
            Private_effectManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "effectManager");
            Private___78_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__78_const_intnl_SystemString");
            Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__23_intnl_SystemInt32");
            Private_killEventTimer = new AstroUdonVariable<float>(GameManager, "killEventTimer");
            Private___91_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__91_intnl_SystemBoolean");
            Private___36_intnl_SystemObject = new AstroUdonVariable<string>(GameManager, "__36_intnl_SystemObject");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__7_const_intnl_SystemString");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__15_const_intnl_SystemString");
            Private___35_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__35_intnl_VRCSDKBaseVRCPlayerApi");
            Private___1_tempNum_Int32 = new AstroUdonVariable<int>(GameManager, "__1_tempNum_Int32");
            Private___0_const_intnl_NL_WorkshopManagerArray = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "__0_const_intnl_NL_WorkshopManagerArray");
            Private_teleportCheckTimer = new AstroUdonVariable<float>(GameManager, "teleportCheckTimer");
            Private___48_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__48_intnl_SystemInt32");
            Private_isInfested = new AstroUdonVariable<bool>(GameManager, "isInfested");
            Private___2_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "__2_intnl_UnityEngineComponentArray");
            Private___89_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__89_intnl_SystemBoolean");
            Private___36_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__36_intnl_VRCSDKBaseVRCPlayerApi");
            Private___16_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__16_intnl_SystemInt16");
            Private___8_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__8_intnl_VRCSDKBaseVRCPlayerApi");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(GameManager, "__refl_const_intnl_udonTypeID");
            Private___65_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__65_const_intnl_SystemString");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__4_intnl_SystemBoolean");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__11_intnl_SystemSingle");
            Private___0_intnl_NL_Gun = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_NL_Gun");
            Private___106_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__106_intnl_SystemBoolean");
            Private___43_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__43_const_intnl_SystemString");
            Private___34_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__34_intnl_SystemInt32");
            Private___79_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__79_const_intnl_SystemString");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__19_intnl_SystemBoolean");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(GameManager, "__refl_const_intnl_udonTypeName");
            Private___37_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__37_intnl_VRCSDKBaseVRCPlayerApi");
            Private___9_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__9_intnl_NL_PlayerCharacter");
            Private___127_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__127_intnl_SystemBoolean");
            Private_hasEnterHeroMode = new AstroUdonVariable<bool>(GameManager, "hasEnterHeroMode");
            Private___87_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__87_const_intnl_SystemString");
            Private_mapLayoutSet = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "mapLayoutSet");
            Private___0_intnl_SystemObject = new AstroUdonVariable<long>(GameManager, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__1_intnl_SystemBoolean");
            Private_audioSource_Lobby = new AstroUdonVariable<UnityEngine.AudioSource>(GameManager, "audioSource_Lobby");
            Private___28_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__28_intnl_SystemInt16");
            Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__38_intnl_SystemBoolean");
            Private___31_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__31_intnl_SystemInt32");
            Private___37_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__37_intnl_SystemInt32");
            Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__14_intnl_SystemInt32");
            Private___2_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__2_intnl_NL_PlayerCharacter");
            Private___2_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__2_intnl_UnityEngineComponent");
            Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__12_const_intnl_exitJumpLoc_UInt32");
            Private_gameOverTime = new AstroUdonVariable<int>(GameManager, "gameOverTime");
            Private___34_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__34_const_intnl_SystemString");
            Private___27_intnl_SystemObject = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "__27_intnl_SystemObject");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__17_const_intnl_SystemString");
            Private___22_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__22_intnl_VRCSDKBaseVRCPlayerApi");
            Private___68_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__68_intnl_SystemInt32");
            Private___100_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__100_intnl_SystemBoolean");
            Private___14_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__14_intnl_VRCSDKBaseVRCPlayerApi");
            Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__11_intnl_SystemInt32");
            Private___79_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__79_intnl_SystemBoolean");
            Private___92_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__92_intnl_SystemBoolean");
            Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__17_intnl_SystemInt32");
            Private___5_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__5_intnl_SystemInt64");
            Private___26_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__26_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__4_const_intnl_SystemString");
            Private___28_intnl_SystemObject = new AstroUdonVariable<long>(GameManager, "__28_intnl_SystemObject");
            Private___81_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__81_intnl_SystemBoolean");
            Private___1_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__1_intnl_SystemInt16");
            Private_infestedRunningSpeed = new AstroUdonVariable<float>(GameManager, "infestedRunningSpeed");
            Private___10_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__10_intnl_SystemString");
            Private___0_mp_playerID_Int32 = new AstroUdonVariable<int>(GameManager, "__0_mp_playerID_Int32");
            Private___68_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__68_intnl_SystemBoolean");
            Private___67_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__67_const_intnl_SystemString");
            Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__20_const_intnl_SystemString");
            Private___50_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__50_const_intnl_SystemString");
            Private___4_const_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__4_const_intnl_SystemSingle");
            Private___101_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__101_intnl_SystemBoolean");
            Private___94_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__94_const_intnl_SystemString");
            Private_killedPlayerList = new AstroUdonVariable<int[]>(GameManager, "killedPlayerList");
            Private_allPlayerSlots = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "allPlayerSlots");
            Private_initialMoneySpawnRate = new AstroUdonVariable<float>(GameManager, "initialMoneySpawnRate");
            Private___35_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__35_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__2_intnl_SystemInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___44_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__44_intnl_SystemInt32");
            Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__30_intnl_SystemBoolean");
            Private___21_intnl_SystemObject = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__21_intnl_SystemObject");
            Private___26_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__26_intnl_SystemInt32");
            Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__54_intnl_SystemBoolean");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__2_intnl_SystemString");
            Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__21_const_intnl_SystemString");
            Private___13_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__13_intnl_SystemObject");
            Private___51_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__51_const_intnl_SystemString");
            Private___41_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__41_intnl_SystemInt32");
            Private___47_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__47_intnl_SystemInt32");
            Private___26_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__26_const_intnl_SystemString");
            Private___56_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__56_const_intnl_SystemString");
            Private___71_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__71_intnl_SystemBoolean");
            Private___117_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__117_intnl_SystemBoolean");
            Private___95_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__95_const_intnl_SystemString");
            Private___4_intnl_SystemObject = new AstroUdonVariable<bool>(GameManager, "__4_intnl_SystemObject");
            Private___1_mp_delta_Int32 = new AstroUdonVariable<int>(GameManager, "__1_mp_delta_Int32");
            Private___19_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__19_intnl_SystemInt16");
            Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__9_const_intnl_exitJumpLoc_UInt32");
            Private___60_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__60_intnl_SystemBoolean");
            Private___29_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__29_intnl_VRCSDKBaseVRCPlayerApi");
            Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__37_intnl_SystemBoolean");
            Private___82_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__82_intnl_SystemBoolean");
            Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__20_const_intnl_exitJumpLoc_UInt32");
            Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__9_intnl_SystemInt32");
            Private___59_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__59_intnl_SystemInt32");
            Private___37_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__37_const_intnl_SystemString");
            Private___6_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameManager, "__6_intnl_UnityEngineVector3");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__2_intnl_SystemSingle");
            Private___3_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "__3_intnl_UnityEngineComponentArray");
            Private___0_workshop_NL_WorkshopManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_workshop_NL_WorkshopManager");
            Private___64_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__64_intnl_SystemInt32");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__3_intnl_SystemBoolean");
            Private___21_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__21_intnl_SystemInt16");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(GameManager, "__0_intnl_returnValSymbol_Boolean");
            Private___5_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__5_intnl_SystemInt16");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__12_intnl_SystemBoolean");
            Private___10_intnl_SystemObject = new AstroUdonVariable<string>(GameManager, "__10_intnl_SystemObject");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__6_const_intnl_exitJumpLoc_UInt32");
            Private___70_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__70_const_intnl_SystemString");
            Private___61_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__61_intnl_SystemInt32");
            Private_weaponSkinManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "weaponSkinManager");
            Private___67_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__67_intnl_SystemInt32");
            Private___67_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__67_intnl_SystemBoolean");
            Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__23_const_intnl_SystemString");
            Private___53_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__53_const_intnl_SystemString");
            Private___0_intnl_NL_UpdateManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_NL_UpdateManager");
            Private___5_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameManager, "__5_intnl_UnityEngineVector3");
            Private_inGameZValue = new AstroUdonVariable<float>(GameManager, "inGameZValue");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__6_intnl_SystemInt32");
            Private___97_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__97_const_intnl_SystemString");
            Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__44_intnl_SystemBoolean");
            Private___0_mp_delta_Int32 = new AstroUdonVariable<int>(GameManager, "__0_mp_delta_Int32");
            Private___29_intnl_SystemObject = new AstroUdonVariable<int>(GameManager, "__29_intnl_SystemObject");
            Private___82_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__82_const_intnl_SystemString");
            Private___72_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__72_intnl_SystemBoolean");
            Private___6_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__6_intnl_SystemString");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__0_intnl_SystemBoolean");
            Private___4_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameManager, "__4_intnl_UnityEngineVector3");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__9_intnl_SystemSingle");
            Private___102_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__102_intnl_SystemBoolean");
            Private___15_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__15_intnl_VRCSDKBaseVRCPlayerApi");
            Private___71_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__71_const_intnl_SystemString");
            Private___3_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__3_intnl_VRCSDKBaseVRCPlayerApi");
            Private___7_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__7_intnl_VRCSDKBaseVRCPlayerApi");
            Private_playerHUD = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "playerHUD");
            Private___76_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__76_const_intnl_SystemString");
            Private___124_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__124_intnl_SystemBoolean");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__12_const_intnl_SystemString");
            Private___16_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__16_intnl_VRCSDKBaseVRCPlayerApi");
            Private___123_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__123_intnl_SystemBoolean");
            Private___32_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__32_intnl_SystemInt16");
            Private___24_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__24_intnl_SystemInt16");
            Private___3_intnl_SystemObject = new AstroUdonVariable<bool>(GameManager, "__3_intnl_SystemObject");
            Private___125_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__125_intnl_SystemBoolean");
            Private___62_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__62_const_intnl_SystemString");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__8_const_intnl_SystemString");
            Private___12_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__12_intnl_SystemInt16");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__6_intnl_SystemSingle");
            Private___27_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__27_intnl_SystemInt16");
            Private___55_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__55_intnl_SystemInt32");
            Private___3_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__3_intnl_NL_PlayerCharacter");
            Private___0_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(GameManager, "__0_intnl_UnityEngineQuaternion");
            Private___52_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__52_intnl_SystemInt32");
            Private___58_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__58_intnl_SystemBoolean");
            Private___11_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__11_intnl_SystemInt64");
            Private___137_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__137_intnl_SystemBoolean");
            Private___3_intnl_NL_Gun = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__3_intnl_NL_Gun");
            Private___0_itemInHand_VRC_Pickup = new AstroUdonVariable<VRC.SDK3.Components.VRCPickup>(GameManager, "__0_itemInHand_VRC_Pickup");
            Private___73_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__73_const_intnl_SystemString");
            Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__15_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__2_intnl_SystemInt64");
            Private___14_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__14_intnl_SystemObject");
            Private_infestedJumpHeight = new AstroUdonVariable<float>(GameManager, "infestedJumpHeight");
            Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__19_const_intnl_exitJumpLoc_UInt32");
            Private_lobbyManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "lobbyManager");
            Private___1_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "__1_intnl_UnityEngineComponentArray");
            Private___35_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__35_intnl_SystemInt16");
            Private___0_character_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_character_NL_PlayerCharacter");
            Private___22_intnl_SystemObject = new AstroUdonVariable<bool>(GameManager, "__22_intnl_SystemObject");
            Private___114_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__114_intnl_SystemBoolean");
            Private___100_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__100_const_intnl_SystemString");
            Private___0_intnl_NL_WorkshopManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_NL_WorkshopManager");
            Private___0_intnl_NLI_LobbyManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_NLI_LobbyManager");
            Private___32_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__32_const_intnl_SystemString");
            Private___113_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__113_intnl_SystemBoolean");
            Private___29_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__29_intnl_SystemInt32");
            Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__35_intnl_SystemBoolean");
            Private_hasRevealIdentity = new AstroUdonVariable<bool>(GameManager, "hasRevealIdentity");
            Private___15_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__15_intnl_SystemInt16");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__50_intnl_SystemBoolean");
            Private___7_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__7_intnl_SystemObject");
            Private___22_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__22_const_intnl_exitJumpLoc_UInt32");
            Private___115_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__115_intnl_SystemBoolean");
            Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__24_intnl_SystemBoolean");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__9_const_intnl_SystemString");
            Private___0_intnl_NL_SpectateCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_NL_SpectateCharacter");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__0_intnl_SystemInt32");
            Private___9_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__9_intnl_SystemInt64");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(GameManager, "__0_intnl_returnTarget_UInt32");
            Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__48_intnl_SystemBoolean");
            Private___30_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__30_intnl_SystemInt32");
            Private___44_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__44_const_intnl_SystemString");
            Private___65_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__65_intnl_SystemBoolean");
            Private___92_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__92_const_intnl_SystemString");
            Private___0_lastHuman_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_lastHuman_NL_PlayerCharacter");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__0_intnl_SystemString");
            Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__33_intnl_SystemBoolean");
            Private___24_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__24_intnl_VRCSDKBaseVRCPlayerApi");
            Private___0_tempNum_Int32 = new AstroUdonVariable<int>(GameManager, "__0_tempNum_Int32");
            Private___57_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__57_intnl_SystemBoolean");
            Private___33_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__33_intnl_SystemInt32");
            Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__10_intnl_SystemInt32");
            Private_gameStateCheckTimer = new AstroUdonVariable<float>(GameManager, "gameStateCheckTimer");
            Private___126_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__126_intnl_SystemBoolean");
            Private___1_intnl_NL_WorkshopManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_intnl_NL_WorkshopManager");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(GameManager, "__0_const_intnl_SystemUInt32");
            Private_inGameTime = new AstroUdonVariable<int>(GameManager, "inGameTime");
            Private___6_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__6_intnl_SystemInt64");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__9_intnl_SystemBoolean");
            Private___19_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__19_intnl_SystemObject");
            Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__13_intnl_SystemInt32");
            Private___2_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__2_intnl_SystemInt16");
            Private___8_character_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__8_character_NL_PlayerCharacter");
            Private___45_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__45_const_intnl_SystemString");
            Private___63_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__63_intnl_SystemBoolean");
            Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__36_intnl_SystemBoolean");
            Private___88_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__88_const_intnl_SystemString");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__0_intnl_SystemSingle");
            Private___108_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__108_intnl_SystemBoolean");
            Private___12_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__12_intnl_SystemString");
            Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__40_intnl_SystemBoolean");
            Private___120_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__120_intnl_SystemBoolean");
            Private___8_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__8_intnl_SystemObject");
            Private___94_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__94_intnl_SystemBoolean");
            Private___0_this_intnl_NLI_GameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_this_intnl_NLI_GameManager");
            Private_audioSource_InGame = new AstroUdonVariable<UnityEngine.AudioSource>(GameManager, "audioSource_InGame");
            Private___15_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__15_intnl_SystemObject");
            Private___25_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__25_intnl_SystemInt32");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__18_const_intnl_SystemString");
            Private___109_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__109_intnl_SystemBoolean");
            Private___40_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__40_intnl_SystemInt32");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__13_intnl_SystemSingle");
            Private___66_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__66_intnl_SystemBoolean");
            Private___121_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__121_intnl_SystemBoolean");
            Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__22_intnl_SystemInt32");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__4_intnl_SystemInt32");
            Private_maxAmmo = new AstroUdonVariable<int>(GameManager, "maxAmmo");
            Private___89_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__89_const_intnl_SystemString");
            Private___68_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__68_const_intnl_SystemString");
            Private___18_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__18_intnl_SystemInt16");
            Private___43_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__43_intnl_SystemInt32");
            Private___9_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__9_intnl_SystemInt16");
            Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameManager, "__3_intnl_UnityEngineVector3");
            Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__47_intnl_SystemBoolean");
            Private_humanRunningSpeed = new AstroUdonVariable<float>(GameManager, "humanRunningSpeed");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__4_intnl_SystemString");
            Private___134_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__134_intnl_SystemBoolean");
            Private___47_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__47_const_intnl_SystemString");
            Private___133_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__133_intnl_SystemBoolean");
            Private___58_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__58_intnl_SystemInt32");
            Private___4_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "__4_intnl_UnityEngineTransform");
            Private___2_intnl_NL_WorkshopManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__2_intnl_NL_WorkshopManager");
            Private___30_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__30_intnl_VRCSDKBaseVRCPlayerApi");
            Private___9_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__9_intnl_VRCSDKBaseVRCPlayerApi");
            Private___0_playerName_String = new AstroUdonVariable<string>(GameManager, "__0_playerName_String");
            Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__19_const_intnl_SystemString");
            Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__17_const_intnl_exitJumpLoc_UInt32");
            Private___20_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__20_intnl_SystemInt16");
            Private___116_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__116_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__0_const_intnl_SystemInt16");
            Private___135_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__135_intnl_SystemBoolean");
            Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__39_intnl_SystemBoolean");
            Private___6_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__6_intnl_SystemInt16");
            Private___69_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__69_const_intnl_SystemString");
            Private___60_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__60_intnl_SystemInt32");
            Private___23_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__23_intnl_SystemInt16");
            Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__28_intnl_SystemBoolean");
            Private___36_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__36_intnl_SystemInt32");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__6_intnl_SystemBoolean");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__4_intnl_SystemSingle");
            Private___2_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__2_const_intnl_SystemInt64");
            Private___11_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__11_intnl_SystemString");
            Private___63_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__63_intnl_SystemInt32");
            Private___84_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__84_intnl_SystemBoolean");
            Private___110_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__110_intnl_SystemBoolean");
            Private_isHero = new AstroUdonVariable<bool>(GameManager, "isHero");
            Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__24_const_intnl_SystemString");
            Private___0_gunInHand_NL_Gun = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_gunInHand_NL_Gun");
            Private___54_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__54_const_intnl_SystemString");
            Private_isPlayerInVR = new AstroUdonVariable<bool>(GameManager, "isPlayerInVR");
            Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__16_intnl_SystemInt32");
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__0_intnl_VRCSDKBaseVRCPlayerApi");
            Private___69_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__69_intnl_SystemBoolean");
            Private___4_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__4_intnl_VRCSDKBaseVRCPlayerApi");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__12_intnl_SystemSingle");
            Private___38_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__38_const_intnl_SystemString");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__14_intnl_SystemBoolean");
            Private___111_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__111_intnl_SystemBoolean");
            Private_gameStateCheckTime = new AstroUdonVariable<float>(GameManager, "gameStateCheckTime");
            Private_infestRewards = new AstroUdonVariable<int>(GameManager, "infestRewards");
            Private___0_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__0_intnl_SystemInt64");
            Private___0_mp_targetID_Int32 = new AstroUdonVariable<int>(GameManager, "__0_mp_targetID_Int32");
            Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(GameManager, "__1_intnl_returnValSymbol_Boolean");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__3_intnl_SystemInt32");
            Private___31_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__31_intnl_SystemInt16");
            Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__31_intnl_SystemBoolean");
            Private___0_intnl_NLI_PlayerSlotUI = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_NLI_PlayerSlotUI");
            Private___55_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__55_intnl_SystemBoolean");
            Private___25_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__25_const_intnl_SystemString");
            Private___55_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__55_const_intnl_SystemString");
            Private_latencyProtection = new AstroUdonVariable<int>(GameManager, "latencyProtection");
            Private_ammoSpawnTimer = new AstroUdonVariable<float>(GameManager, "ammoSpawnTimer");
            Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__11_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__8_intnl_SystemBoolean");
            Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__20_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameManager, "__2_intnl_UnityEngineVector3");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__3_intnl_SystemString");
            Private___98_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__98_const_intnl_SystemString");
            Private___54_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__54_intnl_SystemInt32");
            Private___39_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__39_const_intnl_SystemString");
            Private___74_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__74_intnl_SystemBoolean");
            Private___11_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__11_intnl_SystemInt16");
            Private___1_intnl_SystemObject = new AstroUdonVariable<long>(GameManager, "__1_intnl_SystemObject");
            Private___122_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__122_intnl_SystemBoolean");
            Private___25_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__25_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__46_intnl_SystemInt32");
            Private___33_intnl_SystemObject = new AstroUdonVariable<string>(GameManager, "__33_intnl_SystemObject");
            Private___1_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_intnl_NL_PlayerCharacter");
            Private___10_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__10_intnl_SystemInt64");
            Private___61_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__61_intnl_SystemBoolean");
            Private___98_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__98_intnl_SystemBoolean");
            Private___0_returnValue_Boolean = new AstroUdonVariable<bool>(GameManager, "__0_returnValue_Boolean");
            Private___51_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__51_intnl_SystemInt32");
            Private_killEventDelay = new AstroUdonVariable<float>(GameManager, "killEventDelay");
            Private___57_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__57_intnl_SystemInt32");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameManager, "__1_intnl_UnityEngineVector3");
            Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__53_intnl_SystemBoolean");
            Private___80_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__80_const_intnl_SystemString");
            Private___3_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__3_const_intnl_SystemInt64");
            Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__27_intnl_SystemBoolean");
            Private___0_mp_hitCharacter_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_mp_hitCharacter_NL_PlayerCharacter");
            Private___99_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__99_const_intnl_SystemString");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__3_intnl_SystemSingle");
            Private_updateManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "updateManager");
            Private___0_mp_playerIndex_Int32 = new AstroUdonVariable<int>(GameManager, "__0_mp_playerIndex_Int32");
            Private_lobbySpawnPoints = new AstroUdonVariable<UnityEngine.Transform[]>(GameManager, "lobbySpawnPoints");
            Private___74_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__74_const_intnl_SystemString");
            Private___3_intnl_VRCSDK3ComponentsVRCPickup = new AstroUdonVariable<VRC.SDK3.Components.VRCPickup>(GameManager, "__3_intnl_VRCSDK3ComponentsVRCPickup");
            Private___136_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__136_intnl_SystemBoolean");
            Private___0_mp_zValue_Single = new AstroUdonVariable<float>(GameManager, "__0_mp_zValue_Single");
            Private___27_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__27_const_intnl_SystemString");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameManager, "__0_intnl_UnityEngineVector3");
            Private___57_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__57_const_intnl_SystemString");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__10_const_intnl_SystemString");
            Private___31_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__31_intnl_VRCSDKBaseVRCPlayerApi");
            Private___34_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__34_intnl_SystemInt16");
            Private___0_playerSlotUI_NLI_PlayerSlotUI = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_playerSlotUI_NLI_PlayerSlotUI");
            Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__32_intnl_SystemBoolean");
            Private___4_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__4_intnl_UnityEngineComponent");
            Private___56_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__56_intnl_SystemBoolean");
            Private_maxMoney = new AstroUdonVariable<int>(GameManager, "maxMoney");
            Private___42_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__42_const_intnl_SystemString");
            Private___66_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__66_intnl_SystemInt32");
            Private_roomSpectateObj = new AstroUdonVariable<UnityEngine.GameObject>(GameManager, "roomSpectateObj");
            Private___32_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__32_intnl_VRCSDKBaseVRCPlayerApi");
            Private_allCharacters = new AstroUdonVariable<UnityEngine.Component[]>(GameManager, "allCharacters");
            Private___4_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__4_intnl_SystemInt64");
            Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__45_intnl_SystemBoolean");
            Private___81_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__81_const_intnl_SystemString");
            Private___60_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__60_const_intnl_SystemString");
            Private___28_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__28_intnl_SystemInt32");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__7_intnl_SystemInt32");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "__0_intnl_UnityEngineTransform");
            Private___86_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__86_const_intnl_SystemString");
            Private___14_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__14_intnl_SystemInt16");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__1_const_intnl_SystemBoolean");
            Private___2_intnl_NL_Gun = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__2_intnl_NL_Gun");
            Private___0_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__0_intnl_SystemInt16");
            Private___90_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__90_intnl_SystemBoolean");
            Private_nameBoard = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "nameBoard");
            Private___0_mp_delay_Single = new AstroUdonVariable<float>(GameManager, "__0_mp_delay_Single");
            Private___75_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__75_const_intnl_SystemString");
            Private___130_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__130_intnl_SystemBoolean");
            Private_currency = new AstroUdonVariable<int>(GameManager, "currency");
            Private___33_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__33_intnl_VRCSDKBaseVRCPlayerApi");
            Private___62_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__62_intnl_SystemBoolean");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__11_const_intnl_SystemString");
            Private___17_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__17_intnl_SystemInt16");
            Private___1_intnl_VRCSDK3ComponentsVRCPickup = new AstroUdonVariable<VRC.SDK3.Components.VRCPickup>(GameManager, "__1_intnl_VRCSDK3ComponentsVRCPickup");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__16_const_intnl_SystemString");
            Private___5_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__5_intnl_SystemObject");
            Private___112_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__112_intnl_SystemBoolean");
            Private___88_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__88_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__0_const_intnl_SystemInt64");
            Private___131_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__131_intnl_SystemBoolean");
            Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__43_intnl_SystemBoolean");
            Private___61_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__61_const_intnl_SystemString");
            Private___66_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__66_const_intnl_SystemString");
            Private___10_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameManager, "__10_intnl_VRCSDKBaseVRCPlayerApi");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__18_intnl_SystemBoolean");
            Private___97_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__97_intnl_SystemBoolean");
            Private_ammoReserve = new AstroUdonVariable<int>(GameManager, "ammoReserve");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__10_intnl_SystemSingle");
            Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__14_const_intnl_exitJumpLoc_UInt32");
            Private_teleportCheckTime = new AstroUdonVariable<float>(GameManager, "teleportCheckTime");
            Private___1_resultCharacter_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_resultCharacter_NL_PlayerCharacter");
            Private___83_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__83_const_intnl_SystemString");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__3_const_intnl_SystemInt32");
            Private___0_index_Int32 = new AstroUdonVariable<int>(GameManager, "__0_index_Int32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__7_intnl_SystemSingle");
            Private___37_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__37_intnl_SystemObject");
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(GameManager, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
            Private___26_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__26_intnl_SystemInt16");
            Private___59_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__59_intnl_SystemBoolean");
            Private___2_intnl_returnValSymbol_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__2_intnl_returnValSymbol_NL_PlayerCharacter");
            Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__18_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__46_intnl_SystemBoolean");
            Private___39_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__39_intnl_SystemInt32");
            Private___77_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__77_const_intnl_SystemString");
            Private___30_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__30_const_intnl_SystemString");
            Private_initialAmmoSpawnRate = new AstroUdonVariable<float>(GameManager, "initialAmmoSpawnRate");
            Private_worldOrigin = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "worldOrigin");
            Private___38_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__38_intnl_SystemObject");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__13_const_intnl_SystemString");
            Private___78_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__78_intnl_SystemBoolean");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__8_intnl_SystemInt32");
            Private___80_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__80_intnl_SystemBoolean");
            Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__19_intnl_SystemInt32");
            Private___4_intnl_SystemInt16 = new AstroUdonVariable<short>(GameManager, "__4_intnl_SystemInt16");
            Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__24_intnl_SystemInt32");
            Private___63_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__63_const_intnl_SystemString");
            Private___8_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__8_intnl_SystemString");
            Private___3_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__3_intnl_SystemInt64");
            Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__13_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(GameManager, "__3_intnl_UnityEngineTransform");
            Private___1_intnl_NL_Gun = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__1_intnl_NL_Gun");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__10_intnl_SystemBoolean");
            Private_forceInfestedTeleport = new AstroUdonVariable<bool>(GameManager, "forceInfestedTeleport");
            Private___34_intnl_SystemObject = new AstroUdonVariable<short>(GameManager, "__34_intnl_SystemObject");
            Private___90_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__90_const_intnl_SystemString");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__2_const_intnl_SystemString");
            Private___31_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__31_const_intnl_SystemString");
            Private___31_intnl_SystemObject = new AstroUdonVariable<bool>(GameManager, "__31_intnl_SystemObject");
            Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__21_intnl_SystemInt32");
            Private___27_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__27_intnl_SystemInt32");
            Private___36_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__36_const_intnl_SystemString");
            Private___1_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameManager, "__1_const_intnl_SystemInt64");
            Private___2_const_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__2_const_intnl_SystemSingle");
            Private___128_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__128_intnl_SystemBoolean");
            Private_keyCount = new AstroUdonVariable<int>(GameManager, "keyCount");
            Private___87_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__87_intnl_SystemBoolean");
            Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__51_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__0_const_intnl_SystemInt32");
            Private___107_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__107_intnl_SystemBoolean");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameManager, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___0_const_intnl_VRCSDKBaseVRC_PickupPickupHand = new AstroUdonVariable<VRC.SDKBase.VRC_Pickup.PickupHand>(GameManager, "__0_const_intnl_VRCSDKBaseVRC_PickupPickupHand");
            Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__25_intnl_SystemBoolean");
            Private_infestedPlayerCount = new AstroUdonVariable<int>(GameManager, "infestedPlayerCount");
            Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__22_const_intnl_SystemString");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(GameManager, "__8_intnl_SystemSingle");
            Private___52_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__52_const_intnl_SystemString");
            Private___70_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__70_intnl_SystemBoolean");
            Private___129_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__129_intnl_SystemBoolean");
            Private___49_intnl_SystemInt32 = new AstroUdonVariable<int>(GameManager, "__49_intnl_SystemInt32");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__17_intnl_SystemBoolean");
            Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__49_intnl_SystemBoolean");
            Private___91_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__91_const_intnl_SystemString");
            Private___96_const_intnl_SystemString = new AstroUdonVariable<string>(GameManager, "__96_const_intnl_SystemString");
            Private___0_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameManager, "__0_intnl_UnityEngineComponent");
            Private___132_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameManager, "__132_intnl_SystemBoolean");
        }
        private void Cleanup_GameManager()
        {
            Private___35_intnl_SystemInt32 = null;
            Private___0_intnl_NL_PlayerCharacter = null;
            Private___33_const_intnl_SystemString = null;
            Private_allWorkshopManagers = null;
            Private___23_intnl_SystemBoolean = null;
            Private___32_intnl_SystemInt32 = null;
            Private___77_intnl_SystemBoolean = null;
            Private___1_const_intnl_VRCSDKBaseVRC_PickupPickupHand = null;
            Private___29_intnl_SystemInt16 = null;
            Private___48_const_intnl_SystemString = null;
            Private___7_intnl_SystemInt64 = null;
            Private___15_intnl_SystemInt32 = null;
            Private___21_const_intnl_exitJumpLoc_UInt32 = null;
            Private___3_intnl_SystemInt16 = null;
            Private___12_intnl_SystemInt32 = null;
            Private___52_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemString = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___12_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___93_const_intnl_SystemString = null;
            Private___26_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineQuaternion = null;
            Private___41_intnl_SystemBoolean = null;
            Private___30_intnl_SystemInt16 = null;
            Private_humanJumpHeight = null;
            Private___3_const_intnl_SystemSingle = null;
            Private___118_intnl_SystemBoolean = null;
            Private_identityRevealTime = null;
            Private___0_intnl_NL_WorkshopManagerArray = null;
            Private___0_intnl_NL_PlayerCharacterArray = null;
            Private___95_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___13_intnl_NL_PlayerCharacter = null;
            Private___49_const_intnl_SystemString = null;
            Private___13_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___1_intnl_SystemInt32 = null;
            Private___33_intnl_SystemInt16 = null;
            Private___10_intnl_SystemInt16 = null;
            Private___16_const_intnl_exitJumpLoc_UInt32 = null;
            Private___72_const_intnl_SystemString = null;
            Private___119_intnl_SystemBoolean = null;
            Private___35_intnl_SystemObject = null;
            Private___2_intnl_SystemObject = null;
            Private___45_intnl_SystemInt32 = null;
            Private___1_intnl_SystemString = null;
            Private___50_intnl_SystemInt32 = null;
            Private___1_i_Int32 = null;
            Private___0_i_Int32 = null;
            Private___13_intnl_SystemInt16 = null;
            Private___42_intnl_SystemInt32 = null;
            Private_spectateCharacters = null;
            Private___2_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___6_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___3_intnl_UnityEngineComponent = null;
            Private___93_intnl_SystemBoolean = null;
            Private___53_intnl_SystemInt32 = null;
            Private___4_const_intnl_SystemInt64 = null;
            Private___8_intnl_SystemInt64 = null;
            Private___0_const_intnl_SystemString = null;
            Private_ammoSpawnDelay = null;
            Private___1_workshop_NL_WorkshopManager = null;
            Private_weaponManager = null;
            Private___12_intnl_NL_PlayerCharacter = null;
            Private___42_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemSingle = null;
            Private___29_intnl_SystemBoolean = null;
            Private___1_intnl_SystemSingle = null;
            Private___7_intnl_SystemInt16 = null;
            Private_killRewards = null;
            Private___22_intnl_SystemInt16 = null;
            Private___96_intnl_SystemBoolean = null;
            Private___34_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___9_intnl_SystemObject = null;
            Private___0_this_intnl_UnityEngineTransform = null;
            Private___5_intnl_SystemBoolean = null;
            Private___65_intnl_SystemInt32 = null;
            Private___85_intnl_SystemBoolean = null;
            Private_playerIndex = null;
            Private___62_intnl_SystemInt32 = null;
            Private___0_spawnPoint_Transform = null;
            Private___1_itemInHand_VRC_Pickup = null;
            Private___10_const_intnl_exitJumpLoc_UInt32 = null;
            Private___104_intnl_SystemBoolean = null;
            Private___2_intnl_returnValSymbol_Boolean = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___103_intnl_SystemBoolean = null;
            Private___1_gunInHand_NL_Gun = null;
            Private___15_intnl_SystemBoolean = null;
            Private_humanPlayerCount = null;
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___5_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private_initialMoney = null;
            Private___24_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_mp_delta_Int32 = null;
            Private___6_intnl_SystemObject = null;
            Private___5_intnl_SystemString = null;
            Private___105_intnl_SystemBoolean = null;
            Private___34_intnl_SystemBoolean = null;
            Private___28_const_intnl_SystemString = null;
            Private___2_intnl_UnityEngineTransform = null;
            Private_cameraSpectate = null;
            Private___1_character_NL_PlayerCharacter = null;
            Private___58_const_intnl_SystemString = null;
            Private___83_intnl_SystemBoolean = null;
            Private_initialAmmo = null;
            Private___6_const_intnl_SystemString = null;
            Private___21_intnl_SystemBoolean = null;
            Private___138_intnl_SystemBoolean = null;
            Private___75_intnl_SystemBoolean = null;
            Private___5_const_intnl_exitJumpLoc_UInt32 = null;
            Private___3_intnl_returnValSymbol_NL_PlayerCharacter = null;
            Private___13_intnl_SystemBoolean = null;
            Private_isJoinedGame = null;
            Private___1_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private___1_intnl_UnityEngineComponent = null;
            Private___64_intnl_SystemBoolean = null;
            Private___40_const_intnl_SystemString = null;
            Private___8_intnl_SystemInt16 = null;
            Private___139_intnl_SystemBoolean = null;
            Private___99_intnl_SystemBoolean = null;
            Private___38_intnl_SystemInt32 = null;
            Private___0_mp_damageTake_Int32 = null;
            Private___25_intnl_SystemInt16 = null;
            Private___86_intnl_SystemBoolean = null;
            Private___29_const_intnl_SystemString = null;
            Private___1_const_intnl_SystemSingle = null;
            Private___23_const_intnl_exitJumpLoc_UInt32 = null;
            Private___59_const_intnl_SystemString = null;
            Private___0_resultCharacter_NL_PlayerCharacter = null;
            Private___5_intnl_SystemSingle = null;
            Private___84_const_intnl_SystemString = null;
            Private___56_intnl_SystemInt32 = null;
            Private___5_character_NL_PlayerCharacter = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___18_intnl_SystemInt32 = null;
            Private___16_intnl_SystemBoolean = null;
            Private___73_intnl_SystemBoolean = null;
            Private___14_const_intnl_SystemString = null;
            Private___41_const_intnl_SystemString = null;
            Private___46_const_intnl_SystemString = null;
            Private___7_intnl_SystemBoolean = null;
            Private___20_intnl_SystemInt32 = null;
            Private___1_intnl_SystemInt64 = null;
            Private___85_const_intnl_SystemString = null;
            Private___64_const_intnl_SystemString = null;
            Private___9_character_NL_PlayerCharacter = null;
            Private___1_intnl_NL_UpdateManager = null;
            Private___22_intnl_SystemBoolean = null;
            Private___20_intnl_SystemObject = null;
            Private___1_intnl_NLI_PlayerSlotUI = null;
            Private___0_intnl_UnityEngineComponentArray = null;
            Private___7_const_intnl_exitJumpLoc_UInt32 = null;
            Private___76_intnl_SystemBoolean = null;
            Private_effectManager = null;
            Private___78_const_intnl_SystemString = null;
            Private___23_intnl_SystemInt32 = null;
            Private_killEventTimer = null;
            Private___91_intnl_SystemBoolean = null;
            Private___36_intnl_SystemObject = null;
            Private___7_const_intnl_SystemString = null;
            Private___15_const_intnl_SystemString = null;
            Private___35_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___1_tempNum_Int32 = null;
            Private___0_const_intnl_NL_WorkshopManagerArray = null;
            Private_teleportCheckTimer = null;
            Private___48_intnl_SystemInt32 = null;
            Private_isInfested = null;
            Private___2_intnl_UnityEngineComponentArray = null;
            Private___89_intnl_SystemBoolean = null;
            Private___36_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___16_intnl_SystemInt16 = null;
            Private___8_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___65_const_intnl_SystemString = null;
            Private___4_intnl_SystemBoolean = null;
            Private___11_intnl_SystemSingle = null;
            Private___0_intnl_NL_Gun = null;
            Private___106_intnl_SystemBoolean = null;
            Private___43_const_intnl_SystemString = null;
            Private___34_intnl_SystemInt32 = null;
            Private___79_const_intnl_SystemString = null;
            Private___19_intnl_SystemBoolean = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___37_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___9_intnl_NL_PlayerCharacter = null;
            Private___127_intnl_SystemBoolean = null;
            Private_hasEnterHeroMode = null;
            Private___87_const_intnl_SystemString = null;
            Private_mapLayoutSet = null;
            Private___0_intnl_SystemObject = null;
            Private___1_intnl_SystemBoolean = null;
            Private_audioSource_Lobby = null;
            Private___28_intnl_SystemInt16 = null;
            Private___38_intnl_SystemBoolean = null;
            Private___31_intnl_SystemInt32 = null;
            Private___37_intnl_SystemInt32 = null;
            Private___14_intnl_SystemInt32 = null;
            Private___2_intnl_NL_PlayerCharacter = null;
            Private___2_intnl_UnityEngineComponent = null;
            Private___12_const_intnl_exitJumpLoc_UInt32 = null;
            Private_gameOverTime = null;
            Private___34_const_intnl_SystemString = null;
            Private___27_intnl_SystemObject = null;
            Private___17_const_intnl_SystemString = null;
            Private___22_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___68_intnl_SystemInt32 = null;
            Private___100_intnl_SystemBoolean = null;
            Private___14_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___11_intnl_SystemInt32 = null;
            Private___79_intnl_SystemBoolean = null;
            Private___92_intnl_SystemBoolean = null;
            Private___17_intnl_SystemInt32 = null;
            Private___5_intnl_SystemInt64 = null;
            Private___26_const_intnl_exitJumpLoc_UInt32 = null;
            Private___4_const_intnl_SystemString = null;
            Private___28_intnl_SystemObject = null;
            Private___81_intnl_SystemBoolean = null;
            Private___1_intnl_SystemInt16 = null;
            Private_infestedRunningSpeed = null;
            Private___10_intnl_SystemString = null;
            Private___0_mp_playerID_Int32 = null;
            Private___68_intnl_SystemBoolean = null;
            Private___67_const_intnl_SystemString = null;
            Private___20_const_intnl_SystemString = null;
            Private___50_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemSingle = null;
            Private___101_intnl_SystemBoolean = null;
            Private___94_const_intnl_SystemString = null;
            Private_killedPlayerList = null;
            Private_allPlayerSlots = null;
            Private_initialMoneySpawnRate = null;
            Private___35_const_intnl_SystemString = null;
            Private___11_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___44_intnl_SystemInt32 = null;
            Private___30_intnl_SystemBoolean = null;
            Private___21_intnl_SystemObject = null;
            Private___26_intnl_SystemInt32 = null;
            Private___54_intnl_SystemBoolean = null;
            Private___2_intnl_SystemString = null;
            Private___21_const_intnl_SystemString = null;
            Private___13_intnl_SystemObject = null;
            Private___51_const_intnl_SystemString = null;
            Private___41_intnl_SystemInt32 = null;
            Private___47_intnl_SystemInt32 = null;
            Private___26_const_intnl_SystemString = null;
            Private___56_const_intnl_SystemString = null;
            Private___71_intnl_SystemBoolean = null;
            Private___117_intnl_SystemBoolean = null;
            Private___95_const_intnl_SystemString = null;
            Private___4_intnl_SystemObject = null;
            Private___1_mp_delta_Int32 = null;
            Private___19_intnl_SystemInt16 = null;
            Private___9_const_intnl_exitJumpLoc_UInt32 = null;
            Private___60_intnl_SystemBoolean = null;
            Private___29_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___37_intnl_SystemBoolean = null;
            Private___82_intnl_SystemBoolean = null;
            Private___20_const_intnl_exitJumpLoc_UInt32 = null;
            Private___9_intnl_SystemInt32 = null;
            Private___59_intnl_SystemInt32 = null;
            Private___37_const_intnl_SystemString = null;
            Private___6_intnl_UnityEngineVector3 = null;
            Private___2_intnl_SystemSingle = null;
            Private___3_intnl_UnityEngineComponentArray = null;
            Private___0_workshop_NL_WorkshopManager = null;
            Private___64_intnl_SystemInt32 = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___21_intnl_SystemInt16 = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___5_intnl_SystemInt16 = null;
            Private___12_intnl_SystemBoolean = null;
            Private___10_intnl_SystemObject = null;
            Private___6_const_intnl_exitJumpLoc_UInt32 = null;
            Private___70_const_intnl_SystemString = null;
            Private___61_intnl_SystemInt32 = null;
            Private_weaponSkinManager = null;
            Private___67_intnl_SystemInt32 = null;
            Private___67_intnl_SystemBoolean = null;
            Private___23_const_intnl_SystemString = null;
            Private___53_const_intnl_SystemString = null;
            Private___0_intnl_NL_UpdateManager = null;
            Private___5_intnl_UnityEngineVector3 = null;
            Private_inGameZValue = null;
            Private___6_intnl_SystemInt32 = null;
            Private___97_const_intnl_SystemString = null;
            Private___44_intnl_SystemBoolean = null;
            Private___0_mp_delta_Int32 = null;
            Private___29_intnl_SystemObject = null;
            Private___82_const_intnl_SystemString = null;
            Private___72_intnl_SystemBoolean = null;
            Private___6_intnl_SystemString = null;
            Private___0_intnl_SystemBoolean = null;
            Private___4_intnl_UnityEngineVector3 = null;
            Private___9_intnl_SystemSingle = null;
            Private___102_intnl_SystemBoolean = null;
            Private___15_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___71_const_intnl_SystemString = null;
            Private___3_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___7_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private_playerHUD = null;
            Private___76_const_intnl_SystemString = null;
            Private___124_intnl_SystemBoolean = null;
            Private___12_const_intnl_SystemString = null;
            Private___16_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___123_intnl_SystemBoolean = null;
            Private___32_intnl_SystemInt16 = null;
            Private___24_intnl_SystemInt16 = null;
            Private___3_intnl_SystemObject = null;
            Private___125_intnl_SystemBoolean = null;
            Private___62_const_intnl_SystemString = null;
            Private___8_const_intnl_SystemString = null;
            Private___12_intnl_SystemInt16 = null;
            Private___6_intnl_SystemSingle = null;
            Private___27_intnl_SystemInt16 = null;
            Private___55_intnl_SystemInt32 = null;
            Private___3_intnl_NL_PlayerCharacter = null;
            Private___0_intnl_UnityEngineQuaternion = null;
            Private___52_intnl_SystemInt32 = null;
            Private___58_intnl_SystemBoolean = null;
            Private___11_intnl_SystemInt64 = null;
            Private___137_intnl_SystemBoolean = null;
            Private___3_intnl_NL_Gun = null;
            Private___0_itemInHand_VRC_Pickup = null;
            Private___73_const_intnl_SystemString = null;
            Private___15_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_SystemInt64 = null;
            Private___14_intnl_SystemObject = null;
            Private_infestedJumpHeight = null;
            Private___19_const_intnl_exitJumpLoc_UInt32 = null;
            Private_lobbyManager = null;
            Private___1_intnl_UnityEngineComponentArray = null;
            Private___35_intnl_SystemInt16 = null;
            Private___0_character_NL_PlayerCharacter = null;
            Private___22_intnl_SystemObject = null;
            Private___114_intnl_SystemBoolean = null;
            Private___100_const_intnl_SystemString = null;
            Private___0_intnl_NL_WorkshopManager = null;
            Private___0_intnl_NLI_LobbyManager = null;
            Private___32_const_intnl_SystemString = null;
            Private___113_intnl_SystemBoolean = null;
            Private___29_intnl_SystemInt32 = null;
            Private___35_intnl_SystemBoolean = null;
            Private_hasRevealIdentity = null;
            Private___15_intnl_SystemInt16 = null;
            Private___8_const_intnl_exitJumpLoc_UInt32 = null;
            Private___50_intnl_SystemBoolean = null;
            Private___7_intnl_SystemObject = null;
            Private___22_const_intnl_exitJumpLoc_UInt32 = null;
            Private___115_intnl_SystemBoolean = null;
            Private___24_intnl_SystemBoolean = null;
            Private___9_const_intnl_SystemString = null;
            Private___0_intnl_NL_SpectateCharacter = null;
            Private___0_intnl_SystemInt32 = null;
            Private___9_intnl_SystemInt64 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___48_intnl_SystemBoolean = null;
            Private___30_intnl_SystemInt32 = null;
            Private___44_const_intnl_SystemString = null;
            Private___65_intnl_SystemBoolean = null;
            Private___92_const_intnl_SystemString = null;
            Private___0_lastHuman_NL_PlayerCharacter = null;
            Private___0_intnl_SystemString = null;
            Private___33_intnl_SystemBoolean = null;
            Private___24_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___0_tempNum_Int32 = null;
            Private___57_intnl_SystemBoolean = null;
            Private___33_intnl_SystemInt32 = null;
            Private___10_intnl_SystemInt32 = null;
            Private_gameStateCheckTimer = null;
            Private___126_intnl_SystemBoolean = null;
            Private___1_intnl_NL_WorkshopManager = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private_inGameTime = null;
            Private___6_intnl_SystemInt64 = null;
            Private___9_intnl_SystemBoolean = null;
            Private___19_intnl_SystemObject = null;
            Private___13_intnl_SystemInt32 = null;
            Private___2_intnl_SystemInt16 = null;
            Private___8_character_NL_PlayerCharacter = null;
            Private___45_const_intnl_SystemString = null;
            Private___63_intnl_SystemBoolean = null;
            Private___36_intnl_SystemBoolean = null;
            Private___88_const_intnl_SystemString = null;
            Private___0_intnl_SystemSingle = null;
            Private___108_intnl_SystemBoolean = null;
            Private___12_intnl_SystemString = null;
            Private___40_intnl_SystemBoolean = null;
            Private___120_intnl_SystemBoolean = null;
            Private___8_intnl_SystemObject = null;
            Private___94_intnl_SystemBoolean = null;
            Private___0_this_intnl_NLI_GameManager = null;
            Private_audioSource_InGame = null;
            Private___15_intnl_SystemObject = null;
            Private___25_intnl_SystemInt32 = null;
            Private___18_const_intnl_SystemString = null;
            Private___109_intnl_SystemBoolean = null;
            Private___40_intnl_SystemInt32 = null;
            Private___13_intnl_SystemSingle = null;
            Private___66_intnl_SystemBoolean = null;
            Private___121_intnl_SystemBoolean = null;
            Private___22_intnl_SystemInt32 = null;
            Private___4_intnl_SystemInt32 = null;
            Private_maxAmmo = null;
            Private___89_const_intnl_SystemString = null;
            Private___68_const_intnl_SystemString = null;
            Private___18_intnl_SystemInt16 = null;
            Private___43_intnl_SystemInt32 = null;
            Private___9_intnl_SystemInt16 = null;
            Private___3_intnl_UnityEngineVector3 = null;
            Private___47_intnl_SystemBoolean = null;
            Private_humanRunningSpeed = null;
            Private___4_intnl_SystemString = null;
            Private___134_intnl_SystemBoolean = null;
            Private___47_const_intnl_SystemString = null;
            Private___133_intnl_SystemBoolean = null;
            Private___58_intnl_SystemInt32 = null;
            Private___4_intnl_UnityEngineTransform = null;
            Private___2_intnl_NL_WorkshopManager = null;
            Private___30_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___9_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___0_playerName_String = null;
            Private___19_const_intnl_SystemString = null;
            Private___17_const_intnl_exitJumpLoc_UInt32 = null;
            Private___20_intnl_SystemInt16 = null;
            Private___116_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt16 = null;
            Private___135_intnl_SystemBoolean = null;
            Private___39_intnl_SystemBoolean = null;
            Private___6_intnl_SystemInt16 = null;
            Private___69_const_intnl_SystemString = null;
            Private___60_intnl_SystemInt32 = null;
            Private___23_intnl_SystemInt16 = null;
            Private___28_intnl_SystemBoolean = null;
            Private___36_intnl_SystemInt32 = null;
            Private___6_intnl_SystemBoolean = null;
            Private___4_intnl_SystemSingle = null;
            Private___2_const_intnl_SystemInt64 = null;
            Private___11_intnl_SystemString = null;
            Private___63_intnl_SystemInt32 = null;
            Private___84_intnl_SystemBoolean = null;
            Private___110_intnl_SystemBoolean = null;
            Private_isHero = null;
            Private___24_const_intnl_SystemString = null;
            Private___0_gunInHand_NL_Gun = null;
            Private___54_const_intnl_SystemString = null;
            Private_isPlayerInVR = null;
            Private___16_intnl_SystemInt32 = null;
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___69_intnl_SystemBoolean = null;
            Private___4_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___12_intnl_SystemSingle = null;
            Private___38_const_intnl_SystemString = null;
            Private___14_intnl_SystemBoolean = null;
            Private___111_intnl_SystemBoolean = null;
            Private_gameStateCheckTime = null;
            Private_infestRewards = null;
            Private___0_intnl_SystemInt64 = null;
            Private___0_mp_targetID_Int32 = null;
            Private___1_intnl_returnValSymbol_Boolean = null;
            Private___3_intnl_SystemInt32 = null;
            Private___31_intnl_SystemInt16 = null;
            Private___31_intnl_SystemBoolean = null;
            Private___0_intnl_NLI_PlayerSlotUI = null;
            Private___55_intnl_SystemBoolean = null;
            Private___25_const_intnl_SystemString = null;
            Private___55_const_intnl_SystemString = null;
            Private_latencyProtection = null;
            Private_ammoSpawnTimer = null;
            Private___11_const_intnl_exitJumpLoc_UInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___20_intnl_SystemBoolean = null;
            Private___2_intnl_UnityEngineVector3 = null;
            Private___3_intnl_SystemString = null;
            Private___98_const_intnl_SystemString = null;
            Private___54_intnl_SystemInt32 = null;
            Private___39_const_intnl_SystemString = null;
            Private___74_intnl_SystemBoolean = null;
            Private___11_intnl_SystemInt16 = null;
            Private___1_intnl_SystemObject = null;
            Private___122_intnl_SystemBoolean = null;
            Private___25_const_intnl_exitJumpLoc_UInt32 = null;
            Private___46_intnl_SystemInt32 = null;
            Private___33_intnl_SystemObject = null;
            Private___1_intnl_NL_PlayerCharacter = null;
            Private___10_intnl_SystemInt64 = null;
            Private___61_intnl_SystemBoolean = null;
            Private___98_intnl_SystemBoolean = null;
            Private___0_returnValue_Boolean = null;
            Private___51_intnl_SystemInt32 = null;
            Private_killEventDelay = null;
            Private___57_intnl_SystemInt32 = null;
            Private___1_intnl_UnityEngineVector3 = null;
            Private___53_intnl_SystemBoolean = null;
            Private___80_const_intnl_SystemString = null;
            Private___3_const_intnl_SystemInt64 = null;
            Private___27_intnl_SystemBoolean = null;
            Private___0_mp_hitCharacter_NL_PlayerCharacter = null;
            Private___99_const_intnl_SystemString = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private_updateManager = null;
            Private___0_mp_playerIndex_Int32 = null;
            Private_lobbySpawnPoints = null;
            Private___74_const_intnl_SystemString = null;
            Private___3_intnl_VRCSDK3ComponentsVRCPickup = null;
            Private___136_intnl_SystemBoolean = null;
            Private___0_mp_zValue_Single = null;
            Private___27_const_intnl_SystemString = null;
            Private___0_intnl_UnityEngineVector3 = null;
            Private___57_const_intnl_SystemString = null;
            Private___10_const_intnl_SystemString = null;
            Private___31_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___34_intnl_SystemInt16 = null;
            Private___0_playerSlotUI_NLI_PlayerSlotUI = null;
            Private___32_intnl_SystemBoolean = null;
            Private___4_intnl_UnityEngineComponent = null;
            Private___56_intnl_SystemBoolean = null;
            Private_maxMoney = null;
            Private___42_const_intnl_SystemString = null;
            Private___66_intnl_SystemInt32 = null;
            Private_roomSpectateObj = null;
            Private___32_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private_allCharacters = null;
            Private___4_intnl_SystemInt64 = null;
            Private___45_intnl_SystemBoolean = null;
            Private___81_const_intnl_SystemString = null;
            Private___60_const_intnl_SystemString = null;
            Private___28_intnl_SystemInt32 = null;
            Private___7_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineTransform = null;
            Private___86_const_intnl_SystemString = null;
            Private___14_intnl_SystemInt16 = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___2_intnl_NL_Gun = null;
            Private___0_intnl_SystemInt16 = null;
            Private___90_intnl_SystemBoolean = null;
            Private_nameBoard = null;
            Private___0_mp_delay_Single = null;
            Private___75_const_intnl_SystemString = null;
            Private___130_intnl_SystemBoolean = null;
            Private_currency = null;
            Private___33_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___62_intnl_SystemBoolean = null;
            Private___11_const_intnl_SystemString = null;
            Private___17_intnl_SystemInt16 = null;
            Private___1_intnl_VRCSDK3ComponentsVRCPickup = null;
            Private___16_const_intnl_SystemString = null;
            Private___5_intnl_SystemObject = null;
            Private___112_intnl_SystemBoolean = null;
            Private___88_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt64 = null;
            Private___131_intnl_SystemBoolean = null;
            Private___43_intnl_SystemBoolean = null;
            Private___61_const_intnl_SystemString = null;
            Private___66_const_intnl_SystemString = null;
            Private___10_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___18_intnl_SystemBoolean = null;
            Private___97_intnl_SystemBoolean = null;
            Private_ammoReserve = null;
            Private___2_intnl_SystemBoolean = null;
            Private___10_intnl_SystemSingle = null;
            Private___14_const_intnl_exitJumpLoc_UInt32 = null;
            Private_teleportCheckTime = null;
            Private___1_resultCharacter_NL_PlayerCharacter = null;
            Private___83_const_intnl_SystemString = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___0_index_Int32 = null;
            Private___7_intnl_SystemSingle = null;
            Private___37_intnl_SystemObject = null;
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = null;
            Private___26_intnl_SystemInt16 = null;
            Private___59_intnl_SystemBoolean = null;
            Private___2_intnl_returnValSymbol_NL_PlayerCharacter = null;
            Private___18_const_intnl_exitJumpLoc_UInt32 = null;
            Private___46_intnl_SystemBoolean = null;
            Private___39_intnl_SystemInt32 = null;
            Private___77_const_intnl_SystemString = null;
            Private___30_const_intnl_SystemString = null;
            Private_initialAmmoSpawnRate = null;
            Private_worldOrigin = null;
            Private___38_intnl_SystemObject = null;
            Private___13_const_intnl_SystemString = null;
            Private___78_intnl_SystemBoolean = null;
            Private___8_intnl_SystemInt32 = null;
            Private___80_intnl_SystemBoolean = null;
            Private___19_intnl_SystemInt32 = null;
            Private___4_intnl_SystemInt16 = null;
            Private___24_intnl_SystemInt32 = null;
            Private___63_const_intnl_SystemString = null;
            Private___8_intnl_SystemString = null;
            Private___3_intnl_SystemInt64 = null;
            Private___13_const_intnl_exitJumpLoc_UInt32 = null;
            Private___3_intnl_UnityEngineTransform = null;
            Private___1_intnl_NL_Gun = null;
            Private___10_intnl_SystemBoolean = null;
            Private_forceInfestedTeleport = null;
            Private___34_intnl_SystemObject = null;
            Private___90_const_intnl_SystemString = null;
            Private___2_const_intnl_SystemString = null;
            Private___31_const_intnl_SystemString = null;
            Private___31_intnl_SystemObject = null;
            Private___21_intnl_SystemInt32 = null;
            Private___27_intnl_SystemInt32 = null;
            Private___36_const_intnl_SystemString = null;
            Private___1_const_intnl_SystemInt64 = null;
            Private___2_const_intnl_SystemSingle = null;
            Private___128_intnl_SystemBoolean = null;
            Private_keyCount = null;
            Private___87_intnl_SystemBoolean = null;
            Private___51_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___107_intnl_SystemBoolean = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_const_intnl_VRCSDKBaseVRC_PickupPickupHand = null;
            Private___25_intnl_SystemBoolean = null;
            Private_infestedPlayerCount = null;
            Private___22_const_intnl_SystemString = null;
            Private___8_intnl_SystemSingle = null;
            Private___52_const_intnl_SystemString = null;
            Private___70_intnl_SystemBoolean = null;
            Private___129_intnl_SystemBoolean = null;
            Private___49_intnl_SystemInt32 = null;
            Private___17_intnl_SystemBoolean = null;
            Private___49_intnl_SystemBoolean = null;
            Private___91_const_intnl_SystemString = null;
            Private___96_const_intnl_SystemString = null;
            Private___0_intnl_UnityEngineComponent = null;
            Private___132_intnl_SystemBoolean = null;
        }

        #region Getter / Setters AstroUdonVariables  of GameManager

        internal int? __35_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_SystemInt32 != null)
                {
                    return Private___35_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_intnl_SystemInt32 != null)
                    {
                        Private___35_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_PlayerCharacter != null)
                {
                    return Private___0_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_PlayerCharacter != null)
                {
                    Private___0_intnl_NL_PlayerCharacter.Value = value;
                }
            }
        }

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

        internal UnityEngine.Component[] allWorkshopManagers
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_allWorkshopManagers != null)
                {
                    return Private_allWorkshopManagers.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_allWorkshopManagers != null)
                {
                    Private_allWorkshopManagers.Value = value;
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

        internal bool? __77_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___77_intnl_SystemBoolean != null)
                {
                    return Private___77_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___77_intnl_SystemBoolean != null)
                    {
                        Private___77_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRC_Pickup.PickupHand? __1_const_intnl_VRCSDKBaseVRC_PickupPickupHand
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_VRCSDKBaseVRC_PickupPickupHand != null)
                {
                    return Private___1_const_intnl_VRCSDKBaseVRC_PickupPickupHand.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_VRCSDKBaseVRC_PickupPickupHand != null)
                    {
                        Private___1_const_intnl_VRCSDKBaseVRC_PickupPickupHand.Value = value.Value;
                    }
                }
            }
        }

        internal short? __29_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_intnl_SystemInt16 != null)
                {
                    return Private___29_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___29_intnl_SystemInt16 != null)
                    {
                        Private___29_intnl_SystemInt16.Value = value.Value;
                    }
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

        internal long? __7_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemInt64 != null)
                {
                    return Private___7_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemInt64 != null)
                    {
                        Private___7_intnl_SystemInt64.Value = value.Value;
                    }
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

        internal short? __3_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemInt16 != null)
                {
                    return Private___3_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemInt16 != null)
                    {
                        Private___3_intnl_SystemInt16.Value = value.Value;
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

        internal bool? __52_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___52_intnl_SystemBoolean != null)
                {
                    return Private___52_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___52_intnl_SystemBoolean != null)
                    {
                        Private___52_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi __12_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___12_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___12_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___12_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal string __93_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___93_const_intnl_SystemString != null)
                {
                    return Private___93_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___93_const_intnl_SystemString != null)
                {
                    Private___93_const_intnl_SystemString.Value = value;
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

        internal UnityEngine.Quaternion? __1_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineQuaternion != null)
                {
                    return Private___1_intnl_UnityEngineQuaternion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_UnityEngineQuaternion != null)
                    {
                        Private___1_intnl_UnityEngineQuaternion.Value = value.Value;
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

        internal short? __30_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_intnl_SystemInt16 != null)
                {
                    return Private___30_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___30_intnl_SystemInt16 != null)
                    {
                        Private___30_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal float? humanJumpHeight
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_humanJumpHeight != null)
                {
                    return Private_humanJumpHeight.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_humanJumpHeight != null)
                    {
                        Private_humanJumpHeight.Value = value.Value;
                    }
                }
            }
        }

        internal float? __3_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_const_intnl_SystemSingle != null)
                {
                    return Private___3_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_const_intnl_SystemSingle != null)
                    {
                        Private___3_const_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __118_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___118_intnl_SystemBoolean != null)
                {
                    return Private___118_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___118_intnl_SystemBoolean != null)
                    {
                        Private___118_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? identityRevealTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_identityRevealTime != null)
                {
                    return Private_identityRevealTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_identityRevealTime != null)
                    {
                        Private_identityRevealTime.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __0_intnl_NL_WorkshopManagerArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_WorkshopManagerArray != null)
                {
                    return Private___0_intnl_NL_WorkshopManagerArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_WorkshopManagerArray != null)
                {
                    Private___0_intnl_NL_WorkshopManagerArray.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __0_intnl_NL_PlayerCharacterArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_PlayerCharacterArray != null)
                {
                    return Private___0_intnl_NL_PlayerCharacterArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_PlayerCharacterArray != null)
                {
                    Private___0_intnl_NL_PlayerCharacterArray.Value = value;
                }
            }
        }

        internal bool? __95_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___95_intnl_SystemBoolean != null)
                {
                    return Private___95_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___95_intnl_SystemBoolean != null)
                    {
                        Private___95_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __13_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_NL_PlayerCharacter != null)
                {
                    return Private___13_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___13_intnl_NL_PlayerCharacter != null)
                {
                    Private___13_intnl_NL_PlayerCharacter.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __13_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___13_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___13_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___13_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

        internal short? __33_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_intnl_SystemInt16 != null)
                {
                    return Private___33_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_intnl_SystemInt16 != null)
                    {
                        Private___33_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal short? __10_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemInt16 != null)
                {
                    return Private___10_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_SystemInt16 != null)
                    {
                        Private___10_intnl_SystemInt16.Value = value.Value;
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

        internal string __72_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___72_const_intnl_SystemString != null)
                {
                    return Private___72_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___72_const_intnl_SystemString != null)
                {
                    Private___72_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __119_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___119_intnl_SystemBoolean != null)
                {
                    return Private___119_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___119_intnl_SystemBoolean != null)
                    {
                        Private___119_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal short? __35_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_SystemObject != null)
                {
                    return Private___35_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_intnl_SystemObject != null)
                    {
                        Private___35_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __2_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemObject != null)
                {
                    return Private___2_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemObject != null)
                    {
                        Private___2_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal int? __45_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___45_intnl_SystemInt32 != null)
                {
                    return Private___45_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___45_intnl_SystemInt32 != null)
                    {
                        Private___45_intnl_SystemInt32.Value = value.Value;
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

        internal int? __50_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___50_intnl_SystemInt32 != null)
                {
                    return Private___50_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___50_intnl_SystemInt32 != null)
                    {
                        Private___50_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal short? __13_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemInt16 != null)
                {
                    return Private___13_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_SystemInt16 != null)
                    {
                        Private___13_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal int? __42_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___42_intnl_SystemInt32 != null)
                {
                    return Private___42_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___42_intnl_SystemInt32 != null)
                    {
                        Private___42_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] spectateCharacters
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_spectateCharacters != null)
                {
                    return Private_spectateCharacters.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_spectateCharacters != null)
                {
                    Private_spectateCharacters.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __6_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___6_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___6_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __3_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineComponent != null)
                {
                    return Private___3_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_UnityEngineComponent != null)
                {
                    Private___3_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal bool? __93_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___93_intnl_SystemBoolean != null)
                {
                    return Private___93_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___93_intnl_SystemBoolean != null)
                    {
                        Private___93_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __53_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___53_intnl_SystemInt32 != null)
                {
                    return Private___53_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___53_intnl_SystemInt32 != null)
                    {
                        Private___53_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal long? __4_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_const_intnl_SystemInt64 != null)
                {
                    return Private___4_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_const_intnl_SystemInt64 != null)
                    {
                        Private___4_const_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal long? __8_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemInt64 != null)
                {
                    return Private___8_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemInt64 != null)
                    {
                        Private___8_intnl_SystemInt64.Value = value.Value;
                    }
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

        internal int? ammoSpawnDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ammoSpawnDelay != null)
                {
                    return Private_ammoSpawnDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_ammoSpawnDelay != null)
                    {
                        Private_ammoSpawnDelay.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_workshop_NL_WorkshopManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_workshop_NL_WorkshopManager != null)
                {
                    return Private___1_workshop_NL_WorkshopManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_workshop_NL_WorkshopManager != null)
                {
                    Private___1_workshop_NL_WorkshopManager.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour weaponManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_weaponManager != null)
                {
                    return Private_weaponManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_weaponManager != null)
                {
                    Private_weaponManager.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __12_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_NL_PlayerCharacter != null)
                {
                    return Private___12_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___12_intnl_NL_PlayerCharacter != null)
                {
                    Private___12_intnl_NL_PlayerCharacter.Value = value;
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

        internal short? __7_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemInt16 != null)
                {
                    return Private___7_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemInt16 != null)
                    {
                        Private___7_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal int? killRewards
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_killRewards != null)
                {
                    return Private_killRewards.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_killRewards != null)
                    {
                        Private_killRewards.Value = value.Value;
                    }
                }
            }
        }

        internal short? __22_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemInt16 != null)
                {
                    return Private___22_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_intnl_SystemInt16 != null)
                    {
                        Private___22_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __96_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___96_intnl_SystemBoolean != null)
                {
                    return Private___96_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___96_intnl_SystemBoolean != null)
                    {
                        Private___96_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __34_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___34_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___34_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___34_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal bool? __9_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemObject != null)
                {
                    return Private___9_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemObject != null)
                    {
                        Private___9_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __0_this_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_UnityEngineTransform != null)
                {
                    return Private___0_this_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_UnityEngineTransform != null)
                {
                    Private___0_this_intnl_UnityEngineTransform.Value = value;
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

        internal int? __65_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___65_intnl_SystemInt32 != null)
                {
                    return Private___65_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___65_intnl_SystemInt32 != null)
                    {
                        Private___65_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __85_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___85_intnl_SystemBoolean != null)
                {
                    return Private___85_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___85_intnl_SystemBoolean != null)
                    {
                        Private___85_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? playerIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerIndex != null)
                {
                    return Private_playerIndex.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_playerIndex != null)
                    {
                        Private_playerIndex.Value = value.Value;
                    }
                }
            }
        }

        internal int? __62_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___62_intnl_SystemInt32 != null)
                {
                    return Private___62_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___62_intnl_SystemInt32 != null)
                    {
                        Private___62_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __0_spawnPoint_Transform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_spawnPoint_Transform != null)
                {
                    return Private___0_spawnPoint_Transform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_spawnPoint_Transform != null)
                {
                    Private___0_spawnPoint_Transform.Value = value;
                }
            }
        }

        internal VRC.SDK3.Components.VRCPickup __1_itemInHand_VRC_Pickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_itemInHand_VRC_Pickup != null)
                {
                    return Private___1_itemInHand_VRC_Pickup.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_itemInHand_VRC_Pickup != null)
                {
                    Private___1_itemInHand_VRC_Pickup.Value = value;
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

        internal bool? __104_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___104_intnl_SystemBoolean != null)
                {
                    return Private___104_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___104_intnl_SystemBoolean != null)
                    {
                        Private___104_intnl_SystemBoolean.Value = value.Value;
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

        internal bool? __103_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___103_intnl_SystemBoolean != null)
                {
                    return Private___103_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___103_intnl_SystemBoolean != null)
                    {
                        Private___103_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_gunInHand_NL_Gun
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_gunInHand_NL_Gun != null)
                {
                    return Private___1_gunInHand_NL_Gun.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_gunInHand_NL_Gun != null)
                {
                    Private___1_gunInHand_NL_Gun.Value = value;
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

        internal int? humanPlayerCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_humanPlayerCount != null)
                {
                    return Private_humanPlayerCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_humanPlayerCount != null)
                    {
                        Private_humanPlayerCount.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi __5_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___5_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___5_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal int? initialMoney
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_initialMoney != null)
                {
                    return Private_initialMoney.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_initialMoney != null)
                    {
                        Private_initialMoney.Value = value.Value;
                    }
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

        internal int? __2_mp_delta_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_delta_Int32 != null)
                {
                    return Private___2_mp_delta_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_delta_Int32 != null)
                    {
                        Private___2_mp_delta_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __6_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemObject != null)
                {
                    return Private___6_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemObject != null)
                    {
                        Private___6_intnl_SystemObject.Value = value.Value;
                    }
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

        internal bool? __105_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___105_intnl_SystemBoolean != null)
                {
                    return Private___105_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___105_intnl_SystemBoolean != null)
                    {
                        Private___105_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal UnityEngine.Transform __2_intnl_UnityEngineTransform
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

        internal VRC.Udon.UdonBehaviour cameraSpectate
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cameraSpectate != null)
                {
                    return Private_cameraSpectate.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cameraSpectate != null)
                {
                    Private_cameraSpectate.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_character_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_character_NL_PlayerCharacter != null)
                {
                    return Private___1_character_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_character_NL_PlayerCharacter != null)
                {
                    Private___1_character_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal string __58_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___58_const_intnl_SystemString != null)
                {
                    return Private___58_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___58_const_intnl_SystemString != null)
                {
                    Private___58_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __83_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___83_intnl_SystemBoolean != null)
                {
                    return Private___83_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___83_intnl_SystemBoolean != null)
                    {
                        Private___83_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? initialAmmo
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_initialAmmo != null)
                {
                    return Private_initialAmmo.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_initialAmmo != null)
                    {
                        Private_initialAmmo.Value = value.Value;
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

        internal bool? __138_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___138_intnl_SystemBoolean != null)
                {
                    return Private___138_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___138_intnl_SystemBoolean != null)
                    {
                        Private___138_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __75_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___75_intnl_SystemBoolean != null)
                {
                    return Private___75_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___75_intnl_SystemBoolean != null)
                    {
                        Private___75_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __3_intnl_returnValSymbol_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_returnValSymbol_NL_PlayerCharacter != null)
                {
                    return Private___3_intnl_returnValSymbol_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_returnValSymbol_NL_PlayerCharacter != null)
                {
                    Private___3_intnl_returnValSymbol_NL_PlayerCharacter.Value = value;
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

        internal bool? isJoinedGame
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isJoinedGame != null)
                {
                    return Private_isJoinedGame.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isJoinedGame != null)
                    {
                        Private_isJoinedGame.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __1_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineComponent != null)
                {
                    return Private___1_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineComponent != null)
                {
                    Private___1_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal bool? __64_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___64_intnl_SystemBoolean != null)
                {
                    return Private___64_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___64_intnl_SystemBoolean != null)
                    {
                        Private___64_intnl_SystemBoolean.Value = value.Value;
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

        internal short? __8_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemInt16 != null)
                {
                    return Private___8_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemInt16 != null)
                    {
                        Private___8_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __139_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___139_intnl_SystemBoolean != null)
                {
                    return Private___139_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___139_intnl_SystemBoolean != null)
                    {
                        Private___139_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __99_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___99_intnl_SystemBoolean != null)
                {
                    return Private___99_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___99_intnl_SystemBoolean != null)
                    {
                        Private___99_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __38_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_intnl_SystemInt32 != null)
                {
                    return Private___38_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___38_intnl_SystemInt32 != null)
                    {
                        Private___38_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_damageTake_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_damageTake_Int32 != null)
                {
                    return Private___0_mp_damageTake_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_damageTake_Int32 != null)
                    {
                        Private___0_mp_damageTake_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal short? __25_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_intnl_SystemInt16 != null)
                {
                    return Private___25_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___25_intnl_SystemInt16 != null)
                    {
                        Private___25_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __86_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___86_intnl_SystemBoolean != null)
                {
                    return Private___86_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___86_intnl_SystemBoolean != null)
                    {
                        Private___86_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal float? __1_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemSingle != null)
                {
                    return Private___1_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemSingle != null)
                    {
                        Private___1_const_intnl_SystemSingle.Value = value.Value;
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

        internal string __59_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___59_const_intnl_SystemString != null)
                {
                    return Private___59_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___59_const_intnl_SystemString != null)
                {
                    Private___59_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_resultCharacter_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_resultCharacter_NL_PlayerCharacter != null)
                {
                    return Private___0_resultCharacter_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_resultCharacter_NL_PlayerCharacter != null)
                {
                    Private___0_resultCharacter_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal float? __5_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemSingle != null)
                {
                    return Private___5_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemSingle != null)
                    {
                        Private___5_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __84_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___84_const_intnl_SystemString != null)
                {
                    return Private___84_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___84_const_intnl_SystemString != null)
                {
                    Private___84_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __56_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___56_intnl_SystemInt32 != null)
                {
                    return Private___56_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___56_intnl_SystemInt32 != null)
                    {
                        Private___56_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __5_character_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_character_NL_PlayerCharacter != null)
                {
                    return Private___5_character_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_character_NL_PlayerCharacter != null)
                {
                    Private___5_character_NL_PlayerCharacter.Value = value;
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

        internal bool? __73_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___73_intnl_SystemBoolean != null)
                {
                    return Private___73_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___73_intnl_SystemBoolean != null)
                    {
                        Private___73_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal string __85_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___85_const_intnl_SystemString != null)
                {
                    return Private___85_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___85_const_intnl_SystemString != null)
                {
                    Private___85_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __64_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___64_const_intnl_SystemString != null)
                {
                    return Private___64_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___64_const_intnl_SystemString != null)
                {
                    Private___64_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __9_character_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_character_NL_PlayerCharacter != null)
                {
                    return Private___9_character_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_character_NL_PlayerCharacter != null)
                {
                    Private___9_character_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_NL_UpdateManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_NL_UpdateManager != null)
                {
                    return Private___1_intnl_NL_UpdateManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_NL_UpdateManager != null)
                {
                    Private___1_intnl_NL_UpdateManager.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __20_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemObject != null)
                {
                    return Private___20_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___20_intnl_SystemObject != null)
                {
                    Private___20_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_NLI_PlayerSlotUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_NLI_PlayerSlotUI != null)
                {
                    return Private___1_intnl_NLI_PlayerSlotUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_NLI_PlayerSlotUI != null)
                {
                    Private___1_intnl_NLI_PlayerSlotUI.Value = value;
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

        internal bool? __76_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___76_intnl_SystemBoolean != null)
                {
                    return Private___76_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___76_intnl_SystemBoolean != null)
                    {
                        Private___76_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour effectManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_effectManager != null)
                {
                    return Private_effectManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_effectManager != null)
                {
                    Private_effectManager.Value = value;
                }
            }
        }

        internal string __78_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___78_const_intnl_SystemString != null)
                {
                    return Private___78_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___78_const_intnl_SystemString != null)
                {
                    Private___78_const_intnl_SystemString.Value = value;
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

        internal float? killEventTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_killEventTimer != null)
                {
                    return Private_killEventTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_killEventTimer != null)
                    {
                        Private_killEventTimer.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __91_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___91_intnl_SystemBoolean != null)
                {
                    return Private___91_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___91_intnl_SystemBoolean != null)
                    {
                        Private___91_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __36_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_intnl_SystemObject != null)
                {
                    return Private___36_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___36_intnl_SystemObject != null)
                {
                    Private___36_intnl_SystemObject.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __35_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___35_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___35_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___35_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal int? __1_tempNum_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_tempNum_Int32 != null)
                {
                    return Private___1_tempNum_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_tempNum_Int32 != null)
                    {
                        Private___1_tempNum_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __0_const_intnl_NL_WorkshopManagerArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_NL_WorkshopManagerArray != null)
                {
                    return Private___0_const_intnl_NL_WorkshopManagerArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_const_intnl_NL_WorkshopManagerArray != null)
                {
                    Private___0_const_intnl_NL_WorkshopManagerArray.Value = value;
                }
            }
        }

        internal float? teleportCheckTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teleportCheckTimer != null)
                {
                    return Private_teleportCheckTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teleportCheckTimer != null)
                    {
                        Private_teleportCheckTimer.Value = value.Value;
                    }
                }
            }
        }

        internal int? __48_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___48_intnl_SystemInt32 != null)
                {
                    return Private___48_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___48_intnl_SystemInt32 != null)
                    {
                        Private___48_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isInfested
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isInfested != null)
                {
                    return Private_isInfested.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isInfested != null)
                    {
                        Private_isInfested.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __2_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineComponentArray != null)
                {
                    return Private___2_intnl_UnityEngineComponentArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineComponentArray != null)
                {
                    Private___2_intnl_UnityEngineComponentArray.Value = value;
                }
            }
        }

        internal bool? __89_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___89_intnl_SystemBoolean != null)
                {
                    return Private___89_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___89_intnl_SystemBoolean != null)
                    {
                        Private___89_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __36_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___36_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___36_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___36_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal short? __16_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_SystemInt16 != null)
                {
                    return Private___16_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_intnl_SystemInt16 != null)
                    {
                        Private___16_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __8_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___8_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___8_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

        internal string __65_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___65_const_intnl_SystemString != null)
                {
                    return Private___65_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___65_const_intnl_SystemString != null)
                {
                    Private___65_const_intnl_SystemString.Value = value;
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

        internal float? __11_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemSingle != null)
                {
                    return Private___11_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_SystemSingle != null)
                    {
                        Private___11_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_NL_Gun
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_Gun != null)
                {
                    return Private___0_intnl_NL_Gun.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_Gun != null)
                {
                    Private___0_intnl_NL_Gun.Value = value;
                }
            }
        }

        internal bool? __106_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___106_intnl_SystemBoolean != null)
                {
                    return Private___106_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___106_intnl_SystemBoolean != null)
                    {
                        Private___106_intnl_SystemBoolean.Value = value.Value;
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

        internal int? __34_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_SystemInt32 != null)
                {
                    return Private___34_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_intnl_SystemInt32 != null)
                    {
                        Private___34_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __79_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___79_const_intnl_SystemString != null)
                {
                    return Private___79_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___79_const_intnl_SystemString != null)
                {
                    Private___79_const_intnl_SystemString.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __37_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___37_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___37_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___37_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __9_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_NL_PlayerCharacter != null)
                {
                    return Private___9_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_intnl_NL_PlayerCharacter != null)
                {
                    Private___9_intnl_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal bool? __127_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___127_intnl_SystemBoolean != null)
                {
                    return Private___127_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___127_intnl_SystemBoolean != null)
                    {
                        Private___127_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? hasEnterHeroMode
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasEnterHeroMode != null)
                {
                    return Private_hasEnterHeroMode.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasEnterHeroMode != null)
                    {
                        Private_hasEnterHeroMode.Value = value.Value;
                    }
                }
            }
        }

        internal string __87_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___87_const_intnl_SystemString != null)
                {
                    return Private___87_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___87_const_intnl_SystemString != null)
                {
                    Private___87_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour mapLayoutSet
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_mapLayoutSet != null)
                {
                    return Private_mapLayoutSet.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_mapLayoutSet != null)
                {
                    Private_mapLayoutSet.Value = value;
                }
            }
        }

        internal long? __0_intnl_SystemObject
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
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemObject != null)
                    {
                        Private___0_intnl_SystemObject.Value = value.Value;
                    }
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

        internal UnityEngine.AudioSource audioSource_Lobby
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_audioSource_Lobby != null)
                {
                    return Private_audioSource_Lobby.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_audioSource_Lobby != null)
                {
                    Private_audioSource_Lobby.Value = value;
                }
            }
        }

        internal short? __28_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_intnl_SystemInt16 != null)
                {
                    return Private___28_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___28_intnl_SystemInt16 != null)
                    {
                        Private___28_intnl_SystemInt16.Value = value.Value;
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

        internal int? __37_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_intnl_SystemInt32 != null)
                {
                    return Private___37_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_intnl_SystemInt32 != null)
                    {
                        Private___37_intnl_SystemInt32.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __2_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_NL_PlayerCharacter != null)
                {
                    return Private___2_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_NL_PlayerCharacter != null)
                {
                    Private___2_intnl_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __2_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineComponent != null)
                {
                    return Private___2_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineComponent != null)
                {
                    Private___2_intnl_UnityEngineComponent.Value = value;
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

        internal int? gameOverTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameOverTime != null)
                {
                    return Private_gameOverTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameOverTime != null)
                    {
                        Private_gameOverTime.Value = value.Value;
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

        internal UnityEngine.Transform __27_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_intnl_SystemObject != null)
                {
                    return Private___27_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___27_intnl_SystemObject != null)
                {
                    Private___27_intnl_SystemObject.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __22_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___22_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___22_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___22_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal int? __68_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___68_intnl_SystemInt32 != null)
                {
                    return Private___68_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___68_intnl_SystemInt32 != null)
                    {
                        Private___68_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __100_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___100_intnl_SystemBoolean != null)
                {
                    return Private___100_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___100_intnl_SystemBoolean != null)
                    {
                        Private___100_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __14_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___14_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___14_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___14_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

        internal bool? __79_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___79_intnl_SystemBoolean != null)
                {
                    return Private___79_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___79_intnl_SystemBoolean != null)
                    {
                        Private___79_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __92_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___92_intnl_SystemBoolean != null)
                {
                    return Private___92_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___92_intnl_SystemBoolean != null)
                    {
                        Private___92_intnl_SystemBoolean.Value = value.Value;
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

        internal long? __5_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemInt64 != null)
                {
                    return Private___5_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemInt64 != null)
                    {
                        Private___5_intnl_SystemInt64.Value = value.Value;
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

        internal long? __28_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_intnl_SystemObject != null)
                {
                    return Private___28_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___28_intnl_SystemObject != null)
                    {
                        Private___28_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __81_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___81_intnl_SystemBoolean != null)
                {
                    return Private___81_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___81_intnl_SystemBoolean != null)
                    {
                        Private___81_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal short? __1_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemInt16 != null)
                {
                    return Private___1_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemInt16 != null)
                    {
                        Private___1_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal float? infestedRunningSpeed
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_infestedRunningSpeed != null)
                {
                    return Private_infestedRunningSpeed.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_infestedRunningSpeed != null)
                    {
                        Private_infestedRunningSpeed.Value = value.Value;
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

        internal int? __0_mp_playerID_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_playerID_Int32 != null)
                {
                    return Private___0_mp_playerID_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_playerID_Int32 != null)
                    {
                        Private___0_mp_playerID_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __68_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___68_intnl_SystemBoolean != null)
                {
                    return Private___68_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___68_intnl_SystemBoolean != null)
                    {
                        Private___68_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __67_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___67_const_intnl_SystemString != null)
                {
                    return Private___67_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___67_const_intnl_SystemString != null)
                {
                    Private___67_const_intnl_SystemString.Value = value;
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

        internal float? __4_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_const_intnl_SystemSingle != null)
                {
                    return Private___4_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_const_intnl_SystemSingle != null)
                    {
                        Private___4_const_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __101_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___101_intnl_SystemBoolean != null)
                {
                    return Private___101_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___101_intnl_SystemBoolean != null)
                    {
                        Private___101_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __94_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___94_const_intnl_SystemString != null)
                {
                    return Private___94_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___94_const_intnl_SystemString != null)
                {
                    Private___94_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int[] killedPlayerList
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_killedPlayerList != null)
                {
                    return Private_killedPlayerList.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_killedPlayerList != null)
                {
                    Private_killedPlayerList.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] allPlayerSlots
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_allPlayerSlots != null)
                {
                    return Private_allPlayerSlots.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_allPlayerSlots != null)
                {
                    Private_allPlayerSlots.Value = value;
                }
            }
        }

        internal float? initialMoneySpawnRate
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_initialMoneySpawnRate != null)
                {
                    return Private_initialMoneySpawnRate.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_initialMoneySpawnRate != null)
                    {
                        Private_initialMoneySpawnRate.Value = value.Value;
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

        internal int? __44_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___44_intnl_SystemInt32 != null)
                {
                    return Private___44_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___44_intnl_SystemInt32 != null)
                    {
                        Private___44_intnl_SystemInt32.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi __21_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemObject != null)
                {
                    return Private___21_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___21_intnl_SystemObject != null)
                {
                    Private___21_intnl_SystemObject.Value = value;
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

        internal bool? __54_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___54_intnl_SystemBoolean != null)
                {
                    return Private___54_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___54_intnl_SystemBoolean != null)
                    {
                        Private___54_intnl_SystemBoolean.Value = value.Value;
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

        internal short? __13_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemObject != null)
                {
                    return Private___13_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_SystemObject != null)
                    {
                        Private___13_intnl_SystemObject.Value = value.Value;
                    }
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

        internal int? __41_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___41_intnl_SystemInt32 != null)
                {
                    return Private___41_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___41_intnl_SystemInt32 != null)
                    {
                        Private___41_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __47_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___47_intnl_SystemInt32 != null)
                {
                    return Private___47_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___47_intnl_SystemInt32 != null)
                    {
                        Private___47_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal string __56_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___56_const_intnl_SystemString != null)
                {
                    return Private___56_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___56_const_intnl_SystemString != null)
                {
                    Private___56_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __71_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___71_intnl_SystemBoolean != null)
                {
                    return Private___71_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___71_intnl_SystemBoolean != null)
                    {
                        Private___71_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __117_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___117_intnl_SystemBoolean != null)
                {
                    return Private___117_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___117_intnl_SystemBoolean != null)
                    {
                        Private___117_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __95_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___95_const_intnl_SystemString != null)
                {
                    return Private___95_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___95_const_intnl_SystemString != null)
                {
                    Private___95_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __4_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemObject != null)
                {
                    return Private___4_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemObject != null)
                    {
                        Private___4_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_mp_delta_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_delta_Int32 != null)
                {
                    return Private___1_mp_delta_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_delta_Int32 != null)
                    {
                        Private___1_mp_delta_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal short? __19_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemInt16 != null)
                {
                    return Private___19_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemInt16 != null)
                    {
                        Private___19_intnl_SystemInt16.Value = value.Value;
                    }
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

        internal bool? __60_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___60_intnl_SystemBoolean != null)
                {
                    return Private___60_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___60_intnl_SystemBoolean != null)
                    {
                        Private___60_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __29_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___29_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___29_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___29_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

        internal bool? __82_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___82_intnl_SystemBoolean != null)
                {
                    return Private___82_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___82_intnl_SystemBoolean != null)
                    {
                        Private___82_intnl_SystemBoolean.Value = value.Value;
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

        internal int? __59_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___59_intnl_SystemInt32 != null)
                {
                    return Private___59_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___59_intnl_SystemInt32 != null)
                    {
                        Private___59_intnl_SystemInt32.Value = value.Value;
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

        internal UnityEngine.Vector3? __6_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_UnityEngineVector3 != null)
                {
                    return Private___6_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_UnityEngineVector3 != null)
                    {
                        Private___6_intnl_UnityEngineVector3.Value = value.Value;
                    }
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

        internal UnityEngine.Component[] __3_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineComponentArray != null)
                {
                    return Private___3_intnl_UnityEngineComponentArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_UnityEngineComponentArray != null)
                {
                    Private___3_intnl_UnityEngineComponentArray.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_workshop_NL_WorkshopManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_workshop_NL_WorkshopManager != null)
                {
                    return Private___0_workshop_NL_WorkshopManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_workshop_NL_WorkshopManager != null)
                {
                    Private___0_workshop_NL_WorkshopManager.Value = value;
                }
            }
        }

        internal int? __64_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___64_intnl_SystemInt32 != null)
                {
                    return Private___64_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___64_intnl_SystemInt32 != null)
                    {
                        Private___64_intnl_SystemInt32.Value = value.Value;
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

        internal short? __21_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemInt16 != null)
                {
                    return Private___21_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_intnl_SystemInt16 != null)
                    {
                        Private___21_intnl_SystemInt16.Value = value.Value;
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

        internal short? __5_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemInt16 != null)
                {
                    return Private___5_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemInt16 != null)
                    {
                        Private___5_intnl_SystemInt16.Value = value.Value;
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

        internal string __10_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemObject != null)
                {
                    return Private___10_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___10_intnl_SystemObject != null)
                {
                    Private___10_intnl_SystemObject.Value = value;
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

        internal string __70_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___70_const_intnl_SystemString != null)
                {
                    return Private___70_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___70_const_intnl_SystemString != null)
                {
                    Private___70_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __61_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___61_intnl_SystemInt32 != null)
                {
                    return Private___61_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___61_intnl_SystemInt32 != null)
                    {
                        Private___61_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour weaponSkinManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_weaponSkinManager != null)
                {
                    return Private_weaponSkinManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_weaponSkinManager != null)
                {
                    Private_weaponSkinManager.Value = value;
                }
            }
        }

        internal int? __67_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___67_intnl_SystemInt32 != null)
                {
                    return Private___67_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___67_intnl_SystemInt32 != null)
                    {
                        Private___67_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __67_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___67_intnl_SystemBoolean != null)
                {
                    return Private___67_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___67_intnl_SystemBoolean != null)
                    {
                        Private___67_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal string __53_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___53_const_intnl_SystemString != null)
                {
                    return Private___53_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___53_const_intnl_SystemString != null)
                {
                    Private___53_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_NL_UpdateManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_UpdateManager != null)
                {
                    return Private___0_intnl_NL_UpdateManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_UpdateManager != null)
                {
                    Private___0_intnl_NL_UpdateManager.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __5_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_UnityEngineVector3 != null)
                {
                    return Private___5_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_UnityEngineVector3 != null)
                    {
                        Private___5_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal float? inGameZValue
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inGameZValue != null)
                {
                    return Private_inGameZValue.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inGameZValue != null)
                    {
                        Private_inGameZValue.Value = value.Value;
                    }
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

        internal string __97_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___97_const_intnl_SystemString != null)
                {
                    return Private___97_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___97_const_intnl_SystemString != null)
                {
                    Private___97_const_intnl_SystemString.Value = value;
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

        internal int? __0_mp_delta_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_delta_Int32 != null)
                {
                    return Private___0_mp_delta_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_delta_Int32 != null)
                    {
                        Private___0_mp_delta_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __29_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_intnl_SystemObject != null)
                {
                    return Private___29_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___29_intnl_SystemObject != null)
                    {
                        Private___29_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal string __82_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___82_const_intnl_SystemString != null)
                {
                    return Private___82_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___82_const_intnl_SystemString != null)
                {
                    Private___82_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __72_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___72_intnl_SystemBoolean != null)
                {
                    return Private___72_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___72_intnl_SystemBoolean != null)
                    {
                        Private___72_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal float? __9_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemSingle != null)
                {
                    return Private___9_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemSingle != null)
                    {
                        Private___9_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __102_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___102_intnl_SystemBoolean != null)
                {
                    return Private___102_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___102_intnl_SystemBoolean != null)
                    {
                        Private___102_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __15_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___15_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___15_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___15_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal string __71_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___71_const_intnl_SystemString != null)
                {
                    return Private___71_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___71_const_intnl_SystemString != null)
                {
                    Private___71_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __3_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___3_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___3_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __7_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___7_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___7_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour playerHUD
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerHUD != null)
                {
                    return Private_playerHUD.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerHUD != null)
                {
                    Private_playerHUD.Value = value;
                }
            }
        }

        internal string __76_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___76_const_intnl_SystemString != null)
                {
                    return Private___76_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___76_const_intnl_SystemString != null)
                {
                    Private___76_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __124_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___124_intnl_SystemBoolean != null)
                {
                    return Private___124_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___124_intnl_SystemBoolean != null)
                    {
                        Private___124_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal VRC.SDKBase.VRCPlayerApi __16_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___16_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___16_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___16_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal bool? __123_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___123_intnl_SystemBoolean != null)
                {
                    return Private___123_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___123_intnl_SystemBoolean != null)
                    {
                        Private___123_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal short? __32_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_intnl_SystemInt16 != null)
                {
                    return Private___32_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_intnl_SystemInt16 != null)
                    {
                        Private___32_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal short? __24_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_intnl_SystemInt16 != null)
                {
                    return Private___24_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_intnl_SystemInt16 != null)
                    {
                        Private___24_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __3_intnl_SystemObject
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
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemObject != null)
                    {
                        Private___3_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __125_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___125_intnl_SystemBoolean != null)
                {
                    return Private___125_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___125_intnl_SystemBoolean != null)
                    {
                        Private___125_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __62_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___62_const_intnl_SystemString != null)
                {
                    return Private___62_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___62_const_intnl_SystemString != null)
                {
                    Private___62_const_intnl_SystemString.Value = value;
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

        internal short? __12_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_SystemInt16 != null)
                {
                    return Private___12_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_SystemInt16 != null)
                    {
                        Private___12_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal float? __6_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemSingle != null)
                {
                    return Private___6_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemSingle != null)
                    {
                        Private___6_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal short? __27_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_intnl_SystemInt16 != null)
                {
                    return Private___27_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___27_intnl_SystemInt16 != null)
                    {
                        Private___27_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal int? __55_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___55_intnl_SystemInt32 != null)
                {
                    return Private___55_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___55_intnl_SystemInt32 != null)
                    {
                        Private___55_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __3_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_NL_PlayerCharacter != null)
                {
                    return Private___3_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_NL_PlayerCharacter != null)
                {
                    Private___3_intnl_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal UnityEngine.Quaternion? __0_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineQuaternion != null)
                {
                    return Private___0_intnl_UnityEngineQuaternion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineQuaternion != null)
                    {
                        Private___0_intnl_UnityEngineQuaternion.Value = value.Value;
                    }
                }
            }
        }

        internal int? __52_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___52_intnl_SystemInt32 != null)
                {
                    return Private___52_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___52_intnl_SystemInt32 != null)
                    {
                        Private___52_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __58_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___58_intnl_SystemBoolean != null)
                {
                    return Private___58_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___58_intnl_SystemBoolean != null)
                    {
                        Private___58_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal long? __11_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemInt64 != null)
                {
                    return Private___11_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_SystemInt64 != null)
                    {
                        Private___11_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __137_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___137_intnl_SystemBoolean != null)
                {
                    return Private___137_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___137_intnl_SystemBoolean != null)
                    {
                        Private___137_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __3_intnl_NL_Gun
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_NL_Gun != null)
                {
                    return Private___3_intnl_NL_Gun.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_NL_Gun != null)
                {
                    Private___3_intnl_NL_Gun.Value = value;
                }
            }
        }

        internal VRC.SDK3.Components.VRCPickup __0_itemInHand_VRC_Pickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_itemInHand_VRC_Pickup != null)
                {
                    return Private___0_itemInHand_VRC_Pickup.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_itemInHand_VRC_Pickup != null)
                {
                    Private___0_itemInHand_VRC_Pickup.Value = value;
                }
            }
        }

        internal string __73_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___73_const_intnl_SystemString != null)
                {
                    return Private___73_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___73_const_intnl_SystemString != null)
                {
                    Private___73_const_intnl_SystemString.Value = value;
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

        internal long? __2_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemInt64 != null)
                {
                    return Private___2_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemInt64 != null)
                    {
                        Private___2_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal short? __14_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemObject != null)
                {
                    return Private___14_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_intnl_SystemObject != null)
                    {
                        Private___14_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal float? infestedJumpHeight
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_infestedJumpHeight != null)
                {
                    return Private_infestedJumpHeight.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_infestedJumpHeight != null)
                    {
                        Private_infestedJumpHeight.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour lobbyManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lobbyManager != null)
                {
                    return Private_lobbyManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_lobbyManager != null)
                {
                    Private_lobbyManager.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __1_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineComponentArray != null)
                {
                    return Private___1_intnl_UnityEngineComponentArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineComponentArray != null)
                {
                    Private___1_intnl_UnityEngineComponentArray.Value = value;
                }
            }
        }

        internal short? __35_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_SystemInt16 != null)
                {
                    return Private___35_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_intnl_SystemInt16 != null)
                    {
                        Private___35_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_character_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_character_NL_PlayerCharacter != null)
                {
                    return Private___0_character_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_character_NL_PlayerCharacter != null)
                {
                    Private___0_character_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal bool? __22_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemObject != null)
                {
                    return Private___22_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_intnl_SystemObject != null)
                    {
                        Private___22_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __114_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___114_intnl_SystemBoolean != null)
                {
                    return Private___114_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___114_intnl_SystemBoolean != null)
                    {
                        Private___114_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __100_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___100_const_intnl_SystemString != null)
                {
                    return Private___100_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___100_const_intnl_SystemString != null)
                {
                    Private___100_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_NL_WorkshopManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_WorkshopManager != null)
                {
                    return Private___0_intnl_NL_WorkshopManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_WorkshopManager != null)
                {
                    Private___0_intnl_NL_WorkshopManager.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_NLI_LobbyManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NLI_LobbyManager != null)
                {
                    return Private___0_intnl_NLI_LobbyManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NLI_LobbyManager != null)
                {
                    Private___0_intnl_NLI_LobbyManager.Value = value;
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

        internal bool? __113_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___113_intnl_SystemBoolean != null)
                {
                    return Private___113_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___113_intnl_SystemBoolean != null)
                    {
                        Private___113_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal bool? hasRevealIdentity
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasRevealIdentity != null)
                {
                    return Private_hasRevealIdentity.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasRevealIdentity != null)
                    {
                        Private_hasRevealIdentity.Value = value.Value;
                    }
                }
            }
        }

        internal short? __15_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemInt16 != null)
                {
                    return Private___15_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_intnl_SystemInt16 != null)
                    {
                        Private___15_intnl_SystemInt16.Value = value.Value;
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

        internal bool? __50_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___50_intnl_SystemBoolean != null)
                {
                    return Private___50_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___50_intnl_SystemBoolean != null)
                    {
                        Private___50_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal short? __7_intnl_SystemObject
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

        internal bool? __115_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___115_intnl_SystemBoolean != null)
                {
                    return Private___115_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___115_intnl_SystemBoolean != null)
                    {
                        Private___115_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_NL_SpectateCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_SpectateCharacter != null)
                {
                    return Private___0_intnl_NL_SpectateCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_SpectateCharacter != null)
                {
                    Private___0_intnl_NL_SpectateCharacter.Value = value;
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

        internal long? __9_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemInt64 != null)
                {
                    return Private___9_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemInt64 != null)
                    {
                        Private___9_intnl_SystemInt64.Value = value.Value;
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

        internal bool? __65_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___65_intnl_SystemBoolean != null)
                {
                    return Private___65_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___65_intnl_SystemBoolean != null)
                    {
                        Private___65_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __92_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___92_const_intnl_SystemString != null)
                {
                    return Private___92_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___92_const_intnl_SystemString != null)
                {
                    Private___92_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_lastHuman_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_lastHuman_NL_PlayerCharacter != null)
                {
                    return Private___0_lastHuman_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_lastHuman_NL_PlayerCharacter != null)
                {
                    Private___0_lastHuman_NL_PlayerCharacter.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __24_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___24_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___24_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___24_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal int? __0_tempNum_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_tempNum_Int32 != null)
                {
                    return Private___0_tempNum_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_tempNum_Int32 != null)
                    {
                        Private___0_tempNum_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __57_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___57_intnl_SystemBoolean != null)
                {
                    return Private___57_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___57_intnl_SystemBoolean != null)
                    {
                        Private___57_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal float? gameStateCheckTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStateCheckTimer != null)
                {
                    return Private_gameStateCheckTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStateCheckTimer != null)
                    {
                        Private_gameStateCheckTimer.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __126_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___126_intnl_SystemBoolean != null)
                {
                    return Private___126_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___126_intnl_SystemBoolean != null)
                    {
                        Private___126_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_NL_WorkshopManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_NL_WorkshopManager != null)
                {
                    return Private___1_intnl_NL_WorkshopManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_NL_WorkshopManager != null)
                {
                    Private___1_intnl_NL_WorkshopManager.Value = value;
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

        internal int? inGameTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inGameTime != null)
                {
                    return Private_inGameTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inGameTime != null)
                    {
                        Private_inGameTime.Value = value.Value;
                    }
                }
            }
        }

        internal long? __6_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemInt64 != null)
                {
                    return Private___6_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemInt64 != null)
                    {
                        Private___6_intnl_SystemInt64.Value = value.Value;
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

        internal short? __19_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemObject != null)
                {
                    return Private___19_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemObject != null)
                    {
                        Private___19_intnl_SystemObject.Value = value.Value;
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

        internal short? __2_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemInt16 != null)
                {
                    return Private___2_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemInt16 != null)
                    {
                        Private___2_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __8_character_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_character_NL_PlayerCharacter != null)
                {
                    return Private___8_character_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_character_NL_PlayerCharacter != null)
                {
                    Private___8_character_NL_PlayerCharacter.Value = value;
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

        internal bool? __63_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___63_intnl_SystemBoolean != null)
                {
                    return Private___63_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___63_intnl_SystemBoolean != null)
                    {
                        Private___63_intnl_SystemBoolean.Value = value.Value;
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

        internal string __88_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___88_const_intnl_SystemString != null)
                {
                    return Private___88_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___88_const_intnl_SystemString != null)
                {
                    Private___88_const_intnl_SystemString.Value = value;
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

        internal bool? __108_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___108_intnl_SystemBoolean != null)
                {
                    return Private___108_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___108_intnl_SystemBoolean != null)
                    {
                        Private___108_intnl_SystemBoolean.Value = value.Value;
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

        internal bool? __120_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___120_intnl_SystemBoolean != null)
                {
                    return Private___120_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___120_intnl_SystemBoolean != null)
                    {
                        Private___120_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal short? __8_intnl_SystemObject
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

        internal bool? __94_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___94_intnl_SystemBoolean != null)
                {
                    return Private___94_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___94_intnl_SystemBoolean != null)
                    {
                        Private___94_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_this_intnl_NLI_GameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_NLI_GameManager != null)
                {
                    return Private___0_this_intnl_NLI_GameManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_NLI_GameManager != null)
                {
                    Private___0_this_intnl_NLI_GameManager.Value = value;
                }
            }
        }

        internal UnityEngine.AudioSource audioSource_InGame
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_audioSource_InGame != null)
                {
                    return Private_audioSource_InGame.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_audioSource_InGame != null)
                {
                    Private_audioSource_InGame.Value = value;
                }
            }
        }

        internal short? __15_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemObject != null)
                {
                    return Private___15_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_intnl_SystemObject != null)
                    {
                        Private___15_intnl_SystemObject.Value = value.Value;
                    }
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

        internal bool? __109_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___109_intnl_SystemBoolean != null)
                {
                    return Private___109_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___109_intnl_SystemBoolean != null)
                    {
                        Private___109_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __40_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___40_intnl_SystemInt32 != null)
                {
                    return Private___40_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___40_intnl_SystemInt32 != null)
                    {
                        Private___40_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __13_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemSingle != null)
                {
                    return Private___13_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_SystemSingle != null)
                    {
                        Private___13_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __66_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___66_intnl_SystemBoolean != null)
                {
                    return Private___66_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___66_intnl_SystemBoolean != null)
                    {
                        Private___66_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __121_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___121_intnl_SystemBoolean != null)
                {
                    return Private___121_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___121_intnl_SystemBoolean != null)
                    {
                        Private___121_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal int? maxAmmo
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_maxAmmo != null)
                {
                    return Private_maxAmmo.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_maxAmmo != null)
                    {
                        Private_maxAmmo.Value = value.Value;
                    }
                }
            }
        }

        internal string __89_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___89_const_intnl_SystemString != null)
                {
                    return Private___89_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___89_const_intnl_SystemString != null)
                {
                    Private___89_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __68_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___68_const_intnl_SystemString != null)
                {
                    return Private___68_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___68_const_intnl_SystemString != null)
                {
                    Private___68_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal short? __18_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemInt16 != null)
                {
                    return Private___18_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_intnl_SystemInt16 != null)
                    {
                        Private___18_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal int? __43_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___43_intnl_SystemInt32 != null)
                {
                    return Private___43_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___43_intnl_SystemInt32 != null)
                    {
                        Private___43_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal short? __9_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemInt16 != null)
                {
                    return Private___9_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemInt16 != null)
                    {
                        Private___9_intnl_SystemInt16.Value = value.Value;
                    }
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

        internal float? humanRunningSpeed
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_humanRunningSpeed != null)
                {
                    return Private_humanRunningSpeed.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_humanRunningSpeed != null)
                    {
                        Private_humanRunningSpeed.Value = value.Value;
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

        internal bool? __134_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___134_intnl_SystemBoolean != null)
                {
                    return Private___134_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___134_intnl_SystemBoolean != null)
                    {
                        Private___134_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal bool? __133_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___133_intnl_SystemBoolean != null)
                {
                    return Private___133_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___133_intnl_SystemBoolean != null)
                    {
                        Private___133_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __58_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___58_intnl_SystemInt32 != null)
                {
                    return Private___58_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___58_intnl_SystemInt32 != null)
                    {
                        Private___58_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __4_intnl_UnityEngineTransform
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

        internal VRC.Udon.UdonBehaviour __2_intnl_NL_WorkshopManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_NL_WorkshopManager != null)
                {
                    return Private___2_intnl_NL_WorkshopManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_NL_WorkshopManager != null)
                {
                    Private___2_intnl_NL_WorkshopManager.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __30_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___30_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___30_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___30_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

        internal short? __20_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemInt16 != null)
                {
                    return Private___20_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_intnl_SystemInt16 != null)
                    {
                        Private___20_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __116_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___116_intnl_SystemBoolean != null)
                {
                    return Private___116_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___116_intnl_SystemBoolean != null)
                    {
                        Private___116_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal short? __0_const_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemInt16 != null)
                {
                    return Private___0_const_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemInt16 != null)
                    {
                        Private___0_const_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __135_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___135_intnl_SystemBoolean != null)
                {
                    return Private___135_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___135_intnl_SystemBoolean != null)
                    {
                        Private___135_intnl_SystemBoolean.Value = value.Value;
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

        internal short? __6_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemInt16 != null)
                {
                    return Private___6_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemInt16 != null)
                    {
                        Private___6_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal string __69_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___69_const_intnl_SystemString != null)
                {
                    return Private___69_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___69_const_intnl_SystemString != null)
                {
                    Private___69_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __60_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___60_intnl_SystemInt32 != null)
                {
                    return Private___60_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___60_intnl_SystemInt32 != null)
                    {
                        Private___60_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal short? __23_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_intnl_SystemInt16 != null)
                {
                    return Private___23_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_intnl_SystemInt16 != null)
                    {
                        Private___23_intnl_SystemInt16.Value = value.Value;
                    }
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

        internal int? __36_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_intnl_SystemInt32 != null)
                {
                    return Private___36_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___36_intnl_SystemInt32 != null)
                    {
                        Private___36_intnl_SystemInt32.Value = value.Value;
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

        internal float? __4_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemSingle != null)
                {
                    return Private___4_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemSingle != null)
                    {
                        Private___4_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal long? __2_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_const_intnl_SystemInt64 != null)
                {
                    return Private___2_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_const_intnl_SystemInt64 != null)
                    {
                        Private___2_const_intnl_SystemInt64.Value = value.Value;
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

        internal int? __63_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___63_intnl_SystemInt32 != null)
                {
                    return Private___63_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___63_intnl_SystemInt32 != null)
                    {
                        Private___63_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __84_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___84_intnl_SystemBoolean != null)
                {
                    return Private___84_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___84_intnl_SystemBoolean != null)
                    {
                        Private___84_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __110_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___110_intnl_SystemBoolean != null)
                {
                    return Private___110_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___110_intnl_SystemBoolean != null)
                    {
                        Private___110_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isHero
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isHero != null)
                {
                    return Private_isHero.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isHero != null)
                    {
                        Private_isHero.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_gunInHand_NL_Gun
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_gunInHand_NL_Gun != null)
                {
                    return Private___0_gunInHand_NL_Gun.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_gunInHand_NL_Gun != null)
                {
                    Private___0_gunInHand_NL_Gun.Value = value;
                }
            }
        }

        internal string __54_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___54_const_intnl_SystemString != null)
                {
                    return Private___54_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___54_const_intnl_SystemString != null)
                {
                    Private___54_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? isPlayerInVR
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isPlayerInVR != null)
                {
                    return Private_isPlayerInVR.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isPlayerInVR != null)
                    {
                        Private_isPlayerInVR.Value = value.Value;
                    }
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

        internal bool? __69_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___69_intnl_SystemBoolean != null)
                {
                    return Private___69_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___69_intnl_SystemBoolean != null)
                    {
                        Private___69_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __4_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___4_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___4_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal float? __12_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_SystemSingle != null)
                {
                    return Private___12_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_SystemSingle != null)
                    {
                        Private___12_intnl_SystemSingle.Value = value.Value;
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

        internal bool? __111_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___111_intnl_SystemBoolean != null)
                {
                    return Private___111_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___111_intnl_SystemBoolean != null)
                    {
                        Private___111_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? gameStateCheckTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStateCheckTime != null)
                {
                    return Private_gameStateCheckTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStateCheckTime != null)
                    {
                        Private_gameStateCheckTime.Value = value.Value;
                    }
                }
            }
        }

        internal int? infestRewards
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_infestRewards != null)
                {
                    return Private_infestRewards.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_infestRewards != null)
                    {
                        Private_infestRewards.Value = value.Value;
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

        internal int? __0_mp_targetID_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_targetID_Int32 != null)
                {
                    return Private___0_mp_targetID_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_targetID_Int32 != null)
                    {
                        Private___0_mp_targetID_Int32.Value = value.Value;
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

        internal short? __31_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_intnl_SystemInt16 != null)
                {
                    return Private___31_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___31_intnl_SystemInt16 != null)
                    {
                        Private___31_intnl_SystemInt16.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_NLI_PlayerSlotUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NLI_PlayerSlotUI != null)
                {
                    return Private___0_intnl_NLI_PlayerSlotUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NLI_PlayerSlotUI != null)
                {
                    Private___0_intnl_NLI_PlayerSlotUI.Value = value;
                }
            }
        }

        internal bool? __55_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___55_intnl_SystemBoolean != null)
                {
                    return Private___55_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___55_intnl_SystemBoolean != null)
                    {
                        Private___55_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal string __55_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___55_const_intnl_SystemString != null)
                {
                    return Private___55_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___55_const_intnl_SystemString != null)
                {
                    Private___55_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? latencyProtection
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_latencyProtection != null)
                {
                    return Private_latencyProtection.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_latencyProtection != null)
                    {
                        Private_latencyProtection.Value = value.Value;
                    }
                }
            }
        }

        internal float? ammoSpawnTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ammoSpawnTimer != null)
                {
                    return Private_ammoSpawnTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_ammoSpawnTimer != null)
                    {
                        Private_ammoSpawnTimer.Value = value.Value;
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

        internal string __98_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___98_const_intnl_SystemString != null)
                {
                    return Private___98_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___98_const_intnl_SystemString != null)
                {
                    Private___98_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __54_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___54_intnl_SystemInt32 != null)
                {
                    return Private___54_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___54_intnl_SystemInt32 != null)
                    {
                        Private___54_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? __74_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___74_intnl_SystemBoolean != null)
                {
                    return Private___74_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___74_intnl_SystemBoolean != null)
                    {
                        Private___74_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal short? __11_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemInt16 != null)
                {
                    return Private___11_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_SystemInt16 != null)
                    {
                        Private___11_intnl_SystemInt16.Value = value.Value;
                    }
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

        internal bool? __122_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___122_intnl_SystemBoolean != null)
                {
                    return Private___122_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___122_intnl_SystemBoolean != null)
                    {
                        Private___122_intnl_SystemBoolean.Value = value.Value;
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

        internal int? __46_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___46_intnl_SystemInt32 != null)
                {
                    return Private___46_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___46_intnl_SystemInt32 != null)
                    {
                        Private___46_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __33_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_intnl_SystemObject != null)
                {
                    return Private___33_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___33_intnl_SystemObject != null)
                {
                    Private___33_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_NL_PlayerCharacter != null)
                {
                    return Private___1_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_NL_PlayerCharacter != null)
                {
                    Private___1_intnl_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal long? __10_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemInt64 != null)
                {
                    return Private___10_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_SystemInt64 != null)
                    {
                        Private___10_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __61_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___61_intnl_SystemBoolean != null)
                {
                    return Private___61_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___61_intnl_SystemBoolean != null)
                    {
                        Private___61_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __98_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___98_intnl_SystemBoolean != null)
                {
                    return Private___98_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___98_intnl_SystemBoolean != null)
                    {
                        Private___98_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_returnValue_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_returnValue_Boolean != null)
                {
                    return Private___0_returnValue_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_returnValue_Boolean != null)
                    {
                        Private___0_returnValue_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __51_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___51_intnl_SystemInt32 != null)
                {
                    return Private___51_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___51_intnl_SystemInt32 != null)
                    {
                        Private___51_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? killEventDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_killEventDelay != null)
                {
                    return Private_killEventDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_killEventDelay != null)
                    {
                        Private_killEventDelay.Value = value.Value;
                    }
                }
            }
        }

        internal int? __57_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___57_intnl_SystemInt32 != null)
                {
                    return Private___57_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___57_intnl_SystemInt32 != null)
                    {
                        Private___57_intnl_SystemInt32.Value = value.Value;
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

        internal bool? __53_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___53_intnl_SystemBoolean != null)
                {
                    return Private___53_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___53_intnl_SystemBoolean != null)
                    {
                        Private___53_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __80_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___80_const_intnl_SystemString != null)
                {
                    return Private___80_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___80_const_intnl_SystemString != null)
                {
                    Private___80_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal long? __3_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_const_intnl_SystemInt64 != null)
                {
                    return Private___3_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_const_intnl_SystemInt64 != null)
                    {
                        Private___3_const_intnl_SystemInt64.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_mp_hitCharacter_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_hitCharacter_NL_PlayerCharacter != null)
                {
                    return Private___0_mp_hitCharacter_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_hitCharacter_NL_PlayerCharacter != null)
                {
                    Private___0_mp_hitCharacter_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal string __99_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___99_const_intnl_SystemString != null)
                {
                    return Private___99_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___99_const_intnl_SystemString != null)
                {
                    Private___99_const_intnl_SystemString.Value = value;
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

        internal VRC.Udon.UdonBehaviour updateManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_updateManager != null)
                {
                    return Private_updateManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_updateManager != null)
                {
                    Private_updateManager.Value = value;
                }
            }
        }

        internal int? __0_mp_playerIndex_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_playerIndex_Int32 != null)
                {
                    return Private___0_mp_playerIndex_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_playerIndex_Int32 != null)
                    {
                        Private___0_mp_playerIndex_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform[] lobbySpawnPoints
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lobbySpawnPoints != null)
                {
                    return Private_lobbySpawnPoints.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_lobbySpawnPoints != null)
                {
                    Private_lobbySpawnPoints.Value = value;
                }
            }
        }

        internal string __74_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___74_const_intnl_SystemString != null)
                {
                    return Private___74_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___74_const_intnl_SystemString != null)
                {
                    Private___74_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.SDK3.Components.VRCPickup __3_intnl_VRCSDK3ComponentsVRCPickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_VRCSDK3ComponentsVRCPickup != null)
                {
                    return Private___3_intnl_VRCSDK3ComponentsVRCPickup.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_VRCSDK3ComponentsVRCPickup != null)
                {
                    Private___3_intnl_VRCSDK3ComponentsVRCPickup.Value = value;
                }
            }
        }

        internal bool? __136_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___136_intnl_SystemBoolean != null)
                {
                    return Private___136_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___136_intnl_SystemBoolean != null)
                    {
                        Private___136_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_zValue_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_zValue_Single != null)
                {
                    return Private___0_mp_zValue_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_zValue_Single != null)
                    {
                        Private___0_mp_zValue_Single.Value = value.Value;
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

        internal string __57_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___57_const_intnl_SystemString != null)
                {
                    return Private___57_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___57_const_intnl_SystemString != null)
                {
                    Private___57_const_intnl_SystemString.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi __31_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___31_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___31_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___31_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal short? __34_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_SystemInt16 != null)
                {
                    return Private___34_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_intnl_SystemInt16 != null)
                    {
                        Private___34_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_playerSlotUI_NLI_PlayerSlotUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_playerSlotUI_NLI_PlayerSlotUI != null)
                {
                    return Private___0_playerSlotUI_NLI_PlayerSlotUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_playerSlotUI_NLI_PlayerSlotUI != null)
                {
                    Private___0_playerSlotUI_NLI_PlayerSlotUI.Value = value;
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

        internal VRC.Udon.UdonBehaviour __4_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineComponent != null)
                {
                    return Private___4_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_UnityEngineComponent != null)
                {
                    Private___4_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal bool? __56_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___56_intnl_SystemBoolean != null)
                {
                    return Private___56_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___56_intnl_SystemBoolean != null)
                    {
                        Private___56_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? maxMoney
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_maxMoney != null)
                {
                    return Private_maxMoney.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_maxMoney != null)
                    {
                        Private_maxMoney.Value = value.Value;
                    }
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

        internal int? __66_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___66_intnl_SystemInt32 != null)
                {
                    return Private___66_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___66_intnl_SystemInt32 != null)
                    {
                        Private___66_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject roomSpectateObj
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_roomSpectateObj != null)
                {
                    return Private_roomSpectateObj.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_roomSpectateObj != null)
                {
                    Private_roomSpectateObj.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __32_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___32_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___32_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___32_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] allCharacters
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_allCharacters != null)
                {
                    return Private_allCharacters.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_allCharacters != null)
                {
                    Private_allCharacters.Value = value;
                }
            }
        }

        internal long? __4_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemInt64 != null)
                {
                    return Private___4_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemInt64 != null)
                    {
                        Private___4_intnl_SystemInt64.Value = value.Value;
                    }
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

        internal string __81_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___81_const_intnl_SystemString != null)
                {
                    return Private___81_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___81_const_intnl_SystemString != null)
                {
                    Private___81_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __60_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___60_const_intnl_SystemString != null)
                {
                    return Private___60_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___60_const_intnl_SystemString != null)
                {
                    Private___60_const_intnl_SystemString.Value = value;
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

        internal string __86_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___86_const_intnl_SystemString != null)
                {
                    return Private___86_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___86_const_intnl_SystemString != null)
                {
                    Private___86_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal short? __14_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemInt16 != null)
                {
                    return Private___14_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_intnl_SystemInt16 != null)
                    {
                        Private___14_intnl_SystemInt16.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __2_intnl_NL_Gun
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_NL_Gun != null)
                {
                    return Private___2_intnl_NL_Gun.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_NL_Gun != null)
                {
                    Private___2_intnl_NL_Gun.Value = value;
                }
            }
        }

        internal short? __0_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemInt16 != null)
                {
                    return Private___0_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemInt16 != null)
                    {
                        Private___0_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __90_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___90_intnl_SystemBoolean != null)
                {
                    return Private___90_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___90_intnl_SystemBoolean != null)
                    {
                        Private___90_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour nameBoard
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_nameBoard != null)
                {
                    return Private_nameBoard.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_nameBoard != null)
                {
                    Private_nameBoard.Value = value;
                }
            }
        }

        internal float? __0_mp_delay_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_delay_Single != null)
                {
                    return Private___0_mp_delay_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_delay_Single != null)
                    {
                        Private___0_mp_delay_Single.Value = value.Value;
                    }
                }
            }
        }

        internal string __75_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___75_const_intnl_SystemString != null)
                {
                    return Private___75_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___75_const_intnl_SystemString != null)
                {
                    Private___75_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __130_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___130_intnl_SystemBoolean != null)
                {
                    return Private___130_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___130_intnl_SystemBoolean != null)
                    {
                        Private___130_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? currency
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_currency != null)
                {
                    return Private_currency.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_currency != null)
                    {
                        Private_currency.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __33_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___33_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___33_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___33_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal bool? __62_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___62_intnl_SystemBoolean != null)
                {
                    return Private___62_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___62_intnl_SystemBoolean != null)
                    {
                        Private___62_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal short? __17_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemInt16 != null)
                {
                    return Private___17_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemInt16 != null)
                    {
                        Private___17_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCPickup __1_intnl_VRCSDK3ComponentsVRCPickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_VRCSDK3ComponentsVRCPickup != null)
                {
                    return Private___1_intnl_VRCSDK3ComponentsVRCPickup.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_VRCSDK3ComponentsVRCPickup != null)
                {
                    Private___1_intnl_VRCSDK3ComponentsVRCPickup.Value = value;
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

        internal short? __5_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemObject != null)
                {
                    return Private___5_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemObject != null)
                    {
                        Private___5_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __112_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___112_intnl_SystemBoolean != null)
                {
                    return Private___112_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___112_intnl_SystemBoolean != null)
                    {
                        Private___112_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __88_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___88_intnl_SystemBoolean != null)
                {
                    return Private___88_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___88_intnl_SystemBoolean != null)
                    {
                        Private___88_intnl_SystemBoolean.Value = value.Value;
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

        internal bool? __131_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___131_intnl_SystemBoolean != null)
                {
                    return Private___131_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___131_intnl_SystemBoolean != null)
                    {
                        Private___131_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal string __61_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___61_const_intnl_SystemString != null)
                {
                    return Private___61_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___61_const_intnl_SystemString != null)
                {
                    Private___61_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __66_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___66_const_intnl_SystemString != null)
                {
                    return Private___66_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___66_const_intnl_SystemString != null)
                {
                    Private___66_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __10_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___10_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___10_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___10_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

        internal bool? __97_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___97_intnl_SystemBoolean != null)
                {
                    return Private___97_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___97_intnl_SystemBoolean != null)
                    {
                        Private___97_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? ammoReserve
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ammoReserve != null)
                {
                    return Private_ammoReserve.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_ammoReserve != null)
                    {
                        Private_ammoReserve.Value = value.Value;
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

        internal float? __10_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemSingle != null)
                {
                    return Private___10_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_SystemSingle != null)
                    {
                        Private___10_intnl_SystemSingle.Value = value.Value;
                    }
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

        internal float? teleportCheckTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teleportCheckTime != null)
                {
                    return Private_teleportCheckTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teleportCheckTime != null)
                    {
                        Private_teleportCheckTime.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_resultCharacter_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_resultCharacter_NL_PlayerCharacter != null)
                {
                    return Private___1_resultCharacter_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_resultCharacter_NL_PlayerCharacter != null)
                {
                    Private___1_resultCharacter_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal string __83_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___83_const_intnl_SystemString != null)
                {
                    return Private___83_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___83_const_intnl_SystemString != null)
                {
                    Private___83_const_intnl_SystemString.Value = value;
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

        internal int? __0_index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_index_Int32 != null)
                {
                    return Private___0_index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_index_Int32 != null)
                    {
                        Private___0_index_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __7_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemSingle != null)
                {
                    return Private___7_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemSingle != null)
                    {
                        Private___7_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal short? __37_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_intnl_SystemObject != null)
                {
                    return Private___37_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_intnl_SystemObject != null)
                    {
                        Private___37_intnl_SystemObject.Value = value.Value;
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

        internal short? __26_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___26_intnl_SystemInt16 != null)
                {
                    return Private___26_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___26_intnl_SystemInt16 != null)
                    {
                        Private___26_intnl_SystemInt16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __59_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___59_intnl_SystemBoolean != null)
                {
                    return Private___59_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___59_intnl_SystemBoolean != null)
                    {
                        Private___59_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __2_intnl_returnValSymbol_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_returnValSymbol_NL_PlayerCharacter != null)
                {
                    return Private___2_intnl_returnValSymbol_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_returnValSymbol_NL_PlayerCharacter != null)
                {
                    Private___2_intnl_returnValSymbol_NL_PlayerCharacter.Value = value;
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

        internal int? __39_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___39_intnl_SystemInt32 != null)
                {
                    return Private___39_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___39_intnl_SystemInt32 != null)
                    {
                        Private___39_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __77_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___77_const_intnl_SystemString != null)
                {
                    return Private___77_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___77_const_intnl_SystemString != null)
                {
                    Private___77_const_intnl_SystemString.Value = value;
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

        internal float? initialAmmoSpawnRate
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_initialAmmoSpawnRate != null)
                {
                    return Private_initialAmmoSpawnRate.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_initialAmmoSpawnRate != null)
                    {
                        Private_initialAmmoSpawnRate.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform worldOrigin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_worldOrigin != null)
                {
                    return Private_worldOrigin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_worldOrigin != null)
                {
                    Private_worldOrigin.Value = value;
                }
            }
        }

        internal short? __38_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_intnl_SystemObject != null)
                {
                    return Private___38_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___38_intnl_SystemObject != null)
                    {
                        Private___38_intnl_SystemObject.Value = value.Value;
                    }
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

        internal bool? __78_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___78_intnl_SystemBoolean != null)
                {
                    return Private___78_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___78_intnl_SystemBoolean != null)
                    {
                        Private___78_intnl_SystemBoolean.Value = value.Value;
                    }
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

        internal bool? __80_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___80_intnl_SystemBoolean != null)
                {
                    return Private___80_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___80_intnl_SystemBoolean != null)
                    {
                        Private___80_intnl_SystemBoolean.Value = value.Value;
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

        internal short? __4_intnl_SystemInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemInt16 != null)
                {
                    return Private___4_intnl_SystemInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemInt16 != null)
                    {
                        Private___4_intnl_SystemInt16.Value = value.Value;
                    }
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

        internal string __63_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___63_const_intnl_SystemString != null)
                {
                    return Private___63_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___63_const_intnl_SystemString != null)
                {
                    Private___63_const_intnl_SystemString.Value = value;
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

        internal long? __3_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemInt64 != null)
                {
                    return Private___3_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemInt64 != null)
                    {
                        Private___3_intnl_SystemInt64.Value = value.Value;
                    }
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

        internal UnityEngine.Transform __3_intnl_UnityEngineTransform
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

        internal VRC.Udon.UdonBehaviour __1_intnl_NL_Gun
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_NL_Gun != null)
                {
                    return Private___1_intnl_NL_Gun.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_NL_Gun != null)
                {
                    Private___1_intnl_NL_Gun.Value = value;
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

        internal bool? forceInfestedTeleport
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_forceInfestedTeleport != null)
                {
                    return Private_forceInfestedTeleport.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_forceInfestedTeleport != null)
                    {
                        Private_forceInfestedTeleport.Value = value.Value;
                    }
                }
            }
        }

        internal short? __34_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_SystemObject != null)
                {
                    return Private___34_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_intnl_SystemObject != null)
                    {
                        Private___34_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal string __90_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___90_const_intnl_SystemString != null)
                {
                    return Private___90_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___90_const_intnl_SystemString != null)
                {
                    Private___90_const_intnl_SystemString.Value = value;
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

        internal bool? __31_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_intnl_SystemObject != null)
                {
                    return Private___31_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___31_intnl_SystemObject != null)
                    {
                        Private___31_intnl_SystemObject.Value = value.Value;
                    }
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

        internal float? __2_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_const_intnl_SystemSingle != null)
                {
                    return Private___2_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_const_intnl_SystemSingle != null)
                    {
                        Private___2_const_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __128_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___128_intnl_SystemBoolean != null)
                {
                    return Private___128_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___128_intnl_SystemBoolean != null)
                    {
                        Private___128_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? keyCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyCount != null)
                {
                    return Private_keyCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_keyCount != null)
                    {
                        Private_keyCount.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __87_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___87_intnl_SystemBoolean != null)
                {
                    return Private___87_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___87_intnl_SystemBoolean != null)
                    {
                        Private___87_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __51_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___51_intnl_SystemBoolean != null)
                {
                    return Private___51_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___51_intnl_SystemBoolean != null)
                    {
                        Private___51_intnl_SystemBoolean.Value = value.Value;
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

        internal bool? __107_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___107_intnl_SystemBoolean != null)
                {
                    return Private___107_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___107_intnl_SystemBoolean != null)
                    {
                        Private___107_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.SDKBase.VRC_Pickup.PickupHand? __0_const_intnl_VRCSDKBaseVRC_PickupPickupHand
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_VRCSDKBaseVRC_PickupPickupHand != null)
                {
                    return Private___0_const_intnl_VRCSDKBaseVRC_PickupPickupHand.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_VRCSDKBaseVRC_PickupPickupHand != null)
                    {
                        Private___0_const_intnl_VRCSDKBaseVRC_PickupPickupHand.Value = value.Value;
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

        internal int? infestedPlayerCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_infestedPlayerCount != null)
                {
                    return Private_infestedPlayerCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_infestedPlayerCount != null)
                    {
                        Private_infestedPlayerCount.Value = value.Value;
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

        internal float? __8_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemSingle != null)
                {
                    return Private___8_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemSingle != null)
                    {
                        Private___8_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __52_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___52_const_intnl_SystemString != null)
                {
                    return Private___52_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___52_const_intnl_SystemString != null)
                {
                    Private___52_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __70_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___70_intnl_SystemBoolean != null)
                {
                    return Private___70_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___70_intnl_SystemBoolean != null)
                    {
                        Private___70_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __129_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___129_intnl_SystemBoolean != null)
                {
                    return Private___129_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___129_intnl_SystemBoolean != null)
                    {
                        Private___129_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __49_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___49_intnl_SystemInt32 != null)
                {
                    return Private___49_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___49_intnl_SystemInt32 != null)
                    {
                        Private___49_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? __49_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___49_intnl_SystemBoolean != null)
                {
                    return Private___49_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___49_intnl_SystemBoolean != null)
                    {
                        Private___49_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __91_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___91_const_intnl_SystemString != null)
                {
                    return Private___91_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___91_const_intnl_SystemString != null)
                {
                    Private___91_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __96_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___96_const_intnl_SystemString != null)
                {
                    return Private___96_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___96_const_intnl_SystemString != null)
                {
                    Private___96_const_intnl_SystemString.Value = value;
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

        internal bool? __132_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___132_intnl_SystemBoolean != null)
                {
                    return Private___132_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___132_intnl_SystemBoolean != null)
                    {
                        Private___132_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of GameManager

        #region AstroUdonVariables  of GameManager

        private AstroUdonVariable<int> Private___35_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___33_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_allWorkshopManagers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___32_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___77_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRC_Pickup.PickupHand> Private___1_const_intnl_VRCSDKBaseVRC_PickupPickupHand { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___29_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___48_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___7_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___21_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___3_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___52_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___12_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___93_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___1_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___30_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_humanJumpHeight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___118_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_identityRevealTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___0_intnl_NL_WorkshopManagerArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___0_intnl_NL_PlayerCharacterArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___95_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___13_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___49_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___13_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___33_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___10_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___16_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___72_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___119_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___35_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___45_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___50_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___13_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___42_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_spectateCharacters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___2_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___6_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___93_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___53_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___4_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___8_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_ammoSpawnDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_workshop_NL_WorkshopManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_weaponManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___12_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___7_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_killRewards { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___22_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___96_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___34_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_this_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___65_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___85_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_playerIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___62_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_spawnPoint_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCPickup> Private___1_itemInHand_VRC_Pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___104_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___103_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_gunInHand_NL_Gun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_humanPlayerCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___5_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_initialMoney { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___24_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_mp_delta_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___105_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___28_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___2_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_cameraSpectate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_character_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___58_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___83_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_initialAmmo { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___138_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___75_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_returnValSymbol_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isJoinedGame { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___64_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___40_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___8_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___139_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___99_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___38_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_damageTake_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___25_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___86_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___29_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___23_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___59_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_resultCharacter_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___84_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___56_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_character_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___73_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___41_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___46_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___85_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___64_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___9_character_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_NL_UpdateManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___20_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_NLI_PlayerSlotUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___0_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___76_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_effectManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___78_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___23_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_killEventTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___91_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___36_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___35_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_tempNum_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___0_const_intnl_NL_WorkshopManagerArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_teleportCheckTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___48_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isInfested { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___2_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___89_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___36_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___16_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___8_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___65_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NL_Gun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___106_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___43_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___34_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___79_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___37_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___9_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___127_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasEnterHeroMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___87_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_mapLayoutSet { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioSource> Private_audioSource_Lobby { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___28_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___31_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___37_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___12_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_gameOverTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___34_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___27_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___22_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___68_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___100_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___14_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___79_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___92_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___5_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___26_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___28_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___81_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___1_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_infestedRunningSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_playerID_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___68_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___67_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___50_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___101_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___94_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int[]> Private_killedPlayerList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_allPlayerSlots { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_initialMoneySpawnRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___35_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___44_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___21_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___26_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___54_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___13_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___51_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___41_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___47_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___26_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___56_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___71_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___117_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___95_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_delta_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___19_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___60_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___29_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___82_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___20_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___59_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___37_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___6_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___3_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_workshop_NL_WorkshopManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___64_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___21_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___5_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___70_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___61_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_weaponSkinManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___67_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___67_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___23_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___53_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NL_UpdateManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___5_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_inGameZValue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___97_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_delta_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___29_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___82_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___72_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___4_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___102_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___15_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___71_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___3_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___7_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerHUD { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___76_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___124_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___16_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___123_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___32_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___24_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___125_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___62_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___12_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___27_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___55_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___0_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___52_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___58_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___11_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___137_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_NL_Gun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCPickup> Private___0_itemInHand_VRC_Pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___73_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___15_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___2_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___14_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_infestedJumpHeight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___19_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_lobbyManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___1_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___35_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_character_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___114_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___100_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NL_WorkshopManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NLI_LobbyManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___32_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___113_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___29_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasRevealIdentity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___15_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___50_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___7_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___22_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___115_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NL_SpectateCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___9_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___30_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___44_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___65_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___92_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_lastHuman_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___24_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_tempNum_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___57_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___33_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_gameStateCheckTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___126_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_NL_WorkshopManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_inGameTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___6_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___19_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___2_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___8_character_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___45_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___63_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___88_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___108_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___120_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___8_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___94_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_NLI_GameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioSource> Private_audioSource_InGame { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___15_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___25_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___109_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___40_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___66_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___121_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___22_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_maxAmmo { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___89_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___68_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___18_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___43_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___9_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_humanRunningSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___134_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___47_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___133_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___58_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___4_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_NL_WorkshopManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___30_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___9_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_playerName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___17_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___20_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___116_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___0_const_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___135_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___6_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___69_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___60_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___23_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___36_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___2_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___63_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___84_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___110_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isHero { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___24_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_gunInHand_NL_Gun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___54_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isPlayerInVR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___69_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___4_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___38_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___111_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_gameStateCheckTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_infestRewards { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_targetID_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___31_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NLI_PlayerSlotUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___55_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___25_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___55_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_latencyProtection { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_ammoSpawnTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___98_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___54_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___39_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___74_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___11_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___122_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___25_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___46_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___33_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___10_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___61_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___98_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_returnValue_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___51_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_killEventDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___57_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___53_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___80_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___3_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_hitCharacter_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___99_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_updateManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_playerIndex_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform[]> Private_lobbySpawnPoints { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___74_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCPickup> Private___3_intnl_VRCSDK3ComponentsVRCPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___136_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_zValue_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___27_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___57_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___31_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___34_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_playerSlotUI_NLI_PlayerSlotUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___4_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___56_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_maxMoney { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___42_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___66_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_roomSpectateObj { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___32_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_allCharacters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___4_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___81_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___60_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___28_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___86_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___14_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_NL_Gun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___0_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___90_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_nameBoard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_delay_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___75_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___130_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_currency { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___33_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___62_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___17_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCPickup> Private___1_intnl_VRCSDK3ComponentsVRCPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___5_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___112_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___88_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___131_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___61_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___66_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___10_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___97_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_ammoReserve { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___14_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_teleportCheckTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_resultCharacter_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___83_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___37_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___26_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___59_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_returnValSymbol_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___18_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___39_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___77_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___30_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_initialAmmoSpawnRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_worldOrigin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___38_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___78_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___80_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___4_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___24_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___63_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___3_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___13_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___3_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_NL_Gun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_forceInfestedTeleport { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___34_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___90_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___31_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___31_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___27_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___36_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___128_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_keyCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___87_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___51_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___107_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRC_Pickup.PickupHand> Private___0_const_intnl_VRCSDKBaseVRC_PickupPickupHand { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_infestedPlayerCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___52_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___70_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___129_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___49_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___49_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___91_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___96_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___132_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of GameManager

    }
}