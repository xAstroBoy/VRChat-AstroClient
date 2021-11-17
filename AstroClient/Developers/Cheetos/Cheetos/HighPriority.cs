namespace AstroClient.Cheetos
{
    using System;
    using System.Diagnostics;
    using Config;

    internal class HighPriority : AstroEvents
    {
        internal override void VRChat_OnUiManagerInit()
        {
            if (ConfigManager.Performance.HighPriority)
            {
                SetPriority(ProcessPriorityClass.High);
            }
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
                    ModConsole.DebugLog($"Process priority: {priority}");
                }
            }
            catch (Exception e)
            {
                ModConsole.Error("Failed to set process priority");
                ModConsole.Exception(e);
            }
            finally
            {
                ConfigManager.Performance.HighPriority = priority == ProcessPriorityClass.High;
            }
        }
    }
}