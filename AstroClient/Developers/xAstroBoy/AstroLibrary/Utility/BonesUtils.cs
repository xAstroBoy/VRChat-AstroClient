namespace AstroClient.xAstroBoy.Utility
{
    using UnityEngine;
    using VRC;

    internal static class BonesUtils
    {
        internal static Transform Get_Player_Bone_Transform(this Player player, HumanBodyBones bone)
        {
            if (player != null)
            {
                var vrcplayerapi = player.GetVRCPlayerApi();
                if (vrcplayerapi != null)
                {
                    return vrcplayerapi.GetBoneTransform(bone);
                }
            }
            return null;
        }


        internal static Vector3? Get_Center_Of_Player(this Player player)
        {
            Vector3 center = player.transform.position;
            Vector3? headPos = player.Get_Player_Bone_Transform(HumanBodyBones.Head).position;
            Vector3? lFootPos = player.Get_Player_Bone_Transform(HumanBodyBones.LeftFoot).position;
            return headPos != null && lFootPos != null
                ? new Vector3(center.x, headPos.Value.y - Vector3.Distance(headPos.Value, lFootPos.Value) / 2f, center.z)
                : null;
        }

        internal static Vector3? Get_Player_Bone_Position(this Player player, HumanBodyBones bone)
        {
            if (player != null)
            {
                return player.Get_Player_Bone_Transform(bone).position;
            }
            return null;
        }
    }
}