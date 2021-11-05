namespace AstroClient.ClientUI.ActionMenuButtons.AvatarParametersModule
{
    using UnityEngine;
    using UnityEngine.Experimental.Rendering;
    using UnityEngine.Rendering;

    internal static class ParametersEditorResources
    {
        private static readonly string CameraName = "AstroPreviewCamera";
        private static GameObject _AstroPreviewCamera;

        internal static GameObject AstroPreviewCamera
        {
            get
            {
                if (_AstroPreviewCamera == null) // instead of using a prefab, let's build it manually...
                {
                    var cameraobj = new GameObject();
                    cameraobj.transform.SetParent(SpawnedItemsHolder.GetDoNotDestroySpawnedItemsHolder().transform);
                    cameraobj.name = CameraName;
                    var camera = cameraobj.AddComponent<Camera>();
                    if (camera != null)
                    {
                        camera.name = CameraName;
                        camera.nearClipPlane = 0.05f;
                        camera.farClipPlane = 0.6f;
                        camera.fieldOfView = 60;
                        camera.renderingPath = RenderingPath.Forward;
                        camera.allowHDR = true;
                        camera.allowMSAA = true;
                        camera.allowDynamicResolution = false;
                        camera.forceIntoRenderTexture = false;
                        camera.orthographic = true;
                        camera.orthographicSize = 0.1938f;
                        camera.opaqueSortMode = OpaqueSortMode.Default;
                        camera.transparencySortMode = TransparencySortMode.Default;
                        camera.transparencySortAxis = new Vector3(0, 0, 1);
                        camera.depth = 0;
                        camera.aspect = 1;
                        camera.eventMask = -1;
                        camera.layerCullSpherical = false;
                        camera.cameraType = CameraType.Game;
                        camera.overrideSceneCullingMask = 0;
                        camera.useOcclusionCulling = false;
                        camera.backgroundColor = new Color(1, 1, 1, 0);
                        camera.clearFlags = CameraClearFlags.SolidColor;
                        camera.clearStencilAfterLightingPass = false;
                        camera.usePhysicalProperties = false;
                        camera.sensorSize = new Vector2(36, 24);
                        camera.lensShift = new Vector2(0, 0);
                        camera.focalLength = 50;
                        camera.gateFit = Camera.GateFitMode.Horizontal;
                        camera.rect = new Rect(0, 0, 1, 1);
                        camera.targetDisplay = 0;
                        camera.useJitteredProjectionMatrixForTransparentRendering = true;
                        camera.stereoSeparation = 0.022f;
                        camera.stereoConvergence = 10;
                        CustomRenderTexture customrenderer = new CustomRenderTexture(256, 256, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
                        customrenderer.name = CameraName + "_Texture";
                        customrenderer.wrapMode = TextureWrapMode.Clamp; 
                        customrenderer.wrapModeU = TextureWrapMode.Clamp;
                        customrenderer.wrapModeV = TextureWrapMode.Clamp;
                        customrenderer.wrapModeW = TextureWrapMode.Clamp;
                        customrenderer.filterMode = FilterMode.Bilinear;
                        customrenderer.anisoLevel = 1;
                        customrenderer.mipMapBias = 0;
                        customrenderer.dimension = TextureDimension.Tex2D;
                        customrenderer.graphicsFormat = GraphicsFormat.R8G8B8A8_UNorm;
                        customrenderer.useMipMap = false;
                        customrenderer.autoGenerateMips = true;
                        customrenderer.volumeDepth = 1;
                        customrenderer.antiAliasing = 1;
                        customrenderer.bindTextureMS = false;
                        customrenderer.enableRandomWrite = false;
                        customrenderer.useDynamicScale = false;
                        customrenderer.isPowerOfTwo = true;
                        customrenderer.depth = 0;
                        customrenderer.isCubemap = false;
                        customrenderer.isVolume = false;
                        customrenderer.material = null;
                        customrenderer.initializationMaterial = null;
                        customrenderer.initializationTexture = null;
                        customrenderer.initializationSource = CustomRenderTextureInitializationSource.TextureAndColor; 
                        customrenderer.initializationColor = new Color(1, 1, 1, 1);
                        customrenderer.updateMode = CustomRenderTextureUpdateMode.OnLoad;
                        customrenderer.initializationMode = CustomRenderTextureUpdateMode.OnDemand;
                        customrenderer.updateZoneSpace = CustomRenderTextureUpdateZoneSpace.Normalized;
                        customrenderer.shaderPass = 0;
                        customrenderer.doubleBuffered = false;
                        customrenderer.wrapUpdateZones = false;
                        customrenderer.hideFlags = HideFlags.DontUnloadUnusedAsset;
                        camera.targetTexture = customrenderer;
                        camera.targetTexture.height = 256;
                        camera.targetTexture.width = 256;
                        camera.pixelRect = new Rect(0f, 0f, 256f, 256f);
                    }
                    return _AstroPreviewCamera = cameraobj;
                }

                return _AstroPreviewCamera;
            }
        }
    }
}