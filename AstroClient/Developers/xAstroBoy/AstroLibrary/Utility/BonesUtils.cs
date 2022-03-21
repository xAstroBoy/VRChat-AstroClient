namespace AstroClient.xAstroBoy.Utility
{
    using UnityEngine;
    using VRC;

    internal static class BonesUtils
    {
        internal static Transform Get_Player_Bone_Transform(this Player player, HumanBodyBones bone)
        {
            return player.prop_VRCPlayerApi_0.GetBoneTransform(bone);
        }


        internal static Vector3 Get_Center_Of_Player(this Player player)
        {
            Vector3 center = player.transform.position;
            Vector3 headPos = player.Get_Player_Bone_Transform(HumanBodyBones.Head).position;
            Vector3 lFootPos = player.Get_Player_Bone_Transform(HumanBodyBones.LeftFoot).position;
            return new Vector3(center.x, headPos.y - Vector3.Distance(headPos, lFootPos) / 2f, center.z);
        }

        internal static Vector3 Get_Player_Bone_Position(this Player player, HumanBodyBones bone)
        {
            return player.Get_Player_Bone_Transform(bone).position;
        }
    }
}