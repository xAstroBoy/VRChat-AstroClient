namespace AstroClient.AstroEventArgs
{
    using System;

    internal class OnSceneLoadedEventArgs : EventArgs
    {
        internal int BuildIndex;

        internal string SceneName;

        internal OnSceneLoadedEventArgs(int buildIndex, string sceneName)
        {
            BuildIndex = buildIndex;
            SceneName = sceneName;
        }
    }
}