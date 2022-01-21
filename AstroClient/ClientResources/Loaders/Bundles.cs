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
        private static AssetBundle _crystal_003;

        internal static AssetBundle crystal_003
        {
            get
            {
                if (_crystal_003 == null)
                {
                    _crystal_003 = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}crystal_003.assetbundle"), 0u);
                    _crystal_003.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _crystal_003;
            }
        }
        private static AssetBundle _chocolate;

        internal static AssetBundle chocolate
        {
            get
            {
                if (_chocolate == null)
                {
                    _chocolate = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}chocolate.assetbundle"), 0u);
                    _chocolate.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _chocolate;
            }
        }
        private static AssetBundle _strawberry;

        internal static AssetBundle strawberry
        {
            get
            {
                if (_strawberry == null)
                {
                    _strawberry = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}strawberry.assetbundle"), 0u);
                    _strawberry.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _strawberry;
            }
        }

        private static AssetBundle _coral_001;

        internal static AssetBundle coral_001
        {
            get
            {
                if (_coral_001 == null)
                {
                    _coral_001 = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}coral_001.assetbundle"), 0u);
                    _coral_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _coral_001;
            }
        }

    }
}