namespace CheetosLibrary
{
    using MelonLoader;
    using System;

    public class CheetoUtils
    {
        public static void TryRun(Action[] actions)
        {
            foreach (var action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    MelonLogger.Error(e);
                }
            }
        }
    }
}