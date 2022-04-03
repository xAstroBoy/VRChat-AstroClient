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




        internal static void SafetyRaise(this Delegate eh, params object[] args) => MelonCoroutines.Start(SafetyRaiseInternal(eh, args));

        private static IEnumerator SafetyRaiseInternal(Delegate eh, params object[] args)
        {
            if (eh == null) yield return null;

            Delegate[] array = eh.GetInvocationList();
            for (int i = 0; i < array.Length; i++)
            {
                Delegate handler = array[i];
                if (handler != null)
                {
                    MelonCoroutines.Start(ExecuteDelegate(eh, handler, args));
                }
                else
                {
                    Delegate.Remove(eh, handler);
                }
            }
            yield return null;
        }

        
        

        
        
        private static IEnumerator ExecuteDelegate(Delegate Event, Delegate handler, params object[] args)
        {
            if (Event == null) yield return null;
            if (handler == null) yield return null;

            if (handler != null)
            {

                try
                {
                    _ = handler.DynamicInvoke(handler, args);
                }
                catch (TargetInvocationException invokeexc)
                {
                    if (invokeexc.InnerException.Message.Contains("Object was garbage collected"))
                    {
                        Delegate.Remove(Event, handler);
                        yield break;
                    }

                    ModConsole.DebugError($"Error in the Handler : {handler.Method.DeclaringType.FullName + "." + handler.Method.Name}");
                    ModConsole.ErrorExc(invokeexc.InnerException);
                }
            }
            else
            {
                Delegate.Remove(Event, handler);
            }
            yield return null;
        }
        

    }
}