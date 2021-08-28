namespace AstroClient.Cheetos
{
    using AstroLibrary.Console;
    using System;
    using System.Diagnostics;

    internal class HighPriority : GameEvents
    {
        public override void VRChat_OnUiManagerInit()
        {
            if (ConfigManager.Performance.HighPriority)
            {
                SetPriority(ProcessPriorityClass.High);
            }
        }

        public static bool IsEnabled
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
                    ModConsole.Log($"Process priority: {priority}");
                }
            }
            catch (Exception e)
            {
                ModConsole.Error($"Failed to set process priority: {e.Message}");
            }
            finally
            {
                ConfigManager.Performance.HighPriority = priority == ProcessPriorityClass.High;
            }
        }
    }
}