namespace AstroClient.Tools.Extensions
{
    #region Imports

    using System;
    using System.Reflection;
    using System.Collections;
    using MelonLoader;
    using xAstroBoy.CodeDebugTools;

    #endregion Imports

    internal static class Eventhandler_ext
    {

        internal static void SafetyRaise(this EventHandler eh) => MelonCoroutines.Start(SafetyRaiseInternal(eh));
        internal static void SafetyRaiseDebug(this EventHandler eh) => MelonCoroutines.Start(SafetyRaiseInternalDebug(eh));

        internal static void SafetyRaise<T>(this EventHandler<T> eh, T e) where T : EventArgs => MelonCoroutines.Start(SafetyRaiseInternal(eh, e));

        internal static void SafetyRaise(this Delegate eh, params object[] args) => MelonCoroutines.Start(SafetyRaiseInternal(eh, args));

        internal static void SafetyRaiseDebug<T>(this EventHandler<T> eh, T e) where T : EventArgs => MelonCoroutines.Start(SafetyRaiseInternalDebug(eh, e));
        private static IEnumerator SafetyRaiseInternal(this Delegate eh, params object[] args)
        {
            if (eh == null)
                yield break;
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
                            _ = handler.DynamicInvoke(args);
                        }
                        catch (TargetInvocationException invokeexc)
                        {
                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            ModConsole.ErrorExc(invokeexc.InnerException);
                        }
                        catch (Exception exc)
                        {
                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
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

            yield return null;
        }

        private static IEnumerator SafetyRaiseInternal(EventHandler eh)
        {
            if (eh == null)
                yield break;
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
                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            ModConsole.ErrorExc(invokeexc.InnerException);
                        }
                        catch (Exception exc)
                        {
                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
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

            yield return null;
        }
        private static IEnumerator SafetyRaiseInternal<T>(EventHandler<T> eh, T args) where T : EventArgs
        {
            if (eh == null)
                yield break;
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
                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            ModConsole.ErrorExc(invokeexc.InnerException);
                        }
                        catch (Exception exc)
                        {
                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
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

            yield return null;
        }

        private static IEnumerator SafetyRaiseInternalDebug<T>(EventHandler<T> eh, T args) where T : EventArgs
        {
            if (eh == null)
                yield break;
            try
            {
                Delegate[] array = eh.GetInvocationList();
                for (int i = 0; i < array.Length; i++)
                {
                    Delegate handler = array[i];
                    if (handler != null)
                    {
                        var fullName = handler.Method.DeclaringType.FullName + "." + handler.Method.Name;
                        CodeDebug.StopWatchDebug(fullName, new Action(() =>
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
                        }));
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugError($"Error in SafetyRaiseInternal!");
                ModConsole.ErrorExc(e);

            }

            yield return null;
        }

        private static IEnumerator SafetyRaiseInternalDebug(EventHandler eh)
        {
            if (eh == null)
                yield break;
            try
            {
                Delegate[] array = eh.GetInvocationList();
                for (int i = 0; i < array.Length; i++)
                {
                    Delegate handler = array[i];
                    if (handler != null)
                    {
                        var fullName = handler.Method.DeclaringType.FullName + "." + handler.Method.Name;
                        CodeDebug.StopWatchDebug(fullName, new Action(() =>
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
                        }));
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugError($"Error in SafetyRaiseInternal!");
                ModConsole.ErrorExc(e);

            }

            yield return null;
        }



    }
}