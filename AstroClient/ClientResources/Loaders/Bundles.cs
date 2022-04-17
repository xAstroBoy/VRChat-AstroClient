namespace AstroClient.ClientResources.Loaders
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using Helpers;
    using Paths;
    using UnityEngine;

    internal static class Bundles
    {
        private static AssetBundle _playerlistmod;

        internal static AssetBundle playerlistmod
        {
            get
            {
                if (_playerlistmod == null)
                {
                    _playerlistmod = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}playerlistmod.assetbundle"), 0u);
                    _playerlistmod.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _playerlistmod;
            }
        }



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
        private static AssetBundle _strawberry_milshake_foam;

        internal static AssetBundle strawberry_milshake_foam
        {
            get
            {
                if (_strawberry_milshake_foam == null)
                {
                    _strawberry_milshake_foam = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}strawberry_milkshake_foam.assetbundle"), 0u);
                    _strawberry_milshake_foam.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _strawberry_milshake_foam;
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

        private static AssetBundle _coffee_grains_001;

        internal static AssetBundle coffee_grains_001
        {
            get
            {
                if (_coffee_grains_001 == null)
                {
                    _coffee_grains_001 = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}coffee_grains_001.assetbundle"), 0u);
                    _coffee_grains_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _coffee_grains_001;
            }
        }

        private static AssetBundle _coin_stack_001;

        internal static AssetBundle coin_stack_001
        {
            get
            {
                if (_coin_stack_001 == null)
                {
                    _coin_stack_001 = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}coin_stack_001.assetbundle"), 0u);
                    _coin_stack_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _coin_stack_001;
            }
        }
        private static AssetBundle _fabric_padded_005;

        internal static AssetBundle fabric_padded_005
        {
            get
            {
                if (_fabric_padded_005 == null)
                {
                    _fabric_padded_005 = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}fabric_padded_005.assetbundle"), 0u);
                    _fabric_padded_005.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _fabric_padded_005;
            }
        }
        private static AssetBundle _metal_gold_001;

        internal static AssetBundle metal_gold_001
        {
            get
            {
                if (_metal_gold_001 == null)
                {
                    _metal_gold_001 = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}metal_gold_001.assetbundle"), 0u);
                    _metal_gold_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _metal_gold_001;
            }
        }
        private static AssetBundle _waffle;

        internal static AssetBundle waffle
        {
            get
            {
                if (_waffle == null)
                {
                    _waffle = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}waffle.assetbundle"), 0u);
                    _waffle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _waffle;
            }
        }

        private static AssetBundle _flashlights;
        internal static AssetBundle flashlights
        {
            get
            {
                if (_flashlights == null)
                {
                    _flashlights = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}flashlights.assetbundle"), 0u);
                    _flashlights.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _flashlights;
            }
        }

        private static AssetBundle _WorldButton;
        internal static AssetBundle WorldButton
        {
            get
            {
                if (_WorldButton == null)
                {
                    _WorldButton = AssetBundle.LoadFromMemory(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), $"{ResourcePaths.BundlesPath}WorldButton.assetbundle"), 0u);
                    _WorldButton.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _WorldButton;
            }
        }


    }
}