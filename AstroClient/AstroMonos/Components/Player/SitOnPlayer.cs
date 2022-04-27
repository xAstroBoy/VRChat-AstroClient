namespace AstroClient.AstroMonos.Components.Player
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class SitOnPlayer : MonoBehaviour
    {
        private static Player TargetPlayer;
        private static HumanBodyBones TargetBone;
        private static GameObject Target;
        private static GameObject Self;

        public SitOnPlayer(IntPtr obj0) : base(obj0)
        {
        }

        internal static bool IsEnabled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal static float Height { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal void Start()
        {
            Self = gameObject;
        }

        internal void Update()
        {
            if (IsEnabled)
            {
                Target ??= BonesUtils.Get_Player_Bone_Transform(TargetPlayer, TargetBone).gameObject;

                if (TargetPlayer == null) Detach();

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) Detach();

                if (Input.GetKey(KeyCode.Q)) Height -= 0.02f;
                if (Input.GetKey(KeyCode.E)) Height += 0.02f;

                if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E)) Height = 0f;

                Self.transform.position = Target.transform.position + new Vector3(0, Height, 0);
            }
        }

        internal static void AttachToTarget(Player targetPlayer, HumanBodyBones targetBone)
        {
            Detach();
            Self.gameObject.GetComponent<CharacterController>().enabled = false;
            TargetPlayer = targetPlayer;
            TargetBone = targetBone;
            IsEnabled = true;
        }

        internal static void Detach()
        {
            Self.gameObject.GetComponent<CharacterController>().enabled = true;
            TargetBone = HumanBodyBones.Head;
            Target = null;
            IsEnabled = false;
        }
    }
}