using System;
using AstroClient.Components;
using AstroLibrary.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRCSDK2;

namespace AstroClient
{
	internal class EnderPearlBehaviour : MonoBehaviour
	{

		public EnderPearlBehaviour(IntPtr ptr)
			: base(ptr)
		{
		}

		public void Start()
		{
			pickup = base.gameObject.GetComponent<PickupController>();
			body = base.gameObject.GetComponent<Rigidbody>();
			collider = base.gameObject.GetComponent<BoxCollider>();
		}

		public void Update()
		{
			Time += UnityEngine.Time.deltaTime;
			if (Time > 0.3f)
			{
				if (pickup.IsHeld)
				{
					Held = true;
				}
				if (Held)
				{
					body.useGravity = true;
					collider.isTrigger = false;
				}
				Time = 0f;
			}
		}

		public void OnDisable()
		{
			Held = false;
		}

		public void OnEnable()
		{
			Held = false;
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.transform.name.Contains("VRCPlayer"))
			{
				return;
			}
			foreach (ContactPoint contact in collision.contacts)
			{
				if (Held)
				{
					MelonLogger.Msg(contact.point.ToString() + "Point To Tp To");
					Vector3 position = new Vector3(contact.point.x, contact.point.y, contact.point.z);
					Utils.CurrentUser.gameObject.transform.position = position;
					base.gameObject.DestroyMeLocal();
				}
			}
		}

		private void OnCollisionExit(Collision other)
		{
			MelonLogger.Msg("No longer in contact with " + other.transform.name);
		}

		private void OnDestroy()
		{
			Held = false;
		}


		internal PickupController pickup { get; private set; }
		internal Rigidbody body { get; private set; }
		internal BoxCollider collider { get; private set; }
		internal static bool Held { get; private set; }
		internal static float Time { get; private set; }

	}
}
