using AstroClient.HighlightFXv2.Enums;

namespace AstroClient.HighlightFXv2.Extensions;

internal static class QualityLevelExtensions
{
    internal static bool UsesMultipleOffsets(this QualityLevel qualityLevel)
    {
        return qualityLevel == QualityLevel.Medium || qualityLevel == QualityLevel.High;
    }
}