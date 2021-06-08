namespace AstroClient
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using VRC;

	public class ObjectMiscOptions : GameEvents
    {


        public static void AllWorldPickupsOrbitsOnTarget()
        {
            try
            {
                var apiuser = QuickMenuUtils.GetSelectedUser();
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.TargetSelector.CurrentTarget = targetuser;
                        foreach (var item in WorldUtils.Get_Pickups())
                        {
                            if (item != null)
                            {
                                OrbitManager.AddOrbitObject(item, targetuser);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.Log("[Orbit] Cant find user : " + apiuser.displayName);
                    }
                }
            }
            catch (Exception) { }
        }

        public static void TeleportAllWorldPickupsToPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.GetSelectedUser();
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.TargetSelector.CurrentTarget = targetuser;
                        foreach (var item in WorldUtils.Get_Pickups())
                        {
                            try
                            {
                                if (item != null)
                                {
                                    ItemPosition.TeleportObject(item, targetuser, HumanBodyBones.Head, false);
                                }
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        ModConsole.Log("[Teleport] Cant find user : " + apiuser.displayName);
                    }
                }
                else
                {
                    ModConsole.Log("ApiUser is null.");
                }
            }
            catch (Exception) { }
        }

        public static void AllWorldPickupsAttackTarget()
        {
            try
            {
                var apiuser = QuickMenuUtils.GetSelectedUser();
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.TargetSelector.CurrentTarget = targetuser;
                        foreach (var item in WorldUtils.Get_Pickups())
                        {
                            if (item != null)
                            {
                                PlayerAttackerManager.AddObject(item, targetuser);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.Log("[Attacker] Cant find user : " + apiuser.displayName);
                    }
                }
                else
                {
                    ModConsole.Error("Error : ApiUser is null");
                }
            }
            catch (Exception) { }
        }

        public static void AllWorldPickupsWatchTarget()
        {
            try
            {
                var apiuser = QuickMenuUtils.GetSelectedUser();
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.TargetSelector.CurrentTarget = targetuser;
                        foreach (var item in WorldUtils.Get_Pickups())
                        {
                            if (item != null)
                            {
                                PlayerWatcherManager.AddObject(item, targetuser);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.Log("[Watcher] Cant find user : " + apiuser.displayName);
                    }
                }
                else
                {
                    ModConsole.Error("Error : ApiUser is null");
                }
            }
            catch (Exception) { }
        }

        public static void RemoveAttackerFromobj(GameObject obj)
        {
            if (obj != null)
            {
                var attacker = obj.GetComponent<PlayerAttacker>();
                if (attacker != null)
                {
                    attacker.DestroyMeLocal();
                }
            }
        }

        public static void RemoveWatcherFromobj(GameObject obj)
        {
            if (obj != null)
            {
                var watcher = obj.GetComponent<PlayerWatcher>();
                if (watcher != null)
                {
                    watcher.DestroyMeLocal();
                }
            }
        }

        public static void RemoveOrbitingObject(GameObject obj)
        {
            if (obj != null)
            {
                var orbit = obj.GetComponent<Orbit>();
                if (orbit != null)
                {
                    orbit.DestroyMeLocal();
                }
            }
        }

        public static void MakeHeldItemOrbitAroundTarget(GameObject obj)
        {
            try
            {
                var targetuser = TargetSelector.TargetSelector.CurrentTarget;
                if (targetuser != null)
                {
                    if (obj != null)
                    {
                        OrbitManager.AddOrbitObject(obj, targetuser);
                    }
                }
                else
                {
                    ModConsole.Log("[Attacker] Cant find Last Target ");
                }
            }
            catch (Exception) { }
        }

        public static void MakeObjectAttackTarget(GameObject obj)
        {
            try
            {
				var targetuser = TargetSelector.TargetSelector.CurrentTarget;
				if (targetuser != null)
				{
                    if (obj != null)
                    {
                        PlayerAttackerManager.AddObject(obj, targetuser);
                    }
                }
                else
                {
                    ModConsole.Log("[Attacker] Cant find Last Target ");
                }
            }
            catch (Exception) { }
        }

        public static void MakeObjectWatchTarget(GameObject obj)
        {
            try
            {
				var targetuser = TargetSelector.TargetSelector.CurrentTarget;
				if (targetuser != null)
				{
                    if (obj != null)
                    {
                        PlayerWatcherManager.AddObject(obj, targetuser);
                    }
                }
                else
                {
                    ModConsole.Log("[Watcher] Cant find Last Target ");
                }
            }
            catch (Exception) { }
        }

        public static void MakeObjectOrbitToTarget(GameObject obj)
        {
            try
            {
				var targetuser = TargetSelector.TargetSelector.CurrentTarget;
				if (targetuser != null)
				{
                    if (obj != null)
                    {
                        OrbitManager.AddOrbitObject(obj, targetuser);
                    }
                }
                else
                {
                    ModConsole.Error("[ORBIT] Cant find Target ");
                }
            }
            catch (Exception) { }
        }

        public static void RemoveAllWatchersPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.GetSelectedUser();
                if (apiuser != null)
                {
                    PlayerWatcherManager.RemovePickupsWatchersBoundToPlayer(apiuser);
                }
            }
            catch (Exception) { }
        }

        public static void RemoveAllAttackPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.GetSelectedUser();
                if (apiuser != null)
                {
                    PlayerAttackerManager.RemovePickupsAttackerBoundToPlayer(apiuser);
                }
            }
            catch (Exception) { }
        }

        public static void DisablePickupKinematic(bool useGravity)
        {
            foreach (var item in WorldUtils.Get_Pickups())
            {
                if (item != null)
                {
                    var control = item.GetOrAddComponent<RigidBodyController>();
                    if (control != null)
                    {
                        if (control.GetRigidbody() != null)
                        {
                            ModConsole.DebugLog($"Analyzing Rigidbody Property of {item.name}");

                            bool hasWorkingCollider = false;
                            if (control.GetRigidbody().isKinematic)
                            {
                                ModConsole.DebugLog($"Checking If a Non-trigger collider is present in {item.name}");

                                var meshcolliders = control.gameObject.GetComponentsInChildren<MeshCollider>(true);
                                if (meshcolliders.Count != 0)
                                {
                                    foreach (var c in meshcolliders)
                                    {
                                        if (c.enabled && c.convex)
                                        {
                                            ModConsole.DebugLog($"Found Working MeshCollider for {item.name}");

                                            if (!hasWorkingCollider)
                                            {
                                                hasWorkingCollider = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
									var Colliders = control.gameObject.GetComponentsInChildren<Collider>(true);
                                    if (Colliders.Count != 0)
                                    {
                                        foreach (var collider in Colliders)
                                        {
                                            if (collider != null)
                                            {
                                                if (!collider.isTrigger && collider.enabled)
                                                {
                                                    ModConsole.DebugLog($"Found Working Collider for {item.name}");
                                                    if (!hasWorkingCollider)
                                                    {
                                                        hasWorkingCollider = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                hasWorkingCollider = false;
                            }
                            if (hasWorkingCollider)
                            {
                                control.EditMode = true;
                                control.isKinematic = false;
                                control.useGravity = useGravity;
                            }
                        }
                    }
                }
            }
        }

        public static void RemoveAllOrbitPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.GetSelectedUser();
                if (apiuser != null)
                {
                    OrbitManager.RemoveOrbitObjectsBoundToPlayer(apiuser);
                }
            }
            catch (Exception) { }
        }

		
    }
}