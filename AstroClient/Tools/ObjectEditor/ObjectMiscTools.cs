namespace AstroClient.Tools.ObjectEditor
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using AstroMonos.Components.Malicious;
    using AstroMonos.Components.Malicious.Orbit;
    using AstroMonos.Components.Tools;
    using Editor.Position;
    using Extensions;
    using Extensions.Components_exts;
    using Target;
    using UnityEngine;
    using World;
    using xAstroBoy.Utility;

    internal class ObjectMiscOptions : AstroEvents
    {
        internal static void AllWorldPickupsOrbitsOnTarget()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.CurrentTarget = targetuser;
                        System.Collections.Generic.List<GameObject> list = WorldUtils_Old.Get_Pickups();
                        for (int i = 0; i < list.Count; i++)
                        {
                            GameObject item = list[i];
                            if (item != null)
                            {
                                OrbitManager_Old.AddOrbitObject(item, targetuser);
                            }
                        }
                    }
                    else
                    {
                        Log.Write($"[Orbit] Cant find user : {apiuser.displayName}");
                    }
                }
            }
            catch (Exception) { }
        }

        internal static void TeleportAllWorldPickupsToPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.CurrentTarget = targetuser;
                        System.Collections.Generic.List<GameObject> list = WorldUtils_Old.Get_Pickups();
                        for (int i = 0; i < list.Count; i++)
                        {
                            GameObject item = list[i];
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
                        Log.Write($"[Teleport] Cant find user : {apiuser.displayName}");
                    }
                }
                else
                {
                    Log.Write("ApiUser is null.");
                }
            }
            catch (Exception) { }
        }

        internal static void AllWorldPickupsAttackTarget()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.CurrentTarget = targetuser;
                        System.Collections.Generic.List<GameObject> list = WorldUtils_Old.Get_Pickups();
                        for (int i = 0; i < list.Count; i++)
                        {
                            GameObject item = list[i];
                            if (item != null)
                            {
                                var itemtwo = item.GetOrAddComponent<PlayerAttacker>();
                                if (itemtwo != null)
                                {
                                    itemtwo.TargetPlayer = targetuser;
                                }
                            }
                        }
                    }
                    else
                    {
                        Log.Write($"[Attacker] Cant find user : {apiuser.displayName}");
                    }
                }
                else
                {
                    Log.Error("Error : ApiUser is null");
                }
            }
            catch (Exception) { }
        }

        internal static void AllWorldPickupsWatchTarget()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        TargetSelector.CurrentTarget = targetuser;
                        System.Collections.Generic.List<GameObject> list = WorldUtils_Old.Get_Pickups();
                        for (int i = 0; i < list.Count; i++)
                        {
                            GameObject item = list[i];
                            var itemtwo = item.GetOrAddComponent<PlayerWatcher>();
                            if (itemtwo != null)
                            {
                                itemtwo.TargetPlayer = targetuser;
                            }
                        }
                    }
                    else
                    {
                        Log.Write($"[Watcher] Cant find user : {apiuser.displayName}");
                    }
                }
                else
                {
                    Log.Error("Error : ApiUser is null");
                }
            }
            catch (Exception) { }
        }

        internal static void RemoveAttackerFromobj(GameObject obj)
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

        internal static void RemoveWatcherFromobj(GameObject obj)
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

        internal static void RemoveOrbitingObject(GameObject obj)
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

        internal static void MakeHeldItemOrbitAroundTarget(GameObject obj)
        {
            try
            {
                var targetuser = TargetSelector.CurrentTarget;
                if (targetuser != null)
                {
                    if (obj != null)
                    {
                        OrbitManager_Old.AddOrbitObject(obj, targetuser);
                    }
                }
                else
                {
                    Log.Write("[Attacker] Cant find Last Target ");
                }
            }
            catch (Exception) { }
        }

        internal static void MakeObjectAttackTarget(GameObject obj)
        {
            try
            {
                var targetuser = TargetSelector.CurrentTarget;
                if (targetuser != null)
                {
                    if (obj != null)
                    {
                        var item = obj.GetOrAddComponent<PlayerAttacker>();
                        if (item != null)
                        {
                            item.TargetPlayer = targetuser;
                        }
                    }
                }
                else
                {
                    Log.Write("[Attacker] Cant find Last Target ");
                }
            }
            catch (Exception) { }
        }

        internal static void MakeObjectWatchTarget(GameObject obj)
        {
            try
            {
                var targetuser = TargetSelector.CurrentTarget;
                if (targetuser != null)
                {
                    if (obj != null)
                    {
                        var item = obj.GetOrAddComponent<PlayerWatcher>();
                        if (item != null)
                        {
                            item.TargetPlayer = targetuser;
                        }
                    }
                }
                else
                {
                    Log.Write("[Watcher] Cant find Last Target ");
                }
            }
            catch (Exception) { }
        }

        internal static void MakeObjectOrbitToTarget(GameObject obj)
        {
            try
            {
                var targetuser = TargetSelector.CurrentTarget;
                if (targetuser != null)
                {
                    if (obj != null)
                    {
                        OrbitManager_Old.AddOrbitObject(obj, targetuser);
                    }
                }
                else
                {
                    Log.Error("[ORBIT] Cant find Target ");
                }
            }
            catch (Exception) { }
        }

        internal static void RemoveAllWatchersPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    foreach (var pickup in WorldUtils_Old.Get_Pickups())
                    {
                        var item = pickup.GetComponent<PlayerWatcher>();
                        if (item != null)
                        {
                            item.DestroyMeLocal();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        internal static void RemoveAllAttackPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    foreach (var pickup in WorldUtils_Old.Get_Pickups())
                    {
                        var item = pickup.GetComponent<PlayerAttacker>();
                        if (item != null)
                        {
                            item.DestroyMeLocal();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        internal static void SetGravityOnWorldPickups(bool useGravity)
        {
            WorldUtils_Old.Get_Pickups().RigidBody_Set_Gravity(useGravity);
        }
        internal static void DisablePickupKinematic(bool useGravity)
        {
            System.Collections.Generic.List<GameObject> list = WorldUtils_Old.Get_Pickups();
            for (int i1 = 0; i1 < list.Count; i1++)
            {
                GameObject item = list[i1];
                if (item != null)
                {
                    var control = item.GetOrAddComponent<RigidBodyController>();
                    if (control != null)
                    {
                        if (control.Rigidbody != null)
                        {
                            Log.Debug($"Analyzing Rigidbody Property of {item.name}");

                            bool hasWorkingCollider = false;
                            if (control.Rigidbody.isKinematic)
                            {
                                Log.Debug($"Checking If a Non-trigger collider is present in {item.name}");

                                var meshcolliders = control.gameObject.GetComponentsInChildren<MeshCollider>(true);
                                if (meshcolliders.Count != 0)
                                {
                                    for (int i = 0; i < meshcolliders.Count; i++)
                                    {
                                        MeshCollider c = meshcolliders[i];
                                        if (c.enabled && c.convex)
                                        {
                                            Log.Debug($"Found Working MeshCollider for {item.name}");

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
                                        for (int i = 0; i < Colliders.Count; i++)
                                        {
                                            Collider collider = Colliders[i];
                                            if (collider != null)
                                            {
                                                if (!collider.isTrigger && collider.enabled)
                                                {
                                                    Log.Debug($"Found Working Collider for {item.name}");
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

        internal static void RemoveAllOrbitPlayer()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    OrbitManager_Old.RemoveOrbitObjectsBoundToPlayer(apiuser);
                }
            }
            catch (Exception) { }
        }
    }
}