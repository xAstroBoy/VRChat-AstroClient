using System.Collections.Generic;
using System.Diagnostics;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.Tools.Extensions
{
    #region Imports

    using System;
    using System.Reflection;
    using System.Collections;
    using MelonLoader;
    using xAstroBoy.CodeDebugTools;

    #endregion Imports

    internal static class EventHandlerInvoker
    {

        private static List<string> Results = new List<string>();
        private static bool _PerformanceTest = false;

        internal static bool PerformanceTest 
        {
            get
            {
                return _PerformanceTest;
            }
            set
            {
                _PerformanceTest = value;
                Results.Clear(); 
            }
        }

        internal static void SafetyRaise(this Delegate eh, params object[] args) => SafetyRaiseInternal(eh, args);

        private static void SafetyRaiseInternal(Delegate eh, params object[] args)
        {
            if (eh == null) return;

            Delegate[] array = eh.GetInvocationList();
            for (int i = 0; i < array.Length; i++)
            {
                Delegate handler = array[i];
                if (handler != null)
                {
                    if (!PerformanceTest)
                    {
                        try
                        {
                            _ = handler.DynamicInvoke(args);
                        }
                        catch (TargetInvocationException invokeexc)
                        {
                            if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                            {
                                Delegate.Remove(eh, handler);
                                continue;
                            }

                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            ModConsole.ErrorExc(invokeexc.InnerException);
                        }

                    }
                    else
                    {
                        Stopwatch sw = Stopwatch.StartNew();
                        try
                        {
                            _ = handler.DynamicInvoke(args);
                        }
                        catch (TargetInvocationException invokeexc)
                        {
                            if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                            {
                                Delegate.Remove(eh, handler);
                                continue;
                            }

                            ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            ModConsole.ErrorExc(invokeexc.InnerException);
                        }
                        sw.Stop();
                        var result = $"{handler.Method.DeclaringType.FullName + "." + handler.Method.Name} Time: {sw.Elapsed.TotalMilliseconds}";
                        if(!Results.Contains(result))
                        {
                            ModConsole.DebugLog(result);

                            Results.Add(result);
                        }

                        

                    }
                }
                else
                {
                    Delegate.Remove(eh, handler);
                }
            }
        }

        
        

        
        

    }
}