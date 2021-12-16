namespace AstroClient.ClientUI.LoadingScreen.Prefabs
{
    using ClientResources.Loaders;
    using UnhollowerRuntimeLib;
    using UnityEngine;

    class LoadScreenPrefabs
    {
        private static AssetBundle SelectedBundle => Bundles.NewLoadingScreen;

        private static GameObject _loadScreenPrefab;
        internal static GameObject loadScreenPrefab
        {
            get
            {
                if (_loadScreenPrefab == null)
                {
                    foreach (var paths in SelectedBundle.GetAllAssetNames())
                    {
                        ModConsole.DebugLog($"Found {paths}");
                    }

                    _loadScreenPrefab = SelectedBundle.LoadAsset_Internal("Assets/Bundle/LoadingBackground.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _loadScreenPrefab.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }

                return _loadScreenPrefab;
            }
        }

        private static GameObject _loginPrefab;
        internal static GameObject loginPrefab
        {
            get
            {
                if (_loginPrefab == null)
                {
                    _loginPrefab = SelectedBundle.LoadAsset_Internal("Assets/Bundle/Login.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>();
                    _loginPrefab.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                }
                return _loginPrefab;
            }
        }


    }
}
