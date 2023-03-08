using AstroClient.HighlightFXv2.Enums;
using UnityEngine;

namespace AstroClient.HighlightFXv2;

internal struct ModelMaterials
{
    internal bool render; // if this object can render this frame
    internal Transform transform;
    internal bool bakedTransform;
    internal Vector3 currentPosition;
    internal Vector3 currentRotation;
    internal Vector3 currentScale;
    internal bool renderWasVisibleDuringSetup;
    internal Mesh mesh;
    internal Mesh originalMesh;
    internal Renderer renderer;
    internal bool isSkinnedMesh;
    internal NormalsOption normalsOption;
    internal Material[] fxMatMask;
    internal Material[] fxMatSolidColor;
    internal Material[] fxMatSeeThroughInner;
    internal Material[] fxMatSeeThroughBorder;
    internal Material[] fxMatOverlay;
    internal Material[] fxMatInnerGlow;
    internal Matrix4x4 renderingMatrix;
    internal bool isCombined;

    internal bool preserveOriginalMesh
    {
        get { return !isCombined && normalsOption == NormalsOption.PreserveOriginal; }
    }

    internal void Init()
    {
        render = false;
        transform = null;
        bakedTransform = false;
        currentPosition = currentRotation = currentScale = Vector3.zero;
        mesh = originalMesh = null;
        renderer = null;
        isSkinnedMesh = false;
        normalsOption = NormalsOption.Smooth;
        isCombined = false;
    }
}
