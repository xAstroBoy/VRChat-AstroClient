using AstroClient.AstroMonos.Prefabs;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Extensions;
using UnityEngine.Animations;
using VRC_Pickup = VRCSDK2.VRC_Pickup;
using VRC_Trigger = VRCSDK2.VRC_Trigger;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class SakuraIsland : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private static void FixJetpack()
        {
            foreach (var prefab in SceneUtils.DynamicPrefabs)
            {
                if (prefab != null)
                {
                    // Sakura island has only one Jetpack Prefab.
                    if (prefab.name.isMatch("TBDD_TwoHand"))
                    {
                        var template = ClientResources.Loaders.Prefabs.VRJetpack;
                        var chair = prefab.transform.FindObject("VRCChair");
                        var collider = chair.FindObject("Collider");
                        var colliderconstraint = new ConstraintSource
                        {
                            m_Weight = 1,
                            m_SourceTransform = collider
                        };

                        var VRCChairStick_Prefab = prefab.transform.FindObject("VRCChairStick");
                        if (VRCChairStick_Prefab != null)
                        {
                            var VRCChairStick_Template = template.FindObject("VRCChairStick");
                            if (VRCChairStick_Template != null)
                            {
                                var PosConstraint = VRCChairStick_Template.GetComponent<PositionConstraint>();

                                if (PosConstraint != null)
                                {
                                    var constraint = VRCChairStick_Prefab.AddComponent<PositionConstraint>();
                                    if (constraint != null)
                                    {
                                        constraint.translationAtRest = PosConstraint.translationAtRest;
                                        constraint.translationAxis = PosConstraint.translationAxis;
                                        constraint.translationOffset = PosConstraint.translationOffset;
                                        constraint.weight = PosConstraint.weight;
                                        constraint.locked = PosConstraint.locked;
                                        constraint.constraintActive = true;
                                        constraint.AddSource(colliderconstraint);
                                    }
                                }
                                var RotConstraint = VRCChairStick_Template.GetComponent<RotationConstraint>();

                                if (RotConstraint != null)
                                {
                                    var constraint = VRCChairStick_Prefab.AddComponent<RotationConstraint>();
                                    if (constraint != null)
                                    {
                                        constraint.rotationAtRest = RotConstraint.rotationAtRest;
                                        constraint.rotationOffset = RotConstraint.rotationOffset;
                                        constraint.rotationAxis = RotConstraint.rotationAxis;
                                        constraint.weight = RotConstraint.weight;
                                        constraint.locked = RotConstraint.locked;
                                        constraint.constraintActive = true;
                                        constraint.AddSource(colliderconstraint);
                                    }
                                }
                            }

                            VRCChairStick_Prefab.RemoveComponent<VRC_Pickup>();
                            VRCChairStick_Prefab.RemoveComponent<VRC_Trigger>();
                            //JetpackStick.RemoveComponent<VRC_EventHandler>();
                            //JetpackStick.RemoveComponent<VRC_Trigger>();
                        }
                        var ThrusterStick_Prefab = prefab.transform.FindObject("ThrusterStick");
                        if (ThrusterStick_Prefab != null)
                        {
                            var ThrusterStick_Template = template.FindObject("ThrusterStick");
                            if (ThrusterStick_Template != null)
                            {
                                var PosConstraint = ThrusterStick_Template.GetComponent<PositionConstraint>();

                                if (PosConstraint != null)
                                {
                                    var constraint = ThrusterStick_Prefab.AddComponent<PositionConstraint>();
                                    if (constraint != null)
                                    {
                                        constraint.translationAtRest = PosConstraint.translationAtRest;
                                        constraint.translationAxis = PosConstraint.translationAxis;
                                        constraint.translationOffset = PosConstraint.translationOffset;
                                        constraint.weight = PosConstraint.weight;
                                        constraint.locked = PosConstraint.locked;
                                        constraint.constraintActive = true;
                                        constraint.AddSource(colliderconstraint);
                                    }
                                }
                                var RotConstraint = ThrusterStick_Template.GetComponent<RotationConstraint>();

                                if (RotConstraint != null)
                                {
                                    var constraint = ThrusterStick_Prefab.AddComponent<RotationConstraint>();
                                    if (constraint != null)
                                    {
                                        constraint.rotationAtRest = RotConstraint.rotationAtRest;
                                        constraint.rotationOffset = RotConstraint.rotationOffset;
                                        constraint.rotationAxis = RotConstraint.rotationAxis;
                                        constraint.weight = RotConstraint.weight;
                                        constraint.locked = RotConstraint.locked;
                                        constraint.constraintActive = true;
                                        constraint.AddSource(colliderconstraint);
                                    }
                                }
                            }

                            ThrusterStick_Prefab.RemoveComponent<VRC_Pickup>();
                            ThrusterStick_Prefab.RemoveComponent<VRC_Trigger>();
                            //JetpackStick.RemoveComponent<VRC_EventHandler>();
                            //JetpackStick.RemoveComponent<VRC_Trigger>();
                        }
                        prefab.AddComponent<JetpackController>();
                        break;
                    }
                }
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.SakuraIsland)
            {
                isCurrentWorld = true;
                FixJetpack();
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;

        internal static QMNestedGridMenu CurrentMenu { get; set; }
    }
}