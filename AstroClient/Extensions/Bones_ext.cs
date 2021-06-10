namespace AstroLibrary.Extensions
{
	using UnityEngine;
	using VRC;
	using Vector3 = UnityEngine.Vector3;

	public static class Bones_ext
	{
		public static Transform Get_Player_Bone_Transform(this Player player, HumanBodyBones bone)
		{
			Transform bonetransform = player.transform;
			VRCAvatarManager avatarManager = player.GetVRCPlayer().GetAvatarManager();
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

		public static Vector3? Get_Player_Bone_Position(this Player player, HumanBodyBones bone)
		{
			if (player != null)
			{
				return player.Get_Player_Bone_Transform(bone).position;
			}
			return null;
		}

		public static Vector3? Get_Center_Of_Player(this Player player)
		{
			Vector3 center = player.transform.position;
			var headPos = player.Get_Player_Bone_Position(HumanBodyBones.Head);
			var lFootPos = player.Get_Player_Bone_Position(HumanBodyBones.LeftFoot);
			if (headPos != null && lFootPos != null)
			{
				return new Vector3(center.x, headPos.Value.y - (Vector3.Distance(headPos.Value, lFootPos.Value) / 2f), center.z);
			}
			return null;
		}
	}
}