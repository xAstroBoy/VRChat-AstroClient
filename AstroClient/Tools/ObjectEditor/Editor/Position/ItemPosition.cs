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
                var bonepos = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Position(HumanBodyBones.RightHand);
                if (bonepos != null)
                {
                    OnlineEditor.TakeObjectOwnership(obj);
                    var controller = obj.GetComponent<RigidBodyController>();
                    if (controller != null)
                    {
                        controller.position = bonepos.Value;

                    }
                    else
                    {
                        obj.transform.position = bonepos.Value;
                    }
                    obj.KillCustomComponents(ResetRigidBody, ResetPickupProperties);
                    obj.KillForces(true);
                }
            }
        }

        internal static void TeleportObject(GameObject obj)
        {
            if (obj != null && GameInstances.LocalPlayer != null)
            {
                var bonepos = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Position(HumanBodyBones.RightHand);
                if (bonepos != null)
                {
                    OnlineEditor.TakeObjectOwnership(obj);
                    var controller = obj.GetComponent<RigidBodyController>();
                    if (controller != null)
                    {
                        controller.position = bonepos.Value;

                    }
                    else
                    {
                        obj.transform.position = bonepos.Value;
                    }
                    obj.KillCustomComponents(true);
                    obj.KillForces(true);
                }
            }
        }

        internal static void TeleportObject(GameObject obj, HumanBodyBones SelfBones, bool KillcustomScripts, bool KillForces)
        {
            if (obj != null && GameInstances.LocalPlayer != null)
            {
                var bonepos = GameInstances.LocalPlayer.GetPlayer().Get_Player_Bone_Position(SelfBones);
                if (bonepos != null)
                {
                    OnlineEditor.TakeObjectOwnership(obj);
                    var controller = obj.GetComponent<RigidBodyController>();
                    if (controller != null)
                    {
                        controller.position = bonepos.Value;

                    }
                    else
                    {
                        obj.transform.position = bonepos.Value;
                    }

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
                    OnlineEditor.TakeObjectOwnership(obj);
                    var controller = obj.GetComponent<RigidBodyController>();
                    if (controller != null)
                    {
                        controller.position = bone.position;
                        controller.rotation = bone.rotation;

                    }
                    else
                    {
                        obj.transform.position = bone.position;
                        obj.transform.rotation = bone.rotation;
                    }
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
            if (obj != null && GameInstances.LocalPlayer != null)
            {
                OnlineEditor.TakeObjectOwnership(obj);
                if (SkipKillScripts)
                {
                    obj.KillCustomComponents(true);
                }
                obj.transform.position = NewPos;
            }
        }

        internal static void TeleportObject(GameObject obj, Player player, HumanBodyBones targetbone, bool SkipKillScripts = false)
        {
            if (obj != null && player != null)
            {
                var bonepos = player.Get_Player_Bone_Position(targetbone);
                if (bonepos != null)
                {
                    OnlineEditor.TakeObjectOwnership(obj);
                    if (SkipKillScripts)
                    {
                        obj.KillCustomComponents(true);
                    }

                    obj.transform.position = bonepos.Value;
                    OnlineEditor.RemoveOwnerShip(obj);
                }
            }
        }
    }
}