namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using Harmony;
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using static AstroClient.variables.InstanceBuilder;

	public class MainThreadRunner : GameEventsBehaviour
	{
		public static MainThreadRunner Instance;

		private object queueLock = new object();
		private List<Action> queue = new List<Action>();

		public MainThreadRunner(IntPtr ptr) : base(ptr)
		{
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
			lock (queueLock)
			{
				queue.Do(a => a.Invoke());
			}

			lock (queueLock)
			{
				queue.Clear();
			}
		}

		public static void Run(Action action)
		{
			Instance.AddAction(action);
		}

		private void AddAction(Action action)
		{
			lock (queueLock)
			{
				queue.Add(action);
			}
		}
	}
}
