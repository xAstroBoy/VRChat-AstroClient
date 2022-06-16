using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using IntPtr = System.IntPtr;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PoolParlor
{
    [RegisterComponent]
    public class PoolParlor_CueReader : MonoBehaviour
    {
        private List<object> AntiGarbageCollection = new();

        public PoolParlor_CueReader(IntPtr ptr) : base(ptr)
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
                var obj = gameObject.FindUdonEvent("_OnPrimaryPickup");
                if (obj != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    PoolCue = obj.UdonBehaviour.ToRawUdonBehaviour();
                    Initialize_PoolCue();
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
            Cleanup_PoolCue();
        }

        private RawUdonBehaviour PoolCue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_PoolCue()
        {
            Private___0_mp_96CA60818C7892002DD14A4F7A68B45A_Single = new AstroUdonVariable<float>(PoolCue, "__0_mp_96CA60818C7892002DD14A4F7A68B45A_Single");
            Private_primaryLocked = new AstroUdonVariable<bool>(PoolCue, "primaryLocked");
            Private_primary = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "primary");
            Private___0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single = new AstroUdonVariable<float>(PoolCue, "__0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single");
            Private_secondary = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "secondary");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PoolCue, "__refl_const_intnl_udonTypeID");
            Private_primaryLockDir = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "primaryLockDir");
            Private_body = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "body");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PoolCue, "__refl_const_intnl_udonTypeName");
            Private___1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean = new AstroUdonVariable<bool>(PoolCue, "__1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean");
            Private___0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean = new AstroUdonVariable<bool>(PoolCue, "__0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean");
            Private_desktop = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "desktop");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolCue, "__0_intnl_returnValSymbol_Boolean");
            Private_secondaryLockPos = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "secondaryLockPos");
            Private___0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single = new AstroUdonVariable<float>(PoolCue, "__0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single");
            Private_syncedHolderIsDesktop = new AstroUdonVariable<bool>(PoolCue, "syncedHolderIsDesktop");
            Private___0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3");
            Private_cuetip = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "cuetip");
            Private_table = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "table");
            Private_syncedCueSkin = new AstroUdonVariable<int>(PoolCue, "syncedCueSkin");
            Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PoolCue, "__1_intnl_returnValSymbol_Boolean");
            Private___0_intnl_returnValSymbol_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__0_intnl_returnValSymbol_Vector3");
            Private_secondaryLocked = new AstroUdonVariable<bool>(PoolCue, "secondaryLocked");
            Private___0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single = new AstroUdonVariable<float>(PoolCue, "__0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single");
            Private___0_mp_15482812C415769008DC134F4301DBAB_Single = new AstroUdonVariable<float>(PoolCue, "__0_mp_15482812C415769008DC134F4301DBAB_Single");
            Private_primaryLockPos = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "primaryLockPos");
            Private___0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single = new AstroUdonVariable<float>(PoolCue, "__0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single");
        }

        private void Cleanup_PoolCue()
        {
            Private___0_mp_96CA60818C7892002DD14A4F7A68B45A_Single = null;
            Private_primaryLocked = null;
            Private_primary = null;
            Private___0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single = null;
            Private_secondary = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private_primaryLockDir = null;
            Private_body = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean = null;
            Private___0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean = null;
            Private_desktop = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private_secondaryLockPos = null;
            Private___0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single = null;
            Private_syncedHolderIsDesktop = null;
            Private___0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3 = null;
            Private_cuetip = null;
            Private_table = null;
            Private_syncedCueSkin = null;
            Private___1_intnl_returnValSymbol_Boolean = null;
            Private___0_intnl_returnValSymbol_Vector3 = null;
            Private_secondaryLocked = null;
            Private___0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single = null;
            Private___0_mp_15482812C415769008DC134F4301DBAB_Single = null;
            Private_primaryLockPos = null;
            Private___0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single = null;
        }

        #region Getter / Setters AstroUdonVariables  of PoolCue

        internal float? __0_mp_96CA60818C7892002DD14A4F7A68B45A_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_96CA60818C7892002DD14A4F7A68B45A_Single != null)
                {
                    return Private___0_mp_96CA60818C7892002DD14A4F7A68B45A_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_96CA60818C7892002DD14A4F7A68B45A_Single != null)
                    {
                        Private___0_mp_96CA60818C7892002DD14A4F7A68B45A_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? primaryLocked
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryLocked != null)
                {
                    return Private_primaryLocked.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_primaryLocked != null)
                    {
                        Private_primaryLocked.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject primary
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primary != null)
                {
                    return Private_primary.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_primary != null)
                {
                    Private_primary.Value = value;
                }
            }
        }

        internal float? __0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single != null)
                {
                    return Private___0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single != null)
                    {
                        Private___0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject secondary
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondary != null)
                {
                    return Private_secondary.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_secondary != null)
                {
                    Private_secondary.Value = value;
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

        internal UnityEngine.Vector3? primaryLockDir
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryLockDir != null)
                {
                    return Private_primaryLockDir.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_primaryLockDir != null)
                    {
                        Private_primaryLockDir.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject body
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_body != null)
                {
                    return Private_body.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_body != null)
                {
                    Private_body.Value = value;
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

        internal bool? __1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean != null)
                {
                    return Private___1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean != null)
                    {
                        Private___1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean != null)
                {
                    return Private___0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean != null)
                    {
                        Private___0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject desktop
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_desktop != null)
                {
                    return Private_desktop.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_desktop != null)
                {
                    Private_desktop.Value = value;
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

        internal UnityEngine.Vector3? secondaryLockPos
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondaryLockPos != null)
                {
                    return Private_secondaryLockPos.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_secondaryLockPos != null)
                    {
                        Private_secondaryLockPos.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single != null)
                {
                    return Private___0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single != null)
                    {
                        Private___0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? syncedHolderIsDesktop
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_syncedHolderIsDesktop != null)
                {
                    return Private_syncedHolderIsDesktop.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_syncedHolderIsDesktop != null)
                    {
                        Private_syncedHolderIsDesktop.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3 != null)
                {
                    return Private___0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3 != null)
                    {
                        Private___0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject cuetip
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cuetip != null)
                {
                    return Private_cuetip.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cuetip != null)
                {
                    Private_cuetip.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour table
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

        internal int? syncedCueSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_syncedCueSkin != null)
                {
                    return Private_syncedCueSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_syncedCueSkin != null)
                    {
                        Private_syncedCueSkin.Value = value.Value;
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

        internal bool? secondaryLocked
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondaryLocked != null)
                {
                    return Private_secondaryLocked.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_secondaryLocked != null)
                    {
                        Private_secondaryLocked.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single != null)
                {
                    return Private___0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single != null)
                    {
                        Private___0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_15482812C415769008DC134F4301DBAB_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_15482812C415769008DC134F4301DBAB_Single != null)
                {
                    return Private___0_mp_15482812C415769008DC134F4301DBAB_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_15482812C415769008DC134F4301DBAB_Single != null)
                    {
                        Private___0_mp_15482812C415769008DC134F4301DBAB_Single.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? primaryLockPos
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryLockPos != null)
                {
                    return Private_primaryLockPos.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_primaryLockPos != null)
                    {
                        Private_primaryLockPos.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single != null)
                {
                    return Private___0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single != null)
                    {
                        Private___0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of PoolCue

        #region AstroUdonVariables  of PoolCue

        private AstroUdonVariable<float> Private___0_mp_96CA60818C7892002DD14A4F7A68B45A_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_primaryLocked { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_primary { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_7A899BE1719554E4AAD9B4577AEDC12D_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_secondary { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_primaryLockDir { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_F241A5B8A3F196A303CD2425AAD75F3B_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_desktop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_secondaryLockPos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_1D0417AF3A3DAD2D7CF943FB3BBBC466_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_syncedHolderIsDesktop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_mp_49AAB017C471294D98E4C7541CB26A20_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_cuetip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_table { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_syncedCueSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_returnValSymbol_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_secondaryLocked { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_FC5583779AB8B0A4418BF7D55C5BAEB9_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_15482812C415769008DC134F4301DBAB_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_primaryLockPos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_8C89AB31DA0AC08F06018501A23C0CAD_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of PoolCue

    }
}