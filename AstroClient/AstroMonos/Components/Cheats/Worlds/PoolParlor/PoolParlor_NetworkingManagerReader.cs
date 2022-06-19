using AstroClient.ClientActions;
using System;
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
    public class PoolParlor_NetworkingManagerReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PoolParlor_NetworkingManagerReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }
        internal bool ForceGuidelineOn { get; set; } = false;
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PoolParlor))
            {
                var one = gameObject.FindUdonEvent("_AuthorizeUsers");
                if (one != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    NetworkingManagerOne = one.UdonBehaviour.ToRawUdonBehaviour();
                    Initialize_NetworkingManagerOne();
                    var two = gameObject.FindUdonEvent("_ForceUpdateBallPositions");
                    if (two != null)
                    {
                        NetworkingManagerTwo = two.UdonBehaviour.ToRawUdonBehaviour();
                        Initialize_NetworkingManagerTwo();
                    }
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

        private void OnDestroy()
        {
            ClientEventActions.OnRoomLeft -= OnRoomLeft;
            Cleanup_NetworkingManagerOne();
            Cleanup_NetworkingManagerTwo();
        }

        private RawUdonBehaviour NetworkingManagerOne { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_NetworkingManagerOne()
        {
            Private___2_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(NetworkingManagerOne, "__2_intnl_returnValSymbol_Boolean");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(NetworkingManagerOne, "__refl_const_intnl_udonTypeID");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(NetworkingManagerOne, "__refl_const_intnl_udonTypeName");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(NetworkingManagerOne, "__0_intnl_returnValSymbol_Boolean");
            Private___0_mp_D105BEA9DAA61F63A9666DE6191AD056_String = new AstroUdonVariable<string>(NetworkingManagerOne, "__0_mp_D105BEA9DAA61F63A9666DE6191AD056_String");
            Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(NetworkingManagerOne, "__1_intnl_returnValSymbol_Boolean");
        }

        private void Cleanup_NetworkingManagerOne()
        {
            Private___2_intnl_returnValSymbol_Boolean = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_D105BEA9DAA61F63A9666DE6191AD056_String = null;
            Private___1_intnl_returnValSymbol_Boolean = null;
        }

        #region Getter / Setters AstroUdonVariables  of NetworkingManagerOne

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

        internal string __0_mp_D105BEA9DAA61F63A9666DE6191AD056_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_D105BEA9DAA61F63A9666DE6191AD056_String != null)
                {
                    return Private___0_mp_D105BEA9DAA61F63A9666DE6191AD056_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_D105BEA9DAA61F63A9666DE6191AD056_String != null)
                {
                    Private___0_mp_D105BEA9DAA61F63A9666DE6191AD056_String.Value = value;
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

        #endregion Getter / Setters AstroUdonVariables  of NetworkingManagerOne

        #region AstroUdonVariables  of NetworkingManagerOne

        private AstroUdonVariable<bool> Private___2_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_D105BEA9DAA61F63A9666DE6191AD056_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of NetworkingManagerOne

        private RawUdonBehaviour NetworkingManagerTwo { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_NetworkingManagerTwo()
        {
            Private_ballsPocketedSynced = new AstroUdonVariable<uint>(NetworkingManagerTwo, "ballsPocketedSynced");
            Private_cueBallVSynced = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "cueBallVSynced");
            Private___0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32");
            Private___0_intnl_returnValSymbol_UInt16 = new AstroUdonVariable<ushort>(NetworkingManagerTwo, "__0_intnl_returnValSymbol_UInt16");
            Private___2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32");
            Private___0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32");
            Private_timerSynced = new AstroUdonVariable<uint>(NetworkingManagerTwo, "timerSynced");
            Private_timerStartSynced = new AstroUdonVariable<int>(NetworkingManagerTwo, "timerStartSynced");
            Private___1_mp_466037600B3424A20CCBFB190A471B9E_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__1_mp_466037600B3424A20CCBFB190A471B9E_Vector3");
            Private_repositionStateSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "repositionStateSynced");
            Private___1_mp_107926401C913C624D8A1933A0DB76D2_Single = new AstroUdonVariable<float>(NetworkingManagerTwo, "__1_mp_107926401C913C624D8A1933A0DB76D2_Single");
            Private___0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean = new AstroUdonVariable<bool>(NetworkingManagerTwo, "__0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean");
            Private___1_intnl_returnValSymbol_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__1_intnl_returnValSymbol_Vector3");
            Private___0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte = new AstroUdonVariable<byte>(NetworkingManagerTwo, "__0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte");
            Private___0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32");
            Private_fourBallScoresSynced = new AstroUdonVariable<int[]>(NetworkingManagerTwo, "fourBallScoresSynced");
            Private___3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32");
            Private___4_mp_107926401C913C624D8A1933A0DB76D2_Single = new AstroUdonVariable<float>(NetworkingManagerTwo, "__4_mp_107926401C913C624D8A1933A0DB76D2_Single");
            Private___0_mp_DC153239210006F82FED37DE82D118E9_UInt16 = new AstroUdonVariable<ushort>(NetworkingManagerTwo, "__0_mp_DC153239210006F82FED37DE82D118E9_UInt16");
            Private___2_mp_107926401C913C624D8A1933A0DB76D2_Single = new AstroUdonVariable<float>(NetworkingManagerTwo, "__2_mp_107926401C913C624D8A1933A0DB76D2_Single");
            Private_noGuidelineSynced = new AstroUdonVariable<bool>(NetworkingManagerTwo, "noGuidelineSynced");
            Private_ballsPSynced = new AstroUdonVariable<UnityEngine.Vector3[]>(NetworkingManagerTwo, "ballsPSynced");
            Private_tableModelSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "tableModelSynced");
            Private_isUrgentSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "isUrgentSynced");
            Private___1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32");
            Private_previewWinningTeamSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "previewWinningTeamSynced");
            Private___0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32");
            Private___0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManagerTwo, "__0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule");
            Private___refl_const_intnl_udonTypeID_Net2 = new AstroUdonVariable<long>(NetworkingManagerTwo, "__refl_const_intnl_udonTypeID");
            Private___1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32");
            Private___0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32");
            Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32");
            Private___refl_const_intnl_udonTypeName_Net2 = new AstroUdonVariable<string>(NetworkingManagerTwo, "__refl_const_intnl_udonTypeName");
            Private___0_mp_55F849824B3C125E9E0206887206C381_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__0_mp_55F849824B3C125E9E0206887206C381_Vector3");
            Private_gameStateSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "gameStateSynced");
            Private___0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32");
            Private___2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32");
            Private_winningTeamSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "winningTeamSynced");
            Private_simulationOwner = new AstroUdonVariable<string>(NetworkingManagerTwo, "simulationOwner");
            Private_teamColorSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "teamColorSynced");
            Private___0_intnl_returnValSymbol_Boolean_Net2 = new AstroUdonVariable<bool>(NetworkingManagerTwo, "__0_intnl_returnValSymbol_Boolean");
            Private_playerNamesSynced = new AstroUdonVariable<string[]>(NetworkingManagerTwo, "playerNamesSynced");
            Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean = new AstroUdonVariable<bool>(NetworkingManagerTwo, "__0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean");
            Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__0_mp_466037600B3424A20CCBFB190A471B9E_Vector3");
            Private___0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32");
            Private_isTableOpenSynced = new AstroUdonVariable<bool>(NetworkingManagerTwo, "isTableOpenSynced");
            Private_tournamentRefereeSynced = new AstroUdonVariable<string>(NetworkingManagerTwo, "tournamentRefereeSynced");
            Private___0_mp_A79C9DA0EC3D3640925991447D400F05_Byte = new AstroUdonVariable<byte>(NetworkingManagerTwo, "__0_mp_A79C9DA0EC3D3640925991447D400F05_Byte");
            Private___2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32");
            Private___1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32");
            Private___0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32");
            Private_gameModeSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "gameModeSynced");
            Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__0_mp_3693904A474BEDC44290E85B57401A21_Vector3");
            Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean = new AstroUdonVariable<bool>(NetworkingManagerTwo, "__0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean");
            Private___0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32");
            Private___0_mp_C8395ACCA8E692594D1A5362810B9652_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__0_mp_C8395ACCA8E692594D1A5362810B9652_Int32");
            Private_physicsModeSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "physicsModeSynced");
            Private___1_mp_C8395ACCA8E692594D1A5362810B9652_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__1_mp_C8395ACCA8E692594D1A5362810B9652_Int32");
            Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte = new AstroUdonVariable<byte>(NetworkingManagerTwo, "__0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte");
            Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32");
            Private___0_intnl_returnValSymbol_Color = new AstroUdonVariable<UnityEngine.Color>(NetworkingManagerTwo, "__0_intnl_returnValSymbol_Color");
            Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean = new AstroUdonVariable<bool>(NetworkingManagerTwo, "__0_mp_B5776574A01D77801AC66647C575C338_Boolean");
            Private___0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32");
            Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char = new AstroUdonVariable<char>(NetworkingManagerTwo, "__0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char");
            Private___1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32");
            Private___0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32");
            Private_turnStateSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "turnStateSynced");
            Private___1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32");
            Private_teamsSynced = new AstroUdonVariable<bool>(NetworkingManagerTwo, "teamsSynced");
            Private___1_intnl_returnValSymbol_Boolean_Net2 = new AstroUdonVariable<bool>(NetworkingManagerTwo, "__1_intnl_returnValSymbol_Boolean");
            Private___1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 = new AstroUdonVariable<uint>(NetworkingManagerTwo, "__1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32");
            Private_fourBallCueBallSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "fourBallCueBallSynced");
            Private___1_mp_3693904A474BEDC44290E85B57401A21_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__1_mp_3693904A474BEDC44290E85B57401A21_Vector3");
            Private___0_intnl_returnValSymbol_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__0_intnl_returnValSymbol_Vector3");
            Private___3_mp_107926401C913C624D8A1933A0DB76D2_Single = new AstroUdonVariable<float>(NetworkingManagerTwo, "__3_mp_107926401C913C624D8A1933A0DB76D2_Single");
            Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte = new AstroUdonVariable<byte>(NetworkingManagerTwo, "__0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte");
            Private___0_mp_72681C8A3F190167F4664BA51221AA32_Byte = new AstroUdonVariable<byte>(NetworkingManagerTwo, "__0_mp_72681C8A3F190167F4664BA51221AA32_Byte");
            Private___0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean = new AstroUdonVariable<bool>(NetworkingManagerTwo, "__0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean");
            Private_teamIdSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "teamIdSynced");
            Private_cueBallWSynced = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "cueBallWSynced");
            Private_tableSkinSynced = new AstroUdonVariable<byte>(NetworkingManagerTwo, "tableSkinSynced");
            Private___1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 = new AstroUdonVariable<int>(NetworkingManagerTwo, "__1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32");
            Private_noLockingSynced = new AstroUdonVariable<bool>(NetworkingManagerTwo, "noLockingSynced");
            Private___1_mp_55F849824B3C125E9E0206887206C381_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManagerTwo, "__1_mp_55F849824B3C125E9E0206887206C381_Vector3");
            Private___0_intnl_returnValSymbol_Single = new AstroUdonVariable<float>(NetworkingManagerTwo, "__0_intnl_returnValSymbol_Single");
            Private___0_mp_107926401C913C624D8A1933A0DB76D2_Single = new AstroUdonVariable<float>(NetworkingManagerTwo, "__0_mp_107926401C913C624D8A1933A0DB76D2_Single");
        }

        private void Cleanup_NetworkingManagerTwo()
        {
            Private_ballsPocketedSynced = null;
            Private_cueBallVSynced = null;
            Private___0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32 = null;
            Private___0_intnl_returnValSymbol_UInt16 = null;
            Private___2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = null;
            Private___0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32 = null;
            Private_timerSynced = null;
            Private_timerStartSynced = null;
            Private___1_mp_466037600B3424A20CCBFB190A471B9E_Vector3 = null;
            Private_repositionStateSynced = null;
            Private___1_mp_107926401C913C624D8A1933A0DB76D2_Single = null;
            Private___0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean = null;
            Private___1_intnl_returnValSymbol_Vector3 = null;
            Private___0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte = null;
            Private___0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 = null;
            Private_fourBallScoresSynced = null;
            Private___3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = null;
            Private___4_mp_107926401C913C624D8A1933A0DB76D2_Single = null;
            Private___0_mp_DC153239210006F82FED37DE82D118E9_UInt16 = null;
            Private___2_mp_107926401C913C624D8A1933A0DB76D2_Single = null;
            Private_noGuidelineSynced = null;
            Private_ballsPSynced = null;
            Private_tableModelSynced = null;
            Private_isUrgentSynced = null;
            Private___1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 = null;
            Private_previewWinningTeamSynced = null;
            Private___0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 = null;
            Private___0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule = null;
            Private___refl_const_intnl_udonTypeID_Net2 = null;
            Private___1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 = null;
            Private___0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32 = null;
            Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = null;
            Private___refl_const_intnl_udonTypeName_Net2 = null;
            Private___0_mp_55F849824B3C125E9E0206887206C381_Vector3 = null;
            Private_gameStateSynced = null;
            Private___0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 = null;
            Private___2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 = null;
            Private_winningTeamSynced = null;
            Private_simulationOwner = null;
            Private_teamColorSynced = null;
            Private___0_intnl_returnValSymbol_Boolean_Net2 = null;
            Private_playerNamesSynced = null;
            Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean = null;
            Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 = null;
            Private___0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 = null;
            Private_isTableOpenSynced = null;
            Private_tournamentRefereeSynced = null;
            Private___0_mp_A79C9DA0EC3D3640925991447D400F05_Byte = null;
            Private___2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = null;
            Private___1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = null;
            Private___0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 = null;
            Private_gameModeSynced = null;
            Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 = null;
            Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean = null;
            Private___0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 = null;
            Private___0_mp_C8395ACCA8E692594D1A5362810B9652_Int32 = null;
            Private_physicsModeSynced = null;
            Private___1_mp_C8395ACCA8E692594D1A5362810B9652_Int32 = null;
            Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte = null;
            Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 = null;
            Private___0_intnl_returnValSymbol_Color = null;
            Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean = null;
            Private___0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32 = null;
            Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char = null;
            Private___1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 = null;
            Private___0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32 = null;
            Private_turnStateSynced = null;
            Private___1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 = null;
            Private_teamsSynced = null;
            Private___1_intnl_returnValSymbol_Boolean_Net2 = null;
            Private___1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 = null;
            Private_fourBallCueBallSynced = null;
            Private___1_mp_3693904A474BEDC44290E85B57401A21_Vector3 = null;
            Private___0_intnl_returnValSymbol_Vector3 = null;
            Private___3_mp_107926401C913C624D8A1933A0DB76D2_Single = null;
            Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte = null;
            Private___0_mp_72681C8A3F190167F4664BA51221AA32_Byte = null;
            Private___0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean = null;
            Private_teamIdSynced = null;
            Private_cueBallWSynced = null;
            Private_tableSkinSynced = null;
            Private___1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 = null;
            Private_noLockingSynced = null;
            Private___1_mp_55F849824B3C125E9E0206887206C381_Vector3 = null;
            Private___0_intnl_returnValSymbol_Single = null;
            Private___0_mp_107926401C913C624D8A1933A0DB76D2_Single = null;
        }

        #region Getter / Setters AstroUdonVariables  of NetworkingManagerTwo

        internal uint? ballsPocketedSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsPocketedSynced != null)
                {
                    return Private_ballsPocketedSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_ballsPocketedSynced != null)
                    {
                        Private_ballsPocketedSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? cueBallVSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueBallVSynced != null)
                {
                    return Private_cueBallVSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cueBallVSynced != null)
                    {
                        Private_cueBallVSynced.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32 != null)
                {
                    return Private___0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32 != null)
                    {
                        Private___0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __0_intnl_returnValSymbol_UInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_UInt16 != null)
                {
                    return Private___0_intnl_returnValSymbol_UInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_UInt16 != null)
                    {
                        Private___0_intnl_returnValSymbol_UInt16.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                {
                    return Private___2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                    {
                        Private___2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32 != null)
                {
                    return Private___0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32 != null)
                    {
                        Private___0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? timerSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerSynced != null)
                {
                    return Private_timerSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timerSynced != null)
                    {
                        Private_timerSynced.Value = value.Value;
                    }
                }
            }
        }

        internal int? timerStartSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerStartSynced != null)
                {
                    return Private_timerStartSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timerStartSynced != null)
                    {
                        Private_timerStartSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_mp_466037600B3424A20CCBFB190A471B9E_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_466037600B3424A20CCBFB190A471B9E_Vector3 != null)
                {
                    return Private___1_mp_466037600B3424A20CCBFB190A471B9E_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_466037600B3424A20CCBFB190A471B9E_Vector3 != null)
                    {
                        Private___1_mp_466037600B3424A20CCBFB190A471B9E_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal byte? repositionStateSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_repositionStateSynced != null)
                {
                    return Private_repositionStateSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_repositionStateSynced != null)
                    {
                        Private_repositionStateSynced.Value = value.Value;
                    }
                }
            }
        }

        internal float? __1_mp_107926401C913C624D8A1933A0DB76D2_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                {
                    return Private___1_mp_107926401C913C624D8A1933A0DB76D2_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                    {
                        Private___1_mp_107926401C913C624D8A1933A0DB76D2_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean != null)
                {
                    return Private___0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean != null)
                    {
                        Private___0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_intnl_returnValSymbol_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_returnValSymbol_Vector3 != null)
                {
                    return Private___1_intnl_returnValSymbol_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_returnValSymbol_Vector3 != null)
                    {
                        Private___1_intnl_returnValSymbol_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte != null)
                {
                    return Private___0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte != null)
                    {
                        Private___0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 != null)
                {
                    return Private___0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 != null)
                    {
                        Private___0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int[] fourBallScoresSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fourBallScoresSynced != null)
                {
                    return Private_fourBallScoresSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_fourBallScoresSynced != null)
                {
                    Private_fourBallScoresSynced.Value = value;
                }
            }
        }

        internal int? __3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                {
                    return Private___3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                    {
                        Private___3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __4_mp_107926401C913C624D8A1933A0DB76D2_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                {
                    return Private___4_mp_107926401C913C624D8A1933A0DB76D2_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                    {
                        Private___4_mp_107926401C913C624D8A1933A0DB76D2_Single.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __0_mp_DC153239210006F82FED37DE82D118E9_UInt16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_DC153239210006F82FED37DE82D118E9_UInt16 != null)
                {
                    return Private___0_mp_DC153239210006F82FED37DE82D118E9_UInt16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_DC153239210006F82FED37DE82D118E9_UInt16 != null)
                    {
                        Private___0_mp_DC153239210006F82FED37DE82D118E9_UInt16.Value = value.Value;
                    }
                }
            }
        }

        internal float? __2_mp_107926401C913C624D8A1933A0DB76D2_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                {
                    return Private___2_mp_107926401C913C624D8A1933A0DB76D2_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                    {
                        Private___2_mp_107926401C913C624D8A1933A0DB76D2_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? noGuidelineSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_noGuidelineSynced != null)
                {
                    return Private_noGuidelineSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_noGuidelineSynced != null)
                    {
                        Private_noGuidelineSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3[] ballsPSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsPSynced != null)
                {
                    return Private_ballsPSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ballsPSynced != null)
                {
                    Private_ballsPSynced.Value = value;
                }
            }
        }

        internal byte? tableModelSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableModelSynced != null)
                {
                    return Private_tableModelSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tableModelSynced != null)
                    {
                        Private_tableModelSynced.Value = value.Value;
                    }
                }
            }
        }

        internal byte? isUrgentSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isUrgentSynced != null)
                {
                    return Private_isUrgentSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isUrgentSynced != null)
                    {
                        Private_isUrgentSynced.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 != null)
                {
                    return Private___1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 != null)
                    {
                        Private___1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal byte? previewWinningTeamSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_previewWinningTeamSynced != null)
                {
                    return Private_previewWinningTeamSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_previewWinningTeamSynced != null)
                    {
                        Private_previewWinningTeamSynced.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 != null)
                {
                    return Private___0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 != null)
                    {
                        Private___0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule != null)
                {
                    return Private___0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule != null)
                {
                    Private___0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule.Value = value;
                }
            }
        }

        internal long? __refl_const_intnl_udonTypeID_Net2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_const_intnl_udonTypeID_Net2 != null)
                {
                    return Private___refl_const_intnl_udonTypeID_Net2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___refl_const_intnl_udonTypeID_Net2 != null)
                    {
                        Private___refl_const_intnl_udonTypeID_Net2.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 != null)
                {
                    return Private___1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 != null)
                    {
                        Private___1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32 != null)
                {
                    return Private___0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32 != null)
                    {
                        Private___0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32.Value = value.Value;
                    }
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

        internal string __refl_const_intnl_udonTypeName_Net2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_const_intnl_udonTypeName_Net2 != null)
                {
                    return Private___refl_const_intnl_udonTypeName_Net2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___refl_const_intnl_udonTypeName_Net2 != null)
                {
                    Private___refl_const_intnl_udonTypeName_Net2.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __0_mp_55F849824B3C125E9E0206887206C381_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_55F849824B3C125E9E0206887206C381_Vector3 != null)
                {
                    return Private___0_mp_55F849824B3C125E9E0206887206C381_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_55F849824B3C125E9E0206887206C381_Vector3 != null)
                    {
                        Private___0_mp_55F849824B3C125E9E0206887206C381_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal byte? gameStateSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStateSynced != null)
                {
                    return Private_gameStateSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStateSynced != null)
                    {
                        Private_gameStateSynced.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 != null)
                {
                    return Private___0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 != null)
                    {
                        Private___0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 != null)
                {
                    return Private___2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 != null)
                    {
                        Private___2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal byte? winningTeamSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_winningTeamSynced != null)
                {
                    return Private_winningTeamSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_winningTeamSynced != null)
                    {
                        Private_winningTeamSynced.Value = value.Value;
                    }
                }
            }
        }

        internal string simulationOwner
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_simulationOwner != null)
                {
                    return Private_simulationOwner.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_simulationOwner != null)
                {
                    Private_simulationOwner.Value = value;
                }
            }
        }

        internal byte? teamColorSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamColorSynced != null)
                {
                    return Private_teamColorSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamColorSynced != null)
                    {
                        Private_teamColorSynced.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_intnl_returnValSymbol_Boolean_Net2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Boolean_Net2 != null)
                {
                    return Private___0_intnl_returnValSymbol_Boolean_Net2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Boolean_Net2 != null)
                    {
                        Private___0_intnl_returnValSymbol_Boolean_Net2.Value = value.Value;
                    }
                }
            }
        }

        internal string[] playerNamesSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerNamesSynced != null)
                {
                    return Private_playerNamesSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerNamesSynced != null)
                {
                    Private_playerNamesSynced.Value = value;
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

        internal uint? __0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 != null)
                {
                    return Private___0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 != null)
                    {
                        Private___0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isTableOpenSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isTableOpenSynced != null)
                {
                    return Private_isTableOpenSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isTableOpenSynced != null)
                    {
                        Private_isTableOpenSynced.Value = value.Value;
                    }
                }
            }
        }

        internal string tournamentRefereeSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tournamentRefereeSynced != null)
                {
                    return Private_tournamentRefereeSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tournamentRefereeSynced != null)
                {
                    Private_tournamentRefereeSynced.Value = value;
                }
            }
        }

        internal byte? __0_mp_A79C9DA0EC3D3640925991447D400F05_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_A79C9DA0EC3D3640925991447D400F05_Byte != null)
                {
                    return Private___0_mp_A79C9DA0EC3D3640925991447D400F05_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_A79C9DA0EC3D3640925991447D400F05_Byte != null)
                    {
                        Private___0_mp_A79C9DA0EC3D3640925991447D400F05_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 != null)
                {
                    return Private___2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 != null)
                    {
                        Private___2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                {
                    return Private___1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                    {
                        Private___1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 != null)
                {
                    return Private___0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 != null)
                    {
                        Private___0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal byte? gameModeSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameModeSynced != null)
                {
                    return Private_gameModeSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameModeSynced != null)
                    {
                        Private_gameModeSynced.Value = value.Value;
                    }
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

        internal int? __0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                {
                    return Private___0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 != null)
                    {
                        Private___0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_C8395ACCA8E692594D1A5362810B9652_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_C8395ACCA8E692594D1A5362810B9652_Int32 != null)
                {
                    return Private___0_mp_C8395ACCA8E692594D1A5362810B9652_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_C8395ACCA8E692594D1A5362810B9652_Int32 != null)
                    {
                        Private___0_mp_C8395ACCA8E692594D1A5362810B9652_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal byte? physicsModeSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_physicsModeSynced != null)
                {
                    return Private_physicsModeSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_physicsModeSynced != null)
                    {
                        Private_physicsModeSynced.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_mp_C8395ACCA8E692594D1A5362810B9652_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_C8395ACCA8E692594D1A5362810B9652_Int32 != null)
                {
                    return Private___1_mp_C8395ACCA8E692594D1A5362810B9652_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_C8395ACCA8E692594D1A5362810B9652_Int32 != null)
                    {
                        Private___1_mp_C8395ACCA8E692594D1A5362810B9652_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte != null)
                {
                    return Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte != null)
                    {
                        Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte.Value = value.Value;
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

        internal uint? __0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32 != null)
                {
                    return Private___0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32 != null)
                    {
                        Private___0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal char? __0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char != null)
                {
                    return Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char != null)
                    {
                        Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 != null)
                {
                    return Private___1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 != null)
                    {
                        Private___1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32 != null)
                {
                    return Private___0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32 != null)
                    {
                        Private___0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal byte? turnStateSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_turnStateSynced != null)
                {
                    return Private_turnStateSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_turnStateSynced != null)
                    {
                        Private_turnStateSynced.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 != null)
                {
                    return Private___1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 != null)
                    {
                        Private___1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? teamsSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamsSynced != null)
                {
                    return Private_teamsSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamsSynced != null)
                    {
                        Private_teamsSynced.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __1_intnl_returnValSymbol_Boolean_Net2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_returnValSymbol_Boolean_Net2 != null)
                {
                    return Private___1_intnl_returnValSymbol_Boolean_Net2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_returnValSymbol_Boolean_Net2 != null)
                    {
                        Private___1_intnl_returnValSymbol_Boolean_Net2.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 != null)
                {
                    return Private___1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 != null)
                    {
                        Private___1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal byte? fourBallCueBallSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fourBallCueBallSynced != null)
                {
                    return Private_fourBallCueBallSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_fourBallCueBallSynced != null)
                    {
                        Private_fourBallCueBallSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_mp_3693904A474BEDC44290E85B57401A21_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_3693904A474BEDC44290E85B57401A21_Vector3 != null)
                {
                    return Private___1_mp_3693904A474BEDC44290E85B57401A21_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_3693904A474BEDC44290E85B57401A21_Vector3 != null)
                    {
                        Private___1_mp_3693904A474BEDC44290E85B57401A21_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_intnl_returnValSymbol_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Vector3 != null)
                {
                    return Private___0_intnl_returnValSymbol_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Vector3 != null)
                    {
                        Private___0_intnl_returnValSymbol_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal float? __3_mp_107926401C913C624D8A1933A0DB76D2_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                {
                    return Private___3_mp_107926401C913C624D8A1933A0DB76D2_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                    {
                        Private___3_mp_107926401C913C624D8A1933A0DB76D2_Single.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte != null)
                {
                    return Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte != null)
                    {
                        Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_mp_72681C8A3F190167F4664BA51221AA32_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_72681C8A3F190167F4664BA51221AA32_Byte != null)
                {
                    return Private___0_mp_72681C8A3F190167F4664BA51221AA32_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_72681C8A3F190167F4664BA51221AA32_Byte != null)
                    {
                        Private___0_mp_72681C8A3F190167F4664BA51221AA32_Byte.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean != null)
                {
                    return Private___0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean != null)
                    {
                        Private___0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal byte? teamIdSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamIdSynced != null)
                {
                    return Private_teamIdSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamIdSynced != null)
                    {
                        Private_teamIdSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? cueBallWSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueBallWSynced != null)
                {
                    return Private_cueBallWSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cueBallWSynced != null)
                    {
                        Private_cueBallWSynced.Value = value.Value;
                    }
                }
            }
        }

        internal byte? tableSkinSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableSkinSynced != null)
                {
                    return Private_tableSkinSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tableSkinSynced != null)
                    {
                        Private_tableSkinSynced.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 != null)
                {
                    return Private___1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 != null)
                    {
                        Private___1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? noLockingSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_noLockingSynced != null)
                {
                    return Private_noLockingSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_noLockingSynced != null)
                    {
                        Private_noLockingSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_mp_55F849824B3C125E9E0206887206C381_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_55F849824B3C125E9E0206887206C381_Vector3 != null)
                {
                    return Private___1_mp_55F849824B3C125E9E0206887206C381_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_55F849824B3C125E9E0206887206C381_Vector3 != null)
                    {
                        Private___1_mp_55F849824B3C125E9E0206887206C381_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_intnl_returnValSymbol_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Single != null)
                {
                    return Private___0_intnl_returnValSymbol_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Single != null)
                    {
                        Private___0_intnl_returnValSymbol_Single.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_107926401C913C624D8A1933A0DB76D2_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                {
                    return Private___0_mp_107926401C913C624D8A1933A0DB76D2_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_107926401C913C624D8A1933A0DB76D2_Single != null)
                    {
                        Private___0_mp_107926401C913C624D8A1933A0DB76D2_Single.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of NetworkingManagerTwo

        #region AstroUdonVariables  of NetworkingManagerTwo

        private AstroUdonVariable<uint> Private_ballsPocketedSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_cueBallVSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_FE6DC31B94A320FA08E174D52B47A79D_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private___0_intnl_returnValSymbol_UInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_C3B2200D473C1E1CFAFB38DE57562853_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private_timerSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_timerStartSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_mp_466037600B3424A20CCBFB190A471B9E_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_repositionStateSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_mp_107926401C913C624D8A1933A0DB76D2_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_C8A6172BB8BB2F0DCE5EFA6868CE95BF_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_returnValSymbol_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_90A91A292BE5A4AD0D8CE17797F99C37_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int[]> Private_fourBallScoresSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_mp_107926401C913C624D8A1933A0DB76D2_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private___0_mp_DC153239210006F82FED37DE82D118E9_UInt16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_mp_107926401C913C624D8A1933A0DB76D2_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_noGuidelineSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3[]> Private_ballsPSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_tableModelSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_isUrgentSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_previewWinningTeamSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_C080B061EE3C46389E93D0B9D0537A45_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_70CFFF8C9DF82F5FBB54C858F2583E70_BilliardsModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID_Net2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_mp_9E7A9590357A5DF95BC35DBA923BCE1E_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_29DBECCA2A684307D6746BE9CC63FDF9_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName_Net2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_55F849824B3C125E9E0206887206C381_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_gameStateSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_winningTeamSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_simulationOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_teamColorSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean_Net2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private_playerNamesSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_763AA12F1A8243CFFDC8B4BBD6F57B97_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_466037600B3424A20CCBFB190A471B9E_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isTableOpenSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_tournamentRefereeSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_A79C9DA0EC3D3640925991447D400F05_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_gameModeSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_3693904A474BEDC44290E85B57401A21_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_899C0FEB179ACA6D12148E8F0C11AC2A_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_D2BCEF65ABB737DD9DF03AB45A886983_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_C8395ACCA8E692594D1A5362810B9652_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_physicsModeSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_C8395ACCA8E692594D1A5362810B9652_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_CEB87D383A7FEA7EF753C1444C1213AB_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_C79BBA9EF449750E065B2687544D0FEA_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_returnValSymbol_Color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_B5776574A01D77801AC66647C575C338_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_4230E2AD09763ECE37535A625EDB8FD2_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Char { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_mp_B6662595B7EE0AC48BCCA48A1F658DE7_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_mp_0687EE5AE9569D0D857BD44836DA5BFB_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_turnStateSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_D13983CC2D3A84F48B84B8E6275FDD70_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_teamsSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean_Net2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_mp_AE284B28DE343BBC2678731E0F4E208B_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_fourBallCueBallSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_mp_3693904A474BEDC44290E85B57401A21_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_returnValSymbol_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_mp_107926401C913C624D8A1933A0DB76D2_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_mp_72681C8A3F190167F4664BA51221AA32_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_011A336E223C93E2E565B9A6BDFD3F2D_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_teamIdSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_cueBallWSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private_tableSkinSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_3E31C0E41E38D4B91DE4B132DA25BCB4_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_noLockingSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_mp_55F849824B3C125E9E0206887206C381_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_returnValSymbol_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_107926401C913C624D8A1933A0DB76D2_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of NetworkingManagerTwo

    }
}