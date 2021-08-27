namespace AstroClient
{
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using UnityEngine;

	internal class PlayerCloner
	{
		// CREDITS : Unreal (Day's one is broken and refused to stay in place)
		public static GameObject CloneLocalPlayerAvatar()
		{
			if (PlayerUtils.GetPlayer() != null)
			{
				var original = PlayerUtils.GetPlayer().GetVRCPlayer().GetAvatarManager().prop_GameObject_0;
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
			return null;
		}
	}
}