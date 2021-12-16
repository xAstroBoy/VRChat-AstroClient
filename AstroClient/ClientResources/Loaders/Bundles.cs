namespace AstroClient.ClientResources.Loaders
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using Helpers;
    using Paths;
    using UnityEngine;

    internal static class Bundles
    {
        private static AssetBundle _NewLoadingScreen;

        internal static AssetBundle NewLoadingScreen
        {
            get
            {
                if (_NewLoadingScreen == null)
                {
                    _NewLoadingScreen = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}NewLoadingScreen.assetbundle"), 0u);
                    _NewLoadingScreen.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _NewLoadingScreen;
            }
        }

        private static AssetBundle _OldLoadingScreen;

        internal static AssetBundle OldLoadingScreen
        {
            get
            {
                if (_OldLoadingScreen == null)
                {
                    _OldLoadingScreen = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}OldLoadingScreen.assetbundle"), 0u);
                    _OldLoadingScreen.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _OldLoadingScreen;
            }
        }

    }
}