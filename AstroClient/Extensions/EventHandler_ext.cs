namespace AstroLibrary.Extensions
{
    #region Imports

    using AstroLibrary.Console;
    using System;
    using System.Reflection;

    #endregion Imports

    public static class Eventhandler_ext
    {
        public static void SafetyRaise(this EventHandler eh)
        {
            if (eh == null)
                return;

            foreach (var handler in eh.GetInvocationList())
            {
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

        public static void SafetyRaise<T>(this EventHandler<T> eh, T e) where T : EventArgs
        {
            if (eh == null)
                return;

            foreach (var handler in eh.GetInvocationList())
            {
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