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
                    return Flashlight_normal;
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
                    return Flashlight_gold;
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
                    return PlayerListMenuButton;
                }

                return _PlayerListMenuButton;
            }
        }

        #endregion PlayerListMenuButton

    }
}