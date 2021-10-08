namespace AstroClient
{
    using AstroClient.Components;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;

    internal class ObjectMiscOptions : GameEvents
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
                        ModConsole.Log($"[Orbit] Cant find user : {apiuser.displayName}");
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
                        ModConsole.Log($"[Teleport] Cant find user : {apiuser.displayName}");
                    }
                }
                else
                {
                    ModConsole.Log("ApiUser is null.");
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
                                    if(itemtwo != null)
                                {
                                    itemtwo.TargetPlayer = targetuser;
                                }
                            }
                        }
                    }
                    else
                    {
                        ModConsole.Log($"[Attacker] Cant find user : {apiuser.displayName}");
                    }
                }
                else
                {
                    ModConsole.Error("Error : ApiUser is null");
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
                        ModConsole.Log($"[Watcher] Cant find user : {apiuser.displayName}");
                    }
                }
                else
                {
                    ModConsole.Error("Error : ApiUser is null");
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
                    ModConsole.Log("[Attacker] Cant find Last Target ");
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
                    ModConsole.Log("[Attacker] Cant find Last Target ");
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
                    ModConsole.Log("[Watcher] Cant find Last Target ");
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
                    ModConsole.Error("[ORBIT] Cant find Target ");
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
                    foreach(var item in Resources.FindObjectsOfTypeAll<PlayerWatcher>())
                    {
                        if(item.TargetPlayer.GetAPIUser().Equals(apiuser))
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
                    foreach (var item in Resources.FindObjectsOfTypeAll<PlayerAttacker>())
                    {
                        if (item.TargetPlayer.GetAPIUser().Equals(apiuser))
                        {
                            item.DestroyMeLocal();
                        }
                    }
                }
            }
            catch (Exception) { }
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
                            ModConsole.DebugLog($"Analyzing Rigidbody Property of {item.name}");

                            bool hasWorkingCollider = false;
                            if (control.Rigidbody.isKinematic)
                            {
                                ModConsole.DebugLog($"Checking If a Non-trigger collider is present in {item.name}");

                                var meshcolliders = control.gameObject.GetComponentsInChildren<MeshCollider>(true);
                                if (meshcolliders.Count != 0)
                                {
                                    for (int i = 0; i < meshcolliders.Count; i++)
                                    {
                                        MeshCollider c = meshcolliders[i];
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
                                        for (int i = 0; i < Colliders.Count; i++)
                                        {
                                            Collider collider = Colliders[i];
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