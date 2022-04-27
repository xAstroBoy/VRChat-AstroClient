namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class PrisonEscape_DoorControllerReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_DoorControllerReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
            {
                var obj = gameObject.FindUdonEvent("_StartCellDoorOpening");
                if (obj != null)
                {
                    DoorControl = obj.UdonBehaviour.ToRawUdonBehaviour();
                    Initialize_DoorControl();
                }
                else
                {
                    ModConsole.Error("Can't Find Player Data behaviour, Unable to Add Reader Component, did the author update the world?");
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
            Cleanup_DoorControl();
        }

        internal static RawUdonBehaviour DoorControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private void Initialize_DoorControl()
        {
            Private_cellDoors = new AstroUdonVariable<UnityEngine.Component[]>(DoorControl, "cellDoors");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__3_const_intnl_SystemString");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__0_const_intnl_SystemBoolean");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(DoorControl, "__1_const_intnl_SystemInt32");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(DoorControl, "__1_intnl_SystemInt32");
            Private___2_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__2_intnl_SystemObject");
            Private_cellsClosedObjs = new AstroUdonVariable<UnityEngine.GameObject>(DoorControl, "cellsClosedObjs");
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(DoorControl, "__0_const_intnl_VRCUdonCommonEnumsEventTiming");
            Private_cellDoorWarningDelay = new AstroUdonVariable<float>(DoorControl, "cellDoorWarningDelay");
            Private___0_intnl_CellDoor = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__0_intnl_CellDoor");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__0_const_intnl_SystemString");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__1_intnl_SystemSingle");
            Private___0_intnl_Door = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__0_intnl_Door");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__5_intnl_SystemBoolean");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(DoorControl, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__15_intnl_SystemBoolean");
            Private_doors = new AstroUdonVariable<UnityEngine.Component[]>(DoorControl, "doors");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__6_const_intnl_SystemString");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__13_intnl_SystemBoolean");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__1_const_intnl_SystemString");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__5_intnl_SystemSingle");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__16_intnl_SystemBoolean");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__7_intnl_SystemBoolean");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__7_const_intnl_SystemString");
            Private___1_intnl_AudioControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__1_intnl_AudioControl");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(DoorControl, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__4_intnl_SystemBoolean");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__11_intnl_SystemSingle");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(DoorControl, "__refl_const_intnl_udonTypeName");
            Private___0_intnl_SystemObject = new AstroUdonVariable<bool>(DoorControl, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__1_intnl_SystemBoolean");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__4_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(DoorControl, "__2_intnl_SystemInt32");
            Private___4_intnl_SystemObject = new AstroUdonVariable<float>(DoorControl, "__4_intnl_SystemObject");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__2_intnl_SystemSingle");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__3_intnl_SystemBoolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__12_intnl_SystemBoolean");
            Private___1_door_CellDoor = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__1_door_CellDoor");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__0_intnl_SystemBoolean");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__9_intnl_SystemSingle");
            Private_cellDoorOpenDelay = new AstroUdonVariable<float>(DoorControl, "cellDoorOpenDelay");
            Private___3_intnl_SystemObject = new AstroUdonVariable<bool>(DoorControl, "__3_intnl_SystemObject");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__6_intnl_SystemSingle");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__9_const_intnl_SystemString");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(DoorControl, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(DoorControl, "__0_intnl_returnTarget_UInt32");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(DoorControl, "__0_const_intnl_SystemUInt32");
            Private___0_this_intnl_DoorControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__0_this_intnl_DoorControl");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__9_intnl_SystemBoolean");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__0_intnl_SystemSingle");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__13_intnl_SystemSingle");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__6_intnl_SystemBoolean");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__4_intnl_SystemSingle");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__12_intnl_SystemSingle");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__14_intnl_SystemBoolean");
            Private___0_door_CellDoor = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__0_door_CellDoor");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(DoorControl, "__3_intnl_SystemInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__8_intnl_SystemBoolean");
            Private___1_intnl_SystemObject = new AstroUdonVariable<float>(DoorControl, "__1_intnl_SystemObject");
            Private_cellDoorsOpened = new AstroUdonVariable<bool>(DoorControl, "cellDoorsOpened");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(DoorControl, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__3_intnl_SystemSingle");
            Private___0_door_Door = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__0_door_Door");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__10_const_intnl_SystemString");
            Private___0_intnl_AudioControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__0_intnl_AudioControl");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__1_const_intnl_SystemBoolean");
            Private___5_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__5_intnl_SystemObject");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__10_intnl_SystemSingle");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__7_intnl_SystemSingle");
            Private_gameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "gameManager");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(DoorControl, "__10_intnl_SystemBoolean");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(DoorControl, "__2_const_intnl_SystemString");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(DoorControl, "__0_const_intnl_SystemInt32");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(DoorControl, "__8_intnl_SystemSingle");
            Private___1_intnl_CellDoor = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(DoorControl, "__1_intnl_CellDoor");
        }

        private void Cleanup_DoorControl()
        {
            Private_cellDoors = null;
            Private___3_const_intnl_SystemString = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___1_intnl_SystemInt32 = null;
            Private___2_intnl_SystemObject = null;
            Private_cellsClosedObjs = null;
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = null;
            Private_cellDoorWarningDelay = null;
            Private___0_intnl_CellDoor = null;
            Private___0_const_intnl_SystemString = null;
            Private___1_intnl_SystemSingle = null;
            Private___0_intnl_Door = null;
            Private___5_intnl_SystemBoolean = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___15_intnl_SystemBoolean = null;
            Private_doors = null;
            Private___6_const_intnl_SystemString = null;
            Private___13_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemString = null;
            Private___5_intnl_SystemSingle = null;
            Private___16_intnl_SystemBoolean = null;
            Private___7_intnl_SystemBoolean = null;
            Private___7_const_intnl_SystemString = null;
            Private___1_intnl_AudioControl = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___11_intnl_SystemSingle = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___0_intnl_SystemObject = null;
            Private___1_intnl_SystemBoolean = null;
            Private___4_const_intnl_SystemString = null;
            Private___11_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private___4_intnl_SystemObject = null;
            Private___2_intnl_SystemSingle = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___12_intnl_SystemBoolean = null;
            Private___1_door_CellDoor = null;
            Private___0_intnl_SystemBoolean = null;
            Private___9_intnl_SystemSingle = null;
            Private_cellDoorOpenDelay = null;
            Private___3_intnl_SystemObject = null;
            Private___8_const_intnl_SystemString = null;
            Private___6_intnl_SystemSingle = null;
            Private___9_const_intnl_SystemString = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___0_this_intnl_DoorControl = null;
            Private___9_intnl_SystemBoolean = null;
            Private___0_intnl_SystemSingle = null;
            Private___13_intnl_SystemSingle = null;
            Private___6_intnl_SystemBoolean = null;
            Private___4_intnl_SystemSingle = null;
            Private___12_intnl_SystemSingle = null;
            Private___14_intnl_SystemBoolean = null;
            Private___0_door_CellDoor = null;
            Private___3_intnl_SystemInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___1_intnl_SystemObject = null;
            Private_cellDoorsOpened = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private___0_door_Door = null;
            Private___10_const_intnl_SystemString = null;
            Private___0_intnl_AudioControl = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___5_intnl_SystemObject = null;
            Private___2_intnl_SystemBoolean = null;
            Private___10_intnl_SystemSingle = null;
            Private___7_intnl_SystemSingle = null;
            Private_gameManager = null;
            Private___10_intnl_SystemBoolean = null;
            Private___2_const_intnl_SystemString = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___8_intnl_SystemSingle = null;
            Private___1_intnl_CellDoor = null;
        }

        #region Getter / Setters AstroUdonVariables  of DoorControl

        internal UnityEngine.Component[] cellDoors
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cellDoors != null)
                {
                    return Private_cellDoors.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cellDoors != null)
                {
                    Private_cellDoors.Value = value;
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

        internal VRC.Udon.UdonBehaviour __2_intnl_SystemObject
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
                if (Private___2_intnl_SystemObject != null)
                {
                    Private___2_intnl_SystemObject.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject cellsClosedObjs
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cellsClosedObjs != null)
                {
                    return Private_cellsClosedObjs.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cellsClosedObjs != null)
                {
                    Private_cellsClosedObjs.Value = value;
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

        internal float? cellDoorWarningDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cellDoorWarningDelay != null)
                {
                    return Private_cellDoorWarningDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cellDoorWarningDelay != null)
                    {
                        Private_cellDoorWarningDelay.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_CellDoor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_CellDoor != null)
                {
                    return Private___0_intnl_CellDoor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_CellDoor != null)
                {
                    Private___0_intnl_CellDoor.Value = value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_Door
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_Door != null)
                {
                    return Private___0_intnl_Door.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_Door != null)
                {
                    Private___0_intnl_Door.Value = value;
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

        internal UnityEngine.Component[] doors
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_doors != null)
                {
                    return Private_doors.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_doors != null)
                {
                    Private_doors.Value = value;
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

        internal VRC.Udon.UdonBehaviour __1_intnl_AudioControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_AudioControl != null)
                {
                    return Private___1_intnl_AudioControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_AudioControl != null)
                {
                    Private___1_intnl_AudioControl.Value = value;
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

        internal float? __4_intnl_SystemObject
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

        internal VRC.Udon.UdonBehaviour __1_door_CellDoor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_door_CellDoor != null)
                {
                    return Private___1_door_CellDoor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_door_CellDoor != null)
                {
                    Private___1_door_CellDoor.Value = value;
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

        internal float? cellDoorOpenDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cellDoorOpenDelay != null)
                {
                    return Private_cellDoorOpenDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cellDoorOpenDelay != null)
                    {
                        Private_cellDoorOpenDelay.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_this_intnl_DoorControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_DoorControl != null)
                {
                    return Private___0_this_intnl_DoorControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_DoorControl != null)
                {
                    Private___0_this_intnl_DoorControl.Value = value;
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

        internal VRC.Udon.UdonBehaviour __0_door_CellDoor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_door_CellDoor != null)
                {
                    return Private___0_door_CellDoor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_door_CellDoor != null)
                {
                    Private___0_door_CellDoor.Value = value;
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

        internal float? __1_intnl_SystemObject
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

        internal bool? cellDoorsOpened
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cellDoorsOpened != null)
                {
                    return Private_cellDoorsOpened.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cellDoorsOpened != null)
                    {
                        Private_cellDoorsOpened.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_door_Door
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_door_Door != null)
                {
                    return Private___0_door_Door.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_door_Door != null)
                {
                    Private___0_door_Door.Value = value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_AudioControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_AudioControl != null)
                {
                    return Private___0_intnl_AudioControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_AudioControl != null)
                {
                    Private___0_intnl_AudioControl.Value = value;
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

        internal VRC.Udon.UdonBehaviour __5_intnl_SystemObject
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
                if (Private___5_intnl_SystemObject != null)
                {
                    Private___5_intnl_SystemObject.Value = value;
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

        internal VRC.Udon.UdonBehaviour __1_intnl_CellDoor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_CellDoor != null)
                {
                    return Private___1_intnl_CellDoor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_CellDoor != null)
                {
                    Private___1_intnl_CellDoor.Value = value;
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of DoorControl

        #region AstroUdonVariables  of DoorControl

        private AstroUdonVariable<UnityEngine.Component[]> Private_cellDoors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_cellsClosedObjs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___0_const_intnl_VRCUdonCommonEnumsEventTiming { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_cellDoorWarningDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_CellDoor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_Door { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private_doors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_AudioControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_door_CellDoor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_cellDoorOpenDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_DoorControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_door_CellDoor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cellDoorsOpened { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_door_Door { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_AudioControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_CellDoor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of DoorControl

    }
}