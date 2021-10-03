namespace AstroLibrary.Extensions
{
    #region Imports

    using AstroLibrary.Console;
    using System;
    using System.Reflection;

    #endregion Imports

    internal static class Eventhandler_ext
    {
        internal static void SafetyRaise(this EventHandler eh)
        {
            if (eh == null)
                return;

            Delegate[] array = eh.GetInvocationList();
            for (int i = 0; i < array.Length; i++)
            {
                Delegate handler = array[i];
                try
                {
                    _ = handler.DynamicInvoke(null, null);
                }
                catch (TargetInvocationException invokeexc)
                {
                    ModConsole.DebugError($"Error in the Handler : {handler.Method.Name}");
                    ModConsole.ErrorExc(invokeexc.InnerException);
                }
                catch (Exception exc)
                {
                    ModConsole.DebugError($"Error in the Handler : {handler.Method.Name}");
                    ModConsole.ErrorExc(exc);
                }
            }
        }

        internal static void SafetyRaise<T>(this EventHandler<T> eh, T e) where T : EventArgs
        {
            if (eh == null)
                return;

            Delegate[] array = eh.GetInvocationList();
            for (int i = 0; i < array.Length; i++)
            {
                Delegate handler = array[i];
                try
                {
                    _ = handler.DynamicInvoke(null, e);
                }
                catch (TargetInvocationException invokeexc)
                {
                    ModConsole.DebugError($"Error in the Handler : {handler.Method.Name}");
                    ModConsole.ErrorExc(invokeexc.InnerException);
                }
                catch (Exception exc)
                {
                    ModConsole.DebugError($"Error in the Handler : {handler.Method.Name}");
                    ModConsole.ErrorExc(exc);
                }
            }
        }
    }
}