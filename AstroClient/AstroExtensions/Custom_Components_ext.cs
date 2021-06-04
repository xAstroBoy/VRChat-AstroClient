using System.Linq;

namespace AstroClient.Extensions
{
	using AstroClient.Components;
	using AstroClient.variables;
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public static class Custom_Components_ext
    {
        public static void MakeRocketItemWithG(this GameObject obj)
        {
            RocketManager.AddObject(obj, false);
        }

        public static void MakeRocketItemWithoutG(this GameObject obj)
        {
            RocketManager.AddObject(obj, true);
        }

        public static void MakeRocketItemWithGAndGoUp(this GameObject obj)
        {
            RocketManager.AddObject(obj, false, false);
        }

        public static void MakeRocketItemWithoutGAndGoUp(this GameObject obj)
        {
            RocketManager.AddObject(obj, true, false);
        }

        public static void GoNutsWithGravity(this GameObject obj)
        {
            CrazyObjectManager.AddObject(obj, false);
        }

        public static void GoNutsWithoutGravity(this GameObject obj)
        {
            CrazyObjectManager.AddObject(obj, true);
        }

        //public static void ForceSyncPhysic(this GameObject obj)
        //{
        //	var control = obj.GetComponent<RigidBodyController>();
        //	if (control == null)
        //	{
        //		control = obj.AddComponent<RigidBodyController>();
        //	}
        //	control.Forced_SyncPhysic = true;
        //	control.EditMode = true;
        //	control.isKinematic = true;
        //}

        public static void Add_SpinForceX(this GameObject obj)
        {
            try
            {
                var item = obj;
                if (item != null)
                {
                    if (!ObjectSpinnerManager.ObjectSpinners.Contains(item))
                    {
                        ObjectSpinnerManager.ObjectSpinners.Add(item);
                    }
                    var spin = item.GetComponent<ObjectSpinner>();

                    if (spin != null)
                    {
                        spin.ForceX++;
                    }
                    else
                    {
                        var newspin = item.AddComponent<ObjectSpinner>();

                        if (newspin != null)
                        {
                            spin.ForceX = 1f;
                        }
                    }

                    ObjectSpinnerManager.UpdateSpinnerButton(item);
                    ObjectSpinnerManager.UpdateTimerButton(item);
                }
            }
            catch (Exception) { }
        }

        public static void SubtractSpinForceX(this GameObject obj)
        {
            try
            {
                if (!ObjectSpinnerManager.ObjectSpinners.Contains(obj))
                {
                    ObjectSpinnerManager.ObjectSpinners.Add(obj);
                }
                var spin = obj.GetComponent<ObjectSpinner>();
                if (spin != null)
                {
                    spin.ForceX--;
                }
                else
                {
                    var newspin = obj.AddComponent<ObjectSpinner>();
                    if (newspin != null)
                    {
                        spin.ForceX = 1f;
                    }
                }
                ObjectSpinnerManager.UpdateSpinnerButton(obj);
                ObjectSpinnerManager.UpdateTimerButton(obj);
            }
            catch (Exception) { }
        }

        public static void Add_SpinForceY(this GameObject obj)
        {
            try
            {
                if (!ObjectSpinnerManager.ObjectSpinners.Contains(obj))
                {
                    ObjectSpinnerManager.ObjectSpinners.Add(obj);
                }
                var spin = obj.GetComponent<ObjectSpinner>();
                if (spin != null)
                {
                    spin.ForceY++;
                }
                else
                {
                    var newspin = obj.AddComponent<ObjectSpinner>();
                    if (newspin != null)
                    {
                        spin.ForceY = 1f;
                    }
                }

                ObjectSpinnerManager.UpdateSpinnerButton(obj);
                ObjectSpinnerManager.UpdateTimerButton(obj);
            }
            catch (Exception) { }
        }

        public static void SubtractSpinForceY(this GameObject obj)
        {
            try
            {
                if (!ObjectSpinnerManager.ObjectSpinners.Contains(obj))
                {
                    ObjectSpinnerManager.ObjectSpinners.Add(obj);
                }
                var spin = obj.GetComponent<ObjectSpinner>();
                if (spin != null)
                {
                    spin.ForceY--;
                }
                else
                {
                    var newspin = obj.AddComponent<ObjectSpinner>();
                    if (newspin != null)
                    {
                        spin.ForceY = 1f;
                    }
                }
                ObjectSpinnerManager.UpdateSpinnerButton(obj);
                ObjectSpinnerManager.UpdateTimerButton(obj);
            }
            catch (Exception) { }
        }

        public static void Add_SpinForceZ(this GameObject obj)
        {
            try
            {
                if (!ObjectSpinnerManager.ObjectSpinners.Contains(obj))
                {
                    ObjectSpinnerManager.ObjectSpinners.Add(obj);
                }
                var spin = obj.GetComponent<ObjectSpinner>();
                if (spin != null)
                {
                    spin.ForceZ++;
                }
                else
                {
                    var newspin = obj.AddComponent<ObjectSpinner>();
                    if (newspin != null)
                    {
                        spin.ForceZ = 1f;
                    }
                }
                ObjectSpinnerManager.UpdateSpinnerButton(obj);
                ObjectSpinnerManager.UpdateTimerButton(obj);
            }
            catch (Exception) { }
        }

        public static void SubtractSpinForceZ(this GameObject obj)
        {
            try
            {
                if (!ObjectSpinnerManager.ObjectSpinners.Contains(obj))
                {
                    ObjectSpinnerManager.ObjectSpinners.Add(obj);
                }
                var spin = obj.GetComponent<ObjectSpinner>();
                if (spin != null)
                {
                    spin.ForceZ--;
                }
                else
                {
                    var newspin = obj.AddComponent<ObjectSpinner>();
                    if (newspin != null)
                    {
                        spin.ForceZ = 1f;
                    }
                }
                ObjectSpinnerManager.UpdateSpinnerButton(obj);
                ObjectSpinnerManager.UpdateTimerButton(obj);
            }
            catch (Exception) { }
        }

        public static void Remove_Spinner(this GameObject obj)
        {
            ObjectSpinnerManager.RemoveObject(obj);
        }

        public static void IncSpinnerSpeed(this GameObject obj)
        {
            ObjectSpinnerManager.IncreaseObjTimer(obj);
        }

        public static void DecSpinnerSpeed(this GameObject obj)
        {
            ObjectSpinnerManager.DecreaseObjTimer(obj);
        }

        public static void IncCrazySpeed(this GameObject obj)
        {
            CrazyObjectManager.IncreaseObjTimer(obj);
        }

        public static void DecCrazySpeed(this GameObject obj)
        {
            CrazyObjectManager.DecreaseObjTimer(obj);
        }

        public static void IncRocketSpeed(this GameObject obj)
        {
            RocketManager.IncreaseObjTimer(obj);
        }

        public static void DecRocketSpeed(this GameObject obj)
        {
            RocketManager.DecreaseObjTimer(obj);
        }

        public static void Add_Bounce_Component(this GameObject obj, bool BounceTowardPlayer)
        {
            if (obj != null)
            {
                Bouncer bouncer = obj.GetComponent<Bouncer>();
                if (bouncer == null)
                {
                    bouncer = obj.AddComponent<Bouncer>();
                }
                if (bouncer != null)
                {
                    bouncer.BounceTowardPlayer = BounceTowardPlayer;
                }
            }
        }

        public static void Add_Bounce_Component(this List<GameObject> list, bool BounceTowardPlayer)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                Bouncer bouncer = obj.GetComponent<Bouncer>();
                if (bouncer == null)
                {
                    bouncer = obj.AddComponent<Bouncer>();
                }

                if (bouncer != null)
                {
                    bouncer.BounceTowardPlayer = BounceTowardPlayer;
                }
            }
        }

        public static void Add_Rocket_Component(this List<GameObject> list, bool ShouldFloat, bool HasRelativeForce = true)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                RocketManager.AddObject(obj, ShouldFloat, HasRelativeForce);
            }
        }

        public static void Add_Crazy_Component(this List<GameObject> list, bool ShouldFloat)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                CrazyObjectManager.AddObject(obj, ShouldFloat);
            }
        }

        public static void Add_Rocket_Component(this GameObject obj, bool ShouldFloat, bool HasRelativeForce = true)
        {
            if (obj != null)
            {
                RocketManager.AddObject(obj, ShouldFloat, HasRelativeForce);
            }
        }

        public static void Add_Crazy_Component(this GameObject obj, bool ShouldFloat)
        {
            if (obj != null)
            {
                CrazyObjectManager.AddObject(obj, ShouldFloat);
            }
        }

        public static void AttackSelf(this GameObject obj)
        {
            if (obj != null)
            {
                var Self = LocalPlayerUtils.GetSelfPlayer();
                if (obj != null && Self != null)
                {
                    PlayerAttackerManager.AddObject(obj, Self);
                }
            }
        }

        public static void AttackTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.MakeObjectAttackTarget(obj);
            }
        }

        public static void WatchSelfPlayer(this GameObject obj)
        {
            if (obj != null)
            {
                var Self = LocalPlayerUtils.GetSelfPlayer();
                if (obj != null && Self != null)
                {
                    PlayerWatcherManager.AddObject(obj, Self);
                }
            }
        }

        public static void WatchTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.MakeObjectWatchTarget(obj);
            }
        }

        public static void OrbitSelf(this GameObject obj)
        {
            if (obj != null)
            {
                var Self = LocalPlayerUtils.GetSelfPlayer();
                if (obj != null && Self != null)
                {
                    OrbitManager.AddOrbitObject(obj, Self);
                }
            }
        }

        public static void OrbitTarget(this GameObject obj)
        {
            if (obj != null)
            {
                OrbitManager.AddOrbitObject(obj, ObjectMiscOptions.CurrentTarget);
            }
        }

        public static void AttackSelf(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                var Self = LocalPlayerUtils.GetSelfPlayer();
                if (obj != null && Self != null)
                {
                    PlayerAttackerManager.AddObject(obj, Self);
                }
            }
        }

        public static void AttackTarget(this List<GameObject> list)
        {
            foreach (var item in list.Where(item => item != null))
            {
                ObjectMiscOptions.MakeObjectAttackTarget(item);
            }
        }

        public static void WatchTarget(this List<GameObject> list)
        {
            foreach (var item in list.Where(item => item != null))
            {
                ObjectMiscOptions.MakeObjectWatchTarget(item);
            }
        }

        public static void WatchSelf(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                var Self = LocalPlayerUtils.GetSelfPlayer();
                if (obj != null && Self != null)
                {
                    PlayerWatcherManager.AddObject(obj, Self);
                }
            }
        }

        public static void OrbitSelf(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                var Self = LocalPlayerUtils.GetSelfPlayer();
                if (obj != null && Self != null)
                {
                    OrbitManager.AddOrbitObject(obj, Self);
                }
            }
        }

        public static void OrbitTarget(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null).Where(obj => obj != null))
            {
                OrbitManager.AddOrbitObject(obj, ObjectMiscOptions.CurrentTarget);
            }
        }

        public static void Remove_RocketObject_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                RocketObject RocketObject = obj.GetComponent<RocketObject>();
                if (RocketObject != null)
                {
                    RocketObject.DestroyMeLocal();
                }
            }
        }

        public static void Remove_RocketObject_Component(this GameObject obj)
        {
            if (obj != null)
            {
                RocketObject RocketObject = obj.GetComponent<RocketObject>();
                if (RocketObject != null)
                {
                    RocketObject.DestroyMeLocal();
                }
            }
        }

        public static void Remove_CrazyObject_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                CrazyObject CrazyObject = obj.GetComponent<CrazyObject>();
                if (CrazyObject != null)
                {
                    CrazyObject.DestroyMeLocal();
                }
            }
        }

        public static void Remove_CrazyObject_Component(this GameObject obj)
        {
            if (obj != null)
            {
                CrazyObject CrazyObject = obj.GetComponent<CrazyObject>();
                if (CrazyObject != null)
                {
                    CrazyObject.DestroyMeLocal();
                }
            }
        }

        public static void Remove_ObjectSpinner_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                ObjectSpinner ObjectSpinner = obj.GetComponent<ObjectSpinner>();
                if (ObjectSpinner != null)
                {
                    ObjectSpinner.DestroyMeLocal();
                }
            }
        }

        public static void Remove_ObjectSpinner_Component(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectSpinner ObjectSpinner = obj.GetComponent<ObjectSpinner>();
                if (ObjectSpinner != null)
                {
                    ObjectSpinner.DestroyMeLocal();
                }
            }
        }

        public static void Remove_Bouncer_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                Bouncer Bouncer = obj.GetComponent<Bouncer>();
                if (Bouncer != null)
                {
                    Bouncer.DestroyMeLocal();
                }
            }
        }

        public static void Remove_Bouncer_Component(this GameObject obj)
        {
            if (obj != null)
            {
                Bouncer Bouncer = obj.GetComponent<Bouncer>();
                if (Bouncer != null)
                {
                    Bouncer.DestroyMeLocal();
                }
            }
        }

        public static void Remove_PlayerWatcher_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                PlayerWatcher PlayerWatcher = obj.GetComponent<PlayerWatcher>();
                if (PlayerWatcher != null)
                {
                    PlayerWatcher.DestroyMeLocal();
                }
            }
        }

        public static void Remove_PlayerWatcher_Component(this GameObject obj)
        {
            if (obj != null)
            {
                PlayerWatcher PlayerWatcher = obj.GetComponent<PlayerWatcher>();
                if (PlayerWatcher != null)
                {
                    PlayerWatcher.DestroyMeLocal();
                }
            }
        }

        public static void Remove_PlayerAttacker_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                PlayerAttacker PlayerAttacker = obj.GetComponent<PlayerAttacker>();
                if (PlayerAttacker != null)
                {
                    PlayerAttacker.DestroyMeLocal();
                }
            }
        }

        public static void Remove_PlayerAttacker_Component(this GameObject obj)
        {
            if (obj != null)
            {
                PlayerAttacker PlayerAttacker = obj.GetComponent<PlayerAttacker>();
                if (PlayerAttacker != null)
                {
                    PlayerAttacker.DestroyMeLocal();
                }
            }
        }

        public static void Remove_Orbit_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                Orbit Orbit = obj.GetComponent<Orbit>();
                if (Orbit != null)
                {
                    Orbit.DestroyMeLocal();
                }
            }
        }

        public static void Remove_Orbit_Component(this GameObject obj)
        {
            if (obj != null)
            {
                Orbit Orbit = obj.GetComponent<Orbit>();
                if (Orbit != null)
                {
                    Orbit.DestroyMeLocal();
                }
            }
        }

        public static void KillCustomComponents(this List<GameObject> list, bool ResetRigidBody)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                obj.KillCustomComponents(ResetRigidBody);
            }
        }

        // KILL ( ROCKET | CRAZY | SPINNER | Attacker | Watcher | Orbit | Bouncer) COMPONENT IF PRESENT
        public static void KillCustomComponents(this GameObject obj, bool ResetRigidBody = false, bool ResetPickupProperties = false)
        {
            if (obj != null)
            {
                var rocket = obj.GetComponent<RocketObject>();
                var crazy = obj.GetComponent<CrazyObject>();
                var spinner = obj.GetComponent<ObjectSpinner>();
                var control = obj.GetComponent<RigidBodyController>();
                var bouncer = obj.GetComponent<Bouncer>();
                var watcher = obj.GetComponent<PlayerWatcher>();
                var PickupController = obj.GetComponent<PickupController>();
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
                if (bouncer != null)
                {
                    bouncer.DestroyMeLocal();
                }
                if (ResetRigidBody)
                {
                    if (control != null)
                    {
                        control.RestoreOriginalBody();
                    }
                }
                if (ResetPickupProperties)
                {
                    if (PickupController != null)
                    {
                        PickupController.RestoreOriginalProperties();
                    }
                }
            }
        }
    }
}