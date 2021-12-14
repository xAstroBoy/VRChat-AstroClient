namespace AstroClient.Tools.AvatarPreviewUtils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Tools;
    using Extensions;
    using Extensions.Components_exts;
    using UnityEngine;
    using UnityStandardAssets.Utility;
    using VRC;
    using VRC.Core;
    using VRC.SDK3.Avatars.Components;
    using VRC.SDKBase;
    using xAstroBoy;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;
    using Object = UnityEngine.Object;

    internal class AvatarPreviewer : AstroEvents
    {
        internal override void OnRoomLeft()
        {
            SpawnedPreviewAvatars.Clear();
            AvatarsPreviewsHolder.DestroyMeLocal();
        }

        internal static List<Transform> SpawnedPreviewAvatars = new List<Transform>();
        private static GameObject _AvatarsPreviewsHolder;
        internal static GameObject AvatarsPreviewsHolder
        {
            get
            {
                if (_AvatarsPreviewsHolder == null)
                {
                    _AvatarsPreviewsHolder = new GameObject("AstroClient Avatar Preview Holder");
                }
                return _AvatarsPreviewsHolder;
            }
        }


        internal static void ClonePreviewAvatar()
        {
            if (CurrentPreviewedAvatar != null)
            {
                var PreviewedAvatar = Object.Instantiate(CurrentPreviewedAvatar, AvatarsPreviewsHolder.transform, false);
                if (PreviewedAvatar != null)
                {
                    PreviewedAvatar.GetComponentInChildren<AutoMoveAndRotate>().DestroyMeLocal();
                    PreviewedAvatar.GetComponentInChildren<MonoBehaviourPrivateObUnique>().DestroyMeLocal();
                    PreviewedAvatar.GetComponentInChildren<PipelineManager>().DestroyMeLocal();
                    PreviewedAvatar.GetComponentInChildren<VRCAvatarDescriptor>().DestroyMeLocal();
                    PreviewedAvatar.GetComponentInChildren<VRC_AvatarDescriptor>().DestroyMeLocal();
                    PreviewedAvatar.GetComponentInChildren<VRCSDK2.VRC_AvatarDescriptor>().DestroyMeLocal();
                    PreviewedAvatar.gameObject.TeleportToMe(HumanBodyBones.RightFoot, false, false);
                    PreviewedAvatar.gameObject.AddToWorldUtilsMenu(); // In case I want to mess with it in the tweaker :)
                    SpawnedPreviewAvatars.Add(PreviewedAvatar);

                    foreach (var item in PreviewedAvatar.Get_All_Childs()) 
                    {
                        item.gameObject.layer = 0; // Fix and remove The Layer Override, then Attempt to fix the unload mechanism when switching to a different avatar.
                        //foreach (var mat in item.GetComponentsInChildren<Material>(true))
                        //{
                        //    PreventMaterialDestruction(mat);
                        //}
                        //foreach (var tex in item.GetComponentsInChildren<Texture>(true))
                        //{
                        //    PreventTextureDestruction(tex);
                        //}
                        //foreach (var tex in item.GetComponentsInChildren<Texture2D>(true))
                        //{
                        //    PreventTexture2DDestruction(tex);
                        //}
                        //foreach (var tex in item.GetComponentsInChildren<Texture3D>(true))
                        //{
                        //    PreventTexture3DDestruction(tex);
                        //}
                        foreach (var rend in item.GetComponentsInChildren<Renderer>(true))
                        {
                            if (rend != null)
                            {
                                PreventMaterialDestruction(rend.material);
                                foreach (var materials in rend.materials)
                                {
                                    PreventMaterialDestruction(materials);
                                }
                            }
                        }
                    }

                    PreviewedAvatar.GetOrAddComponent<RigidBodyController>().Forced_Rigidbody = true;
                    PreviewedAvatar.gameObject.RigidBody_Override_isKinematic(true);
                    PreviewedAvatar.gameObject.Pickup_Set_ForceComponent(true);
                    PreviewedAvatar.gameObject.Pickup_Set_Pickupable(true);
                    var coll = PreviewedAvatar.GetOrAddComponent<SphereCollider>();
                    Physics.IgnoreCollision(GameInstances.LocalPlayer.gameObject.GetComponent<Collider>(), coll);

                }
            }

        }
        private static void PreventTexture3DDestruction(Texture3D tex)
        {
            try
            {
                if (tex != null)
                {
                    tex.hideFlags = HideFlags.DontUnloadUnusedAsset;
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private static void PreventTexture2DDestruction(Texture2D tex)
        {
            try
            {
                if (tex != null)
                {
                    tex.hideFlags = HideFlags.DontUnloadUnusedAsset;
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private static void PreventTextureDestruction(Texture tex)
        {
            try
            {
                if (tex != null)
                {
                    tex.hideFlags = HideFlags.DontUnloadUnusedAsset;
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private static void PreventMaterialDestruction(Material mat)
        {
            try
            {
                if (mat != null)
                {
                    mat.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    if (mat.mainTexture != null)
                    {
                        mat.mainTexture.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    if (mat.shader != null)
                    {
                        mat.shader.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

                    var textures = mat.GetTexturePropertyNames();
                    if (textures != null && textures.Count != 0)
                    {
                        foreach (var TextureName in textures)
                        {
                            var MaterialTexture = mat.GetTexture(TextureName);
                            if (MaterialTexture != null)
                            {
                                MaterialTexture.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }

        }

        internal static void DeleteAllClonedAvatars()
        {
            foreach (var item in SpawnedPreviewAvatars)
            {
                item.DestroyMeLocal();
            }
        }

        internal static Transform CurrentPreviewedAvatar
        {
            get
            {
                var list = UserInterfaceObjects.AvatarPreviewBase_MainAvatar.Get_Childs();
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        return item;
                    }

                }
                return null;
            }
        }
    }
}