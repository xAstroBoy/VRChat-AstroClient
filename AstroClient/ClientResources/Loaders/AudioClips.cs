namespace AstroClient.ClientResources.Loaders
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using ClientAttributes;
    using Helpers;
    using Paths;
    using UnhollowerRuntimeLib;
    using UnityEngine;

    internal static class AudioClips
    {
        #region Shuttle_gearInSound

        private static AudioClip _Shuttle_gearInSound;

        /// <summary>
        ///     Loads Shuttle gearInSound in resources as AudioClip Object
        /// </summary>
        internal static AudioClip Shuttle_gearInSound
        {
            get
            {
                if (_Shuttle_gearInSound == null)
                {
                    _Shuttle_gearInSound = Bundles.SpaceShuttle.LoadAsset_Internal("assets/reimajoboothassets/spaceshuttle/sounds/gearin.wav", Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                    _Shuttle_gearInSound.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Shuttle_gearInSound;
                }

                return _Shuttle_gearInSound;
            }
        }

        #endregion Shuttle_gearInSound      

        #region Shuttle_gearOutSound

        private static AudioClip _Shuttle_gearOutSound;

        /// <summary>
        ///     Loads Shuttle gearOutSound bundle in resources as AudioClip Object
        /// </summary>
        internal static AudioClip Shuttle_gearOutSound
        {
            get
            {
                if (_Shuttle_gearOutSound == null)
                {
                    _Shuttle_gearOutSound = Bundles.SpaceShuttle.LoadAsset_Internal("assets/reimajoboothassets/spaceshuttle/sounds/gearout.wav", Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                    _Shuttle_gearOutSound.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Shuttle_gearOutSound;
                }

                return _Shuttle_gearOutSound;
            }
        }

        #endregion Shuttle_gearOutSound      
    }
}