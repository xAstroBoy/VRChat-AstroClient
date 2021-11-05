namespace AstroLibrary.Extensions
{
    #region Imports

    using AstroLibrary.Console;
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Threading.Tasks;

    #endregion Imports

    internal static class Eventhandler_ext
    {

        internal static void SafetyRaise(this EventHandler eh)  =>  SafetyRaiseInternal(eh);


        internal static void SafetyRaise<T>(this EventHandler<T> eh, T e) where T : EventArgs =>  SafetyRaiseInternal(eh, e);

        private static void SafetyRaiseInternal(EventHandler eh)
        {
            if (eh == null)
                return;
            try
            {
                Delegate[] array = eh.GetInvocationList();
                for (int i = 0; i < array.Length; i++)
                {
                    Delegate handler = array[i];
                    if (handler != null)
                    {
                        try
                        {
                            _ = handler.DynamicInvoke(handler, null);
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
            catch (Exception e)
            {
                ModConsole.DebugError($"Error in SafetyRaiseInternal!");
                ModConsole.ErrorExc(e);

            }

        }

        private static void  SafetyRaiseInternal<T>(EventHandler<T> eh, T args) where T : EventArgs
        {
            if (eh == null)
                return;
            try
            {
                Delegate[] array = eh.GetInvocationList();
                for (int i = 0; i < array.Length; i++)
                {
                    Delegate handler = array[i];
                    if (handler != null)
                    {
                        try
                        {
                            _ = handler.DynamicInvoke(handler, args);
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
            catch (Exception e)
            {
                ModConsole.DebugError($"Error in SafetyRaiseInternal!");
                ModConsole.ErrorExc(e);

            }

        }

    }
}