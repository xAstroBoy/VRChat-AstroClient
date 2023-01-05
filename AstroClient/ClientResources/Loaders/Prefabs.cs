namespace AstroClient.ClientResources.Loaders
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using ClientAttributes;
    using Helpers;
    using Paths;
    using UnhollowerRuntimeLib;
    using UnityEngine;

    internal static class Prefabs
    {
        #region Flashlight_normal

        private static GameObject _Flashlight_normal;

        /// <summary>
        ///     Loads Flashlight_normal bundle in resources as Prefab Object
        /// </summary>
        internal static GameObject Flashlight_normal
        {
            get
            {
                if (_Flashlight_normal == null)
                {
                    _Flashlight_normal = Bundles.flashlights.LoadAsset_Internal("assets/flashlight/flashlight_gold/flashlight_normal.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _Flashlight_normal.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Flashlight_normal;
                }

                return _Flashlight_normal;
            }
        }

        #endregion Flashlight_normal
        #region Flashlight_gold

        private static GameObject _Flashlight_gold;

        /// <summary>
        ///     Loads Flashlight_gold bundle in resources as Prefab Object
        /// </summary>
        internal static GameObject Flashlight_gold
        {
            get
            {
                if (_Flashlight_gold == null)
                {
                    _Flashlight_gold = Bundles.flashlights.LoadAsset_Internal("assets/flashlight/flashlight_gold/flashlight_gold.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _Flashlight_gold.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Flashlight_gold;
                }

                return _Flashlight_gold;
            }
        }

        #endregion Flashlight_gold

        #region PlayerListMod

        private static GameObject _PlayerListMod;

        /// <summary>
        ///     Loads PlayerListMod bundle in resources as Prefab Object
        /// </summary>
        internal static GameObject PlayerListMod
        {
            get
            {
                if (_PlayerListMod == null)
                {
                    _PlayerListMod = Bundles.playerlistmod.LoadAsset_Internal("Assets/Prefabs/PlayerListMod.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _PlayerListMod.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return PlayerListMod;
                }

                return _PlayerListMod;
            }
        }

        #endregion PlayerListMod


        #region PlayerListMenuButton

        private static GameObject _PlayerListMenuButton;

        /// <summary>
        ///     Loads PlayerListMenuButton bundle in resources as Prefab Object
        /// </summary>
        internal static GameObject PlayerListMenuButton
        {
            get
            {
                if (_PlayerListMenuButton == null)
                {
                    _PlayerListMenuButton = Bundles.playerlistmod.LoadAsset_Internal("Assets/Prefabs/PlayerListMenuButton.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _PlayerListMenuButton.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _PlayerListMenuButton;
                }

                return _PlayerListMenuButton;
            }
        }

        #endregion PlayerListMenuButton



        private static GameObject _WorldButton;

        /// <summary>
        ///     Loads WorldButton bundle in resources as Prefab Object
        /// </summary>
        internal static GameObject WorldButton
        {
            get
            {
                if (_WorldButton == null)
                {
                    _WorldButton = Bundles.WorldButton.LoadAsset_Internal("assets/buttonprefab/button.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _WorldButton.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _WorldButton;
                }

                return _WorldButton;
            }
        }

        private static GameObject _VRJetpack;

        /// <summary>
        ///     Loads SDK2_VRJetpack bundle in resources as Prefab Object
        /// </summary>
        internal static GameObject VRJetpack
        {
            get
            {
                if (_VRJetpack == null)
                {
                    _VRJetpack = Bundles.Jetpacks.LoadAsset_Internal("assets/drivesystem/tbdd_twohand.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _VRJetpack.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _VRJetpack;
                }

                return _VRJetpack;
            }
        }
        private static GameObject _DesktopJetpack;

        /// <summary>
        ///     Loads SDK2_DesktopJetpack bundle in resources as Prefab Object
        /// </summary>
        internal static GameObject DesktopJetpack
        {
            get
            {
                if (_DesktopJetpack == null)
                {
                    _DesktopJetpack = Bundles.Jetpacks.LoadAsset_Internal("assets/drivesystem/tbdd_onehand.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _DesktopJetpack.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _DesktopJetpack;
                }

                return _DesktopJetpack;
            }
        }

        private static GameObject _EightBall;

        /// <summary>
        ///     Loads EightBall bundle in resources as Prefab Object
        /// </summary>
        //internal static GameObject EightBall
        //{
        //    get
        //    {
        //        if (_EightBall == null)
        //        {
        //            _EightBall = Bundles.EightBall.LoadAsset_Internal("assets/crazy 8 ball/crazy8ballv1.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
        //            _EightBall.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        //            return _EightBall;
        //        }

        //        return _EightBall;
        //    }
        //}
    }
}