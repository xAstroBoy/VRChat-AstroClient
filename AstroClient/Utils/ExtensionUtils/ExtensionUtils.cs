using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using AstroClient.components;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using System.Reflection;
using RubyButtonAPI;
using UnityEngine.UI;
using DayClientML2.Utility.Extensions;
using AstroClient.AstroUtils.ItemTweaker;
using static AstroClient.Forces;
using VRC.SDK3.Components;
using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
    public static class ExtensionUtils
    {
        //TODO : Uhm, maybe split these for each type of extension ? Dunno.

        public static void PrintAllRigidBodySettings(this GameObject obj)
        {
            if (obj != null)
            {
                var body = obj.GetComponent<Rigidbody>();
                if (body != null)
                {
                    ModConsole.Log(obj.name + " Rigidbody Details");
                    ModConsole.Log("{");
                    ModConsole.Log("velocity " + body.velocity.ToString() + ",");
                    ModConsole.Log("angularVelocity " + body.angularVelocity.ToString() + ",");
                    ModConsole.Log("drag " + body.drag.ToString() + ",");
                    ModConsole.Log("angularDrag " + body.angularDrag.ToString() + ",");
                    ModConsole.Log("mass " + body.mass.ToString() + ",");
                    ModConsole.Log("useGravity " + body.useGravity.ToString() + ",");
                    ModConsole.Log("maxDepenetrationVelocity " + body.maxDepenetrationVelocity.ToString() + ",");
                    ModConsole.Log("isKinematic " + body.isKinematic.ToString() + ",");
                    ModConsole.Log("freezeRotation " + body.freezeRotation.ToString() + ",");
                    ModConsole.Log("constraints " + body.constraints.ToString() + ",");
                    ModConsole.Log("collisionDetectionMode " + body.collisionDetectionMode.ToString() + ",");
                    ModConsole.Log("centerOfMass " + body.centerOfMass.ToString() + ",");
                    ModConsole.Log("inertiaTensor " + body.inertiaTensor.ToString() + ",");
                    ModConsole.Log("detectCollisions " + body.detectCollisions.ToString() + ",");
                    ModConsole.Log("position " + body.position.ToString() + ",");
                    ModConsole.Log("rotation " + body.rotation.ToString() + ",");
                    ModConsole.Log("interpolation " + body.interpolation.ToString() + ",");
                    ModConsole.Log("solverIterations " + body.solverIterations.ToString() + ",");
                    ModConsole.Log("sleepThreshold " + body.sleepThreshold.ToString() + ",");
                    ModConsole.Log("maxAngularVelocity " + body.maxAngularVelocity.ToString() + ",");
                    ModConsole.Log("solverVelocityIterations " + body.solverVelocityIterations.ToString() + ",");
                    ModConsole.Log("sleepVelocity " + body.sleepVelocity.ToString() + ",");
                    ModConsole.Log("sleepAngularVelocity " + body.sleepAngularVelocity.ToString() + ",");
                    ModConsole.Log("useConeFriction " + body.useConeFriction.ToString() + ",");
                    ModConsole.Log("inertiaTensorRotation " + body.inertiaTensorRotation.ToString() + ",");
                    ModConsole.Log("solverIterationCount " + body.solverIterationCount.ToString() + ",");
                    ModConsole.Log("solverVelocityIterationCount " + body.solverVelocityIterationCount.ToString() + ",");
                    ModConsole.Log("}");
                }
                else
                {
                    ModConsole.Log("Does " + obj.name + "have a rigidbody?");
                }
            }

        }


        public static void KillForces(this GameObject obj)
        {

            RemoveForces(obj, TakeOwnership);
        }

        public static void Left(this GameObject obj)
        {
            ApplyLeftForce(obj, TakeOwnership);
        }

        public static void Right(this GameObject obj)
        {
            ApplyRightForce(obj, TakeOwnership);
        }

        public static void Foward(this GameObject obj)
        {
            ApplyFowardForce(obj, TakeOwnership);
        }

        public static void Backward(this GameObject obj)
        {
            ApplyBackwardsForce(obj, TakeOwnership);
        }

        public static void Push(this GameObject obj)
        {
            PushObject(obj, TakeOwnership);
        }

        public static void Pull(this GameObject obj)
        {
            PullObject(obj, TakeOwnership);
        }

        public static void SpinX(this GameObject obj)
        {
            SpinObjectX(obj, TakeOwnership);
        }

        public static void SpinY(this GameObject obj)
        {
            SpinObjectY(obj, TakeOwnership);
        }

        public static void SpinZ(this GameObject obj)
        {
            SpinObjectZ(obj, TakeOwnership);
        }

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
            if(control == null)
            {
                control = obj.AddComponent<RigidBodyController>();
            }
            control.ForcedMode = true;
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


        public static void AddConstraint(this GameObject obj, RigidbodyConstraints constraint)
        {

            Forces.AddConstraint(obj, constraint);
        }


        public static void RemoveConstraint(this GameObject obj, RigidbodyConstraints constraint)
        {

            Forces.RemoveConstraint(obj, constraint);
        }

        public static void Remove_all_constraints(this GameObject obj)
        {
            Forces.RemoveAllObjConstraints(obj);
        }
        public static void SetGravity(this GameObject obj, bool useGravity)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.useGravity = useGravity;
                control.isKinematic = false;
            }
        }
        public static bool GetGravity(this GameObject obj)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }

                return control.useGravity;
            }
            return false;
        }

        public static void SetGravity(this List<GameObject> GameObjects, bool useGravity)
        {
            foreach (var obj in GameObjects)
            {
                if (obj != null)
                {
                    var control = obj.GetComponent<RigidBodyController>();
                    if (control == null)
                    {
                        control = obj.AddComponent<RigidBodyController>();
                    }
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.useGravity = useGravity;
                }
            }
        }


        public static void SetKinematic(this GameObject obj, bool isKinematic)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.isKinematic = isKinematic;

            }
        }
   

    public static bool GetKinematic(this GameObject obj)
    {
        if (obj != null)
        {
            var control = obj.GetComponent<RigidBodyController>();
            if (control == null)
            {
                control = obj.AddComponent<RigidBodyController>();
            }

            return control.isKinematic;
        }
        return false;
    }


    public static void SetKinematic(this List<GameObject> GameObjects, bool isKinematic)
        {
            foreach (var obj in GameObjects)
            {
                if (obj != null)
                {
                    var control = obj.GetComponent<RigidBodyController>();
                    if (control == null)
                    {
                        control = obj.AddComponent<RigidBodyController>();
                    }
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.isKinematic = isKinematic;
                }
            }
        }

        public static void SetDetectCollision(this GameObject obj, bool DetectCollisions)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                control.DetectCollisions = DetectCollisions;

            }
        }


        public static void SetDetectCollision(this List<GameObject> GameObjects, bool DetectCollisions)
        {
            foreach (var obj in GameObjects)
            {
                if (obj != null)
                {
                    var control = obj.GetComponent<RigidBodyController>();
                    if (control == null)
                    {
                        control = obj.AddComponent<RigidBodyController>();
                    }
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.isKinematic = DetectCollisions;
                }
            }
        }

        
        public static void DestroyObject(this GameObject obj)
        {

            if (!obj.DestroyMeOnline())
            {
                obj.DestroyMeLocal();
            }
        }


        public static void AddCollider(this GameObject obj)
        {
            if (obj != null)
            {
                ColliderEditors.AddCollider(obj);
            }
        }



        public static void RegisterChildsInPath(this List<GameObject> Original, string path)
        {
            var list = GameObjectFinder.ListFind(path);
            if (list != null)
            {
                if (list.Count() != 0)
                {
                    foreach (var obj in list)
                    {
                        Original.AddGameObject(obj);
                    }
                }
            }
        }


        private static bool GetCopyOfDebugMode = false;
        private static void DebugGetCopyOf(string msg)
        {
            if (GetCopyOfDebugMode)
            {
                ModConsole.DebugWarning("GetCopyOf Debug :" + msg);
            }
        }

        private const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;

        public static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            if (comp == null) return null;
            if (other.GetType() == null) return null;
            Type type = comp.GetType();
            if (type != other.GetType()) return null; // type mis-match
            DebugGetCopyOf("GetCopyOf 1");
            List<Type> derivedTypes = new List<Type>();
            Type derived = type.BaseType;
            DebugGetCopyOf("GetCopyOf 2");

            while (derived != null)
            {
                if (derived != null)
                {
                    if (derived == typeof(MonoBehaviour))
                    {
                        break;
                    }
                    derivedTypes.Add(derived);
                    derived = derived.BaseType;
                }
            }
            DebugGetCopyOf("GetCopyOf 3");
            IEnumerable<PropertyInfo> pinfos = type.GetProperties(bindingFlags);
            foreach (Type derivedType in derivedTypes)
            {
                if (derivedType != null)
                {
                    pinfos = pinfos.Concat(derivedType.GetProperties(bindingFlags));
                }
            }
            DebugGetCopyOf("GetCopyOf 4");
            pinfos = from property in pinfos
                     where !(type == typeof(Rigidbody) && property.Name == "inertiaTensor") // Special case for Rigidbodies inertiaTensor which isn't catched for some reason.
                     where !property.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ObsoleteAttribute))
                     select property;
            DebugGetCopyOf("GetCopyOf 5");

            foreach (var pinfo in pinfos)
            {
                if (pinfo != null)
                {
                    if (pinfo.CanWrite)
                    {
                        if (pinfos.Any(e => e.Name == $"shared{char.ToUpper(pinfo.Name[0])}{pinfo.Name.Substring(1)}"))
                        {
                            continue;
                        }
                        try
                        {
                            pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                        }
                        catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                    }
                }
            }
            DebugGetCopyOf("GetCopyOf 6");

            IEnumerable<FieldInfo> finfos = type.GetFields(bindingFlags);
            DebugGetCopyOf("GetCopyOf 7");

            foreach (var finfo in finfos)
            {
                if (finfo != null)
                {
                    foreach (Type derivedType in derivedTypes)
                    {
                        if (derivedType != null)
                        {
                            if (finfos.Any(e => e.Name == $"shared{char.ToUpper(finfo.Name[0])}{finfo.Name.Substring(1)}"))
                            {
                                continue;
                            }
                            finfos = finfos.Concat(derivedType.GetFields(bindingFlags));
                        }
                    }
                }
            }
            DebugGetCopyOf("GetCopyOf 8");

            foreach (var finfo in finfos)
            {
                if (finfo != null)
                {
                    finfo.SetValue(comp, finfo.GetValue(other));
                }
            }
            DebugGetCopyOf("GetCopyOf 9");

            finfos = from field in finfos
                     where field.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ObsoleteAttribute))
                     select field;
            DebugGetCopyOf("GetCopyOf 10");
            foreach (var finfo in finfos)
            {
                if (finfo != null)
                {
                    finfo.SetValue(comp, finfo.GetValue(other));
                }
            }
            DebugGetCopyOf("GetCopyOf End");
            return comp as T;

        }

        public static T CopyComponent<T>(this GameObject go, T toAdd) where T : Component
        {
            if(go == null)
            {
                ModConsole.Log("CopyComponent GameObject Go is null");
            }
            if(toAdd == null)
            {
                ModConsole.Log("CopyComponent toAdd is null");
            }
            return go.AddComponent<T>().GetCopyOf(toAdd) as T;
        }

        public static bool CopyParticleSystemRenderer(this ParticleSystemRenderer target, ParticleSystemRenderer toCopy)
        {
            if (target != null && toCopy != null)
            {
                target.alignment = toCopy.alignment;
                target.renderMode = toCopy.renderMode;
                target.sortMode = toCopy.sortMode;
                target.lengthScale = toCopy.lengthScale;
                target.velocityScale = toCopy.velocityScale;
                target.cameraVelocityScale = toCopy.cameraVelocityScale;
                target.normalDirection = toCopy.normalDirection;
                target.shadowBias = toCopy.shadowBias;
                target.sortingFudge = toCopy.sortingFudge;
                target.maxParticleSize = toCopy.maxParticleSize;
                target.pivot = toCopy.pivot;
                target.flip = toCopy.flip;
                target.maskInteraction = toCopy.maskInteraction;
                target.trailMaterial = toCopy.trailMaterial;
                target.enableGPUInstancing = toCopy.enableGPUInstancing;
                target.allowRoll = toCopy.allowRoll;
                target.mesh = toCopy.mesh;
                target.minParticleSize = toCopy.minParticleSize;

                return true;
            }
            return false;
        }


        //public static bool CopyParticleSystemRenderer(this ParticleSystemRenderer target, ParticleSystemRenderer toCopy)
        //{
        //    if (target != null && toCopy != null)
        //    {
        //        target.alignment = toCopy.alignment;
        //        target.renderMode = toCopy.renderMode;
        //        target.sortMode = toCopy.sortMode;
        //        target.lengthScale = toCopy.lengthScale;
        //        target.velocityScale = toCopy.velocityScale;
        //        target.cameraVelocityScale = toCopy.cameraVelocityScale;
        //        target.normalDirection = toCopy.normalDirection;
        //        target.shadowBias = toCopy.shadowBias;
        //        target.sortingFudge = toCopy.sortingFudge;
        //        target.maxParticleSize = toCopy.maxParticleSize;
        //        target.pivot = toCopy.pivot;
        //        target.flip = toCopy.flip;
        //        target.maskInteraction = toCopy.maskInteraction;
        //        target.trailMaterial = toCopy.trailMaterial;
        //        target.enableGPUInstancing = toCopy.enableGPUInstancing;
        //        target.allowRoll = toCopy.allowRoll;
        //        target.mesh = toCopy.mesh;
        //        target.minParticleSize = toCopy.minParticleSize;

        //        return true;
        //    }
        //    return false;
        //}



        public static bool CopyTransform(this Transform target, Transform toCopy)
        {
            if (target != null && toCopy != null)
            {
                target.position = toCopy.position;
                target.localPosition = toCopy.localPosition;
                target.eulerAngles = toCopy.eulerAngles;
                target.localEulerAngles = toCopy.localEulerAngles;
                target.right = toCopy.right;
                target.up = toCopy.up;
                target.forward = toCopy.forward;
                target.localRotation = toCopy.localRotation;
                target.rotation = toCopy.rotation;
                target.localScale = toCopy.localScale;
                target.parent = toCopy.parent;
                target.parentInternal = toCopy.parentInternal;
                target.hasChanged = toCopy.hasChanged;
                target.hierarchyCapacity = toCopy.hierarchyCapacity;
                target.rotationOrder = toCopy.rotationOrder;
                return true;
            }
            return false;
        }

        public static void AddToWorldUtilsMenu(this GameObject obj)
        {
            if (obj != null)
            {
                ItemTweakerMain.AddToWorldUtilsMenu(obj);
            }
        }

        public static void AddToWorldUtilsMenu(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemTweakerMain.AddToWorldUtilsMenu(obj);
                }
            }
        }

        public static void RegisterCustomCollider(this GameObject obj, bool HasColliderAdded)
        {
            if (obj != null)
            {
                ColliderEditors.CustomColliderHasBeenAdded(obj, HasColliderAdded);
            }
        }

        public static void AddBoxCollider(this List<GameObject> list, Vector3 size)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ColliderEditors.AddBoxCollider(obj, size);
                }
            }
        }

        public static void RenameObject(this GameObject obj, string newname)
        {
            if (obj != null)
            {
                var oldname = obj.name;
                ModConsole.DebugLog("Renamed object : " + oldname + " to " + newname);
                obj.name = newname;
            }
        }

        public static void SetPickupTheft(this List<GameObject> list, bool DisallowTheft = false)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    Pickup.SetDisallowTheft(obj, DisallowTheft);
                }
            }
        }

        public static void SetPickupTheft(this GameObject obj, bool DisallowTheft = false)
        {
            Pickup.SetDisallowTheft(obj, DisallowTheft);
        }

        public static GameObject InstantiateObject(this GameObject obj)
        {
            if (obj != null)
            {
                return UnityEngine.Object.Instantiate(obj);
            }
            return null;
        }

        public static void CloneObject(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectCloner.CloneGameObject(obj);
            }
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

        public static void TeleportToTarget(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj, ObjectMiscOptions.CurrentTarget, HumanBodyBones.LeftHand, true);
                }
            }
        }

        public static void TeleportToMe(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj);
                }
            }
        }

        public static void TeleportToTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, ObjectMiscOptions.CurrentTarget, HumanBodyBones.LeftHand, true);
            }
        }

        public static void TeleportToMe(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj);
            }
        }


        public static void ExecuteUdonEvent(this CachedUdonEvent cachedudon)
        {
            if(cachedudon.Action != null)
            {
                cachedudon.Action.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, cachedudon.EventKey);
            }

        }


        public static void ExecuteUdonEvent(this List<CachedUdonEvent> cachedudons)
        {
            foreach (var cachedudon in cachedudons)
            {
                if (cachedudon.Action != null)
                {
                    cachedudon.Action.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, cachedudon.EventKey);
                }
            }

        }


        public static void AddString(this List<string> list, string text)
        {
            if (list != null && !string.IsNullOrEmpty((text)))
            {
                if (!list.Contains(text))
                {
                    list.Add(text);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to add string " + text + " because " + nameof(list).ToString() + " is null.");
                    return;
                }
                if (string.IsNullOrEmpty((text)))
                {
                    return;
                }
            }
        }

        public static void RemoveString(this List<string> list, string text)
        {
            if (list != null && !string.IsNullOrEmpty((text)))
            {
                if (list.Contains(text))
                {
                    list.Remove(text);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to remove string " + text + " because " + nameof(list).ToString() + " is null.");
                    return;
                }
                if (string.IsNullOrEmpty((text)))
                {
                    return;
                }
            }
        }

        public static void AddGameObject(this List<GameObject> list, GameObject obj)
        {
            if (list != null && obj != null)
            {
                if (!list.Contains(obj))
                {
                    list.Add(obj);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to add gameobject " + obj.name + " because " + nameof(list).ToString() + " is null.");
                    return;
                }
                if (obj == null)
                {
                    return;
                }
            }
        }

        public static void RegisterMurderItemEsp(this GameObject obj)
        {
            if (obj != null)
            {
                if (obj != null)
                {
                    if (!GameObjectESP.MurderESPItems.Contains(obj))
                    {
                        GameObjectESP.MurderESPItems.Add(obj);
                    }
                }
            }
        }

        public static void RegisterMurderItemEsp(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    if (!GameObjectESP.MurderESPItems.Contains(obj))
                    {
                        GameObjectESP.MurderESPItems.Add(obj);
                    }
                }
            }
        }

        public static void SetButtonToArrow(this QMSingleButton button)
        {
            button.getGameObject().GetComponent<Image>().sprite = Utils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponent<Image>().sprite;
        }

        public static void RotateButton(this QMSingleButton button, float rotation)
        {
            button.getGameObject().transform.Rotate(new Vector3(0f, 0f, rotation));
        }

        public static void RemoveGameobject(this List<GameObject> list, GameObject obj)
        {
            if (list != null && obj != null)
            {
                if (list.Contains(obj))
                {
                    list.Remove(obj);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to remove gameobject " + obj.name + " because " + nameof(list).ToString() + " is null.");
                }
                if (obj == null)
                {
                    return;
                }
            }
        }

        public static Player GetPlayer(this APIUser api)
        {
            if (WorldUtils.GetAllPlayers0() != null)
            {
                foreach (var player in WorldUtils.GetAllPlayers0())
                {
                    if (player != null)
                    {
                        if (player.prop_APIUser_0.id == api.id)
                        {
                            return player;
                        }
                    }
                }
            }
            return null;
        }

        public static void VRC_Trigger_UpdateInteractionText(this GameObject obj, string NewText)
        {
            if (obj != null)
            {
                var one = obj.GetComponentsInChildren<VRC.SDKBase.VRC_Trigger>(true);
                var two = obj.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true);

                if (one.Count() != 0)
                {
                    foreach (var child in one)
                    {
                        if (child.interactText != NewText)
                        {
                            child.interactText = NewText;
                        }
                    }
                }
                if (two.Count() != 0)
                {
                    foreach (var child in one)
                    {
                        if (child.interactText != NewText)
                        {
                            child.interactText = NewText;
                        }
                    }
                }
            }
        }

        public static void PreventOthersFromPicking(this GameObject obj, bool PreventOthersFromGrabbing)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (control != null)
                {
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.PreventOthersFromGrabbing = PreventOthersFromGrabbing;
                }
            }
        }

        public static void SetPickupOrientation(this GameObject obj, VRC_Pickup.PickupOrientation orientation)
        {
            if (obj != null)
            {
                Pickup.SetPickupOrientation(obj, orientation);
            }
        }

        public static void SetAutoHoldMode(this GameObject obj, VRC_Pickup.AutoHoldMode holdmode)
        {
            if (obj != null)
            {
                Pickup.SetAutoHoldMode(obj, holdmode);
            }
        }

        public static void SetDisallowTheft(this GameObject obj, bool DisallowTheft)
        {
            if (obj != null)
            {
                Pickup.SetDisallowTheft(obj, DisallowTheft);
            }
        }

        public static void SetPickupable(this GameObject obj, bool pickupable)
        {
            if (obj != null)
            {
                Pickup.SetPickupable(obj, pickupable);
            }
        }

        public static void SetallowManipulationWhenEquipped(this GameObject obj, bool allowManipulationWhenEquipped)
        {
            if (obj != null)
            {
                Pickup.SetallowManipulationWhenEquipped(obj, allowManipulationWhenEquipped);
            }
        }

        public static void VRC_Interactable_Click(this List<GameObject> list)
        {
            foreach (var item in list)
            {
                if (item != null)
                {
                    item.VRC_Interactable_Click();
                }
            }
        }

        public static void VRC_Interactable_Click(this GameObject obj)
        {
            bool ObjHasBeenActivated = false;
            bool TriggerHasBeenEnabled = false;
            if (obj != null)
            {
                var SDKbase = obj.GetComponent<VRC.SDKBase.VRC_Interactable>();
                var SDK2 = obj.GetComponent<VRCSDK2.VRC_Interactable>();
                var SDK3 = obj.GetComponent<VRCInteractable>();

                if (!obj.active)
                {
                    ObjHasBeenActivated = true;
                    obj.SetActive(true);
                }

                if (SDKbase != null)
                {
                    if (!SDKbase.enabled)
                    {
                        TriggerHasBeenEnabled = true;
                        SDKbase.enabled = true;
                    }

                    SDKbase.Interact();
                    if (TriggerHasBeenEnabled)
                    {
                        SDKbase.enabled = false;
                    }

                    if (ObjHasBeenActivated)
                    {
                        obj.SetActive(false);
                    }
                }
                else if (SDK2 != null)
                {
                    if (!SDK2.enabled)
                    {
                        TriggerHasBeenEnabled = true;
                        SDK2.enabled = true;
                    }

                    SDK2.Interact();
                    if (TriggerHasBeenEnabled)
                    {
                        SDK2.enabled = false;
                    }

                    if (ObjHasBeenActivated)
                    {
                        obj.SetActive(false);
                    }
                }
                else if(SDK3 != null)
                {
                    if (!SDK3.enabled)
                    {
                        TriggerHasBeenEnabled = true;
                        SDK3.enabled = true;
                    }

                    SDK3.Interact();
                    if (TriggerHasBeenEnabled)
                    {
                        SDK3.enabled = false;
                    }

                    if (ObjHasBeenActivated)
                    {
                        obj.SetActive(false);
                    }
                }
            }
        }


        public static void TriggerClick(this GameObject obj)
        {
            bool ObjHasBeenActivated = false;
            bool TriggerHasBeenEnabled = false;

            if (obj != null)
            {
                OnlineEditor.TakeObjectOwnership(obj);

                var SDKbase = obj.GetComponent<VRC.SDKBase.VRC_Trigger>();
                var SDK2 = obj.GetComponent<VRCSDK2.VRC_Trigger>();
                if (!obj.active)
                {
                    ObjHasBeenActivated = true;
                    obj.SetActive(true);
                }

                if (SDKbase != null)
                {
                    if (!SDKbase.enabled)
                    {
                        TriggerHasBeenEnabled = true;
                        SDKbase.enabled = true;
                    }

                    SDKbase.Interact();
                    if (TriggerHasBeenEnabled)
                    {
                        SDKbase.enabled = false;
                    }

                    if (ObjHasBeenActivated)
                    {
                        obj.SetActive(false);
                    }
                    OnlineEditor.RemoveOwnerShip(obj);
                }
                else if (SDK2 != null)
                {
                    if (!SDK2.enabled)
                    {
                        TriggerHasBeenEnabled = true;
                        SDK2.enabled = true;
                    }

                    SDK2.Interact();
                    if (TriggerHasBeenEnabled)
                    {
                        SDK2.enabled = false;
                    }

                    if (ObjHasBeenActivated)
                    {
                        obj.SetActive(false);
                    }

                    OnlineEditor.RemoveOwnerShip(obj);
                }
            }
        }


        public static void RestoreOriginalSettings(this GameObject obj)
        {


            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control != null)
                {
                    control.RestoreOriginalBody();
                }
            }
        }


        public static void IncreaseHoldItemScale(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectMiscOptions.IncreaseHoldItemScale(obj);
            }
        }

        public static void RestoreOriginalScaleItem(this GameObject obj)
        {

            if (obj != null)
            {
                ObjectMiscOptions.RestoreOriginalScaleItem(obj);
            }
        }

        public static void DecreaseHoldItemScale(this GameObject obj)
        {

            if (obj != null)
            {
                ObjectMiscOptions.DecreaseHoldItemScale(obj);
            }
        }




        public static void SetActiveStatus(this GameObject obj, bool SetActive)
        {

            if (obj != null)
            {
                obj.SetActive(SetActive);
                HandsUtils.UpdateCapturedButtonColor(obj.active);
            }
            if (ItemTweakerMain.ObjectActiveToggle != null)
            {
                ItemTweakerMain.ObjectActiveToggle.setToggleState(obj.active);
            }
        }

        public static bool DestroyMeOnline(this GameObject obj)
        {
            bool refreshhandutils = false;
            if (HandsUtils.GameObjectToEdit == obj)
            {
                refreshhandutils = true;
            }
            var name = obj.name;
            if (obj != null)
            {
                OnlineEditor.TakeObjectOwnership(obj);
                Networking.Destroy(obj);
            }
            if (obj != null)
            {
                ModConsole.Log("Failed To Destroy Server-side  Object :  " + obj.name, Color.Red);
                return false;
            }
            else
            {
                ModConsole.Log("Destroyed Server-side Object : " + name, Color.Green);
                if(refreshhandutils)
                {
                    HandsUtils.GameObjectToEdit = null;
                }
                return true;
            }
        }

        public static void removeCollider(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    UnityEngine.Object.DestroyImmediate(c);
                }
            }
        }

        public static void disablecolliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    c.enabled = false;
                }
            }
        }

        public static void enablecolliders(this GameObject obj)
        {
            if (obj != null)
            {
                foreach (var c in obj.GetComponentsInChildren<Collider>(true))
                {
                    c.enabled = true;
                }
                foreach (var c in obj.GetComponentsInChildren<MeshCollider>(true))
                {
                    c.enabled = true;
                    c.convex = true;
                }
            }
        }

        public static APIUser GetPlayer(this VRCHandGrasper handgrasper)
        {
            if (handgrasper != null)
            {
                var VRCPlayer = handgrasper.prop_VRCPlayer_0.GetPlayer();
                if (VRCPlayer != null)
                {
                    var ApiUser = VRCPlayer.prop_APIUser_0;
                    if (ApiUser != null)
                    {
                        return ApiUser;
                    }
                }
            }
            return null;
        }

        public static void DestroyMeLocal(this UnityEngine.Object obj)
        {
            if (obj != null)
            {
                var name = obj.name;
                if (obj != null)
                {
                    UnityEngine.Object.DestroyImmediate(obj);
                }
                if (obj != null)
                {
                    UnityEngine.Object.Destroy(obj);
                }
                if (obj != null)
                {
                    UnityEngine.Object.DestroyObject(obj);
                }
                if (obj != null)
                {
                    ModConsole.Log("Failed To Destroy Object : " + obj.name, Color.Red);
                    ModConsole.Log("Try To Destroy His GameObject in case you are trying to destroy the transform.", Color.Yellow);
                }
                else
                {
                    ModConsole.Log("Destroyed Client-side Object : " + name, Color.Green);
                }
            }
        }

        public static void ClaimOwnership(this GameObject obj)
        {
            OnlineEditor.TakeObjectOwnership(obj);
        }

        public static void DropOwnership(this GameObject obj)
        {
            OnlineEditor.RemoveOwnerShip(obj);
        }
    }
}