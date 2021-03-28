using AstroClient.components;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AstroClient.extensions
{
    public static class CustomComponentExtensions
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

        public static void ForceSyncPhysic(this GameObject obj)
        {
            var control = obj.GetComponent<RigidBodyController>();
            if (control == null)
            {
                control = obj.AddComponent<RigidBodyController>();
            }
            control.ForcedMode = true;
            control.EditMode = true;
            control.isKinematic = true;
        }

        public static void AddSpinForceX(this GameObject obj)
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
                        spin.ForceX = spin.ForceX + 1f;
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
                    spin.ForceX = spin.ForceX - 1f;
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

        public static void AddSpinForceY(this GameObject obj)
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
                    spin.ForceY = spin.ForceY + 1f;
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
                    spin.ForceY = spin.ForceY - 1f;
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

        public static void AddSpinForceZ(this GameObject obj)
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
                    spin.ForceZ = spin.ForceZ + 1f;
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
                    spin.ForceZ = spin.ForceZ - 1f;
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

        public static void RemoveSpinner(this GameObject obj)
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

        public static void AddRocketComponent(this List<GameObject> list, bool ShouldFloat, bool HasRelativeForce = true)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    RocketManager.AddObject(obj, ShouldFloat, HasRelativeForce);
                }
            }
        }

        public static void AddCrazyComponent(this List<GameObject> list, bool ShouldFloat)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    CrazyObjectManager.AddObject(obj, ShouldFloat);
                }
            }
        }

        public static void AddRocketComponent(this GameObject obj, bool ShouldFloat, bool HasRelativeForce = true)
        {
            if (obj != null)
            {
                RocketManager.AddObject(obj, ShouldFloat, HasRelativeForce);
            }
        }

        public static void AddCrazyComponent(this GameObject obj, bool ShouldFloat)
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
            foreach (var obj in list)
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
        }

        public static void AttackTarget(this List<GameObject> list)
        {
            foreach (var item in list)
            {
                if (item != null)
                {
                    ObjectMiscOptions.MakeObjectAttackTarget(item);
                }
            }
        }

        public static void WatchTarget(this List<GameObject> list)
        {
            foreach (var item in list)
            {
                if (item != null)
                {
                    ObjectMiscOptions.MakeObjectWatchTarget(item);
                }
            }
        }

        public static void WatchSelf(this List<GameObject> list)
        {
            foreach (var obj in list)
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
        }

        public static void OrbitSelf(this List<GameObject> list)
        {
            foreach (var obj in list)
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
        }

        public static void OrbitTarget(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    if (obj != null)
                    {
                        OrbitManager.AddOrbitObject(obj, ObjectMiscOptions.CurrentTarget);
                    }
                }
            }
        }
    }
}