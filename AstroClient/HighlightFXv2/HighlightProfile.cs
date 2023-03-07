using AstroClient.HighlightFXv2.Enums;
using UnityEngine;
using QualityLevel = AstroClient.HighlightFXv2.Enums.QualityLevel;

namespace AstroClient.HighlightFXv2
{
    //[CreateAssetMenu(menuName = "Highlight Plus Profile", fileName = "Highlight Plus Profile", order = 100)]
    //[HelpURL("https://www.dropbox.com/s/v9qgn68ydblqz8x/Documentation.pdf?dl=0
    internal class HighlightProfile : ScriptableObject
    {
        //internal HighlightProfile(System.IntPtr handle) : base(handle) { }
        //internal HighlightProfile() : base(ClassInjector.DerivedConstructorPointer<HighlightProfile>()) => ClassInjector.DerivedConstructorBody(this);


        /// <summary>
        /// Different options to specify which objects are affected by this Highlight Effect component.
        /// </summary>
        internal TargetOptions effectGroup = TargetOptions.Children;

        /// <summary>
        /// The layer that contains the affected objects by this effect when effectGroup is set to LayerMask.
        /// </summary>
        internal LayerMask effectGroupLayer = -1;

        /// <summary>
        /// Only include objects whose names contains this text.
        /// </summary>
        internal string effectNameFilter;

        /// <summary>
        /// Combine meshes of all objects in this group affected by Highlight Effect reducing draw calls.
        /// </summary>
        internal bool combineMeshes;

        /// <summary>
        /// The alpha threshold for transparent cutout objects. Pixels with alpha below this value will be discarded.
        /// </summary>

        internal float alphaCutOff;

        /// <summary>
        /// If back facing triangles are ignored.Backfaces triangles are not visible but you may set this property to false to force highlight effects to act on those triangles as well.
        /// </summary>
        internal bool cullBackFaces = true;

        internal bool depthClip;

        /// <summary>
        /// Normals handling option:\nPreserve original: use original mesh normals.\nSmooth: average normals to produce a smoother outline/glow mesh based effect.\nReorient: recomputes normals based on vertex direction to centroid.
        /// </summary>
        internal NormalsOption normalsOption;

        internal float fadeInDuration;
        internal float fadeOutDuration;

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
        /// Keeps the outline/glow size unaffected by object distance.
        /// </summary>
        internal bool constantWidth = true;

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
        internal QualityLevel outlineQuality = QualityLevel.High;

        /// <summary>
        /// Reduces the quality of the outline but improves performance a bit.
        /// </summary>
        internal int outlineDownsampling = 2;

        internal bool outlineOptimalBlit = true;
        internal Visibility outlineVisibility = Visibility.Normal;

        /// <summary>
        /// If enabled, this object won't combine the outline with other objects.
        /// </summary>
        internal bool outlineIndependent;

        /// <summary>
        /// The intensity of the outer glow effect. A value of 0 disables the glow completely.
        /// </summary>
        internal float glow;

        internal float glowWidth = 0.4f;
        internal QualityLevel glowQuality = QualityLevel.High;

        /// <summary>
        /// Reduces the quality of the glow but improves performance a bit.
        /// </summary>
        internal int glowDownsampling = 2;

        internal Color glowHQColor = new Color(0.64f, 1f, 0f, 1f);

        /// <summary>
        /// When enabled, outer glow renders with dithering. When disabled, glow appears as a solid color.
        /// </summary>
        internal bool glowDithering = true;

        internal bool glowOptimalBlit = true;

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
        internal GlowBlendMode glowBlendMode = GlowBlendMode.Additive;

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
        internal float targetFXRotationSpeed = 50f;
        internal float targetFXInitialScale = 4f;
        internal float targetFXEndScale = 1.5f;

        /// <summary>
        /// Makes target scale relative to object renderer bounds.
        /// </summary>
        internal bool targetFXScaleToRenderBounds;

        /// <summary>
        /// Places target FX sprite at the bottom of the highlighted object.
        /// </summary>
        internal bool targetFXAlignToGround;

        /// <summary>
        /// Max distance from the center of the highlighted object to the ground.
        /// </summary>
        internal float targetFXGroundMaxDistance = 15f;

        internal LayerMask targetFXGroundLayerMask = -1;

        /// <summary>
        /// Fade out effect with altitude
        /// </summary>
        internal float targetFXFadePower = 32;

        internal float targetFXTransitionDuration = 0.5f;
        internal float targetFXStayDuration = 1.5f;
        internal Visibility targetFXVisibility = Visibility.AlwaysOnTop;

        /// <summary>
        /// See-through mode for this Highlight Effect component.
        /// </summary>
        internal SeeThroughMode seeThrough = SeeThroughMode.Never;

        /// <summary>
        /// This mask setting let you specify which objects will be considered as occluders and cause the see-through effect for this Highlight Effect component. For example, you assign your walls to a different layer and specify that layer here, so only walls and not other objects, like ground or ceiling, will trigger the see-through effect.
        /// </summary>
        internal LayerMask seeThroughOccluderMask = -1;

        /// <summary>
        /// Uses stencil buffers to ensure pixel-accurate occlusion test. If this option is disabled, only physics raycasting is used to test for occlusion.
        /// </summary>
        internal bool seeThroughOccluderMaskAccurate;

        /// <summary>
        /// A multiplier for the occluder volume size which can be used to reduce the actual size of occluders when Highlight Effect checks if they're occluding this object.
        /// </summary>
        internal float seeThroughOccluderThreshold = 0.4f;

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
        internal float seeThroughBorderWidth = 0.45f;

        /// <summary>
        /// Only display the border instead of the full see-through effect.
        /// </summary>
        internal bool seeThroughBorderOnly;

        /// <summary>
        /// Renders see-through effect on overlapping objects in a sequence that's relative to the distance to the camera
        /// </summary>
        internal bool seeThroughOrdered = true;

        internal float hitFxInitialIntensity;
        internal HitFxMode hitFxMode = HitFxMode.Overlay;
        internal float hitFxFadeOutDuration = 0.25f;
        internal Color hitFxColor = Color.white;
        internal float hitFxRadius = 0.5f;

        internal void Load(HighlightEffect effect)
        {
            effect.effectGroup = effectGroup;
            effect.effectGroupLayer = effectGroupLayer;
            effect.effectNameFilter = effectNameFilter;
            effect.combineMeshes = combineMeshes;
            effect.alphaCutOff = alphaCutOff;
            effect.cullBackFaces = cullBackFaces;
            effect.depthClip = depthClip;
            effect.normalsOption = normalsOption;
            effect.fadeInDuration = fadeInDuration;
            effect.fadeOutDuration = fadeOutDuration;
            effect.cameraDistanceFade = cameraDistanceFade;
            effect.cameraDistanceFadeFar = cameraDistanceFadeFar;
            effect.cameraDistanceFadeNear = cameraDistanceFadeNear;
            effect.constantWidth = constantWidth;
            effect.overlay = overlay;
            effect.overlayColor = overlayColor;
            effect.overlayAnimationSpeed = overlayAnimationSpeed;
            effect.overlayMinIntensity = overlayMinIntensity;
            effect.overlayBlending = overlayBlending;
            effect.overlayTexture = overlayTexture;
            effect.overlayTextureScale = overlayTextureScale;
            effect.outline = outline;
            effect.outlineColor = outlineColor;
            effect.outlineWidth = outlineWidth;
            effect.outlineQuality = outlineQuality;
            effect.outlineOptimalBlit = outlineOptimalBlit;
            effect.outlineDownsampling = outlineDownsampling;
            effect.outlineVisibility = outlineVisibility;
            effect.outlineIndependent = outlineIndependent;
            effect.glow = glow;
            effect.glowWidth = glowWidth;
            effect.glowQuality = glowQuality;
            effect.glowOptimalBlit = glowOptimalBlit;
            effect.glowDownsampling = glowDownsampling;
            effect.glowHQColor = glowHQColor;
            effect.glowDithering = glowDithering;
            effect.glowMagicNumber1 = glowMagicNumber1;
            effect.glowMagicNumber2 = glowMagicNumber2;
            effect.glowAnimationSpeed = glowAnimationSpeed;
            effect.glowVisibility = glowVisibility;
            effect.glowBlendMode = glowBlendMode;
            effect.glowBlendPasses = glowBlendPasses;
            effect.glowPasses = GetGlowPassesCopy(glowPasses);
            effect.glowIgnoreMask = glowIgnoreMask;
            effect.innerGlow = innerGlow;
            effect.innerGlowWidth = innerGlowWidth;
            effect.innerGlowColor = innerGlowColor;
            effect.innerGlowVisibility = innerGlowVisibility;
            effect.targetFX = targetFX;
            effect.targetFXColor = targetFXColor;
            effect.targetFXInitialScale = targetFXInitialScale;
            effect.targetFXEndScale = targetFXEndScale;
            effect.targetFXScaleToRenderBounds = targetFXScaleToRenderBounds;
            effect.targetFXAlignToGround = targetFXAlignToGround;
            effect.targetFXGroundMaxDistance = targetFXGroundMaxDistance;
            effect.targetFXGroundLayerMask = targetFXGroundLayerMask;
            effect.targetFXFadePower = targetFXFadePower;
            effect.targetFXRotationSpeed = targetFXRotationSpeed;
            effect.targetFXStayDuration = targetFXStayDuration;
            effect.targetFXTexture = targetFXTexture;
            effect.targetFXTransitionDuration = targetFXTransitionDuration;
            effect.targetFXVisibility = targetFXVisibility;
            effect.seeThrough = seeThrough;
            effect.seeThroughOccluderMask = seeThroughOccluderMask;
            effect.seeThroughOccluderMaskAccurate = seeThroughOccluderMaskAccurate;
            effect.seeThroughOccluderThreshold = seeThroughOccluderThreshold;
            effect.seeThroughOccluderCheckInterval = seeThroughOccluderCheckInterval;
            effect.seeThroughOccluderCheckIndividualObjects = seeThroughOccluderCheckIndividualObjects;
            effect.seeThroughIntensity = seeThroughIntensity;
            effect.seeThroughTintAlpha = seeThroughTintAlpha;
            effect.seeThroughTintColor = seeThroughTintColor;
            effect.seeThroughNoise = seeThroughNoise;
            effect.seeThroughBorder = seeThroughBorder;
            effect.seeThroughBorderColor = seeThroughBorderColor;
            effect.seeThroughBorderWidth = seeThroughBorderWidth;
            effect.seeThroughBorderOnly = seeThroughBorderOnly;
            effect.seeThroughDepthOffset = seeThroughDepthOffset;
            effect.seeThroughMaxDepth = seeThroughMaxDepth;
            effect.seeThroughOrdered = seeThroughOrdered;
            effect.hitFxInitialIntensity = hitFxInitialIntensity;
            effect.hitFxMode = hitFxMode;
            effect.hitFxFadeOutDuration = hitFxFadeOutDuration;
            effect.hitFxColor = hitFxColor;
            effect.hitFxRadius = hitFxRadius;
            effect.UpdateMaterialProperties();
        }

        internal void Save(HighlightEffect effect)
        {
            effectGroup = effect.effectGroup;
            effectGroupLayer = effect.effectGroupLayer;
            effectNameFilter = effect.effectNameFilter;
            combineMeshes = effect.combineMeshes;
            alphaCutOff = effect.alphaCutOff;
            cullBackFaces = effect.cullBackFaces;
            depthClip = effect.depthClip;
            normalsOption = effect.normalsOption;
            fadeInDuration = effect.fadeInDuration;
            fadeOutDuration = effect.fadeOutDuration;
            cameraDistanceFade = effect.cameraDistanceFade;
            cameraDistanceFadeFar = effect.cameraDistanceFadeFar;
            cameraDistanceFadeNear = effect.cameraDistanceFadeNear;
            constantWidth = effect.constantWidth;
            overlay = effect.overlay;
            overlayColor = effect.overlayColor;
            overlayAnimationSpeed = effect.overlayAnimationSpeed;
            overlayMinIntensity = effect.overlayMinIntensity;
            overlayBlending = effect.overlayBlending;
            overlayTexture = effect.overlayTexture;
            overlayTextureScale = effect.overlayTextureScale;
            outline = effect.outline;
            outlineColor = effect.outlineColor;
            outlineWidth = effect.outlineWidth;
            outlineQuality = effect.outlineQuality;
            outlineDownsampling = effect.outlineDownsampling;
            outlineVisibility = effect.outlineVisibility;
            outlineIndependent = effect.outlineIndependent;
            outlineOptimalBlit = effect.outlineOptimalBlit;
            glow = effect.glow;
            glowWidth = effect.glowWidth;
            glowQuality = effect.glowQuality;
            glowOptimalBlit = effect.glowOptimalBlit;
            glowDownsampling = effect.glowDownsampling;
            glowHQColor = effect.glowHQColor;
            glowDithering = effect.glowDithering;
            glowMagicNumber1 = effect.glowMagicNumber1;
            glowMagicNumber2 = effect.glowMagicNumber2;
            glowAnimationSpeed = effect.glowAnimationSpeed;
            glowVisibility = effect.glowVisibility;
            glowBlendMode = effect.glowBlendMode;
            glowBlendPasses = effect.glowBlendPasses;
            glowPasses = GetGlowPassesCopy(effect.glowPasses);
            glowIgnoreMask = effect.glowIgnoreMask;
            innerGlow = effect.innerGlow;
            innerGlowWidth = effect.innerGlowWidth;
            innerGlowColor = effect.innerGlowColor;
            innerGlowVisibility = effect.innerGlowVisibility;
            targetFX = effect.targetFX;
            targetFXColor = effect.targetFXColor;
            targetFXInitialScale = effect.targetFXInitialScale;
            targetFXEndScale = effect.targetFXEndScale;
            targetFXScaleToRenderBounds = effect.targetFXScaleToRenderBounds;
            targetFXAlignToGround = effect.targetFXAlignToGround;
            targetFXGroundMaxDistance = effect.targetFXGroundMaxDistance;
            targetFXGroundLayerMask = effect.targetFXGroundLayerMask;
            targetFXFadePower = effect.targetFXFadePower;
            targetFXRotationSpeed = effect.targetFXRotationSpeed;
            targetFXStayDuration = effect.targetFXStayDuration;
            targetFXTexture = effect.targetFXTexture;
            targetFXTransitionDuration = effect.targetFXTransitionDuration;
            targetFXVisibility = effect.targetFXVisibility;
            seeThrough = effect.seeThrough;
            seeThroughOccluderMask = effect.seeThroughOccluderMask;
            seeThroughOccluderMaskAccurate = effect.seeThroughOccluderMaskAccurate;
            seeThroughOccluderThreshold = effect.seeThroughOccluderThreshold;
            seeThroughOccluderCheckInterval = effect.seeThroughOccluderCheckInterval;
            seeThroughOccluderCheckIndividualObjects = effect.seeThroughOccluderCheckIndividualObjects;
            seeThroughIntensity = effect.seeThroughIntensity;
            seeThroughTintAlpha = effect.seeThroughTintAlpha;
            seeThroughTintColor = effect.seeThroughTintColor;
            seeThroughNoise = effect.seeThroughNoise;
            seeThroughBorder = effect.seeThroughBorder;
            seeThroughBorderColor = effect.seeThroughBorderColor;
            seeThroughBorderWidth = effect.seeThroughBorderWidth;
            seeThroughDepthOffset = effect.seeThroughDepthOffset;
            seeThroughBorderOnly = effect.seeThroughBorderOnly;
            seeThroughMaxDepth = effect.seeThroughMaxDepth;
            seeThroughOrdered = effect.seeThroughOrdered;
            hitFxInitialIntensity = effect.hitFxInitialIntensity;
            hitFxMode = effect.hitFxMode;
            hitFxFadeOutDuration = effect.hitFxFadeOutDuration;
            hitFxColor = effect.hitFxColor;
            hitFxRadius = effect.hitFxRadius;
        }

        private GlowPassData[] GetGlowPassesCopy(GlowPassData[] glowPasses)
        {
            if (glowPasses == null)
            {
                return new GlowPassData[0];
            }
            GlowPassData[] pd = new GlowPassData[glowPasses.Length];
            for (int k = 0; k < glowPasses.Length; k++)
            {
                pd[k].alpha = glowPasses[k].alpha;
                pd[k].color = glowPasses[k].color;
                pd[k].offset = glowPasses[k].offset;
            }
            return pd;
        }

        internal void OnValidate()
        {
            seeThroughDepthOffset = Mathf.Max(0, seeThroughDepthOffset);
            seeThroughMaxDepth = Mathf.Max(0, seeThroughMaxDepth);
            seeThroughBorderWidth = Mathf.Max(0, seeThroughBorderWidth);
            targetFXFadePower = Mathf.Max(0, targetFXFadePower);
            cameraDistanceFadeNear = Mathf.Max(0, cameraDistanceFadeNear);
            cameraDistanceFadeFar = Mathf.Max(0, cameraDistanceFadeFar);
            if (glowPasses == null || glowPasses.Length == 0)
            {
                glowPasses = new GlowPassData[4];
                glowPasses[0] = new GlowPassData() { offset = 4, alpha = 0.1f, color = new Color(0.64f, 1f, 0f, 1f) };
                glowPasses[1] = new GlowPassData() { offset = 3, alpha = 0.2f, color = new Color(0.64f, 1f, 0f, 1f) };
                glowPasses[2] = new GlowPassData() { offset = 2, alpha = 0.3f, color = new Color(0.64f, 1f, 0f, 1f) };
                glowPasses[3] = new GlowPassData() { offset = 1, alpha = 0.4f, color = new Color(0.64f, 1f, 0f, 1f) };
            }
        }
    }
}