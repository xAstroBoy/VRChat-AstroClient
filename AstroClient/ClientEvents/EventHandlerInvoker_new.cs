using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace AstroClient
{
    #region Imports

    #endregion Imports

    // TODO : Rewrite and make it even better <3
    internal static class EventHandlerInvoker
    {

        private static List<string> Results = new List<string>();
#if CHEETOS
        private static bool _PerformanceTest = true;
#else
        private static bool _PerformanceTest = false;
#endif

        private static bool _CheckForFPS = false;
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
        internal static bool CheckForFPS
        {
            get
            {
                return _CheckForFPS;
            }
            set
            {
                _CheckForFPS = value;
                Results.Clear();
            }
        }


        internal static int GetCurrentFPS()
        {
           return Mathf.Clamp((int)(1f / Time.deltaTime), -99, 999);
        }


        internal static void SafetyRaiseWithParamsAndNoExceptions(this Delegate eh, params object[] args) => SafetyRaiseWithParamsInternal(eh: eh, SuppressExceptions: true, args: args);

        internal static void SafetyRaiseWithParams(this Delegate eh, params object[] args) => SafetyRaiseWithParamsInternal(eh: eh, SuppressExceptions: false, args: args);

        private static void SafetyRaiseWithParamsInternal(Delegate eh, bool SuppressExceptions, params object[] args)
        {
            if (eh == null) return;
            if(args == null)
            {
                args = new object[]
                {
                    null,
                };
            }

            Delegate[] array = eh.GetInvocationList();
            if (array.Length == 0) return; // if there's no subscribers, just ignore the event
                
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

                            if (CheckForFPS)
                            {
                                if (Enumerable.Range(1, 12).Contains(GetCurrentFPS()))
                                {
                                    var result = $"{handler.Method.DeclaringType.FullName + "." + handler.Method.Name} Possibly Lowered your FPS : {GetCurrentFPS()}";
                                    if (!Results.Contains(result))
                                    {
                                        Log.Debug(result);
                                        Results.Add(result);
                                    }
                                }
                            }
                        }
                        catch (TargetInvocationException invokeexc)
                        {
                            if (!SuppressExceptions)
                            {
                                //if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                                //{
                                //    continue;
                                //}

                                Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                                Log.Exception(invokeexc.InnerException);
                            }
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
                            if (!SuppressExceptions)
                            {
                                //if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                                //{
                                //    continue;
                                //}

                                Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                                Log.Exception(invokeexc.InnerException);
                            }
                        }
                        sw.Stop();
                        if (sw.ElapsedMilliseconds > 100)
                        {

                            var result = $"{handler.Method.DeclaringType.FullName + "." + handler.Method.Name} Elapsed Milliseconds : {sw.ElapsedMilliseconds}";
                            if (!Results.Contains(result))
                            {
                                Log.Warn(result);
                                Results.Add(result);
                            }
                        }
                    }
                }
            }
        }
        
        internal static void SafetyRaise(this Delegate eh, bool SuppressExceptions = false) => SafetyRaiseInternal(eh, SuppressExceptions);

        private static void SafetyRaiseInternal(Delegate eh, bool SuppressExceptions = false)
        {
            if (eh == null) return;
            Delegate[] array = eh.GetInvocationList();
            if (array.Length == 0) return; // if there's no subscribers, just ignore the event
            for (int i = 0; i < array.Length; i++)
            {
                Delegate handler = array[i];
                if (handler != null)
                {
                    if (!PerformanceTest)
                    {
                        try
                        {
                            _ = handler.DynamicInvoke();

                            if (CheckForFPS)
                            {
                                if (Enumerable.Range(1, 12).Contains(GetCurrentFPS()))
                                {
                                    var result = $"{handler.Method.DeclaringType.FullName + "." + handler.Method.Name} Possibly Lowered your FPS : {GetCurrentFPS()}";
                                    if (!Results.Contains(result))
                                    {
                                        Log.Debug(result);
                                        Results.Add(result);
                                    }
                                }
                            }
                        }
                        catch (TargetInvocationException invokeexc)
                        {
                            if (!SuppressExceptions)
                            {
                                //if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                                //{
                                //    continue;
                                //}

                                Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                                Log.Exception(invokeexc.InnerException);
                            }
                        }

                    }
                    else
                    {
                        Stopwatch sw = Stopwatch.StartNew();
                        try
                        {
                            _ = handler.DynamicInvoke();
                        }
                        catch (TargetInvocationException invokeexc)
                        {
                            if (!SuppressExceptions)
                            {
                                //if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                                //{
                                //    continue;
                                //}

                                Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                                Log.Exception(invokeexc.InnerException);
                            }
                        }
                        sw.Stop();
                        if (sw.ElapsedMilliseconds > 1)
                        {
                            var target = string.Empty;
                            if (handler.Target != null)
                            {
                                target = handler.Target.ToString();
                            }
                            else
                            {
                                target = "NULL";
                            }
                            var result = $"[{handler.Target.ToString()}] {handler.Method.DeclaringType.FullName + "." + handler.Method.Name} Time: {sw.Elapsed.TotalMilliseconds}ms, FPS : {GetCurrentFPS()}";
                            if (!Results.Contains(result))
                            {
                                Log.Warn(result);
                                Results.Add(result);
                            }
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