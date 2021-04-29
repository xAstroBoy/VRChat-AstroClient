using UnityEngine;
using VRC;
using AstroClient.extensions;

#region AstroClient Imports

using AstroClient.components;
using static AstroClient.LocalPlayerUtils;
using AstroClient.variables;

#endregion AstroClient Imports

namespace AstroClient
{
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

		// KILL ( ROCKET | CRAZY | SPINNER | Attacker | Watcher | Orbit) COMPONENT IF PRESENT
		public static void KillCustomScripts(GameObject obj)
		{
			var rocket = obj.GetComponent<RocketObject>();
			var crazy = obj.GetComponent<CrazyObject>();
			var spinner = obj.GetComponent<ObjectSpinner>();
			var control = obj.GetComponent<RigidBodyController>();
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
			var watcher = obj.GetComponent<PlayerWatcher>();
			if (watcher != null)
			{
				watcher.DestroyMeLocal();
			}
			if (rocket != null)
			{
				rocket.SelfDestroy();
			}
			if (crazy != null)
			{
				crazy.SelfDestroy();
			}
			if (spinner != null)
			{
				spinner.SelfDestroy();
			}
			if (control != null)
			{
				control.RestoreOriginalBody();
			}
		}
	}
}