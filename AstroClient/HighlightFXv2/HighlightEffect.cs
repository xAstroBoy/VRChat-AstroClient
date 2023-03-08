using AstroClient.ClientAttributes;
using AstroClient.HighlightFXv2.Enums;
using AstroClient.HighlightFXv2.Events;
using AstroClient.HighlightFXv2.Extensions;
using System;
using System.Collections.Generic;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using UnityEngine.Rendering;
using QualityLevel = AstroClient.HighlightFXv2.Enums.QualityLevel;

namespace AstroClient.HighlightFXv2
{
    //https://www.dropbox.com/s/v9qgn68ydblqz8x/Documentation.pdf?dl=0
    [RegisterComponent]
    public class HighlightEffect : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public HighlightEffect(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }


        /// <summary>
        /// Gets or sets the current profile. To load a profile and apply its settings at runtime, please use ProfileLoad() method.
        /// The current profile (optional). A profile let you store Highlight Plus settings and apply those settings easily to many objects. You can also load a profile and apply its settings at runtime, using the ProfileLoad() method of the Highlight Effect component.
        /// </summary>
        internal HighlightProfile profile;

        /// <summary>
        /// Sets if changes to the original profile should propagate to this effect.
        /// If enabled, settings from the profile will be applied to this component automatically when game starts or when any profile setting is updated.
        /// </summary>
        internal bool profileSync;

        /// <summary>
        /// Makes the effects visible in the SceneView.
        /// If enabled, effects will be visible also when not in Play mode.
        /// </summary>
        internal bool previewInEditor = true;

        /// <summary>
        /// Which cameras can render the effects
        /// </summary>
        internal LayerMask camerasLayerMask = -1;

        /// <summary>
        /// Specifies which objects are affected by this effect.
        /// Different options to specify which objects are affected by this Highlight Effect component.
        /// </summary>
        internal TargetOptions effectGroup = TargetOptions.Children;

        /// <summary>
        /// The layer that contains the affected objects by this effect when effectGroup is set to LayerMask.
        /// The layer that contains the affected objects by this effect when effectGroup is set to LayerMask.
        /// </summary>
        internal LayerMask effectGroupLayer = -1;

        /// <summary>
        /// Optional object name filter
        /// Only include objects whose names contains this text.
        /// </summary>
        internal string effectNameFilter;

        /// <summary>
        /// Combine objects into a single mesh
        /// Combine meshes of all objects in this group affected by Highlight Effect reducing draw calls.
        /// </summary>
        internal bool combineMeshes;

        /// <summary>
        /// The alpha threshold for transparent cutout objects. Pixels with alpha below this value will be discarded.
        /// The alpha threshold for transparent cutout objects. Pixels with alpha below this value will be discarded.
        /// </summary>

        internal float alphaCutOff;

        /// <summary>
        /// If back facing triangles are ignored. Backfaces triangles are not visible but you may set this property to false to force highlight effects to act on those triangles as well.
        /// If back facing triangles are ignored.Backfaces triangles are not visible but you may set this property to false to force highlight effects to act on those triangles as well.
        /// </summary>
        internal bool cullBackFaces = true;

        /// <summary>
        /// Show highlight effects even if the object is currently not visible. This option is useful if the affected objects are rendered using GPU instancing tools which render directly to the GPU without creating real game object geometry in CPU.
        /// Show highlight effects even if the object is not visible. If this object or its children use GPU Instancing tools, the MeshRenderer can be disabled although the object is visible. In this case, this option is useful to enable highlighting.
        /// </summary>
        internal bool ignoreObjectVisibility;

        /// <summary>
        /// Enable to support reflection probes
        /// Support reflection probes. Enable only if you want the effects to be visible in reflections.
        /// </summary>
        internal bool reflectionProbes;

        /// <summary>
        /// Enable to support reflection probes
        /// Enables GPU instancing. Reduces draw calls in outline and outer glow effects on platforms that support GPU instancing. Should be enabled by default.
        /// </summary>
        internal bool GPUInstancing = true;

        /// <summary>
        /// Enabled depth buffer flip in HQ
        /// Enables depth buffer clipping. Only applies to outline or outer glow in High Quality mode.
        /// </summary>
        internal bool depthClip;

        /// <summary>
        /// Fades out effects based on distance to camera
        /// </summary>
        internal bool cameraDistanceFade;

        /// <summary>
        /// The closest distance particles can get to the camera before they fade from the camera’s view.
        /// </summary>
        internal float cameraDistanceFadeNear;

        /// <summary>
        /// The farthest distance particles can get away from the camera before they fade from the camera’s view.
        /// </summary>
        internal float cameraDistanceFadeFar = 1000;

        /// <summary>
        /// Normals handling option:\nPreserve original: use original mesh normals.\nSmooth: average normals to produce a smoother outline/glow mesh based effect.\nReorient: recomputes normals based on vertex direction to centroid.\nPlanar: same than reorient but renders outline and glow in an optimized way for 2D or planar meshes like quads or planes.
        /// </summary>
        internal NormalsOption normalsOption;

        /// <summary>
        /// Ignores highlight effects on this object.
        /// Ignore highlighting on this object.
        /// </summary>
        internal bool ignore;

        private bool _highlighted;

        internal bool highlighted
        {
            [HideFromIl2Cpp]
            get => _highlighted;
            [HideFromIl2Cpp]
            set => SetHighlighted(value);
        }

        internal float fadeInDuration;
        internal float fadeOutDuration;
        internal bool flipY;

        /// <summary>
        /// Keeps the outline/glow size unaffected by object distance.
        /// </summary>
        internal bool constantWidth = true;

        /// <summary>
        /// Mask to include or exclude certain submeshes. By default, all submeshes are included.
        /// </summary>
        internal int subMeshMask = -1;

        /// <summary>
        /// Intensity of the overlay effect. A value of 0 disables the overlay completely.
        /// </summary>
        internal float overlay;

        internal Color overlayColor = Color.yellow;
        internal float overlayAnimationSpeed = 1f;
        internal float overlayMinIntensity = 0.5f;

        /// <summary>
        /// Controls the blending or mix of the overlay color with the natural colors of the object.
        /// </summary>
        internal float overlayBlending = 1.0f;

        /// <summary>
        /// Optional overlay texture.
        /// </summary>
        internal Texture2D overlayTexture;

        internal float overlayTextureScale = 1f;

        /// <summary>
        /// Intensity of the outline. A value of 0 disables the outline completely.
        /// </summary>
        internal float outline = 1f;

        internal Color outlineColor = Color.black;
        internal float outlineWidth = 0.45f;
        internal QualityLevel outlineQuality = QualityLevel.Medium;

        /// <summary>
        /// Reduces the quality of the outline but improves performance a bit.
        /// </summary>
        internal int outlineDownsampling = 2;

        internal Visibility outlineVisibility = Visibility.Normal;
        internal GlowBlendMode glowBlendMode = GlowBlendMode.Additive;
        internal bool outlineOptimalBlit = true;
        internal bool outlineBlitDebug;

        /// <summary>
        /// If enabled, this object won't combine the outline with other objects.
        /// </summary>
        internal bool outlineIndependent;

        /// <summary>
        /// The intensity of the outer glow effect. A value of 0 disables the glow completely.
        /// </summary>
        internal float glow;

        internal float glowWidth = 0.4f;
        internal QualityLevel glowQuality = QualityLevel.Medium;

        /// <summary>
        /// Reduces the quality of the glow but improves performance a bit.
        /// </summary>
        internal int glowDownsampling = 2;

        internal Color glowHQColor = new Color(0.64f, 1f, 0f, 1f);

        /// <summary>
        /// When enabled, outer glow renders with dithering. When disabled, glow appears as a solid color.
        /// </summary>
        internal bool glowDithering = true;

        /// <summary>
        /// Seed for the dithering effect
        /// </summary>
        internal float glowMagicNumber1 = 0.75f;

        /// <summary>
        /// Another seed for the dithering effect that combines with first seed to create different patterns
        /// </summary>
        internal float glowMagicNumber2 = 0.5f;

        internal float glowAnimationSpeed = 1f;
        internal Visibility glowVisibility = Visibility.Normal;

        /// <summary>
        /// Performs a blit to screen only over the affected area, instead of a full-screen pass
        /// </summary>
        internal bool glowOptimalBlit = true;

        internal bool glowBlitDebug;

        /// <summary>
        /// Blends glow passes one after another. If this option is disabled, glow passes won't overlap (in this case, make sure the glow pass 1 has a smaller offset than pass 2, etc.)
        /// </summary>
        internal bool glowBlendPasses = true;

        internal GlowPassData[] glowPasses;

        /// <summary>
        /// If enabled, glow effect will not use a stencil mask. This can be used to render the glow effect alone.
        /// </summary>
        internal bool glowIgnoreMask;

        /// <summary>
        /// The intensity of the inner glow effect. A value of 0 disables the glow completely.
        /// </summary>
        internal float innerGlow;

        internal float innerGlowWidth = 1f;
        internal Color innerGlowColor = Color.white;
        internal Visibility innerGlowVisibility = Visibility.Normal;

        /// <summary>
        /// Enables the targetFX effect. This effect draws an animated sprite over the object.
        /// </summary>
        internal bool targetFX;

        internal Texture2D targetFXTexture;
        internal Color targetFXColor = Color.white;
        internal Transform targetFXCenter;
        internal float targetFXRotationSpeed = 50f;
        internal float targetFXInitialScale = 4f;
        internal float targetFXEndScale = 1.5f;

        /// <summary>
        /// Makes target scale relative to object renderer bounds
        /// </summary>
        internal bool targetFXScaleToRenderBounds = true;

        /// <summary>
        /// Places target FX sprite at the bottom of the highlighted object.
        /// </summary>
        internal bool targetFXAlignToGround;

        /// <summary>
        /// Fade out effect with altitude
        /// </summary>
        internal float targetFXFadePower = 32;

        internal float targetFXGroundMaxDistance = 10f;
        internal LayerMask targetFXGroundLayerMask = -1;
        internal float targetFXTransitionDuration = 0.5f;

        /// <summary>
        /// The duration of the effect. A value of 0 will keep the target sprite on screen while object is highlighted.
        /// </summary>
        internal float targetFXStayDuration = 1.5f;

        internal Visibility targetFXVisibility = Visibility.AlwaysOnTop;

        internal event OnObjectHighlightEvent OnObjectHighlightStart;

        internal event OnObjectHighlightEvent OnObjectHighlightEnd;

        internal event OnRendererHighlightEvent OnRendererHighlightStart;

        internal event OnTargetAnimatesEvent OnTargetAnimates;

        /// <summary>
        /// See-through mode for this Highlight Effect component.
        /// </summary>
        internal SeeThroughMode seeThrough = SeeThroughMode.Never;

        /// <summary>
        /// This mask setting let you specify which objects will be considered as occluders and cause the see-through effect for this Highlight Effect component. For example, you assign your walls to a different layer and specify that layer here, so only walls and not other objects, like ground or ceiling, will trigger the see-through effect.
        /// </summary>
        internal LayerMask seeThroughOccluderMask = -1;

        /// <summary>
        /// A multiplier for the occluder volume size which can be used to reduce the actual size of occluders when Highlight Effect checks if they're occluding this object.
        /// </summary>
        internal float seeThroughOccluderThreshold = 0.3f;

        /// <summary>
        /// Uses stencil buffers to ensure pixel-accurate occlusion test. If this option is disabled, only physics raycasting is used to test for occlusion.
        /// </summary>
        internal bool seeThroughOccluderMaskAccurate;

        /// <summary>
        /// The interval of time between occlusion tests.
        /// </summary>
        internal float seeThroughOccluderCheckInterval = 1f;

        /// <summary>
        /// If enabled, occlusion test is performed for each children element. If disabled, the bounds of all children is combined and a single occlusion test is performed for the combined bounds.
        /// </summary>
        internal bool seeThroughOccluderCheckIndividualObjects;

        /// <summary>
        /// Shows the see-through effect only if the occluder if at this 'offset' distance from the object.
        /// </summary>
        internal float seeThroughDepthOffset;

        /// <summary>
        /// Hides the see-through effect if the occluder is further than this distance from the object (0 = infinite)
        /// </summary>
        internal float seeThroughMaxDepth;

        internal float seeThroughIntensity = 0.8f;
        internal float seeThroughTintAlpha = 0.5f;
        internal Color seeThroughTintColor = Color.red;
        internal float seeThroughNoise = 1f;
        internal float seeThroughBorder;
        internal Color seeThroughBorderColor = Color.black;

        /// <summary>
        /// Only display the border instead of the full see-through effect.
        /// </summary>
        internal bool seeThroughBorderOnly;

        internal float seeThroughBorderWidth = 0.45f;

        /// <summary>
        /// Renders see-through effect on overlapping objects in a sequence that's relative to the distance to the camera
        /// </summary>
        internal bool seeThroughOrdered;


        private ModelMaterials[] rms;
        private int rmsCount;

        /// <summary>
        /// Number of objects affected by this highlight effect script
        /// </summary>
        internal int includedObjectsCount => rmsCount;

        internal Transform target;

        /// <summary>
        /// Time in which the highlight started
        /// </summary>

        internal float highlightStartTime;

        /// <summary>
        /// Time in which the target fx started
        /// </summary>

        internal float targetFxStartTime;

        /// <summary>
        /// True if this object is selected (if selectOnClick is used)
        /// </summary>

        internal bool isSelected;

        internal HighlightProfile previousSettings;

        internal void RestorePreviousHighlightEffectSettings()
        {
            previousSettings.Load(this);
        }

        private const float TAU = 0.70711f;

        // Reference materials. These are instanced per object (rms).
        private static Material fxMatMask, fxMatSolidColor, fxMatSeeThroughInner, fxMatSeeThroughBorder, fxMatOverlay, fxMatClearStencil;

        private static Material fxMatGlowRef, fxMatInnerGlow, fxMatOutlineRef, fxMatTargetRef;
        private static Material fxMatComposeGlowRef, fxMatComposeOutlineRef, fxMatBlurGlowRef, fxMatBlurOutlineRef;
        private static Material fxMatSeeThroughMask;

        // Per-object materials
        private Material _fxMatOutline, _fxMatGlow, _fxMatTarget;

        private Material _fxMatComposeGlow, _fxMatComposeOutline, _fxMatBlurGlow, _fxMatBlurOutline;

        private Material fxMatOutline
        {
            get
            {
                if (_fxMatOutline == null && fxMatOutlineRef != null)
                {
                    _fxMatOutline = Instantiate(fxMatOutlineRef);
                    if (useGPUInstancing) _fxMatOutline.enableInstancing = true; else _fxMatOutline.enableInstancing = false;
                }
                return _fxMatOutline;
            }
        }

        private Material fxMatGlow
        {
            get
            {
                if (_fxMatGlow == null && fxMatGlowRef != null)
                {
                    _fxMatGlow = Instantiate(fxMatGlowRef);
                    if (useGPUInstancing) _fxMatGlow.enableInstancing = true; else _fxMatGlow.enableInstancing = false;
                }
                return _fxMatGlow;
            }
        }

        private Material fxMatTarget
        {
            get
            {
                if (_fxMatTarget == null && fxMatTargetRef != null) _fxMatTarget = Instantiate(fxMatTargetRef);
                return _fxMatTarget;
            }
        }

        private Material fxMatComposeGlow
        {
            get
            {
                if (_fxMatComposeGlow == null && fxMatComposeGlowRef != null) _fxMatComposeGlow = Instantiate(fxMatComposeGlowRef);
                return _fxMatComposeGlow;
            }
        }

        private Material fxMatComposeOutline
        {
            get
            {
                if (_fxMatComposeOutline == null && fxMatComposeOutlineRef != null) _fxMatComposeOutline = Instantiate(fxMatComposeOutlineRef);
                return _fxMatComposeOutline;
            }
        }

        private Material fxMatBlurGlow
        {
            get
            {
                if (_fxMatBlurGlow == null && fxMatBlurGlowRef != null) _fxMatBlurGlow = Instantiate(fxMatBlurGlowRef);
                return _fxMatBlurGlow;
            }
        }

        private Material fxMatBlurOutline
        {
            get
            {
                if (_fxMatBlurOutline == null && fxMatBlurOutlineRef != null) _fxMatBlurOutline = Instantiate(fxMatBlurOutlineRef);
                return _fxMatBlurOutline;
            }
        }

        private void OnEnable()
        {
            lastOutlineVisibility = outlineVisibility;
            debugColor = new Color(1f, 0f, 0f, 0.5f);
            blackColor = new Color(0, 0, 0, 0);
            if (offsets == null || offsets.Length != 8)
            {
                offsets = new Vector4[] {
                    new Vector4(0,1),
                    new Vector4(1,0),
                    new Vector4(0,-1),
                    new Vector4(-1,0),
                    new Vector4 (-TAU, TAU),
                    new Vector4 (TAU, TAU),
                    new Vector4 (TAU, -TAU),
                    new Vector4 (-TAU, -TAU)
                };
            }
            if (corners == null || corners.Length != 8)
            {
                corners = new Vector3[8];
            }
            if (quadMesh == null)
            {
                BuildQuad();
            }
            if (cubeMesh == null)
            {
                BuildCube();
            }
            if (target == null)
            {
                target = transform;
            }
            if (profileSync && profile != null)
            {
                profile.Load(this);
            }
            if (glowPasses == null || glowPasses.Length == 0)
            {
                glowPasses = new GlowPassData[4];
                glowPasses[0] = new GlowPassData() { offset = 4, alpha = 0.1f, color = new Color(0.64f, 1f, 0f, 1f) };
                glowPasses[1] = new GlowPassData() { offset = 3, alpha = 0.2f, color = new Color(0.64f, 1f, 0f, 1f) };
                glowPasses[2] = new GlowPassData() { offset = 2, alpha = 0.3f, color = new Color(0.64f, 1f, 0f, 1f) };
                glowPasses[3] = new GlowPassData() { offset = 1, alpha = 0.4f, color = new Color(0.64f, 1f, 0f, 1f) };
            }
            sourceRT = Shader.PropertyToID("_HPSourceRT");
            useGPUInstancing = GPUInstancing && SystemInfo.supportsInstancing;
            if (useGPUInstancing)
            {
                if (glowPropertyBlock == null)
                {
                    glowPropertyBlock = new MaterialPropertyBlock();
                }
                if (outlinePropertyBlock == null)
                {
                    outlinePropertyBlock = new MaterialPropertyBlock();
                }
            }

            CheckGeometrySupportDependencies();
            SetupMaterial();

            if (!effects.Contains(this))
            {
                effects.Add(this);
            }
        }

        private void OnDisable()
        {
            UpdateMaterialPropertiesNow();
        }

        private void Reset()
        {
            SetupMaterial();
        }

        private void DestroyMaterial(Material mat)
        {
            if (mat != null) DestroyImmediate(mat);
        }

        private void DestroyMaterialArray(Material[] mm)
        {
            if (mm == null) return;
            for (int k = 0; k < mm.Length; k++)
            {
                DestroyMaterial(mm[k]);
            }
        }

        private void OnDestroy()
        {
            if (rms != null)
            {
                for (int k = 0; k < rms.Length; k++)
                {
                    DestroyMaterialArray(rms[k].fxMatMask);
                    DestroyMaterialArray(rms[k].fxMatSolidColor);
                    DestroyMaterialArray(rms[k].fxMatSeeThroughInner);
                    DestroyMaterialArray(rms[k].fxMatSeeThroughBorder);
                    DestroyMaterialArray(rms[k].fxMatOverlay);
                    DestroyMaterialArray(rms[k].fxMatInnerGlow);
                }
            }

            DestroyMaterial(fxMatGlow);
            DestroyMaterial(fxMatOutline);
            DestroyMaterial(fxMatTarget);
            DestroyMaterial(fxMatComposeGlow);
            DestroyMaterial(fxMatComposeOutline);
            DestroyMaterial(fxMatBlurGlow);
            DestroyMaterial(fxMatBlurOutline);

            if (effects.Contains(this))
            {
                effects.Remove(this);
            }

            if (combinedMeshes.ContainsKey(combinedMeshesHashId))
            {
                combinedMeshes.Remove(combinedMeshesHashId);
            }
        }

        internal static void DrawEffectsNow(Camera cam = null)
        {
            if (cam == null)
            {
                cam = Camera.current;
                if (cam == null) return;
            }
            int effectsCount = effects.Count;
            int thisFrame = Time.frameCount;
            for (int k = 0; k < effectsCount; k++)
            {
                HighlightEffect effect = effects[k];
                if (effect != null)
                {
                    effect.DoOnRenderObject(cam);
                    effect.skipThisFrame = thisFrame;
                }
            }
        }

        private void OnRenderObject()
        {
            if (usingPipeline) return;
            DoOnRenderObject(Camera.current);
        }

        /// <summary>
        /// Loads a profile into this effect
        /// </summary>
        internal void ProfileLoad(HighlightProfile profile)
        {
            if (profile != null)
            {
                this.profile = profile;
                profile.Load(this);
            }
        }

        /// <summary>
        /// Reloads currently assigned profile
        /// </summary>
        internal void ProfileReload()
        {
            if (profile != null)
            {
                profile.Load(this);
            }
        }

        /// <summary>
        /// Save current settings into given profile
        /// </summary>
        internal void ProfileSaveChanges(HighlightProfile profile)
        {
            if (profile != null)
            {
                profile.Save(this);
            }
        }

        /// <summary>
        /// Save current settings into current profile
        /// </summary>
        internal void ProfileSaveChanges()
        {
            if (profile != null)
            {
                profile.Save(this);
            }
        }

        internal void Refresh()
        {
            if (enabled)
            {
                SetupMaterial();
            }
        }

        private void DoOnRenderObject(Camera cam)
        {
            if (customSorting)
            {
                int frameCount = Time.frameCount;
                if (customSortingFrame != frameCount || customSortingCamera != cam)
                {
                    customSortingFrame = frameCount;
                    customSortingCamera = cam;
                    int effectsCount = effects.Count;
                    for (int k = 0; k < effectsCount; k++)
                    {
                        HighlightEffect effect = effects[k];
                        effect.skipThisFrame = -1;
                        effect.RenderEffect(cam);
                        effect.skipThisFrame = frameCount;
                    }
                }
            }
            else
            {
                RenderEffect(cam);
            }
        }

        private void RenderEffect(Camera cam)
        {
            if (cam == null || ((1 << cam.gameObject.layer) & camerasLayerMask) == 0) return;

            if (!reflectionProbes && cam.cameraType == CameraType.Reflection)
                return;

            if (requireUpdateMaterial)
            {
                requireUpdateMaterial = false;
                UpdateMaterialPropertiesNow();
            }

            bool seeThroughReal = seeThroughIntensity > 0 && (seeThrough == SeeThroughMode.AlwaysWhenOccluded || (seeThrough == SeeThroughMode.WhenHighlighted && _highlighted));
            if (seeThroughReal)
            {
                seeThroughReal = RenderSeeThroughOccluders(cam);
                if (seeThroughReal && seeThroughOccluderMask != -1)
                {
                    if (seeThroughOccluderMaskAccurate)
                    {
                        CheckOcclusionAccurate(cam);
                    }
                    else
                    {
                        seeThroughReal = CheckOcclusion(cam);
                    }
                }
            }

            if (!_highlighted && !seeThroughReal && !hitActive)
            {
                return;
            }

            if (skipThisFrame == Time.frameCount)
            {
                return;
            }

            if (rms == null) return;

            // Check camera culling mask
            int cullingMask = cam.cullingMask;

            // Ensure renderers are valid and visible (in case LODgroup has changed active renderer)
            if (!ignoreObjectVisibility)
            {
                for (int k = 0; k < rmsCount; k++)
                {
                    if (rms[k].renderer != null && rms[k].renderer.isVisible != rms[k].renderWasVisibleDuringSetup)
                    {
                        SetupMaterial();
                        break;
                    }
                }
            }

            if (fxMatMask == null)
                return;

            // Apply effect
            float glowReal = _highlighted ? this.glow : 0;

            // Check smooth blend ztesting capability
            bool useSmoothGlow = glow > 0 && glowQuality == QualityLevel.Highest;
            bool useSmoothOutline = outline > 0 && outlineQuality == QualityLevel.Highest;
            bool useSmoothBlend = useSmoothGlow || useSmoothOutline;
            if (useSmoothBlend)
            {
                if (useSmoothGlow && useSmoothOutline)
                {
                    outlineVisibility = glowVisibility;
                }
            }
            Visibility smoothGlowVisibility = glowVisibility;
            Visibility smoothOutlineVisibility = outlineVisibility;
            if (useSmoothBlend)
            {
                if (depthClip)
                {
                    cam.depthTextureMode |= DepthTextureMode.Depth;
                }
                if (Application.isMobilePlatform || (cam.allowMSAA && QualitySettings.antiAliasing > 1))
                {
                    smoothGlowVisibility = smoothOutlineVisibility = Visibility.AlwaysOnTop;
                }
                else if (UnityEngine.XR.XRSettings.enabled && Application.isPlaying)
                {
                    smoothGlowVisibility = smoothOutlineVisibility = Visibility.AlwaysOnTop;
                }
            }

            // First create masks
            float camAspect = cam.aspect;
            bool independentFullScreenNotExecuted = true;
            bool somePartVisible = false;

            for (int k = 0; k < rmsCount; k++)
            {
                rms[k].render = false;

                Transform t = rms[k].transform;
                if (t == null)
                    continue;

                Mesh mesh = rms[k].mesh;
                if (mesh == null)
                    continue;

                int layer = t.gameObject.layer;
                if (!ignoreObjectVisibility)
                {
                    if (((1 << layer) & cullingMask) == 0)
                        continue;
                    if (!rms[k].renderer.isVisible)
                        continue;
                }

                rms[k].render = true;
                somePartVisible = true;

                if (rms[k].isCombined)
                {
                    rms[k].renderingMatrix = t.localToWorldMatrix;
                }
                else if (!rms[k].preserveOriginalMesh)
                {
                    Vector3 lossyScale = t.lossyScale;
                    Vector3 position = t.position;
                    if (rms[k].bakedTransform)
                    {
                        if (rms[k].currentPosition != t.position || rms[k].currentRotation != t.eulerAngles || rms[k].currentScale != t.lossyScale)
                        {
                            BakeTransform(k, true);
                        }
                        rms[k].renderingMatrix = matrix4X4Identity;
                    }
                    else
                    {
                        rms[k].renderingMatrix = Matrix4x4.TRS(position, t.rotation, lossyScale);
                    }
                }

                // Outline
                if (outlineIndependent)
                {
                    if (useSmoothBlend)
                    {
                        if (independentFullScreenNotExecuted)
                        {
                            independentFullScreenNotExecuted = false;
                            fxMatClearStencil.SetPass(0);
                            if (subMeshMask > 0)
                            {
                                for (int l = 0; l < mesh.subMeshCount; l++)
                                {
                                    if (((1 << l) & subMeshMask) != 0)
                                    {
                                        Graphics.DrawMeshNow(quadMesh, matrix4X4Identity, l);
                                    }
                                }
                            }
                            else
                            {
                                Graphics.DrawMeshNow(quadMesh, matrix4X4Identity);
                            }
                        }
                    }
                    else if (outline > 0 || glow > 0)
                    {
                        float width = outlineWidth;
                        if (glow > 0)
                        {
                            width = Mathf.Max(width, glowWidth);
                        }
                        Material mat = fxMatOutline;
                        bool usesMultipleOffsets = normalsOption != NormalsOption.Planar && outlineQuality.UsesMultipleOffsets();
                        for (int l = 0; l < mesh.subMeshCount; l++)
                        {
                            if (((1 << l) & subMeshMask) == 0) continue;
                            if (usesMultipleOffsets)
                            {
                                for (int o = outlineOffsetsMin; o <= outlineOffsetsMax; o++)
                                {
                                    Vector3 direction = offsets[o] * (width / 100f);
                                    direction.y *= camAspect;
                                    mat.SetVector(ShaderParams.OutlineDirection, direction);
                                    if (rms[k].preserveOriginalMesh)
                                    {
                                        cbOutline.Clear();
                                        cbOutline.DrawRenderer(rms[k].renderer, mat, l, 1);
                                        Graphics.ExecuteCommandBuffer(cbOutline);
                                    }
                                    else
                                    {
                                        mat.SetPass(1);
                                        Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                                    }
                                }
                            }
                            else
                            {
                                if (rms[k].preserveOriginalMesh)
                                {
                                    cbOutline.Clear();
                                    cbOutline.DrawRenderer(rms[k].renderer, mat, l, 1);
                                    Graphics.ExecuteCommandBuffer(cbOutline);
                                }
                                else
                                {
                                    mat.SetPass(1);
                                    Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                                }
                            }
                        }
                    }
                }
            }

            if (!somePartVisible) return;

            bool renderMaskOnTop = _highlighted && ((outline > 0 && smoothOutlineVisibility != Visibility.Normal) || (glow > 0 && smoothGlowVisibility != Visibility.Normal) || (innerGlow > 0 && innerGlowVisibility != Visibility.Normal));
            if (maskRequired)
            {
                for (int k = 0; k < rmsCount; k++)
                {
                    if (rms[k].render)
                    {
                        RenderMask(k, rms[k].mesh, renderMaskOnTop);
                    }
                }
            }

            // Compute tweening
            float fadeGroup = 1f;
            float fade = 1f;
            if (fading != FadingState.NoFading)
            {
                if (fading == FadingState.FadingIn)
                {
                    if (fadeInDuration > 0)
                    {
                        fadeGroup = (Time.time - fadeStartTime) / fadeInDuration;
                        if (fadeGroup > 1f)
                        {
                            fadeGroup = 1f;
                            fading = FadingState.NoFading;
                        }
                    }
                }
                else if (fadeOutDuration > 0)
                {
                    fadeGroup = 1f - (Time.time - fadeStartTime) / fadeOutDuration;
                    if (fadeGroup < 0f)
                    {
                        fadeGroup = 0f;
                        fading = FadingState.NoFading;
                        _highlighted = false;
                        if (OnObjectHighlightEnd != null)
                        {
                            OnObjectHighlightEnd(gameObject);
                        }
                        SendMessage("HighlightEnd", null, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            if (glowQuality == QualityLevel.High)
            {
                glowReal *= 0.25f;
            }
            else if (glowQuality == QualityLevel.Medium)
            {
                glowReal *= 0.5f;
            }

            int smoothRTWidth = 0;
            int smoothRTHeight = 0;
            Bounds smoothBounds = new Bounds();

            if (useSmoothBlend)
            {
                // Prepare smooth outer glow / outline target
                if (cbSmoothBlend == null)
                {
                    CheckBlurCommandBuffer();
                }
                cbSmoothBlend.Clear();
                smoothRTWidth = cam.pixelWidth;
                smoothRTHeight = cam.pixelHeight;
                if (smoothRTHeight <= 0)
                {
                    smoothRTHeight = 1;
                }
                if (UnityEngine.XR.XRSettings.enabled && Application.isPlaying)
                {
                    sourceDesc = UnityEngine.XR.XRSettings.eyeTextureDesc;
                }
                else
                {
                    sourceDesc = new RenderTextureDescriptor(smoothRTWidth, smoothRTHeight, Application.isMobilePlatform ? RenderTextureFormat.Default : RenderTextureFormat.DefaultHDR);
                    sourceDesc.volumeDepth = 1;
                }
                sourceDesc.msaaSamples = 1;
                sourceDesc.useMipMap = false;
                sourceDesc.depthBufferBits = 0;

                cbSmoothBlend.GetTemporaryRT(sourceRT, sourceDesc, FilterMode.Bilinear);
                RenderTargetIdentifier sourceDestination = new RenderTargetIdentifier(sourceRT, 0, CubemapFace.Unknown, -1);
                if ((glow > 0 && smoothGlowVisibility == Visibility.AlwaysOnTop) || (outline > 0 && smoothOutlineVisibility == Visibility.AlwaysOnTop))
                {
                    cbSmoothBlend.SetRenderTarget(sourceDestination);
                }
                else
                {
                    RenderTargetIdentifier targetDestination = new RenderTargetIdentifier(BuiltinRenderTextureType.CameraTarget, 0, CubemapFace.Unknown, -1);
                    if (Application.isMobilePlatform)
                    {
                        cbSmoothBlend.SetRenderTarget(sourceDestination, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.DontCare, targetDestination, RenderBufferLoadAction.Load, RenderBufferStoreAction.DontCare);
                    }
                    else
                    {
                        cbSmoothBlend.SetRenderTarget(sourceDestination, targetDestination);
                    }
                }
                cbSmoothBlend.ClearRenderTarget(false, true, new Color(0, 0, 0, 0));
            }

            bool targetEffectRendered = false;
            cbSeeThrough.Clear();

            // Add effects
            if (seeThroughReal && renderMaskOnTop)
            {
                for (int k = 0; k < rmsCount; k++)
                {
                    if (!rms[k].render)
                        continue;
                    Mesh mesh = rms[k].mesh;
                    RenderSeeThroughClearStencil(k, mesh);
                }
                for (int k = 0; k < rmsCount; k++)
                {
                    if (!rms[k].render)
                        continue;
                    Mesh mesh = rms[k].mesh;
                    RenderSeeThroughMask(k, mesh);
                }
            }

            for (int k = 0; k < rmsCount; k++)
            {
                if (!rms[k].render)
                    continue;
                Mesh mesh = rms[k].mesh;

                fade = fadeGroup;
                // Distance fade
                if (cameraDistanceFade)
                {
                    fade *= ComputeCameraDistanceFade(rms[k].transform.position, cam.transform);
                }

                // See-Through
                if (seeThroughReal)
                {
                    if (seeThroughDepthOffset > 0)
                    {
                        cam.depthTextureMode |= DepthTextureMode.Depth;
                    }
                    bool usesSeeThroughBorder = (seeThroughBorder * seeThroughBorderWidth) > 0;
                    if (rms[k].preserveOriginalMesh)
                    {
                        for (int l = 0; l < mesh.subMeshCount; l++)
                        {
                            if (((1 << l) & subMeshMask) == 0) continue;
                            if (l < rms[k].fxMatSeeThroughInner.Length && rms[k].fxMatSeeThroughInner[l] != null)
                            {
                                cbSeeThrough.DrawRenderer(rms[k].renderer, rms[k].fxMatSeeThroughInner[l], l);
                                if (usesSeeThroughBorder)
                                {
                                    cbSeeThrough.DrawRenderer(rms[k].renderer, rms[k].fxMatSeeThroughBorder[l], l);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int l = 0; l < mesh.subMeshCount; l++)
                        {
                            if (((1 << l) & subMeshMask) == 0) continue;
                            if (l < rms[k].fxMatSeeThroughInner.Length && rms[k].fxMatSeeThroughInner[l] != null)
                            {
                                cbSeeThrough.DrawMesh(mesh, rms[k].renderingMatrix, rms[k].fxMatSeeThroughInner[l], l);
                                if (usesSeeThroughBorder)
                                {
                                    cbSeeThrough.DrawMesh(mesh, rms[k].renderingMatrix, rms[k].fxMatSeeThroughBorder[l], l);
                                }
                            }
                        }
                    }
                }

                if (_highlighted || hitActive)
                {
                    // Hit FX
                    Color overlayColor = this.overlayColor;
                    float overlayMinIntensity = this.overlayMinIntensity;
                    float overlayBlending = this.overlayBlending;

                    Color innerGlowColorA = this.innerGlowColor;
                    float innerGlow = this.innerGlow;

                    if (hitActive)
                    {
                        overlayColor.a = _highlighted ? overlay : 0;
                        innerGlowColorA.a = _highlighted ? innerGlow : 0;
                        float t = hitFadeOutDuration > 0 ? (Time.time - hitStartTime) / hitFadeOutDuration : 1f;
                        if (t >= 1f)
                        {
                            hitActive = false;
                        }
                        else
                        {
                            if (hitFxMode == HitFxMode.InnerGlow)
                            {
                                bool lerpToCurrentInnerGlow = _highlighted && innerGlow > 0;
                                innerGlowColorA = lerpToCurrentInnerGlow ? Color.Lerp(hitColor, innerGlowColor, t) : hitColor;
                                innerGlowColorA.a = lerpToCurrentInnerGlow ? Mathf.Lerp(1f - t, innerGlow, t) : 1f - t;
                                innerGlowColorA.a *= hitInitialIntensity;
                            }
                            else
                            {
                                bool lerpToCurrentOverlay = _highlighted && overlay > 0;
                                overlayColor = lerpToCurrentOverlay ? Color.Lerp(hitColor, overlayColor, t) : hitColor;
                                overlayColor.a = lerpToCurrentOverlay ? Mathf.Lerp(1f - t, overlay, t) : 1f - t;
                                overlayColor.a *= hitInitialIntensity;
                                overlayMinIntensity = 1f;
                                overlayBlending = 0;
                            }
                        }
                    }
                    else
                    {
                        overlayColor.a = overlay * fade;
                        innerGlowColorA.a = innerGlow * fade;
                    }

                    for (int l = 0; l < mesh.subMeshCount; l++)
                    {
                        if (((1 << l) & subMeshMask) == 0) continue;

                        // Overlay
                        if (overlayColor.a > 0)
                        {
                            Material fxMat = rms[k].fxMatOverlay[l];
                            fxMat.SetColor(ShaderParams.OverlayColor, overlayColor);
                            fxMat.SetVector(ShaderParams.OverlayData, new Vector4(overlayAnimationSpeed, overlayMinIntensity, overlayBlending, overlayTextureScale));
                            if (hitActive && hitFxMode == HitFxMode.LocalHit)
                            {
                                fxMat.SetVector(ShaderParams.OverlayHitPosData, new Vector4(hitPosition.x, hitPosition.y, hitPosition.z, hitRadius));
                                fxMat.SetFloat(ShaderParams.OverlayHitStartTime, hitStartTime);
                            }
                            else
                            {
                                fxMat.SetVector(ShaderParams.OverlayHitPosData, Vector4.zero);
                            }
                            if (rms[k].preserveOriginalMesh)
                            {
                                cbOverlay.Clear();
                                cbOverlay.DrawRenderer(rms[k].renderer, fxMat, l);
                                Graphics.ExecuteCommandBuffer(cbOverlay);
                            }
                            else
                            {
                                fxMat.SetPass(0);
                                Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                            }
                        }

                        // Inner Glow
                        if (innerGlowColorA.a > 0)
                        {
                            rms[k].fxMatInnerGlow[l].SetColor(ShaderParams.InnerGlowColor, innerGlowColorA);

                            if (rms[k].preserveOriginalMesh)
                            {
                                cbInnerGlow.Clear();
                                cbInnerGlow.DrawRenderer(rms[k].renderer, rms[k].fxMatInnerGlow[l], l);
                                Graphics.ExecuteCommandBuffer(cbInnerGlow);
                            }
                            else
                            {
                                rms[k].fxMatInnerGlow[l].SetPass(0);
                                Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                            }
                        }
                    }
                }

                if (!_highlighted)
                    continue;

                if (useSmoothBlend)
                {
                    if (k == 0)
                    {
                        smoothBounds = rms[k].renderer.bounds;
                    }
                    else
                    {
                        smoothBounds.Encapsulate(rms[k].renderer.bounds);
                    }
                }

                for (int l = 0; l < mesh.subMeshCount; l++)
                {
                    if (((1 << l) & subMeshMask) == 0) continue;

                    // Render object body for glow/outline highest quality
                    if (useSmoothBlend)
                    {
                        if (l < rms[k].fxMatSolidColor.Length)
                        {
                            if (rms[k].preserveOriginalMesh)
                            {
                                cbSmoothBlend.DrawRenderer(rms[k].renderer, rms[k].fxMatSolidColor[l], l);
                            }
                            else
                            {
                                cbSmoothBlend.DrawMesh(mesh, rms[k].renderingMatrix, rms[k].fxMatSolidColor[l], l);
                            }
                        }
                    }

                    // Glow
                    if (glow > 0 && glowQuality != QualityLevel.Highest)
                    {
                        matDataGlow.Clear();
                        matDataColor.Clear();
                        matDataDirection.Clear();
                        Material mat = fxMatGlow;
                        Vector4 directionZero = normalsOption == NormalsOption.Planar ? new Vector4(0, 0, glowWidth / 100f, 0) : Vector4.zero;
                        mat.SetVector(ShaderParams.GlowDirection, directionZero);
                        for (int j = 0; j < glowPasses.Length; j++)
                        {
                            Color dataColor = glowPasses[j].color;
                            mat.SetColor(ShaderParams.GlowColor, dataColor);
                            Vector4 dataGlow = new Vector4(fade * glowReal * glowPasses[j].alpha, normalsOption == NormalsOption.Planar ? 0 : glowPasses[j].offset * glowWidth / 100f, glowMagicNumber1, glowMagicNumber2);
                            mat.SetVector(ShaderParams.Glow, dataGlow);
                            if (normalsOption != NormalsOption.Planar && glowQuality.UsesMultipleOffsets())
                            {
                                for (int o = glowOffsetsMin; o <= glowOffsetsMax; o++)
                                {
                                    Vector4 direction = offsets[o];
                                    direction.y *= camAspect;
                                    mat.SetVector(ShaderParams.GlowDirection, direction);
                                    if (rms[k].preserveOriginalMesh)
                                    {
                                        cbGlow.Clear();
                                        cbGlow.DrawRenderer(rms[k].renderer, mat, l);
                                        Graphics.ExecuteCommandBuffer(cbGlow);
                                    }
                                    else
                                    {
                                        if (useGPUInstancing)
                                        {
                                            matDataDirection.Add(direction);
                                            matDataGlow.Add(dataGlow);
                                            matDataColor.Add(new Vector4(dataColor.r, dataColor.g, dataColor.b, dataColor.a));
                                        }
                                        else
                                        {
                                            mat.SetPass(0);
                                            Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (rms[k].preserveOriginalMesh)
                                {
                                    cbGlow.Clear();
                                    cbGlow.DrawRenderer(rms[k].renderer, mat, l);
                                    Graphics.ExecuteCommandBuffer(cbGlow);
                                }
                                else
                                {
                                    if (useGPUInstancing)
                                    {
                                        matDataDirection.Add(directionZero);
                                        matDataGlow.Add(dataGlow);
                                        matDataColor.Add(new Vector4(dataColor.r, dataColor.g, dataColor.b, dataColor.a));
                                    }
                                    else
                                    {
                                        mat.SetPass(0);
                                        Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                                    }
                                }
                            }
                        }
                        if (useGPUInstancing)
                        {
                            int instanceCount = matDataDirection.Count;
                            if (instanceCount > 0)
                            {
                                glowPropertyBlock.Clear();
                                glowPropertyBlock.SetVectorArray(ShaderParams.GlowDirection, matDataDirection);
                                glowPropertyBlock.SetVectorArray(ShaderParams.GlowColor, matDataColor);
                                glowPropertyBlock.SetVectorArray(ShaderParams.Glow, matDataGlow);
                                if (matrices == null || matrices.Length < instanceCount)
                                {
                                    matrices = new Matrix4x4[instanceCount];
                                }
                                for (int m = 0; m < instanceCount; m++)
                                {
                                    matrices[m] = rms[k].renderingMatrix;
                                }
                                cbGlow.Clear();
                                cbGlow.DrawMeshInstanced(mesh, l, mat, 0, matrices, instanceCount, glowPropertyBlock);
                                Graphics.ExecuteCommandBuffer(cbGlow);
                            }
                        }
                    }

                    // Outline
                    if (outline > 0 && outlineQuality != QualityLevel.Highest)
                    {
                        Color outlineColor = this.outlineColor;
                        outlineColor.a = outline * fade;
                        Material mat = fxMatOutline;
                        mat.SetColor(ShaderParams.OutlineColor, outlineColor);
                        if (normalsOption != NormalsOption.Planar && outlineQuality.UsesMultipleOffsets())
                        {
                            matDataDirection.Clear();
                            for (int o = outlineOffsetsMin; o <= outlineOffsetsMax; o++)
                            {
                                Vector4 direction = offsets[o] * (outlineWidth / 100f);
                                direction.y *= camAspect;
                                mat.SetVector(ShaderParams.OutlineDirection, direction);
                                if (rms[k].preserveOriginalMesh)
                                {
                                    cbOutline.Clear();
                                    cbOutline.DrawRenderer(rms[k].renderer, mat, l, 0);
                                    Graphics.ExecuteCommandBuffer(cbOutline);
                                }
                                else
                                {
                                    if (useGPUInstancing)
                                    {
                                        matDataDirection.Add(direction);
                                    }
                                    else
                                    {
                                        mat.SetPass(0);
                                        Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                                    }
                                }
                            }
                            if (useGPUInstancing)
                            {
                                int instanceCount = matDataDirection.Count;
                                if (instanceCount > 0)
                                {
                                    outlinePropertyBlock.Clear();
                                    outlinePropertyBlock.SetVectorArray(ShaderParams.OutlineDirection, matDataDirection);
                                    if (matrices == null || matrices.Length < instanceCount)
                                    {
                                        matrices = new Matrix4x4[instanceCount];
                                    }
                                    for (int m = 0; m < instanceCount; m++)
                                    {
                                        matrices[m] = rms[k].renderingMatrix;
                                    }
                                    cbGlow.Clear(); // we reuse the same commandbuffer for glow
                                    cbGlow.DrawMeshInstanced(mesh, l, mat, 0, matrices, instanceCount, outlinePropertyBlock);
                                    Graphics.ExecuteCommandBuffer(cbGlow);
                                }
                            }
                        }
                        else
                        {
                            if (rms[k].preserveOriginalMesh)
                            {
                                cbOutline.Clear();
                                cbOutline.DrawRenderer(rms[k].renderer, mat, l, 0);
                                Graphics.ExecuteCommandBuffer(cbOutline);
                            }
                            else
                            {
                                mat.SetPass(0);
                                Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                            }
                        }
                    }
                }

                // Target
                if (targetFX)
                {
                    float fadeOut = 1f;
                    if (targetFXStayDuration > 0 && Application.isPlaying)
                    {
                        fadeOut = (Time.time - targetFxStartTime);
                        if (fadeOut >= targetFXStayDuration)
                        {
                            fadeOut -= targetFXStayDuration;
                            fadeOut = 1f - fadeOut;
                        }
                        if (fadeOut > 1f)
                        {
                            fadeOut = 1f;
                        }
                    }
                    bool usesTarget = targetFXCenter != null;
                    if (fadeOut > 0 && !(targetEffectRendered && usesTarget))
                    {
                        targetEffectRendered = true;
                        float scaleT = 1f;
                        float time;
                        float normalizedTime = 0;
                        if (Application.isPlaying)
                        {
                            normalizedTime = (Time.time - targetFxStartTime) / targetFXTransitionDuration;
                            if (normalizedTime > 1f)
                            {
                                normalizedTime = 1f;
                            }
                            scaleT = Mathf.Sin(normalizedTime * Cheetah.Math.Mathf.PI * 0.5f);
                            time = Time.time;
                        }
                        else
                        {
                            time = (float)DateTime.Now.Subtract(DateTime.Today).TotalSeconds;
                        }

                        Bounds bounds = rms[k].renderer.bounds;
                        if (!targetFXScaleToRenderBounds)
                        {
                            bounds.size = Vector3.one;
                        }
                        Vector3 scale = bounds.size;
                        float minSize = scale.x;
                        if (scale.y < minSize)
                        {
                            minSize = scale.y;
                        }
                        if (scale.z < minSize)
                        {
                            minSize = scale.z;
                        }
                        scale.x = scale.y = scale.z = minSize;
                        scale = Vector3.Lerp(scale * targetFXInitialScale, scale * targetFXEndScale, scaleT);
                        Vector3 center = usesTarget ? targetFXCenter.transform.position : bounds.center;
                        Quaternion rotation;
                        if (targetFXAlignToGround)
                        {
                            rotation = Quaternion.Euler(90, 0, 0);
                            center.y += 0.5f; // a bit of offset in case it's in contact with ground
                            if (Physics.Raycast(center, Vector3.down, out RaycastHit groundHitInfo, targetFXGroundMaxDistance, targetFXGroundLayerMask))
                            {
                                center = groundHitInfo.point;
                                center.y += 0.01f;
                                Vector4 renderData = groundHitInfo.normal;
                                renderData.w = targetFXFadePower;
                                fxMatTarget.SetVector(ShaderParams.TargetFXRenderData, renderData);
                                rotation = Quaternion.Euler(0, time * targetFXRotationSpeed, 0);
                                if (OnTargetAnimates != null)
                                {
                                    OnTargetAnimates(ref center, ref rotation, ref scale, normalizedTime);
                                }
                                Matrix4x4 m = Matrix4x4.TRS(center, rotation, scale);
                                Color color = targetFXColor;
                                color.a *= fade * fadeOut;
                                Material mat = fxMatTarget;
                                mat.color = color;
                                mat.SetPass(0);
                                Graphics.DrawMeshNow(cubeMesh, m);
                            }
                        }
                        else
                        {
                            rotation = Quaternion.LookRotation(cam.transform.position - rms[k].transform.position);
                            Quaternion animationRot = Quaternion.Euler(0, 0, time * targetFXRotationSpeed);
                            rotation *= animationRot;
                            if (OnTargetAnimates != null)
                            {
                                OnTargetAnimates(ref center, ref rotation, ref scale, normalizedTime);
                            }
                            Matrix4x4 m = Matrix4x4.TRS(center, rotation, scale);
                            Color color = targetFXColor;
                            color.a *= fade * fadeOut;
                            Material mat = fxMatTarget;
                            mat.color = color;
                            mat.SetPass(1);
                            Graphics.DrawMeshNow(quadMesh, m);
                        }
                    }
                }
            }

            if (useSmoothBlend)
            {
                if (ComputeSmoothQuadMatrix(cam, smoothBounds))
                {
                    // Smooth Glow
                    if (useSmoothGlow)
                    {
                        float intensity = glow * fade;
                        fxMatComposeGlow.color = new Color(glowHQColor.r * intensity, glowHQColor.g * intensity, glowHQColor.b * intensity, glowHQColor.a * intensity);
                        SmoothGlow(smoothRTWidth / glowDownsampling, smoothRTHeight / glowDownsampling);
                    }

                    // Smooth Outline
                    if (useSmoothOutline)
                    {
                        fxMatComposeOutline.color = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 5f * outlineColor.a * outline * fade);
                        SmoothOutline(smoothRTWidth / outlineDownsampling, smoothRTHeight / outlineDownsampling);
                    }

                    // Bit result
                    ComposeSmoothBlend(smoothGlowVisibility, smoothOutlineVisibility);
                }
            }

            if (seeThroughReal && seeThroughOrdered)
            { // Ordered for see-through
                for (int k = 0; k < rmsCount; k++)
                {
                    if (!rms[k].render)
                        continue;
                    Mesh mesh = rms[k].mesh;
                    for (int l = 0; l < mesh.subMeshCount; l++)
                    {
                        if (((1 << l) & subMeshMask) == 0) continue;
                        if (rms[k].isCombined)
                        {
                            cbSeeThrough.DrawMesh(mesh, rms[k].renderingMatrix, fxMatClearStencil, l, 1);
                        }
                        else
                        {
                            cbSeeThrough.DrawRenderer(rms[k].renderer, fxMatClearStencil, l, 1);
                        }
                    }
                }
            }

            Graphics.ExecuteCommandBuffer(cbSeeThrough);
        }

        private void RenderMask(int k, Mesh mesh, bool alwaysOnTop)
        {
            if (rms[k].preserveOriginalMesh)
            {
                cbMask.Clear();
                for (int l = 0; l < mesh.subMeshCount; l++)
                {
                    if (((1 << l) & subMeshMask) == 0) continue;
                    if (alwaysOnTop)
                    {
                        rms[k].fxMatMask[l].SetInt(ShaderParams.ZTest, (int)CompareFunction.Always);
                    }
                    else
                    {
                        rms[k].fxMatMask[l].SetInt(ShaderParams.ZTest, (int)CompareFunction.LessEqual);
                    }
                    cbMask.DrawRenderer(rms[k].renderer, rms[k].fxMatMask[l], l, 0);
                }
                Graphics.ExecuteCommandBuffer(cbMask);
            }
            else
            {
                for (int l = 0; l < mesh.subMeshCount; l++)
                {
                    if (((1 << l) & subMeshMask) == 0) continue;
                    if (alwaysOnTop)
                    {
                        rms[k].fxMatMask[l].SetInt(ShaderParams.ZTest, (int)CompareFunction.Always);
                    }
                    else
                    {
                        rms[k].fxMatMask[l].SetInt(ShaderParams.ZTest, (int)CompareFunction.LessEqual);
                    }
                    rms[k].fxMatMask[l].SetPass(0);
                    Graphics.DrawMeshNow(mesh, rms[k].renderingMatrix, l);
                }
            }
        }

        private void RenderSeeThroughClearStencil(int k, Mesh mesh)
        {
            if (rms[k].preserveOriginalMesh)
            {
                for (int l = 0; l < mesh.subMeshCount; l++)
                {
                    if (((1 << l) & subMeshMask) == 0) continue;
                    cbSeeThrough.DrawRenderer(rms[k].renderer, fxMatClearStencil, l, 1);
                }
            }
            else
            {
                for (int l = 0; l < mesh.subMeshCount; l++)
                {
                    if (((1 << l) & subMeshMask) == 0) continue;
                    cbSeeThrough.DrawMesh(mesh, rms[k].renderingMatrix, fxMatClearStencil, l, 1);
                }
            }
        }

        private void RenderSeeThroughMask(int k, Mesh mesh)
        {
            if (rms[k].preserveOriginalMesh)
            {
                for (int l = 0; l < mesh.subMeshCount; l++)
                {
                    if (((1 << l) & subMeshMask) == 0) continue;
                    cbSeeThrough.DrawRenderer(rms[k].renderer, rms[k].fxMatMask[l], l, 1);
                }
            }
            else
            {
                for (int l = 0; l < mesh.subMeshCount; l++)
                {
                    if (((1 << l) & subMeshMask) == 0) continue;
                    cbSeeThrough.DrawMesh(mesh, rms[k].renderingMatrix, rms[k].fxMatMask[l], l, 1);
                }
            }
        }

        private bool ComputeSmoothQuadMatrix(Camera cam, Bounds bounds)
        {
            // Compute bounds in screen space and enlarge for glow space
            Vector3 min = bounds.min;
            Vector3 max = bounds.max;
            corners[0] = new Vector3(min.x, min.y, min.z);
            corners[1] = new Vector3(min.x, min.y, max.z);
            corners[2] = new Vector3(max.x, min.y, min.z);
            corners[3] = new Vector3(max.x, min.y, max.z);
            corners[4] = new Vector3(min.x, max.y, min.z);
            corners[5] = new Vector3(min.x, max.y, max.z);
            corners[6] = new Vector3(max.x, max.y, min.z);
            corners[7] = new Vector3(max.x, max.y, max.z);
            Vector3 scrMin = new Vector3(float.MaxValue, float.MaxValue, 0);
            Vector3 scrMax = new Vector3(float.MinValue, float.MinValue, 0);
            float distance = float.MaxValue;
            for (int k = 0; k < corners.Length; k++)
            {
                corners[k] = cam.WorldToScreenPoint(corners[k]);
                if (corners[k].x < scrMin.x)
                {
                    scrMin.x = corners[k].x;
                }
                if (corners[k].y < scrMin.y)
                {
                    scrMin.y = corners[k].y;
                }
                if (corners[k].x > scrMax.x)
                {
                    scrMax.x = corners[k].x;
                }
                if (corners[k].y > scrMax.y)
                {
                    scrMax.y = corners[k].y;
                }
                if (corners[k].z < distance)
                {
                    distance = corners[k].z;
                    if (distance < cam.nearClipPlane)
                    {
                        scrMin.x = scrMin.y = 0;
                        scrMax.x = cam.pixelWidth;
                        scrMax.y = cam.pixelHeight;
                        break;
                    }
                }
            }
            if (scrMax.y == scrMin.y)
                return false;

            if (distance < cam.nearClipPlane)
            {
                distance = cam.nearClipPlane + 0.01f;
            }
            scrMin.z = scrMax.z = distance;
            if (outline > 0)
            {
                BuildMatrix(cam, scrMin, scrMax, (int)(10 + 20 * outlineWidth + 5 * outlineDownsampling), ref quadOutlineMatrix);
            }
            if (glow > 0)
            {
                BuildMatrix(cam, scrMin, scrMax, (int)(20 + 30 * glowWidth + 10 * glowDownsampling), ref quadGlowMatrix);
            }
            return true;
        }

        private void BuildMatrix(Camera cam, Vector3 scrMin, Vector3 scrMax, int border, ref Matrix4x4 quadMatrix)
        {
            // Insert padding to make room for effects
            scrMin.x -= border;
            scrMin.y -= border;
            scrMax.x += border;
            scrMax.y += border;

            // Back to world space
            Vector3 third = new Vector3(scrMax.x, scrMin.y, scrMin.z);
            scrMin = cam.ScreenToWorldPoint(scrMin);
            scrMax = cam.ScreenToWorldPoint(scrMax);
            third = cam.ScreenToWorldPoint(third);

            float width = Vector3.Distance(scrMin, third);
            float height = Vector3.Distance(scrMax, third);

            quadMatrix = Matrix4x4.TRS((scrMin + scrMax) * 0.5f, cam.transform.rotation, new Vector3(width, height, 1f));
        }

        private void SmoothGlow(int rtWidth, int rtHeight)
        {
            const int blurPasses = 4;

            // Blur buffers
            int bufferCount = blurPasses * 2;
            if (mipGlowBuffers == null || mipGlowBuffers.Length != bufferCount)
            {
                mipGlowBuffers = new int[bufferCount];
                for (int k = 0; k < bufferCount; k++)
                {
                    mipGlowBuffers[k] = Shader.PropertyToID("_HPSmoothGlowTemp" + k);
                }
                glowRT = Shader.PropertyToID("_HPComposeGlowFinal");
                mipGlowBuffers[bufferCount - 2] = glowRT;
            }
            RenderTextureDescriptor glowDesc = sourceDesc;
            glowDesc.depthBufferBits = 0;

            for (int k = 0; k < bufferCount; k++)
            {
                float reduction = k / 2 + 2;
                int reducedWidth = (int)(rtWidth / reduction);
                int reducedHeight = (int)(rtHeight / reduction);
                if (reducedWidth <= 0)
                {
                    reducedWidth = 1;
                }
                if (reducedHeight <= 0)
                {
                    reducedHeight = 1;
                }
                glowDesc.width = reducedWidth;
                glowDesc.height = reducedHeight;
                cbSmoothBlend.GetTemporaryRT(mipGlowBuffers[k], glowDesc, FilterMode.Bilinear);
            }

            Material matBlur = fxMatBlurGlow;

            for (int k = 0; k < bufferCount - 1; k += 2)
            {
                if (k == 0)
                {
                    cbSmoothBlend.Blit(sourceRT, mipGlowBuffers[k + 1], matBlur, 0);
                }
                else
                {
                    cbSmoothBlend.Blit(mipGlowBuffers[k], mipGlowBuffers[k + 1], matBlur, 0);
                }
                cbSmoothBlend.Blit(mipGlowBuffers[k + 1], mipGlowBuffers[k], matBlur, 1);

                if (k < bufferCount - 2)
                {
                    cbSmoothBlend.Blit(mipGlowBuffers[k], mipGlowBuffers[k + 2], matBlur, 2);
                }
            }
        }

        private void SmoothOutline(int rtWidth, int rtHeight)
        {
            const int blurPasses = 2;

            // Blur buffers
            int bufferCount = blurPasses * 2;
            if (mipOutlineBuffers == null || mipOutlineBuffers.Length != bufferCount)
            {
                mipOutlineBuffers = new int[bufferCount];
                for (int k = 0; k < bufferCount; k++)
                {
                    mipOutlineBuffers[k] = Shader.PropertyToID("_HPSmoothOutlineTemp" + k);
                }
                outlineRT = Shader.PropertyToID("_HPComposeOutlineFinal");
                mipOutlineBuffers[bufferCount - 2] = outlineRT;
            }
            RenderTextureDescriptor outlineDesc = sourceDesc;
            outlineDesc.depthBufferBits = 0;

            for (int k = 0; k < bufferCount; k++)
            {
                float reduction = k / 2 + 2;
                int reducedWidth = (int)(rtWidth / reduction);
                int reducedHeight = (int)(rtHeight / reduction);
                if (reducedWidth <= 0)
                {
                    reducedWidth = 1;
                }
                if (reducedHeight <= 0)
                {
                    reducedHeight = 1;
                }
                outlineDesc.width = reducedWidth;
                outlineDesc.height = reducedHeight;
                cbSmoothBlend.GetTemporaryRT(mipOutlineBuffers[k], outlineDesc, FilterMode.Bilinear);
            }

            Material matBlur = fxMatBlurOutline;
            for (int k = 0; k < bufferCount - 1; k += 2)
            {
                if (k == 0)
                {
                    cbSmoothBlend.Blit(sourceRT, mipOutlineBuffers[k + 1], matBlur, 0);
                }
                else
                {
                    cbSmoothBlend.Blit(mipOutlineBuffers[k], mipOutlineBuffers[k + 1], matBlur, 0);
                }
                cbSmoothBlend.Blit(mipOutlineBuffers[k + 1], mipOutlineBuffers[k], matBlur, 1);

                if (k < bufferCount - 2)
                {
                    cbSmoothBlend.Blit(mipOutlineBuffers[k], mipOutlineBuffers[k + 2], matBlur, 2);
                }
            }
        }

        private void ComposeSmoothBlend(Visibility smoothGlowVisibility, Visibility smoothOutlineVisibility)
        {
            bool renderSmoothGlow = glow > 0 && glowQuality == QualityLevel.Highest;
            RenderTargetIdentifier cameraTargetDestination = new RenderTargetIdentifier(BuiltinRenderTextureType.CameraTarget, 0, CubemapFace.Unknown, -1);
            if (renderSmoothGlow)
            {
                Material matComposeGlow = fxMatComposeGlow;
                matComposeGlow.SetVector(ShaderParams.Flip, (UnityEngine.XR.XRSettings.enabled && flipY) ? new Vector3(1, -1, 0) : new Vector3(0, 1, 0));
                if (glowOptimalBlit)
                {
                    if (Application.isMobilePlatform && smoothGlowVisibility != Visibility.AlwaysOnTop)
                    {
                        cbSmoothBlend.SetRenderTarget(cameraTargetDestination, RenderBufferLoadAction.Load, RenderBufferStoreAction.DontCare);
                    }
                    else
                    {
                        cbSmoothBlend.SetRenderTarget(cameraTargetDestination);
                    }
                    matComposeGlow.SetInt(ShaderParams.ZTest, GetZTestValue(smoothGlowVisibility));
                    matComposeGlow.SetColor(ShaderParams.Debug, glowBlitDebug ? debugColor : blackColor);
                    cbSmoothBlend.DrawMesh(quadMesh, quadGlowMatrix, matComposeGlow, 0, 0);
                }
                else
                {
                    cbSmoothBlend.Blit(glowRT, cameraTargetDestination, matComposeGlow, 1);
                }
            }
            bool renderSmoothOutline = outline > 0 && outlineQuality == QualityLevel.Highest;
            if (renderSmoothOutline)
            {
                Material matComposeOutline = fxMatComposeOutline;
                matComposeOutline.SetVector(ShaderParams.Flip, (UnityEngine.XR.XRSettings.enabled && flipY) ? new Vector3(1, -1, 0) : new Vector3(0, 1, 0));
                Log.Debug(Camera.current.name + " " + smoothOutlineVisibility);
                if (outlineOptimalBlit)
                {
                    if (Application.isMobilePlatform && smoothOutlineVisibility != Visibility.AlwaysOnTop)
                    {
                        cbSmoothBlend.SetRenderTarget(cameraTargetDestination, RenderBufferLoadAction.Load, RenderBufferStoreAction.DontCare);
                    }
                    else
                    {
                        cbSmoothBlend.SetRenderTarget(cameraTargetDestination);
                    }
                    matComposeOutline.SetInt(ShaderParams.ZTest, GetZTestValue(smoothOutlineVisibility));
                    matComposeOutline.SetColor(ShaderParams.Debug, outlineBlitDebug ? debugColor : blackColor);
                    cbSmoothBlend.DrawMesh(quadMesh, quadOutlineMatrix, matComposeOutline, 0, 0);
                }
                else
                {
                    cbSmoothBlend.Blit(outlineRT, cameraTargetDestination, matComposeOutline, 1);
                }
            }
            // Release render textures
            if (renderSmoothGlow)
            {
                for (int k = 0; k < mipGlowBuffers.Length; k++)
                {
                    cbSmoothBlend.ReleaseTemporaryRT(mipGlowBuffers[k]);
                }
            }
            if (renderSmoothOutline)
            {
                for (int k = 0; k < mipOutlineBuffers.Length; k++)
                {
                    cbSmoothBlend.ReleaseTemporaryRT(mipOutlineBuffers[k]);
                }
            }

            cbSmoothBlend.ReleaseTemporaryRT(sourceRT);

            Graphics.ExecuteCommandBuffer(cbSmoothBlend);
        }

        private void InitMaterial(ref Material material, string shaderName)
        {
            if (material == null)
            {
                // check first if shader is in ClientResources.shaders
                var shaderFX = ClientResources.Loaders.Shaders.LoadedShaders.Find(s => s.name == shaderName);
                if(shaderFX == null)
                {
                    shaderFX = Shader.Find(shaderName);
                }

                if (shaderFX == null)
                {
                    Log.Debug("Shader " + shaderName + " not found.");
                    enabled = false;
                    return;
                }
                material = new Material(shaderFX);
            }
        }

        /// <summary>
        /// Sets target for highlight effects
        /// </summary>
        internal void SetTarget(Transform transform)
        {
            if (transform == target || transform == null)
                return;

            if (_highlighted)
            {
                ImmediateFadeOut();
            }

            target = transform;
            SetupMaterial();
        }

        /// <summary>
        /// Sets target for highlight effects and also specify a list of renderers to be included as well
        /// </summary>
        internal void SetTargets(Transform transform, Renderer[] renderers)
        {
            if (transform == null)
                return;

            if (_highlighted)
            {
                ImmediateFadeOut();
            }

            effectGroup = TargetOptions.Scripting;
            target = transform;
            SetupMaterial(renderers);
        }

        /// <summary>
        /// Start or finish highlight on the object
        /// </summary>
        internal void SetHighlighted(bool state)
        {
            if (!Application.isPlaying)
            {
                _highlighted = state;
                return;
            }

            float now = Time.time;

            if (fading == FadingState.NoFading)
            {
                fadeStartTime = now;
            }

            if (state && !ignore)
            {
                if (_highlighted && fading == FadingState.NoFading)
                {
                    return;
                }
                if (OnObjectHighlightStart != null)
                {
                    if (!OnObjectHighlightStart(gameObject))
                    {
                        return;
                    }
                }
                SendMessage("HighlightStart", null, SendMessageOptions.DontRequireReceiver);
                highlightStartTime = targetFxStartTime = now;
                if (fadeInDuration > 0)
                {
                    if (fading == FadingState.FadingOut)
                    {
                        float remaining = fadeOutDuration - (now - fadeStartTime);
                        fadeStartTime = now - remaining;
                        fadeStartTime = Mathf.Min(fadeStartTime, now);
                    }
                    fading = FadingState.FadingIn;
                }
                else
                {
                    fading = FadingState.NoFading;
                }
                _highlighted = true;
                requireUpdateMaterial = true;
            }
            else if (_highlighted)
            {
                if (fadeOutDuration > 0)
                {
                    if (fading == FadingState.FadingIn)
                    {
                        float elapsed = now - fadeStartTime;
                        fadeStartTime = now + elapsed - fadeInDuration;
                        fadeStartTime = Mathf.Min(fadeStartTime, now);
                    }
                    fading = FadingState.FadingOut; // when fade out ends, highlighted will be set to false in OnRenderObject
                }
                else
                {
                    fading = FadingState.NoFading;
                    ImmediateFadeOut();
                    requireUpdateMaterial = true;
                }
            }
        }

        private void ImmediateFadeOut()
        {
            fading = FadingState.NoFading;
            _highlighted = false;
            if (OnObjectHighlightEnd != null)
            {
                OnObjectHighlightEnd(gameObject);
            }
            SendMessage("HighlightEnd", null, SendMessageOptions.DontRequireReceiver);
        }

        private void SetupMaterial()
        {
            if (target == null || fxMatMask == null)
                return;

            Renderer[] rr = null;
            switch (effectGroup)
            {
                case TargetOptions.OnlyThisObject:
                    Renderer renderer = target.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        rr = new Renderer[1];
                        rr[0] = renderer;
                    }
                    break;

                case TargetOptions.RootToChildren:
                    Transform root = target;
                    while (root.parent != null)
                    {
                        root = root.parent;
                    }
                    rr = root.GetComponentsInChildren<Renderer>();
                    break;

                case TargetOptions.LayerInScene:
                    {
                        HighlightEffect eg = this;
                        if (target != transform)
                        {
                            HighlightEffect targetEffect = target.GetComponent<HighlightEffect>();
                            if (targetEffect != null)
                            {
                                eg = targetEffect;
                            }
                        }
                        rr = FindRenderersWithLayerInScene(eg.effectGroupLayer);
                    }
                    break;

                case TargetOptions.LayerInChildren:
                    {
                        HighlightEffect eg = this;
                        if (target != transform)
                        {
                            HighlightEffect targetEffect = target.GetComponent<HighlightEffect>();
                            if (targetEffect != null)
                            {
                                eg = targetEffect;
                            }
                        }
                        rr = FindRenderersWithLayerInChildren(eg.effectGroupLayer);
                    }
                    break;

                case TargetOptions.Children:
                    rr = target.GetComponentsInChildren<Renderer>();
                    break;

                case TargetOptions.Scripting:
                    if (rmsCount > 0) return;
                    return;
            }

            SetupMaterial(rr);
        }

        private void SetupMaterial(Renderer[] rr)
        {
            if (rr == null)
            {
                rr = new Renderer[0];
            }
            if (rms == null || rms.Length < rr.Length)
            {
                rms = new ModelMaterials[rr.Length];
            }

            rmsCount = 0;
            for (int k = 0; k < rr.Length; k++)
            {
                rms[rmsCount].Init();
                Renderer renderer = rr[k];
                if (effectGroup != TargetOptions.OnlyThisObject && !string.IsNullOrEmpty(effectNameFilter))
                {
                    if (!renderer.name.Contains(effectNameFilter)) continue;
                }
                rms[rmsCount].renderer = renderer;
                rms[rmsCount].renderWasVisibleDuringSetup = renderer.isVisible;

                if (renderer.transform != target)
                {
                    HighlightEffect otherEffect = renderer.GetComponent<HighlightEffect>();
                    if (otherEffect != null && otherEffect.enabled)
                    {
                        continue; // independent subobject
                    }
                }

                if (OnRendererHighlightStart != null)
                {
                    if (!OnRendererHighlightStart(renderer))
                    {
                        rmsCount++;
                        continue;
                    }
                }

                rms[rmsCount].isCombined = false;
                bool isSkinnedMesh = renderer is SkinnedMeshRenderer;
                rms[rmsCount].isSkinnedMesh = isSkinnedMesh;
                rms[rmsCount].normalsOption = isSkinnedMesh ? NormalsOption.PreserveOriginal : normalsOption;
                if (rms[rmsCount].preserveOriginalMesh || combineMeshes)
                {
                    CheckCommandBuffers();
                }
                if (isSkinnedMesh)
                {
                    // ignore cloth skinned renderers
                    rms[rmsCount].mesh = ((SkinnedMeshRenderer)renderer).sharedMesh;
                }
                else if (Application.isPlaying && renderer.isPartOfStaticBatch)
                {
                    // static batched objects need to have a mesh collider in order to use its original mesh
                    MeshCollider mc = renderer.GetComponent<MeshCollider>();
                    if (mc != null)
                    {
                        rms[rmsCount].mesh = mc.sharedMesh;
                    }
                }
                else
                {
                    MeshFilter mf = renderer.GetComponent<MeshFilter>();
                    if (mf != null)
                    {
                        rms[rmsCount].mesh = mf.sharedMesh;

#if UNITY_EDITOR
                        if (renderer.gameObject.isStatic && renderer.GetComponent<MeshCollider>() == null) {
                            staticChildren = true;
                        }
#endif
                    }
                }

                if (rms[rmsCount].mesh == null)
                {
                    continue;
                }

                rms[rmsCount].transform = renderer.transform;
                Fork(fxMatMask, ref rms[rmsCount].fxMatMask, rms[rmsCount].mesh);
                Fork(fxMatSeeThroughInner, ref rms[rmsCount].fxMatSeeThroughInner, rms[rmsCount].mesh);
                Fork(fxMatSeeThroughBorder, ref rms[rmsCount].fxMatSeeThroughBorder, rms[rmsCount].mesh);
                Fork(fxMatOverlay, ref rms[rmsCount].fxMatOverlay, rms[rmsCount].mesh);
                Fork(fxMatInnerGlow, ref rms[rmsCount].fxMatInnerGlow, rms[rmsCount].mesh);
                Fork(fxMatSolidColor, ref rms[rmsCount].fxMatSolidColor, rms[rmsCount].mesh);
                rms[rmsCount].originalMesh = rms[rmsCount].mesh;
                if (!rms[rmsCount].preserveOriginalMesh)
                {
                    if (innerGlow > 0 || (glow > 0 && glowQuality != QualityLevel.Highest) || (outline > 0 && outlineQuality != QualityLevel.Highest))
                    {
                        if (normalsOption == NormalsOption.Reorient || normalsOption == NormalsOption.Planar)
                        {
                            ReorientNormals(rmsCount);
                        }
                        else
                        {
                            AverageNormals(rmsCount);
                        }
                    }
                    // check if scale is negative
                    BakeTransform(rmsCount, true);
                }
                rmsCount++;
            }

#if UNITY_EDITOR
            // Avoids command buffer issue when refreshing asset inside the Editor
            if (!Application.isPlaying) {
                mipGlowBuffers = null;
                mipOutlineBuffers = null;
            }
#endif

            if (combineMeshes)
            {
                CombineMeshes();
            }

            UpdateMaterialPropertiesNow();
        }


        private Renderer[] FindRenderersWithLayerInScene(LayerMask layer)
        {
            Renderer[] rr = FindObjectsOfType<Renderer>();
            if (tempRR == null)
            {
                tempRR = new();
            }
            else
            {
                tempRR.Clear();
            }
            for (var i = 0; i < rr.Length; i++)
            {
                Renderer r = rr[i];
                if (((1 << r.gameObject.layer) & layer) != 0)
                {
                    tempRR.Add(r);
                }
            }
            return tempRR.ToArray();
        }

        private Renderer[] FindRenderersWithLayerInChildren(LayerMask layer)
        {
            Renderer[] rr = target.GetComponentsInChildren<Renderer>();
            if (tempRR == null)
            {
                tempRR = new();
            }
            else
            {
                tempRR.Clear();
            }
            for (var i = 0; i < rr.Length; i++)
            {
                Renderer r = rr[i];
                if (((1 << r.gameObject.layer) & layer) != 0)
                {
                    tempRR.Add(r);
                }
            }
            return tempRR.ToArray();
        }

        private void CheckGeometrySupportDependencies()
        {
            InitMaterial(ref fxMatMask, "HighlightPlus/Geometry/Mask");
            InitMaterial(ref fxMatOverlay, "HighlightPlus/Geometry/Overlay");
            InitMaterial(ref fxMatSeeThroughInner, "HighlightPlus/Geometry/SeeThroughInner");
            InitMaterial(ref fxMatSeeThroughBorder, "HighlightPlus/Geometry/SeeThroughBorder");
            InitMaterial(ref fxMatSeeThroughMask, "HighlightPlus/Geometry/SeeThroughMask");
            InitMaterial(ref fxMatSolidColor, "HighlightPlus/Geometry/SolidColor");
            InitMaterial(ref fxMatClearStencil, "HighlightPlus/ClearStencil");
            InitMaterial(ref fxMatOutlineRef, "HighlightPlus/Geometry/Outline");
            InitMaterial(ref fxMatGlowRef, "HighlightPlus/Geometry/Glow");
            InitMaterial(ref fxMatInnerGlow, "HighlightPlus/Geometry/InnerGlow");
            InitMaterial(ref fxMatTargetRef, "HighlightPlus/Geometry/Target");
            InitMaterial(ref fxMatComposeOutlineRef, "HighlightPlus/Geometry/ComposeOutline");
            InitMaterial(ref fxMatComposeGlowRef, "HighlightPlus/Geometry/ComposeGlow");
            InitMaterial(ref fxMatBlurOutlineRef, "HighlightPlus/Geometry/BlurOutline");
            InitMaterial(ref fxMatBlurGlowRef, "HighlightPlus/Geometry/BlurGlow");
            CheckRequiredCommandBuffers();
        }

        private void CheckRequiredCommandBuffers()
        {
            if (cbGlow == null)
            {
                cbGlow = new CommandBuffer();
                cbGlow.name = "Outer Glow for " + name;
            }
            if (cbSeeThrough == null)
            {
                cbSeeThrough = new CommandBuffer();
                cbSeeThrough.name = "See Through for " + name;
            }
        }

        private void CheckCommandBuffers()
        {
            if (cbMask == null)
            {
                cbMask = new CommandBuffer();
                cbMask.name = "Mask for " + name;
            }
            if (cbOutline == null)
            {
                cbOutline = new CommandBuffer();
                cbOutline.name = "Outline for " + name;
            }
            if (cbOverlay == null)
            {
                cbOverlay = new CommandBuffer();
                cbOverlay.name = "Overlay for " + name;
            }
            if (cbInnerGlow == null)
            {
                cbInnerGlow = new CommandBuffer();
                cbInnerGlow.name = "Inner Glow for " + name;
            }
        }

        private void CheckBlurCommandBuffer()
        {
            if (cbSmoothBlend == null)
            {
                cbSmoothBlend = new CommandBuffer();
                cbSmoothBlend.name = "Smooth Blend for " + name;
            }
        }

        private void Fork(Material mat, ref Material[] mats, Mesh mesh)
        {
            if (mesh == null)
                return;
            int count = mesh.subMeshCount;
            if (mats == null || mats.Length < count)
            {
                DestroyMaterialArray(mats);
                mats = new Material[count];
            }
            for (int k = 0; k < count; k++)
            {
                if (mats[k] == null)
                {
                    mats[k] = Instantiate(mat);
                }
            }
        }

        private void BakeTransform(int objIndex, bool duplicateMesh)
        {
            if (rms[objIndex].mesh == null)
                return;
            Transform t = rms[objIndex].transform;
            Vector3 scale = t.localScale;
            if (scale.x >= 0 && scale.y >= 0 && scale.z >= 0)
            {
                rms[objIndex].bakedTransform = false;
                return;
            }
            // Duplicates mesh and bake rotation
            Mesh fixedMesh = duplicateMesh ? Instantiate(rms[objIndex].originalMesh) : rms[objIndex].mesh;
            Vector3[] vertices = fixedMesh.vertices;
            for (int k = 0; k < vertices.Length; k++)
            {
                vertices[k] = t.TransformPoint(vertices[k]);
            }
            fixedMesh.vertices = vertices;
            Vector3[] normals = fixedMesh.normals;
            if (normals != null)
            {
                for (int k = 0; k < normals.Length; k++)
                {
                    normals[k] = t.TransformVector(normals[k]).normalized;
                }
                fixedMesh.normals = normals;
            }
            fixedMesh.RecalculateBounds();
            rms[objIndex].mesh = fixedMesh;
            rms[objIndex].bakedTransform = true;
            rms[objIndex].currentPosition = t.position;
            rms[objIndex].currentRotation = t.eulerAngles;
            rms[objIndex].currentScale = t.lossyScale;
        }

        internal void UpdateMaterialProperties(bool forceNow = false)
        {
            if (forceNow || !Application.isPlaying)
            {
                requireUpdateMaterial = false;
                UpdateMaterialPropertiesNow();
            }
            else
            {
                requireUpdateMaterial = true;
            }
        }

        private void UpdateMaterialPropertiesNow()
        {
            if (rms == null)
                return;

            if (ignore)
            {
                _highlighted = false;
            }

            maskRequired = (_highlighted && (outline > 0 || (glow > 0 && !glowIgnoreMask))) || seeThrough != SeeThroughMode.Never || (targetFX && targetFXAlignToGround);

            Color seeThroughTintColor = this.seeThroughTintColor;
            seeThroughTintColor.a = this.seeThroughTintAlpha;

            if (lastOutlineVisibility != outlineVisibility)
            {
                // change by scripting?
                if (glowQuality == QualityLevel.Highest && outlineQuality == QualityLevel.Highest)
                {
                    glowVisibility = outlineVisibility;
                }
                lastOutlineVisibility = outlineVisibility;
            }
            if (outlineWidth < 0)
            {
                outlineWidth = 0;
            }
            if (outlineQuality == QualityLevel.Medium)
            {
                outlineOffsetsMin = 4; outlineOffsetsMax = 7;
            }
            else if (outlineQuality == QualityLevel.High)
            {
                outlineOffsetsMin = 0; outlineOffsetsMax = 7;
            }
            else
            {
                outlineOffsetsMin = outlineOffsetsMax = 0;
            }
            if (glowWidth < 0)
            {
                glowWidth = 0;
            }
            if (glowQuality == QualityLevel.Medium)
            {
                glowOffsetsMin = 4; glowOffsetsMax = 7;
            }
            else if (glowQuality == QualityLevel.High)
            {
                glowOffsetsMin = 0; glowOffsetsMax = 7;
            }
            else
            {
                glowOffsetsMin = glowOffsetsMax = 0;
            }
            if (targetFXTransitionDuration <= 0)
            {
                targetFXTransitionDuration = 0.0001f;
            }
            if (targetFXStayDuration <= 0)
            {
                targetFXStayDuration = 0;
            }
            if (seeThroughDepthOffset < 0)
            {
                seeThroughDepthOffset = 0;
            }
            if (seeThroughMaxDepth < 0)
            {
                seeThroughMaxDepth = 0;
            }
            if (seeThroughBorderWidth < 0)
            {
                seeThroughBorderWidth = 0;
            }
            if (targetFXFadePower < 0)
            {
                targetFXFadePower = 0;
            }

            // Setup materials

            // Outline
            float scaledOutlineWidth = (outlineQuality == QualityLevel.High || normalsOption == NormalsOption.Planar) ? 0f : outlineWidth / 100f;
            Material matOutline = fxMatOutline;
            matOutline.SetFloat(ShaderParams.OutlineWidth, scaledOutlineWidth);
            matOutline.SetFloat(ShaderParams.OutlineVertexWidth, normalsOption == NormalsOption.Planar ? outlineWidth / 100f : 0);
            matOutline.SetVector(ShaderParams.OutlineDirection, Vector3.zero);
            matOutline.SetInt(ShaderParams.OutlineZTest, GetZTestValue(outlineVisibility));
            matOutline.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
            matOutline.SetFloat(ShaderParams.ConstantWidth, constantWidth ? 1.0f : 0);

            bool useSmoothOutline = outline > 0 && outlineQuality == QualityLevel.Highest;
            if (useSmoothOutline)
            {
                CheckBlurCommandBuffer();
                fxMatComposeOutline.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
                fxMatBlurOutline.SetFloat(ShaderParams.BlurScale, outlineWidth / outlineDownsampling);
            }

            // Outer Glow
            Material matGlow = fxMatGlow;
            matGlow.SetVector(ShaderParams.Glow2, new Vector3(normalsOption == NormalsOption.Planar ? 0 : outlineWidth / 100f, glowAnimationSpeed, glowDithering ? 0 : 1));
            matGlow.SetInt(ShaderParams.GlowZTest, GetZTestValue(glowVisibility));
            matGlow.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
            matGlow.SetFloat(ShaderParams.ConstantWidth, constantWidth ? 1.0f : 0);
            matGlow.SetInt(ShaderParams.GlowStencilOp, glowBlendPasses ? (int)StencilOp.Keep : (int)StencilOp.Replace);
            matGlow.SetInt(ShaderParams.GlowStencilComp, glowIgnoreMask ? (int)CompareFunction.Always : (int)CompareFunction.NotEqual);

            bool useSmoothGlow = glow > 0 && glowQuality == QualityLevel.Highest;
            if (useSmoothGlow)
            {
                CheckBlurCommandBuffer();
                fxMatComposeGlow.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
                fxMatComposeGlow.SetInt(ShaderParams.GlowStencilComp, glowIgnoreMask ? (int)CompareFunction.Always : (int)CompareFunction.NotEqual);
                if (glowBlendMode == GlowBlendMode.Additive)
                {
                    fxMatComposeGlow.SetInt(ShaderParams.BlendSrc, (int)BlendMode.One);
                    fxMatComposeGlow.SetInt(ShaderParams.BlendDst, (int)BlendMode.One);
                }
                else
                {
                    fxMatComposeGlow.SetInt(ShaderParams.BlendSrc, (int)BlendMode.SrcAlpha);
                    fxMatComposeGlow.SetInt(ShaderParams.BlendDst, (int)BlendMode.OneMinusSrcAlpha);
                }
                fxMatBlurGlow.SetFloat(ShaderParams.BlurScale, glowWidth / glowDownsampling);
                fxMatBlurGlow.SetFloat(ShaderParams.Speed, glowAnimationSpeed);
            }
            // Target
            if (targetFX)
            {
                if (targetFXTexture == null)
                {
                    targetFXTexture = Resources.Load<Texture2D>("HighlightPlus/target");
                }
                fxMatTarget.mainTexture = targetFXTexture;
                fxMatTarget.SetInt(ShaderParams.ZTest, GetZTestValue(targetFXVisibility));
            }

            // Per object materials
            bool renderMaskOnTop = _highlighted && ((outline > 0 && outlineVisibility != Visibility.Normal) || (glow > 0 && glowVisibility != Visibility.Normal) || (innerGlow > 0 && innerGlowVisibility != Visibility.Normal));
            for (int k = 0; k < rmsCount; k++)
            {
                if (rms[k].mesh != null)
                {
                    Renderer renderer = rms[k].renderer;
                    if (renderer == null)
                        continue;

                    // Mask, See-through & Overlay per submesh
                    for (int l = 0; l < rms[k].mesh.subMeshCount; l++)
                    {
                        if (((1 << l) & subMeshMask) == 0) continue;

                        Material mat = null;
                        renderer.GetSharedMaterials(rendererSharedMaterials);
                        if (l < rendererSharedMaterials.Count)
                        {
                            mat = rendererSharedMaterials[l];
                        }
                        if (mat == null)
                            continue;

                        bool hasTexture = mat.HasProperty(ShaderParams.MainTex);
                        bool useAlphaTest = alphaCutOff > 0 && hasTexture;

                        // Mask
                        if (rms[k].fxMatMask != null && rms[k].fxMatMask.Length > l)
                        {
                            Material fxMat = rms[k].fxMatMask[l];
                            if (fxMat != null)
                            {
                                if (hasTexture)
                                {
                                    Texture texture = mat.mainTexture;
                                    fxMat.mainTexture = texture;
                                    fxMat.mainTextureOffset = mat.mainTextureOffset;
                                    fxMat.mainTextureScale = mat.mainTextureScale;
                                }
                                if (useAlphaTest)
                                {
                                    fxMat.SetFloat(ShaderParams.CutOff, alphaCutOff);
                                    fxMat.EnableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                if (depthClip && !renderMaskOnTop)
                                {
                                    fxMat.EnableKeyword(ShaderParams.SKW_DEPTHCLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_DEPTHCLIP);
                                }
                                fxMat.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
                            }
                        }

                        // See-through inner
                        bool usesSeeThroughBorder = rms[k].fxMatSeeThroughBorder != null && rms[k].fxMatSeeThroughBorder.Length > l && (seeThroughBorder * seeThroughBorderWidth > 0);
                        if (rms[k].fxMatSeeThroughInner != null && rms[k].fxMatSeeThroughInner.Length > l)
                        {
                            Material fxMat = rms[k].fxMatSeeThroughInner[l];
                            if (fxMat != null)
                            {
                                fxMat.SetFloat(ShaderParams.SeeThrough, seeThroughIntensity);
                                fxMat.SetFloat(ShaderParams.SeeThroughNoise, seeThroughNoise);
                                fxMat.SetColor(ShaderParams.SeeThroughTintColor, seeThroughTintColor);
                                if (seeThroughOccluderMaskAccurate && seeThroughOccluderMask != -1)
                                {
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilRef, 1);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilComp, (int)CompareFunction.Equal);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilPassOp, (int)StencilOp.Zero);
                                }
                                else
                                {
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilRef, 2);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilComp, (int)CompareFunction.Greater);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilPassOp, (int)StencilOp.Replace);
                                }
                                if (seeThroughOrdered)
                                {
                                    fxMat.SetInt(ShaderParams.ZTest, (int)CompareFunction.LessEqual);
                                    fxMat.SetInt(ShaderParams.SeeThroughOrdered, 1);
                                }
                                else
                                {
                                    fxMat.SetInt(ShaderParams.ZTest, (int)CompareFunction.Greater);
                                    fxMat.SetInt(ShaderParams.SeeThroughOrdered, 0);
                                }
                                if (hasTexture)
                                {
                                    Texture texture = mat.mainTexture;
                                    fxMat.mainTexture = texture;
                                    fxMat.mainTextureOffset = mat.mainTextureOffset;
                                    fxMat.mainTextureScale = mat.mainTextureScale;
                                }
                                if (useAlphaTest)
                                {
                                    fxMat.SetFloat(ShaderParams.CutOff, alphaCutOff);
                                    fxMat.EnableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                if (seeThroughDepthOffset > 0 || seeThroughMaxDepth > 0)
                                {
                                    fxMat.SetFloat(ShaderParams.SeeThroughDepthOffset, seeThroughDepthOffset > 0 ? seeThroughDepthOffset : -1);
                                    fxMat.SetFloat(ShaderParams.SeeThroughMaxDepth, seeThroughMaxDepth > 0 ? seeThroughMaxDepth : 999999);
                                    fxMat.EnableKeyword(ShaderParams.SKW_DEPTH_OFFSET);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_DEPTH_OFFSET);
                                }
                                if (seeThroughBorderOnly)
                                {
                                    fxMat.EnableKeyword(ShaderParams.SKW_SEETHROUGH_ONLY_BORDER);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_SEETHROUGH_ONLY_BORDER);
                                }
                            }
                        }

                        // See-through border
                        if (usesSeeThroughBorder)
                        {
                            Material fxMat = rms[k].fxMatSeeThroughBorder[l];
                            if (fxMat != null)
                            {
                                fxMat.SetColor(ShaderParams.SeeThroughBorderColor, new Color(seeThroughBorderColor.r, seeThroughBorderColor.g, seeThroughBorderColor.b, seeThroughBorder));
                                fxMat.SetFloat(ShaderParams.SeeThroughBorderWidth, (seeThroughBorder * seeThroughBorderWidth) > 0 ? seeThroughBorderWidth / 100f : 0);
                                fxMat.SetFloat(ShaderParams.SeeThroughBorderConstantWidth, constantWidth ? 1.0f : 0);
                                if (seeThroughOccluderMaskAccurate && seeThroughOccluderMask != -1)
                                {
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilRef, 1);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilComp, (int)CompareFunction.Equal);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilPassOp, (int)StencilOp.Zero);
                                }
                                else
                                {
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilRef, 2);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilComp, (int)CompareFunction.Greater);
                                    fxMat.SetInt(ShaderParams.SeeThroughStencilPassOp, (int)StencilOp.Replace);
                                }
                                if (seeThroughOrdered)
                                {
                                    fxMat.SetInt(ShaderParams.ZTest, (int)CompareFunction.LessEqual);
                                    fxMat.SetInt(ShaderParams.SeeThroughOrdered, 1);
                                }
                                else
                                {
                                    fxMat.SetInt(ShaderParams.ZTest, (int)CompareFunction.Greater);
                                    fxMat.SetInt(ShaderParams.SeeThroughOrdered, 0);
                                }
                                if (hasTexture)
                                {
                                    Texture texture = mat.mainTexture;
                                    fxMat.mainTexture = texture;
                                    fxMat.mainTextureOffset = mat.mainTextureOffset;
                                    fxMat.mainTextureScale = mat.mainTextureScale;
                                }
                                if (useAlphaTest)
                                {
                                    fxMat.SetFloat(ShaderParams.CutOff, alphaCutOff);
                                    fxMat.EnableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                if (seeThroughDepthOffset > 0 || seeThroughMaxDepth > 0)
                                {
                                    fxMat.SetFloat(ShaderParams.SeeThroughDepthOffset, seeThroughDepthOffset > 0 ? seeThroughDepthOffset : -1);
                                    fxMat.SetFloat(ShaderParams.SeeThroughMaxDepth, seeThroughMaxDepth > 0 ? seeThroughMaxDepth : 999999);
                                    fxMat.EnableKeyword(ShaderParams.SKW_DEPTH_OFFSET);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_DEPTH_OFFSET);
                                }
                            }
                        }

                        // Overlay
                        if (rms[k].fxMatOverlay != null && rms[k].fxMatOverlay.Length > l)
                        {
                            Material fxMat = rms[k].fxMatOverlay[l];
                            if (fxMat != null)
                            {
                                if (hasTexture)
                                {
                                    Texture texture = mat.mainTexture;
                                    fxMat.mainTexture = texture;
                                    fxMat.mainTextureOffset = mat.mainTextureOffset;
                                    fxMat.mainTextureScale = mat.mainTextureScale;
                                }
                                if (mat.HasProperty(ShaderParams.Color))
                                {
                                    fxMat.SetColor(ShaderParams.OverlayBackColor, mat.GetColor(ShaderParams.Color));
                                }
                                fxMat.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
                                if (overlayTexture != null)
                                {
                                    fxMat.SetTexture(ShaderParams.OverlayTexture, overlayTexture);
                                    fxMat.EnableKeyword(ShaderParams.SKW_USES_OVERLAY_TEXTURE);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_USES_OVERLAY_TEXTURE);
                                }
                                if (useAlphaTest)
                                {
                                    fxMat.SetFloat(ShaderParams.CutOff, alphaCutOff);
                                    fxMat.EnableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                            }
                        }

                        // Inner Glow
                        if (rms[k].fxMatInnerGlow != null && rms[k].fxMatInnerGlow.Length > l)
                        {
                            Material fxMat = rms[k].fxMatInnerGlow[l];
                            if (fxMat != null)
                            {
                                if (hasTexture)
                                {
                                    Texture texture = mat.mainTexture;
                                    fxMat.mainTexture = texture;
                                    fxMat.mainTextureOffset = mat.mainTextureOffset;
                                    fxMat.mainTextureScale = mat.mainTextureScale;
                                }
                                fxMat.SetFloat(ShaderParams.InnerGlowWidth, innerGlowWidth);
                                fxMat.SetInt(ShaderParams.InnerGlowZTest, GetZTestValue(innerGlowVisibility));
                                fxMat.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
                                if (useAlphaTest)
                                {
                                    fxMat.SetFloat(ShaderParams.CutOff, alphaCutOff);
                                    fxMat.EnableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                            }
                        }

                        // Solid Color for smooth glow
                        if (rms[k].fxMatSolidColor != null && rms[k].fxMatSolidColor.Length > l)
                        {
                            Material fxMat = rms[k].fxMatSolidColor[l];
                            if (fxMat != null)
                            {
                                fxMat.color = glowHQColor;
                                fxMat.SetInt(ShaderParams.Cull, cullBackFaces ? (int)CullMode.Back : (int)CullMode.Off);
                                fxMat.SetInt(ShaderParams.ZTest, GetZTestValue(useSmoothGlow ? glowVisibility : outlineVisibility));
                                if (hasTexture)
                                {
                                    Texture texture = mat.mainTexture;
                                    fxMat.mainTexture = texture;
                                    fxMat.mainTextureOffset = mat.mainTextureOffset;
                                    fxMat.mainTextureScale = mat.mainTextureScale;
                                }
                                if (useAlphaTest)
                                {
                                    fxMat.SetFloat(ShaderParams.CutOff, alphaCutOff);
                                    fxMat.EnableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_ALPHACLIP);
                                }
                                if (depthClip && !renderMaskOnTop)
                                {
                                    fxMat.EnableKeyword(ShaderParams.SKW_DEPTHCLIP);
                                }
                                else
                                {
                                    fxMat.DisableKeyword(ShaderParams.SKW_DEPTHCLIP);
                                }
                            }
                        }
                    }
                }
            }
        }

        private float ComputeCameraDistanceFade(Vector3 position, Transform cameraTransform)
        {
            Vector3 heading = position - cameraTransform.position;
            float distance = Vector3.Dot(heading, cameraTransform.forward);
            if (distance < cameraDistanceFadeNear)
            {
                return 1f - Mathf.Min(1f, cameraDistanceFadeNear - distance);
            }
            if (distance > cameraDistanceFadeFar)
            {
                return 1f - Mathf.Min(1f, distance - cameraDistanceFadeFar);
            }
            return 1f;
        }

        private int GetZTestValue(Visibility param)
        {
            switch (param)
            {
                case Visibility.AlwaysOnTop:
                    return (int)CompareFunction.Always;

                case Visibility.OnlyWhenOccluded:
                    return (int)CompareFunction.Greater;

                default:
                    return (int)CompareFunction.LessEqual;
            }
        }

        private void BuildQuad()
        {
            quadMesh = new Mesh();

            // Setup vertices
            Vector3[] newVertices = new Vector3[4];
            float halfHeight = 0.5f;
            float halfWidth = 0.5f;
            newVertices[0] = new Vector3(-halfWidth, -halfHeight, 0);
            newVertices[1] = new Vector3(-halfWidth, halfHeight, 0);
            newVertices[2] = new Vector3(halfWidth, -halfHeight, 0);
            newVertices[3] = new Vector3(halfWidth, halfHeight, 0);

            // Setup UVs
            Vector2[] newUVs = new Vector2[newVertices.Length];
            newUVs[0] = new Vector2(0, 0);
            newUVs[1] = new Vector2(0, 1);
            newUVs[2] = new Vector2(1, 0);
            newUVs[3] = new Vector2(1, 1);

            // Setup triangles
            int[] newTriangles = { 0, 1, 2, 3, 2, 1 };

            // Setup normals
            Vector3[] newNormals = new Vector3[newVertices.Length];
            for (int i = 0; i < newNormals.Length; i++)
            {
                newNormals[i] = Vector3.forward;
            }

            // Create quad
            quadMesh.vertices = newVertices;
            quadMesh.uv = newUVs;
            quadMesh.triangles = newTriangles;
            quadMesh.normals = newNormals;

            quadMesh.RecalculateBounds();
        }

        private void BuildCube()
        {
            cubeMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
        }

        /// <summary>
        /// Returns true if a given transform is included in this effect
        /// </summary>
        internal bool Includes(Transform transform)
        {
            for (int k = 0; k < rmsCount; k++)
            {
                if (rms[k].transform == transform) return true;
            }
            return false;
        }

        /// <summary>
        /// Updates profile glow color
        /// </summary>
        internal void SetGlowColor(Color color)
        {
            if (glowPasses != null)
            {
                for (int k = 0; k < glowPasses.Length; k++)
                {
                    glowPasses[k].color = color;
                }
            }
            glowHQColor = color;
            UpdateMaterialProperties();
        }

        #region Normals handling

        private static Il2CppSystem.Collections.Generic.List<Vector3> vertices;
        private static Il2CppSystem.Collections.Generic.List<Vector3> normals;
        private static Vector3[] newNormals;
        private static int[] matches;
        private static readonly Dictionary<Vector3, int> vv = new Dictionary<Vector3, int>();
        private static readonly Dictionary<int, Mesh> smoothMeshes = new Dictionary<int, Mesh>();
        private static readonly Dictionary<int, Mesh> reorientedMeshes = new Dictionary<int, Mesh>();
        private static readonly Dictionary<int, Mesh> combinedMeshes = new Dictionary<int, Mesh>();
        private static readonly Il2CppSystem.Collections.Generic.List<Material> rendererSharedMaterials = new();
        private int combinedMeshesHashId;

        private void AverageNormals(int objIndex)
        {
            if (rms == null || objIndex >= rms.Length) return;
            Mesh mesh = rms[objIndex].mesh;

            Mesh newMesh;
            int hashCode = mesh.GetHashCode();
            if (!smoothMeshes.TryGetValue(hashCode, out newMesh) || newMesh == null)
            {
                if (!mesh.isReadable) return;
                if (normals == null)
                {
                    normals = new();
                }
                else
                {
                    normals.Clear();
                }
                mesh.GetNormals(normals);
                int normalsCount = normals.Count;
                if (normalsCount == 0)
                    return;
                if (vertices == null)
                {
                    vertices = new();
                }
                else
                {
                    vertices.Clear();
                }
                mesh.GetVertices(vertices);
                int vertexCount = vertices.Count;
                if (normalsCount < vertexCount)
                {
                    vertexCount = normalsCount;
                }
                if (newNormals == null || newNormals.Length < vertexCount)
                {
                    newNormals = new Vector3[vertexCount];
                }
                else
                {
                    Vector3 zero = Vector3.zero;
                    for (int k = 0; k < vertexCount; k++)
                    {
                        newNormals[k] = zero;
                    }
                }
                if (matches == null || matches.Length < vertexCount)
                {
                    matches = new int[vertexCount];
                }
                // Locate overlapping vertices
                vv.Clear();
                for (int k = 0; k < vertexCount; k++)
                {
                    int i;
                    Vector3 v = vertices[k];
                    if (!vv.TryGetValue(v, out i))
                    {
                        vv[v] = i = k;
                    }
                    matches[k] = i;
                }
                // Average normals
                for (int k = 0; k < vertexCount; k++)
                {
                    int match = matches[k];
                    newNormals[match] += normals[k];
                }
                for (int k = 0; k < vertexCount; k++)
                {
                    int match = matches[k];
                    normals[k] = newNormals[match].normalized;
                }
                // Reassign normals
                newMesh = Instantiate(mesh);
                newMesh.SetNormals(normals);
                smoothMeshes[hashCode] = newMesh;
            }
            rms[objIndex].mesh = newMesh;
        }

        private void ReorientNormals(int objIndex)
        {
            if (rms == null || objIndex >= rms.Length) return;
            Mesh mesh = rms[objIndex].mesh;

            Mesh newMesh;
            int hashCode = mesh.GetHashCode();
            if (!reorientedMeshes.TryGetValue(hashCode, out newMesh) || newMesh == null)
            {
                if (!mesh.isReadable) return;
                if (normals == null)
                {
                    normals = new();
                }
                else
                {
                    normals.Clear();
                }
                if (vertices == null)
                {
                    vertices = new();
                }
                else
                {
                    vertices.Clear();
                }
                mesh.GetVertices(vertices);
                int vertexCount = vertices.Count;
                if (vertexCount == 0) return;

                Vector3 mid = Vector3.zero;
                for (int k = 0; k < vertexCount; k++)
                {
                    mid += vertices[k];
                }
                mid /= vertexCount;
                // Average normals
                for (int k = 0; k < vertexCount; k++)
                {
                    normals.Add((vertices[k] - mid).normalized);
                }
                // Reassign normals
                newMesh = Instantiate(mesh);
                newMesh.SetNormals(normals);
                reorientedMeshes[hashCode] = newMesh;
            }
            rms[objIndex].mesh = newMesh;
        }

        private const int MAX_VERTEX_COUNT = 65535;

        private void CombineMeshes()
        {
            // Combine meshes of group into the first mesh in rms
            if (combineInstances == null || combineInstances.Length != rmsCount)
            {
                combineInstances = new CombineInstance[rmsCount];
            }
            int first = -1;
            int count = 0;
            combinedMeshesHashId = 0;
            int vertexCount = 0;
            Matrix4x4 im = matrix4X4Identity;
            for (int k = 0; k < rmsCount; k++)
            {
                combineInstances[k].mesh = null;
                if (!rms[k].isSkinnedMesh)
                {
                    Mesh mesh = rms[k].mesh;
                    if (mesh != null && mesh.isReadable)
                    {
                        if (vertexCount + mesh.vertexCount > MAX_VERTEX_COUNT) continue;

                        combineInstances[k].mesh = mesh;
                        int instanceId = rms[k].renderer.gameObject.GetInstanceID();
                        if (first < 0)
                        {
                            first = k;
                            combinedMeshesHashId = instanceId;
                            im = rms[k].transform.worldToLocalMatrix;
                        }
                        else
                        {
                            combinedMeshesHashId ^= instanceId;
                            rms[k].mesh = null;
                        }
                        combineInstances[k].transform = im * rms[k].transform.localToWorldMatrix;
                        count++;
                    }
                }
            }
            if (count < 2) return;

            Mesh combinedMesh;
            if (!combinedMeshes.TryGetValue(combinedMeshesHashId, out combinedMesh) || combinedMesh == null)
            {
                combinedMesh = new Mesh();
                combinedMesh.CombineMeshes(combineInstances, true, true);
                combinedMeshes[combinedMeshesHashId] = combinedMesh;
            }
            rms[first].mesh = combinedMesh;
            rms[first].isCombined = true;
        }

        #endregion Normals handling

        #region HighlightEffectActions

        /// <summary>
        /// Performs a hit effect using default values
        /// </summary>
        internal void HitFX()
        {
            HitFX(hitFxColor, hitFxFadeOutDuration, hitFxInitialIntensity);
        }

        /// <summary>
        /// Performs a hit effect localized at hit position and radius with default values
        /// </summary>
        internal void HitFX(Vector3 position)
        {
            HitFX(hitFxColor, hitFxFadeOutDuration, hitFxInitialIntensity, position, hitFxRadius);
        }

        /// <summary>
        /// Performs a hit effect using desired color, fade out duration and optionally initial intensity (0-1)
        /// </summary>
        internal void HitFX(Color color, float fadeOutDuration, float initialIntensity = 1f)
        {
            hitInitialIntensity = initialIntensity;
            hitFadeOutDuration = fadeOutDuration;
            hitColor = color;
            hitStartTime = Time.time;
            hitActive = true;
            if (overlay == 0)
            {
                UpdateMaterialProperties();
            }
        }

        /// <summary>
        /// Performs a hit effect using desired color, fade out duration, initial intensity (0-1), hit position and radius of effect
        /// </summary>
        internal void HitFX(Color color, float fadeOutDuration, float initialIntensity, Vector3 position, float radius)
        {
            hitInitialIntensity = initialIntensity;
            hitFadeOutDuration = fadeOutDuration;
            hitColor = color;
            hitStartTime = Time.time;
            hitActive = true;
            hitPosition = position;
            hitRadius = radius;
            if (overlay == 0)
            {
                UpdateMaterialProperties();
            }
        }

        /// <summary>
        /// Initiates the target FX on demand using predefined configuration (see targetFX... properties)
        /// </summary>
        internal void TargetFX()
        {
            targetFxStartTime = Time.time;
            if (!targetFX)
            {
                targetFX = true;
                UpdateMaterialProperties();
            }
        }

        #endregion HighlightEffectActions

        #region OccluderManager

        /// <summary>
        /// True if the see-through is cancelled by an occluder using raycast method
        /// </summary>
        internal bool IsSeeThroughOccluded(Camera cam)
        {
            // Compute bounds
            Bounds bounds = new Bounds();
            for (int r = 0; r < rms.Length; r++)
            {
                if (rms[r].renderer != null)
                {
                    if (bounds.size.x == 0)
                    {
                        bounds = rms[r].renderer.bounds;
                    }
                    else
                    {
                        bounds.Encapsulate(rms[r].renderer.bounds);
                    }
                }
            }
            Vector3 pos = bounds.center;
            Vector3 camPos = cam.transform.position;
            Vector3 offset = pos - camPos;
            float maxDistance = Vector3.Distance(pos, camPos);
            if (hits == null || hits.Length == 0)
            {
                hits = new RaycastHit[64];
            }
            int occludersCount = occluders.Count;
            int hitCount = Physics.BoxCastNonAlloc(pos - offset, bounds.extents * 0.9f, offset.normalized, hits, Quaternion.identity, maxDistance);
            for (int k = 0; k < hitCount; k++)
            {
                for (int j = 0; j < occludersCount; j++)
                {
                    if (hits[k].collider.transform == occluders[j].transform)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static void RegisterOccluder(HighlightSeeThroughOccluder occluder)
        {
            if (!occluders.Contains(occluder))
            {
                occluders.Add(occluder);
            }
        }

        internal static void UnregisterOccluder(HighlightSeeThroughOccluder occluder)
        {
            if (occluders.Contains(occluder))
            {
                occluders.Remove(occluder);
            }
        }

        /// <summary>
        /// Test see-through occluders.
        /// </summary>
        /// <param name="cam">The camera to be tested</param>
        /// <returns>Returns true if there's no raycast-based occluder cancelling the see-through effect</returns>
        internal bool RenderSeeThroughOccluders(Camera cam)
        {
            int occludersCount = occluders.Count;
            if (occludersCount == 0 || rmsCount == 0) return true;

            bool useRayCastCheck = false;
            // Check if raycast method is needed
            for (int k = 0; k < occludersCount; k++)
            {
                HighlightSeeThroughOccluder occluder = occluders[k];
                if (occluder == null || !occluder.isActiveAndEnabled) continue;
                if (occluder.detectionMethod == DetectionMethod.RayCast)
                {
                    useRayCastCheck = true;
                    break;
                }
            }
            if (useRayCastCheck)
            {
                if (IsSeeThroughOccluded(cam)) return false;
            }

            // do not render see-through occluders more than once this frame per camera (there can be many highlight effect scripts in the scene, we only need writing to stencil once)
            int lastFrameCount;
            occludersFrameCount.TryGetValue(cam, out lastFrameCount);
            int currentFrameCount = Time.frameCount;
            if (currentFrameCount == lastFrameCount) return true;
            occludersFrameCount[cam] = currentFrameCount;

            if (cbOccluder == null)
            {
                cbOccluder = new CommandBuffer();
                cbOccluder.name = "Occluder";
            }

            if (fxMatOccluder == null)
            {
                InitMaterial(ref fxMatOccluder, "HighlightPlus/Geometry/SeeThroughOccluder");
                if (fxMatOccluder == null) return true;
            }

            cbOccluder.Clear();
            for (int k = 0; k < occludersCount; k++)
            {
                HighlightSeeThroughOccluder occluder = occluders[k];
                if (occluder == null || !occluder.isActiveAndEnabled) continue;
                if (occluder.detectionMethod == DetectionMethod.Stencil)
                {
                    if (occluder.meshData == null || occluder.meshData.Length == 0) continue;
                    // Per renderer
                    for (int m = 0; m < occluder.meshData.Length; m++)
                    {
                        // Per submesh
                        Renderer renderer = occluder.meshData[m].renderer;
                        if (renderer.isVisible)
                        {
                            for (int s = 0; s < occluder.meshData[m].subMeshCount; s++)
                            {
                                cbOccluder.DrawRenderer(renderer, fxMatOccluder, s);
                            }
                        }
                    }
                }
            }
            Graphics.ExecuteCommandBuffer(cbOccluder);

            return true;
        }

        private bool CheckOcclusion(Camera cam)
        {
            float now = Time.time;
            int frameCount = Time.frameCount; // ensure all cameras are checked this frame

            if (Time.time - occlusionCheckLastTime < seeThroughOccluderCheckInterval && Application.isPlaying && occlusionRenderFrame != frameCount) return lastOcclusionTestResult;
            occlusionCheckLastTime = now;
            occlusionRenderFrame = frameCount;

            if (rms.Length == 0 || rms[0].renderer == null) return false;

            Vector3 camPos = cam.transform.position;

            if (seeThroughOccluderCheckIndividualObjects)
            {
                for (int r = 0; r < rms.Length; r++)
                {
                    if (rms[r].renderer != null)
                    {
                        Bounds bounds = rms[r].renderer.bounds;
                        Vector3 pos = bounds.center;
                        float maxDistance = Vector3.Distance(pos, camPos);
                        if (Physics.BoxCast(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, Quaternion.identity, maxDistance, seeThroughOccluderMask))
                        {
                            lastOcclusionTestResult = true;
                            return true;
                        }
                    }
                }
                lastOcclusionTestResult = false;
                return false;
            }
            else
            {
                // Compute bounds
                Bounds bounds = rms[0].renderer.bounds;
                for (int r = 1; r < rms.Length; r++)
                {
                    if (rms[r].renderer != null)
                    {
                        bounds.Encapsulate(rms[r].renderer.bounds);
                    }
                }
                Vector3 pos = bounds.center;
                float maxDistance = Vector3.Distance(pos, camPos);
                lastOcclusionTestResult = Physics.BoxCast(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, Quaternion.identity, maxDistance, seeThroughOccluderMask);
                return lastOcclusionTestResult;
            }
        }

        private const int MAX_OCCLUDER_HITS = 50;
        private static RaycastHit[] occluderHits;
        private readonly Dictionary<Camera, List<Renderer>> cachedOccludersPerCamera = new Dictionary<Camera, List<Renderer>>();


        private void CheckOcclusionAccurate(Camera cam)
        {
            List<Renderer> occluderRenderers;
            if (!cachedOccludersPerCamera.TryGetValue(cam, out occluderRenderers))
            {
                occluderRenderers = new List<Renderer>();
                cachedOccludersPerCamera[cam] = occluderRenderers;
            }

            float now = Time.time;
            int frameCount = Time.frameCount; // ensure all cameras are checked this frame
            bool reuse = Time.time - occlusionCheckLastTime < seeThroughOccluderCheckInterval && Application.isPlaying && occlusionRenderFrame != frameCount;

            if (!reuse)
            {
                if (rms.Length == 0 || rms[0].renderer == null) return;

                occlusionCheckLastTime = now;
                occlusionRenderFrame = frameCount;
                Quaternion quaternionIdentity = Quaternion.identity;
                Vector3 camPos = cam.transform.position;

                occluderRenderers.Clear();

                if (occluderHits == null || occluderHits.Length < MAX_OCCLUDER_HITS)
                {
                    occluderHits = new RaycastHit[MAX_OCCLUDER_HITS];
                }

                if (seeThroughOccluderCheckIndividualObjects)
                {
                    for (int r = 0; r < rms.Length; r++)
                    {
                        if (rms[r].renderer != null)
                        {
                            Bounds bounds = rms[r].renderer.bounds;
                            Vector3 pos = bounds.center;
                            float maxDistance = Vector3.Distance(pos, camPos);
                            int numOccluderHits = Physics.BoxCastNonAlloc(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, occluderHits, quaternionIdentity, maxDistance, seeThroughOccluderMask);
                            for (int k = 0; k < numOccluderHits; k++)
                            {
                                occluderHits[k].collider.transform.root.GetComponentsInChildren(tempRR);
                                occluderRenderers.AddWithoutRepetition(tempRR.ToManaged());
                            }
                        }
                    }
                }
                else
                {
                    // Compute combined bounds
                    Bounds bounds = rms[0].renderer.bounds;
                    for (int r = 1; r < rms.Length; r++)
                    {
                        if (rms[r].renderer != null)
                        {
                            bounds.Encapsulate(rms[r].renderer.bounds);
                        }
                    }
                    Vector3 pos = bounds.center;
                    float maxDistance = Vector3.Distance(pos, camPos);
                    int numOccluderHits = Physics.BoxCastNonAlloc(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, occluderHits, quaternionIdentity, maxDistance, seeThroughOccluderMask);
                    for (int k = 0; k < numOccluderHits; k++)
                    {
                        occluderHits[k].collider.transform.root.GetComponentsInChildren(tempRR);
                        occluderRenderers.AddWithoutRepetition(tempRR.ToManaged());
                    }
                }
            }

            // render occluders
            int occluderRenderersCount = occluderRenderers.Count;
            if (occluderRenderersCount > 0)
            {
                cbSeeThrough.Clear();
                for (int k = 0; k < occluderRenderersCount; k++)
                {
                    Renderer r = occluderRenderers[k];
                    if (r != null)
                    {
                        cbSeeThrough.DrawRenderer(r, fxMatSeeThroughMask);
                    }
                }
                Graphics.ExecuteCommandBuffer(cbSeeThrough);
            }
        }

        internal List<Renderer> GetOccluders(Camera camera)
        {
            List<Renderer> occluders = null;
            if (cachedOccludersPerCamera != null)
            {
                cachedOccludersPerCamera.TryGetValue(camera, out occluders);
            }
            return occluders;
        }

        #endregion OccluderManager

        internal float hitFxInitialIntensity;
        internal HitFxMode hitFxMode = HitFxMode.Overlay;
        internal float hitFxFadeOutDuration = 0.25f;
        internal Color hitFxColor = Color.white;
        internal float hitFxRadius = 0.5f;

        private float hitInitialIntensity;
        private float hitStartTime;
        private float hitFadeOutDuration;
        private Color hitColor;
        private bool hitActive;
        private Vector3 hitPosition;
        private float hitRadius;

        private static readonly List<HighlightSeeThroughOccluder> occluders = new List<HighlightSeeThroughOccluder>();
        private static readonly Dictionary<Camera, int> occludersFrameCount = new Dictionary<Camera, int>();
        private static CommandBuffer cbOccluder;
        private static Material fxMatOccluder;
        private static RaycastHit[] hits;

        private static Vector4[] offsets;

        private float fadeStartTime;
        private FadingState fading = FadingState.NoFading;
        private CommandBuffer cbMask, cbSeeThrough, cbGlow, cbOutline, cbOverlay, cbInnerGlow;
        private CommandBuffer cbSmoothBlend;
        private int[] mipGlowBuffers, mipOutlineBuffers;
        private int glowRT, outlineRT;
        private static Mesh quadMesh, cubeMesh;
        private int sourceRT;
        private Matrix4x4 quadGlowMatrix, quadOutlineMatrix;
        private Vector3[] corners;
        private RenderTextureDescriptor sourceDesc;
        private Color debugColor, blackColor;
        private Visibility lastOutlineVisibility;
        private bool requireUpdateMaterial;
        private bool usingPipeline = false; // set to false to avoid editor warning due to conditional code
        private float occlusionCheckLastTime;
        private int occlusionRenderFrame;
        private bool lastOcclusionTestResult;
        private bool useGPUInstancing;

        private MaterialPropertyBlock glowPropertyBlock, outlinePropertyBlock;
        private static readonly Il2CppSystem.Collections.Generic.List<Vector4> matDataDirection = new();
        private static readonly Il2CppSystem.Collections.Generic.List<Vector4> matDataGlow = new();
        private static readonly Il2CppSystem.Collections.Generic.List<Vector4> matDataColor = new();
        private static Matrix4x4[] matrices;
        internal static readonly System.Collections.Generic.List<HighlightEffect> effects = new();
        internal static bool customSorting;
        private static int customSortingFrame;
        private static Camera customSortingCamera;

        private int skipThisFrame = -1;
        private int outlineOffsetsMin, outlineOffsetsMax;
        private int glowOffsetsMin, glowOffsetsMax;
        private static CombineInstance[] combineInstances;
        private Matrix4x4 matrix4X4Identity = Matrix4x4.identity;
        private bool maskRequired;

        private Il2CppSystem.Collections.Generic.List<Renderer> tempRR;

    }
}