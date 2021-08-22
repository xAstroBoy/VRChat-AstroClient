using System;
using System.Collections;
using System.Linq;
using AstroClient.Components;
using AstroLibrary.Extensions;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC.SDKBase;
using VRCSDK2;

namespace AstroClient
{
	public class AstroEnderPearl 
	{
		private static Color Ender { get; } = new Color(0f, 2f, 0f, 0.4f);

		private static GameObject ENDER;



		public static void SpawnEnderPearl()
		{
			if (ENDER != null)
			{
				UnityEngine.Object.Destroy(ENDER);
				ENDER = null;
				return;
			}
			Vector3 bonePosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightHand);
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
			gameObject.transform.position = bonePosition;
			gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			gameObject.name = "AstroEnderPearl";

			UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());

			var collider = gameObject.GetOrAddComponent<BoxCollider>();
			if(collider != null)
			{
				collider.size = new Vector3(1f, 1f, 1f);
				collider.isTrigger = true;
			}
			var renderer = gameObject.GetOrAddComponent<MeshRenderer>();
			if (renderer != null)
			{
				renderer.material.color = Ender;
			}
			var body = gameObject.GetOrAddComponent<Rigidbody>();
			if (body != null)
			{
				body.useGravity = false;
				body.drag = 0f;
				body.angularDrag = 0.01f;
			}
			var pickup = gameObject.GetOrAddComponent<PickupController>();
			if(pickup != null)
			{
				pickup.ForceComponent = true;
				pickup.pickupable = true;
				pickup.ThrowVelocityBoostScale = 5.5f;
			}

			gameObject.AddComponent<EnderPearlBehaviour>();
			ENDER = gameObject;
		}

	}
}
