namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using Harmony;
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
					ModConsole.Log("MainThreadRunner: Ready!");
				}
			}
		}

		public void Update()
		{
			if (queue.Count > 0)
			{
				mutex.WaitOne();
				queue[0]();
				mutex.ReleaseMutex();
				mutex.WaitOne();
				queue.RemoveAt(0);
				mutex.ReleaseMutex();
				ModConsole.Log($"MainThreadRunner: Action Ran");
			}
		}

		public static void Run(Action action)
		{
			mutex.WaitOne();
			Instance.queue.Add(action);
			mutex.ReleaseMutex();
		}
	}
}
