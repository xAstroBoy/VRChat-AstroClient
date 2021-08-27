﻿namespace AstroClient.Components.SitOnPlayer
{
	using AstroLibrary.Utility;
	using Blaze.Utils;
	using System;
	using UnityEngine;
	using VRC;

	public class SitOnPlayer : GameEventsBehaviour
	{
		private static Player TargetPlayer;
		private static HumanBodyBones TargetBone;
		private static GameObject Target;
		private static GameObject Self;
		public static bool IsEnabled { get; private set; } = false;
		public static float Height = 0f;

		public SitOnPlayer(IntPtr obj0) : base(obj0)
		{
		}

		public static void AttachToTarget(Player targetPlayer, HumanBodyBones targetBone)
		{
			Detach();
			Self.gameObject.GetComponent<CharacterController>().enabled = false;
			TargetPlayer = targetPlayer;
			TargetBone = targetBone;
			IsEnabled = true;
		}

		public static void Detach()
		{
			Self.gameObject.GetComponent<CharacterController>().enabled = true;
			TargetBone = HumanBodyBones.Head;
			Target = null;
			IsEnabled = false;
		}

		public void Start()
		{
			Self = gameObject;
		}

		public void LateUpdate()
		{
			if (Target == null)
			{
				Target = PositionOfBone(TargetPlayer, TargetBone).gameObject;
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

		private static Transform PositionOfBone(Player player, HumanBodyBones bone)
		{
			Transform bonePosition = player.transform;
			VRCAvatarManager avatarManager = player.GetVRCPlayer().GetAvatarManager();
			if (!avatarManager)
				return bonePosition;
			Animator animator = avatarManager.field_Private_Animator_0;
			if (!animator)
				return bonePosition;
			Transform boneTransform = animator.GetBoneTransform(bone);
			if (!boneTransform)
				return bonePosition;

			return boneTransform;
		}
	}
}