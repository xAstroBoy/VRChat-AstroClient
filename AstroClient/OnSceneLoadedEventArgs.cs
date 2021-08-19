namespace AstroClient
{
	using System;

	public class OnSceneLoadedEventArgs : EventArgs
	{
		public int BuildIndex;

		public string SceneName;

		public OnSceneLoadedEventArgs(int buildIndex, string sceneName)
		{
			BuildIndex = buildIndex;
			SceneName = sceneName;
		}
	}
}