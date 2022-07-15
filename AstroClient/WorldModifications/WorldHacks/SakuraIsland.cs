using System;
using System.Text;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds;
using AstroClient.AstroMonos.Components.Custom.Items;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Startup.Hooks;
using AstroClient.Tools;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy.Extensions;
using UnityEngine.AI;
using UnityEngine.Animations;
using VRC.SDKBase;
using VRC_EventHandler = VRCSDK2.VRC_EventHandler;
using VRC_Pickup = VRCSDK2.VRC_Pickup;
using VRC_Trigger = VRCSDK2.VRC_Trigger;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.PatronCrackers;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.World;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
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


                        var JetpackStick = prefab.transform.FindObject("VRCChairStick");
                        if (JetpackStick != null)
                        {
                            var clonethis = template.FindObject("VRCChairStick").GetComponent<ParentConstraint>();
                            if (clonethis != null)
                            {
                                var constraint = JetpackStick.AddComponent<ParentConstraint>();
                                if (constraint != null)
                                {
                                    constraint.rotationAtRest = clonethis.rotationAtRest;
                                    constraint.rotationAxis = clonethis.rotationAxis;
                                    constraint.rotationOffsets = clonethis.rotationOffsets;
                                    constraint.translationAtRest = clonethis.translationAtRest;
                                    constraint.translationOffsets = clonethis.translationOffsets;
                                    constraint.weight = clonethis.weight;
                                    constraint.locked = clonethis.locked;
                                    constraint.constraintActive = true;
                                    constraint.AddSource(colliderconstraint);
                                }

                            }

                            JetpackStick.RemoveComponent<VRC_Pickup>();
                            JetpackStick.RemoveComponent<VRC_Trigger>();
                            //JetpackStick.RemoveComponent<VRC_EventHandler>();
                            //JetpackStick.RemoveComponent<VRC_Trigger>();
                        }
                        var ThrusterStick = prefab.transform.FindObject("ThrusterStick");
                        if (ThrusterStick != null)
                        {
                            var clonethis = template.FindObject("ThrusterStick").GetComponent<ParentConstraint>();
                            if (clonethis != null)
                            {
                                var constraint = ThrusterStick.AddComponent<ParentConstraint>();
                                if (constraint != null)
                                {
                                    constraint.rotationAtRest = clonethis.rotationAtRest;
                                    constraint.rotationAxis = clonethis.rotationAxis;
                                    constraint.rotationOffsets = clonethis.rotationOffsets;
                                    constraint.translationAtRest = clonethis.translationAtRest;
                                    constraint.translationOffsets = clonethis.translationOffsets;
                                    constraint.weight = clonethis.weight;
                                    constraint.locked = clonethis.locked;
                                    constraint.constraintActive = true;

                                    constraint.AddSource(colliderconstraint);
                                }

                            }
                            ThrusterStick.RemoveComponent<VRC_Pickup>();
                            ThrusterStick.RemoveComponent<VRC_Trigger>();
                            //ThrusterStick.RemoveComponent<VRC_EventHandler>();
                            //ThrusterStick.RemoveComponent<VRC_Trigger>();
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