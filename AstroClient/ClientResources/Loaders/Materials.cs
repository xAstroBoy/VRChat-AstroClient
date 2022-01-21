namespace AstroClient.ClientResources.Loaders
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using Helpers;
    using Paths;
    using UnhollowerRuntimeLib;
    using UnityEngine;

    internal static class Materials
    {
        #region crystal_003

        private static Material _crystal_003;

        /// <summary>
        ///     Loads Crystal_003 bundle in resources as Material
        /// </summary>
        internal static Material crystal_003
        {
            get
            {
                if (_crystal_003 == null)
                {
                    foreach (var paths in Bundles.crystal_003.GetAllAssetNames())
                    {
                        if (!paths.ToLower().EndsWith(".mat")) continue;
                        _crystal_003 = Bundles.crystal_003.LoadAsset_Internal(paths, Il2CppType.Of<Material>()).Cast<Material>();
                        _crystal_003.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                        return crystal_003;
                    }
                }

                return _crystal_003;
            }
        }

        #endregion crystal_003
        #region strawberry

        private static Material _strawberry;

        /// <summary>
        ///     Loads strawberry bundle in resources as Material
        /// </summary>
        internal static Material strawberry
        {
            get
            {
                if (_strawberry == null)
                {
                    foreach (var paths in Bundles.strawberry.GetAllAssetNames())
                    {
                        if (!paths.ToLower().EndsWith(".mat")) continue;
                        _strawberry = Bundles.strawberry.LoadAsset_Internal(paths, Il2CppType.Of<Material>()).Cast<Material>();
                        _strawberry.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                        return strawberry;
                    }
                }

                return _strawberry;
            }
        }

        #endregion strawberry

        #region chocolate

        private static Material _chocolate;

        /// <summary>
        ///     Loads chocolate bundle in resources as Material
        /// </summary>
        internal static Material chocolate
        {
            get
            {
                if (_chocolate == null)
                {
                    foreach (var paths in Bundles.chocolate.GetAllAssetNames())
                    {
                        if (!paths.ToLower().EndsWith(".mat")) continue;
                        _chocolate = Bundles.chocolate.LoadAsset_Internal(paths, Il2CppType.Of<Material>()).Cast<Material>();
                        _chocolate.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                        return chocolate;
                    }
                }

                return _chocolate;
            }
        }

        #endregion chocolate

        #region coral_001

        private static Material _coral_001;

        /// <summary>
        ///     Loads coral_001 bundle in resources as Material
        /// </summary>
        internal static Material coral_001
        {
            get
            {
                if (_coral_001 == null)
                {
                    foreach (var paths in Bundles.coral_001.GetAllAssetNames())
                    {
                        if (!paths.ToLower().EndsWith(".mat")) continue;
                        _coral_001 = Bundles.coral_001.LoadAsset_Internal(paths, Il2CppType.Of<Material>()).Cast<Material>();
                        _coral_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                        return coral_001;
                    }
                }

                return _coral_001;
            }
        }

        #endregion coral_001

    }
}