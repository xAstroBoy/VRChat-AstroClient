namespace AstroLibrary.Utility
{
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using Vector3 = UnityEngine.Vector3;

    public static class BonesUtils
    {
        public static Transform Get_Player_Bone_Transform(this Player player, HumanBodyBones bone)
        {
            Transform bonetransform = player.transform;
            VRCPlayerApi VRCPlayer = player.GetVRCPlayerApi();
            if (VRCPlayer != null)
                return bonetransform;
            Transform boneTransform = VRCPlayer.GetBoneTransform(bone);
            return !boneTransform ? bonetransform : boneTransform.transform;
        }

        public static Vector3? Get_Player_Bone_Position(this Player player, HumanBodyBones bone)
        {
            return player != null ? player.Get_Player_Bone_Transform(bone).position : null;
        }

        public static Vector3? Get_Center_Of_Player(this Player player)
        {
            Vector3 center = player.transform.position;
            var headPos = player.Get_Player_Bone_Position(HumanBodyBones.Head);
            var lFootPos = player.Get_Player_Bone_Position(HumanBodyBones.LeftFoot);
            return headPos != null && lFootPos != null
                ? new Vector3(center.x, headPos.Value.y - Vector3.Distance(headPos.Value, lFootPos.Value) / 2f, center.z)
                : null;
        }
    }
}