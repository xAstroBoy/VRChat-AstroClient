using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.Infested
{
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class Infested_CharacterObject : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public Infested_CharacterObject(IntPtr ptr) : base(ptr)
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
                var obj = gameObject.FindUdonEvent("Local_SetInfested");
                if (obj != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    PlayerCharacterObject = obj.RawItem;
                    Initialize_PlayerCharacterObject();
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


        private  GameObject _InfestedBar { get; set; }
        internal GameObject InfestedBar
        {
            get
            {
                if(_InfestedBar == null)
                {
                    _InfestedBar = this.transform.FindObject("FloatingHUD/HealthBar/HealthBar_Infested/Infested_Shadow").gameObject;
                }
                return _InfestedBar;
            }
        }

        private GameObject _HumanBar { get; set; }
        internal GameObject HumanBar
        {
            get
            {
                if (_HumanBar == null)
                {
                    _HumanBar = this.transform.FindObject("FloatingHUD/HealthBar/HealthBar_Human/Human_Shadow").gameObject;
                }
                return _HumanBar;
            }
        }
        private void OnDestroy()
        {
            ClientEventActions.OnRoomLeft -= OnRoomLeft;
            Cleanup_PlayerCharacterObject();
        }

        private RawUdonBehaviour PlayerCharacterObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_PlayerCharacterObject()
        {
            Private___18_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__18_const_intnl_SystemInt32");
            Private___0_mp_newIndex_Int32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__0_mp_newIndex_Int32");
            Private___33_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__33_const_intnl_SystemString");
            Private___20_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__20_const_intnl_SystemInt32");
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__23_intnl_SystemBoolean");
            Private___77_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__77_intnl_SystemBoolean");
            Private___17_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__17_intnl_UnityEngineVector3");
            Private___48_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__48_const_intnl_SystemString");
            Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__15_intnl_SystemInt32");
            Private___1_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "__1_intnl_UnityEngineGameObject");
            Private___13_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__13_intnl_UnityEngineVector3");
            Private___3_intnl_SystemInt16 = new AstroUdonVariable<short>(PlayerCharacterObject, "__3_intnl_SystemInt16");
            Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__12_intnl_SystemInt32");
            Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__52_intnl_SystemBoolean");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__3_const_intnl_SystemString");
            Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__6_const_intnl_SystemInt32");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___0_huntBegin_Boolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_huntBegin_Boolean");
            Private_floatingHUD = new AstroUdonVariable<UnityEngine.Transform>(PlayerCharacterObject, "floatingHUD");
            Private___93_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__93_const_intnl_SystemString");
            Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__26_intnl_SystemBoolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_const_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(PlayerCharacterObject, "__1_intnl_UnityEngineQuaternion");
            Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__41_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PlayerCharacterObject, "__1_intnl_UnityEngineTransform");
            Private___3_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__3_const_intnl_SystemSingle");
            Private___118_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__118_intnl_SystemBoolean");
            Private_huntMarkDistanceText2 = new AstroUdonVariable<UnityEngine.UI.Text>(PlayerCharacterObject, "huntMarkDistanceText2");
            Private___95_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__95_intnl_SystemBoolean");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__1_const_intnl_SystemInt32");
            Private___49_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__49_const_intnl_SystemString");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__1_intnl_SystemInt32");
            Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__16_const_intnl_exitJumpLoc_UInt32");
            Private___72_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__72_const_intnl_SystemString");
            Private___119_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__119_intnl_SystemBoolean");
            Private___15_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__15_intnl_SystemSingle");
            Private_sync_infestedKilled = new AstroUdonVariable<short>(PlayerCharacterObject, "sync_infestedKilled");
            Private___0_mp_newSpectateCharacter_NL_SpectateCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__0_mp_newSpectateCharacter_NL_SpectateCharacter");
            Private___93_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__93_intnl_SystemBoolean");
            Private___0_originOffset_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__0_originOffset_Vector3");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__0_const_intnl_SystemString");
            Private___21_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__21_intnl_SystemSingle");
            Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__42_intnl_SystemBoolean");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__0_const_intnl_SystemSingle");
            Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__29_intnl_SystemBoolean");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__1_intnl_SystemSingle");
            Private___96_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__96_intnl_SystemBoolean");
            Private___7_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__7_const_intnl_SystemInt32");
            Private___0_this_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PlayerCharacterObject, "__0_this_intnl_UnityEngineTransform");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__5_intnl_SystemBoolean");
            Private___85_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__85_intnl_SystemBoolean");
            Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__10_const_intnl_exitJumpLoc_UInt32");
            Private___11_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__11_const_intnl_SystemInt32");
            Private___104_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__104_intnl_SystemBoolean");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___103_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__103_intnl_SystemBoolean");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__15_intnl_SystemBoolean");
            Private___0_mp_newWorldOrigin_Transform = new AstroUdonVariable<UnityEngine.Transform>(PlayerCharacterObject, "__0_mp_newWorldOrigin_Transform");
            Private___105_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__105_intnl_SystemBoolean");
            Private_hasSpawnInfestedEffect = new AstroUdonVariable<bool>(PlayerCharacterObject, "hasSpawnInfestedEffect");
            Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__34_intnl_SystemBoolean");
            Private___28_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__28_const_intnl_SystemString");
            Private___58_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__58_const_intnl_SystemString");
            Private___83_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__83_intnl_SystemBoolean");
            Private_maxHealth = new AstroUdonVariable<int>(PlayerCharacterObject, "maxHealth");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__6_const_intnl_SystemString");
            Private___0_mp_damageValue_Int32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__0_mp_damageValue_Int32");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__21_intnl_SystemBoolean");
            Private___138_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__138_intnl_SystemBoolean");
            Private___75_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__75_intnl_SystemBoolean");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___6_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__6_const_intnl_SystemSingle");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__13_intnl_SystemBoolean");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__4_const_intnl_SystemInt32");
            Private___64_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__64_intnl_SystemBoolean");
            Private___40_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__40_const_intnl_SystemString");
            Private___139_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__139_intnl_SystemBoolean");
            Private___99_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__99_intnl_SystemBoolean");
            Private___86_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__86_intnl_SystemBoolean");
            Private___29_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__29_const_intnl_SystemString");
            Private___1_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__1_const_intnl_SystemSingle");
            Private___59_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__59_const_intnl_SystemString");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__5_intnl_SystemSingle");
            Private___25_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__25_const_intnl_SystemInt32");
            Private___84_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__84_const_intnl_SystemString");
            Private_humanTitle = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "humanTitle");
            Private___0_mp_newGameManager_NLI_GameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__0_mp_newGameManager_NLI_GameManager");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__18_intnl_SystemInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__16_intnl_SystemBoolean");
            Private___73_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__73_intnl_SystemBoolean");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__14_const_intnl_SystemString");
            Private___9_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__9_intnl_UnityEngineVector3");
            Private___4_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "__4_intnl_UnityEngineGameObject");
            Private___19_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__19_intnl_SystemSingle");
            Private___41_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__41_const_intnl_SystemString");
            Private___46_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__46_const_intnl_SystemString");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__7_intnl_SystemBoolean");
            Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__20_intnl_SystemInt32");
            Private___85_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__85_const_intnl_SystemString");
            Private___64_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__64_const_intnl_SystemString");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__22_intnl_SystemBoolean");
            Private___20_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__20_intnl_SystemObject");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__8_intnl_UnityEngineVector3");
            Private___76_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__76_intnl_SystemBoolean");
            Private___78_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__78_const_intnl_SystemString");
            Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__23_intnl_SystemInt32");
            Private___91_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__91_intnl_SystemBoolean");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__7_const_intnl_SystemString");
            Private_footStepSound = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "footStepSound");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__15_const_intnl_SystemString");
            Private_isInfested = new AstroUdonVariable<bool>(PlayerCharacterObject, "isInfested");
            Private___0_newHealthRatio_Single = new AstroUdonVariable<float>(PlayerCharacterObject, "__0_newHealthRatio_Single");
            Private___89_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__89_intnl_SystemBoolean");
            Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__5_const_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PlayerCharacterObject, "__refl_const_intnl_udonTypeID");
            Private___65_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__65_const_intnl_SystemString");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__4_intnl_SystemBoolean");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__11_intnl_SystemSingle");
            Private___106_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__106_intnl_SystemBoolean");
            Private___16_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__16_const_intnl_SystemInt32");
            Private___43_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__43_const_intnl_SystemString");
            Private___79_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__79_const_intnl_SystemString");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__19_intnl_SystemBoolean");
            Private_sync_Health = new AstroUdonVariable<short>(PlayerCharacterObject, "sync_Health");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PlayerCharacterObject, "__refl_const_intnl_udonTypeName");
            Private___127_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__127_intnl_SystemBoolean");
            Private___87_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__87_const_intnl_SystemString");
            Private___0_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__1_intnl_SystemBoolean");
            Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__38_intnl_SystemBoolean");
            Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__14_intnl_SystemInt32");
            Private_playerUISlot = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "playerUISlot");
            Private___7_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__7_intnl_UnityEngineVector3");
            Private___2_intnl_NL_EffectManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__2_intnl_NL_EffectManager");
            Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__12_const_intnl_exitJumpLoc_UInt32");
            Private___34_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__34_const_intnl_SystemString");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__17_const_intnl_SystemString");
            Private___100_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__100_intnl_SystemBoolean");
            Private___17_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__17_const_intnl_SystemInt32");
            Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__11_intnl_SystemInt32");
            Private___79_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__79_intnl_SystemBoolean");
            Private___92_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__92_intnl_SystemBoolean");
            Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__17_intnl_SystemInt32");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__4_const_intnl_SystemString");
            Private_hasInitialized = new AstroUdonVariable<bool>(PlayerCharacterObject, "hasInitialized");
            Private___81_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__81_intnl_SystemBoolean");
            Private___1_intnl_SystemInt16 = new AstroUdonVariable<short>(PlayerCharacterObject, "__1_intnl_SystemInt16");
            Private___10_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__10_intnl_SystemString");
            Private___68_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__68_intnl_SystemBoolean");
            Private_hitboxFadeSpeed = new AstroUdonVariable<float>(PlayerCharacterObject, "hitboxFadeSpeed");
            Private___67_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__67_const_intnl_SystemString");
            Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__20_const_intnl_SystemString");
            Private___50_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__50_const_intnl_SystemString");
            Private___4_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__4_const_intnl_SystemSingle");
            Private___101_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__101_intnl_SystemBoolean");
            Private_trackingPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PlayerCharacterObject, "trackingPlayer");
            Private___35_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__35_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__11_intnl_SystemBoolean");
            Private_headPosition = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "headPosition");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__2_intnl_SystemInt32");
            Private_hasTeleported = new AstroUdonVariable<bool>(PlayerCharacterObject, "hasTeleported");
            Private_isAlive = new AstroUdonVariable<bool>(PlayerCharacterObject, "isAlive");
            Private___8_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__8_const_intnl_SystemInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__30_intnl_SystemBoolean");
            Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__54_intnl_SystemBoolean");
            Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__21_const_intnl_SystemString");
            Private___51_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__51_const_intnl_SystemString");
            Private___26_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__26_const_intnl_SystemString");
            Private___56_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__56_const_intnl_SystemString");
            Private___71_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__71_intnl_SystemBoolean");
            Private___117_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__117_intnl_SystemBoolean");
            Private___4_intnl_SystemObject = new AstroUdonVariable<int>(PlayerCharacterObject, "__4_intnl_SystemObject");
            Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__9_const_intnl_exitJumpLoc_UInt32");
            Private___60_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__60_intnl_SystemBoolean");
            Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__37_intnl_SystemBoolean");
            Private___82_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__82_intnl_SystemBoolean");
            Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__20_const_intnl_exitJumpLoc_UInt32");
            Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__9_intnl_SystemInt32");
            Private___37_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__37_const_intnl_SystemString");
            Private___6_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__6_intnl_UnityEngineVector3");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__2_intnl_SystemSingle");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__3_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_intnl_returnValSymbol_Boolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__12_intnl_SystemBoolean");
            Private___9_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__9_intnl_SystemString");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__6_const_intnl_exitJumpLoc_UInt32");
            Private___5_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__5_const_intnl_SystemSingle");
            Private___70_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__70_const_intnl_SystemString");
            Private_local_Health = new AstroUdonVariable<int>(PlayerCharacterObject, "local_Health");
            Private___67_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__67_intnl_SystemBoolean");
            Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__23_const_intnl_SystemString");
            Private___53_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__53_const_intnl_SystemString");
            Private___5_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__5_intnl_UnityEngineVector3");
            Private___14_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__14_const_intnl_SystemInt32");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__6_intnl_SystemInt32");
            Private___9_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__9_const_intnl_SystemInt32");
            Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__44_intnl_SystemBoolean");
            Private___17_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__17_intnl_SystemSingle");
            Private_infestedIndicator = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "infestedIndicator");
            Private___82_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__82_const_intnl_SystemString");
            Private___72_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__72_intnl_SystemBoolean");
            Private___19_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__19_const_intnl_SystemInt32");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_intnl_SystemBoolean");
            Private___4_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__4_intnl_UnityEngineVector3");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__9_intnl_SystemSingle");
            Private___102_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__102_intnl_SystemBoolean");
            Private___21_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__21_const_intnl_SystemInt32");
            Private___71_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__71_const_intnl_SystemString");
            Private___76_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__76_const_intnl_SystemString");
            Private___124_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__124_intnl_SystemBoolean");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__12_const_intnl_SystemString");
            Private___123_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__123_intnl_SystemBoolean");
            Private___0_this_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "__0_this_intnl_UnityEngineGameObject");
            Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "__0_intnl_UnityEngineGameObject");
            Private___125_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__125_intnl_SystemBoolean");
            Private___62_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__62_const_intnl_SystemString");
            Private___17_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerCharacterObject, "__17_intnl_SystemObject");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__6_intnl_SystemSingle");
            Private___18_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerCharacterObject, "__18_intnl_SystemObject");
            Private___0_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(PlayerCharacterObject, "__0_intnl_UnityEngineQuaternion");
            Private___58_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__58_intnl_SystemBoolean");
            Private___137_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__137_intnl_SystemBoolean");
            Private___73_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__73_const_intnl_SystemString");
            Private_damageSync = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "damageSync");
            Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__15_const_intnl_exitJumpLoc_UInt32");
            Private___16_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__16_intnl_SystemSingle");
            Private_isLocalPlayer = new AstroUdonVariable<bool>(PlayerCharacterObject, "isLocalPlayer");
            Private___11_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerCharacterObject, "__11_intnl_SystemObject");
            Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__19_const_intnl_exitJumpLoc_UInt32");
            Private___12_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__12_const_intnl_SystemInt32");
            Private_lobbyManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "lobbyManager");
            Private___114_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__114_intnl_SystemBoolean");
            Private___32_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__32_const_intnl_SystemString");
            Private___113_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__113_intnl_SystemBoolean");
            Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__35_intnl_SystemBoolean");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__50_intnl_SystemBoolean");
            Private___115_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__115_intnl_SystemBoolean");
            Private___1_mp_damageValue_Int32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__1_mp_damageValue_Int32");
            Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__24_intnl_SystemBoolean");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__9_const_intnl_SystemString");
            Private_healthBarDefaultOffset = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "healthBarDefaultOffset");
            Private___13_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__13_const_intnl_SystemInt32");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__0_intnl_returnTarget_UInt32");
            Private___0_mp_newUISlot_NLI_PlayerSlotUI = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__0_mp_newUISlot_NLI_PlayerSlotUI");
            Private_delayedSyncTimer = new AstroUdonVariable<float>(PlayerCharacterObject, "delayedSyncTimer");
            Private___144_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__144_intnl_SystemBoolean");
            Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__48_intnl_SystemBoolean");
            Private___143_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__143_intnl_SystemBoolean");
            Private___44_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__44_const_intnl_SystemString");
            Private___65_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__65_intnl_SystemBoolean");
            Private___92_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__92_const_intnl_SystemString");
            Private___0_mp_isInfested_Boolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_mp_isInfested_Boolean");
            Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__33_intnl_SystemBoolean");
            Private___14_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__14_intnl_UnityEngineVector3");
            Private___0_height_Single = new AstroUdonVariable<float>(PlayerCharacterObject, "__0_height_Single");
            Private___57_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__57_intnl_SystemBoolean");
            Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__10_intnl_SystemInt32");
            Private___126_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__126_intnl_SystemBoolean");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__0_const_intnl_SystemUInt32");
            Private___10_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__10_intnl_UnityEngineVector3");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__9_intnl_SystemBoolean");
            Private___19_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerCharacterObject, "__19_intnl_SystemObject");
            Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__13_intnl_SystemInt32");
            Private___2_intnl_SystemInt16 = new AstroUdonVariable<short>(PlayerCharacterObject, "__2_intnl_SystemInt16");
            Private___45_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__45_const_intnl_SystemString");
            Private___63_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__63_intnl_SystemBoolean");
            Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__36_intnl_SystemBoolean");
            Private___88_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__88_const_intnl_SystemString");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__0_intnl_SystemSingle");
            Private___108_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__108_intnl_SystemBoolean");
            Private___16_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__16_intnl_UnityEngineVector3");
            Private_characterIndex = new AstroUdonVariable<int>(PlayerCharacterObject, "characterIndex");
            Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__40_intnl_SystemBoolean");
            Private___120_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__120_intnl_SystemBoolean");
            Private___0_mp_checkGameState_Boolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_mp_checkGameState_Boolean");
            Private___12_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__12_intnl_UnityEngineVector3");
            Private___94_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__94_intnl_SystemBoolean");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__18_const_intnl_SystemString");
            Private___109_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__109_intnl_SystemBoolean");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__13_intnl_SystemSingle");
            Private___66_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__66_intnl_SystemBoolean");
            Private___121_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__121_intnl_SystemBoolean");
            Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__22_intnl_SystemInt32");
            Private___0_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PlayerCharacterObject, "__0_mp_player_VRCPlayerApi");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__4_intnl_SystemInt32");
            Private___89_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__89_const_intnl_SystemString");
            Private___68_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__68_const_intnl_SystemString");
            Private_isBeingInfested = new AstroUdonVariable<bool>(PlayerCharacterObject, "isBeingInfested");
            Private_huntMarkDistanceText = new AstroUdonVariable<UnityEngine.UI.Text>(PlayerCharacterObject, "huntMarkDistanceText");
            Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__14_intnl_SystemSingle");
            Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__3_intnl_UnityEngineVector3");
            Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__47_intnl_SystemBoolean");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__4_intnl_SystemString");
            Private___134_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__134_intnl_SystemBoolean");
            Private___47_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__47_const_intnl_SystemString");
            Private_onPlayerLeftPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PlayerCharacterObject, "onPlayerLeftPlayer");
            Private___133_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__133_intnl_SystemBoolean");
            Private___10_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__10_const_intnl_SystemInt32");
            Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__19_const_intnl_SystemString");
            Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__17_const_intnl_exitJumpLoc_UInt32");
            Private___116_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__116_intnl_SystemBoolean");
            Private___0_this_intnl_NL_PlayerCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__0_this_intnl_NL_PlayerCharacter");
            Private_hitboxMinTrans = new AstroUdonVariable<float>(PlayerCharacterObject, "hitboxMinTrans");
            Private___135_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__135_intnl_SystemBoolean");
            Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__39_intnl_SystemBoolean");
            Private___69_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__69_const_intnl_SystemString");
            Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__28_intnl_SystemBoolean");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__6_intnl_SystemBoolean");
            Private___20_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__20_intnl_SystemSingle");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__4_intnl_SystemSingle");
            Private___11_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__11_intnl_SystemString");
            Private___84_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__84_intnl_SystemBoolean");
            Private___110_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__110_intnl_SystemBoolean");
            Private_isHero = new AstroUdonVariable<bool>(PlayerCharacterObject, "isHero");
            Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__24_const_intnl_SystemString");
            Private___54_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__54_const_intnl_SystemString");
            Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__16_intnl_SystemInt32");
            Private___69_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__69_intnl_SystemBoolean");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__12_intnl_SystemSingle");
            Private___38_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__38_const_intnl_SystemString");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__14_intnl_SystemBoolean");
            Private___111_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__111_intnl_SystemBoolean");
            Private___24_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__24_const_intnl_SystemInt32");
            Private___140_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__140_intnl_SystemBoolean");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__3_intnl_SystemInt32");
            Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__31_intnl_SystemBoolean");
            Private___55_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__55_intnl_SystemBoolean");
            Private___25_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__25_const_intnl_SystemString");
            Private___55_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__55_const_intnl_SystemString");
            Private___5_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "__5_intnl_UnityEngineGameObject");
            Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__11_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__8_intnl_SystemBoolean");
            Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__20_intnl_SystemBoolean");
            Private___0_isLethalHit_Boolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__0_isLethalHit_Boolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__2_intnl_UnityEngineVector3");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__3_intnl_SystemString");
            Private___141_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__141_intnl_SystemBoolean");
            Private___39_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__39_const_intnl_SystemString");
            Private___74_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__74_intnl_SystemBoolean");
            Private___0_newPlayer_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PlayerCharacterObject, "__0_newPlayer_VRCPlayerApi");
            Private___122_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__122_intnl_SystemBoolean");
            Private___0_intnl_NL_EffectManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__0_intnl_NL_EffectManager");
            Private___61_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__61_intnl_SystemBoolean");
            Private___98_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__98_intnl_SystemBoolean");
            Private_humanIndicator = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "humanIndicator");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__1_intnl_UnityEngineVector3");
            Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__53_intnl_SystemBoolean");
            Private___80_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__80_const_intnl_SystemString");
            Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__27_intnl_SystemBoolean");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__3_intnl_SystemSingle");
            Private_updateManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "updateManager");
            Private_infestedTitle = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "infestedTitle");
            Private___74_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__74_const_intnl_SystemString");
            Private___136_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__136_intnl_SystemBoolean");
            Private___0_const_intnl_UnityEngineHumanBodyBones = new AstroUdonVariable<UnityEngine.HumanBodyBones>(PlayerCharacterObject, "__0_const_intnl_UnityEngineHumanBodyBones");
            Private___27_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__27_const_intnl_SystemString");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__0_intnl_UnityEngineVector3");
            Private___57_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__57_const_intnl_SystemString");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__10_const_intnl_SystemString");
            Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__32_intnl_SystemBoolean");
            Private___56_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__56_intnl_SystemBoolean");
            Private_colliderObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "colliderObject");
            Private___42_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__42_const_intnl_SystemString");
            Private___18_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__18_intnl_SystemSingle");
            Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__45_intnl_SystemBoolean");
            Private___81_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__81_const_intnl_SystemString");
            Private___60_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__60_const_intnl_SystemString");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__7_intnl_SystemInt32");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PlayerCharacterObject, "__0_intnl_UnityEngineTransform");
            Private___86_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__86_const_intnl_SystemString");
            Private_localPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PlayerCharacterObject, "localPlayer");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__1_const_intnl_SystemBoolean");
            Private___0_intnl_SystemInt16 = new AstroUdonVariable<short>(PlayerCharacterObject, "__0_intnl_SystemInt16");
            Private___90_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__90_intnl_SystemBoolean");
            Private___75_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__75_const_intnl_SystemString");
            Private___130_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__130_intnl_SystemBoolean");
            Private___0_mp_newPlayerID_Int32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__0_mp_newPlayerID_Int32");
            Private___22_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__22_const_intnl_SystemInt32");
            Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(PlayerCharacterObject, "__0_intnl_UnityEngineColor");
            Private___62_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__62_intnl_SystemBoolean");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__11_const_intnl_SystemString");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__16_const_intnl_SystemString");
            Private___5_intnl_SystemObject = new AstroUdonVariable<int>(PlayerCharacterObject, "__5_intnl_SystemObject");
            Private___112_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__112_intnl_SystemBoolean");
            Private___88_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__88_intnl_SystemBoolean");
            Private___131_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__131_intnl_SystemBoolean");
            Private_hitboxColorTemp = new AstroUdonVariable<UnityEngine.Color>(PlayerCharacterObject, "hitboxColorTemp");
            Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__43_intnl_SystemBoolean");
            Private_spectateCharacter = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "spectateCharacter");
            Private___61_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__61_const_intnl_SystemString");
            Private___15_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__15_intnl_UnityEngineVector3");
            Private___66_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__66_const_intnl_SystemString");
            Private___15_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__15_const_intnl_SystemInt32");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__18_intnl_SystemBoolean");
            Private___97_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__97_intnl_SystemBoolean");
            Private_local_displayHealth = new AstroUdonVariable<int>(PlayerCharacterObject, "local_displayHealth");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__10_intnl_SystemSingle");
            Private___11_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__11_intnl_UnityEngineVector3");
            Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__14_const_intnl_exitJumpLoc_UInt32");
            Private___23_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__23_const_intnl_SystemInt32");
            Private___142_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__142_intnl_SystemBoolean");
            Private___0_mp_newUpdateManager_NL_UpdateManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__0_mp_newUpdateManager_NL_UpdateManager");
            Private___83_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__83_const_intnl_SystemString");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__3_const_intnl_SystemInt32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__7_intnl_SystemSingle");
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(PlayerCharacterObject, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
            Private_sync_playerID = new AstroUdonVariable<short>(PlayerCharacterObject, "sync_playerID");
            Private___0_mp_newLobbyManager_NLI_LobbyManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "__0_mp_newLobbyManager_NLI_LobbyManager");
            Private___59_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__59_intnl_SystemBoolean");
            Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__18_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__46_intnl_SystemBoolean");
            Private___77_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__77_const_intnl_SystemString");
            Private___30_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__30_const_intnl_SystemString");
            Private_worldOrigin = new AstroUdonVariable<UnityEngine.Transform>(PlayerCharacterObject, "worldOrigin");
            Private_sync_humanInfested = new AstroUdonVariable<short>(PlayerCharacterObject, "sync_humanInfested");
            Private_gameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "gameManager");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__13_const_intnl_SystemString");
            Private___78_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__78_intnl_SystemBoolean");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__8_intnl_SystemInt32");
            Private_stabRange = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerCharacterObject, "stabRange");
            Private___80_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__80_intnl_SystemBoolean");
            Private_huntMark = new AstroUdonVariable<UnityEngine.GameObject>(PlayerCharacterObject, "huntMark");
            Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__19_intnl_SystemInt32");
            Private___0_distance_Single = new AstroUdonVariable<float>(PlayerCharacterObject, "__0_distance_Single");
            Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__24_intnl_SystemInt32");
            Private___63_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__63_const_intnl_SystemString");
            Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__13_const_intnl_exitJumpLoc_UInt32");
            Private_hitBoxAssist = new AstroUdonVariable<UnityEngine.SpriteRenderer>(PlayerCharacterObject, "hitBoxAssist");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__10_intnl_SystemBoolean");
            Private___90_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__90_const_intnl_SystemString");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__2_const_intnl_SystemString");
            Private___31_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__31_const_intnl_SystemString");
            Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__21_intnl_SystemInt32");
            Private___36_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__36_const_intnl_SystemString");
            Private___0_mp_hitPoint_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerCharacterObject, "__0_mp_hitPoint_Vector3");
            Private___2_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__2_const_intnl_SystemSingle");
            Private___128_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__128_intnl_SystemBoolean");
            Private_healthRegenTimer = new AstroUdonVariable<float>(PlayerCharacterObject, "healthRegenTimer");
            Private_playerName = new AstroUdonVariable<string>(PlayerCharacterObject, "playerName");
            Private___87_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__87_intnl_SystemBoolean");
            Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__51_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerCharacterObject, "__0_const_intnl_SystemInt32");
            Private___107_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__107_intnl_SystemBoolean");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerCharacterObject, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__25_intnl_SystemBoolean");
            Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__22_const_intnl_SystemString");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerCharacterObject, "__8_intnl_SystemSingle");
            Private___52_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__52_const_intnl_SystemString");
            Private___70_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__70_intnl_SystemBoolean");
            Private___129_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__129_intnl_SystemBoolean");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__17_intnl_SystemBoolean");
            Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__49_intnl_SystemBoolean");
            Private___91_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerCharacterObject, "__91_const_intnl_SystemString");
            Private___132_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerCharacterObject, "__132_intnl_SystemBoolean");
        }

        private void Cleanup_PlayerCharacterObject()
        {
            Private___18_const_intnl_SystemInt32 = null;
            Private___0_mp_newIndex_Int32 = null;
            Private___33_const_intnl_SystemString = null;
            Private___20_const_intnl_SystemInt32 = null;
            Private___23_intnl_SystemBoolean = null;
            Private___77_intnl_SystemBoolean = null;
            Private___17_intnl_UnityEngineVector3 = null;
            Private___48_const_intnl_SystemString = null;
            Private___15_intnl_SystemInt32 = null;
            Private___1_intnl_UnityEngineGameObject = null;
            Private___13_intnl_UnityEngineVector3 = null;
            Private___3_intnl_SystemInt16 = null;
            Private___12_intnl_SystemInt32 = null;
            Private___52_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemString = null;
            Private___6_const_intnl_SystemInt32 = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_huntBegin_Boolean = null;
            Private_floatingHUD = null;
            Private___93_const_intnl_SystemString = null;
            Private___26_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineQuaternion = null;
            Private___41_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineTransform = null;
            Private___3_const_intnl_SystemSingle = null;
            Private___118_intnl_SystemBoolean = null;
            Private_huntMarkDistanceText2 = null;
            Private___95_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___49_const_intnl_SystemString = null;
            Private___1_intnl_SystemInt32 = null;
            Private___16_const_intnl_exitJumpLoc_UInt32 = null;
            Private___72_const_intnl_SystemString = null;
            Private___119_intnl_SystemBoolean = null;
            Private___15_intnl_SystemSingle = null;
            Private_sync_infestedKilled = null;
            Private___0_mp_newSpectateCharacter_NL_SpectateCharacter = null;
            Private___93_intnl_SystemBoolean = null;
            Private___0_originOffset_Vector3 = null;
            Private___0_const_intnl_SystemString = null;
            Private___21_intnl_SystemSingle = null;
            Private___42_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemSingle = null;
            Private___29_intnl_SystemBoolean = null;
            Private___1_intnl_SystemSingle = null;
            Private___96_intnl_SystemBoolean = null;
            Private___7_const_intnl_SystemInt32 = null;
            Private___0_this_intnl_UnityEngineTransform = null;
            Private___5_intnl_SystemBoolean = null;
            Private___85_intnl_SystemBoolean = null;
            Private___10_const_intnl_exitJumpLoc_UInt32 = null;
            Private___11_const_intnl_SystemInt32 = null;
            Private___104_intnl_SystemBoolean = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___103_intnl_SystemBoolean = null;
            Private___15_intnl_SystemBoolean = null;
            Private___0_mp_newWorldOrigin_Transform = null;
            Private___105_intnl_SystemBoolean = null;
            Private_hasSpawnInfestedEffect = null;
            Private___34_intnl_SystemBoolean = null;
            Private___28_const_intnl_SystemString = null;
            Private___58_const_intnl_SystemString = null;
            Private___83_intnl_SystemBoolean = null;
            Private_maxHealth = null;
            Private___6_const_intnl_SystemString = null;
            Private___0_mp_damageValue_Int32 = null;
            Private___21_intnl_SystemBoolean = null;
            Private___138_intnl_SystemBoolean = null;
            Private___75_intnl_SystemBoolean = null;
            Private___5_const_intnl_exitJumpLoc_UInt32 = null;
            Private___6_const_intnl_SystemSingle = null;
            Private___13_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private___64_intnl_SystemBoolean = null;
            Private___40_const_intnl_SystemString = null;
            Private___139_intnl_SystemBoolean = null;
            Private___99_intnl_SystemBoolean = null;
            Private___86_intnl_SystemBoolean = null;
            Private___29_const_intnl_SystemString = null;
            Private___1_const_intnl_SystemSingle = null;
            Private___59_const_intnl_SystemString = null;
            Private___5_intnl_SystemSingle = null;
            Private___25_const_intnl_SystemInt32 = null;
            Private___84_const_intnl_SystemString = null;
            Private_humanTitle = null;
            Private___0_mp_newGameManager_NLI_GameManager = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___18_intnl_SystemInt32 = null;
            Private___16_intnl_SystemBoolean = null;
            Private___73_intnl_SystemBoolean = null;
            Private___14_const_intnl_SystemString = null;
            Private___9_intnl_UnityEngineVector3 = null;
            Private___4_intnl_UnityEngineGameObject = null;
            Private___19_intnl_SystemSingle = null;
            Private___41_const_intnl_SystemString = null;
            Private___46_const_intnl_SystemString = null;
            Private___7_intnl_SystemBoolean = null;
            Private___20_intnl_SystemInt32 = null;
            Private___85_const_intnl_SystemString = null;
            Private___64_const_intnl_SystemString = null;
            Private___22_intnl_SystemBoolean = null;
            Private___20_intnl_SystemObject = null;
            Private___7_const_intnl_exitJumpLoc_UInt32 = null;
            Private___8_intnl_UnityEngineVector3 = null;
            Private___76_intnl_SystemBoolean = null;
            Private___78_const_intnl_SystemString = null;
            Private___23_intnl_SystemInt32 = null;
            Private___91_intnl_SystemBoolean = null;
            Private___7_const_intnl_SystemString = null;
            Private_footStepSound = null;
            Private___15_const_intnl_SystemString = null;
            Private_isInfested = null;
            Private___0_newHealthRatio_Single = null;
            Private___89_intnl_SystemBoolean = null;
            Private___5_const_intnl_SystemInt32 = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___65_const_intnl_SystemString = null;
            Private___4_intnl_SystemBoolean = null;
            Private___11_intnl_SystemSingle = null;
            Private___106_intnl_SystemBoolean = null;
            Private___16_const_intnl_SystemInt32 = null;
            Private___43_const_intnl_SystemString = null;
            Private___79_const_intnl_SystemString = null;
            Private___19_intnl_SystemBoolean = null;
            Private_sync_Health = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___127_intnl_SystemBoolean = null;
            Private___87_const_intnl_SystemString = null;
            Private___0_intnl_SystemObject = null;
            Private___1_intnl_SystemBoolean = null;
            Private___38_intnl_SystemBoolean = null;
            Private___14_intnl_SystemInt32 = null;
            Private_playerUISlot = null;
            Private___7_intnl_UnityEngineVector3 = null;
            Private___2_intnl_NL_EffectManager = null;
            Private___12_const_intnl_exitJumpLoc_UInt32 = null;
            Private___34_const_intnl_SystemString = null;
            Private___17_const_intnl_SystemString = null;
            Private___100_intnl_SystemBoolean = null;
            Private___17_const_intnl_SystemInt32 = null;
            Private___11_intnl_SystemInt32 = null;
            Private___79_intnl_SystemBoolean = null;
            Private___92_intnl_SystemBoolean = null;
            Private___17_intnl_SystemInt32 = null;
            Private___4_const_intnl_SystemString = null;
            Private_hasInitialized = null;
            Private___81_intnl_SystemBoolean = null;
            Private___1_intnl_SystemInt16 = null;
            Private___10_intnl_SystemString = null;
            Private___68_intnl_SystemBoolean = null;
            Private_hitboxFadeSpeed = null;
            Private___67_const_intnl_SystemString = null;
            Private___20_const_intnl_SystemString = null;
            Private___50_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemSingle = null;
            Private___101_intnl_SystemBoolean = null;
            Private_trackingPlayer = null;
            Private___35_const_intnl_SystemString = null;
            Private___11_intnl_SystemBoolean = null;
            Private_headPosition = null;
            Private___2_intnl_SystemInt32 = null;
            Private_hasTeleported = null;
            Private_isAlive = null;
            Private___8_const_intnl_SystemInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___30_intnl_SystemBoolean = null;
            Private___54_intnl_SystemBoolean = null;
            Private___21_const_intnl_SystemString = null;
            Private___51_const_intnl_SystemString = null;
            Private___26_const_intnl_SystemString = null;
            Private___56_const_intnl_SystemString = null;
            Private___71_intnl_SystemBoolean = null;
            Private___117_intnl_SystemBoolean = null;
            Private___4_intnl_SystemObject = null;
            Private___9_const_intnl_exitJumpLoc_UInt32 = null;
            Private___60_intnl_SystemBoolean = null;
            Private___37_intnl_SystemBoolean = null;
            Private___82_intnl_SystemBoolean = null;
            Private___20_const_intnl_exitJumpLoc_UInt32 = null;
            Private___9_intnl_SystemInt32 = null;
            Private___37_const_intnl_SystemString = null;
            Private___6_intnl_UnityEngineVector3 = null;
            Private___2_intnl_SystemSingle = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___12_intnl_SystemBoolean = null;
            Private___9_intnl_SystemString = null;
            Private___6_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_const_intnl_SystemSingle = null;
            Private___70_const_intnl_SystemString = null;
            Private_local_Health = null;
            Private___67_intnl_SystemBoolean = null;
            Private___23_const_intnl_SystemString = null;
            Private___53_const_intnl_SystemString = null;
            Private___5_intnl_UnityEngineVector3 = null;
            Private___14_const_intnl_SystemInt32 = null;
            Private___6_intnl_SystemInt32 = null;
            Private___9_const_intnl_SystemInt32 = null;
            Private___44_intnl_SystemBoolean = null;
            Private___17_intnl_SystemSingle = null;
            Private_infestedIndicator = null;
            Private___82_const_intnl_SystemString = null;
            Private___72_intnl_SystemBoolean = null;
            Private___19_const_intnl_SystemInt32 = null;
            Private___0_intnl_SystemBoolean = null;
            Private___4_intnl_UnityEngineVector3 = null;
            Private___9_intnl_SystemSingle = null;
            Private___102_intnl_SystemBoolean = null;
            Private___21_const_intnl_SystemInt32 = null;
            Private___71_const_intnl_SystemString = null;
            Private___76_const_intnl_SystemString = null;
            Private___124_intnl_SystemBoolean = null;
            Private___12_const_intnl_SystemString = null;
            Private___123_intnl_SystemBoolean = null;
            Private___0_this_intnl_UnityEngineGameObject = null;
            Private___0_intnl_UnityEngineGameObject = null;
            Private___125_intnl_SystemBoolean = null;
            Private___62_const_intnl_SystemString = null;
            Private___17_intnl_SystemObject = null;
            Private___8_const_intnl_SystemString = null;
            Private___6_intnl_SystemSingle = null;
            Private___18_intnl_SystemObject = null;
            Private___0_intnl_UnityEngineQuaternion = null;
            Private___58_intnl_SystemBoolean = null;
            Private___137_intnl_SystemBoolean = null;
            Private___73_const_intnl_SystemString = null;
            Private_damageSync = null;
            Private___15_const_intnl_exitJumpLoc_UInt32 = null;
            Private___16_intnl_SystemSingle = null;
            Private_isLocalPlayer = null;
            Private___11_intnl_SystemObject = null;
            Private___19_const_intnl_exitJumpLoc_UInt32 = null;
            Private___12_const_intnl_SystemInt32 = null;
            Private_lobbyManager = null;
            Private___114_intnl_SystemBoolean = null;
            Private___32_const_intnl_SystemString = null;
            Private___113_intnl_SystemBoolean = null;
            Private___35_intnl_SystemBoolean = null;
            Private___8_const_intnl_exitJumpLoc_UInt32 = null;
            Private___50_intnl_SystemBoolean = null;
            Private___115_intnl_SystemBoolean = null;
            Private___1_mp_damageValue_Int32 = null;
            Private___24_intnl_SystemBoolean = null;
            Private___9_const_intnl_SystemString = null;
            Private_healthBarDefaultOffset = null;
            Private___13_const_intnl_SystemInt32 = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___0_mp_newUISlot_NLI_PlayerSlotUI = null;
            Private_delayedSyncTimer = null;
            Private___144_intnl_SystemBoolean = null;
            Private___48_intnl_SystemBoolean = null;
            Private___143_intnl_SystemBoolean = null;
            Private___44_const_intnl_SystemString = null;
            Private___65_intnl_SystemBoolean = null;
            Private___92_const_intnl_SystemString = null;
            Private___0_mp_isInfested_Boolean = null;
            Private___33_intnl_SystemBoolean = null;
            Private___14_intnl_UnityEngineVector3 = null;
            Private___0_height_Single = null;
            Private___57_intnl_SystemBoolean = null;
            Private___10_intnl_SystemInt32 = null;
            Private___126_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___10_intnl_UnityEngineVector3 = null;
            Private___9_intnl_SystemBoolean = null;
            Private___19_intnl_SystemObject = null;
            Private___13_intnl_SystemInt32 = null;
            Private___2_intnl_SystemInt16 = null;
            Private___45_const_intnl_SystemString = null;
            Private___63_intnl_SystemBoolean = null;
            Private___36_intnl_SystemBoolean = null;
            Private___88_const_intnl_SystemString = null;
            Private___0_intnl_SystemSingle = null;
            Private___108_intnl_SystemBoolean = null;
            Private___16_intnl_UnityEngineVector3 = null;
            Private_characterIndex = null;
            Private___40_intnl_SystemBoolean = null;
            Private___120_intnl_SystemBoolean = null;
            Private___0_mp_checkGameState_Boolean = null;
            Private___12_intnl_UnityEngineVector3 = null;
            Private___94_intnl_SystemBoolean = null;
            Private___18_const_intnl_SystemString = null;
            Private___109_intnl_SystemBoolean = null;
            Private___13_intnl_SystemSingle = null;
            Private___66_intnl_SystemBoolean = null;
            Private___121_intnl_SystemBoolean = null;
            Private___22_intnl_SystemInt32 = null;
            Private___0_mp_player_VRCPlayerApi = null;
            Private___4_intnl_SystemInt32 = null;
            Private___89_const_intnl_SystemString = null;
            Private___68_const_intnl_SystemString = null;
            Private_isBeingInfested = null;
            Private_huntMarkDistanceText = null;
            Private___14_intnl_SystemSingle = null;
            Private___3_intnl_UnityEngineVector3 = null;
            Private___47_intnl_SystemBoolean = null;
            Private___4_intnl_SystemString = null;
            Private___134_intnl_SystemBoolean = null;
            Private___47_const_intnl_SystemString = null;
            Private_onPlayerLeftPlayer = null;
            Private___133_intnl_SystemBoolean = null;
            Private___10_const_intnl_SystemInt32 = null;
            Private___19_const_intnl_SystemString = null;
            Private___17_const_intnl_exitJumpLoc_UInt32 = null;
            Private___116_intnl_SystemBoolean = null;
            Private___0_this_intnl_NL_PlayerCharacter = null;
            Private_hitboxMinTrans = null;
            Private___135_intnl_SystemBoolean = null;
            Private___39_intnl_SystemBoolean = null;
            Private___69_const_intnl_SystemString = null;
            Private___28_intnl_SystemBoolean = null;
            Private___6_intnl_SystemBoolean = null;
            Private___20_intnl_SystemSingle = null;
            Private___4_intnl_SystemSingle = null;
            Private___11_intnl_SystemString = null;
            Private___84_intnl_SystemBoolean = null;
            Private___110_intnl_SystemBoolean = null;
            Private_isHero = null;
            Private___24_const_intnl_SystemString = null;
            Private___54_const_intnl_SystemString = null;
            Private___16_intnl_SystemInt32 = null;
            Private___69_intnl_SystemBoolean = null;
            Private___12_intnl_SystemSingle = null;
            Private___38_const_intnl_SystemString = null;
            Private___14_intnl_SystemBoolean = null;
            Private___111_intnl_SystemBoolean = null;
            Private___24_const_intnl_SystemInt32 = null;
            Private___140_intnl_SystemBoolean = null;
            Private___3_intnl_SystemInt32 = null;
            Private___31_intnl_SystemBoolean = null;
            Private___55_intnl_SystemBoolean = null;
            Private___25_const_intnl_SystemString = null;
            Private___55_const_intnl_SystemString = null;
            Private___5_intnl_UnityEngineGameObject = null;
            Private___11_const_intnl_exitJumpLoc_UInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___20_intnl_SystemBoolean = null;
            Private___0_isLethalHit_Boolean = null;
            Private___2_intnl_UnityEngineVector3 = null;
            Private___3_intnl_SystemString = null;
            Private___141_intnl_SystemBoolean = null;
            Private___39_const_intnl_SystemString = null;
            Private___74_intnl_SystemBoolean = null;
            Private___0_newPlayer_VRCPlayerApi = null;
            Private___122_intnl_SystemBoolean = null;
            Private___0_intnl_NL_EffectManager = null;
            Private___61_intnl_SystemBoolean = null;
            Private___98_intnl_SystemBoolean = null;
            Private_humanIndicator = null;
            Private___1_intnl_UnityEngineVector3 = null;
            Private___53_intnl_SystemBoolean = null;
            Private___80_const_intnl_SystemString = null;
            Private___27_intnl_SystemBoolean = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private_updateManager = null;
            Private_infestedTitle = null;
            Private___74_const_intnl_SystemString = null;
            Private___136_intnl_SystemBoolean = null;
            Private___0_const_intnl_UnityEngineHumanBodyBones = null;
            Private___27_const_intnl_SystemString = null;
            Private___0_intnl_UnityEngineVector3 = null;
            Private___57_const_intnl_SystemString = null;
            Private___10_const_intnl_SystemString = null;
            Private___32_intnl_SystemBoolean = null;
            Private___56_intnl_SystemBoolean = null;
            Private_colliderObject = null;
            Private___42_const_intnl_SystemString = null;
            Private___18_intnl_SystemSingle = null;
            Private___45_intnl_SystemBoolean = null;
            Private___81_const_intnl_SystemString = null;
            Private___60_const_intnl_SystemString = null;
            Private___7_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineTransform = null;
            Private___86_const_intnl_SystemString = null;
            Private_localPlayer = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___0_intnl_SystemInt16 = null;
            Private___90_intnl_SystemBoolean = null;
            Private___75_const_intnl_SystemString = null;
            Private___130_intnl_SystemBoolean = null;
            Private___0_mp_newPlayerID_Int32 = null;
            Private___22_const_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineColor = null;
            Private___62_intnl_SystemBoolean = null;
            Private___11_const_intnl_SystemString = null;
            Private___16_const_intnl_SystemString = null;
            Private___5_intnl_SystemObject = null;
            Private___112_intnl_SystemBoolean = null;
            Private___88_intnl_SystemBoolean = null;
            Private___131_intnl_SystemBoolean = null;
            Private_hitboxColorTemp = null;
            Private___43_intnl_SystemBoolean = null;
            Private_spectateCharacter = null;
            Private___61_const_intnl_SystemString = null;
            Private___15_intnl_UnityEngineVector3 = null;
            Private___66_const_intnl_SystemString = null;
            Private___15_const_intnl_SystemInt32 = null;
            Private___18_intnl_SystemBoolean = null;
            Private___97_intnl_SystemBoolean = null;
            Private_local_displayHealth = null;
            Private___2_intnl_SystemBoolean = null;
            Private___10_intnl_SystemSingle = null;
            Private___11_intnl_UnityEngineVector3 = null;
            Private___14_const_intnl_exitJumpLoc_UInt32 = null;
            Private___23_const_intnl_SystemInt32 = null;
            Private___142_intnl_SystemBoolean = null;
            Private___0_mp_newUpdateManager_NL_UpdateManager = null;
            Private___83_const_intnl_SystemString = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___7_intnl_SystemSingle = null;
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = null;
            Private_sync_playerID = null;
            Private___0_mp_newLobbyManager_NLI_LobbyManager = null;
            Private___59_intnl_SystemBoolean = null;
            Private___18_const_intnl_exitJumpLoc_UInt32 = null;
            Private___46_intnl_SystemBoolean = null;
            Private___77_const_intnl_SystemString = null;
            Private___30_const_intnl_SystemString = null;
            Private_worldOrigin = null;
            Private_sync_humanInfested = null;
            Private_gameManager = null;
            Private___13_const_intnl_SystemString = null;
            Private___78_intnl_SystemBoolean = null;
            Private___8_intnl_SystemInt32 = null;
            Private_stabRange = null;
            Private___80_intnl_SystemBoolean = null;
            Private_huntMark = null;
            Private___19_intnl_SystemInt32 = null;
            Private___0_distance_Single = null;
            Private___24_intnl_SystemInt32 = null;
            Private___63_const_intnl_SystemString = null;
            Private___13_const_intnl_exitJumpLoc_UInt32 = null;
            Private_hitBoxAssist = null;
            Private___10_intnl_SystemBoolean = null;
            Private___90_const_intnl_SystemString = null;
            Private___2_const_intnl_SystemString = null;
            Private___31_const_intnl_SystemString = null;
            Private___21_intnl_SystemInt32 = null;
            Private___36_const_intnl_SystemString = null;
            Private___0_mp_hitPoint_Vector3 = null;
            Private___2_const_intnl_SystemSingle = null;
            Private___128_intnl_SystemBoolean = null;
            Private_healthRegenTimer = null;
            Private_playerName = null;
            Private___87_intnl_SystemBoolean = null;
            Private___51_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___107_intnl_SystemBoolean = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___25_intnl_SystemBoolean = null;
            Private___22_const_intnl_SystemString = null;
            Private___8_intnl_SystemSingle = null;
            Private___52_const_intnl_SystemString = null;
            Private___70_intnl_SystemBoolean = null;
            Private___129_intnl_SystemBoolean = null;
            Private___17_intnl_SystemBoolean = null;
            Private___49_intnl_SystemBoolean = null;
            Private___91_const_intnl_SystemString = null;
            Private___132_intnl_SystemBoolean = null;
        }

        #region Getter / Setters AstroUdonVariables  of PlayerCharacterObject

        internal int? __18_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_const_intnl_SystemInt32 != null)
                {
                    return Private___18_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_const_intnl_SystemInt32 != null)
                    {
                        Private___18_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_newIndex_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newIndex_Int32 != null)
                {
                    return Private___0_mp_newIndex_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_newIndex_Int32 != null)
                    {
                        Private___0_mp_newIndex_Int32.Value = value.Value;
                    }
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

        internal int? __20_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_const_intnl_SystemInt32 != null)
                {
                    return Private___20_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_const_intnl_SystemInt32 != null)
                    {
                        Private___20_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal UnityEngine.Vector3? __17_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_UnityEngineVector3 != null)
                {
                    return Private___17_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_UnityEngineVector3 != null)
                    {
                        Private___17_intnl_UnityEngineVector3.Value = value.Value;
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

        internal UnityEngine.Vector3? __13_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_UnityEngineVector3 != null)
                {
                    return Private___13_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_UnityEngineVector3 != null)
                    {
                        Private___13_intnl_UnityEngineVector3.Value = value.Value;
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

        internal int? __6_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_const_intnl_SystemInt32 != null)
                {
                    return Private___6_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_const_intnl_SystemInt32 != null)
                    {
                        Private___6_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? __0_huntBegin_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_huntBegin_Boolean != null)
                {
                    return Private___0_huntBegin_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_huntBegin_Boolean != null)
                    {
                        Private___0_huntBegin_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform floatingHUD
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_floatingHUD != null)
                {
                    return Private_floatingHUD.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_floatingHUD != null)
                {
                    Private_floatingHUD.Value = value;
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

        internal UnityEngine.Transform __1_intnl_UnityEngineTransform
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

        internal UnityEngine.UI.Text huntMarkDistanceText2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_huntMarkDistanceText2 != null)
                {
                    return Private_huntMarkDistanceText2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_huntMarkDistanceText2 != null)
                {
                    Private_huntMarkDistanceText2.Value = value;
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

        internal float? __15_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemSingle != null)
                {
                    return Private___15_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_intnl_SystemSingle != null)
                    {
                        Private___15_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal short? sync_infestedKilled
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_sync_infestedKilled != null)
                {
                    return Private_sync_infestedKilled.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_sync_infestedKilled != null)
                    {
                        Private_sync_infestedKilled.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_mp_newSpectateCharacter_NL_SpectateCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newSpectateCharacter_NL_SpectateCharacter != null)
                {
                    return Private___0_mp_newSpectateCharacter_NL_SpectateCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_newSpectateCharacter_NL_SpectateCharacter != null)
                {
                    Private___0_mp_newSpectateCharacter_NL_SpectateCharacter.Value = value;
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

        internal UnityEngine.Vector3? __0_originOffset_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_originOffset_Vector3 != null)
                {
                    return Private___0_originOffset_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_originOffset_Vector3 != null)
                    {
                        Private___0_originOffset_Vector3.Value = value.Value;
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

        internal float? __21_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemSingle != null)
                {
                    return Private___21_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_intnl_SystemSingle != null)
                    {
                        Private___21_intnl_SystemSingle.Value = value.Value;
                    }
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

        internal int? __7_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_const_intnl_SystemInt32 != null)
                {
                    return Private___7_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_const_intnl_SystemInt32 != null)
                    {
                        Private___7_const_intnl_SystemInt32.Value = value.Value;
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

        internal int? __11_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_const_intnl_SystemInt32 != null)
                {
                    return Private___11_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_const_intnl_SystemInt32 != null)
                    {
                        Private___11_const_intnl_SystemInt32.Value = value.Value;
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

        internal UnityEngine.Transform __0_mp_newWorldOrigin_Transform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newWorldOrigin_Transform != null)
                {
                    return Private___0_mp_newWorldOrigin_Transform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_newWorldOrigin_Transform != null)
                {
                    Private___0_mp_newWorldOrigin_Transform.Value = value;
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

        internal bool? hasSpawnInfestedEffect
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasSpawnInfestedEffect != null)
                {
                    return Private_hasSpawnInfestedEffect.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasSpawnInfestedEffect != null)
                    {
                        Private_hasSpawnInfestedEffect.Value = value.Value;
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

        internal int? maxHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_maxHealth != null)
                {
                    return Private_maxHealth.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_maxHealth != null)
                    {
                        Private_maxHealth.Value = value.Value;
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

        internal int? __0_mp_damageValue_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_damageValue_Int32 != null)
                {
                    return Private___0_mp_damageValue_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_damageValue_Int32 != null)
                    {
                        Private___0_mp_damageValue_Int32.Value = value.Value;
                    }
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

        internal float? __6_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_const_intnl_SystemSingle != null)
                {
                    return Private___6_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_const_intnl_SystemSingle != null)
                    {
                        Private___6_const_intnl_SystemSingle.Value = value.Value;
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

        internal int? __25_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_const_intnl_SystemInt32 != null)
                {
                    return Private___25_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___25_const_intnl_SystemInt32 != null)
                    {
                        Private___25_const_intnl_SystemInt32.Value = value.Value;
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

        internal UnityEngine.GameObject humanTitle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_humanTitle != null)
                {
                    return Private_humanTitle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_humanTitle != null)
                {
                    Private_humanTitle.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_mp_newGameManager_NLI_GameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newGameManager_NLI_GameManager != null)
                {
                    return Private___0_mp_newGameManager_NLI_GameManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_newGameManager_NLI_GameManager != null)
                {
                    Private___0_mp_newGameManager_NLI_GameManager.Value = value;
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

        internal UnityEngine.Vector3? __9_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_UnityEngineVector3 != null)
                {
                    return Private___9_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_UnityEngineVector3 != null)
                    {
                        Private___9_intnl_UnityEngineVector3.Value = value.Value;
                    }
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

        internal float? __19_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemSingle != null)
                {
                    return Private___19_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemSingle != null)
                    {
                        Private___19_intnl_SystemSingle.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __20_intnl_SystemObject
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

        internal UnityEngine.Vector3? __8_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_UnityEngineVector3 != null)
                {
                    return Private___8_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_UnityEngineVector3 != null)
                    {
                        Private___8_intnl_UnityEngineVector3.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour footStepSound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_footStepSound != null)
                {
                    return Private_footStepSound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_footStepSound != null)
                {
                    Private_footStepSound.Value = value;
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

        internal float? __0_newHealthRatio_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newHealthRatio_Single != null)
                {
                    return Private___0_newHealthRatio_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newHealthRatio_Single != null)
                    {
                        Private___0_newHealthRatio_Single.Value = value.Value;
                    }
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

        internal int? __5_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_const_intnl_SystemInt32 != null)
                {
                    return Private___5_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_const_intnl_SystemInt32 != null)
                    {
                        Private___5_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal int? __16_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_const_intnl_SystemInt32 != null)
                {
                    return Private___16_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_const_intnl_SystemInt32 != null)
                    {
                        Private___16_const_intnl_SystemInt32.Value = value.Value;
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

        internal short? sync_Health
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_sync_Health != null)
                {
                    return Private_sync_Health.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_sync_Health != null)
                    {
                        Private_sync_Health.Value = value.Value;
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



        internal bool? __0_intnl_SystemObject
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

        internal VRC.Udon.UdonBehaviour playerUISlot
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerUISlot != null)
                {
                    return Private_playerUISlot.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerUISlot != null)
                {
                    Private_playerUISlot.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __7_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_UnityEngineVector3 != null)
                {
                    return Private___7_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_UnityEngineVector3 != null)
                    {
                        Private___7_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __2_intnl_NL_EffectManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_NL_EffectManager != null)
                {
                    return Private___2_intnl_NL_EffectManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_NL_EffectManager != null)
                {
                    Private___2_intnl_NL_EffectManager.Value = value;
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

        internal int? __17_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_const_intnl_SystemInt32 != null)
                {
                    return Private___17_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_const_intnl_SystemInt32 != null)
                    {
                        Private___17_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? hasInitialized
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasInitialized != null)
                {
                    return Private_hasInitialized.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasInitialized != null)
                    {
                        Private_hasInitialized.Value = value.Value;
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

        internal float? hitboxFadeSpeed
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitboxFadeSpeed != null)
                {
                    return Private_hitboxFadeSpeed.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hitboxFadeSpeed != null)
                    {
                        Private_hitboxFadeSpeed.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi trackingPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_trackingPlayer != null)
                {
                    return Private_trackingPlayer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_trackingPlayer != null)
                {
                    Private_trackingPlayer.Value = value;
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

        internal UnityEngine.Vector3? headPosition
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_headPosition != null)
                {
                    return Private_headPosition.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_headPosition != null)
                    {
                        Private_headPosition.Value = value.Value;
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

        internal bool? hasTeleported
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasTeleported != null)
                {
                    return Private_hasTeleported.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasTeleported != null)
                    {
                        Private_hasTeleported.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isAlive
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isAlive != null)
                {
                    return Private_isAlive.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isAlive != null)
                    {
                        Private_isAlive.Value = value.Value;
                    }
                }
            }
        }

        internal int? __8_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_const_intnl_SystemInt32 != null)
                {
                    return Private___8_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_const_intnl_SystemInt32 != null)
                    {
                        Private___8_const_intnl_SystemInt32.Value = value.Value;
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

        internal int? __4_intnl_SystemObject
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

        internal float? __5_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_const_intnl_SystemSingle != null)
                {
                    return Private___5_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_const_intnl_SystemSingle != null)
                    {
                        Private___5_const_intnl_SystemSingle.Value = value.Value;
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

        internal int? local_Health
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_local_Health != null)
                {
                    return Private_local_Health.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_local_Health != null)
                    {
                        Private_local_Health.Value = value.Value;
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

        internal int? __14_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_const_intnl_SystemInt32 != null)
                {
                    return Private___14_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_const_intnl_SystemInt32 != null)
                    {
                        Private___14_const_intnl_SystemInt32.Value = value.Value;
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

        internal int? __9_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_const_intnl_SystemInt32 != null)
                {
                    return Private___9_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_const_intnl_SystemInt32 != null)
                    {
                        Private___9_const_intnl_SystemInt32.Value = value.Value;
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

        internal float? __17_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemSingle != null)
                {
                    return Private___17_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemSingle != null)
                    {
                        Private___17_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject infestedIndicator
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_infestedIndicator != null)
                {
                    return Private_infestedIndicator.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_infestedIndicator != null)
                {
                    Private_infestedIndicator.Value = value;
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

        internal int? __19_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_const_intnl_SystemInt32 != null)
                {
                    return Private___19_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_const_intnl_SystemInt32 != null)
                    {
                        Private___19_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal int? __21_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_const_intnl_SystemInt32 != null)
                {
                    return Private___21_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_const_intnl_SystemInt32 != null)
                    {
                        Private___21_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? __17_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemObject != null)
                {
                    return Private___17_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemObject != null)
                    {
                        Private___17_intnl_SystemObject.Value = value.Value;
                    }
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

        internal bool? __18_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemObject != null)
                {
                    return Private___18_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_intnl_SystemObject != null)
                    {
                        Private___18_intnl_SystemObject.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour damageSync
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_damageSync != null)
                {
                    return Private_damageSync.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_damageSync != null)
                {
                    Private_damageSync.Value = value;
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

        internal float? __16_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_SystemSingle != null)
                {
                    return Private___16_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_intnl_SystemSingle != null)
                    {
                        Private___16_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isLocalPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isLocalPlayer != null)
                {
                    return Private_isLocalPlayer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isLocalPlayer != null)
                    {
                        Private_isLocalPlayer.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __11_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemObject != null)
                {
                    return Private___11_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_SystemObject != null)
                    {
                        Private___11_intnl_SystemObject.Value = value.Value;
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

        internal int? __12_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_const_intnl_SystemInt32 != null)
                {
                    return Private___12_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_const_intnl_SystemInt32 != null)
                    {
                        Private___12_const_intnl_SystemInt32.Value = value.Value;
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

        internal int? __1_mp_damageValue_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_damageValue_Int32 != null)
                {
                    return Private___1_mp_damageValue_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_damageValue_Int32 != null)
                    {
                        Private___1_mp_damageValue_Int32.Value = value.Value;
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

        internal UnityEngine.Vector3? healthBarDefaultOffset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_healthBarDefaultOffset != null)
                {
                    return Private_healthBarDefaultOffset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_healthBarDefaultOffset != null)
                    {
                        Private_healthBarDefaultOffset.Value = value.Value;
                    }
                }
            }
        }

        internal int? __13_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_const_intnl_SystemInt32 != null)
                {
                    return Private___13_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_const_intnl_SystemInt32 != null)
                    {
                        Private___13_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __0_mp_newUISlot_NLI_PlayerSlotUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newUISlot_NLI_PlayerSlotUI != null)
                {
                    return Private___0_mp_newUISlot_NLI_PlayerSlotUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_newUISlot_NLI_PlayerSlotUI != null)
                {
                    Private___0_mp_newUISlot_NLI_PlayerSlotUI.Value = value;
                }
            }
        }

        internal float? delayedSyncTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_delayedSyncTimer != null)
                {
                    return Private_delayedSyncTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_delayedSyncTimer != null)
                    {
                        Private_delayedSyncTimer.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __144_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___144_intnl_SystemBoolean != null)
                {
                    return Private___144_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___144_intnl_SystemBoolean != null)
                    {
                        Private___144_intnl_SystemBoolean.Value = value.Value;
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

        internal bool? __143_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___143_intnl_SystemBoolean != null)
                {
                    return Private___143_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___143_intnl_SystemBoolean != null)
                    {
                        Private___143_intnl_SystemBoolean.Value = value.Value;
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

        internal bool? __0_mp_isInfested_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_isInfested_Boolean != null)
                {
                    return Private___0_mp_isInfested_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_isInfested_Boolean != null)
                    {
                        Private___0_mp_isInfested_Boolean.Value = value.Value;
                    }
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

        internal UnityEngine.Vector3? __14_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_UnityEngineVector3 != null)
                {
                    return Private___14_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_intnl_UnityEngineVector3 != null)
                    {
                        Private___14_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_height_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_height_Single != null)
                {
                    return Private___0_height_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_height_Single != null)
                    {
                        Private___0_height_Single.Value = value.Value;
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

        internal UnityEngine.Vector3? __10_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_UnityEngineVector3 != null)
                {
                    return Private___10_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_UnityEngineVector3 != null)
                    {
                        Private___10_intnl_UnityEngineVector3.Value = value.Value;
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

        internal bool? __19_intnl_SystemObject
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

        internal UnityEngine.Vector3? __16_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_UnityEngineVector3 != null)
                {
                    return Private___16_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_intnl_UnityEngineVector3 != null)
                    {
                        Private___16_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal int? characterIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_characterIndex != null)
                {
                    return Private_characterIndex.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_characterIndex != null)
                    {
                        Private_characterIndex.Value = value.Value;
                    }
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

        internal bool? __0_mp_checkGameState_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_checkGameState_Boolean != null)
                {
                    return Private___0_mp_checkGameState_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_checkGameState_Boolean != null)
                    {
                        Private___0_mp_checkGameState_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __12_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_UnityEngineVector3 != null)
                {
                    return Private___12_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_UnityEngineVector3 != null)
                    {
                        Private___12_intnl_UnityEngineVector3.Value = value.Value;
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

        internal bool? isBeingInfested
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isBeingInfested != null)
                {
                    return Private_isBeingInfested.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isBeingInfested != null)
                    {
                        Private_isBeingInfested.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text huntMarkDistanceText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_huntMarkDistanceText != null)
                {
                    return Private_huntMarkDistanceText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_huntMarkDistanceText != null)
                {
                    Private_huntMarkDistanceText.Value = value;
                }
            }
        }

        internal float? __14_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemSingle != null)
                {
                    return Private___14_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_intnl_SystemSingle != null)
                    {
                        Private___14_intnl_SystemSingle.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi onPlayerLeftPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_onPlayerLeftPlayer != null)
                {
                    return Private_onPlayerLeftPlayer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_onPlayerLeftPlayer != null)
                {
                    Private_onPlayerLeftPlayer.Value = value;
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

        internal int? __10_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_const_intnl_SystemInt32 != null)
                {
                    return Private___10_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_const_intnl_SystemInt32 != null)
                    {
                        Private___10_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __0_this_intnl_NL_PlayerCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_NL_PlayerCharacter != null)
                {
                    return Private___0_this_intnl_NL_PlayerCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_NL_PlayerCharacter != null)
                {
                    Private___0_this_intnl_NL_PlayerCharacter.Value = value;
                }
            }
        }

        internal float? hitboxMinTrans
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitboxMinTrans != null)
                {
                    return Private_hitboxMinTrans.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hitboxMinTrans != null)
                    {
                        Private_hitboxMinTrans.Value = value.Value;
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

        internal float? __20_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemSingle != null)
                {
                    return Private___20_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_intnl_SystemSingle != null)
                    {
                        Private___20_intnl_SystemSingle.Value = value.Value;
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

        internal int? __24_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_const_intnl_SystemInt32 != null)
                {
                    return Private___24_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_const_intnl_SystemInt32 != null)
                    {
                        Private___24_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __140_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___140_intnl_SystemBoolean != null)
                {
                    return Private___140_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___140_intnl_SystemBoolean != null)
                    {
                        Private___140_intnl_SystemBoolean.Value = value.Value;
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

        internal bool? __0_isLethalHit_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_isLethalHit_Boolean != null)
                {
                    return Private___0_isLethalHit_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_isLethalHit_Boolean != null)
                    {
                        Private___0_isLethalHit_Boolean.Value = value.Value;
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

        internal bool? __141_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___141_intnl_SystemBoolean != null)
                {
                    return Private___141_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___141_intnl_SystemBoolean != null)
                    {
                        Private___141_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi __0_newPlayer_VRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newPlayer_VRCPlayerApi != null)
                {
                    return Private___0_newPlayer_VRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_newPlayer_VRCPlayerApi != null)
                {
                    Private___0_newPlayer_VRCPlayerApi.Value = value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_NL_EffectManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_NL_EffectManager != null)
                {
                    return Private___0_intnl_NL_EffectManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_NL_EffectManager != null)
                {
                    Private___0_intnl_NL_EffectManager.Value = value;
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

        internal UnityEngine.GameObject humanIndicator
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_humanIndicator != null)
                {
                    return Private_humanIndicator.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_humanIndicator != null)
                {
                    Private_humanIndicator.Value = value;
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

        internal UnityEngine.GameObject infestedTitle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_infestedTitle != null)
                {
                    return Private_infestedTitle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_infestedTitle != null)
                {
                    Private_infestedTitle.Value = value;
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

        internal UnityEngine.GameObject colliderObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_colliderObject != null)
                {
                    return Private_colliderObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_colliderObject != null)
                {
                    Private_colliderObject.Value = value;
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

        internal float? __18_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemSingle != null)
                {
                    return Private___18_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_intnl_SystemSingle != null)
                    {
                        Private___18_intnl_SystemSingle.Value = value.Value;
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

        internal int? __0_mp_newPlayerID_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newPlayerID_Int32 != null)
                {
                    return Private___0_mp_newPlayerID_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_newPlayerID_Int32 != null)
                    {
                        Private___0_mp_newPlayerID_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __22_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_const_intnl_SystemInt32 != null)
                {
                    return Private___22_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_const_intnl_SystemInt32 != null)
                    {
                        Private___22_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __0_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineColor != null)
                {
                    return Private___0_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineColor != null)
                    {
                        Private___0_intnl_UnityEngineColor.Value = value.Value;
                    }
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

        internal int? __5_intnl_SystemObject
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

        internal UnityEngine.Color? hitboxColorTemp
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitboxColorTemp != null)
                {
                    return Private_hitboxColorTemp.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hitboxColorTemp != null)
                    {
                        Private_hitboxColorTemp.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour spectateCharacter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_spectateCharacter != null)
                {
                    return Private_spectateCharacter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_spectateCharacter != null)
                {
                    Private_spectateCharacter.Value = value;
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

        internal UnityEngine.Vector3? __15_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_UnityEngineVector3 != null)
                {
                    return Private___15_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_intnl_UnityEngineVector3 != null)
                    {
                        Private___15_intnl_UnityEngineVector3.Value = value.Value;
                    }
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

        internal int? __15_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_const_intnl_SystemInt32 != null)
                {
                    return Private___15_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_const_intnl_SystemInt32 != null)
                    {
                        Private___15_const_intnl_SystemInt32.Value = value.Value;
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

        internal int? local_displayHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_local_displayHealth != null)
                {
                    return Private_local_displayHealth.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_local_displayHealth != null)
                    {
                        Private_local_displayHealth.Value = value.Value;
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

        internal UnityEngine.Vector3? __11_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_UnityEngineVector3 != null)
                {
                    return Private___11_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_UnityEngineVector3 != null)
                    {
                        Private___11_intnl_UnityEngineVector3.Value = value.Value;
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

        internal int? __23_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_const_intnl_SystemInt32 != null)
                {
                    return Private___23_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_const_intnl_SystemInt32 != null)
                    {
                        Private___23_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __142_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___142_intnl_SystemBoolean != null)
                {
                    return Private___142_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___142_intnl_SystemBoolean != null)
                    {
                        Private___142_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_mp_newUpdateManager_NL_UpdateManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newUpdateManager_NL_UpdateManager != null)
                {
                    return Private___0_mp_newUpdateManager_NL_UpdateManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_newUpdateManager_NL_UpdateManager != null)
                {
                    Private___0_mp_newUpdateManager_NL_UpdateManager.Value = value;
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

        internal short? sync_playerID
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_sync_playerID != null)
                {
                    return Private_sync_playerID.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_sync_playerID != null)
                    {
                        Private_sync_playerID.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_mp_newLobbyManager_NLI_LobbyManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newLobbyManager_NLI_LobbyManager != null)
                {
                    return Private___0_mp_newLobbyManager_NLI_LobbyManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_newLobbyManager_NLI_LobbyManager != null)
                {
                    Private___0_mp_newLobbyManager_NLI_LobbyManager.Value = value;
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

        internal short? sync_humanInfested
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_sync_humanInfested != null)
                {
                    return Private_sync_humanInfested.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_sync_humanInfested != null)
                    {
                        Private_sync_humanInfested.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour gameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameManager != null)
                {
                    return Private_gameManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_gameManager != null)
                {
                    Private_gameManager.Value = value;
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

        internal VRC.Udon.UdonBehaviour stabRange
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stabRange != null)
                {
                    return Private_stabRange.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_stabRange != null)
                {
                    Private_stabRange.Value = value;
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

        internal UnityEngine.GameObject huntMark
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_huntMark != null)
                {
                    return Private_huntMark.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_huntMark != null)
                {
                    Private_huntMark.Value = value;
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

        internal float? __0_distance_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_distance_Single != null)
                {
                    return Private___0_distance_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_distance_Single != null)
                    {
                        Private___0_distance_Single.Value = value.Value;
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

        internal UnityEngine.SpriteRenderer hitBoxAssist
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitBoxAssist != null)
                {
                    return Private_hitBoxAssist.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_hitBoxAssist != null)
                {
                    Private_hitBoxAssist.Value = value;
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

        internal UnityEngine.Vector3? __0_mp_hitPoint_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_hitPoint_Vector3 != null)
                {
                    return Private___0_mp_hitPoint_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_hitPoint_Vector3 != null)
                    {
                        Private___0_mp_hitPoint_Vector3.Value = value.Value;
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

        internal float? healthRegenTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_healthRegenTimer != null)
                {
                    return Private_healthRegenTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_healthRegenTimer != null)
                    {
                        Private_healthRegenTimer.Value = value.Value;
                    }
                }
            }
        }

        internal string playerName
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerName != null)
                {
                    return Private_playerName.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerName != null)
                {
                    Private_playerName.Value = value;
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

        #endregion Getter / Setters AstroUdonVariables  of PlayerCharacterObject

        #region AstroUdonVariables  of PlayerCharacterObject

        private AstroUdonVariable<int> Private___18_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_newIndex_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___33_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___20_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___77_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___17_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___48_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___1_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___13_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___3_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___52_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_huntBegin_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_floatingHUD { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___93_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___1_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___118_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_huntMarkDistanceText2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___95_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___49_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___16_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___72_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___119_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___15_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private_sync_infestedKilled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_newSpectateCharacter_NL_SpectateCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___93_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_originOffset_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___21_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___96_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_this_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___85_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___104_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___103_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_mp_newWorldOrigin_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___105_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasSpawnInfestedEffect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___28_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___58_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___83_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_maxHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_damageValue_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___138_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___75_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___64_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___40_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___139_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___99_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___86_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___29_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___59_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___25_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___84_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_humanTitle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_newGameManager_NLI_GameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___73_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___9_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___4_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___19_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___41_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___46_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___85_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___64_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___20_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___8_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___76_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___78_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___23_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___91_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_footStepSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isInfested { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_newHealthRatio_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___89_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___65_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___106_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___16_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___43_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___79_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private_sync_Health { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___127_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___87_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerUISlot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___7_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_NL_EffectManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___12_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___34_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___100_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___17_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___79_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___92_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasInitialized { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___81_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___1_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___68_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_hitboxFadeSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___67_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___50_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___101_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_trackingPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___35_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_headPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasTeleported { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isAlive { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___54_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___51_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___26_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___56_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___71_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___117_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___60_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___82_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___20_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___37_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___6_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___70_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_local_Health { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___67_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___23_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___53_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___5_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___14_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___17_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_infestedIndicator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___82_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___72_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___19_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___4_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___102_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___21_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___71_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___76_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___124_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___123_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_this_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___125_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___62_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___0_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___58_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___137_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___73_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_damageSync { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___15_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___16_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isLocalPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___19_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_lobbyManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___114_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___32_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___113_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___50_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___115_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_damageValue_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_healthBarDefaultOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_newUISlot_NLI_PlayerSlotUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_delayedSyncTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___144_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___143_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___44_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___65_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___92_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_isInfested_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___14_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_height_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___57_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___126_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___10_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___2_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___45_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___63_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___88_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___108_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___16_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_characterIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___120_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_checkGameState_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___12_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___94_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___109_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___66_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___121_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___22_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___89_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___68_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isBeingInfested { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_huntMarkDistanceText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___14_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___134_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___47_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_onPlayerLeftPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___133_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___17_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___116_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_NL_PlayerCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_hitboxMinTrans { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___135_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___69_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___20_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___84_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___110_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isHero { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___24_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___54_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___69_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___38_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___111_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___24_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___140_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___55_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___25_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___55_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___5_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_isLethalHit_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___141_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___39_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___74_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_newPlayer_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___122_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_NL_EffectManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___61_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___98_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_humanIndicator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___53_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___80_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_updateManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_infestedTitle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___74_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___136_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.HumanBodyBones> Private___0_const_intnl_UnityEngineHumanBodyBones { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___27_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___57_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___56_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_colliderObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___42_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___18_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___81_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___60_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___86_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_localPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private___0_intnl_SystemInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___90_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___75_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___130_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_newPlayerID_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___22_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___62_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___112_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___88_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___131_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_hitboxColorTemp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_spectateCharacter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___61_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___15_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___66_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___15_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___97_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_local_displayHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___11_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___14_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___23_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___142_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_newUpdateManager_NL_UpdateManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___83_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private_sync_playerID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_newLobbyManager_NLI_LobbyManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___59_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___18_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___77_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___30_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_worldOrigin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<short> Private_sync_humanInfested { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___78_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_stabRange { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___80_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_huntMark { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_distance_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___24_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___63_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___13_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.SpriteRenderer> Private_hitBoxAssist { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___90_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___31_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___36_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_hitPoint_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___128_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_healthRegenTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_playerName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___87_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___51_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___107_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___52_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___70_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___129_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___49_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___91_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___132_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of PlayerCharacterObject

    }
}