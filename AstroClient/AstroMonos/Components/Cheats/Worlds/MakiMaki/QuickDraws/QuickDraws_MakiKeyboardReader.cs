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

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki.QuickDraws
{
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class QuickDraws_MakiKeyboardReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public QuickDraws_MakiKeyboardReader(IntPtr ptr) : base(ptr)
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

        private void OnDestroy()
        {
            HasSubscribed = false;
            Cleanup_Keyboard();
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal RawUdonBehaviour Keyboard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.QuickDraws))
            {
                var obj = gameObject.FindUdonEvent("_OnAutoSubmitClick");
                if (obj != null)
                {
                    Keyboard = obj.RawItem;
                    HasSubscribed = true;
                    Initialize_Keyboard();
                    InvokeRepeating(nameof(RevealAnswer), 0.01f, 0.01f);
                }
                else
                {
                    Log.Error("Can't Find MakiKeyboard behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        internal void RevealAnswer()
        {
            if (!WorldModifications.WorldHacks.MakiMaki.QuickDraws.ShowAnswers) return;
            if (WorldModifications.WorldHacks.MakiMaki.QuickDraws.Answer_TextMesh_Animator != null)
            {
                WorldModifications.WorldHacks.MakiMaki.QuickDraws.Answer_TextMesh_Animator.SetText("Answer is : {fade d=5}<rainb>" + __0_mp_word_String + "</rainb>" + "{/fade" + "}", false);
            }
        }

        private void Initialize_Keyboard()
        {
            Private___0_substitutionCost_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_substitutionCost_Int32");
            Private___35_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__35_intnl_SystemInt32");
            Private___43_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__43_const_intnl_exitJumpLoc_UInt32");
            Private___0_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(Keyboard, "__0_intnl_TMProTextMeshProUGUI");
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__23_intnl_SystemBoolean");
            Private___0_this_intnl_MakiKeyboard = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Keyboard, "__0_this_intnl_MakiKeyboard");
            Private___32_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__32_intnl_SystemInt32");
            Private___77_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__77_intnl_SystemBoolean");
            Private___0_intnl_interpolatedStr_String = new AstroUdonVariable<string>(Keyboard, "__0_intnl_interpolatedStr_String");
            Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__15_intnl_SystemInt32");
            Private___40_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__40_intnl_SystemString");
            Private_keyboardSizeDecButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "keyboardSizeDecButton");
            Private___21_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__21_const_intnl_exitJumpLoc_UInt32");
            Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__12_intnl_SystemInt32");
            Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__52_intnl_SystemBoolean");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__3_const_intnl_SystemString");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__26_intnl_SystemBoolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__0_const_intnl_SystemBoolean");
            Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__41_intnl_SystemBoolean");
            Private___2_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(Keyboard, "__2_intnl_returnValSymbol_Int32");
            Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(Keyboard, "__1_intnl_UnityEngineTransform");
            Private_incorrectColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "incorrectColor");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__1_const_intnl_SystemInt32");
            Private___8_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__8_intnl_UnityEngineColor");
            Private_outputLogToggleSprites = new AstroUdonVariable<UnityEngine.Sprite[]>(Keyboard, "outputLogToggleSprites");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__1_intnl_SystemInt32");
            Private___1_mp_interactable_Boolean = new AstroUdonVariable<bool>(Keyboard, "__1_mp_interactable_Boolean");
            Private___1_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(Keyboard, "__1_intnl_returnValSymbol_Int32");
            Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__16_const_intnl_exitJumpLoc_UInt32");
            Private__keyboardOffset = new AstroUdonVariable<float>(Keyboard, "_keyboardOffset");
            Private___45_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__45_intnl_SystemInt32");
            Private___1_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__1_intnl_SystemString");
            Private___61_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__61_const_intnl_exitJumpLoc_UInt32");
            Private___9_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__9_i_Int32");
            Private___8_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__8_i_Int32");
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(Keyboard, "__0_const_intnl_VRCUdonCommonEnumsEventTiming");
            Private___50_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__50_intnl_SystemInt32");
            Private___15_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__15_intnl_SystemString");
            Private___1_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__1_i_Int32");
            Private___0_j_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_j_Int32");
            Private___0_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_i_Int32");
            Private___0_n_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_n_Int32");
            Private___0_m_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_m_Int32");
            Private___3_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__3_i_Int32");
            Private___2_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__2_i_Int32");
            Private___5_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__5_i_Int32");
            Private___4_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__4_i_Int32");
            Private___7_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__7_i_Int32");
            Private___6_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__6_i_Int32");
            Private___42_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__42_intnl_SystemInt32");
            Private___35_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__35_const_intnl_exitJumpLoc_UInt32");
            Private___53_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__53_intnl_SystemInt32");
            Private___39_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__39_const_intnl_exitJumpLoc_UInt32");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__0_const_intnl_SystemString");
            Private___56_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__56_const_intnl_exitJumpLoc_UInt32");
            Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__42_intnl_SystemBoolean");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__0_const_intnl_SystemSingle");
            Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__29_intnl_SystemBoolean");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__1_intnl_SystemSingle");
            Private_C_APP = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "C_APP");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__5_intnl_SystemBoolean");
            Private___65_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__65_intnl_SystemInt32");
            Private___46_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__46_const_intnl_exitJumpLoc_UInt32");
            Private___64_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__64_intnl_SystemString");
            Private___8_intnl_interpolatedStr_String = new AstroUdonVariable<string>(Keyboard, "__8_intnl_interpolatedStr_String");
            Private_outputLogText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(Keyboard, "outputLogText");
            Private_C_LOG = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "C_LOG");
            Private___62_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__62_intnl_SystemInt32");
            Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__10_const_intnl_exitJumpLoc_UInt32");
            Private_correctColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "correctColor");
            Private___2_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(Keyboard, "__2_intnl_returnValSymbol_Boolean");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__15_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_CharArray = new AstroUdonVariable<char[]>(Keyboard, "__0_intnl_returnValSymbol_CharArray");
            Private___11_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__11_intnl_UnityEngineColor");
            Private___24_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__24_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__5_intnl_SystemString");
            Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__34_intnl_SystemBoolean");
            Private___28_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__28_const_intnl_SystemString");
            Private_doWriteDebugLog = new AstroUdonVariable<bool>(Keyboard, "doWriteDebugLog");
            Private___83_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__83_intnl_SystemBoolean");
            Private___0_deletionCost_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_deletionCost_Int32");
            Private___1_textLength_Int32 = new AstroUdonVariable<int>(Keyboard, "__1_textLength_Int32");
            Private___28_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__28_const_intnl_exitJumpLoc_UInt32");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__6_const_intnl_SystemString");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__21_intnl_SystemBoolean");
            Private___9_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__9_intnl_UnityEngineColor");
            Private___75_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__75_intnl_SystemBoolean");
            Private__keyboardSize = new AstroUdonVariable<float>(Keyboard, "_keyboardSize");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__13_intnl_SystemBoolean");
            Private___50_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__50_const_intnl_exitJumpLoc_UInt32");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__1_const_intnl_SystemString");
            Private___0_mp_word_String = new AstroUdonVariable<string>(Keyboard, "__0_mp_word_String");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__4_const_intnl_SystemInt32");
            Private___64_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__64_intnl_SystemBoolean");
            Private___38_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__38_intnl_SystemInt32");
            Private___64_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__64_const_intnl_exitJumpLoc_UInt32");
            Private___1_const_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__1_const_intnl_SystemSingle");
            Private___0_const_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__0_const_intnl_SystemChar");
            Private___23_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__23_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__5_intnl_SystemSingle");
            Private___56_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__56_intnl_SystemInt32");
            Private___40_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__40_const_intnl_exitJumpLoc_UInt32");
            Private__characterTexts = new AstroUdonVariable<TMPro.TextMeshProUGUI[]>(Keyboard, "_characterTexts");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__18_intnl_SystemInt32");
            Private___68_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__68_const_intnl_exitJumpLoc_UInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__16_intnl_SystemBoolean");
            Private___73_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__73_intnl_SystemBoolean");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__14_const_intnl_SystemString");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__7_intnl_SystemBoolean");
            Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__20_intnl_SystemInt32");
            Private___10_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__10_intnl_UnityEngineColor");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__22_intnl_SystemBoolean");
            Private___0_closeThreshold_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_closeThreshold_Int32");
            Private___63_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__63_const_intnl_exitJumpLoc_UInt32");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___76_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__76_intnl_SystemBoolean");
            Private___43_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__43_intnl_SystemString");
            Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__23_intnl_SystemInt32");
            Private___37_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__37_const_intnl_exitJumpLoc_UInt32");
            Private_keyboardOffsetDecButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "keyboardOffsetDecButton");
            Private___69_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__69_intnl_SystemString");
            Private___0_mp_inLobby_Boolean = new AstroUdonVariable<bool>(Keyboard, "__0_mp_inLobby_Boolean");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__7_const_intnl_SystemString");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__15_const_intnl_SystemString");
            Private___0_mp_offset_Single = new AstroUdonVariable<float>(Keyboard, "__0_mp_offset_Single");
            Private___48_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__48_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(Keyboard, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__4_intnl_SystemBoolean");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__11_intnl_SystemSingle");
            Private___7_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__7_intnl_SystemChar");
            Private___34_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__34_intnl_SystemInt32");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__19_intnl_SystemBoolean");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(Keyboard, "__refl_const_intnl_udonTypeName");
            Private___1_const_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__1_const_intnl_SystemChar");
            Private__autoClear = new AstroUdonVariable<bool>(Keyboard, "_autoClear");
            Private_outputLogToggleImage = new AstroUdonVariable<UnityEngine.UI.Image>(Keyboard, "outputLogToggleImage");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__1_intnl_SystemBoolean");
            Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__38_intnl_SystemBoolean");
            Private___31_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__31_intnl_SystemInt32");
            Private___37_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__37_intnl_SystemInt32");
            Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__14_intnl_SystemInt32");
            Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__12_const_intnl_exitJumpLoc_UInt32");
            Private__outputLogHeights = new AstroUdonVariable<float[]>(Keyboard, "_outputLogHeights");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__17_const_intnl_SystemString");
            Private___0_mp_c_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_mp_c_Int32");
            Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__11_intnl_SystemInt32");
            Private___79_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__79_intnl_SystemBoolean");
            Private_C_WAR = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "C_WAR");
            Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__17_intnl_SystemInt32");
            Private___26_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__26_const_intnl_exitJumpLoc_UInt32");
            Private___12_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__12_intnl_UnityEngineColor");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__4_const_intnl_SystemString");
            Private_settingsButtonIcon = new AstroUdonVariable<UnityEngine.UI.Image>(Keyboard, "settingsButtonIcon");
            Private___81_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__81_intnl_SystemBoolean");
            Private___31_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__31_const_intnl_exitJumpLoc_UInt32");
            Private___10_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__10_intnl_SystemString");
            Private___68_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__68_intnl_SystemBoolean");
            Private___42_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__42_intnl_SystemString");
            Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__20_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__2_intnl_SystemInt32");
            Private__text = new AstroUdonVariable<char[]>(Keyboard, "_text");
            Private___52_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__52_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___67_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__67_intnl_SystemString");
            Private___44_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__44_intnl_SystemInt32");
            Private___2_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__2_intnl_SystemChar");
            Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__30_intnl_SystemBoolean");
            Private___0_mp_a_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_mp_a_Int32");
            Private___26_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__26_intnl_SystemInt32");
            Private___70_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__70_intnl_SystemString");
            Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__54_intnl_SystemBoolean");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__2_intnl_SystemString");
            Private___66_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__66_const_intnl_exitJumpLoc_UInt32");
            Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__21_const_intnl_SystemString");
            Private___41_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__41_intnl_SystemInt32");
            Private___47_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__47_intnl_SystemInt32");
            Private___26_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__26_const_intnl_SystemString");
            Private___71_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__71_const_intnl_exitJumpLoc_UInt32");
            Private___42_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__42_const_intnl_exitJumpLoc_UInt32");
            Private__characterImages = new AstroUdonVariable<UnityEngine.UI.Image[]>(Keyboard, "_characterImages");
            Private_audioManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Keyboard, "audioManager");
            Private_autoClearImage = new AstroUdonVariable<UnityEngine.UI.Image>(Keyboard, "autoClearImage");
            Private___71_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__71_intnl_SystemBoolean");
            Private___44_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__44_intnl_SystemString");
            Private___9_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__9_intnl_SystemChar");
            Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__9_const_intnl_exitJumpLoc_UInt32");
            Private___60_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__60_intnl_SystemBoolean");
            Private_C_ERR = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "C_ERR");
            Private__settingState = new AstroUdonVariable<bool>(Keyboard, "_settingState");
            Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__37_intnl_SystemBoolean");
            Private___82_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__82_intnl_SystemBoolean");
            Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__20_const_intnl_exitJumpLoc_UInt32");
            Private__correctWord = new AstroUdonVariable<char[]>(Keyboard, "_correctWord");
            Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__9_intnl_SystemInt32");
            Private___59_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__59_intnl_SystemInt32");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__2_intnl_SystemSingle");
            Private___64_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__64_intnl_SystemInt32");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__3_intnl_SystemBoolean");
            Private___1_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__1_intnl_SystemChar");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(Keyboard, "__0_intnl_returnValSymbol_Boolean");
            Private___41_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__41_intnl_SystemString");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__12_intnl_SystemBoolean");
            Private___9_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__9_intnl_SystemString");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__6_const_intnl_exitJumpLoc_UInt32");
            Private___61_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__61_intnl_SystemInt32");
            Private___67_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__67_intnl_SystemInt32");
            Private___67_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__67_intnl_SystemBoolean");
            Private_selectedColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "selectedColor");
            Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__23_const_intnl_SystemString");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__6_intnl_SystemInt32");
            Private___66_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__66_intnl_SystemString");
            Private_nextHistoryButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "nextHistoryButton");
            Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__44_intnl_SystemBoolean");
            Private___0_intnl_UnityEngineRect = new AstroUdonVariable<UnityEngine.Rect>(Keyboard, "__0_intnl_UnityEngineRect");
            Private___60_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__60_const_intnl_exitJumpLoc_UInt32");
            Private___72_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__72_intnl_SystemBoolean");
            Private__maxHistory = new AstroUdonVariable<int>(Keyboard, "_maxHistory");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__0_intnl_SystemBoolean");
            Private___0_mp_color_String = new AstroUdonVariable<string>(Keyboard, "__0_mp_color_String");
            Private___34_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__34_const_intnl_exitJumpLoc_UInt32");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__9_intnl_SystemSingle");
            Private___4_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__4_intnl_SystemChar");
            Private___0_intnl_UnityEngineVector2 = new AstroUdonVariable<UnityEngine.Vector2>(Keyboard, "__0_intnl_UnityEngineVector2");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__12_const_intnl_SystemString");
            Private___38_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__38_const_intnl_exitJumpLoc_UInt32");
            Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(Keyboard, "__0_intnl_UnityEngineGameObject");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__8_const_intnl_SystemString");
            Private__logMaxLines = new AstroUdonVariable<int>(Keyboard, "_logMaxLines");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__6_intnl_SystemSingle");
            Private___55_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__55_intnl_SystemInt32");
            Private__stringHolder = new AstroUdonVariable<UnityEngine.UI.Text>(Keyboard, "_stringHolder");
            Private___33_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__33_const_intnl_exitJumpLoc_UInt32");
            Private_CTagEnd = new AstroUdonVariable<string>(Keyboard, "CTagEnd");
            Private___52_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__52_intnl_SystemInt32");
            Private___58_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__58_intnl_SystemBoolean");
            Private___0_mp_condition_Boolean = new AstroUdonVariable<bool>(Keyboard, "__0_mp_condition_Boolean");
            Private___0_mp_state_Boolean = new AstroUdonVariable<bool>(Keyboard, "__0_mp_state_Boolean");
            Private___65_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__65_intnl_SystemString");
            Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__15_const_intnl_exitJumpLoc_UInt32");
            Private___0_intnl_SystemCharArray = new AstroUdonVariable<char[]>(Keyboard, "__0_intnl_SystemCharArray");
            Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__19_const_intnl_exitJumpLoc_UInt32");
            Private___13_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__13_intnl_SystemString");
            Private__maxKeyboardOffset = new AstroUdonVariable<float>(Keyboard, "_maxKeyboardOffset");
            Private___29_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__29_intnl_SystemInt32");
            Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__35_intnl_SystemBoolean");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__50_intnl_SystemBoolean");
            Private___55_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__55_const_intnl_exitJumpLoc_UInt32");
            Private___0_arr_CharArray = new AstroUdonVariable<char[]>(Keyboard, "__0_arr_CharArray");
            Private___22_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__22_const_intnl_exitJumpLoc_UInt32");
            Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__24_intnl_SystemBoolean");
            Private_keyboardPanel = new AstroUdonVariable<UnityEngine.Transform>(Keyboard, "keyboardPanel");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__9_const_intnl_SystemString");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__0_intnl_returnTarget_UInt32");
            Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__48_intnl_SystemBoolean");
            Private___59_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__59_const_intnl_exitJumpLoc_UInt32");
            Private___1_mp_c_Color = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__1_mp_c_Color");
            Private___30_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__30_intnl_SystemInt32");
            Private___0_width_Single = new AstroUdonVariable<float>(Keyboard, "__0_width_Single");
            Private___45_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__45_const_intnl_exitJumpLoc_UInt32");
            Private___65_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__65_intnl_SystemBoolean");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__0_intnl_SystemString");
            Private___0_mp_c_Color = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__0_mp_c_Color");
            Private_keyboardSizeText = new AstroUdonVariable<UnityEngine.UI.Text>(Keyboard, "keyboardSizeText");
            Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__33_intnl_SystemBoolean");
            Private___57_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__57_intnl_SystemBoolean");
            Private___33_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__33_intnl_SystemInt32");
            Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__10_intnl_SystemInt32");
            Private___49_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__49_const_intnl_exitJumpLoc_UInt32");
            Private___47_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__47_intnl_SystemString");
            Private_outputParent = new AstroUdonVariable<UnityEngine.RectTransform>(Keyboard, "outputParent");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(Keyboard, "__0_const_intnl_SystemUInt32");
            Private__minKeyboardSize = new AstroUdonVariable<float>(Keyboard, "_minKeyboardSize");
            Private___62_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__62_const_intnl_exitJumpLoc_UInt32");
            Private___0_min_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_min_Int32");
            Private__pointerIndex = new AstroUdonVariable<int>(Keyboard, "_pointerIndex");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__9_intnl_SystemBoolean");
            Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__13_intnl_SystemInt32");
            Private___0_intnl_UnityEngineUIButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "__0_intnl_UnityEngineUIButton");
            Private___36_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__36_const_intnl_exitJumpLoc_UInt32");
            Private___63_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__63_intnl_SystemBoolean");
            Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__36_intnl_SystemBoolean");
            Private_appname = new AstroUdonVariable<string>(Keyboard, "appname");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__0_intnl_SystemSingle");
            Private_outputLogTransform = new AstroUdonVariable<UnityEngine.RectTransform>(Keyboard, "outputLogTransform");
            Private___12_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__12_intnl_SystemString");
            Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__40_intnl_SystemBoolean");
            Private___25_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__25_intnl_SystemInt32");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__18_const_intnl_SystemString");
            Private___40_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__40_intnl_SystemInt32");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__13_intnl_SystemSingle");
            Private_keyboardOffsetText = new AstroUdonVariable<UnityEngine.UI.Text>(Keyboard, "keyboardOffsetText");
            Private___66_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__66_intnl_SystemBoolean");
            Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__22_intnl_SystemInt32");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__4_intnl_SystemInt32");
            Private__submitHistory = new AstroUdonVariable<System.Object[]>(Keyboard, "_submitHistory");
            Private___43_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__43_intnl_SystemInt32");
            Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__14_intnl_SystemSingle");
            Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Keyboard, "__3_intnl_UnityEngineVector3");
            Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__47_intnl_SystemBoolean");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__4_intnl_SystemString");
            Private__isBig = new AstroUdonVariable<bool>(Keyboard, "_isBig");
            Private___58_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__58_intnl_SystemInt32");
            Private___14_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__14_intnl_SystemString");
            Private___46_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__46_intnl_SystemString");
            Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__19_const_intnl_SystemString");
            Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__17_const_intnl_exitJumpLoc_UInt32");
            Private__isCorrect = new AstroUdonVariable<bool>(Keyboard, "_isCorrect");
            Private___1_mp_o_Object = new AstroUdonVariable<string>(Keyboard, "__1_mp_o_Object");
            Private___30_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__30_const_intnl_exitJumpLoc_UInt32");
            Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__39_intnl_SystemBoolean");
            Private___0_mp_text_String = new AstroUdonVariable<string>(Keyboard, "__0_mp_text_String");
            Private___60_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__60_intnl_SystemInt32");
            Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__28_intnl_SystemBoolean");
            Private___36_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__36_intnl_SystemInt32");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__6_intnl_SystemBoolean");
            Private___0_mp_chars_CharArray = new AstroUdonVariable<char[]>(Keyboard, "__0_mp_chars_CharArray");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__4_intnl_SystemSingle");
            Private___11_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__11_intnl_SystemString");
            Private___1_mp_state_Boolean = new AstroUdonVariable<bool>(Keyboard, "__1_mp_state_Boolean");
            Private___63_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__63_intnl_SystemInt32");
            Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__24_const_intnl_SystemString");
            Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__16_intnl_SystemInt32");
            Private___69_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__69_intnl_SystemBoolean");
            Private___57_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__57_const_intnl_exitJumpLoc_UInt32");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__12_intnl_SystemSingle");
            Private___0_textLength_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_textLength_Int32");
            Private_scribbleManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Keyboard, "scribbleManager");
            Private___70_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__70_const_intnl_exitJumpLoc_UInt32");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__14_intnl_SystemBoolean");
            Private___0_insertionCost_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_insertionCost_Int32");
            Private_keyboardSizeIncButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "keyboardSizeIncButton");
            Private___4_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__4_intnl_UnityEngineColor");
            Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(Keyboard, "__1_intnl_returnValSymbol_Boolean");
            Private___47_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__47_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__3_intnl_SystemInt32");
            Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__31_intnl_SystemBoolean");
            Private___55_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__55_intnl_SystemBoolean");
            Private___25_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__25_const_intnl_SystemString");
            Private_prevHistoryButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "prevHistoryButton");
            Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__11_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__8_intnl_SystemBoolean");
            Private___45_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__45_intnl_SystemString");
            Private___1_intnl_interpolatedStr_String = new AstroUdonVariable<string>(Keyboard, "__1_intnl_interpolatedStr_String");
            Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__20_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Keyboard, "__2_intnl_UnityEngineVector3");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__3_intnl_SystemString");
            Private___0_mp_b_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_mp_b_Int32");
            Private___54_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__54_intnl_SystemInt32");
            Private___74_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__74_intnl_SystemBoolean");
            Private___0_isChar_Boolean = new AstroUdonVariable<bool>(Keyboard, "__0_isChar_Boolean");
            Private__interactable = new AstroUdonVariable<bool>(Keyboard, "_interactable");
            Private___25_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__25_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__46_intnl_SystemInt32");
            Private___7_intnl_interpolatedStr_String = new AstroUdonVariable<string>(Keyboard, "__7_intnl_interpolatedStr_String");
            Private___0_c_Char = new AstroUdonVariable<char>(Keyboard, "__0_c_Char");
            Private___61_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__61_intnl_SystemBoolean");
            Private___0_stringDif_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_stringDif_Int32");
            Private___51_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__51_intnl_SystemInt32");
            Private___3_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__3_intnl_SystemChar");
            Private___57_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__57_intnl_SystemInt32");
            Private___29_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__29_const_intnl_exitJumpLoc_UInt32");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Keyboard, "__1_intnl_UnityEngineVector3");
            Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__53_intnl_SystemBoolean");
            Private___0_mp_c_Char = new AstroUdonVariable<char>(Keyboard, "__0_mp_c_Char");
            Private___4_intnl_interpolatedStr_String = new AstroUdonVariable<string>(Keyboard, "__4_intnl_interpolatedStr_String");
            Private___10_i_Int32 = new AstroUdonVariable<int>(Keyboard, "__10_i_Int32");
            Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__27_intnl_SystemBoolean");
            Private___51_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__51_const_intnl_exitJumpLoc_UInt32");
            Private__minKeyboardOffset = new AstroUdonVariable<float>(Keyboard, "_minKeyboardOffset");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__3_intnl_SystemSingle");
            Private___13_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__13_intnl_UnityEngineColor");
            Private___1_intnl_UnityEngineUIButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "__1_intnl_UnityEngineUIButton");
            Private___27_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__27_const_intnl_SystemString");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Keyboard, "__0_intnl_UnityEngineVector3");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__10_const_intnl_SystemString");
            Private___65_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__65_const_intnl_exitJumpLoc_UInt32");
            Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__32_intnl_SystemBoolean");
            Private___56_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__56_intnl_SystemBoolean");
            Private___41_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__41_const_intnl_exitJumpLoc_UInt32");
            Private__logLinesCount = new AstroUdonVariable<int>(Keyboard, "_logLinesCount");
            Private___66_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__66_intnl_SystemInt32");
            Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__45_intnl_SystemBoolean");
            Private___28_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__28_intnl_SystemInt32");
            Private___69_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__69_const_intnl_exitJumpLoc_UInt32");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__7_intnl_SystemInt32");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(Keyboard, "__0_intnl_UnityEngineTransform");
            Private___6_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__6_intnl_SystemChar");
            Private___6_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__6_intnl_UnityEngineColor");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__1_const_intnl_SystemBoolean");
            Private___0_mp_n_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_mp_n_Int32");
            Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__0_intnl_UnityEngineColor");
            Private___62_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__62_intnl_SystemBoolean");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__11_const_intnl_SystemString");
            Private___68_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__68_intnl_SystemString");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__16_const_intnl_SystemString");
            Private__maxKeyboardSize = new AstroUdonVariable<float>(Keyboard, "_maxKeyboardSize");
            Private_logger = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Keyboard, "logger");
            Private___32_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__32_const_intnl_exitJumpLoc_UInt32");
            Private___7_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__7_intnl_UnityEngineColor");
            Private___2_intnl_UnityEngineUIImage = new AstroUdonVariable<UnityEngine.UI.Image>(Keyboard, "__2_intnl_UnityEngineUIImage");
            Private___5_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__5_intnl_UnityEngineColor");
            Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__43_intnl_SystemBoolean");
            Private___0_mp_interactable_Boolean = new AstroUdonVariable<bool>(Keyboard, "__0_mp_interactable_Boolean");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__18_intnl_SystemBoolean");
            Private___0_characterButton_Button = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "__0_characterButton_Button");
            Private___14_intnl_SystemCharArray = new AstroUdonVariable<char[]>(Keyboard, "__14_intnl_SystemCharArray");
            Private___0_mp_index_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_mp_index_Int32");
            Private___0_emptySlot_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_emptySlot_Int32");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__10_intnl_SystemSingle");
            Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__14_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__5_intnl_SystemChar");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__3_const_intnl_SystemInt32");
            Private___0_index_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_index_Int32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__7_intnl_SystemSingle");
            Private___1_intnl_UnityEngineUIImage = new AstroUdonVariable<UnityEngine.UI.Image>(Keyboard, "__1_intnl_UnityEngineUIImage");
            Private___0_mp_size_Single = new AstroUdonVariable<float>(Keyboard, "__0_mp_size_Single");
            Private___59_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__59_intnl_SystemBoolean");
            Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__18_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__46_intnl_SystemBoolean");
            Private___39_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__39_intnl_SystemInt32");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__13_const_intnl_SystemString");
            Private___78_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__78_intnl_SystemBoolean");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__8_intnl_SystemInt32");
            Private__slotCount = new AstroUdonVariable<int>(Keyboard, "_slotCount");
            Private___0_intnl_UnityEngineUIImage = new AstroUdonVariable<UnityEngine.UI.Image>(Keyboard, "__0_intnl_UnityEngineUIImage");
            Private___80_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__80_intnl_SystemBoolean");
            Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__19_intnl_SystemInt32");
            Private_normalColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "normalColor");
            Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__24_intnl_SystemInt32");
            Private___54_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__54_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_UnityEngineUIButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "__2_intnl_UnityEngineUIButton");
            Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__13_const_intnl_exitJumpLoc_UInt32");
            Private_keyboardOffsetIncButton = new AstroUdonVariable<UnityEngine.UI.Button>(Keyboard, "keyboardOffsetIncButton");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__10_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__2_intnl_UnityEngineColor");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__2_const_intnl_SystemString");
            Private_autoSubmitImage = new AstroUdonVariable<UnityEngine.UI.Image>(Keyboard, "autoSubmitImage");
            Private___8_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__8_intnl_SystemChar");
            Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__21_intnl_SystemInt32");
            Private___27_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__27_const_intnl_exitJumpLoc_UInt32");
            Private___27_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__27_intnl_SystemInt32");
            Private___58_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__58_const_intnl_exitJumpLoc_UInt32");
            Private___44_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__44_const_intnl_exitJumpLoc_UInt32");
            Private___2_const_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__2_const_intnl_SystemSingle");
            Private_settingsPanel = new AstroUdonVariable<UnityEngine.GameObject>(Keyboard, "settingsPanel");
            Private_offColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "offColor");
            Private___2_intnl_returnValSymbol_String = new AstroUdonVariable<string>(Keyboard, "__2_intnl_returnValSymbol_String");
            Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__51_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__0_const_intnl_SystemInt32");
            Private___0_intnl_SystemChar = new AstroUdonVariable<char>(Keyboard, "__0_intnl_SystemChar");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__25_intnl_SystemBoolean");
            Private___48_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__48_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__3_intnl_UnityEngineColor");
            Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(Keyboard, "__22_const_intnl_SystemString");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(Keyboard, "__8_intnl_SystemSingle");
            Private__historyIndex = new AstroUdonVariable<int>(Keyboard, "_historyIndex");
            Private___70_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__70_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Keyboard, "__1_intnl_UnityEngineColor");
            Private___49_intnl_SystemInt32 = new AstroUdonVariable<int>(Keyboard, "__49_intnl_SystemInt32");
            Private___1_intnl_returnValSymbol_String = new AstroUdonVariable<string>(Keyboard, "__1_intnl_returnValSymbol_String");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__17_intnl_SystemBoolean");
            Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(Keyboard, "__49_intnl_SystemBoolean");
            Private___53_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__53_const_intnl_exitJumpLoc_UInt32");
            Private__autoSubmit = new AstroUdonVariable<bool>(Keyboard, "_autoSubmit");
            Private__characterButtons = new AstroUdonVariable<UnityEngine.UI.Button[]>(Keyboard, "_characterButtons");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(Keyboard, "__0_intnl_returnValSymbol_Int32");
            Private___67_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Keyboard, "__67_const_intnl_exitJumpLoc_UInt32");
        }

        private void Cleanup_Keyboard()
        {
            Private___0_substitutionCost_Int32 = null;
            Private___35_intnl_SystemInt32 = null;
            Private___43_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_intnl_TMProTextMeshProUGUI = null;
            Private___23_intnl_SystemBoolean = null;
            Private___0_this_intnl_MakiKeyboard = null;
            Private___32_intnl_SystemInt32 = null;
            Private___77_intnl_SystemBoolean = null;
            Private___0_intnl_interpolatedStr_String = null;
            Private___15_intnl_SystemInt32 = null;
            Private___40_intnl_SystemString = null;
            Private_keyboardSizeDecButton = null;
            Private___21_const_intnl_exitJumpLoc_UInt32 = null;
            Private___12_intnl_SystemInt32 = null;
            Private___52_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemString = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___26_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___41_intnl_SystemBoolean = null;
            Private___2_intnl_returnValSymbol_Int32 = null;
            Private___1_intnl_UnityEngineTransform = null;
            Private_incorrectColor = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___8_intnl_UnityEngineColor = null;
            Private_outputLogToggleSprites = null;
            Private___1_intnl_SystemInt32 = null;
            Private___1_mp_interactable_Boolean = null;
            Private___1_intnl_returnValSymbol_Int32 = null;
            Private___16_const_intnl_exitJumpLoc_UInt32 = null;
            Private__keyboardOffset = null;
            Private___45_intnl_SystemInt32 = null;
            Private___1_intnl_SystemString = null;
            Private___61_const_intnl_exitJumpLoc_UInt32 = null;
            Private___9_i_Int32 = null;
            Private___8_i_Int32 = null;
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = null;
            Private___50_intnl_SystemInt32 = null;
            Private___15_intnl_SystemString = null;
            Private___1_i_Int32 = null;
            Private___0_j_Int32 = null;
            Private___0_i_Int32 = null;
            Private___0_n_Int32 = null;
            Private___0_m_Int32 = null;
            Private___3_i_Int32 = null;
            Private___2_i_Int32 = null;
            Private___5_i_Int32 = null;
            Private___4_i_Int32 = null;
            Private___7_i_Int32 = null;
            Private___6_i_Int32 = null;
            Private___42_intnl_SystemInt32 = null;
            Private___35_const_intnl_exitJumpLoc_UInt32 = null;
            Private___53_intnl_SystemInt32 = null;
            Private___39_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_const_intnl_SystemString = null;
            Private___56_const_intnl_exitJumpLoc_UInt32 = null;
            Private___42_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemSingle = null;
            Private___29_intnl_SystemBoolean = null;
            Private___1_intnl_SystemSingle = null;
            Private_C_APP = null;
            Private___5_intnl_SystemBoolean = null;
            Private___65_intnl_SystemInt32 = null;
            Private___46_const_intnl_exitJumpLoc_UInt32 = null;
            Private___64_intnl_SystemString = null;
            Private___8_intnl_interpolatedStr_String = null;
            Private_outputLogText = null;
            Private_C_LOG = null;
            Private___62_intnl_SystemInt32 = null;
            Private___10_const_intnl_exitJumpLoc_UInt32 = null;
            Private_correctColor = null;
            Private___2_intnl_returnValSymbol_Boolean = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___15_intnl_SystemBoolean = null;
            Private___0_intnl_returnValSymbol_CharArray = null;
            Private___11_intnl_UnityEngineColor = null;
            Private___24_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_intnl_SystemString = null;
            Private___34_intnl_SystemBoolean = null;
            Private___28_const_intnl_SystemString = null;
            Private_doWriteDebugLog = null;
            Private___83_intnl_SystemBoolean = null;
            Private___0_deletionCost_Int32 = null;
            Private___1_textLength_Int32 = null;
            Private___28_const_intnl_exitJumpLoc_UInt32 = null;
            Private___6_const_intnl_SystemString = null;
            Private___21_intnl_SystemBoolean = null;
            Private___9_intnl_UnityEngineColor = null;
            Private___75_intnl_SystemBoolean = null;
            Private__keyboardSize = null;
            Private___5_const_intnl_exitJumpLoc_UInt32 = null;
            Private___13_intnl_SystemBoolean = null;
            Private___50_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_const_intnl_SystemString = null;
            Private___0_mp_word_String = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private___64_intnl_SystemBoolean = null;
            Private___38_intnl_SystemInt32 = null;
            Private___64_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_const_intnl_SystemSingle = null;
            Private___0_const_intnl_SystemChar = null;
            Private___23_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_intnl_SystemSingle = null;
            Private___56_intnl_SystemInt32 = null;
            Private___40_const_intnl_exitJumpLoc_UInt32 = null;
            Private__characterTexts = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___18_intnl_SystemInt32 = null;
            Private___68_const_intnl_exitJumpLoc_UInt32 = null;
            Private___16_intnl_SystemBoolean = null;
            Private___73_intnl_SystemBoolean = null;
            Private___14_const_intnl_SystemString = null;
            Private___7_intnl_SystemBoolean = null;
            Private___20_intnl_SystemInt32 = null;
            Private___10_intnl_UnityEngineColor = null;
            Private___22_intnl_SystemBoolean = null;
            Private___0_closeThreshold_Int32 = null;
            Private___63_const_intnl_exitJumpLoc_UInt32 = null;
            Private___7_const_intnl_exitJumpLoc_UInt32 = null;
            Private___76_intnl_SystemBoolean = null;
            Private___43_intnl_SystemString = null;
            Private___23_intnl_SystemInt32 = null;
            Private___37_const_intnl_exitJumpLoc_UInt32 = null;
            Private_keyboardOffsetDecButton = null;
            Private___69_intnl_SystemString = null;
            Private___0_mp_inLobby_Boolean = null;
            Private___7_const_intnl_SystemString = null;
            Private___15_const_intnl_SystemString = null;
            Private___0_mp_offset_Single = null;
            Private___48_intnl_SystemInt32 = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___11_intnl_SystemSingle = null;
            Private___7_intnl_SystemChar = null;
            Private___34_intnl_SystemInt32 = null;
            Private___19_intnl_SystemBoolean = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___1_const_intnl_SystemChar = null;
            Private__autoClear = null;
            Private_outputLogToggleImage = null;
            Private___1_intnl_SystemBoolean = null;
            Private___38_intnl_SystemBoolean = null;
            Private___31_intnl_SystemInt32 = null;
            Private___37_intnl_SystemInt32 = null;
            Private___14_intnl_SystemInt32 = null;
            Private___12_const_intnl_exitJumpLoc_UInt32 = null;
            Private__outputLogHeights = null;
            Private___17_const_intnl_SystemString = null;
            Private___0_mp_c_Int32 = null;
            Private___11_intnl_SystemInt32 = null;
            Private___79_intnl_SystemBoolean = null;
            Private_C_WAR = null;
            Private___17_intnl_SystemInt32 = null;
            Private___26_const_intnl_exitJumpLoc_UInt32 = null;
            Private___12_intnl_UnityEngineColor = null;
            Private___4_const_intnl_SystemString = null;
            Private_settingsButtonIcon = null;
            Private___81_intnl_SystemBoolean = null;
            Private___31_const_intnl_exitJumpLoc_UInt32 = null;
            Private___10_intnl_SystemString = null;
            Private___68_intnl_SystemBoolean = null;
            Private___42_intnl_SystemString = null;
            Private___20_const_intnl_SystemString = null;
            Private___11_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private__text = null;
            Private___52_const_intnl_exitJumpLoc_UInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___67_intnl_SystemString = null;
            Private___44_intnl_SystemInt32 = null;
            Private___2_intnl_SystemChar = null;
            Private___30_intnl_SystemBoolean = null;
            Private___0_mp_a_Int32 = null;
            Private___26_intnl_SystemInt32 = null;
            Private___70_intnl_SystemString = null;
            Private___54_intnl_SystemBoolean = null;
            Private___2_intnl_SystemString = null;
            Private___66_const_intnl_exitJumpLoc_UInt32 = null;
            Private___21_const_intnl_SystemString = null;
            Private___41_intnl_SystemInt32 = null;
            Private___47_intnl_SystemInt32 = null;
            Private___26_const_intnl_SystemString = null;
            Private___71_const_intnl_exitJumpLoc_UInt32 = null;
            Private___42_const_intnl_exitJumpLoc_UInt32 = null;
            Private__characterImages = null;
            Private_audioManager = null;
            Private_autoClearImage = null;
            Private___71_intnl_SystemBoolean = null;
            Private___44_intnl_SystemString = null;
            Private___9_intnl_SystemChar = null;
            Private___9_const_intnl_exitJumpLoc_UInt32 = null;
            Private___60_intnl_SystemBoolean = null;
            Private_C_ERR = null;
            Private__settingState = null;
            Private___37_intnl_SystemBoolean = null;
            Private___82_intnl_SystemBoolean = null;
            Private___20_const_intnl_exitJumpLoc_UInt32 = null;
            Private__correctWord = null;
            Private___9_intnl_SystemInt32 = null;
            Private___59_intnl_SystemInt32 = null;
            Private___2_intnl_SystemSingle = null;
            Private___64_intnl_SystemInt32 = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___1_intnl_SystemChar = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___41_intnl_SystemString = null;
            Private___12_intnl_SystemBoolean = null;
            Private___9_intnl_SystemString = null;
            Private___6_const_intnl_exitJumpLoc_UInt32 = null;
            Private___61_intnl_SystemInt32 = null;
            Private___67_intnl_SystemInt32 = null;
            Private___67_intnl_SystemBoolean = null;
            Private_selectedColor = null;
            Private___23_const_intnl_SystemString = null;
            Private___6_intnl_SystemInt32 = null;
            Private___66_intnl_SystemString = null;
            Private_nextHistoryButton = null;
            Private___44_intnl_SystemBoolean = null;
            Private___0_intnl_UnityEngineRect = null;
            Private___60_const_intnl_exitJumpLoc_UInt32 = null;
            Private___72_intnl_SystemBoolean = null;
            Private__maxHistory = null;
            Private___0_intnl_SystemBoolean = null;
            Private___0_mp_color_String = null;
            Private___34_const_intnl_exitJumpLoc_UInt32 = null;
            Private___9_intnl_SystemSingle = null;
            Private___4_intnl_SystemChar = null;
            Private___0_intnl_UnityEngineVector2 = null;
            Private___12_const_intnl_SystemString = null;
            Private___38_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_intnl_UnityEngineGameObject = null;
            Private___8_const_intnl_SystemString = null;
            Private__logMaxLines = null;
            Private___6_intnl_SystemSingle = null;
            Private___55_intnl_SystemInt32 = null;
            Private__stringHolder = null;
            Private___33_const_intnl_exitJumpLoc_UInt32 = null;
            Private_CTagEnd = null;
            Private___52_intnl_SystemInt32 = null;
            Private___58_intnl_SystemBoolean = null;
            Private___0_mp_condition_Boolean = null;
            Private___0_mp_state_Boolean = null;
            Private___65_intnl_SystemString = null;
            Private___15_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_intnl_SystemCharArray = null;
            Private___19_const_intnl_exitJumpLoc_UInt32 = null;
            Private___13_intnl_SystemString = null;
            Private__maxKeyboardOffset = null;
            Private___29_intnl_SystemInt32 = null;
            Private___35_intnl_SystemBoolean = null;
            Private___8_const_intnl_exitJumpLoc_UInt32 = null;
            Private___50_intnl_SystemBoolean = null;
            Private___55_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_arr_CharArray = null;
            Private___22_const_intnl_exitJumpLoc_UInt32 = null;
            Private___24_intnl_SystemBoolean = null;
            Private_keyboardPanel = null;
            Private___9_const_intnl_SystemString = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___48_intnl_SystemBoolean = null;
            Private___59_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_mp_c_Color = null;
            Private___30_intnl_SystemInt32 = null;
            Private___0_width_Single = null;
            Private___45_const_intnl_exitJumpLoc_UInt32 = null;
            Private___65_intnl_SystemBoolean = null;
            Private___0_intnl_SystemString = null;
            Private___0_mp_c_Color = null;
            Private_keyboardSizeText = null;
            Private___33_intnl_SystemBoolean = null;
            Private___57_intnl_SystemBoolean = null;
            Private___33_intnl_SystemInt32 = null;
            Private___10_intnl_SystemInt32 = null;
            Private___49_const_intnl_exitJumpLoc_UInt32 = null;
            Private___47_intnl_SystemString = null;
            Private_outputParent = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private__minKeyboardSize = null;
            Private___62_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_min_Int32 = null;
            Private__pointerIndex = null;
            Private___9_intnl_SystemBoolean = null;
            Private___13_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineUIButton = null;
            Private___36_const_intnl_exitJumpLoc_UInt32 = null;
            Private___63_intnl_SystemBoolean = null;
            Private___36_intnl_SystemBoolean = null;
            Private_appname = null;
            Private___0_intnl_SystemSingle = null;
            Private_outputLogTransform = null;
            Private___12_intnl_SystemString = null;
            Private___40_intnl_SystemBoolean = null;
            Private___25_intnl_SystemInt32 = null;
            Private___18_const_intnl_SystemString = null;
            Private___40_intnl_SystemInt32 = null;
            Private___13_intnl_SystemSingle = null;
            Private_keyboardOffsetText = null;
            Private___66_intnl_SystemBoolean = null;
            Private___22_intnl_SystemInt32 = null;
            Private___4_intnl_SystemInt32 = null;
            Private__submitHistory = null;
            Private___43_intnl_SystemInt32 = null;
            Private___14_intnl_SystemSingle = null;
            Private___3_intnl_UnityEngineVector3 = null;
            Private___47_intnl_SystemBoolean = null;
            Private___4_intnl_SystemString = null;
            Private__isBig = null;
            Private___58_intnl_SystemInt32 = null;
            Private___14_intnl_SystemString = null;
            Private___46_intnl_SystemString = null;
            Private___19_const_intnl_SystemString = null;
            Private___17_const_intnl_exitJumpLoc_UInt32 = null;
            Private__isCorrect = null;
            Private___1_mp_o_Object = null;
            Private___30_const_intnl_exitJumpLoc_UInt32 = null;
            Private___39_intnl_SystemBoolean = null;
            Private___0_mp_text_String = null;
            Private___60_intnl_SystemInt32 = null;
            Private___28_intnl_SystemBoolean = null;
            Private___36_intnl_SystemInt32 = null;
            Private___6_intnl_SystemBoolean = null;
            Private___0_mp_chars_CharArray = null;
            Private___4_intnl_SystemSingle = null;
            Private___11_intnl_SystemString = null;
            Private___1_mp_state_Boolean = null;
            Private___63_intnl_SystemInt32 = null;
            Private___24_const_intnl_SystemString = null;
            Private___16_intnl_SystemInt32 = null;
            Private___69_intnl_SystemBoolean = null;
            Private___57_const_intnl_exitJumpLoc_UInt32 = null;
            Private___12_intnl_SystemSingle = null;
            Private___0_textLength_Int32 = null;
            Private_scribbleManager = null;
            Private___70_const_intnl_exitJumpLoc_UInt32 = null;
            Private___14_intnl_SystemBoolean = null;
            Private___0_insertionCost_Int32 = null;
            Private_keyboardSizeIncButton = null;
            Private___4_intnl_UnityEngineColor = null;
            Private___1_intnl_returnValSymbol_Boolean = null;
            Private___47_const_intnl_exitJumpLoc_UInt32 = null;
            Private___3_intnl_SystemInt32 = null;
            Private___31_intnl_SystemBoolean = null;
            Private___55_intnl_SystemBoolean = null;
            Private___25_const_intnl_SystemString = null;
            Private_prevHistoryButton = null;
            Private___11_const_intnl_exitJumpLoc_UInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___45_intnl_SystemString = null;
            Private___1_intnl_interpolatedStr_String = null;
            Private___20_intnl_SystemBoolean = null;
            Private___2_intnl_UnityEngineVector3 = null;
            Private___3_intnl_SystemString = null;
            Private___0_mp_b_Int32 = null;
            Private___54_intnl_SystemInt32 = null;
            Private___74_intnl_SystemBoolean = null;
            Private___0_isChar_Boolean = null;
            Private__interactable = null;
            Private___25_const_intnl_exitJumpLoc_UInt32 = null;
            Private___46_intnl_SystemInt32 = null;
            Private___7_intnl_interpolatedStr_String = null;
            Private___0_c_Char = null;
            Private___61_intnl_SystemBoolean = null;
            Private___0_stringDif_Int32 = null;
            Private___51_intnl_SystemInt32 = null;
            Private___3_intnl_SystemChar = null;
            Private___57_intnl_SystemInt32 = null;
            Private___29_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_intnl_UnityEngineVector3 = null;
            Private___53_intnl_SystemBoolean = null;
            Private___0_mp_c_Char = null;
            Private___4_intnl_interpolatedStr_String = null;
            Private___10_i_Int32 = null;
            Private___27_intnl_SystemBoolean = null;
            Private___51_const_intnl_exitJumpLoc_UInt32 = null;
            Private__minKeyboardOffset = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private___13_intnl_UnityEngineColor = null;
            Private___1_intnl_UnityEngineUIButton = null;
            Private___27_const_intnl_SystemString = null;
            Private___0_intnl_UnityEngineVector3 = null;
            Private___10_const_intnl_SystemString = null;
            Private___65_const_intnl_exitJumpLoc_UInt32 = null;
            Private___32_intnl_SystemBoolean = null;
            Private___56_intnl_SystemBoolean = null;
            Private___41_const_intnl_exitJumpLoc_UInt32 = null;
            Private__logLinesCount = null;
            Private___66_intnl_SystemInt32 = null;
            Private___45_intnl_SystemBoolean = null;
            Private___28_intnl_SystemInt32 = null;
            Private___69_const_intnl_exitJumpLoc_UInt32 = null;
            Private___7_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineTransform = null;
            Private___6_intnl_SystemChar = null;
            Private___6_intnl_UnityEngineColor = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___0_mp_n_Int32 = null;
            Private___0_intnl_UnityEngineColor = null;
            Private___62_intnl_SystemBoolean = null;
            Private___11_const_intnl_SystemString = null;
            Private___68_intnl_SystemString = null;
            Private___16_const_intnl_SystemString = null;
            Private__maxKeyboardSize = null;
            Private_logger = null;
            Private___32_const_intnl_exitJumpLoc_UInt32 = null;
            Private___7_intnl_UnityEngineColor = null;
            Private___2_intnl_UnityEngineUIImage = null;
            Private___5_intnl_UnityEngineColor = null;
            Private___43_intnl_SystemBoolean = null;
            Private___0_mp_interactable_Boolean = null;
            Private___18_intnl_SystemBoolean = null;
            Private___0_characterButton_Button = null;
            Private___14_intnl_SystemCharArray = null;
            Private___0_mp_index_Int32 = null;
            Private___0_emptySlot_Int32 = null;
            Private___2_intnl_SystemBoolean = null;
            Private___10_intnl_SystemSingle = null;
            Private___14_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_intnl_SystemChar = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___0_index_Int32 = null;
            Private___7_intnl_SystemSingle = null;
            Private___1_intnl_UnityEngineUIImage = null;
            Private___0_mp_size_Single = null;
            Private___59_intnl_SystemBoolean = null;
            Private___18_const_intnl_exitJumpLoc_UInt32 = null;
            Private___46_intnl_SystemBoolean = null;
            Private___39_intnl_SystemInt32 = null;
            Private___13_const_intnl_SystemString = null;
            Private___78_intnl_SystemBoolean = null;
            Private___8_intnl_SystemInt32 = null;
            Private__slotCount = null;
            Private___0_intnl_UnityEngineUIImage = null;
            Private___80_intnl_SystemBoolean = null;
            Private___19_intnl_SystemInt32 = null;
            Private_normalColor = null;
            Private___24_intnl_SystemInt32 = null;
            Private___54_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_UnityEngineUIButton = null;
            Private___13_const_intnl_exitJumpLoc_UInt32 = null;
            Private_keyboardOffsetIncButton = null;
            Private___10_intnl_SystemBoolean = null;
            Private___2_intnl_UnityEngineColor = null;
            Private___2_const_intnl_SystemString = null;
            Private_autoSubmitImage = null;
            Private___8_intnl_SystemChar = null;
            Private___21_intnl_SystemInt32 = null;
            Private___27_const_intnl_exitJumpLoc_UInt32 = null;
            Private___27_intnl_SystemInt32 = null;
            Private___58_const_intnl_exitJumpLoc_UInt32 = null;
            Private___44_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_const_intnl_SystemSingle = null;
            Private_settingsPanel = null;
            Private_offColor = null;
            Private___2_intnl_returnValSymbol_String = null;
            Private___51_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___0_intnl_SystemChar = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___25_intnl_SystemBoolean = null;
            Private___48_const_intnl_exitJumpLoc_UInt32 = null;
            Private___3_intnl_UnityEngineColor = null;
            Private___22_const_intnl_SystemString = null;
            Private___8_intnl_SystemSingle = null;
            Private__historyIndex = null;
            Private___70_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineColor = null;
            Private___49_intnl_SystemInt32 = null;
            Private___1_intnl_returnValSymbol_String = null;
            Private___17_intnl_SystemBoolean = null;
            Private___49_intnl_SystemBoolean = null;
            Private___53_const_intnl_exitJumpLoc_UInt32 = null;
            Private__autoSubmit = null;
            Private__characterButtons = null;
            Private___0_intnl_returnValSymbol_Int32 = null;
            Private___67_const_intnl_exitJumpLoc_UInt32 = null;
        }

        #region Getter / Setters AstroUdonVariables  of Keyboard

        internal int? __0_substitutionCost_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_substitutionCost_Int32 != null)
                {
                    return Private___0_substitutionCost_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_substitutionCost_Int32 != null)
                    {
                        Private___0_substitutionCost_Int32.Value = value.Value;
                    }
                }
            }
        }

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

        internal uint? __43_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___43_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___43_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___43_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___43_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __0_this_intnl_MakiKeyboard
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_MakiKeyboard != null)
                {
                    return Private___0_this_intnl_MakiKeyboard.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_MakiKeyboard != null)
                {
                    Private___0_this_intnl_MakiKeyboard.Value = value;
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

        internal string __40_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___40_intnl_SystemString != null)
                {
                    return Private___40_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___40_intnl_SystemString != null)
                {
                    Private___40_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Button keyboardSizeDecButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyboardSizeDecButton != null)
                {
                    return Private_keyboardSizeDecButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keyboardSizeDecButton != null)
                {
                    Private_keyboardSizeDecButton.Value = value;
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

        internal int? __2_intnl_returnValSymbol_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_returnValSymbol_Int32 != null)
                {
                    return Private___2_intnl_returnValSymbol_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_returnValSymbol_Int32 != null)
                    {
                        Private___2_intnl_returnValSymbol_Int32.Value = value.Value;
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

        internal UnityEngine.Color? incorrectColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_incorrectColor != null)
                {
                    return Private_incorrectColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_incorrectColor != null)
                    {
                        Private_incorrectColor.Value = value.Value;
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

        internal UnityEngine.Color? __8_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_UnityEngineColor != null)
                {
                    return Private___8_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_UnityEngineColor != null)
                    {
                        Private___8_intnl_UnityEngineColor.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Sprite[] outputLogToggleSprites
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outputLogToggleSprites != null)
                {
                    return Private_outputLogToggleSprites.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_outputLogToggleSprites != null)
                {
                    Private_outputLogToggleSprites.Value = value;
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

        internal bool? __1_mp_interactable_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_interactable_Boolean != null)
                {
                    return Private___1_mp_interactable_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_interactable_Boolean != null)
                    {
                        Private___1_mp_interactable_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_intnl_returnValSymbol_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_returnValSymbol_Int32 != null)
                {
                    return Private___1_intnl_returnValSymbol_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_returnValSymbol_Int32 != null)
                    {
                        Private___1_intnl_returnValSymbol_Int32.Value = value.Value;
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

        internal float? _keyboardOffset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__keyboardOffset != null)
                {
                    return Private__keyboardOffset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__keyboardOffset != null)
                    {
                        Private__keyboardOffset.Value = value.Value;
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

        internal uint? __61_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___61_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___61_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___61_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___61_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __9_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_i_Int32 != null)
                {
                    return Private___9_i_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_i_Int32 != null)
                    {
                        Private___9_i_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __8_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_i_Int32 != null)
                {
                    return Private___8_i_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_i_Int32 != null)
                    {
                        Private___8_i_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.Common.Enums.EventTiming? __0_const_intnl_VRCUdonCommonEnumsEventTiming
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_VRCUdonCommonEnumsEventTiming != null)
                {
                    return Private___0_const_intnl_VRCUdonCommonEnumsEventTiming.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_VRCUdonCommonEnumsEventTiming != null)
                    {
                        Private___0_const_intnl_VRCUdonCommonEnumsEventTiming.Value = value.Value;
                    }
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

        internal string __15_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemString != null)
                {
                    return Private___15_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___15_intnl_SystemString != null)
                {
                    Private___15_intnl_SystemString.Value = value;
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

        internal int? __0_n_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_n_Int32 != null)
                {
                    return Private___0_n_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_n_Int32 != null)
                    {
                        Private___0_n_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_m_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_m_Int32 != null)
                {
                    return Private___0_m_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_m_Int32 != null)
                    {
                        Private___0_m_Int32.Value = value.Value;
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

        internal uint? __35_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___35_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___35_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal uint? __39_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___39_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___39_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___39_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___39_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal uint? __56_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___56_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___56_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___56_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___56_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal UnityEngine.Color? C_APP
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_C_APP != null)
                {
                    return Private_C_APP.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_C_APP != null)
                    {
                        Private_C_APP.Value = value.Value;
                    }
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

        internal uint? __46_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___46_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___46_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___46_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___46_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __64_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___64_intnl_SystemString != null)
                {
                    return Private___64_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___64_intnl_SystemString != null)
                {
                    Private___64_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __8_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_interpolatedStr_String != null)
                {
                    return Private___8_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_interpolatedStr_String != null)
                {
                    Private___8_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI outputLogText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outputLogText != null)
                {
                    return Private_outputLogText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_outputLogText != null)
                {
                    Private_outputLogText.Value = value;
                }
            }
        }

        internal UnityEngine.Color? C_LOG
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_C_LOG != null)
                {
                    return Private_C_LOG.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_C_LOG != null)
                    {
                        Private_C_LOG.Value = value.Value;
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

        internal UnityEngine.Color? correctColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_correctColor != null)
                {
                    return Private_correctColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_correctColor != null)
                    {
                        Private_correctColor.Value = value.Value;
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

        internal char[] __0_intnl_returnValSymbol_CharArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_CharArray != null)
                {
                    return Private___0_intnl_returnValSymbol_CharArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_returnValSymbol_CharArray != null)
                {
                    Private___0_intnl_returnValSymbol_CharArray.Value = value;
                }
            }
        }

        internal UnityEngine.Color? __11_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_UnityEngineColor != null)
                {
                    return Private___11_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_UnityEngineColor != null)
                    {
                        Private___11_intnl_UnityEngineColor.Value = value.Value;
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

        internal bool? doWriteDebugLog
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_doWriteDebugLog != null)
                {
                    return Private_doWriteDebugLog.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_doWriteDebugLog != null)
                    {
                        Private_doWriteDebugLog.Value = value.Value;
                    }
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

        internal int? __0_deletionCost_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_deletionCost_Int32 != null)
                {
                    return Private___0_deletionCost_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_deletionCost_Int32 != null)
                    {
                        Private___0_deletionCost_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_textLength_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_textLength_Int32 != null)
                {
                    return Private___1_textLength_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_textLength_Int32 != null)
                    {
                        Private___1_textLength_Int32.Value = value.Value;
                    }
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

        internal UnityEngine.Color? __9_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_UnityEngineColor != null)
                {
                    return Private___9_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_UnityEngineColor != null)
                    {
                        Private___9_intnl_UnityEngineColor.Value = value.Value;
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

        internal float? _keyboardSize
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__keyboardSize != null)
                {
                    return Private__keyboardSize.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__keyboardSize != null)
                    {
                        Private__keyboardSize.Value = value.Value;
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

        internal uint? __50_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___50_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___50_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___50_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___50_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal string __0_mp_word_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_word_String != null)
                {
                    return Private___0_mp_word_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_word_String != null)
                {
                    Private___0_mp_word_String.Value = value;
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

        internal uint? __64_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___64_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___64_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___64_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___64_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal uint? __40_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___40_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___40_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___40_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___40_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI[] _characterTexts
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__characterTexts != null)
                {
                    return Private__characterTexts.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__characterTexts != null)
                {
                    Private__characterTexts.Value = value;
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

        internal uint? __68_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___68_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___68_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___68_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___68_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal UnityEngine.Color? __10_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_UnityEngineColor != null)
                {
                    return Private___10_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_UnityEngineColor != null)
                    {
                        Private___10_intnl_UnityEngineColor.Value = value.Value;
                    }
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

        internal int? __0_closeThreshold_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_closeThreshold_Int32 != null)
                {
                    return Private___0_closeThreshold_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_closeThreshold_Int32 != null)
                    {
                        Private___0_closeThreshold_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __63_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___63_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___63_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___63_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___63_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal string __43_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___43_intnl_SystemString != null)
                {
                    return Private___43_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___43_intnl_SystemString != null)
                {
                    Private___43_intnl_SystemString.Value = value;
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

        internal uint? __37_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___37_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___37_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Button keyboardOffsetDecButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyboardOffsetDecButton != null)
                {
                    return Private_keyboardOffsetDecButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keyboardOffsetDecButton != null)
                {
                    Private_keyboardOffsetDecButton.Value = value;
                }
            }
        }

        internal string __69_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___69_intnl_SystemString != null)
                {
                    return Private___69_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___69_intnl_SystemString != null)
                {
                    Private___69_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __0_mp_inLobby_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_inLobby_Boolean != null)
                {
                    return Private___0_mp_inLobby_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_inLobby_Boolean != null)
                    {
                        Private___0_mp_inLobby_Boolean.Value = value.Value;
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

        internal float? __0_mp_offset_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_offset_Single != null)
                {
                    return Private___0_mp_offset_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_offset_Single != null)
                    {
                        Private___0_mp_offset_Single.Value = value.Value;
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

        internal char? __7_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemChar != null)
                {
                    return Private___7_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemChar != null)
                    {
                        Private___7_intnl_SystemChar.Value = value.Value;
                    }
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

        internal bool? _autoClear
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__autoClear != null)
                {
                    return Private__autoClear.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__autoClear != null)
                    {
                        Private__autoClear.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Image outputLogToggleImage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outputLogToggleImage != null)
                {
                    return Private_outputLogToggleImage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_outputLogToggleImage != null)
                {
                    Private_outputLogToggleImage.Value = value;
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

        internal float[] _outputLogHeights
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__outputLogHeights != null)
                {
                    return Private__outputLogHeights.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__outputLogHeights != null)
                {
                    Private__outputLogHeights.Value = value;
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

        internal int? __0_mp_c_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_c_Int32 != null)
                {
                    return Private___0_mp_c_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_c_Int32 != null)
                    {
                        Private___0_mp_c_Int32.Value = value.Value;
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

        internal UnityEngine.Color? C_WAR
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_C_WAR != null)
                {
                    return Private_C_WAR.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_C_WAR != null)
                    {
                        Private_C_WAR.Value = value.Value;
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

        internal UnityEngine.Color? __12_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_UnityEngineColor != null)
                {
                    return Private___12_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_UnityEngineColor != null)
                    {
                        Private___12_intnl_UnityEngineColor.Value = value.Value;
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

        internal UnityEngine.UI.Image settingsButtonIcon
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_settingsButtonIcon != null)
                {
                    return Private_settingsButtonIcon.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_settingsButtonIcon != null)
                {
                    Private_settingsButtonIcon.Value = value;
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

        internal string __42_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___42_intnl_SystemString != null)
                {
                    return Private___42_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___42_intnl_SystemString != null)
                {
                    Private___42_intnl_SystemString.Value = value;
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

        internal char[] _text
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__text != null)
                {
                    return Private__text.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__text != null)
                {
                    Private__text.Value = value;
                }
            }
        }

        internal uint? __52_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___52_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___52_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___52_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___52_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal string __67_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___67_intnl_SystemString != null)
                {
                    return Private___67_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___67_intnl_SystemString != null)
                {
                    Private___67_intnl_SystemString.Value = value;
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

        internal char? __2_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemChar != null)
                {
                    return Private___2_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemChar != null)
                    {
                        Private___2_intnl_SystemChar.Value = value.Value;
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

        internal int? __0_mp_a_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_a_Int32 != null)
                {
                    return Private___0_mp_a_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_a_Int32 != null)
                    {
                        Private___0_mp_a_Int32.Value = value.Value;
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

        internal string __70_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___70_intnl_SystemString != null)
                {
                    return Private___70_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___70_intnl_SystemString != null)
                {
                    Private___70_intnl_SystemString.Value = value;
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

        internal uint? __66_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___66_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___66_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___66_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___66_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal uint? __71_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___71_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___71_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___71_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___71_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __42_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___42_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___42_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___42_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___42_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Image[] _characterImages
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__characterImages != null)
                {
                    return Private__characterImages.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__characterImages != null)
                {
                    Private__characterImages.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour audioManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_audioManager != null)
                {
                    return Private_audioManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_audioManager != null)
                {
                    Private_audioManager.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Image autoClearImage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_autoClearImage != null)
                {
                    return Private_autoClearImage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_autoClearImage != null)
                {
                    Private_autoClearImage.Value = value;
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

        internal char? __9_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemChar != null)
                {
                    return Private___9_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemChar != null)
                    {
                        Private___9_intnl_SystemChar.Value = value.Value;
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

        internal UnityEngine.Color? C_ERR
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_C_ERR != null)
                {
                    return Private_C_ERR.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_C_ERR != null)
                    {
                        Private_C_ERR.Value = value.Value;
                    }
                }
            }
        }

        internal bool? _settingState
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__settingState != null)
                {
                    return Private__settingState.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__settingState != null)
                    {
                        Private__settingState.Value = value.Value;
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

        internal char[] _correctWord
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__correctWord != null)
                {
                    return Private__correctWord.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__correctWord != null)
                {
                    Private__correctWord.Value = value;
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

        internal char? __1_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemChar != null)
                {
                    return Private___1_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemChar != null)
                    {
                        Private___1_intnl_SystemChar.Value = value.Value;
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

        internal string __41_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___41_intnl_SystemString != null)
                {
                    return Private___41_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___41_intnl_SystemString != null)
                {
                    Private___41_intnl_SystemString.Value = value;
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

        internal UnityEngine.Color? selectedColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_selectedColor != null)
                {
                    return Private_selectedColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_selectedColor != null)
                    {
                        Private_selectedColor.Value = value.Value;
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

        internal string __66_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___66_intnl_SystemString != null)
                {
                    return Private___66_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___66_intnl_SystemString != null)
                {
                    Private___66_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Button nextHistoryButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_nextHistoryButton != null)
                {
                    return Private_nextHistoryButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_nextHistoryButton != null)
                {
                    Private_nextHistoryButton.Value = value;
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

        internal UnityEngine.Rect? __0_intnl_UnityEngineRect
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineRect != null)
                {
                    return Private___0_intnl_UnityEngineRect.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineRect != null)
                    {
                        Private___0_intnl_UnityEngineRect.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __60_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___60_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___60_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___60_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___60_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal int? _maxHistory
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__maxHistory != null)
                {
                    return Private__maxHistory.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__maxHistory != null)
                    {
                        Private__maxHistory.Value = value.Value;
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

        internal string __0_mp_color_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_color_String != null)
                {
                    return Private___0_mp_color_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_color_String != null)
                {
                    Private___0_mp_color_String.Value = value;
                }
            }
        }

        internal uint? __34_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___34_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___34_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal char? __4_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemChar != null)
                {
                    return Private___4_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemChar != null)
                    {
                        Private___4_intnl_SystemChar.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector2? __0_intnl_UnityEngineVector2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineVector2 != null)
                {
                    return Private___0_intnl_UnityEngineVector2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineVector2 != null)
                    {
                        Private___0_intnl_UnityEngineVector2.Value = value.Value;
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

        internal uint? __38_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___38_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___38_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___38_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal int? _logMaxLines
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__logMaxLines != null)
                {
                    return Private__logMaxLines.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__logMaxLines != null)
                    {
                        Private__logMaxLines.Value = value.Value;
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

        internal UnityEngine.UI.Text _stringHolder
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__stringHolder != null)
                {
                    return Private__stringHolder.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__stringHolder != null)
                {
                    Private__stringHolder.Value = value;
                }
            }
        }

        internal uint? __33_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___33_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___33_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string CTagEnd
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_CTagEnd != null)
                {
                    return Private_CTagEnd.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_CTagEnd != null)
                {
                    Private_CTagEnd.Value = value;
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

        internal bool? __0_mp_condition_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_condition_Boolean != null)
                {
                    return Private___0_mp_condition_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_condition_Boolean != null)
                    {
                        Private___0_mp_condition_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_state_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_state_Boolean != null)
                {
                    return Private___0_mp_state_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_state_Boolean != null)
                    {
                        Private___0_mp_state_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __65_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___65_intnl_SystemString != null)
                {
                    return Private___65_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___65_intnl_SystemString != null)
                {
                    Private___65_intnl_SystemString.Value = value;
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

        internal char[] __0_intnl_SystemCharArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemCharArray != null)
                {
                    return Private___0_intnl_SystemCharArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_SystemCharArray != null)
                {
                    Private___0_intnl_SystemCharArray.Value = value;
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

        internal float? _maxKeyboardOffset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__maxKeyboardOffset != null)
                {
                    return Private__maxKeyboardOffset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__maxKeyboardOffset != null)
                    {
                        Private__maxKeyboardOffset.Value = value.Value;
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

        internal uint? __55_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___55_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___55_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___55_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___55_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal char[] __0_arr_CharArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_arr_CharArray != null)
                {
                    return Private___0_arr_CharArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_arr_CharArray != null)
                {
                    Private___0_arr_CharArray.Value = value;
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

        internal UnityEngine.Transform keyboardPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyboardPanel != null)
                {
                    return Private_keyboardPanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keyboardPanel != null)
                {
                    Private_keyboardPanel.Value = value;
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

        internal uint? __59_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___59_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___59_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___59_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___59_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __1_mp_c_Color
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_c_Color != null)
                {
                    return Private___1_mp_c_Color.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_c_Color != null)
                    {
                        Private___1_mp_c_Color.Value = value.Value;
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

        internal float? __0_width_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_width_Single != null)
                {
                    return Private___0_width_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_width_Single != null)
                    {
                        Private___0_width_Single.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __45_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___45_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___45_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___45_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___45_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal UnityEngine.Color? __0_mp_c_Color
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_c_Color != null)
                {
                    return Private___0_mp_c_Color.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_c_Color != null)
                    {
                        Private___0_mp_c_Color.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text keyboardSizeText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyboardSizeText != null)
                {
                    return Private_keyboardSizeText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keyboardSizeText != null)
                {
                    Private_keyboardSizeText.Value = value;
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

        internal uint? __49_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___49_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___49_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___49_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___49_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal UnityEngine.RectTransform outputParent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outputParent != null)
                {
                    return Private_outputParent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_outputParent != null)
                {
                    Private_outputParent.Value = value;
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

        internal float? _minKeyboardSize
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__minKeyboardSize != null)
                {
                    return Private__minKeyboardSize.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__minKeyboardSize != null)
                    {
                        Private__minKeyboardSize.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __62_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___62_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___62_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___62_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___62_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_min_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_min_Int32 != null)
                {
                    return Private___0_min_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_min_Int32 != null)
                    {
                        Private___0_min_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? _pointerIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__pointerIndex != null)
                {
                    return Private__pointerIndex.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__pointerIndex != null)
                    {
                        Private__pointerIndex.Value = value.Value;
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

        internal UnityEngine.UI.Button __0_intnl_UnityEngineUIButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineUIButton != null)
                {
                    return Private___0_intnl_UnityEngineUIButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineUIButton != null)
                {
                    Private___0_intnl_UnityEngineUIButton.Value = value;
                }
            }
        }

        internal uint? __36_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___36_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___36_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___36_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal string appname
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_appname != null)
                {
                    return Private_appname.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_appname != null)
                {
                    Private_appname.Value = value;
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

        internal UnityEngine.RectTransform outputLogTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outputLogTransform != null)
                {
                    return Private_outputLogTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_outputLogTransform != null)
                {
                    Private_outputLogTransform.Value = value;
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

        internal UnityEngine.UI.Text keyboardOffsetText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyboardOffsetText != null)
                {
                    return Private_keyboardOffsetText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keyboardOffsetText != null)
                {
                    Private_keyboardOffsetText.Value = value;
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

        internal System.Object[] _submitHistory
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__submitHistory != null)
                {
                    return Private__submitHistory.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__submitHistory != null)
                {
                    Private__submitHistory.Value = value;
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

        internal bool? _isBig
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__isBig != null)
                {
                    return Private__isBig.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__isBig != null)
                    {
                        Private__isBig.Value = value.Value;
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

        internal bool? _isCorrect
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__isCorrect != null)
                {
                    return Private__isCorrect.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__isCorrect != null)
                    {
                        Private__isCorrect.Value = value.Value;
                    }
                }
            }
        }

        internal string __1_mp_o_Object
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_o_Object != null)
                {
                    return Private___1_mp_o_Object.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_mp_o_Object != null)
                {
                    Private___1_mp_o_Object.Value = value;
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

        internal string __0_mp_text_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_text_String != null)
                {
                    return Private___0_mp_text_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_text_String != null)
                {
                    Private___0_mp_text_String.Value = value;
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

        internal char[] __0_mp_chars_CharArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_chars_CharArray != null)
                {
                    return Private___0_mp_chars_CharArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_chars_CharArray != null)
                {
                    Private___0_mp_chars_CharArray.Value = value;
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

        internal bool? __1_mp_state_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_state_Boolean != null)
                {
                    return Private___1_mp_state_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_state_Boolean != null)
                    {
                        Private___1_mp_state_Boolean.Value = value.Value;
                    }
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

        internal uint? __57_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___57_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___57_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___57_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___57_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal int? __0_textLength_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_textLength_Int32 != null)
                {
                    return Private___0_textLength_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_textLength_Int32 != null)
                    {
                        Private___0_textLength_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour scribbleManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scribbleManager != null)
                {
                    return Private_scribbleManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scribbleManager != null)
                {
                    Private_scribbleManager.Value = value;
                }
            }
        }

        internal uint? __70_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___70_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___70_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___70_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___70_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal int? __0_insertionCost_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_insertionCost_Int32 != null)
                {
                    return Private___0_insertionCost_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_insertionCost_Int32 != null)
                    {
                        Private___0_insertionCost_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Button keyboardSizeIncButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyboardSizeIncButton != null)
                {
                    return Private_keyboardSizeIncButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keyboardSizeIncButton != null)
                {
                    Private_keyboardSizeIncButton.Value = value;
                }
            }
        }

        internal UnityEngine.Color? __4_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineColor != null)
                {
                    return Private___4_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_UnityEngineColor != null)
                    {
                        Private___4_intnl_UnityEngineColor.Value = value.Value;
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

        internal uint? __47_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___47_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___47_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___47_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___47_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal UnityEngine.UI.Button prevHistoryButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_prevHistoryButton != null)
                {
                    return Private_prevHistoryButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_prevHistoryButton != null)
                {
                    Private_prevHistoryButton.Value = value;
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

        internal int? __0_mp_b_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_b_Int32 != null)
                {
                    return Private___0_mp_b_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_b_Int32 != null)
                    {
                        Private___0_mp_b_Int32.Value = value.Value;
                    }
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

        internal bool? __0_isChar_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_isChar_Boolean != null)
                {
                    return Private___0_isChar_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_isChar_Boolean != null)
                    {
                        Private___0_isChar_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? _interactable
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__interactable != null)
                {
                    return Private__interactable.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__interactable != null)
                    {
                        Private__interactable.Value = value.Value;
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

        internal string __7_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_interpolatedStr_String != null)
                {
                    return Private___7_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_interpolatedStr_String != null)
                {
                    Private___7_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal char? __0_c_Char
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_c_Char != null)
                {
                    return Private___0_c_Char.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_c_Char != null)
                    {
                        Private___0_c_Char.Value = value.Value;
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

        internal int? __0_stringDif_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_stringDif_Int32 != null)
                {
                    return Private___0_stringDif_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_stringDif_Int32 != null)
                    {
                        Private___0_stringDif_Int32.Value = value.Value;
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

        internal char? __3_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemChar != null)
                {
                    return Private___3_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemChar != null)
                    {
                        Private___3_intnl_SystemChar.Value = value.Value;
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

        internal char? __0_mp_c_Char
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_c_Char != null)
                {
                    return Private___0_mp_c_Char.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_c_Char != null)
                    {
                        Private___0_mp_c_Char.Value = value.Value;
                    }
                }
            }
        }

        internal string __4_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_interpolatedStr_String != null)
                {
                    return Private___4_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_interpolatedStr_String != null)
                {
                    Private___4_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal int? __10_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_i_Int32 != null)
                {
                    return Private___10_i_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_i_Int32 != null)
                    {
                        Private___10_i_Int32.Value = value.Value;
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

        internal uint? __51_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___51_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___51_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___51_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___51_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? _minKeyboardOffset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__minKeyboardOffset != null)
                {
                    return Private__minKeyboardOffset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__minKeyboardOffset != null)
                    {
                        Private__minKeyboardOffset.Value = value.Value;
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

        internal UnityEngine.Color? __13_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_UnityEngineColor != null)
                {
                    return Private___13_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_UnityEngineColor != null)
                    {
                        Private___13_intnl_UnityEngineColor.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Button __1_intnl_UnityEngineUIButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineUIButton != null)
                {
                    return Private___1_intnl_UnityEngineUIButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineUIButton != null)
                {
                    Private___1_intnl_UnityEngineUIButton.Value = value;
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

        internal uint? __65_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___65_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___65_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___65_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___65_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal uint? __41_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___41_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___41_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___41_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___41_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? _logLinesCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__logLinesCount != null)
                {
                    return Private__logLinesCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__logLinesCount != null)
                    {
                        Private__logLinesCount.Value = value.Value;
                    }
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

        internal uint? __69_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___69_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___69_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___69_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___69_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal UnityEngine.RectTransform __0_intnl_UnityEngineTransform
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

        internal char? __6_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemChar != null)
                {
                    return Private___6_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemChar != null)
                    {
                        Private___6_intnl_SystemChar.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __6_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_UnityEngineColor != null)
                {
                    return Private___6_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_UnityEngineColor != null)
                    {
                        Private___6_intnl_UnityEngineColor.Value = value.Value;
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

        internal int? __0_mp_n_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_n_Int32 != null)
                {
                    return Private___0_mp_n_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_n_Int32 != null)
                    {
                        Private___0_mp_n_Int32.Value = value.Value;
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

        internal string __68_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___68_intnl_SystemString != null)
                {
                    return Private___68_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___68_intnl_SystemString != null)
                {
                    Private___68_intnl_SystemString.Value = value;
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

        internal float? _maxKeyboardSize
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__maxKeyboardSize != null)
                {
                    return Private__maxKeyboardSize.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__maxKeyboardSize != null)
                    {
                        Private__maxKeyboardSize.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour logger
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_logger != null)
                {
                    return Private_logger.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_logger != null)
                {
                    Private_logger.Value = value;
                }
            }
        }

        internal uint? __32_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___32_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___32_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __7_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_UnityEngineColor != null)
                {
                    return Private___7_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_UnityEngineColor != null)
                    {
                        Private___7_intnl_UnityEngineColor.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Image __2_intnl_UnityEngineUIImage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineUIImage != null)
                {
                    return Private___2_intnl_UnityEngineUIImage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineUIImage != null)
                {
                    Private___2_intnl_UnityEngineUIImage.Value = value;
                }
            }
        }

        internal UnityEngine.Color? __5_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_UnityEngineColor != null)
                {
                    return Private___5_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_UnityEngineColor != null)
                    {
                        Private___5_intnl_UnityEngineColor.Value = value.Value;
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

        internal bool? __0_mp_interactable_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_interactable_Boolean != null)
                {
                    return Private___0_mp_interactable_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_interactable_Boolean != null)
                    {
                        Private___0_mp_interactable_Boolean.Value = value.Value;
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

        internal UnityEngine.UI.Button __0_characterButton_Button
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_characterButton_Button != null)
                {
                    return Private___0_characterButton_Button.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_characterButton_Button != null)
                {
                    Private___0_characterButton_Button.Value = value;
                }
            }
        }

        internal char[] __14_intnl_SystemCharArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemCharArray != null)
                {
                    return Private___14_intnl_SystemCharArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___14_intnl_SystemCharArray != null)
                {
                    Private___14_intnl_SystemCharArray.Value = value;
                }
            }
        }

        internal int? __0_mp_index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_index_Int32 != null)
                {
                    return Private___0_mp_index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_index_Int32 != null)
                    {
                        Private___0_mp_index_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_emptySlot_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_emptySlot_Int32 != null)
                {
                    return Private___0_emptySlot_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_emptySlot_Int32 != null)
                    {
                        Private___0_emptySlot_Int32.Value = value.Value;
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

        internal char? __5_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemChar != null)
                {
                    return Private___5_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemChar != null)
                    {
                        Private___5_intnl_SystemChar.Value = value.Value;
                    }
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

        internal UnityEngine.UI.Image __1_intnl_UnityEngineUIImage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineUIImage != null)
                {
                    return Private___1_intnl_UnityEngineUIImage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineUIImage != null)
                {
                    Private___1_intnl_UnityEngineUIImage.Value = value;
                }
            }
        }

        internal float? __0_mp_size_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_size_Single != null)
                {
                    return Private___0_mp_size_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_size_Single != null)
                    {
                        Private___0_mp_size_Single.Value = value.Value;
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

        internal int? _slotCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__slotCount != null)
                {
                    return Private__slotCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__slotCount != null)
                    {
                        Private__slotCount.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Image __0_intnl_UnityEngineUIImage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineUIImage != null)
                {
                    return Private___0_intnl_UnityEngineUIImage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineUIImage != null)
                {
                    Private___0_intnl_UnityEngineUIImage.Value = value;
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

        internal UnityEngine.Color? normalColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_normalColor != null)
                {
                    return Private_normalColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_normalColor != null)
                    {
                        Private_normalColor.Value = value.Value;
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

        internal uint? __54_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___54_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___54_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___54_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___54_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Button __2_intnl_UnityEngineUIButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineUIButton != null)
                {
                    return Private___2_intnl_UnityEngineUIButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineUIButton != null)
                {
                    Private___2_intnl_UnityEngineUIButton.Value = value;
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

        internal UnityEngine.UI.Button keyboardOffsetIncButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keyboardOffsetIncButton != null)
                {
                    return Private_keyboardOffsetIncButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keyboardOffsetIncButton != null)
                {
                    Private_keyboardOffsetIncButton.Value = value;
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

        internal UnityEngine.Color? __2_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineColor != null)
                {
                    return Private___2_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_UnityEngineColor != null)
                    {
                        Private___2_intnl_UnityEngineColor.Value = value.Value;
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

        internal UnityEngine.UI.Image autoSubmitImage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_autoSubmitImage != null)
                {
                    return Private_autoSubmitImage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_autoSubmitImage != null)
                {
                    Private_autoSubmitImage.Value = value;
                }
            }
        }

        internal char? __8_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemChar != null)
                {
                    return Private___8_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemChar != null)
                    {
                        Private___8_intnl_SystemChar.Value = value.Value;
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

        internal uint? __58_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___58_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___58_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___58_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___58_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __44_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___44_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___44_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___44_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___44_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal UnityEngine.GameObject settingsPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_settingsPanel != null)
                {
                    return Private_settingsPanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_settingsPanel != null)
                {
                    Private_settingsPanel.Value = value;
                }
            }
        }

        internal UnityEngine.Color? offColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_offColor != null)
                {
                    return Private_offColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_offColor != null)
                    {
                        Private_offColor.Value = value.Value;
                    }
                }
            }
        }

        internal string __2_intnl_returnValSymbol_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_returnValSymbol_String != null)
                {
                    return Private___2_intnl_returnValSymbol_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_returnValSymbol_String != null)
                {
                    Private___2_intnl_returnValSymbol_String.Value = value;
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

        internal char? __0_intnl_SystemChar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemChar != null)
                {
                    return Private___0_intnl_SystemChar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemChar != null)
                    {
                        Private___0_intnl_SystemChar.Value = value.Value;
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

        internal uint? __48_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___48_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___48_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___48_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___48_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __3_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineColor != null)
                {
                    return Private___3_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_UnityEngineColor != null)
                    {
                        Private___3_intnl_UnityEngineColor.Value = value.Value;
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

        internal int? _historyIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__historyIndex != null)
                {
                    return Private__historyIndex.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__historyIndex != null)
                    {
                        Private__historyIndex.Value = value.Value;
                    }
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

        internal UnityEngine.Color? __1_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineColor != null)
                {
                    return Private___1_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_UnityEngineColor != null)
                    {
                        Private___1_intnl_UnityEngineColor.Value = value.Value;
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

        internal string __1_intnl_returnValSymbol_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_returnValSymbol_String != null)
                {
                    return Private___1_intnl_returnValSymbol_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_returnValSymbol_String != null)
                {
                    Private___1_intnl_returnValSymbol_String.Value = value;
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

        internal uint? __53_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___53_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___53_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___53_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___53_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? _autoSubmit
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__autoSubmit != null)
                {
                    return Private__autoSubmit.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__autoSubmit != null)
                    {
                        Private__autoSubmit.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Button[] _characterButtons
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__characterButtons != null)
                {
                    return Private__characterButtons.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__characterButtons != null)
                {
                    Private__characterButtons.Value = value;
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

        internal uint? __67_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___67_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___67_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___67_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___67_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of Keyboard

        #region AstroUdonVariables  of Keyboard

        private AstroUdonVariable<int> Private___0_substitutionCost_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___35_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___43_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___0_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_MakiKeyboard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___32_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___77_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___40_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_keyboardSizeDecButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___21_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___52_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_incorrectColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___8_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Sprite[]> Private_outputLogToggleSprites { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_interactable_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___16_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private__keyboardOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___45_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___61_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___0_const_intnl_VRCUdonCommonEnumsEventTiming { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___50_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_j_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_n_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_m_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___42_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___35_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___53_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___39_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___56_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_C_APP { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___65_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___46_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___64_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_outputLogText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_C_LOG { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___62_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_correctColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_intnl_returnValSymbol_CharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___11_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___24_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___28_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_doWriteDebugLog { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___83_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_deletionCost_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_textLength_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___28_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___9_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___75_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private__keyboardSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___50_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_word_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___64_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___38_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___64_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___23_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___56_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___40_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI[]> Private__characterTexts { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___68_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___73_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___10_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_closeThreshold_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___63_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___76_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___43_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___23_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___37_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_keyboardOffsetDecButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___69_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_inLobby_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_offset_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___48_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___7_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___34_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___1_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private__autoClear { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private_outputLogToggleImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___31_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___37_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___12_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float[]> Private__outputLogHeights { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_c_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___79_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_C_WAR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___26_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___12_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private_settingsButtonIcon { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___81_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___31_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___68_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___42_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private__text { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___52_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___67_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___44_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___2_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_a_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___26_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___70_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___54_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___66_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___41_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___47_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___26_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___71_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___42_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image[]> Private__characterImages { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_audioManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private_autoClearImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___71_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___44_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___9_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___60_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_C_ERR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private__settingState { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___82_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___20_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private__correctWord { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___59_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___64_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___1_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___41_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___61_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___67_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___67_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_selectedColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___23_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___66_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_nextHistoryButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Rect> Private___0_intnl_UnityEngineRect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___60_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___72_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__maxHistory { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_color_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___34_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___4_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector2> Private___0_intnl_UnityEngineVector2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___38_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__logMaxLines { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___55_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private__stringHolder { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___33_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_CTagEnd { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___52_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___58_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_condition_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_state_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___65_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___15_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___19_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private__maxKeyboardOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___29_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___50_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___55_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_arr_CharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___22_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_keyboardPanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___59_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___1_mp_c_Color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___30_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_width_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___45_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___65_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_mp_c_Color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_keyboardSizeText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___57_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___33_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___49_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___47_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private_outputParent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private__minKeyboardSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___62_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_min_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__pointerIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private___0_intnl_UnityEngineUIButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___36_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___63_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_appname { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private_outputLogTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___25_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___40_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_keyboardOffsetText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___66_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___22_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.Object[]> Private__submitHistory { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___43_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___14_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private__isBig { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___58_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___46_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___17_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private__isCorrect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_mp_o_Object { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___30_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_text_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___60_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___36_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_mp_chars_CharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_state_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___63_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___24_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___69_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___57_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_textLength_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_scribbleManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___70_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_insertionCost_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_keyboardSizeIncButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___4_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___47_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___55_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___25_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_prevHistoryButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___45_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_b_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___54_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___74_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_isChar_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private__interactable { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___25_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___46_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_c_Char { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___61_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_stringDif_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___51_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___3_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___57_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___29_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___53_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_mp_c_Char { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___51_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private__minKeyboardOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___13_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private___1_intnl_UnityEngineUIButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___27_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___65_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___56_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___41_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__logLinesCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___66_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___28_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___69_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___6_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___6_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_n_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___62_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___68_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private__maxKeyboardSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_logger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___32_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___7_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private___2_intnl_UnityEngineUIImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___5_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_interactable_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private___0_characterButton_Button { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___14_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_emptySlot_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___14_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___5_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private___1_intnl_UnityEngineUIImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_size_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___59_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___18_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___39_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___78_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__slotCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private___0_intnl_UnityEngineUIImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___80_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_normalColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___24_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___54_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private___2_intnl_UnityEngineUIButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___13_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_keyboardOffsetIncButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___2_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private_autoSubmitImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___8_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___27_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___27_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___58_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___44_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_settingsPanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_offColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___51_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___48_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___3_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__historyIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___70_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___1_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___49_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___49_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___53_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private__autoSubmit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button[]> Private__characterButtons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___67_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of Keyboard
    }
}