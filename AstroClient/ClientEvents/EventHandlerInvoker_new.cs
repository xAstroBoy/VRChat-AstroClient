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

    internal static class EventHandlerInvoker
    {

        private static List<string> Results = new List<string>();
        private static bool _PerformanceTest = false;
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


        
        internal static void SafetyRaiseWithParams(this Delegate eh, params object[] args) => SafetyRaiseWithParamsInternal(eh, args);

        private static void SafetyRaiseWithParamsInternal(Delegate eh, params object[] args)
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
                            if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                            {
                                Delegate.Remove(eh, handler);
                                continue;
                            }

                            Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            Log.Exception(invokeexc.InnerException);
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

                            Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            Log.Exception(invokeexc.InnerException);
                        }
                        sw.Stop();
                        var result = $"{handler.Method.DeclaringType.FullName + "." + handler.Method.Name} Time: {sw.Elapsed.TotalMilliseconds}, FPS : {GetCurrentFPS()}";
                        if(!Results.Contains(result))
                        {
                            Log.Debug(result);

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





        internal static void SafetyRaise(this Delegate eh) => SafetyRaiseInternal(eh);

        private static void SafetyRaiseInternal(Delegate eh)
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
                            if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                            {
                                Delegate.Remove(eh, handler);
                                continue;
                            }

                            Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            Log.Exception(invokeexc.InnerException);
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
                            if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                            {
                                Delegate.Remove(eh, handler);
                                continue;
                            }

                            Log.Error($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                            Log.Exception(invokeexc.InnerException);
                        }
                        sw.Stop();
                        var result = $"{handler.Method.DeclaringType.FullName + "." + handler.Method.Name} Time: {sw.Elapsed.TotalMilliseconds}, FPS : {GetCurrentFPS()}";
                        if (!Results.Contains(result))
                        {
                            Log.Debug(result);

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