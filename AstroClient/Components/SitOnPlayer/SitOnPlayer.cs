namespace AstroClient.Components
{
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
    using VRC;

    [RegisterComponent]
    public class SitOnPlayer : GameEventsBehaviour
    {
        private static Player TargetPlayer;
        private static HumanBodyBones TargetBone;
        private static GameObject Target;
        private static GameObject Self;
        internal static bool IsEnabled { get; set; } = false;
        internal static float Height { get; set; } = 0f;

        public SitOnPlayer(IntPtr obj0) : base(obj0)
        {
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

        internal void Start()
        {
            Self = gameObject;
        }

        internal void LateUpdate()
        {
            if (Target == null)
            {
                Target = BonesUtils.Get_Player_Bone_Transform(TargetPlayer, TargetBone).gameObject;
            }

            if (TargetPlayer == null)
            {
                Detach();
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                Detach();
            }

            if (Input.GetKey(KeyCode.Q))
            {
                Height -= 0.02f;
            }

            if (Input.GetKey(KeyCode.E))
            {
                Height += 0.02f;
            }

            if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
            {
                Height = 0f;
            }

            if (IsEnabled)
            {
                Self.transform.position = Target.transform.position + new Vector3(0, Height, 0);
            }
        }
    }
}