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

        #region WorldButton_clickDownAudioClip

        private static AudioClip _WorldButton_clickDownAudioClip;

        /// <summary>
        ///     Loads WorldButton clickDownAudioClip bundle in resources as AudioClip Object
        /// </summary>
        internal static AudioClip WorldButton_clickDownAudioClip
        {
            get
            {
                if (_WorldButton_clickDownAudioClip == null)
                {
                    _WorldButton_clickDownAudioClip = Bundles.buttonandsliders.LoadAsset_Internal("assets/ReimajoBoothAssets/ButtonAndSlider/Scripts/Buttons/_clickDownAudioClip.wav", Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                    _WorldButton_clickDownAudioClip.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _WorldButton_clickDownAudioClip;
                }

                return _WorldButton_clickDownAudioClip;
            }
        }

        #endregion WorldButton_clickDownAudioClip      
        #region WorldButton_clickUpAudioClip

        private static AudioClip _WorldButton_clickUpAudioClip;

        /// <summary>
        ///     Loads WorldButton clickUpAudioClip bundle in resources as AudioClip Object
        /// </summary>
        internal static AudioClip WorldButton_clickUpAudioClip
        {
            get
            {
                if (_WorldButton_clickUpAudioClip == null)
                {
                    _WorldButton_clickUpAudioClip = Bundles.buttonandsliders.LoadAsset_Internal("assets/ReimajoBoothAssets/ButtonAndSlider/Scripts/Buttons/_clickUpAudioClip.wav", Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                    _WorldButton_clickUpAudioClip.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _WorldButton_clickUpAudioClip;
                }

                return _WorldButton_clickUpAudioClip;
            }
        }

        #endregion WorldButton_clickUpAudioClip      

        #region Grapple_hit

        private static AudioClip _Grapple_hit;

        /// <summary>
        ///     Loads Grapple hit bundle in resources as AudioClip Object
        /// </summary>
        internal static AudioClip Grapple_hit
        {
            get
            {
                if (_Grapple_hit == null)
                {
                    _Grapple_hit = Bundles.Grapple.LoadAsset_Internal("assets/tether/assets/audio/hit.ogg", Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                    _Grapple_hit.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Grapple_hit;
                }

                return _Grapple_hit;
            }
        }

        #endregion Grapple_hit      

        #region Grapple_lock

        private static AudioClip _Grapple_lock;

        /// <summary>
        ///     Loads Grapple lock bundle in resources as AudioClip Object
        /// </summary>
        internal static AudioClip Grapple_lock
        {
            get
            {
                if (_Grapple_lock == null)
                {
                    _Grapple_lock = Bundles.Grapple.LoadAsset_Internal("assets/tether/assets/audio/lock.ogg", Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                    _Grapple_lock.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Grapple_lock;
                }

                return _Grapple_lock;
            }
        }

        #endregion Grapple_lock      

        #region Grapple_unwind2

        private static AudioClip _Grapple_unwind2;

        /// <summary>
        ///     Loads Grapple unwind2 bundle in resources as AudioClip Object
        /// </summary>
        internal static AudioClip Grapple_unwind2
        {
            get
            {
                if (_Grapple_unwind2 == null)
                {
                    _Grapple_unwind2 = Bundles.Grapple.LoadAsset_Internal("assets/tether/assets/audio/unwind2.ogg", Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
                    _Grapple_unwind2.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _Grapple_unwind2;
                }

                return _Grapple_unwind2;
            }
        }

        #endregion Grapple_unwind2      
    }
}