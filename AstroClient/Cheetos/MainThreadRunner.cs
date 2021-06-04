namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using Il2CppSystem.Diagnostics;
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using static AstroClient.variables.InstanceBuilder;

	public class MainThreadRunner : GameEventsBehaviour
    {
        public static MainThreadRunner Instance;

        private static Mutex mutex = new Mutex();
        private List<Action> queue = new List<Action>();

        public MainThreadRunner(IntPtr ptr) : base(ptr)
        {
        }

        ~MainThreadRunner()
        {
            mutex.Dispose();
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "MainThreadRunner";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<MainThreadRunner>();
                DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.DebugLog("MainThreadRunner: Ready!");
                }
            }
        }

        public void Update()
        {
            try
            {
                mutex.WaitOne();
                if (queue.Count >= 1)
                {
                    List<Action> toRemove = new List<Action>();

                    long totalTime = 0;

                    foreach (Action action in queue)
                    {
                        if (totalTime >= 10)
                        {
                            ModConsole.DebugLog("Waiting to run actions, took over 10ms");
                            break;
                        }
                        try
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            action();
                            stopwatch.Stop();
                            totalTime += stopwatch.ElapsedMilliseconds;
                        }
                        catch (Exception ex)
                        {
                            toRemove.Add(action);
                            ModConsole.Error($"MainThreadRunner: Action Error: {ex.Message}");
                            ModConsole.ErrorExc(ex);
                            break;
                        }
                        finally
                        {
                            toRemove.Add(action);
                        }
                    }

                    toRemove.ForEach(r => queue.Remove(r));
                }
            }
            catch (Exception e)
            {
                ModConsole.Error(e.Message);
                ModConsole.ErrorExc(e);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Queue up and run an action on the main thread.
        /// Warning: Do not run anything async on this command!
        /// </summary>
        /// <param name="action"></param>
        public static void Run(Action action)
        {
            try
            {
                mutex.WaitOne();
                Instance.queue.Add(action);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}