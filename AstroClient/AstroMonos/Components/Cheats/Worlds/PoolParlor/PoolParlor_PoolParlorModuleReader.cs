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
    public class PoolParlor_PoolParlorModuleReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PoolParlor_PoolParlorModuleReader(IntPtr ptr) : base(ptr)
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
                var obj = gameObject.FindUdonEvent("_OnSAOJumpImpulseChanged");
                if (obj != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    PoolParlorModule = obj.RawItem;
                    Initialize_PoolParlorModule();
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
            Cleanup_PoolParlorModule();
        }

        private RawUdonBehaviour PoolParlorModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_PoolParlorModule()
        {
            Private___6_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__6_intnl_returnValSymbol_Boolean");
            Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32");
            Private_outCanUse = new AstroUdonVariable<bool>(PoolParlorModule, "outCanUse");
            Private_nameColorData = new AstroUdonVariable<UnityEngine.TextAsset>(PoolParlorModule, "nameColorData");
            Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32");
            Private___2_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__2_intnl_returnValSymbol_Boolean");
            Private_cueSkinData = new AstroUdonVariable<UnityEngine.TextAsset>(PoolParlorModule, "cueSkinData");
            Private_inMode = new AstroUdonVariable<int>(PoolParlorModule, "inMode");
            Private_tables = new AstroUdonVariable<UnityEngine.Component[]>(PoolParlorModule, "tables");
            Private___0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean");
            Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__1_mp_680845797CF11D637DB85E28135E758C_Int32");
            Private_inSkin = new AstroUdonVariable<int>(PoolParlorModule, "inSkin");
            Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PoolParlorModule, "__refl_const_intnl_udonTypeID");
            Private_outSuccessful = new AstroUdonVariable<bool>(PoolParlorModule, "outSuccessful");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PoolParlorModule, "__refl_const_intnl_udonTypeName");
            Private_props = new AstroUdonVariable<UnityEngine.GameObject[]>(PoolParlorModule, "props");
            Private___4_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__4_intnl_returnValSymbol_Boolean");
            Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32");
            Private_shouldBlahaj = new AstroUdonVariable<bool>(PoolParlorModule, "shouldBlahaj");
            Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__0_mp_680845797CF11D637DB85E28135E758C_Int32");
            Private_tableSkinData = new AstroUdonVariable<UnityEngine.TextAsset>(PoolParlorModule, "tableSkinData");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__0_intnl_returnValSymbol_Boolean");
            Private___0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean");
            Private_popcat = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "popcat");
            Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean");
            Private___1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean");
            Private_VERSION = new AstroUdonVariable<string>(PoolParlorModule, "VERSION");
            Private___3_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__3_intnl_returnValSymbol_Boolean");
            Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = new AstroUdonVariable<float>(PoolParlorModule, "__0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single");
            Private_inLocalVersion = new AstroUdonVariable<int>(PoolParlorModule, "inLocalVersion");
            Private___0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32");
            Private___0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean");
            Private___0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32");
            Private___5_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__5_intnl_returnValSymbol_Boolean");
            Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean");
            Private_previewCue = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "previewCue");
            Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__1_intnl_returnValSymbol_Boolean");
            Private_shouldPopcat = new AstroUdonVariable<bool>(PoolParlorModule, "shouldPopcat");
            Private___0_mp_E005EA806BD7DB8EC72DC105C2E79C03_DateTime = new AstroUdonVariable<System.DateTime>(PoolParlorModule, "__0_mp_E005EA806BD7DB8EC72DC105C2E79C03_DateTime");
            Private___3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = new AstroUdonVariable<float>(PoolParlorModule, "__3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single");
            Private___1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean");
            Private_outSetting = new AstroUdonVariable<int>(PoolParlorModule, "outSetting");
            Private___2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = new AstroUdonVariable<float>(PoolParlorModule, "__2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single");
            Private___0_mp_4A46509CB3672DB75272426993F9D53E_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__0_mp_4A46509CB3672DB75272426993F9D53E_Boolean");
            Private___1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean");
            Private_blahaj = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "blahaj");
            Private_INITIALIZED = new AstroUdonVariable<bool>(PoolParlorModule, "INITIALIZED");
            Private___3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32");
            Private___4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = new AstroUdonVariable<float>(PoolParlorModule, "__4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single");
            Private_inRemoteVersion = new AstroUdonVariable<int>(PoolParlorModule, "inRemoteVersion");
            Private_DEPENDENCIES = new AstroUdonVariable<string[]>(PoolParlorModule, "DEPENDENCIES");
            Private___2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = new AstroUdonVariable<bool>(PoolParlorModule, "__2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean");
            Private___1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = new AstroUdonVariable<float>(PoolParlorModule, "__1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single");
            Private_saoMenu = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "saoMenu");
            Private___0_mp_4BBB0766B4033170A92B9CD30BBB1376_String = new AstroUdonVariable<string>(PoolParlorModule, "__0_mp_4BBB0766B4033170A92B9CD30BBB1376_String");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(PoolParlorModule, "__0_intnl_returnValSymbol_Int32");
        }

        private void Cleanup_PoolParlorModule()
        {
            Private___6_intnl_returnValSymbol_Boolean = null;
            Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = null;
            Private_outCanUse = null;
            Private_nameColorData = null;
            Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = null;
            Private___2_intnl_returnValSymbol_Boolean = null;
            Private_cueSkinData = null;
            Private_inMode = null;
            Private_tables = null;
            Private___0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean = null;
            Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 = null;
            Private_inSkin = null;
            Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private_outSuccessful = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private_props = null;
            Private___4_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 = null;
            Private_shouldBlahaj = null;
            Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 = null;
            Private_tableSkinData = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean = null;
            Private_popcat = null;
            Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean = null;
            Private___1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean = null;
            Private_VERSION = null;
            Private___3_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = null;
            Private_inLocalVersion = null;
            Private___0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32 = null;
            Private___0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean = null;
            Private___0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32 = null;
            Private___5_intnl_returnValSymbol_Boolean = null;
            Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = null;
            Private_previewCue = null;
            Private___1_intnl_returnValSymbol_Boolean = null;
            Private_shouldPopcat = null;
            Private___0_mp_E005EA806BD7DB8EC72DC105C2E79C03_DateTime = null;
            Private___3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = null;
            Private___1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = null;
            Private_outSetting = null;
            Private___2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = null;
            Private___0_mp_4A46509CB3672DB75272426993F9D53E_Boolean = null;
            Private___1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean = null;
            Private_blahaj = null;
            Private_INITIALIZED = null;
            Private___3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = null;
            Private___4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = null;
            Private_inRemoteVersion = null;
            Private_DEPENDENCIES = null;
            Private___2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean = null;
            Private___1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single = null;
            Private_saoMenu = null;
            Private___0_mp_4BBB0766B4033170A92B9CD30BBB1376_String = null;
            Private___0_intnl_returnValSymbol_Int32 = null;
        }

        #region Getter / Setters AstroUdonVariables  of PoolParlorModule

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

        internal bool? outCanUse
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outCanUse != null)
                {
                    return Private_outCanUse.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_outCanUse != null)
                    {
                        Private_outCanUse.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.TextAsset nameColorData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_nameColorData != null)
                {
                    return Private_nameColorData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_nameColorData != null)
                {
                    Private_nameColorData.Value = value;
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

        internal UnityEngine.TextAsset cueSkinData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueSkinData != null)
                {
                    return Private_cueSkinData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cueSkinData != null)
                {
                    Private_cueSkinData.Value = value;
                }
            }
        }

        internal int? inMode
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inMode != null)
                {
                    return Private_inMode.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inMode != null)
                    {
                        Private_inMode.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] tables
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tables != null)
                {
                    return Private_tables.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tables != null)
                {
                    Private_tables.Value = value;
                }
            }
        }

        internal bool? __0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean != null)
                {
                    return Private___0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean != null)
                    {
                        Private___0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean.Value = value.Value;
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

        internal int? inSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inSkin != null)
                {
                    return Private_inSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inSkin != null)
                    {
                        Private_inSkin.Value = value.Value;
                    }
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

        internal bool? outSuccessful
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outSuccessful != null)
                {
                    return Private_outSuccessful.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_outSuccessful != null)
                    {
                        Private_outSuccessful.Value = value.Value;
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

        internal UnityEngine.GameObject[] props
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_props != null)
                {
                    return Private_props.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_props != null)
                {
                    Private_props.Value = value;
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

        internal bool? shouldBlahaj
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_shouldBlahaj != null)
                {
                    return Private_shouldBlahaj.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_shouldBlahaj != null)
                    {
                        Private_shouldBlahaj.Value = value.Value;
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

        internal UnityEngine.TextAsset tableSkinData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableSkinData != null)
                {
                    return Private_tableSkinData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tableSkinData != null)
                {
                    Private_tableSkinData.Value = value;
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

        internal bool? __0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean != null)
                {
                    return Private___0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean != null)
                    {
                        Private___0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject popcat
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_popcat != null)
                {
                    return Private_popcat.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_popcat != null)
                {
                    Private_popcat.Value = value;
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

        internal bool? __1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean != null)
                {
                    return Private___1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean != null)
                    {
                        Private___1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean.Value = value.Value;
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

        internal float? __0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                {
                    return Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                    {
                        Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value = value.Value;
                    }
                }
            }
        }

        internal int? inLocalVersion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inLocalVersion != null)
                {
                    return Private_inLocalVersion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inLocalVersion != null)
                    {
                        Private_inLocalVersion.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32 != null)
                {
                    return Private___0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32 != null)
                    {
                        Private___0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean != null)
                {
                    return Private___0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean != null)
                    {
                        Private___0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32 != null)
                {
                    return Private___0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32 != null)
                    {
                        Private___0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32.Value = value.Value;
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

        internal UnityEngine.GameObject previewCue
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_previewCue != null)
                {
                    return Private_previewCue.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_previewCue != null)
                {
                    Private_previewCue.Value = value;
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

        internal bool? shouldPopcat
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_shouldPopcat != null)
                {
                    return Private_shouldPopcat.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_shouldPopcat != null)
                    {
                        Private_shouldPopcat.Value = value.Value;
                    }
                }
            }
        }

        internal float? __3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                {
                    return Private___3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                    {
                        Private___3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean != null)
                {
                    return Private___1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean != null)
                    {
                        Private___1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? outSetting
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outSetting != null)
                {
                    return Private_outSetting.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_outSetting != null)
                    {
                        Private_outSetting.Value = value.Value;
                    }
                }
            }
        }

        internal float? __2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                {
                    return Private___2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                    {
                        Private___2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_4A46509CB3672DB75272426993F9D53E_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_4A46509CB3672DB75272426993F9D53E_Boolean != null)
                {
                    return Private___0_mp_4A46509CB3672DB75272426993F9D53E_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_4A46509CB3672DB75272426993F9D53E_Boolean != null)
                    {
                        Private___0_mp_4A46509CB3672DB75272426993F9D53E_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean != null)
                {
                    return Private___1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean != null)
                    {
                        Private___1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject blahaj
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_blahaj != null)
                {
                    return Private_blahaj.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_blahaj != null)
                {
                    Private_blahaj.Value = value;
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

        internal int? __3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                {
                    return Private___3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 != null)
                    {
                        Private___3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                {
                    return Private___4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                    {
                        Private___4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value = value.Value;
                    }
                }
            }
        }

        internal int? inRemoteVersion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inRemoteVersion != null)
                {
                    return Private_inRemoteVersion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inRemoteVersion != null)
                    {
                        Private_inRemoteVersion.Value = value.Value;
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

        internal bool? __2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean != null)
                {
                    return Private___2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean != null)
                    {
                        Private___2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                {
                    return Private___1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single != null)
                    {
                        Private___1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject saoMenu
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoMenu != null)
                {
                    return Private_saoMenu.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoMenu != null)
                {
                    Private_saoMenu.Value = value;
                }
            }
        }

        internal string __0_mp_4BBB0766B4033170A92B9CD30BBB1376_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_4BBB0766B4033170A92B9CD30BBB1376_String != null)
                {
                    return Private___0_mp_4BBB0766B4033170A92B9CD30BBB1376_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_4BBB0766B4033170A92B9CD30BBB1376_String != null)
                {
                    Private___0_mp_4BBB0766B4033170A92B9CD30BBB1376_String.Value = value;
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

        #endregion Getter / Setters AstroUdonVariables  of PoolParlorModule

        #region AstroUdonVariables  of PoolParlorModule

        private AstroUdonVariable<bool> Private___6_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_outCanUse { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.TextAsset> Private_nameColorData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.TextAsset> Private_cueSkinData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_inMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_tables { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_680845797CF11D637DB85E28135E758C_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_inSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_outSuccessful { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private_props { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_14A55C5E9908F0ED1E7958D22913F4E0_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_shouldBlahaj { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_680845797CF11D637DB85E28135E758C_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.TextAsset> Private_tableSkinData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_BC6098BA169E2AD1C0C61252B78B1577_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_popcat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_20B5BB32A06720584C1206EEF9C7B7E0_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_VERSION { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_inLocalVersion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_E6E861D3ECADC36700FBDAA95DEFBABF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_264052BCE1C05FB91B9113F8AAE39094_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_5B06D40EB25A68FBCD2015D7F45B16DA_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_previewCue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_shouldPopcat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.DateTime> Private___0_mp_E005EA806BD7DB8EC72DC105C2E79C03_DateTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_outSetting { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_4A46509CB3672DB75272426993F9D53E_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_30185AEDA9D2F981AF9DFF88ABE95479_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_blahaj { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_INITIALIZED { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_inRemoteVersion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private_DEPENDENCIES { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_mp_423A9D36E74A1409238F9D30DF6080C8_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_mp_E72C2AD7DCEA1375E5F7EBD7035BBCD5_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_saoMenu { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_4BBB0766B4033170A92B9CD30BBB1376_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of PoolParlorModule

    }
}