namespace AstroClient.Experiments
{
    #region Usings

    using System.Collections.Generic;
    using AstroMonos.Components.Tools;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    #endregion

    internal class CameraTweaker : AstroEvents
    {
        internal static Transform UserCamera
        {
            get
            {
                if (_UserCamera == null)
                {
                    var camerapath1 = Finder.Find("_Application/TrackingVolume/PlayerObjects/UserCamera").transform;
                    if (camerapath1 != null)
                    {
                        return _UserCamera = camerapath1;
                    }
                    else
                    {
                        var camerapath2 = Finder.Find("UserCamera").transform;
                        if (camerapath2 != null)
                        {
                            return _UserCamera = camerapath2;
                        }
                    }
                    return null;
                }
                else
                {
                    return _UserCamera;
                }
            }
        }

        internal static Transform ViewFinder
        {
            get
            {
                if (_ViewFinder != null)
                {
                    return _ViewFinder;
                }
                else
                {
                    var item = UserCamera.FindObject("ViewFinder").transform;
                    if (item != null)
                    {
                        return _ViewFinder = item;
                    }
                }
                return null;
            }
        }

        internal static Transform userCameraParent
        {
            get
            {
                if (_UserCameraParent != null)
                {
                    return _UserCameraParent;
                }
                else
                {
                    var item = Finder.Find("_Application/TrackingVolume/PlayerObjects").transform;
                    if (item != null)
                    {
                        return _UserCameraParent = item;
                    }
                }
                return null;
            }
        }

        private static Transform _UserCamera;
        private static Transform _ViewFinder;
        private static Transform _UserCameraParent;
    }
}