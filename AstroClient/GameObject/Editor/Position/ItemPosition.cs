namespace AstroClient
{
	using AstroClient.components;
	using AstroClient.extensions;
	using AstroClient.variables;
	using UnityEngine;
	using VRC;
	using static AstroClient.LocalPlayerUtils;

	public class ItemPosition
	{
		public static void TeleportObject(GameObject obj)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				var physic = obj.GetComponent<Rigidbody>();
				obj.transform.position = GetPlayerBoneTransform(HumanBodyBones.RightHand).position;

				KillCustomScripts(obj);
				if (physic != null)
				{
					// WIPE VELOCITY
					physic.velocity = Vector3.zero;
					physic.angularVelocity = Vector3.zero;
				}
			}
		}

		public static void TeleportObject(GameObject obj, Vector3 NewPos, bool SkipKillScripts = false)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				if (SkipKillScripts)
				{
					KillCustomScripts(obj);
				}
				obj.transform.position = NewPos;
			}
		}

		public static void TeleportObject(GameObject obj, Player player, HumanBodyBones targetbone, bool SkipKillScripts = false)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				if (SkipKillScripts)
				{
					KillCustomScripts(obj);
				}

				obj.transform.position = LocalPlayerUtils.PlayerPositionBones(player, targetbone);
				OnlineEditor.RemoveOwnerShip(obj);
			}
		}

		// KILL ( ROCKET | CRAZY | SPINNER | Attacker | Watcher | Orbit | Bouncer) COMPONENT IF PRESENT
		public static void KillCustomScripts(GameObject obj)
		{
			var rocket = obj.GetComponent<RocketObject>();
			var crazy = obj.GetComponent<CrazyObject>();
			var spinner = obj.GetComponent<ObjectSpinner>();
			var control = obj.GetComponent<RigidBodyController>();
			var bouncer = obj.GetComponent<Bouncer>();
			var watcher = obj.GetComponent<PlayerWatcher>();
			if (Bools.AllowAttackerComponent)
			{
				var attacker = obj.GetComponent<PlayerAttacker>();
				if (attacker != null)
				{
					attacker.DestroyMeLocal();
				}
			}
			if (Bools.AllowOrbitComponent)
			{
				var orbit = obj.GetComponent<Orbit>();
				if (orbit != null)
				{
					orbit.DestroyMeLocal();
				}
			}
			if (watcher != null)
			{
				watcher.DestroyMeLocal();
			}
			if (rocket != null)
			{
				rocket.DestroyMeLocal();
			}
			if (crazy != null)
			{
				crazy.DestroyMeLocal();
			}
			if (spinner != null)
			{
				spinner.DestroyMeLocal();
			}
			if(bouncer != null)
			{
				bouncer.DestroyMeLocal();
			}
			if (control != null)
			{
				control.RestoreOriginalBody();
			}
		}
	}
}