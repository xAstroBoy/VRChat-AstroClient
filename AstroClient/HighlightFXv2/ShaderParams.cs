using UnityEngine;

namespace AstroClient.HighlightFXv2 {

    internal static class ShaderParams {

        // general uniforms
        internal static int Cull = Shader.PropertyToID("_Cull");
        internal static int BlurScale = Shader.PropertyToID("_BlurScale");
        internal static int Speed = Shader.PropertyToID("_Speed");
        internal static int ConstantWidth = Shader.PropertyToID("_ConstantWidth");
        internal static int CutOff = Shader.PropertyToID("_CutOff");
        internal static int ZTest = Shader.PropertyToID("_ZTest");
        internal static int Flip = Shader.PropertyToID("_Flip");
        internal static int Debug = Shader.PropertyToID("_Debug");
        internal static int Color = Shader.PropertyToID("_Color");
        internal static int MainTex = Shader.PropertyToID("_MainTex");
        internal static int BlendSrc = Shader.PropertyToID("_BlendSrc");
        internal static int BlendDst = Shader.PropertyToID("_BlendDst");

        // outline uniforms
        internal static int OutlineWidth = Shader.PropertyToID("_OutlineWidth");
        internal static int OutlineZTest = Shader.PropertyToID("_OutlineZTest");
        internal static int OutlineDirection = Shader.PropertyToID("_OutlineDirection");
        internal static int OutlineColor = Shader.PropertyToID("_OutlineColor");
        internal static int OutlineVertexWidth = Shader.PropertyToID("_OutlineVertexWidth");

        // glow uniforms
        internal static int GlowZTest = Shader.PropertyToID("_GlowZTest");
        internal static int GlowStencilComp = Shader.PropertyToID("_GlowStencilComp");
        internal static int GlowStencilOp = Shader.PropertyToID("_GlowStencilOp");
        internal static int GlowDirection = Shader.PropertyToID("_GlowDirection");
        internal static int Glow = Shader.PropertyToID("_Glow");
        internal static int GlowColor = Shader.PropertyToID("_GlowColor");
        internal static int Glow2 = Shader.PropertyToID("_Glow2");

        // see-through uniforms
        internal static int SeeThrough = Shader.PropertyToID("_SeeThrough");
        internal static int SeeThroughNoise = Shader.PropertyToID("_SeeThroughNoise");
        internal static int SeeThroughBorderWidth = Shader.PropertyToID("_SeeThroughBorderWidth");
        internal static int SeeThroughBorderConstantWidth = Shader.PropertyToID("_SeeThroughBorderConstantWidth");
        internal static int SeeThroughTintColor = Shader.PropertyToID("_SeeThroughTintColor");
        internal static int SeeThroughBorderColor = Shader.PropertyToID("_SeeThroughBorderColor");
        internal static int SeeThroughStencilRef = Shader.PropertyToID("_SeeThroughStencilRef");
        internal static int SeeThroughStencilComp = Shader.PropertyToID("_SeeThroughStencilComp");
        internal static int SeeThroughStencilPassOp = Shader.PropertyToID("_SeeThroughStencilPassOp");
        internal static int SeeThroughDepthOffset = Shader.PropertyToID("_SeeThroughDepthOffset");
        internal static int SeeThroughMaxDepth = Shader.PropertyToID("_SeeThroughMaxDepth");
        internal static int SeeThroughOrdered = Shader.PropertyToID("_SeeThroughOrdered");

        // inner glow uniforms
        internal static int InnerGlowWidth = Shader.PropertyToID("_InnerGlowWidth");
        internal static int InnerGlowZTest = Shader.PropertyToID("_InnerGlowZTest");
        internal static int InnerGlowColor = Shader.PropertyToID("_InnerGlowColor");

        // overlay uniforms
        internal static int OverlayData = Shader.PropertyToID("_OverlayData");
        internal static int OverlayBackColor = Shader.PropertyToID("_OverlayBackColor");
        internal static int OverlayColor = Shader.PropertyToID("_OverlayColor");
        internal static int OverlayHitPosData = Shader.PropertyToID("_OverlayHitPosData");
        internal static int OverlayHitStartTime = Shader.PropertyToID("_OverlayHitStartTime");
        internal static int OverlayTexture = Shader.PropertyToID("_OverlayTexture");

        // target uniforms
        internal static int TargetFXRenderData = Shader.PropertyToID("_TargetFXRenderData");

        // keywords
        internal const string SKW_ALPHACLIP = "HP_ALPHACLIP";
        internal const string SKW_DEPTHCLIP = "HP_DEPTHCLIP";
        internal const string SKW_DEPTH_OFFSET = "HP_DEPTH_OFFSET";
        internal const string SKW_USES_OVERLAY_TEXTURE = "HP_USES_OVERLAY_TEXTURE";
        internal const string SKW_SEETHROUGH_ONLY_BORDER = "HP_SEETHROUGH_ONLY_BORDER";
    }
}

