using RubyButtonAPI;
using UnityEngine;
using VRC;
using VRC.Animation;
using VRC.SDKBase;
using Vector3 = UnityEngine.Vector3;

namespace AstroClient
{
    public class LocalPlayerUtils : GameEvents
    {
        public override void OnUpdate()
        {
            if (FreezePlayerOnQMOpen)
            {
                try
                {
                    if (GetPlayerCharControl() != null)
                    {
                        GetPlayerCharControl().enabled = !IsQuickMenuOpen;
                    }
                }
                catch
                {
                }
            }
            else
            {
                if(!UnfreezePlayerOnce)
                {
                    if (GetPlayerCharControl() != null)
                    {
                        if (!GetPlayerCharControl().enabled)
                        {
                            GetPlayerCharControl().enabled = true;
                        }
                    }
                    UnfreezePlayerOnce = true;
                }
                return;
            }
        }

        public override void OnLevelLoaded()
        {
            LocalMotionState = null;
            if (FreezePlayerOnQMOpenToggle != null)
            {
                FreezePlayerOnQMOpenToggle.setToggleState(FreezePlayerOnQMOpen);
            }
            UnfreezePlayerOnce = true;

        }

        public static Vector3 PlayerPositionBones(Player player, HumanBodyBones bone)
        {
            Vector3 bonePosition = player.transform.position;
            VRCAvatarManager avatarManager = player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0;
            if (!avatarManager)
                return bonePosition;
            Animator animator = avatarManager.field_Private_Animator_0;
            if (!animator)
                return bonePosition;
            Transform boneTransform = animator.GetBoneTransform(bone);
            if (!boneTransform)
                return bonePosition;
            return boneTransform.position;
        }

        public static Vector3 PositionOfBone(HumanBodyBones bone)
        {
            var player = Player.prop_Player_0;
            Vector3 bonePosition = player.transform.position;
            VRCAvatarManager avatarManager = player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0;
            if (!avatarManager)
                return bonePosition;
            Animator animator = avatarManager.field_Private_Animator_0;
            if (!animator)
                return bonePosition;
            Transform boneTransform = animator.GetBoneTransform(bone);
            if (!boneTransform)
                return bonePosition;

            return boneTransform.position;
        }

        public static Transform GetPlayerBoneTransform(HumanBodyBones bone)
        {
            var player = Player.prop_Player_0;
            Transform bonetransform = player.transform;
            VRCAvatarManager avatarManager = player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0;
            if (!avatarManager)
                return bonetransform;
            Animator animator = avatarManager.field_Private_Animator_0;
            if (!animator)
                return bonetransform;
            Transform boneTransform = animator.GetBoneTransform(bone);
            if (!boneTransform)
                return bonetransform;

            return boneTransform.transform;
        }

        public static Vector3 CenterOfPlayer()
        {
            var player = Player.prop_Player_0;
            Vector3 center = player.transform.position;
            Vector3 headPos = PositionOfBone(HumanBodyBones.Head);
            Vector3 lFootPos = PositionOfBone(HumanBodyBones.LeftFoot);

            return new Vector3(center.x, headPos.y - (Vector3.Distance(headPos, lFootPos) / 2f), center.z);
        }

        public static VRCPlayerApi GetSelfVRCPlayerApi()
        {
            return VRCPlayerApi.GetPlayerByGameObject(GetPlayerGameObject());
        }

        public static Player GetSelfPlayer()
        {
            return Player.prop_Player_0;
        }

        public static bool isPlayerGrounded()
        {
            return GetLocalPlayerAPI().IsPlayerGrounded();
        }

        public static VRCPlayer GetLocalVRCPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }

        public static VRCPlayerApi GetLocalPlayerAPI()
        {
            return GetLocalVRCPlayer().prop_VRCPlayerApi_0;
        }

        public static GameObject GetPlayerGameObject()
        {
            return GetLocalVRCPlayer().gameObject;
        }

        public static bool IsQuickMenuOpen
        {
            get
            {
                try
                {
                    return QuickMenu.prop_QuickMenu_0.prop_Boolean_0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static CharacterController GetPlayerCharControl()
        {
            try
            {
                if (GetPlayerGameObject() != null && GetLocalVRCPlayer() != null && GetPlayerGameObject().GetComponent<CharacterController>() != null)
                {
                    if (charcontrol == null)
                    {
                        return charcontrol = GetPlayerGameObject().GetComponent<CharacterController>();
                    }
                    else
                    {
                        return charcontrol;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public static CharacterController charcontrol;

        public static VRCMotionState GetPlayerVRCMotionState()
        {
            if (LocalMotionState != null)
            {
                return LocalMotionState;
            }
            else
            {
                LocalMotionState = GetPlayerGameObject().GetComponent<VRC.Animation.VRCMotionState>();
                return LocalMotionState;
            }
        }

        public static void ToggleFreezePlayerOnQMOpen()
        {
            FreezePlayerOnQMOpen = !FreezePlayerOnQMOpen;
            if (FreezePlayerOnQMOpenToggle != null)
            {
                FreezePlayerOnQMOpenToggle.setToggleState(FreezePlayerOnQMOpen);
            }
            UnfreezePlayerOnce = false;
        }

        private static bool UnfreezePlayerOnce;

        public static VRCMotionState LocalMotionState;

        public static bool FreezePlayerOnQMOpen;

        public static QMToggleButton FreezePlayerOnQMOpenToggle;
    }
}