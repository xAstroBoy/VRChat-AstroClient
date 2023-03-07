namespace AstroClient.ClientResources.Loaders
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using ClientAttributes;
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
                    _crystal_003 = Bundles.crystal_003.LoadAsset_Internal("assets/gems/crystal_003.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _crystal_003.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _crystal_003;
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
                    _strawberry = Bundles.strawberry.LoadAsset_Internal("assets/gems/strawberry.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _strawberry.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _strawberry;
                }

                return _strawberry;
            }
        }

        #endregion strawberry
        #region strawberry_milshake_foam

        private static Material _strawberry_milshake_foam;

        /// <summary>
        ///     Loads strawberry_milshake_foam bundle in resources as Material
        /// </summary>
        internal static Material strawberry_milshake_foam
        {
            get
            {
                if (_strawberry_milshake_foam == null)
                {
                    _strawberry_milshake_foam = Bundles.strawberry_milshake_foam.LoadAsset_Internal("assets/material generator/strawberry_milkshake_foam.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _strawberry_milshake_foam.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _strawberry_milshake_foam;
                }

                return _strawberry_milshake_foam;
            }
        }

        #endregion strawberry_milshake_foam

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
                    _chocolate = Bundles.chocolate.LoadAsset_Internal("assets/gems/chocolate.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _chocolate.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return chocolate;
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
                    _coral_001 = Bundles.coral_001.LoadAsset_Internal("assets/gems/coral_001.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _coral_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _coral_001;
                }

                return _coral_001;
            }
        }

        #endregion coral_001
        #region coffee_grains_001

        private static Material _coffee_grains_001;

        /// <summary>
        ///     Loads coffee_grains_001 bundle in resources as Material
        /// </summary>
        internal static Material coffee_grains_001
        {
            get
            {
                if (_coffee_grains_001 == null)
                {
                    _coffee_grains_001 = Bundles.coffee_grains_001.LoadAsset_Internal("assets/gems/coffee_grains_001.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _coffee_grains_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _coffee_grains_001;
                }
                return _coffee_grains_001;
            }
        }

        #endregion coffee_grains_001
        #region coin_stack_001

        private static Material _coin_stack_001;

        /// <summary>
        ///     Loads coin_stack_001 bundle in resources as Material
        /// </summary>
        internal static Material coin_stack_001
        {
            get
            {
                if (_coin_stack_001 == null)
                {
                    _coin_stack_001 = Bundles.coin_stack_001.LoadAsset_Internal("assets/gems/coin_stack_001.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _coin_stack_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _coin_stack_001;
                }

                return _coin_stack_001;
            }
        }

        #endregion coin_stack_001

        #region fabric_padded_005

        private static Material _fabric_padded_005;

        /// <summary>
        ///     Loads fabric_padded_005 bundle in resources as Material
        /// </summary>
        internal static Material fabric_padded_005
        {
            get
            {
                if (_fabric_padded_005 == null)
                {
                    _fabric_padded_005 = Bundles.fabric_padded_005.LoadAsset_Internal("assets/gems/fabric_padded_005.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _fabric_padded_005.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _fabric_padded_005;
                }

                return _fabric_padded_005;
            }
        }

        #endregion fabric_padded_005

        #region metal_gold_001

        private static Material _metal_gold_001;

        /// <summary>
        ///     Loads metal_gold_001 bundle in resources as Material
        /// </summary>
        internal static Material metal_gold_001
        {
            get
            {
                if (_metal_gold_001 == null)
                {
                    _metal_gold_001 = Bundles.metal_gold_001.LoadAsset_Internal("assets/gems/metal_gold_001.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _metal_gold_001.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _metal_gold_001;
                }

                return _metal_gold_001;
            }
        }

        #endregion metal_gold_001
        #region waffle

        private static Material _waffle;

        /// <summary>
        ///     Loads waffle bundle in resources as Material
        /// </summary>
        internal static Material waffle
        {
            get
            {
                if (_waffle == null)
                {
                    _waffle = Bundles.waffle.LoadAsset_Internal("assets/Texture/waffle.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _waffle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _waffle;
                }

                return _waffle;
            }
        }

        #endregion waffle
        #region 3d_cellular_tiling

        private static Material _cellular_tiling;

        /// <summary>
        ///     Loads 3d_cellular_tiling bundle in resources as Material
        /// </summary>
        internal static Material cellular_tiling
        {
            get
            {
                if (_cellular_tiling == null)
                {
                    _cellular_tiling = Bundles.Shaders.LoadAsset_Internal("assets/shader experiments/3dcellular/3d cellular tiling.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _cellular_tiling.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _cellular_tiling;
                }

                return _cellular_tiling;
            }
        }

        #endregion 3d_cellular_tiling


        #region 3d_fractal_Land

        private static Material _fractal_Land;

        /// <summary>
        ///     Loads 3d_fractal_Land bundle in resources as Material
        /// </summary>
        internal static Material fractal_Land
        {
            get
            {
                if (_fractal_Land == null)
                {
                    _fractal_Land = Bundles.Shaders.LoadAsset_Internal("assets/shader experiments/fractal land/fractal land.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _fractal_Land.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _fractal_Land;
                }

                return _fractal_Land;
            }
        }

        #endregion 3d_fractal_Land

        #region 3d_happy_jumping

        private static Material _happy_jumping;

        /// <summary>
        ///     Loads 3d_happy_jumping bundle in resources as Material
        /// </summary>
        internal static Material happy_jumping
        {
            get
            {
                if (_happy_jumping == null)
                {
                    _happy_jumping = Bundles.Shaders.LoadAsset_Internal("assets/shader experiments/happy jumping/happy jumping.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _happy_jumping.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _happy_jumping;
                }

                return _happy_jumping;
            }
        }

        #endregion 3d_happy_jumping

        #region 3d_reef_and_waves

        private static Material _reef_and_waves;

        /// <summary>
        ///     Loads 3d_reef_and_waves bundle in resources as Material
        /// </summary>
        internal static Material reef_and_waves
        {
            get
            {
                if (_reef_and_waves == null)
                {
                    _reef_and_waves = Bundles.Shaders.LoadAsset_Internal("assets/shader experiments/reef and waves/reef and waves 4.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _reef_and_waves.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _reef_and_waves;
                }

                return _reef_and_waves;
            }
        }

        #endregion 3d_reef_and_waves

        #region 3d_rough_seas

        private static Material _rough_seas;

        /// <summary>
        ///     Loads 3d_rough_seas bundle in resources as Material
        /// </summary>
        internal static Material rough_seas
        {
            get
            {
                if (_rough_seas == null)
                {
                    _rough_seas = Bundles.Shaders.LoadAsset_Internal("assets/shader experiments/rough seas/rough seas .mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _rough_seas.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _rough_seas;
                }

                return _rough_seas;
            }
        }

        #endregion 3d_rough_seas

        #region 3d_Woods_Forestry

        private static Material _Woods_Forestry;

        /// <summary>
        ///     Loads 3d_Woods_Forestry bundle in resources as Material
        /// </summary>
        internal static Material Woods_Forestry
        {
            get
            {
                if (_Woods_Forestry == null)
                {
                    _Woods_Forestry = Bundles.Shaders.LoadAsset_Internal("assets/shader experiments/woods/woods.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _Woods_Forestry.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Woods_Forestry;
                }

                return _Woods_Forestry;
            }
        }

        #endregion 3d_Woods_Forestry

        #region 3d_fractal_trees

        private static Material _fractal_trees;

        /// <summary>
        ///     Loads 3d_fractal_trees bundle in resources as Material
        /// </summary>
        internal static Material fractal_trees
        {
            get
            {
                if (_fractal_trees == null)
                {
                    _fractal_trees = Bundles.Shaders.LoadAsset_Internal("assets/shader experiments/fractal trees/fractal trees gif.mat", Il2CppType.Of<Material>()).Cast<Material>();
                    _fractal_trees.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _fractal_trees;
                }

                return _fractal_trees;
            }
        }

        #endregion 3d_fractal_trees

    }
}