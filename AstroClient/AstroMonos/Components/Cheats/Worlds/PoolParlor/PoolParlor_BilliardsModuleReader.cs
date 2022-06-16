using System;
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


namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PoolParlor
{
    [RegisterComponent]
    public class PoolParlor_BilliardsModuleReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PoolParlor_BilliardsModuleReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PoolParlor))
            {
                var obj = gameObject.FindUdonEvent("_TriggerCueBallHit");
                if (obj != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    BilliardsModule = obj.UdonBehaviour.ToRawUdonBehaviour();
                    Initialize_BilliardsModule();
                    
                }
                else
                {
                    Log.Error("Can't Find BilliardsModule behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        internal bool ForceGuidelineOn { get; set; } = false;
        internal bool ForceLockingOn { get; set; } = false;

        private void StartStuff()
        {
            InvokeRepeating(nameof(ForceSettings), 0.1f, 0.1f);

        }


        private void ForceSettings()
        {
            if (ForceGuidelineOn)
            {
                if (noGuidelineLocal.GetValueOrDefault(false))
                {
                    noGuidelineLocal = false;
                }
            }
            if(ForceLockingOn)
            {
                if (noLockingLocal.GetValueOrDefault(false))
                {
                    noLockingLocal = false;
                }
            }
        }

        private void OnDestroy()
        {
            ClientEventActions.OnRoomLeft -= OnRoomLeft;
            Cleanup_BilliardsModule();
        }

        private RawUdonBehaviour BilliardsModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_BilliardsModule()
        {
            Private___0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean");
            Private_noGuidelineLocal = new AstroUdonVariable<bool>(BilliardsModule, "noGuidelineLocal");
            Private_snd_spin = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_spin");
            Private_isPracticeMode = new AstroUdonVariable<bool>(BilliardsModule, "isPracticeMode");
            Private___0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean");
            Private_localPlayerId = new AstroUdonVariable<int>(BilliardsModule, "localPlayerId");
            Private___6_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__6_intnl_returnValSymbol_Boolean");
            Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32");
            Private_currentPhysicsManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "currentPhysicsManager");
            Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32");
            Private___0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32");
            Private_lobbyOpen = new AstroUdonVariable<bool>(BilliardsModule, "lobbyOpen");
            Private___0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32");
            Private_textureSets = new AstroUdonVariable<UnityEngine.Texture[]>(BilliardsModule, "textureSets");
            Private___0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean");
            Private_k_colour_default = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_colour_default");
            Private_k_TABLE_WIDTH = new AstroUdonVariable<float>(BilliardsModule, "k_TABLE_WIDTH");
            Private_marker9ball = new AstroUdonVariable<UnityEngine.GameObject>(BilliardsModule, "marker9ball");
            Private_localTeamId = new AstroUdonVariable<uint>(BilliardsModule, "localTeamId");
            Private___0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String = new AstroUdonVariable<string>(BilliardsModule, "__0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String");
            Private_snd_NewTurn = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_NewTurn");
            Private_k_teamColour_spots = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_teamColour_spots");
            Private___2_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__2_intnl_returnValSymbol_Boolean");
            Private___4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String = new AstroUdonVariable<string>(BilliardsModule, "__4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String");
            Private_isLocalSimulationRunning = new AstroUdonVariable<bool>(BilliardsModule, "isLocalSimulationRunning");
            Private___0_mp_683DB5641238683D33EF621CD7CDFECD_Single = new AstroUdonVariable<float>(BilliardsModule, "__0_mp_683DB5641238683D33EF621CD7CDFECD_Single");
            Private_isGuidelineValid = new AstroUdonVariable<bool>(BilliardsModule, "isGuidelineValid");
            Private_cameraManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "cameraManager");
            Private_timerLocal = new AstroUdonVariable<uint>(BilliardsModule, "timerLocal");
            Private_noLockingLocal = new AstroUdonVariable<bool>(BilliardsModule, "noLockingLocal");
            Private_betaPhysicsManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "betaPhysicsManager");
            Private_k_fabricColour_4ball = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_fabricColour_4ball");
            Private___0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32");
            Private___0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32");
            Private_tableSkinLocal = new AstroUdonVariable<int>(BilliardsModule, "tableSkinLocal");
            Private___8_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__8_intnl_returnValSymbol_Boolean");
            Private___0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32");
            Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__1_mp_680845797CF11D637DB85E28135E758C_Int32");
            Private_guideline = new AstroUdonVariable<UnityEngine.GameObject>(BilliardsModule, "guideline");
            Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32");
            Private_tableSkins = new AstroUdonVariable<UnityEngine.Texture2D[]>(BilliardsModule, "tableSkins");
            Private_teamColorLocal = new AstroUdonVariable<uint>(BilliardsModule, "teamColorLocal");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(BilliardsModule, "__refl_const_intnl_udonTypeID");
            Private___0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean");
            Private_gameModeLocal = new AstroUdonVariable<uint>(BilliardsModule, "gameModeLocal");
            Private_snd_hitball = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_hitball");
            Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(BilliardsModule, "__refl_const_intnl_udonTypeName");
            Private___0_mp_3A7037A057A86331DC882253A9EA828E_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_3A7037A057A86331DC882253A9EA828E_Boolean");
            Private_k_POCKET_RADIUS = new AstroUdonVariable<float>(BilliardsModule, "k_POCKET_RADIUS");
            Private_PERF_PHYSICS_BALL = new AstroUdonVariable<int>(BilliardsModule, "PERF_PHYSICS_BALL");
            Private___0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32");
            Private___0_mp_999528999B17CED7B7B9A26F2DE51012_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_999528999B17CED7B7B9A26F2DE51012_Int32");
            Private___0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "__0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3");
            Private_k_teamColour_stripes = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_teamColour_stripes");
            Private_PERF_PHYSICS_MAIN = new AstroUdonVariable<int>(BilliardsModule, "PERF_PHYSICS_MAIN");
            Private_auto_pocketblockers = new AstroUdonVariable<UnityEngine.GameObject>(BilliardsModule, "auto_pocketblockers");
            Private_repositionManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "repositionManager");
            Private___4_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__4_intnl_returnValSymbol_Boolean");
            Private___0_intnl_returnValSymbol_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(BilliardsModule, "__0_intnl_returnValSymbol_GameObject");
            Private_is8Ball = new AstroUdonVariable<bool>(BilliardsModule, "is8Ball");
            Private_is4Ball = new AstroUdonVariable<bool>(BilliardsModule, "is4Ball");
            Private_is9Ball = new AstroUdonVariable<bool>(BilliardsModule, "is9Ball");
            Private_ballsW = new AstroUdonVariable<UnityEngine.Vector3[]>(BilliardsModule, "ballsW");
            Private___0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean");
            Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32");
            Private_ltext = new AstroUdonVariable<UnityEngine.UI.Text>(BilliardsModule, "ltext");
            Private___0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32");
            Private_fourBallCueBallLocal = new AstroUdonVariable<uint>(BilliardsModule, "fourBallCueBallLocal");
            Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_680845797CF11D637DB85E28135E758C_Int32");
            Private_devhit = new AstroUdonVariable<UnityEngine.GameObject>(BilliardsModule, "devhit");
            Private_PERF_MAX = new AstroUdonVariable<int>(BilliardsModule, "PERF_MAX");
            Private_desktopManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "desktopManager");
            Private_k_TABLE_HEIGHT = new AstroUdonVariable<float>(BilliardsModule, "k_TABLE_HEIGHT");
            Private___0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32");
            Private___1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "__1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3");
            Private___7_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__7_intnl_returnValSymbol_Boolean");
            Private_teamsLocal = new AstroUdonVariable<bool>(BilliardsModule, "teamsLocal");
            Private_legacyPhysicsManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "legacyPhysicsManager");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_intnl_returnValSymbol_Boolean");
            Private_PERF_PHYSICS_VEL = new AstroUdonVariable<int>(BilliardsModule, "PERF_PHYSICS_VEL");
            Private_k_CUSHION_RADIUS = new AstroUdonVariable<float>(BilliardsModule, "k_CUSHION_RADIUS");
            Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean");
            Private_cueSkinHook = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "cueSkinHook");
            Private_k_colour_off = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_colour_off");
            Private_physicsModeLocal = new AstroUdonVariable<int>(BilliardsModule, "physicsModeLocal");
            Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "__0_mp_466037600B3424A20CCBFB190A471B9E_Vector3");
            Private_fbScoresLocal = new AstroUdonVariable<int[]>(BilliardsModule, "fbScoresLocal");
            Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean");
            Private_menuManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "menuManager");
            Private___0_mp_B30B3C627DA342FAF687A7F730211209_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_B30B3C627DA342FAF687A7F730211209_Int32");
            Private___12_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__12_intnl_returnValSymbol_Boolean");
            Private___0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte = new AstroUdonVariable<byte>(BilliardsModule, "__0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte");
            Private_k_colour4Ball_team_1 = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_colour4Ball_team_1");
            Private_VERSION = new AstroUdonVariable<string>(BilliardsModule, "VERSION");
            Private___3_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__3_intnl_returnValSymbol_Boolean");
            Private___11_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__11_intnl_returnValSymbol_Boolean");
            Private_gameLive = new AstroUdonVariable<bool>(BilliardsModule, "gameLive");
            Private_callbacks = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "callbacks");
            Private_k_INNER_RADIUS = new AstroUdonVariable<float>(BilliardsModule, "k_INNER_RADIUS");
            Private_canHitCueBall = new AstroUdonVariable<bool>(BilliardsModule, "canHitCueBall");
            Private_ballsPocketedLocal = new AstroUdonVariable<uint>(BilliardsModule, "ballsPocketedLocal");
            Private___0_mp_662E199239EE18499A38900AE1882A37_Transform = new AstroUdonVariable<UnityEngine.RectTransform>(BilliardsModule, "__0_mp_662E199239EE18499A38900AE1882A37_Transform");
            Private_timerRunning = new AstroUdonVariable<bool>(BilliardsModule, "timerRunning");
            Private_PERF_PHYSICS_CUSHION = new AstroUdonVariable<int>(BilliardsModule, "PERF_PHYSICS_CUSHION");
            Private_k_fabricColour_9ball = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_fabricColour_9ball");
            Private___0_mp_92A1625974934242B7768ADAE3029AD8_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_92A1625974934242B7768ADAE3029AD8_Int32");
            Private_snd_PointMade = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_PointMade");
            Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "__0_mp_3693904A474BEDC44290E85B57401A21_Vector3");
            Private_infReset = new AstroUdonVariable<UnityEngine.UI.Text>(BilliardsModule, "infReset");
            Private_repoMaxX = new AstroUdonVariable<float>(BilliardsModule, "repoMaxX");
            Private___0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform = new AstroUdonVariable<UnityEngine.Transform>(BilliardsModule, "__0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform");
            Private_playerNamesLocal = new AstroUdonVariable<string[]>(BilliardsModule, "playerNamesLocal");
            Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean");
            Private___0_mp_E6EFA20213DE446B068D040E26995995_Byte = new AstroUdonVariable<byte>(BilliardsModule, "__0_mp_E6EFA20213DE446B068D040E26995995_Byte");
            Private___9_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__9_intnl_returnValSymbol_Boolean");
            Private___0_mp_B83162C92B798F1B9974D8E396114439_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_B83162C92B798F1B9974D8E396114439_Boolean");
            Private_isKr4Ball = new AstroUdonVariable<bool>(BilliardsModule, "isKr4Ball");
            Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32");
            Private_balls = new AstroUdonVariable<UnityEngine.GameObject[]>(BilliardsModule, "balls");
            Private_table = new AstroUdonVariable<UnityEngine.Transform>(BilliardsModule, "table");
            Private_pockets = new AstroUdonVariable<UnityEngine.GameObject[]>(BilliardsModule, "pockets");
            Private_k_vF = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "k_vF");
            Private_cueSkins = new AstroUdonVariable<UnityEngine.Texture2D[]>(BilliardsModule, "cueSkins");
            Private_isReposition = new AstroUdonVariable<bool>(BilliardsModule, "isReposition");
            Private___10_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__10_intnl_returnValSymbol_Boolean");
            Private___0_mp_72681C8A3F190167F4664BA51221AA32_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_72681C8A3F190167F4664BA51221AA32_Int32");
            Private___5_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__5_intnl_returnValSymbol_Boolean");
            Private_standardPhysicsManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "standardPhysicsManager");
            Private___0_mp_1316037599E67E752566661A8A5BDC31_Byte = new AstroUdonVariable<byte>(BilliardsModule, "__0_mp_1316037599E67E752566661A8A5BDC31_Byte");
            Private_snd_btn = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_btn");
            Private_PERF_PHYSICS_POCKET = new AstroUdonVariable<int>(BilliardsModule, "PERF_PHYSICS_POCKET");
            Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean");
            Private___0_mp_759D708A95415D8D1E83F45F073F409B_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_759D708A95415D8D1E83F45F073F409B_UInt32");
            Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_B5776574A01D77801AC66647C575C338_Boolean");
            Private_snd_spinstop = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_spinstop");
            Private___0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32");
            Private___0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32");
            Private_activeCueSkin = new AstroUdonVariable<int>(BilliardsModule, "activeCueSkin");
            Private_practiceManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "practiceManager");
            Private_networkingManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "networkingManager");
            Private_k_colour_foul = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_colour_foul");
            Private___0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32");
            Private_tableModels = new AstroUdonVariable<UnityEngine.Component[]>(BilliardsModule, "tableModels");
            Private_nameColorHook = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "nameColorHook");
            Private_cameraOverrideModule = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "cameraOverrideModule");
            Private_k_vE = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "k_vE");
            Private_PERF_MAIN = new AstroUdonVariable<int>(BilliardsModule, "PERF_MAIN");
            Private___0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32");
            Private___1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32");
            Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__1_intnl_returnValSymbol_Boolean");
            Private_snd_Sink = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_Sink");
            Private_k_rack_position = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "k_rack_position");
            Private_ballsP = new AstroUdonVariable<UnityEngine.Vector3[]>(BilliardsModule, "ballsP");
            Private___0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte = new AstroUdonVariable<byte>(BilliardsModule, "__0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte");
            Private_aud_main = new AstroUdonVariable<UnityEngine.AudioSource>(BilliardsModule, "aud_main");
            Private_previewWinningTeamLocal = new AstroUdonVariable<uint>(BilliardsModule, "previewWinningTeamLocal");
            Private_isTableOpenLocal = new AstroUdonVariable<bool>(BilliardsModule, "isTableOpenLocal");
            Private_k_colour4Ball_team_0 = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_colour4Ball_team_0");
            Private_isJp4Ball = new AstroUdonVariable<bool>(BilliardsModule, "isJp4Ball");
            Private___0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(BilliardsModule, "__0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3");
            Private_INITIALIZED = new AstroUdonVariable<bool>(BilliardsModule, "INITIALIZED");
            Private_snd_Intro = new AstroUdonVariable<UnityEngine.AudioClip>(BilliardsModule, "snd_Intro");
            Private_teamIdLocal = new AstroUdonVariable<uint>(BilliardsModule, "teamIdLocal");
            Private_canPlayLocal = new AstroUdonVariable<bool>(BilliardsModule, "canPlayLocal");
            Private_DEPENDENCIES = new AstroUdonVariable<string[]>(BilliardsModule, "DEPENDENCIES");
            Private_graphicsManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "graphicsManager");
            Private_markerObj = new AstroUdonVariable<UnityEngine.GameObject>(BilliardsModule, "markerObj");
            Private___0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte = new AstroUdonVariable<byte>(BilliardsModule, "__0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte");
            Private_winningTeamLocal = new AstroUdonVariable<uint>(BilliardsModule, "winningTeamLocal");
            Private_k_fabricColour_8ball = new AstroUdonVariable<UnityEngine.Color>(BilliardsModule, "k_fabricColour_8ball");
            Private___0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32 = new AstroUdonVariable<uint>(BilliardsModule, "__0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32");
            Private_tableSkinHook = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(BilliardsModule, "tableSkinHook");
            Private_ballsV = new AstroUdonVariable<UnityEngine.Vector3[]>(BilliardsModule, "ballsV");
            Private_reflection_main = new AstroUdonVariable<UnityEngine.ReflectionProbe>(BilliardsModule, "reflection_main");
            Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32");
            Private_cueControllers = new AstroUdonVariable<UnityEngine.Component[]>(BilliardsModule, "cueControllers");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(BilliardsModule, "__0_intnl_returnValSymbol_Int32");
            Private___0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean = new AstroUdonVariable<bool>(BilliardsModule, "__0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean");
        }

        private void Cleanup_BilliardsModule()
        {
            Private___0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean = null;
            Private_noGuidelineLocal = null;
            Private_snd_spin = null;
            Private_isPracticeMode = null;
            Private___0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean = null;
            Private_localPlayerId = null;
            Private___6_intnl_returnValSymbol_Boolean = null;
            Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = null;
            Private_currentPhysicsManager = null;
            Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = null;
            Private___0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32 = null;
            Private_lobbyOpen = null;
            Private___0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32 = null;
            Private_textureSets = null;
            Private___0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean = null;
            Private_k_colour_default = null;
            Private_k_TABLE_WIDTH = null;
            Private_marker9ball = null;
            Private_localTeamId = null;
            Private___0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String = null;
            Private_snd_NewTurn = null;
            Private_k_teamColour_spots = null;
            Private___2_intnl_returnValSymbol_Boolean = null;
            Private___4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String = null;
            Private_isLocalSimulationRunning = null;
            Private___0_mp_683DB5641238683D33EF621CD7CDFECD_Single = null;
            Private_isGuidelineValid = null;
            Private_cameraManager = null;
            Private_timerLocal = null;
            Private_noLockingLocal = null;
            Private_betaPhysicsManager = null;
            Private_k_fabricColour_4ball = null;
            Private___0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32 = null;
            Private___0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32 = null;
            Private_tableSkinLocal = null;
            Private___8_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32 = null;
            Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 = null;
            Private_guideline = null;
            Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = null;
            Private_tableSkins = null;
            Private_teamColorLocal = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean = null;
            Private_gameModeLocal = null;
            Private_snd_hitball = null;
            Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___0_mp_3A7037A057A86331DC882253A9EA828E_Boolean = null;
            Private_k_POCKET_RADIUS = null;
            Private_PERF_PHYSICS_BALL = null;
            Private___0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32 = null;
            Private___0_mp_999528999B17CED7B7B9A26F2DE51012_Int32 = null;
            Private___0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3 = null;
            Private_k_teamColour_stripes = null;
            Private_PERF_PHYSICS_MAIN = null;
            Private_auto_pocketblockers = null;
            Private_repositionManager = null;
            Private___4_intnl_returnValSymbol_Boolean = null;
            Private___0_intnl_returnValSymbol_GameObject = null;
            Private_is8Ball = null;
            Private_is4Ball = null;
            Private_is9Ball = null;
            Private_ballsW = null;
            Private___0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean = null;
            Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 = null;
            Private_ltext = null;
            Private___0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32 = null;
            Private_fourBallCueBallLocal = null;
            Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 = null;
            Private_devhit = null;
            Private_PERF_MAX = null;
            Private_desktopManager = null;
            Private_k_TABLE_HEIGHT = null;
            Private___0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32 = null;
            Private___1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 = null;
            Private___7_intnl_returnValSymbol_Boolean = null;
            Private_teamsLocal = null;
            Private_legacyPhysicsManager = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private_PERF_PHYSICS_VEL = null;
            Private_k_CUSHION_RADIUS = null;
            Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean = null;
            Private_cueSkinHook = null;
            Private_k_colour_off = null;
            Private_physicsModeLocal = null;
            Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 = null;
            Private_fbScoresLocal = null;
            Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean = null;
            Private_menuManager = null;
            Private___0_mp_B30B3C627DA342FAF687A7F730211209_Int32 = null;
            Private___12_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte = null;
            Private_k_colour4Ball_team_1 = null;
            Private_VERSION = null;
            Private___3_intnl_returnValSymbol_Boolean = null;
            Private___11_intnl_returnValSymbol_Boolean = null;
            Private_gameLive = null;
            Private_callbacks = null;
            Private_k_INNER_RADIUS = null;
            Private_canHitCueBall = null;
            Private_ballsPocketedLocal = null;
            Private___0_mp_662E199239EE18499A38900AE1882A37_Transform = null;
            Private_timerRunning = null;
            Private_PERF_PHYSICS_CUSHION = null;
            Private_k_fabricColour_9ball = null;
            Private___0_mp_92A1625974934242B7768ADAE3029AD8_Int32 = null;
            Private_snd_PointMade = null;
            Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 = null;
            Private_infReset = null;
            Private_repoMaxX = null;
            Private___0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform = null;
            Private_playerNamesLocal = null;
            Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean = null;
            Private___0_mp_E6EFA20213DE446B068D040E26995995_Byte = null;
            Private___9_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_B83162C92B798F1B9974D8E396114439_Boolean = null;
            Private_isKr4Ball = null;
            Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 = null;
            Private_balls = null;
            Private_table = null;
            Private_pockets = null;
            Private_k_vF = null;
            Private_cueSkins = null;
            Private_isReposition = null;
            Private___10_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_72681C8A3F190167F4664BA51221AA32_Int32 = null;
            Private___5_intnl_returnValSymbol_Boolean = null;
            Private_standardPhysicsManager = null;
            Private___0_mp_1316037599E67E752566661A8A5BDC31_Byte = null;
            Private_snd_btn = null;
            Private_PERF_PHYSICS_POCKET = null;
            Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = null;
            Private___0_mp_759D708A95415D8D1E83F45F073F409B_UInt32 = null;
            Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean = null;
            Private_snd_spinstop = null;
            Private___0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32 = null;
            Private___0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32 = null;
            Private_activeCueSkin = null;
            Private_practiceManager = null;
            Private_networkingManager = null;
            Private_k_colour_foul = null;
            Private___0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32 = null;
            Private_tableModels = null;
            Private_nameColorHook = null;
            Private_cameraOverrideModule = null;
            Private_k_vE = null;
            Private_PERF_MAIN = null;
            Private___0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32 = null;
            Private___1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 = null;
            Private___1_intnl_returnValSymbol_Boolean = null;
            Private_snd_Sink = null;
            Private_k_rack_position = null;
            Private_ballsP = null;
            Private___0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte = null;
            Private_aud_main = null;
            Private_previewWinningTeamLocal = null;
            Private_isTableOpenLocal = null;
            Private_k_colour4Ball_team_0 = null;
            Private_isJp4Ball = null;
            Private___0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 = null;
            Private_INITIALIZED = null;
            Private_snd_Intro = null;
            Private_teamIdLocal = null;
            Private_canPlayLocal = null;
            Private_DEPENDENCIES = null;
            Private_graphicsManager = null;
            Private_markerObj = null;
            Private___0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte = null;
            Private_winningTeamLocal = null;
            Private_k_fabricColour_8ball = null;
            Private___0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32 = null;
            Private_tableSkinHook = null;
            Private_ballsV = null;
            Private_reflection_main = null;
            Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 = null;
            Private_cueControllers = null;
            Private___0_intnl_returnValSymbol_Int32 = null;
            Private___0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean = null;
        }

        #region Getter / Setters AstroUdonVariables  of BilliardsModule

        internal bool? __0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean != null)
                {
                    return Private___0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean != null)
                    {
                        Private___0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? noGuidelineLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_noGuidelineLocal != null)
                {
                    return Private_noGuidelineLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_noGuidelineLocal != null)
                    {
                        Private_noGuidelineLocal.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioClip snd_spin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_spin != null)
                {
                    return Private_snd_spin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_spin != null)
                {
                    Private_snd_spin.Value = value;
                }
            }
        }

        internal bool? isPracticeMode
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isPracticeMode != null)
                {
                    return Private_isPracticeMode.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isPracticeMode != null)
                    {
                        Private_isPracticeMode.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean != null)
                {
                    return Private___0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean != null)
                    {
                        Private___0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? localPlayerId
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_localPlayerId != null)
                {
                    return Private_localPlayerId.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_localPlayerId != null)
                    {
                        Private_localPlayerId.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __6_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___6_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___6_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                {
                    return Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                    {
                        Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour currentPhysicsManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_currentPhysicsManager != null)
                {
                    return Private_currentPhysicsManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_currentPhysicsManager != null)
                {
                    Private_currentPhysicsManager.Value = value;
                }
            }
        }

        internal int? __1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                {
                    return Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                    {
                        Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32 != null)
                {
                    return Private___0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32 != null)
                    {
                        Private___0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? lobbyOpen
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lobbyOpen != null)
                {
                    return Private_lobbyOpen.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lobbyOpen != null)
                    {
                        Private_lobbyOpen.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32 != null)
                {
                    return Private___0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32 != null)
                    {
                        Private___0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Texture[] textureSets
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_textureSets != null)
                {
                    return Private_textureSets.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_textureSets != null)
                {
                    Private_textureSets.Value = value;
                }
            }
        }

        internal bool? __0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean != null)
                {
                    return Private___0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean != null)
                    {
                        Private___0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? k_colour_default
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_colour_default != null)
                {
                    return Private_k_colour_default.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_colour_default != null)
                    {
                        Private_k_colour_default.Value = value.Value;
                    }
                }
            }
        }

        internal float? k_TABLE_WIDTH
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_TABLE_WIDTH != null)
                {
                    return Private_k_TABLE_WIDTH.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_TABLE_WIDTH != null)
                    {
                        Private_k_TABLE_WIDTH.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject marker9ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_marker9ball != null)
                {
                    return Private_marker9ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_marker9ball != null)
                {
                    Private_marker9ball.Value = value;
                }
            }
        }

        internal uint? localTeamId
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_localTeamId != null)
                {
                    return Private_localTeamId.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_localTeamId != null)
                    {
                        Private_localTeamId.Value = value.Value;
                    }
                }
            }
        }

        internal string __0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String != null)
                {
                    return Private___0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String != null)
                {
                    Private___0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String.Value = value;
                }
            }
        }

        internal UnityEngine.AudioClip snd_NewTurn
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_NewTurn != null)
                {
                    return Private_snd_NewTurn.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_NewTurn != null)
                {
                    Private_snd_NewTurn.Value = value;
                }
            }
        }

        internal UnityEngine.Color? k_teamColour_spots
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_teamColour_spots != null)
                {
                    return Private_k_teamColour_spots.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_teamColour_spots != null)
                    {
                        Private_k_teamColour_spots.Value = value.Value;
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

        internal string __4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String != null)
                {
                    return Private___4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String != null)
                {
                    Private___4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String.Value = value;
                }
            }
        }

        internal bool? isLocalSimulationRunning
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isLocalSimulationRunning != null)
                {
                    return Private_isLocalSimulationRunning.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isLocalSimulationRunning != null)
                    {
                        Private_isLocalSimulationRunning.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_683DB5641238683D33EF621CD7CDFECD_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_683DB5641238683D33EF621CD7CDFECD_Single != null)
                {
                    return Private___0_mp_683DB5641238683D33EF621CD7CDFECD_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_683DB5641238683D33EF621CD7CDFECD_Single != null)
                    {
                        Private___0_mp_683DB5641238683D33EF621CD7CDFECD_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isGuidelineValid
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isGuidelineValid != null)
                {
                    return Private_isGuidelineValid.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isGuidelineValid != null)
                    {
                        Private_isGuidelineValid.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour cameraManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cameraManager != null)
                {
                    return Private_cameraManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cameraManager != null)
                {
                    Private_cameraManager.Value = value;
                }
            }
        }

        internal uint? timerLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerLocal != null)
                {
                    return Private_timerLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timerLocal != null)
                    {
                        Private_timerLocal.Value = value.Value;
                    }
                }
            }
        }

        internal bool? noLockingLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_noLockingLocal != null)
                {
                    return Private_noLockingLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_noLockingLocal != null)
                    {
                        Private_noLockingLocal.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour betaPhysicsManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_betaPhysicsManager != null)
                {
                    return Private_betaPhysicsManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_betaPhysicsManager != null)
                {
                    Private_betaPhysicsManager.Value = value;
                }
            }
        }

        internal UnityEngine.Color? k_fabricColour_4ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_fabricColour_4ball != null)
                {
                    return Private_k_fabricColour_4ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_fabricColour_4ball != null)
                    {
                        Private_k_fabricColour_4ball.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32 != null)
                {
                    return Private___0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32 != null)
                    {
                        Private___0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32 != null)
                {
                    return Private___0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32 != null)
                    {
                        Private___0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? tableSkinLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableSkinLocal != null)
                {
                    return Private_tableSkinLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tableSkinLocal != null)
                    {
                        Private_tableSkinLocal.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __8_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___8_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___8_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32 != null)
                {
                    return Private___0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32 != null)
                    {
                        Private___0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_mp_680845797CF11D637DB85E28135E758C_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 != null)
                {
                    return Private___1_mp_680845797CF11D637DB85E28135E758C_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 != null)
                    {
                        Private___1_mp_680845797CF11D637DB85E28135E758C_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject guideline
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_guideline != null)
                {
                    return Private_guideline.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_guideline != null)
                {
                    Private_guideline.Value = value;
                }
            }
        }

        internal int? __0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                {
                    return Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                    {
                        Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Texture2D[] tableSkins
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableSkins != null)
                {
                    return Private_tableSkins.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tableSkins != null)
                {
                    Private_tableSkins.Value = value;
                }
            }
        }

        internal uint? teamColorLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamColorLocal != null)
                {
                    return Private_teamColorLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamColorLocal != null)
                    {
                        Private_teamColorLocal.Value = value.Value;
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

        internal bool? __0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean != null)
                {
                    return Private___0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean != null)
                    {
                        Private___0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? gameModeLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameModeLocal != null)
                {
                    return Private_gameModeLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameModeLocal != null)
                    {
                        Private_gameModeLocal.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioClip snd_hitball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_hitball != null)
                {
                    return Private_snd_hitball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_hitball != null)
                {
                    Private_snd_hitball.Value = value;
                }
            }
        }

        internal int? __0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 != null)
                {
                    return Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 != null)
                    {
                        Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32.Value = value.Value;
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

        internal bool? __0_mp_3A7037A057A86331DC882253A9EA828E_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_3A7037A057A86331DC882253A9EA828E_Boolean != null)
                {
                    return Private___0_mp_3A7037A057A86331DC882253A9EA828E_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_3A7037A057A86331DC882253A9EA828E_Boolean != null)
                    {
                        Private___0_mp_3A7037A057A86331DC882253A9EA828E_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? k_POCKET_RADIUS
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_POCKET_RADIUS != null)
                {
                    return Private_k_POCKET_RADIUS.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_POCKET_RADIUS != null)
                    {
                        Private_k_POCKET_RADIUS.Value = value.Value;
                    }
                }
            }
        }

        internal int? PERF_PHYSICS_BALL
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_PERF_PHYSICS_BALL != null)
                {
                    return Private_PERF_PHYSICS_BALL.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_PERF_PHYSICS_BALL != null)
                    {
                        Private_PERF_PHYSICS_BALL.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32 != null)
                {
                    return Private___0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32 != null)
                    {
                        Private___0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_999528999B17CED7B7B9A26F2DE51012_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_999528999B17CED7B7B9A26F2DE51012_Int32 != null)
                {
                    return Private___0_mp_999528999B17CED7B7B9A26F2DE51012_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_999528999B17CED7B7B9A26F2DE51012_Int32 != null)
                    {
                        Private___0_mp_999528999B17CED7B7B9A26F2DE51012_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3 != null)
                {
                    return Private___0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3 != null)
                    {
                        Private___0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? k_teamColour_stripes
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_teamColour_stripes != null)
                {
                    return Private_k_teamColour_stripes.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_teamColour_stripes != null)
                    {
                        Private_k_teamColour_stripes.Value = value.Value;
                    }
                }
            }
        }

        internal int? PERF_PHYSICS_MAIN
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_PERF_PHYSICS_MAIN != null)
                {
                    return Private_PERF_PHYSICS_MAIN.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_PERF_PHYSICS_MAIN != null)
                    {
                        Private_PERF_PHYSICS_MAIN.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject auto_pocketblockers
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_auto_pocketblockers != null)
                {
                    return Private_auto_pocketblockers.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_auto_pocketblockers != null)
                {
                    Private_auto_pocketblockers.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour repositionManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_repositionManager != null)
                {
                    return Private_repositionManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_repositionManager != null)
                {
                    Private_repositionManager.Value = value;
                }
            }
        }

        internal bool? __4_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___4_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___4_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __0_intnl_returnValSymbol_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_GameObject != null)
                {
                    return Private___0_intnl_returnValSymbol_GameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_returnValSymbol_GameObject != null)
                {
                    Private___0_intnl_returnValSymbol_GameObject.Value = value;
                }
            }
        }

        internal bool? is8Ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_is8Ball != null)
                {
                    return Private_is8Ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_is8Ball != null)
                    {
                        Private_is8Ball.Value = value.Value;
                    }
                }
            }
        }

        internal bool? is4Ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_is4Ball != null)
                {
                    return Private_is4Ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_is4Ball != null)
                    {
                        Private_is4Ball.Value = value.Value;
                    }
                }
            }
        }

        internal bool? is9Ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_is9Ball != null)
                {
                    return Private_is9Ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_is9Ball != null)
                    {
                        Private_is9Ball.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3[] ballsW
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsW != null)
                {
                    return Private_ballsW.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ballsW != null)
                {
                    Private_ballsW.Value = value;
                }
            }
        }

        internal bool? __0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean != null)
                {
                    return Private___0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean != null)
                    {
                        Private___0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 != null)
                {
                    return Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 != null)
                    {
                        Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text ltext
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ltext != null)
                {
                    return Private_ltext.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ltext != null)
                {
                    Private_ltext.Value = value;
                }
            }
        }

        internal uint? __0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32 != null)
                {
                    return Private___0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32 != null)
                    {
                        Private___0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? fourBallCueBallLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fourBallCueBallLocal != null)
                {
                    return Private_fourBallCueBallLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_fourBallCueBallLocal != null)
                    {
                        Private_fourBallCueBallLocal.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_680845797CF11D637DB85E28135E758C_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 != null)
                {
                    return Private___0_mp_680845797CF11D637DB85E28135E758C_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 != null)
                    {
                        Private___0_mp_680845797CF11D637DB85E28135E758C_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject devhit
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_devhit != null)
                {
                    return Private_devhit.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_devhit != null)
                {
                    Private_devhit.Value = value;
                }
            }
        }

        internal int? PERF_MAX
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_PERF_MAX != null)
                {
                    return Private_PERF_MAX.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_PERF_MAX != null)
                    {
                        Private_PERF_MAX.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour desktopManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_desktopManager != null)
                {
                    return Private_desktopManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_desktopManager != null)
                {
                    Private_desktopManager.Value = value;
                }
            }
        }

        internal float? k_TABLE_HEIGHT
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_TABLE_HEIGHT != null)
                {
                    return Private_k_TABLE_HEIGHT.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_TABLE_HEIGHT != null)
                    {
                        Private_k_TABLE_HEIGHT.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32 != null)
                {
                    return Private___0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32 != null)
                    {
                        Private___0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 != null)
                {
                    return Private___1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 != null)
                    {
                        Private___1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __7_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___7_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___7_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? teamsLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamsLocal != null)
                {
                    return Private_teamsLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamsLocal != null)
                    {
                        Private_teamsLocal.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour legacyPhysicsManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_legacyPhysicsManager != null)
                {
                    return Private_legacyPhysicsManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_legacyPhysicsManager != null)
                {
                    Private_legacyPhysicsManager.Value = value;
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

        internal int? PERF_PHYSICS_VEL
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_PERF_PHYSICS_VEL != null)
                {
                    return Private_PERF_PHYSICS_VEL.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_PERF_PHYSICS_VEL != null)
                    {
                        Private_PERF_PHYSICS_VEL.Value = value.Value;
                    }
                }
            }
        }

        internal float? k_CUSHION_RADIUS
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_CUSHION_RADIUS != null)
                {
                    return Private_k_CUSHION_RADIUS.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_CUSHION_RADIUS != null)
                    {
                        Private_k_CUSHION_RADIUS.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean != null)
                {
                    return Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean != null)
                    {
                        Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour cueSkinHook
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueSkinHook != null)
                {
                    return Private_cueSkinHook.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cueSkinHook != null)
                {
                    Private_cueSkinHook.Value = value;
                }
            }
        }

        internal UnityEngine.Color? k_colour_off
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_colour_off != null)
                {
                    return Private_k_colour_off.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_colour_off != null)
                    {
                        Private_k_colour_off.Value = value.Value;
                    }
                }
            }
        }

        internal int? physicsModeLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_physicsModeLocal != null)
                {
                    return Private_physicsModeLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_physicsModeLocal != null)
                    {
                        Private_physicsModeLocal.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_mp_466037600B3424A20CCBFB190A471B9E_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 != null)
                {
                    return Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 != null)
                    {
                        Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal int[] fbScoresLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fbScoresLocal != null)
                {
                    return Private_fbScoresLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_fbScoresLocal != null)
                {
                    Private_fbScoresLocal.Value = value;
                }
            }
        }

        internal bool? __0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean != null)
                {
                    return Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean != null)
                    {
                        Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour menuManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_menuManager != null)
                {
                    return Private_menuManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_menuManager != null)
                {
                    Private_menuManager.Value = value;
                }
            }
        }

        internal int? __0_mp_B30B3C627DA342FAF687A7F730211209_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_B30B3C627DA342FAF687A7F730211209_Int32 != null)
                {
                    return Private___0_mp_B30B3C627DA342FAF687A7F730211209_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_B30B3C627DA342FAF687A7F730211209_Int32 != null)
                    {
                        Private___0_mp_B30B3C627DA342FAF687A7F730211209_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __12_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___12_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___12_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte != null)
                {
                    return Private___0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte != null)
                    {
                        Private___0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? k_colour4Ball_team_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_colour4Ball_team_1 != null)
                {
                    return Private_k_colour4Ball_team_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_colour4Ball_team_1 != null)
                    {
                        Private_k_colour4Ball_team_1.Value = value.Value;
                    }
                }
            }
        }

        internal string VERSION
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_VERSION != null)
                {
                    return Private_VERSION.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_VERSION != null)
                {
                    Private_VERSION.Value = value;
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

        internal bool? __11_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___11_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___11_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? gameLive
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameLive != null)
                {
                    return Private_gameLive.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameLive != null)
                    {
                        Private_gameLive.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour callbacks
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_callbacks != null)
                {
                    return Private_callbacks.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_callbacks != null)
                {
                    Private_callbacks.Value = value;
                }
            }
        }

        internal float? k_INNER_RADIUS
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_INNER_RADIUS != null)
                {
                    return Private_k_INNER_RADIUS.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_INNER_RADIUS != null)
                    {
                        Private_k_INNER_RADIUS.Value = value.Value;
                    }
                }
            }
        }

        internal bool? canHitCueBall
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_canHitCueBall != null)
                {
                    return Private_canHitCueBall.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_canHitCueBall != null)
                    {
                        Private_canHitCueBall.Value = value.Value;
                    }
                }
            }
        }

        internal uint? ballsPocketedLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsPocketedLocal != null)
                {
                    return Private_ballsPocketedLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_ballsPocketedLocal != null)
                    {
                        Private_ballsPocketedLocal.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __0_mp_662E199239EE18499A38900AE1882A37_Transform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_662E199239EE18499A38900AE1882A37_Transform != null)
                {
                    return Private___0_mp_662E199239EE18499A38900AE1882A37_Transform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_662E199239EE18499A38900AE1882A37_Transform != null)
                {
                    Private___0_mp_662E199239EE18499A38900AE1882A37_Transform.Value = value;
                }
            }
        }

        internal bool? timerRunning
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerRunning != null)
                {
                    return Private_timerRunning.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timerRunning != null)
                    {
                        Private_timerRunning.Value = value.Value;
                    }
                }
            }
        }

        internal int? PERF_PHYSICS_CUSHION
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_PERF_PHYSICS_CUSHION != null)
                {
                    return Private_PERF_PHYSICS_CUSHION.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_PERF_PHYSICS_CUSHION != null)
                    {
                        Private_PERF_PHYSICS_CUSHION.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? k_fabricColour_9ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_fabricColour_9ball != null)
                {
                    return Private_k_fabricColour_9ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_fabricColour_9ball != null)
                    {
                        Private_k_fabricColour_9ball.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_92A1625974934242B7768ADAE3029AD8_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_92A1625974934242B7768ADAE3029AD8_Int32 != null)
                {
                    return Private___0_mp_92A1625974934242B7768ADAE3029AD8_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_92A1625974934242B7768ADAE3029AD8_Int32 != null)
                    {
                        Private___0_mp_92A1625974934242B7768ADAE3029AD8_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioClip snd_PointMade
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_PointMade != null)
                {
                    return Private_snd_PointMade.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_PointMade != null)
                {
                    Private_snd_PointMade.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __0_mp_3693904A474BEDC44290E85B57401A21_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 != null)
                {
                    return Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 != null)
                    {
                        Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text infReset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_infReset != null)
                {
                    return Private_infReset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_infReset != null)
                {
                    Private_infReset.Value = value;
                }
            }
        }

        internal float? repoMaxX
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_repoMaxX != null)
                {
                    return Private_repoMaxX.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_repoMaxX != null)
                    {
                        Private_repoMaxX.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform != null)
                {
                    return Private___0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform != null)
                {
                    Private___0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform.Value = value;
                }
            }
        }

        internal string[] playerNamesLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerNamesLocal != null)
                {
                    return Private_playerNamesLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerNamesLocal != null)
                {
                    Private_playerNamesLocal.Value = value;
                }
            }
        }

        internal bool? __0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean != null)
                {
                    return Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean != null)
                    {
                        Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_mp_E6EFA20213DE446B068D040E26995995_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_E6EFA20213DE446B068D040E26995995_Byte != null)
                {
                    return Private___0_mp_E6EFA20213DE446B068D040E26995995_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_E6EFA20213DE446B068D040E26995995_Byte != null)
                    {
                        Private___0_mp_E6EFA20213DE446B068D040E26995995_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __9_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___9_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___9_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_B83162C92B798F1B9974D8E396114439_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_B83162C92B798F1B9974D8E396114439_Boolean != null)
                {
                    return Private___0_mp_B83162C92B798F1B9974D8E396114439_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_B83162C92B798F1B9974D8E396114439_Boolean != null)
                    {
                        Private___0_mp_B83162C92B798F1B9974D8E396114439_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isKr4Ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isKr4Ball != null)
                {
                    return Private_isKr4Ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isKr4Ball != null)
                    {
                        Private_isKr4Ball.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 != null)
                {
                    return Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 != null)
                    {
                        Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject[] balls
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_balls != null)
                {
                    return Private_balls.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_balls != null)
                {
                    Private_balls.Value = value;
                }
            }
        }

        internal UnityEngine.Transform table
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_table != null)
                {
                    return Private_table.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_table != null)
                {
                    Private_table.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject[] pockets
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_pockets != null)
                {
                    return Private_pockets.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_pockets != null)
                {
                    Private_pockets.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? k_vF
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_vF != null)
                {
                    return Private_k_vF.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_vF != null)
                    {
                        Private_k_vF.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Texture2D[] cueSkins
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueSkins != null)
                {
                    return Private_cueSkins.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cueSkins != null)
                {
                    Private_cueSkins.Value = value;
                }
            }
        }

        internal bool? isReposition
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isReposition != null)
                {
                    return Private_isReposition.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isReposition != null)
                    {
                        Private_isReposition.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __10_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___10_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___10_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_72681C8A3F190167F4664BA51221AA32_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_72681C8A3F190167F4664BA51221AA32_Int32 != null)
                {
                    return Private___0_mp_72681C8A3F190167F4664BA51221AA32_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_72681C8A3F190167F4664BA51221AA32_Int32 != null)
                    {
                        Private___0_mp_72681C8A3F190167F4664BA51221AA32_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __5_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___5_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___5_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour standardPhysicsManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_standardPhysicsManager != null)
                {
                    return Private_standardPhysicsManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_standardPhysicsManager != null)
                {
                    Private_standardPhysicsManager.Value = value;
                }
            }
        }

        internal byte? __0_mp_1316037599E67E752566661A8A5BDC31_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_1316037599E67E752566661A8A5BDC31_Byte != null)
                {
                    return Private___0_mp_1316037599E67E752566661A8A5BDC31_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_1316037599E67E752566661A8A5BDC31_Byte != null)
                    {
                        Private___0_mp_1316037599E67E752566661A8A5BDC31_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioClip snd_btn
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_btn != null)
                {
                    return Private_snd_btn.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_btn != null)
                {
                    Private_snd_btn.Value = value;
                }
            }
        }

        internal int? PERF_PHYSICS_POCKET
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_PERF_PHYSICS_POCKET != null)
                {
                    return Private_PERF_PHYSICS_POCKET.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_PERF_PHYSICS_POCKET != null)
                    {
                        Private_PERF_PHYSICS_POCKET.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean != null)
                {
                    return Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean != null)
                    {
                        Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_759D708A95415D8D1E83F45F073F409B_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_759D708A95415D8D1E83F45F073F409B_UInt32 != null)
                {
                    return Private___0_mp_759D708A95415D8D1E83F45F073F409B_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_759D708A95415D8D1E83F45F073F409B_UInt32 != null)
                    {
                        Private___0_mp_759D708A95415D8D1E83F45F073F409B_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_B5776574A01D77801AC66647C575C338_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean != null)
                {
                    return Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean != null)
                    {
                        Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioClip snd_spinstop
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_spinstop != null)
                {
                    return Private_snd_spinstop.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_spinstop != null)
                {
                    Private_snd_spinstop.Value = value;
                }
            }
        }

        internal uint? __0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32 != null)
                {
                    return Private___0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32 != null)
                    {
                        Private___0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32 != null)
                {
                    return Private___0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32 != null)
                    {
                        Private___0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? activeCueSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_activeCueSkin != null)
                {
                    return Private_activeCueSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_activeCueSkin != null)
                    {
                        Private_activeCueSkin.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour practiceManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_practiceManager != null)
                {
                    return Private_practiceManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_practiceManager != null)
                {
                    Private_practiceManager.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour networkingManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_networkingManager != null)
                {
                    return Private_networkingManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_networkingManager != null)
                {
                    Private_networkingManager.Value = value;
                }
            }
        }

        internal UnityEngine.Color? k_colour_foul
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_colour_foul != null)
                {
                    return Private_k_colour_foul.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_colour_foul != null)
                    {
                        Private_k_colour_foul.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32 != null)
                {
                    return Private___0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32 != null)
                    {
                        Private___0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] tableModels
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableModels != null)
                {
                    return Private_tableModels.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tableModels != null)
                {
                    Private_tableModels.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour nameColorHook
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_nameColorHook != null)
                {
                    return Private_nameColorHook.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_nameColorHook != null)
                {
                    Private_nameColorHook.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour cameraOverrideModule
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cameraOverrideModule != null)
                {
                    return Private_cameraOverrideModule.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cameraOverrideModule != null)
                {
                    Private_cameraOverrideModule.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? k_vE
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_vE != null)
                {
                    return Private_k_vE.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_vE != null)
                    {
                        Private_k_vE.Value = value.Value;
                    }
                }
            }
        }

        internal int? PERF_MAIN
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_PERF_MAIN != null)
                {
                    return Private_PERF_MAIN.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_PERF_MAIN != null)
                    {
                        Private_PERF_MAIN.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32 != null)
                {
                    return Private___0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32 != null)
                    {
                        Private___0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 != null)
                {
                    return Private___1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 != null)
                    {
                        Private___1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32.Value = value.Value;
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

        internal UnityEngine.AudioClip snd_Sink
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_Sink != null)
                {
                    return Private_snd_Sink.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_Sink != null)
                {
                    Private_snd_Sink.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? k_rack_position
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_rack_position != null)
                {
                    return Private_k_rack_position.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_rack_position != null)
                    {
                        Private_k_rack_position.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3[] ballsP
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsP != null)
                {
                    return Private_ballsP.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ballsP != null)
                {
                    Private_ballsP.Value = value;
                }
            }
        }

        internal byte? __0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte != null)
                {
                    return Private___0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte != null)
                    {
                        Private___0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioSource aud_main
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_aud_main != null)
                {
                    return Private_aud_main.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_aud_main != null)
                {
                    Private_aud_main.Value = value;
                }
            }
        }

        internal uint? previewWinningTeamLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_previewWinningTeamLocal != null)
                {
                    return Private_previewWinningTeamLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_previewWinningTeamLocal != null)
                    {
                        Private_previewWinningTeamLocal.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isTableOpenLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isTableOpenLocal != null)
                {
                    return Private_isTableOpenLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isTableOpenLocal != null)
                    {
                        Private_isTableOpenLocal.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? k_colour4Ball_team_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_colour4Ball_team_0 != null)
                {
                    return Private_k_colour4Ball_team_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_colour4Ball_team_0 != null)
                    {
                        Private_k_colour4Ball_team_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isJp4Ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isJp4Ball != null)
                {
                    return Private_isJp4Ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isJp4Ball != null)
                    {
                        Private_isJp4Ball.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 != null)
                {
                    return Private___0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 != null)
                    {
                        Private___0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal bool? INITIALIZED
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_INITIALIZED != null)
                {
                    return Private_INITIALIZED.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_INITIALIZED != null)
                    {
                        Private_INITIALIZED.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioClip snd_Intro
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_snd_Intro != null)
                {
                    return Private_snd_Intro.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_snd_Intro != null)
                {
                    Private_snd_Intro.Value = value;
                }
            }
        }

        internal uint? teamIdLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamIdLocal != null)
                {
                    return Private_teamIdLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamIdLocal != null)
                    {
                        Private_teamIdLocal.Value = value.Value;
                    }
                }
            }
        }

        internal bool? canPlayLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_canPlayLocal != null)
                {
                    return Private_canPlayLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_canPlayLocal != null)
                    {
                        Private_canPlayLocal.Value = value.Value;
                    }
                }
            }
        }

        internal string[] DEPENDENCIES
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_DEPENDENCIES != null)
                {
                    return Private_DEPENDENCIES.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_DEPENDENCIES != null)
                {
                    Private_DEPENDENCIES.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour graphicsManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_graphicsManager != null)
                {
                    return Private_graphicsManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_graphicsManager != null)
                {
                    Private_graphicsManager.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject markerObj
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_markerObj != null)
                {
                    return Private_markerObj.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_markerObj != null)
                {
                    Private_markerObj.Value = value;
                }
            }
        }

        internal byte? __0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte != null)
                {
                    return Private___0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte != null)
                    {
                        Private___0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal uint? winningTeamLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_winningTeamLocal != null)
                {
                    return Private_winningTeamLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_winningTeamLocal != null)
                    {
                        Private_winningTeamLocal.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? k_fabricColour_8ball
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_k_fabricColour_8ball != null)
                {
                    return Private_k_fabricColour_8ball.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_k_fabricColour_8ball != null)
                    {
                        Private_k_fabricColour_8ball.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32 != null)
                {
                    return Private___0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32 != null)
                    {
                        Private___0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour tableSkinHook
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableSkinHook != null)
                {
                    return Private_tableSkinHook.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tableSkinHook != null)
                {
                    Private_tableSkinHook.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3[] ballsV
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsV != null)
                {
                    return Private_ballsV.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ballsV != null)
                {
                    Private_ballsV.Value = value;
                }
            }
        }

        internal UnityEngine.ReflectionProbe reflection_main
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_reflection_main != null)
                {
                    return Private_reflection_main.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_reflection_main != null)
                {
                    Private_reflection_main.Value = value;
                }
            }
        }

        internal int? __0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 != null)
                {
                    return Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 != null)
                    {
                        Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] cueControllers
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueControllers != null)
                {
                    return Private_cueControllers.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cueControllers != null)
                {
                    Private_cueControllers.Value = value;
                }
            }
        }

        internal int? __0_intnl_returnValSymbol_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Int32 != null)
                {
                    return Private___0_intnl_returnValSymbol_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Int32 != null)
                    {
                        Private___0_intnl_returnValSymbol_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean != null)
                {
                    return Private___0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean != null)
                    {
                        Private___0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of BilliardsModule

        #region AstroUdonVariables  of BilliardsModule

        private AstroUdonVariable<bool> Private___0_mp_771041BD82823E9CF2922971EDE9C34C_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_noGuidelineLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_spin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isPracticeMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_6C5772F0A235B9F5383FE66F81767C0B_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_localPlayerId { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_currentPhysicsManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_70FE648E8C2EAE31DFA9B9D2F2914FFA_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_lobbyOpen { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_AF595B63AA0FB69C4B22498E36A095A2_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Texture[]> Private_textureSets { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_EE08B76E2E6C2301CC68D9083B0DB413_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_colour_default { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_k_TABLE_WIDTH { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_marker9ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_localTeamId { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_420B1477B488F9A5CD7A794A4CFC7B0A_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_NewTurn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_teamColour_spots { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_mp_F41EF41F7AA0EDDB8BD444FAA70509C5_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isLocalSimulationRunning { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_683DB5641238683D33EF621CD7CDFECD_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isGuidelineValid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_cameraManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_timerLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_noLockingLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_betaPhysicsManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_fabricColour_4ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_C58BD96944AE385F104231A0A8C6683C_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_2CEFCBB197AF3783E52A49AA7F9848B0_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_tableSkinLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_A56275423EB496D16F2C13ED7FE79AAF_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_guideline { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Texture2D[]> Private_tableSkins { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_teamColorLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_5687E3FCA95A6E314E09C59287004E65_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_gameModeLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_hitball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_3A7037A057A86331DC882253A9EA828E_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_k_POCKET_RADIUS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_PERF_PHYSICS_BALL { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_00DC3B255A6664AECA4DB772B9333755_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_999528999B17CED7B7B9A26F2DE51012_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_B3BFC36B9D419BB27EA35C956C79AD29_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_teamColour_stripes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_PERF_PHYSICS_MAIN { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_auto_pocketblockers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_repositionManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_returnValSymbol_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_is8Ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_is4Ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_is9Ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3[]> Private_ballsW { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_0C3D0EF109C69A7EEAFE26A4659EB359_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_ltext { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_8F8CF9E1C6F8F116C761FC2D2628C6B9_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_fourBallCueBallLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_devhit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_PERF_MAX { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_desktopManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_k_TABLE_HEIGHT { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_0E5D7B7DD1A51344F096ECDF409E5C98_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_teamsLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_legacyPhysicsManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_PERF_PHYSICS_VEL { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_k_CUSHION_RADIUS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_cueSkinHook { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_colour_off { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_physicsModeLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int[]> Private_fbScoresLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_menuManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_B30B3C627DA342FAF687A7F730211209_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_F8E06C8ABDB82BBD33BAFB101C58F1C8_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_colour4Ball_team_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_VERSION { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_gameLive { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_callbacks { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_k_INNER_RADIUS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_canHitCueBall { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_ballsPocketedLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___0_mp_662E199239EE18499A38900AE1882A37_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_timerRunning { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_PERF_PHYSICS_CUSHION { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_fabricColour_9ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_92A1625974934242B7768ADAE3029AD8_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_PointMade { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_infReset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_repoMaxX { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_mp_FFBA62A1A928216DFB930BEEBBFBC04A_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private_playerNamesLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_E6EFA20213DE446B068D040E26995995_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_B83162C92B798F1B9974D8E396114439_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isKr4Ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private_balls { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_table { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private_pockets { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_k_vF { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Texture2D[]> Private_cueSkins { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isReposition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_72681C8A3F190167F4664BA51221AA32_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_standardPhysicsManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_1316037599E67E752566661A8A5BDC31_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_btn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_PERF_PHYSICS_POCKET { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_759D708A95415D8D1E83F45F073F409B_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_spinstop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_3D73A418E4655C5A3983EC9C384519B7_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_DBE1A28CF0304A2624B4CD504FE8BC03_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_activeCueSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_practiceManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_networkingManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_colour_foul { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_09127EC717DE1A2EB51F4AEC88781577_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_tableModels { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_nameColorHook { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_cameraOverrideModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_k_vE { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_PERF_MAIN { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_56ED7969EC8BCAF061D0869841D8C97E_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_Sink { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_k_rack_position { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3[]> Private_ballsP { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_AD18B72B79F9650D47E55B5F06CF4AFD_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioSource> Private_aud_main { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_previewWinningTeamLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isTableOpenLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_colour4Ball_team_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isJp4Ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_198A4428CE5C5F8557F1995F2B4B8B0C_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_INITIALIZED { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_snd_Intro { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_teamIdLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_canPlayLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private_DEPENDENCIES { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_graphicsManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_markerObj { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_winningTeamLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_k_fabricColour_8ball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_F88E82EC2D6D16611D73007ED9D4433C_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_tableSkinHook { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3[]> Private_ballsV { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.ReflectionProbe> Private_reflection_main { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_cueControllers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_0D64C6A34013B5B3CCF421D884E1DBEE_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of BilliardsModule
    }
}