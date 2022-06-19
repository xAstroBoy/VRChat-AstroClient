using AstroClient.AstroMonos.Components.Tools.Avatars;
using AstroClient.ClientActions;
using AstroClient.Config;
using MelonLoader;
using RootMotion.FinalIK;
using System;
using System.Collections;
using System.Collections.Generic;
using AstroClient.Tools.Player;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDKBase;

namespace AstroClient.LocalAvatar.ScaleAdjuster
{
    internal class ScaleAdjusterHelper : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.VRChat_OnUiManagerInit += OnUiManagerInit;
            //ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnPlayerStart += OnPlayerStart;
        }

        //private void OnWorldReveal(string arg1, string arg2, List<string> arg3, string arg4, string arg5)
        //{
        //    Log.Debug("Analyzing Avatar...");

        //    GameInstances.CurrentUser.field_Private_VRCAvatarManager_0.field_Private_AvatarCreationCallback_0 += new Action<GameObject, VRC_AvatarDescriptor, bool>(OnLocalPlayerAvatarCreated);
        //    var avatar = GameInstances.CurrentUser.transform.root.Get_Avatar();
        //    if (avatar != null)
        //    {
        //        Log.Debug("Hooking into Avatar creation callback system..");
        //        OnLocalPlayerAvatarCreated(avatar.gameObject, null, false);
        //    }
        //}
        private static IEnumerator WaitForPlayerBrr(VRCPlayer player)
        {
            Log.Debug("Analyzing Player...");

            while (player != null && player.field_Private_VRCPlayerApi_0 == null)
                yield return null;

            if (player == null || !player.prop_VRCPlayerApi_0.isLocal) yield break;
            Log.Debug("Player is Local!");
            Log.Debug("Hooking into Avatar creation callback system..");
            player.field_Private_VRCAvatarManager_0.field_Private_AvatarCreationCallback_0 += new Action<GameObject, VRC_AvatarDescriptor, bool>(OnLocalPlayerAvatarCreated);
            var avatar = player.transform.FindObject("ForwardDirection/Avatar");
            if (avatar != null)
            {
                Log.Debug("Starting Coroutine on avatar..");
                OnLocalPlayerAvatarCreated(avatar.gameObject, null, false);

            }
        }

        private static void OnPlayerStart(VRCPlayer instance)
        {
            MelonCoroutines.Start(WaitForPlayerBrr(instance));
        }

        internal static VRCVrCameraSteam ourSteamCamera { get; set; }
        internal static Transform ourCameraTransform { get; set; }

        internal static void FireScaleChange(Transform avatarRoot, float newScale)
        {
            ClientEventActions.OnAvatarScaleChanged.SafetyRaiseWithParams(avatarRoot, newScale);
        }

        private void OnUiManagerInit()
        {
            foreach (var vrcTracking in VRCTrackingManager.field_Private_Static_VRCTrackingManager_0
                         .field_Private_List_1_VRCTracking_0)
            {
                var trackingSteam = vrcTracking.TryCast<VRCTrackingSteam>();
                if (trackingSteam == null) continue;

                ourSteamCamera = trackingSteam.GetComponentInChildren<VRCVrCameraSteam>();
                ourCameraTransform = trackingSteam.transform.Find("SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (eye)");

                return;
            }
        }

        internal static void UpdateCameraOffsetForScale(Vector3 offset)
        {
            ourSteamCamera.field_Private_Vector3_0 = -offset / ourSteamCamera.transform.lossyScale.x;
            if (ourCameraTransform != null)
                ourCameraTransform.localPosition = -offset / ourCameraTransform.lossyScale.x;
        }


        private static void OnLocalPlayerAvatarCreated(GameObject go, VRC_AvatarDescriptor descriptor, bool unknown)
        {
            if(go == null)
            {
                Log.Debug("Go is null");
            }
            if (go != null)
            {
                if (go.GetComponent<VRCAvatarDescriptor>() != null)
                {
                    Log.Debug("Initializing Avatar Scaling support....");

                    OnLocalPlayerAvatarCreatedImpl(go);
                }
                else
                {
                    Log.Write("Current avatar is SDK2, ignoring rescaling support");
                }
            }
        }

        internal static void FixAvatarRootFlyingOff(Transform avatarRoot)
        {
            if (!ConfigManager.AvatarOptions.FixAvatarFlyingOffOnScale) return;

            avatarRoot.get_localPosition_Injected(out var oldPos);
            oldPos.x = oldPos.z = 0;
            avatarRoot.localPosition = oldPos;
        }

        private static IEnumerator OnLocalPlayerAvatarCreatedCoro(Vector3 originalScale, GameObject go)
        {
            var trackingRoot = VRCTrackingManager.field_Private_Static_VRCTrackingManager_0.transform;
            Log.Debug("Waiting for VRCTrackingManager to unbamboozle itself....");

            // give it 3 frames for VRCTrackingManager to unbamboozle itself
            for (var i = 0; i < 3 && go != null; i++)
            {
                Log.Debug($"Funny numbers go brr: {i} {VRCTrackingManager.field_Private_Static_Vector3_0.ToString()} {VRCTrackingManager.field_Private_Static_Vector3_1.ToString()}");
                Log.Debug($"Scale stuff: a={go.transform.localScale.y} t={trackingRoot.localScale.y}");
                Log.Debug($"UI stuff: r={QuickMenuTools.UserInterface.localScale.y} u={QuickMenuTools.UnscaledUI.localScale.y}");
                yield return null;
            }
            if (go == null)
            {
                Log.Debug("Avatar is null? WUT!");
            }


            var originalTrackingRootScale = trackingRoot.localScale;

            Log.Debug($"Initialized scaling support for current avatar: avatar initial scale {originalScale.y}, tracking initial scale {originalTrackingRootScale.y}");

            var comp = go.AddComponent<AvatarScaleAdjuster>();
            comp.source = go.transform;
            comp.RootFix = comp.source.parent;
            comp.targetPs = trackingRoot;
            comp.targetAl = ourSteamCamera.GetComponentInChildren<AudioListener>().transform;
            comp.targetAl.get_localScale_Injected(out comp.originalTargetAlScale);
            comp.originalSourceScale = originalScale;
            comp.originalTargetPsScale = originalTrackingRootScale;
            comp.targetUi = QuickMenuTools.UserInterface.transform;
            comp.targetUiInverted = QuickMenuTools.UnscaledUI;

            comp.vrik = go.GetComponent<VRIK>().solver.locomotion;
            comp.originalStep = comp.vrik.footDistance;

            comp.ActuallyDoThings = true;

            var avatarManager = go.GetComponentInParent<VRCAvatarManager>();
            comp.avatarManager = avatarManager;
            comp.amSingle0 = avatarManager.field_Private_Single_0;
            comp.amSingle1 = avatarManager.field_Private_Single_1;
            comp.amSingle3 = avatarManager.field_Private_Single_3;
            comp.amSingle4 = avatarManager.field_Private_Single_4;
            comp.amSingle5 = avatarManager.field_Private_Single_5;
            comp.amSingle6 = avatarManager.field_Private_Single_6;
            comp.amSingle7 = avatarManager.field_Private_Single_7;

            comp.targetVp = avatarManager.field_Private_VRC_AnimationController_0.GetComponentInChildren<IKHeadAlignment>().transform;
            comp.targetVpParent = comp.targetVp.parent;

            // hand effector scaling is used for IKTweaks compat
            comp.targetHandParentL = avatarManager.field_Internal_IkController_0.transform.Find("LeftEffector");
            comp.targetHandParentR = avatarManager.field_Internal_IkController_0.transform.Find("RightEffector");

            comp.tmSV0 = VRCTrackingManager.field_Private_Static_Vector3_0;
            comp.tmSV1 = VRCTrackingManager.field_Private_Static_Vector3_1;
            comp.tmSV1 = VRCTrackingManager.field_Private_Static_Vector3_2;
            comp.tmReady = true;
        }

        private static void OnLocalPlayerAvatarCreatedImpl(GameObject go)
        {
            if (ConfigManager.AvatarOptions.ScalingAvatarSupportEnabled)
            {
                Log.Debug("Backupped Original scale...");
                var originalScale = go.transform.localScale;

                Log.Debug("Adding Scaling support....");

                MelonCoroutines.Start(OnLocalPlayerAvatarCreatedCoro(originalScale, go));
            }
            else
            {
                Log.Debug("Scaling Support is off!");
            }
        }
    }
}