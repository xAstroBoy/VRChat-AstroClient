using System;
using System.Runtime.CompilerServices;
using AstroClient.ClientAttributes;
using AstroClient.Config;
using AstroClient.LocalAvatar.ColliderAdjuster;
using AstroClient.LocalAvatar.ScaleAdjuster;
using Il2CppSystem.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Tools.Avatars
{

    [RegisterComponent]
    internal class AvatarScaleAdjuster : MonoBehaviour
    {
        private static Vector3 vOne = Vector3.one;

        internal Vector3 originalSourceScale; 
        internal Vector3 originalTargetPsScale;
        internal Vector3 originalTargetAlScale;
        internal Transform source;
        internal Transform targetPs;
        internal Transform targetAl;
        internal Transform targetUi;
        internal Transform targetUiInverted;
        internal Transform targetVpParent;
        internal Transform targetVp;
        internal Transform targetHandParentL;
        internal Transform targetHandParentR;

        internal Transform RootFix;

        internal IKSolverVR.Locomotion vrik;
        internal float originalStep;

        internal VRCAvatarManager avatarManager;
        internal float amSingle0;
        internal float amSingle1;
        internal float amSingle3;
        internal float amSingle4;
        internal float amSingle5;
        internal float amSingle6;
        internal float amSingle7;
        
        internal Vector3 tmSV0;
        internal Vector3 tmSV1;
        internal Vector3 tmSV2;
        internal bool tmReady;
        private float lastScaleFactor = 1;

        // Some mods instantiate extra copies of local avatar. This will be always false if Unity "clones" this component
        public bool ActuallyDoThings;

        public AvatarScaleAdjuster(IntPtr obj0) : base(obj0)
        {
        }
        private static Vector3 Scale(Vector3 original, float scale)
        {
            return new Vector3
            {
                x = original.x * scale,
                y = original.y * scale,
                z = original.z * scale,
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DoScale(float scaleFactor, Vector3 originalTargetScale, Transform target)
        {
            var neededTargetScale = Scale(originalTargetScale, scaleFactor);
            target.localScale = neededTargetScale;
        }

        private void OnDestroy()
        {
            if (targetVpParent != null) targetVpParent.localScale = Vector3.one;
            if (targetHandParentL != null) targetHandParentL.localScale = Vector3.one;
            if (targetHandParentR != null) targetHandParentR.localScale = Vector3.one;
        }

        private void LateUpdate()
        {
            if (!ActuallyDoThings) return;
            if (!ConfigManager.AvatarOptions.ScalingAvatarSupportEnabled) return;
            Vector3 originalPsToAvOffset = default;
            Vector3 originalAvPosition = default;
            if (ConfigManager.AvatarOptions.FixPlayspaceCenterBias)
            {
                source.get_position_Injected(out originalAvPosition);
                targetPs.InverseTransformPoint_Injected(ref originalAvPosition, out originalPsToAvOffset);
            }

            source.get_localScale_Injected(out var sourceScale);
            var scaleFactor = sourceScale.y / originalSourceScale.y;
            DoScale(scaleFactor, originalTargetPsScale, targetPs);
            DoScale(1 / scaleFactor, originalTargetAlScale, targetAl);
            DoScale(scaleFactor, originalTargetPsScale, targetUi);
            DoScale(1 / scaleFactor / originalTargetPsScale.y, vOne, targetUiInverted);

            var scaleVector = new Vector3
            {
                x = scaleFactor,
                y = scaleFactor,
                z = scaleFactor,
            };
            targetVpParent.localScale = scaleVector;
            targetHandParentL.localScale = scaleVector;
            targetHandParentR.localScale = scaleVector;

            avatarManager.field_Private_Single_0 = amSingle0 * scaleFactor;
            avatarManager.field_Private_Single_1 = amSingle1 * scaleFactor;
            avatarManager.field_Private_Single_3 = amSingle3 * scaleFactor;
            avatarManager.field_Private_Single_4 = amSingle4 * scaleFactor;
            avatarManager.field_Private_Single_5 = amSingle5 * scaleFactor;
            avatarManager.field_Private_Single_6 = amSingle6 * scaleFactor;
            avatarManager.field_Private_Single_7 = amSingle7 * scaleFactor;

            if (!tmReady) return;
            
            VRCTrackingManager.field_Private_Static_Vector3_0 = Scale(tmSV0, scaleFactor);
            VRCTrackingManager.field_Private_Static_Vector3_1 = Scale(tmSV1, scaleFactor);
            VRCTrackingManager.field_Private_Static_Vector3_2 = Scale(tmSV2, scaleFactor);

            if (Math.Abs(scaleFactor - lastScaleFactor) > lastScaleFactor / 100)
            {
                lastScaleFactor = scaleFactor;
                targetVp.get_localPosition_Injected(out var vpOffset);
                vpOffset = Scale(vpOffset, scaleFactor); // it will be applied by VpParent scale
                ScaleAdjusterHelper.UpdateCameraOffsetForScale(vpOffset);
                vrik.footDistance = originalStep * scaleFactor;
                ScaleAdjusterHelper.FireScaleChange(source, scaleFactor);
            }

            if (ConfigManager.AvatarOptions.FixPlayspaceCenterBias)
            {
                targetPs.TransformPoint_Injected(ref originalPsToAvOffset, out var newAvPosition);
                targetPs.get_position_Injected(out var originalPsPosition);
                var newPsPosition = new Vector3
                {
                    x = originalAvPosition.x - newAvPosition.x + originalPsPosition.x,
                    y = originalPsPosition.y,
                    z = originalAvPosition.z - newAvPosition.z + originalPsPosition.z,
                };
                targetPs.position = newPsPosition;
            }
            
            ScaleAdjusterHelper.FixAvatarRootFlyingOff(RootFix);
            if (AvatarRealHeight.Adjuster != null)
            {
                if (ConfigManager.AvatarOptions.AdjustColliderOnScaleChange)
                {
                    AvatarRealHeight.Adjuster.AdjustCollider();
                }
            }

        }
    }
}