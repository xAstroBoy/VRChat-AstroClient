using UnityEngine;

namespace AstroClient.HighlightFXv2.Events;

/// <summary>
/// Triggers when target effect animation occurs
/// </summary>
/// <param name="t">A value from 0 to 1 that represent the animation time from start to end, based on target duration and start time</param>
internal delegate void OnTargetAnimatesEvent(ref Vector3 center, ref Quaternion rotation, ref Vector3 scale, float t);