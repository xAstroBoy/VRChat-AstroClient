using AstroClient.ClientActions;

namespace AstroClient.Cheetos
{
    using System;
    using System.Diagnostics;
    using Config;

    internal class HighPriority : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;
        }
        private void VRChat_OnUiManagerInit()
        {
            SetPriority(ProcessPriorityClass.High);
        }

        internal static bool IsEnabled
        {
            get => ConfigManager.Performance.HighPriority;
            set
            {
                if (value)
                {
                    SetPriority(ProcessPriorityClass.High);
                }
                else
                {
                    SetPriority(ProcessPriorityClass.Normal);
                }
            }
        }

        private static void SetPriority(ProcessPriorityClass priority)
        {
            try
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    process.PriorityClass = priority;
                    Log.Debug($"Process priority: {priority}");
                }
            }
            catch (Exception e)
            {
                Log.Error("Failed to set process priority");
                Log.Exception(e);
            }
            finally
            {
                ConfigManager.Performance.HighPriority = priority == ProcessPriorityClass.High;
            }
        }
    }
}