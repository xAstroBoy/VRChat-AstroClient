namespace AstroClient
{
	#region Imports

	using AstroLibrary.Extensions;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;
	using Vector3 = UnityEngine.Vector3;

	#endregion Imports

	public static class LocalPlayerUtils
    {
        public static Vector3 PlayerPositionBones(Player player, HumanBodyBones bone)
        {
            Vector3 bonePosition = player.transform.position;
            VRCAvatarManager avatarManager = player.GetVRCPlayer().prop_VRCAvatarManager_0;
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
            VRCAvatarManager avatarManager = player.GetVRCPlayer().prop_VRCAvatarManager_0;
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
            VRCAvatarManager avatarManager = player.GetVRCPlayer().prop_VRCAvatarManager_0;
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
            return KeyManager.IsAuthed ? Player.prop_Player_0 : null;
        }

        public static bool IsPlayerGrounded()
        {
            return GetLocalPlayerAPI().IsPlayerGrounded();
        }

        public static VRCPlayer GetLocalVRCPlayer()
        {
            return KeyManager.IsAuthed ? VRCPlayer.field_Internal_Static_VRCPlayer_0 : null;
        }

        public static VRCPlayerApi GetLocalPlayerAPI()
        {
            return GetLocalVRCPlayer().prop_VRCPlayerApi_0;
        }

        public static GameObject GetPlayerGameObject()
        {
            return GetLocalVRCPlayer().gameObject;
        }
    }
}