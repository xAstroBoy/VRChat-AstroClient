namespace AstroClient.ActionMenu
{
    using AstroActionMenu.Api;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AstroLibrary;
    using AstroLibrary.Extensions;
    using UnityEngine;

    internal static class ParametersEditorResources
    {
        private  static readonly string CameraName = "AstroPreviewCamera";
        private  static Camera _AstroPreviewCamera;

        internal static Camera AstroPreviewCamera
        {
            get
            {
                if (_AstroPreviewCamera == null) // instead of using a prefab, let's build it manually...
                {
                    var cameraobj = new GameObject();
                    cameraobj.transform.SetParent(SpawnedItemsHolder.GetDoNotDestroySpawnedItemsHolder().transform);
                    cameraobj.name = CameraName;
                    Camera camera = cameraobj.AddComponent<Camera>();
                    if (camera != null)
                    {
                        camera.clearFlags = CameraClearFlags.SolidColor;
                        camera.backgroundColor = Color.white;
                        camera.cullingMask = 1;
                        //camera.projectionMatrix = Matrix4x4.Ortho();
                        camera.orthographicSize = 0.14f;
                        camera.farClipPlane = 0.6f;
                        camera.nearClipPlane = 0.05f;
                        camera.rect = new Rect(0, 0, 1, 1);
                        camera.depth = 0;
                        camera.renderingPath = RenderingPath.UsePlayerSettings;
                        camera.targetTexture = null;
                        camera.useOcclusionCulling = false;
                        camera.allowHDR = true;
                        camera.allowMSAA = true;
                        camera.allowDynamicResolution = false;
                        camera.stereoSeparation = 0.022f;
                        camera.stereoConvergence = 10;
                        camera.targetDisplay = 0;
                        camera.stereoTargetEye = 0;
                        camera.Set_DontDestroyOnLoad();
                        return _AstroPreviewCamera = camera;
                    }
                }
                return _AstroPreviewCamera;
            }
        }




    }
}
