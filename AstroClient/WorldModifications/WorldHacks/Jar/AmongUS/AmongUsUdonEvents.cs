using AstroClient.CustomClasses;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS
{
    using System.Collections.Generic;

    internal class AmongUsUdonEvents
    {
        internal static void Cleanup()
        {
            StartGameEvent = null;
            AbortGameEvent = null;
            VictoryCrewmateEvent = null;
            VictoryImpostorEvent = null;

            Complete_Task_Refuel_3__Storage_ = null;
            Complete_Task_Accept_Power__3_ = null;
            Complete_Task_Chart_Course = null;
            Complete_Task_Calibrate_Distributor = null;
            Complete_Task_Data_Transfer_C__Navigation_ = null;
            Complete_Task_Empty_Garbage_A__Storage_ = null;
            Complete_Task_Submit_Scan = null;
            Complete_Task_Accept_Power__7_ = null;
            Complete_Task_Empty_Garbage_A__Oxygen_ = null;
            Complete_Task_Accept_Power__6_ = null;
            Complete_Task_Align_Engine_1__Lower_ = null;
            Complete_Task_Clean_Filter = null;
            Complete_Task_Data_Transfer_A__Cafeteria_ = null;
            Complete_Task_Accept_Power__4_ = null;
            Complete_Task_Accept_Power__1_ = null;
            Complete_Task_Empty_Garbage_B__Cafeteria_ = null;
            Complete_Task_Prime_Shields = null;
            Complete_Task_Refuel_4__Lower_Engine_ = null;
            Complete_Task_Refuel_1__Storage_ = null;
            Complete_Task_Simon_Says = null;
            Complete_Task_Inspect_Sample = null;
            Complete_Task_Data_Transfer_Z__Admin_ = null;
            Complete_Task_Data_Transfer_D__Communications_ = null;
            Complete_Task_Accept_Power__2_ = null;
            Complete_Task_Data_Transfer_E__Electrical_ = null;
            Complete_Task_Asterioids = null;
            Complete_Task_Divert_Power = null;
            Complete_Task_Card_Swipe = null;
            Complete_Task_Data_Transfer_B__Weapons_ = null;
            Complete_Task_Stabilize_Steering = null;
            Complete_Task_Refuel_2__Upper_Engine_ = null;
            Complete_Task_Align_Engine_2__Upper_ = null;
            Complete_Task_Accept_Power__0_ = null;
            Complete_Task_Counting = null;
            Complete_Task_Empty_Garbage_B__Storage_ = null;
            Complete_Task_Accept_Power__5_ = null;
            Complete_Task_Fix_Wiring__Security_ = null;
            Complete_Task_Fix_Wiring__Navigation_ = null;
            Complete_Task_Fix_Wiring__Electrical_ = null;
            Complete_Task_Fix_Wiring__Storage_ = null;
            Complete_Task_Fix_Wiring__Admin_ = null;
            Complete_Task_Fix_Wiring__Cafeteria_ = null;

            EmptyGarbage_Storage_A = null;
            EmptyGarbage_Storage_B = null;
            EmptyGarbage_Oxygen_A = null;
            EmptyGarbage_Cafeteria_B = null;

            CancelAllSabotages = null;
            SyncEmergencyMeeting = null;
            SyncBodyFound = null;
            SyncCloseVoting = null;
            SyncEndVotingPhase = null;
            SyncVoteResultNobody = null;
            SyncVoteResultSkip = null;
            SyncVoteResultTie = null;
            Sabotage_DoorsCafeteria = null;
            Sabotage_DoorsMedbay = null;
            Sabotage_DoorsUpper = null;
            Sabotage_DoorsLower = null;
            Sabotage_DoorsSecurity = null;
            Sabotage_DoorsStorage = null;
            Sabotage_DoorsElectrical = null;
            Sabotage_Lights = null;
            Repair_Lights = null;
            Sabotage_Comms = null;
            Repair_Comms = null;
            Sabotage_Reactor = null;
            Repair_Reactor = null;
            Sabotage_Oxygen = null;
            Repair_OxygenA = null;
            Repair_OxygenB = null;
            Repair_Oxygen = null;

            SabotageAllDoors.Clear();
            SubmitScanTask = null;
        }

        internal static void SearchEvents()
        {
            StartGameEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncStart");
            AbortGameEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncAbort");
            VictoryCrewmateEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncVictoryC");
            VictoryImpostorEvent = UdonSearch.FindUdonEvent("Game Logic", "SyncVictoryI");

            #region Sabotages, repairs and misc

            SyncEmergencyMeeting = UdonSearch.FindUdonEvent("Game Logic", "SyncEmergencyMeeting");
            SyncBodyFound = UdonSearch.FindUdonEvent("Game Logic", "SyncBodyFound");
            SyncCloseVoting = UdonSearch.FindUdonEvent("Game Logic", "SyncCloseVoting");
            SyncEndVotingPhase = UdonSearch.FindUdonEvent("Game Logic", "SyncEndVotingPhase");
            SyncVoteResultNobody = UdonSearch.FindUdonEvent("Game Logic", "SyncVoteResultNobody");
            SyncVoteResultSkip = UdonSearch.FindUdonEvent("Game Logic", "SyncVoteResultSkip");
            SyncVoteResultTie = UdonSearch.FindUdonEvent("Game Logic", "SyncVoteResultTie");
            Sabotage_DoorsCafeteria = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageDoorsCafeteria");
            Sabotage_DoorsMedbay = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageDoorsMedbay");
            Sabotage_DoorsUpper = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageDoorsUpper");
            Sabotage_DoorsLower = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageDoorsLower");
            Sabotage_DoorsSecurity = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageDoorsSecurity");
            Sabotage_DoorsStorage = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageDoorsStorage");
            Sabotage_DoorsElectrical = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageDoorsElectrical");
            Sabotage_Lights = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageLights");
            Repair_Lights = UdonSearch.FindUdonEvent("Game Logic", "SyncRepairLights");
            Sabotage_Comms = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageComms");
            Repair_Comms = UdonSearch.FindUdonEvent("Game Logic", "SyncRepairComms");
            Sabotage_Reactor = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageReactor");
            Repair_Reactor = UdonSearch.FindUdonEvent("Game Logic", "SyncRepairReactor");
            Sabotage_Oxygen = UdonSearch.FindUdonEvent("Game Logic", "SyncDoSabotageOxygen");
            Repair_OxygenA = UdonSearch.FindUdonEvent("Game Logic", "SyncRepairOxygenA");
            Repair_OxygenB = UdonSearch.FindUdonEvent("Game Logic", "SyncRepairOxygenB");
            Repair_Oxygen = UdonSearch.FindUdonEvent("Game Logic", "SyncRepairOxygen");

            #endregion Sabotages, repairs and misc

            CancelAllSabotages = UdonSearch.FindUdonEvent("Game Logic", "CancelAllSabotage");

            EmptyGarbage_Storage_A = UdonSearch.FindUdonEvent("Task Empty Garbage A (Storage)", "SyncConfirmAnimation");
            EmptyGarbage_Storage_B = UdonSearch.FindUdonEvent("Task Empty Garbage B (Storage)", "SyncConfirmAnimation");
            EmptyGarbage_Oxygen_A = UdonSearch.FindUdonEvent("Task Empty Garbage A (Oxygen)", "SyncConfirmAnimation");
            EmptyGarbage_Cafeteria_B = UdonSearch.FindUdonEvent("Task Empty Garbage B (Cafeteria)", "SyncConfirmAnimation");

            SubmitScanTask = UdonSearch.FindUdonEvent("Task Submit Scan", "SyncStartScan");

            #region Complete Tasks events.

            Complete_Task_Refuel_3__Storage_ = UdonSearch.FindUdonEvent("Task Refuel 3 (Storage)", "CompleteTask");
            Complete_Task_Accept_Power__3_ = UdonSearch.FindUdonEvent("Task Accept Power (3)", "CompleteTask");
            Complete_Task_Chart_Course = UdonSearch.FindUdonEvent("Task Chart Course", "CompleteTask");
            Complete_Task_Calibrate_Distributor = UdonSearch.FindUdonEvent("Task Calibrate Distributor", "CompleteTask");
            Complete_Task_Data_Transfer_C__Navigation_ = UdonSearch.FindUdonEvent("Task Data Transfer C (Navigation)", "CompleteTask");
            Complete_Task_Empty_Garbage_A__Storage_ = UdonSearch.FindUdonEvent("Task Empty Garbage A (Storage)", "CompleteTask");
            Complete_Task_Submit_Scan = UdonSearch.FindUdonEvent("Task Submit Scan", "CompleteTask");
            Complete_Task_Accept_Power__7_ = UdonSearch.FindUdonEvent("Task Accept Power (7)", "CompleteTask");
            Complete_Task_Empty_Garbage_A__Oxygen_ = UdonSearch.FindUdonEvent("Task Empty Garbage A (Oxygen)", "CompleteTask");
            Complete_Task_Accept_Power__6_ = UdonSearch.FindUdonEvent("Task Accept Power (6)", "CompleteTask");
            Complete_Task_Align_Engine_1__Lower_ = UdonSearch.FindUdonEvent("Task Align Engine 1 (Lower)", "CompleteTask");
            Complete_Task_Clean_Filter = UdonSearch.FindUdonEvent("Task Clean Filter", "CompleteTask");
            Complete_Task_Data_Transfer_A__Cafeteria_ = UdonSearch.FindUdonEvent("Task Data Transfer A (Cafeteria)", "CompleteTask");
            Complete_Task_Accept_Power__4_ = UdonSearch.FindUdonEvent("Task Accept Power (4)", "CompleteTask");
            Complete_Task_Accept_Power__1_ = UdonSearch.FindUdonEvent("Task Accept Power (1)", "CompleteTask");
            Complete_Task_Empty_Garbage_B__Cafeteria_ = UdonSearch.FindUdonEvent("Task Empty Garbage B (Cafeteria)", "CompleteTask");
            Complete_Task_Prime_Shields = UdonSearch.FindUdonEvent("Task Prime Shields", "CompleteTask");
            Complete_Task_Refuel_4__Lower_Engine_ = UdonSearch.FindUdonEvent("Task Refuel 4 (Lower Engine)", "CompleteTask");
            Complete_Task_Refuel_1__Storage_ = UdonSearch.FindUdonEvent("Task Refuel 1 (Storage)", "CompleteTask");
            Complete_Task_Simon_Says = UdonSearch.FindUdonEvent("Task Simon Says", "CompleteTask");
            Complete_Task_Inspect_Sample = UdonSearch.FindUdonEvent("Task Inspect Sample", "CompleteTask");
            Complete_Task_Data_Transfer_Z__Admin_ = UdonSearch.FindUdonEvent("Task Data Transfer Z (Admin)", "CompleteTask");
            Complete_Task_Data_Transfer_D__Communications_ = UdonSearch.FindUdonEvent("Task Data Transfer D (Communications)", "CompleteTask");
            Complete_Task_Accept_Power__2_ = UdonSearch.FindUdonEvent("Task Accept Power (2)", "CompleteTask");
            Complete_Task_Data_Transfer_E__Electrical_ = UdonSearch.FindUdonEvent("Task Data Transfer E (Electrical)", "CompleteTask");
            Complete_Task_Asterioids = UdonSearch.FindUdonEvent("Task Asterioids", "CompleteTask");
            Complete_Task_Divert_Power = UdonSearch.FindUdonEvent("Task Divert Power", "CompleteTask");
            Complete_Task_Card_Swipe = UdonSearch.FindUdonEvent("Task Card Swipe", "CompleteTask");
            Complete_Task_Data_Transfer_B__Weapons_ = UdonSearch.FindUdonEvent("Task Data Transfer B (Weapons)", "CompleteTask");
            Complete_Task_Stabilize_Steering = UdonSearch.FindUdonEvent("Task Stabilize Steering", "CompleteTask");
            Complete_Task_Refuel_2__Upper_Engine_ = UdonSearch.FindUdonEvent("Task Refuel 2 (Upper Engine)", "CompleteTask");
            Complete_Task_Align_Engine_2__Upper_ = UdonSearch.FindUdonEvent("Task Align Engine 2 (Upper)", "CompleteTask");
            Complete_Task_Accept_Power__0_ = UdonSearch.FindUdonEvent("Task Accept Power (0)", "CompleteTask");
            Complete_Task_Counting = UdonSearch.FindUdonEvent("Task Counting", "CompleteTask");
            Complete_Task_Empty_Garbage_B__Storage_ = UdonSearch.FindUdonEvent("Task Empty Garbage B (Storage)", "CompleteTask");
            Complete_Task_Accept_Power__5_ = UdonSearch.FindUdonEvent("Task Accept Power (5)", "CompleteTask");
            Complete_Task_Fix_Wiring__Security_ = UdonSearch.FindUdonEvent("Task Fix Wiring (Security)", "CompleteTask");
            Complete_Task_Fix_Wiring__Navigation_ = UdonSearch.FindUdonEvent("Task Fix Wiring (Navigation)", "CompleteTask");
            Complete_Task_Fix_Wiring__Electrical_ = UdonSearch.FindUdonEvent("Task Fix Wiring (Electrical)", "CompleteTask");
            Complete_Task_Fix_Wiring__Storage_ = UdonSearch.FindUdonEvent("Task Fix Wiring (Storage)", "CompleteTask");
            Complete_Task_Fix_Wiring__Admin_ = UdonSearch.FindUdonEvent("Task Fix Wiring (Admin)", "CompleteTask");
            Complete_Task_Fix_Wiring__Cafeteria_ = UdonSearch.FindUdonEvent("Task Fix Wiring (Cafeteria)", "CompleteTask");

            #endregion Complete Tasks events.

            #region Sabotage All doors

            var VictoryCrewMateKeys = VictoryCrewmateEvent.UdonBehaviour.Get_EventKeys();
            for (int i = 0; i < VictoryCrewMateKeys.Length; i++)
            {
                var subaction = VictoryCrewMateKeys[i];
                if (subaction.StartsWith("SyncDoSabotage"))
                {
                    if (subaction.Contains("Doors"))
                    {
                        var tmp = new UdonBehaviour_Cached(VictoryCrewmateEvent.UdonBehaviour, subaction);
                        if (!SabotageAllDoors.Contains(tmp))
                        {
                            SabotageAllDoors.Add(tmp);
                        }
                    }
                }
            }

            #endregion Sabotage All doors
        }

        internal static UdonBehaviour_Cached SyncEmergencyMeeting { get; set; } = null;
        internal static UdonBehaviour_Cached SyncBodyFound { get; set; } = null;
        internal static UdonBehaviour_Cached SyncCloseVoting { get; set; } = null;
        internal static UdonBehaviour_Cached SyncEndVotingPhase { get; set; } = null;
        internal static UdonBehaviour_Cached SyncVoteResultNobody { get; set; } = null;
        internal static UdonBehaviour_Cached SyncVoteResultSkip { get; set; } = null;
        internal static UdonBehaviour_Cached SyncVoteResultTie { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_DoorsCafeteria { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_DoorsMedbay { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_DoorsUpper { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_DoorsLower { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_DoorsSecurity { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_DoorsStorage { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_DoorsElectrical { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_Lights { get; set; } = null;
        internal static UdonBehaviour_Cached Repair_Lights { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_Comms { get; set; } = null;
        internal static UdonBehaviour_Cached Repair_Comms { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_Reactor { get; set; } = null;
        internal static UdonBehaviour_Cached Repair_Reactor { get; set; } = null;
        internal static UdonBehaviour_Cached Sabotage_Oxygen { get; set; } = null;
        internal static UdonBehaviour_Cached Repair_OxygenA { get; set; } = null;
        internal static UdonBehaviour_Cached Repair_OxygenB { get; set; } = null;
        internal static UdonBehaviour_Cached Repair_Oxygen { get; set; } = null;
        internal static UdonBehaviour_Cached StartGameEvent { get; set; }
        internal static UdonBehaviour_Cached AbortGameEvent { get; set; }
        internal static UdonBehaviour_Cached VictoryCrewmateEvent { get; set; }
        internal static UdonBehaviour_Cached VictoryImpostorEvent { get; set; }

        internal static UdonBehaviour_Cached EmptyGarbage_Storage_A { get; set; }
        internal static UdonBehaviour_Cached EmptyGarbage_Storage_B { get; set; }

        internal static UdonBehaviour_Cached EmptyGarbage_Oxygen_A { get; set; }

        internal static UdonBehaviour_Cached EmptyGarbage_Cafeteria_B { get; set; }

        internal static UdonBehaviour_Cached CancelAllSabotages { get; set; }
        internal static UdonBehaviour_Cached SubmitScanTask { get; set; }

        internal static List<UdonBehaviour_Cached> SabotageAllDoors { get; set; } = new();

        #region Complete Task Events

        internal static UdonBehaviour_Cached Complete_Task_Refuel_3__Storage_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__3_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Chart_Course { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Calibrate_Distributor { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Data_Transfer_C__Navigation_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Empty_Garbage_A__Storage_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Submit_Scan { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__7_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Empty_Garbage_A__Oxygen_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__6_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Align_Engine_1__Lower_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Clean_Filter { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Data_Transfer_A__Cafeteria_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__4_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__1_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Empty_Garbage_B__Cafeteria_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Prime_Shields { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Refuel_4__Lower_Engine_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Refuel_1__Storage_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Simon_Says { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Inspect_Sample { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Data_Transfer_Z__Admin_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Data_Transfer_D__Communications_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__2_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Data_Transfer_E__Electrical_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Asterioids { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Divert_Power { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Card_Swipe { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Data_Transfer_B__Weapons_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Stabilize_Steering { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Refuel_2__Upper_Engine_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Align_Engine_2__Upper_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__0_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Counting { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Empty_Garbage_B__Storage_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Accept_Power__5_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Fix_Wiring__Security_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Fix_Wiring__Navigation_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Fix_Wiring__Electrical_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Fix_Wiring__Storage_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Fix_Wiring__Admin_ { get; set; } = null;
        internal static UdonBehaviour_Cached Complete_Task_Fix_Wiring__Cafeteria_ { get; set; } = null;

        #endregion Complete Task Events
    }
}