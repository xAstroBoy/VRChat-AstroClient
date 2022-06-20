using System;
using AstroClient.ClientAttributes;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Tools.Avatars
{
    [RegisterComponent]
    class HeightAdjuster : MonoBehaviour
    {
        const float ms_defaultColliderHeight = 1.65f;
        const float ms_defaultColliderCenter = 0.85f;
        const float ms_defaultColliderRadius = 0.2f;

        enum PoseState
        {
            Standing = 0,
            Crouching,
            Crawling
        };

        static readonly float[] ms_heightMultipliers = { 1f, 0.6f, 0.35f };

        VRCPlayer m_player = null;
        readonly VRCPlayer.OnAvatarIsReady m_avatarReadyEvent = null;
        CharacterController m_characterController = null;
        VRCVrIkController m_ikController = null;

        bool isEnabled = true;
        bool usePoseHeight = true;

        float m_avatarEyeHeight = ms_defaultColliderHeight;
        float m_center = ms_defaultColliderCenter;
        float m_radius = ms_defaultColliderRadius;
        PoseState m_poseState = PoseState.Standing;

        private bool HasStoredOriginalAvatarHeight = false;
        float new_m_avatarEyeHeight = ms_defaultColliderHeight;
        float new_m_center = ms_defaultColliderCenter;
        float new_m_radius = ms_defaultColliderRadius;


        public HeightAdjuster(IntPtr obj0) : base(obj0)
        {
            m_avatarReadyEvent = new Action(this.RecacheComponents);
        }


        void Awake()
        {
            m_player = this.GetComponent<VRCPlayer>();
            m_characterController = this.GetComponent<CharacterController>();

            m_player.field_Private_OnAvatarIsReady_0 += m_avatarReadyEvent;
        }

        void OnDestroy()
        {
            if(m_player != null)
                m_player.field_Private_OnAvatarIsReady_0 -= m_avatarReadyEvent;
        }

        void Update()
        {
            if(isEnabled && usePoseHeight)
            {
                PoseState l_newPoseState = PoseState.Standing;

                // Generic avatars are skipped
                if(m_ikController != null)
                    l_newPoseState = (m_ikController.field_Private_Boolean_31 ? PoseState.Crawling : (m_ikController.field_Private_Boolean_32 ? PoseState.Crouching : PoseState.Standing));

                if(m_poseState != l_newPoseState)
                {
                    m_poseState = l_newPoseState;
                    UpdateCollider(m_avatarEyeHeight * ms_heightMultipliers[(int)m_poseState], m_center * ms_heightMultipliers[(int)m_poseState], m_radius, false);
                }
            }
        }

        

        internal void RecacheComponents()
        {
            HasStoredOriginalAvatarHeight = false;
            m_ikController = null;

            m_ikController = m_player.field_Private_VRC_AnimationController_0.field_Private_VRCVrIkController_0;
            AdjustCollider();
        }

        internal void AdjustCollider()
        {
            m_avatarEyeHeight = m_player.field_Private_VRCAvatarManager_0.field_Private_Single_4;
            m_center = m_avatarEyeHeight * 0.515151f;
            m_radius = m_avatarEyeHeight * 0.121212f;
            m_poseState = PoseState.Standing;

            if (isEnabled)
                UpdateCollider(m_avatarEyeHeight, m_center, m_radius);
            if (!HasStoredOriginalAvatarHeight)
            {
                new_m_avatarEyeHeight = m_avatarEyeHeight;
                new_m_center = m_center;
                new_m_radius = m_radius;
                HasStoredOriginalAvatarHeight = true;
            }

        }

        internal void UpdateCollider(float p_height, float p_center, float p_radius, bool p_radiusUpdate = true)
        {
            if(m_characterController != null)
            {
                m_characterController.height = p_height;

                Vector3 l_center = m_characterController.center;
                l_center.y = p_center;
                m_characterController.center = l_center;

                if(p_radiusUpdate)
                    m_characterController.radius = p_radius;
            }
        }

        internal void SetEnabled(bool p_state)
        {
            if(isEnabled != p_state)
            {
                isEnabled = p_state;
                m_poseState = PoseState.Standing;

                UpdateCollider(
                    isEnabled ? m_avatarEyeHeight : ms_defaultColliderHeight,
                    isEnabled ? m_center : ms_defaultColliderCenter,
                    isEnabled ? m_radius : ms_defaultColliderRadius
                );
            }
        }

        internal void Reset()
        {
            UpdateCollider(
                 new_m_avatarEyeHeight,
                new_m_center,
                new_m_radius
            );

        }

        internal void SetPoseHeight(bool p_state)
        {
            if(usePoseHeight != p_state)
            {
                usePoseHeight = p_state;
                m_poseState = PoseState.Standing;

                if(isEnabled && !usePoseHeight)
                    UpdateCollider(m_avatarEyeHeight, m_center, m_radius);
            }
        }
    }
}
