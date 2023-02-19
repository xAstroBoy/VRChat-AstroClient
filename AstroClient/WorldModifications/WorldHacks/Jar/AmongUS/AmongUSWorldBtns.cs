namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS
{
    using UnityEngine;
    using xAstroBoy;

    internal class AmongUsWorldBtns : AstroEvents
    {
        internal static WorldButton_Squared StartGameBtn { get; set; } = null;
        internal static WorldButton_Squared VictoryCrewmateBtn { get; set; } = null;
        internal static WorldButton_Squared VictoryImpostorBtn { get; set; } = null;
        internal static WorldButton_Squared AbortGameBtn { get; set; } = null;
        internal static WorldButton_Squared InvokeEmergencyMeetingBtn { get; set; } = null;
        internal static WorldButton_Squared Fake_Trash_garbage_Cafeteria_B { get; set; } = null;
        internal static WorldButton_Squared Fake_Trash_garbage_Storage_B { get; set; } = null;
        internal static WorldButton_Squared Fake_Trash_garbage_Storage_A { get; set; } = null;
        internal static WorldButton_Squared SkipTask_DataTransfer_Cafeteria { get; set; } = null;
        internal static WorldButton_Squared SkipTask_DataTransfer_Weapons { get; set; } = null;
        internal static WorldButton_Squared SkipTask_DataTransfer_Navigations { get; set; } = null;
        internal static WorldButton_Squared SkipTask_DataTransfer_Communication { get; set; } = null;
        internal static WorldButton_Squared SkipTask_DataTransfer_Electrical { get; set; } = null;
        internal static WorldButton_Squared SkipTask_DataTransfer_Admin { get; set; } = null;
        internal static WorldButton_Squared SkipTask_WireRepair_Navigation { get; set; } = null;
        internal static WorldButton_Squared SkipTask_WireRepair_Cafeteria { get; set; } = null;
        internal static WorldButton_Squared SkipTask_WireRepair_Security { get; set; } = null;
        internal static WorldButton_Squared SkipTask_WireRepair_Admin { get; set; } = null;
        internal static WorldButton_Squared SkipTask_WireRepair_Storage { get; set; } = null;
        internal static WorldButton_Squared SkipTask_WireRepair_Electrical { get; set; } = null; 
        internal static WorldButton_Squared SkipTask_CalibrateDistributor { get; set; } = null;
        internal static WorldButton_Squared SkipTask_CardSwipe { get; set; } = null;
        internal static WorldButton_Squared SkipTask_InspectSample { get; set; } = null;
        internal static WorldButton_Squared SkipTask_AnnoyingShit { get; set; } = null;
        internal static WorldButton_Squared SkipTask_Counting { get; set; } = null;

        internal static void Cleanup()
        {
            StartGameBtn = null;
            VictoryCrewmateBtn = null;
            VictoryImpostorBtn = null;
            AbortGameBtn = null;
            Fake_Trash_garbage_Cafeteria_B = null;
            Fake_Trash_garbage_Storage_B = null;
            Fake_Trash_garbage_Storage_A = null;
            InvokeEmergencyMeetingBtn = null;
            SkipTask_DataTransfer_Cafeteria = null;
            SkipTask_DataTransfer_Weapons = null;
            SkipTask_DataTransfer_Navigations = null;
            SkipTask_DataTransfer_Communication = null;
            SkipTask_DataTransfer_Electrical = null;
            SkipTask_DataTransfer_Admin = null;
            SkipTask_WireRepair_Navigation = null;
            SkipTask_WireRepair_Cafeteria = null;
            SkipTask_WireRepair_Security = null;
            SkipTask_WireRepair_Admin = null;
            SkipTask_WireRepair_Storage = null;
            SkipTask_WireRepair_Electrical = null;
            SkipTask_CalibrateDistributor = null;
            SkipTask_CardSwipe = null;
            SkipTask_InspectSample = null;
            SkipTask_AnnoyingShit = null;
            SkipTask_Counting = null;


        }

        internal static void SetupWorldButtons()
        {
            #region Lobby


            if (StartGameBtn == null)
            {
                StartGameBtn = new WorldButton_Squared(new Vector3(3.882721f, 1.188f, 8.309f), new Vector3(0f, 135.689f, 270f), 0.8f, "<color=green>Start Game</color>", StartGameBtn_OnButtonDown);
                StartGameBtn.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (VictoryCrewmateBtn == null)
            {
                VictoryCrewmateBtn = new WorldButton_Squared(new Vector3(4.37f, 1.188f, 7.81f), new Vector3(0f, 135.689f, 270f), 0.8000004f, "<color=red>Victory Crewmate</color>", VictoryCrewmateBtn_OnButtonDown);
                VictoryCrewmateBtn.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (VictoryImpostorBtn == null)
            {
                VictoryImpostorBtn = new WorldButton_Squared(new Vector3(4.221f, 1.188f, 7.963f), new Vector3(0f, 135.689f, 270f), 0.8f, "<color=red>Victory Impostor</color>", VictoryImpostorBtn_OnButtonDown);
                VictoryImpostorBtn.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (AbortGameBtn == null)
            {
                AbortGameBtn = new WorldButton_Squared(new Vector3(4.055774f, 1.188f, 8.131964f), new Vector3(0f, 135.689f, 270f), 0.8000004f, "<color=red>Abort game</color>", AbortGameBtn_OnButtonDown);
                AbortGameBtn.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }
            #endregion Lobby

            #region Cafeteria


            if (InvokeEmergencyMeetingBtn == null)
            {
                InvokeEmergencyMeetingBtn = new WorldButton_Squared(new Vector3(1.849f, 0.823f, 157.122f), new Vector3(0f, 272.9732f, 0f), 1, "<color=red>Invoke Emergency Meeting!</color>", InvokeEmergencyMeetingBtn_OnButtonDown);
                InvokeEmergencyMeetingBtn.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            #endregion Cafeteria

            #region  Task Fakers

            #region Trash


            if (Fake_Trash_garbage_Cafeteria_B == null)
            {
                Fake_Trash_garbage_Cafeteria_B = new WorldButton_Squared(new Vector3(-6.5154f, 1.1805f, 153.2389f), new Vector3(0f, 310f, 270f), 1, "<color=red>Expel Trash Animation</color>", Fake_Trash_garbage_Cafeteria_B_OnButtonDown);
                Fake_Trash_garbage_Cafeteria_B.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (Fake_Trash_garbage_Storage_B == null)
            {
                Fake_Trash_garbage_Storage_B = new WorldButton_Squared(new Vector3(-0.7646f, 1.1406f, 181.311f), new Vector3(0f, 90f, 270f), 1, "<color=red>Expel Trash Animation</color>", Fake_Trash_garbage_Storage_B_OnButtonDown);
                Fake_Trash_garbage_Storage_B.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (Fake_Trash_garbage_Storage_A == null)
            {
                Fake_Trash_garbage_Storage_A = new WorldButton_Squared(new Vector3(0.344f, 1.1406f, 181.311f), new Vector3(0f, 90f, 270f), 1, "<color=red>Expel Trash Animation</color>", Fake_Trash_garbage_Storage_A_OnButtonDown);
                Fake_Trash_garbage_Storage_A.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }


            #endregion

            #endregion

            #region Skip Tasks.

            #region Transfer Data
            if (SkipTask_DataTransfer_Cafeteria == null)
            {
                SkipTask_DataTransfer_Cafeteria = new WorldButton_Squared(new Vector3(-5.6177f, 1.458f, 152.2212f), new Vector3(-1.024528E-05f, 315.2437f, 270f), 0.5f, "<color=green>Skip Data Transfer Task</color>", SkipTask_DataTransfer_Cafeteria_OnButtonDown);
                SkipTask_DataTransfer_Cafeteria.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_DataTransfer_Weapons == null)
            {
                SkipTask_DataTransfer_Weapons = new WorldButton_Squared(new Vector3(-12.319f, 1.461f, 151.857f), new Vector3(-1.024528E-05f, 269.2205f, 270f), 0.5f, "<color=green>Skip Data Transfer Task</color>", SkipTask_DataTransfer_Weapons_OnButtonDown);
                SkipTask_DataTransfer_Weapons.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_DataTransfer_Navigations == null)
            {
                SkipTask_DataTransfer_Navigations = new WorldButton_Squared(new Vector3(-22.94811f, 1.439489f, 161.1781f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Data Transfer Task</color>", SkipTask_DataTransfer_Navigations_OnButtonDown);
                SkipTask_DataTransfer_Navigations.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_DataTransfer_Communication == null)
            {
                SkipTask_DataTransfer_Communication = new WorldButton_Squared(new Vector3(-5.592102f, 1.422372f, 177.017f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Data Transfer Task</color>", SkipTask_DataTransfer_Communication_OnButtonDown);
                SkipTask_DataTransfer_Communication.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_DataTransfer_Electrical == null)
            {
                SkipTask_DataTransfer_Electrical = new WorldButton_Squared(new Vector3(13.67042f, 1.424186f, 168.0129f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Data Transfer Task</color>", SkipTask_DataTransfer_Electrical_OnButtonDown);
                SkipTask_DataTransfer_Electrical.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_DataTransfer_Admin == null)
            {
                SkipTask_DataTransfer_Admin = new WorldButton_Squared(new Vector3(-3.362774f, 1.487175f, 166.4071f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Data Transfer Task</color>", SkipTask_DataTransfer_Admin_OnButtonDown);
                SkipTask_DataTransfer_Admin.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }


            #endregion

            #region Wire Repairs

            if (SkipTask_WireRepair_Navigation == null)
            {
                SkipTask_WireRepair_Navigation = new WorldButton_Squared(new Vector3(-19.56466f, 1.365633f, 162.9394f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Wire Repair Task</color>", SkipTask_WireRepair_Navigation_OnButtonDown);
                SkipTask_WireRepair_Navigation.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_WireRepair_Cafeteria == null)
            {
                SkipTask_WireRepair_Cafeteria = new WorldButton_Squared(new Vector3(7.056208f, 1.315212f, 150.4779f), new Vector3(0f, 225f, 270f), 0.5f, "<color=green>Skip Wire Repair Task</color>", SkipTask_WireRepair_Cafeteria_OnButtonDown);
                SkipTask_WireRepair_Cafeteria.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_WireRepair_Security == null)
            {
                SkipTask_WireRepair_Security = new WorldButton_Squared(new Vector3(20.81536f, 1.301853f, 163.8193f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Wire Repair Task</color>", SkipTask_WireRepair_Security_OnButtonDown);
                SkipTask_WireRepair_Security.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_WireRepair_Admin == null)
            {
                SkipTask_WireRepair_Admin = new WorldButton_Squared(new Vector3(-1.103954f, 1.314798f, 166.5235f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Wire Repair Task</color>", SkipTask_WireRepair_Admin_OnButtonDown);
                SkipTask_WireRepair_Admin.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_WireRepair_Storage == null)
            {
                SkipTask_WireRepair_Storage = new WorldButton_Squared(new Vector3(2.538058f, 1.34358f, 169.3608f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Wire Repair Task</color>", SkipTask_WireRepair_Storage_OnButtonDown);
                SkipTask_WireRepair_Storage.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            if (SkipTask_WireRepair_Electrical == null)
            {
                SkipTask_WireRepair_Electrical = new WorldButton_Squared(new Vector3(10.747f, 1.637f, 168.191f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Wire Repair Task</color>", SkipTask_WireRepair_Electrical_OnButtonDown);
                SkipTask_WireRepair_Electrical.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }

            #endregion

            #region  Electrical

            if (SkipTask_CalibrateDistributor == null)
            {
                SkipTask_CalibrateDistributor = new WorldButton_Squared(new Vector3(9.0162f, 1.6723f, 168.4052f), new Vector3(0f, 270f, 270f), 0.5f, "<color=green>Skip Calibrate distributor Task</color>", SkipTask_CalibrateDistributor_OnButtonDown);
                SkipTask_CalibrateDistributor.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }



            #endregion

            #region Admin

            if (SkipTask_CardSwipe == null)
            {
                SkipTask_CardSwipe = new WorldButton_Squared(new Vector3(-7.6759f, 0.6966f, 169.3956f), new Vector3(0.05300045f, 179.541f, 2.605512E-11f), 0.5f, "<color=green>Skip  Card Swipe Task</color>", SkipTask_CardSwipe_OnButtonDown);
                SkipTask_CardSwipe.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }



            #endregion

            #region MedBay

            if (SkipTask_InspectSample == null)
            {
                SkipTask_InspectSample = new WorldButton_Squared(new Vector3(8.718f, 0.968f, 165.4162f), new Vector3(0f, 90f, 270f), 0.5f, "<color=green>Skip Inspect Sample Task</color>", SkipTask_InspectSample_OnButtonDown);
                SkipTask_InspectSample.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }


            #endregion

            #region Reactor
            if (SkipTask_AnnoyingShit == null)
            {
                SkipTask_AnnoyingShit = new WorldButton_Squared(new Vector3(30.1503f, 0.9826f, 165.0001f), new Vector3(0f, 180.103f, 0f), 0.5f, "<color=green>Skip Reactor annoying Task</color>", SkipTask_AnnoyingShit_OnButtonDown);
                SkipTask_AnnoyingShit.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }
            if (SkipTask_Counting == null)
            {
                SkipTask_Counting = new WorldButton_Squared(new Vector3(31.37037f, 1.147702f, 161.739f), new Vector3(359.0143f, 234.6128f, 279.9955f), 0.7f, "<color=green>Skip Reactor Counting Task</color>", SkipTask_Counting_OnButtonDown);
                SkipTask_Counting.Set_isToggleButton(false); // Remove this line if you want to be a toggle button.
            }



            #endregion
            #endregion
        }

        #region Lobby

        internal static void StartGameBtn_OnButtonDown() => AmongUsUdonEvents.StartGameEvent.Invoke();

        internal static void VictoryCrewmateBtn_OnButtonDown() => AmongUsUdonEvents.VictoryCrewmateEvent.Invoke();

        internal static void VictoryImpostorBtn_OnButtonDown() => AmongUsUdonEvents.VictoryImpostorEvent.Invoke();

        internal static void AbortGameBtn_OnButtonDown() => AmongUsUdonEvents.AbortGameEvent.Invoke();

        #endregion Lobby

        #region Cafeteria        
        internal static void InvokeEmergencyMeetingBtn_OnButtonDown() => AmongUsUdonEvents.SyncEmergencyMeeting.Invoke();

        #endregion Cafeteria

        #region  Fake Task (Trash)
        internal static void Fake_Trash_garbage_Cafeteria_B_OnButtonDown() => AmongUsUdonEvents.EmptyGarbage_Cafeteria_B.Invoke();
        internal static void Fake_Trash_garbage_Storage_B_OnButtonDown() => AmongUsUdonEvents.EmptyGarbage_Storage_B.Invoke();
        internal static void Fake_Trash_garbage_Storage_A_OnButtonDown() => AmongUsUdonEvents.EmptyGarbage_Storage_A.Invoke();



        #endregion

        #region Skip Tasks

        #region Transfer Data
        internal static void SkipTask_DataTransfer_Cafeteria_OnButtonDown()  => AmongUsUdonEvents.Complete_Task_Data_Transfer_A__Cafeteria_.Invoke();
        internal static void SkipTask_DataTransfer_Weapons_OnButtonDown()  => AmongUsUdonEvents.Complete_Task_Data_Transfer_B__Weapons_.Invoke();
        internal static void SkipTask_DataTransfer_Navigations_OnButtonDown()  => AmongUsUdonEvents.Complete_Task_Data_Transfer_C__Navigation_.Invoke();
        internal static void SkipTask_DataTransfer_Communication_OnButtonDown()  => AmongUsUdonEvents.Complete_Task_Data_Transfer_D__Communications_.Invoke();
        internal static void SkipTask_DataTransfer_Electrical_OnButtonDown()  => AmongUsUdonEvents.Complete_Task_Data_Transfer_E__Electrical_.Invoke();
        internal static void SkipTask_DataTransfer_Admin_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Data_Transfer_Z__Admin_.Invoke();



        #endregion

        #region Wires
        internal static void SkipTask_WireRepair_Navigation_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Fix_Wiring__Navigation_.Invoke();
        internal static void SkipTask_WireRepair_Cafeteria_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Fix_Wiring__Cafeteria_.Invoke();
        internal static void SkipTask_WireRepair_Security_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Fix_Wiring__Security_.Invoke();
        internal static void SkipTask_WireRepair_Admin_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Fix_Wiring__Admin_.Invoke();
        internal static void SkipTask_WireRepair_Storage_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Fix_Wiring__Storage_.Invoke();
        internal static void SkipTask_WireRepair_Electrical_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Fix_Wiring__Electrical_.Invoke();



        #endregion

        #region Electrical

        internal static void SkipTask_CalibrateDistributor_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Calibrate_Distributor.Invoke();


        #endregion

        #region Admin

        internal static void SkipTask_CardSwipe_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Card_Swipe.Invoke();



        #endregion

        #region  MedBay
        internal static void SkipTask_InspectSample_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Inspect_Sample.Invoke();
        #endregion

        #region Reactor

        internal static void SkipTask_AnnoyingShit_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Simon_Says.Invoke();
        internal static void SkipTask_Counting_OnButtonDown() => AmongUsUdonEvents.Complete_Task_Counting.Invoke();



        #endregion
        #endregion
    }
}