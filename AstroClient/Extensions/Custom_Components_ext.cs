namespace AstroLibrary.Extensions
{
    using AstroClient;
    using AstroClient.Components;
    using AstroClient.Variables;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    internal static class Custom_Components_ext
    {
        internal static void MakeRocketItemWithG(this GameObject obj)
        {
            obj.GetOrAddComponent<RocketBehaviour>().UseGravity = true;
        }

        internal static void MakeRocketItemWithoutG(this GameObject obj)
        {
            obj.GetOrAddComponent<RocketBehaviour>().UseGravity = false;
        }

        internal static void MakeRocketItemWithGAndGoUp(this GameObject obj)
        {
           var rocket = obj.GetOrAddComponent<RocketBehaviour>();
            rocket.UseGravity = true;
            rocket.ShouldBeAlwaysUp = true;
        }

        internal static void MakeRocketItemWithoutGAndGoUp(this GameObject obj)
        {
            var rocket = obj.GetOrAddComponent<RocketBehaviour>();
            rocket.UseGravity = false;
            rocket.ShouldBeAlwaysUp = true;
        }

        internal static void GoNutsWithGravity(this GameObject obj)
        {
            var item = obj.GetOrAddComponent<CrazyBehaviour>();
            item.UseGravity = true;
        }

        internal static void GoNutsWithoutGravity(this GameObject obj)
        {
            var item = obj.GetOrAddComponent<CrazyBehaviour>();
            item.UseGravity = false;
        }

        internal static void Add_SpinForceX(this GameObject obj)
        {
            try
            {
                var item = obj;
                SpinnerBehaviour instance = null;
                if (item != null)
                {
                    instance = item.GetComponent<SpinnerBehaviour>();

                    if (instance != null)
                    {
                        instance.ForceX++;
                    }
                    else
                    {
                        instance = item.AddComponent<SpinnerBehaviour>();
                        if (instance != null)
                        {
                            instance.ForceX = 1f;
                        }
                    }
                }
                if(item.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }
            }
            catch (Exception) { }
        }

        internal static void SubtractSpinForceX(this GameObject obj)
        {
            try
            {
                SpinnerBehaviour instance = obj.GetComponent<SpinnerBehaviour>();
                if (instance != null)
                {
                    instance.ForceX--;
                }
                else
                {
                    var newspin = obj.AddComponent<SpinnerBehaviour>();
                    if (newspin != null)
                    {
                        instance.ForceX = 1f;
                    }
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void Add_SpinForceY(this GameObject obj)
        {
            try
            {
                SpinnerBehaviour instance = obj.GetComponent<SpinnerBehaviour>();
                if (instance != null)
                {
                    instance.ForceY++;
                }
                else
                {
                    instance = obj.AddComponent<SpinnerBehaviour>();
                    if (instance != null)
                    {
                        instance.ForceY = 1f;
                    }
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void SubtractSpinForceY(this GameObject obj)
        {
            try
            {
                SpinnerBehaviour instance = obj.GetComponent<SpinnerBehaviour>();
                if (instance != null)
                {
                    instance.ForceY--;
                }
                else
                {
                    instance = obj.AddComponent<SpinnerBehaviour>();
                    if (instance != null)
                    {
                        instance.ForceY = 1f;
                    }
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void Add_SpinForceZ(this GameObject obj)
        {
            try
            {
                SpinnerBehaviour instance = obj.GetComponent<SpinnerBehaviour>();
                if (instance != null)
                {
                    instance.ForceZ++;
                }
                else
                {
                    instance = obj.AddComponent<SpinnerBehaviour>();
                    if (instance != null)
                    {
                        instance.ForceZ = 1f;
                    }
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void SubtractSpinForceZ(this GameObject obj)
        {
            try
            {
                SpinnerBehaviour instance = obj.GetComponent<SpinnerBehaviour>();
                if (instance != null)
                {
                    instance.ForceZ--;
                }
                else
                {
                    var newspin = obj.AddComponent<SpinnerBehaviour>();
                    if (newspin != null)
                    {
                        instance.ForceZ = 1f;
                    }
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void Remove_Spinner(this GameObject obj)
        {
            var item = obj.GetComponent<SpinnerBehaviour>();
            if (item != null)
            {
                UnityEngine.Object.Destroy(item);
            }
        }

        internal static void IncSpinnerSpeed(this GameObject obj)
        {
            try
            {
                SpinnerBehaviour instance = obj.GetOrAddComponent<SpinnerBehaviour>();
                if (instance != null)
                {
                    instance.SpinnerTimer++;
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void DecSpinnerSpeed(this GameObject obj)
        {
            try
            {
                SpinnerBehaviour instance = obj.GetOrAddComponent<SpinnerBehaviour>();
                if (instance != null)
                {
                    instance.SpinnerTimer--;
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void IncCrazySpeed(this GameObject obj)
        {
            try
            {
                CrazyBehaviour instance = obj.GetOrAddComponent<CrazyBehaviour>();
                if (instance != null)
                {
                    instance.CrazyTimer++;
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void DecCrazySpeed(this GameObject obj)
        {
            try
            {
                CrazyBehaviour instance = obj.GetOrAddComponent<CrazyBehaviour>();
                if (instance != null)
                {
                    instance.CrazyTimer--;
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void IncRocketSpeed(this GameObject obj)
        {
            try
            {
                RocketBehaviour instance = obj.GetOrAddComponent<RocketBehaviour>();
                if (instance != null)
                {
                    instance.RocketTimer++;
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void DecRocketSpeed(this GameObject obj)
        {
            try
            {
                RocketBehaviour instance = obj.GetOrAddComponent<RocketBehaviour>();
                if (instance != null)
                {
                    instance.RocketTimer--;
                }
                if (instance.isCurrentObjectToEdit())
                {
                    instance.FocusOnTweaker();
                }

            }
            catch (Exception) { }
        }

        internal static void Add_Rocket_Component(this List<GameObject> list, bool UseGravity, bool ShouldBeAlwaysUp = true)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                try
                {
                    RocketBehaviour item = obj.AddComponent<RocketBehaviour>();
                    if (item != null)
                    {
                        item.UseGravity = UseGravity;
                        item.ShouldBeAlwaysUp = ShouldBeAlwaysUp;
                    }
                    if (item.isCurrentObjectToEdit())
                    {
                        item.FocusOnTweaker();
                    }

                }
                catch (Exception) { }

            }
        }

        internal static void Add_Crazy_Component(this List<GameObject> list, bool UseGravity)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                var item = obj.AddComponent<CrazyBehaviour>();
                if (item != null)
                {
                    item.UseGravity = UseGravity;
                }
            }
        }

        internal static void Add_Rocket_Component(this GameObject obj, bool UseGravity, bool ShouldBeAlwaysUp = true)
        {
            if (obj != null)
            {
                var item = obj.AddComponent<RocketBehaviour>();
                if (item != null)
                {
                    item.UseGravity = UseGravity;
                    item.ShouldBeAlwaysUp = ShouldBeAlwaysUp;
                }
                if (item.isCurrentObjectToEdit())
                {
                    item.FocusOnTweaker();
                }

            }
        }

        internal static void Add_Crazy_Component(this GameObject obj, bool UseGravity)
        {
            if (obj != null)
            {
                var item = obj.AddComponent<CrazyBehaviour>();
                if (item != null)
                {
                    item.UseGravity = UseGravity;
                }
                if (item.isCurrentObjectToEdit())
                {
                    item.FocusOnTweaker();
                }

            }
        }

        internal static void AttackSelf(this GameObject obj)
        {
            if (obj != null)
            {
                var Self = Utils.LocalPlayer.GetPlayer();
                if (obj != null && Self != null)
                {
                    PlayerAttackerManager.AddObject(obj, Self);
                }
            }
        }

        internal static void AttackTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.MakeObjectAttackTarget(obj);
            }
        }

        internal static void WatchSelfPlayer(this GameObject obj)
        {
            if (obj != null)
            {
                var Self = Utils.LocalPlayer.GetPlayer();
                if (obj != null && Self != null)
                {
                    PlayerWatcherManager.AddObject(obj, Self);
                }
            }
        }

        internal static void WatchTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.MakeObjectWatchTarget(obj);
            }
        }

        internal static void OrbitSelf(this GameObject obj)
        {
            if (obj != null)
            {
                var Self = Utils.LocalPlayer.GetPlayer();
                if (obj != null && Self != null)
                {
                    OrbitManager_Old.AddOrbitObject(obj, Self);
                }
            }
        }

        internal static void OrbitTarget(this GameObject obj)
        {
            if (obj != null)
            {
                OrbitManager_Old.AddOrbitObject(obj, TargetSelector.CurrentTarget);
            }
        }

        internal static void AttackSelf(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                var Self = Utils.LocalPlayer.GetPlayer();
                if (obj != null && Self != null)
                {
                    PlayerAttackerManager.AddObject(obj, Self);
                }
            }
        }

        internal static void AttackTarget(this List<GameObject> list)
        {
            foreach (var item in list.Where(item => item != null))
            {
                ObjectMiscOptions.MakeObjectAttackTarget(item);
            }
        }

        internal static void WatchTarget(this List<GameObject> list)
        {
            foreach (var item in list.Where(item => item != null))
            {
                ObjectMiscOptions.MakeObjectWatchTarget(item);
            }
        }

        internal static void WatchSelf(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                var Self = Utils.LocalPlayer.GetPlayer();
                if (obj != null && Self != null)
                {
                    PlayerWatcherManager.AddObject(obj, Self);
                }
            }
        }

        internal static void OrbitSelf(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                var Self = Utils.LocalPlayer.GetPlayer();
                if (obj != null && Self != null)
                {
                    OrbitManager_Old.AddOrbitObject(obj, Self);
                }
            }
        }

        internal static void OrbitTarget(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null).Where(obj => obj != null))
            {
                OrbitManager_Old.AddOrbitObject(obj, TargetSelector.CurrentTarget);
            }
        }

        internal static void Remove_RocketObject_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                RocketBehaviour RocketObject = obj.GetComponent<RocketBehaviour>();
                if (RocketObject != null)
                {
                    RocketObject.DestroyMeLocal();
                }
            }
        }

        internal static void Remove_RocketObject_Component(this GameObject obj)
        {
            if (obj != null)
            {
                RocketBehaviour RocketObject = obj.GetComponent<RocketBehaviour>();
                if (RocketObject != null)
                {
                    RocketObject.DestroyMeLocal();
                }
            }
        }

        internal static void Remove_CrazyObject_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                CrazyBehaviour CrazyObject = obj.GetComponent<CrazyBehaviour>();
                if (CrazyObject != null)
                {
                    CrazyObject.DestroyMeLocal();
                }
            }
        }

        internal static void Remove_CrazyObject_Component(this GameObject obj)
        {
            if (obj != null)
            {
                CrazyBehaviour CrazyObject = obj.GetComponent<CrazyBehaviour>();
                if (CrazyObject != null)
                {
                    CrazyObject.DestroyMeLocal();
                }
            }
        }

        internal static void Remove_SpinnerBehaviour_Component(this List<GameObject> list)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                SpinnerBehaviour SpinnerBehaviour = obj.GetComponent<SpinnerBehaviour>();
                if (SpinnerBehaviour != null)
                {
                    SpinnerBehaviour.DestroyMeLocal();
                }
            }
        }

        internal static void Remove_SpinnerBehaviour_Component(this GameObject obj)
        {
            if (obj != null)
            {
                SpinnerBehaviour SpinnerBehaviour = obj.GetComponent<SpinnerBehaviour>();
                if (SpinnerBehaviour != null)
                {
                    SpinnerBehaviour.DestroyMeLocal();
                }
            }
        }

        internal static void Remove_PlayerWatcher_Component(this List<GameObject> list)
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

        internal static void Remove_PlayerWatcher_Component(this GameObject obj)
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

        internal static void Remove_PlayerAttacker_Component(this List<GameObject> list)
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

        internal static void Remove_PlayerAttacker_Component(this GameObject obj)
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

        internal static void Remove_Orbit_Component(this List<GameObject> list)
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

        internal static void Remove_Orbit_Component(this GameObject obj)
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

        internal static void KillCustomComponents(this List<GameObject> list, bool ResetRigidBody)
        {
            foreach (var obj in list.Where(obj => obj != null))
            {
                obj.KillCustomComponents(ResetRigidBody);
            }
        }

        // KILL ( ROCKET | CRAZY | SPINNER | Attacker | Watcher | Orbit | Bouncer) COMPONENT IF PRESENT
        internal static void KillCustomComponents(this GameObject obj, bool ResetRigidBody = false, bool ResetPickupProperties = false)
        {
            if (obj != null)
            {
                var rocket = obj.GetComponent<RocketBehaviour>();
                var crazy = obj.GetComponent<CrazyBehaviour>();
                var spinner = obj.GetComponent<SpinnerBehaviour>();
                var control = obj.GetComponent<RigidBodyController>();
                var bouncer = obj.GetComponent<Bouncer>();
                var watcher = obj.GetComponent<PlayerWatcher>();
                var PickupController = obj.GetComponent<PickupController>();
                var StretchyCheese = obj.GetComponent<StretchyCheeseBehaviour>();
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
                if (StretchyCheese != null)
                {
                    StretchyCheese.DestroyMeLocal();
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
                        PickupController.RestoreProperties();
                    }
                }
            }
        }
    }
}