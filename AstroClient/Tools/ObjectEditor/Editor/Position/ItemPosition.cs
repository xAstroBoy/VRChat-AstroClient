namespace AstroClient.Tools.ObjectEditor.Editor.Position
{
    using AstroMonos.Components.Tools;
    using Extensions;
    using Online;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Utility;

    internal class ItemPosition
    {
        internal static void TeleportObject(GameObject obj, bool ResetRigidBody = false, bool ResetPickupProperties = false)
        {
            if (obj != null && GameInstances.LocalPlayer != null)
            {
                var bonepos = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(HumanBodyBones.RightHand);
                if (bonepos != null)
                {
                    SetPosition(obj, bonepos.position, true);
                    obj.KillCustomComponents(ResetRigidBody, ResetPickupProperties);
                    obj.KillForces(true);
                }
            }
        }

        internal static Vector3 GetPosition(GameObject obj)
        { 
            var controller = obj.GetComponent<RigidBodyController>();
            if (controller != null)
            {
                if (controller.Rigidbody != null)
                {
                    return controller.position;
                }
                else
                {
                    return obj.transform.position;
                }
            }
            else
            {
               return obj.transform.position;
            }
        }

        internal static Quaternion GetRotation(GameObject obj)
        {
            var controller = obj.GetComponent<RigidBodyController>();
            if (controller != null)
            {
                if (controller.Rigidbody != null)
                {
                    return controller.rotation;
                }
                else
                {
                    return obj.transform.rotation;
                }
            }
            else
            {
                return obj.transform.rotation;
            }
        }

        internal static void SetPosition(GameObject obj, Vector3 Position, bool TakeOwnership = false)
        {
            if (TakeOwnership)
            {
                OnlineEditor.TakeObjectOwnership(obj);
            }
            var controller = obj.GetComponent<RigidBodyController>();
            if (controller != null)
            {
                if (controller.Rigidbody != null)
                {
                    controller.position = Position;
                }
                else
                {
                    obj.transform.position = Position;
                }
            }
            else
            {
                obj.transform.position = Position;
            }
        }
        internal static void SetRotation(GameObject obj, Quaternion Rotation, bool TakeOwnership = false)
        {
            if (TakeOwnership)
            {
                OnlineEditor.TakeObjectOwnership(obj);
            }
            var controller = obj.GetComponent<RigidBodyController>();
            if (controller != null)
            {
                if (controller.Rigidbody != null)
                {
                    controller.rotation = Rotation;
                }
                else
                {
                    obj.transform.rotation = Rotation;
                }
            }
            else
            {
                obj.transform.rotation = Rotation;
            }
        }

        internal static void TeleportObject(GameObject obj)
        {
            if (obj != null && GameInstances.LocalPlayer != null)
            {
                var bonepos = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(HumanBodyBones.RightHand);
                if (bonepos != null)
                {
                    SetPosition(obj, bonepos.position, true);
                    obj.KillCustomComponents(true);
                    obj.KillForces(true);
                }
            }
        }

        internal static void TeleportObject(GameObject obj, HumanBodyBones SelfBones, bool KillcustomScripts, bool KillForces)
        {
            if (obj != null && GameInstances.LocalPlayer != null)
            {
                var bonepos = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(SelfBones).position;
                if (bonepos != null)
                {
                    SetPosition(obj, bonepos, true);
                    if (KillcustomScripts)
                    {
                        obj.KillCustomComponents(true);
                    }
                    if (KillForces)
                    {
                        obj.KillForces(true);
                    }
                }
            }
        }
        internal static void TeleportObjectWithRot(GameObject obj, HumanBodyBones SelfBones, bool KillcustomScripts, bool KillForces)
        {
            if (obj != null && GameInstances.LocalPlayer != null)
            {
                var bone = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(SelfBones);
                if (bone != null)
                {
                    SetPosition(obj, bone.position, true);
                    SetRotation(obj, bone.rotation, true);
                    if (KillcustomScripts)
                    {
                        obj.KillCustomComponents(true);
                    }
                    if (KillForces)
                    {
                        obj.KillForces(true);
                    }
                }
            }
        }

        internal static void TeleportObject(GameObject obj, Vector3 NewPos, bool SkipKillScripts = false)
        {
            if (obj != null)
            {
                if (SkipKillScripts)
                {
                    obj.KillCustomComponents(true);
                }
                SetPosition(obj, NewPos, true);
            }
        }

        internal static void TeleportObject(GameObject obj, Player player, HumanBodyBones targetbone, bool SkipKillScripts = false)
        {
            if (obj != null && player != null)
            {
                var bonepos = player.Get_Player_Bone_Transform(targetbone);
                if (bonepos != null)
                {
                    OnlineEditor.TakeObjectOwnership(obj);
                    if (SkipKillScripts)
                    {
                        obj.KillCustomComponents(true);
                    }

                    SetPosition(obj, bonepos.position, true);
                   // OnlineEditor.RemoveOwnerShip(obj);
                }
            }
        }
    }
}