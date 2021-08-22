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
			gameObject.GetOrAddComponent<BoxCollider>().size = new Vector3(1f, 1f, 1f);
			gameObject.GetOrAddComponent<BoxCollider>().isTrigger = true;
			gameObject.GetOrAddComponent<MeshRenderer>().material.color = Ender;
			gameObject.GetOrAddComponent<Rigidbody>().useGravity = false;
			gameObject.GetOrAddComponent<Rigidbody>().drag = 0f;
			gameObject.GetOrAddComponent<Rigidbody>().angularDrag = 0.01f;
			gameObject.GetOrAddComponent<PickupController>().pickupable = true;
			gameObject.GetOrAddComponent<PickupController>().ThrowVelocityBoostScale = 5.5f;
			gameObject.GetOrAddComponent<EnderPearlBehaviour>();
			ENDER = gameObject;
		}

	}
}
