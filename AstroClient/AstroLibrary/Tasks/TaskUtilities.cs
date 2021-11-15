using System.Threading.Tasks;
using MelonLoader;

namespace AstroClient.Tasks
{
    using AstroClient.TaskHandler;
    using AstroLibrary.Console;

    /// <summary>
    /// This class contains utility methods for Task/async/await-based code
    /// </summary>
    internal static class TaskUtilities
    {
        internal static readonly AwaitProvider ourMainThreadQueue = new("AstroLibrary.ToMainThread"); 
        internal static readonly AwaitProvider ourFrameEndQueue = new("AstroLibrary.FrameEnd"); 
        
        /// <summary>
        /// Returns an awaitable object used to return an async method's execution to the main thread.
        /// After the returned object is awaited, execution will continue on main thread inside of `Update` event
        /// Can also be used to wait for the next frame
        /// </summary>
        internal static AwaitProvider.YieldAwaitable YieldToMainThread()
        {
            return ourMainThreadQueue.Yield();
        }
        
        /// <summary>
        /// Returns an awaitable object used to return an async method's execution to the main thread.
        /// After the returned object is awaited, execution will continue on main thread inside of `OnGUI` event
        /// </summary>
        internal static AwaitProvider.YieldAwaitable YieldToFrameEnd()
        {
            return ourFrameEndQueue.Yield();
        }
        
        /// <summary>
        /// Adds a handler to a Task that prints a message to console if an exception is thrown within that task
        /// </summary>
        /// <param name="taskInfo">A string that will be included in the error message to identify the task</param>
        internal static void NoAwait(this Task task, string taskInfo = "Task")
        {
            task.ContinueWith(tsk =>
            {
                if (tsk.IsFaulted)
                    ModConsole.Error($"Free-floating {taskInfo} failed with exception:");
                    ModConsole.ErrorExc(tsk.Exception);
            });
        }
    }
}