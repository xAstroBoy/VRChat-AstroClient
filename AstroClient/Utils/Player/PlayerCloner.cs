﻿namespace AstroClient
{
	using AstroClient.Extensions;
	using AstroClient.Features.Player;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using VRC.SDKBase;


	class PlayerCloner
	{

		// CREDITS : Unreal (Day's one is broken and refused to stay in place)
		public static GameObject CloneLocalPlayerAvatar()
		{
			if (VRC.Core.APIUser.CurrentUser != null)
			{
				if (VRC.Core.APIUser.CurrentUser.GetPlayer() != null)
				{
					var original = VRC.Core.APIUser.CurrentUser.GetPlayer().prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_GameObject_0;
					if (original != null)
					{
						var Capsule = UnityEngine.Object.Instantiate(original, null, true);
						Animator animator = Capsule.GetComponent<Animator>();
						if (animator != null && animator.isHuman)
						{
							Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Head);
							if (boneTransform != null)
							{
								boneTransform.localScale = Vector3.one;
							}
						}
						Capsule.name = "Serialize Capsule";
						foreach (Component comp in Capsule.GetComponents<Component>())
						{
							if (!(comp is Transform) || !(comp is Renderer) || !(comp is MeshRenderer) || !(comp is Rigidbody))
							{
								UnityEngine.Object.Destroy(comp);
							}
						}
						Capsule.transform.position = original.transform.position;
						Capsule.transform.rotation = original.transform.rotation;
						return Capsule;
					}
				}
			}
			return null;
		}
	}
}