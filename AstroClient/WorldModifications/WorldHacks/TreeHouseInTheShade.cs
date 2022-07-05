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

    internal class TreeHouseInTheShade : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }
        private static Transform _Jetpack_Panel;

        internal static Transform Jetpack_Panel
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Jetpack_Panel == null)
                {
                    return _Jetpack_Panel = GameObjectFinder.FindRootSceneObject("Jetpack Panel").transform;
                }

                return _Jetpack_Panel;
            }
        }
        private static Transform _ShaderSphere;

        internal static Transform ShaderSphere
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_ShaderSphere == null)
                {
                    return _ShaderSphere = GameObjectFinder.FindRootSceneObject("ShaderSphere").transform;
                }

                return _ShaderSphere;
            }
        }


        private static Renderer _ShaderSphereRenderer;
        internal static Renderer ShaderSphereRenderer
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (ShaderSphere == null) return null;
                if (_ShaderSphereRenderer == null)
                {
                    return _ShaderSphereRenderer = ShaderSphere.GetComponent<Renderer>();
                }

                return _ShaderSphereRenderer;
            }
        }



        private static Transform _Canvas;

        internal static Transform Canvas
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Jetpack_Panel == null) return null;
                if (_Canvas == null)
                {
                    return _Canvas = Jetpack_Panel.FindObject("Canvas").transform;
                }

                return _Canvas;
            }
        }
        private static Transform _TimerEnableButtons;

        internal static Transform TimerEnableButtons
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_TimerEnableButtons == null)
                {
                    return _TimerEnableButtons = Canvas.FindObject("TimerEnableButtons").transform;
                }

                return _TimerEnableButtons;
            }
        }
        private static Transform _TextCooldown;

        internal static Transform TextCooldown
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_TextCooldown == null)
                {
                    return _TextCooldown = Canvas.FindObject("TextCooldown").transform;
                }

                return _TextCooldown;
            }
        }

        private static Transform _Spawn_Desktop;

        internal static Transform Spawn_Desktop
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_Spawn_Desktop == null)
                {
                    return _Spawn_Desktop = Canvas.FindObject("Button1 Spawn Desktop").transform;
                }

                return _Spawn_Desktop;
            }
        }
        private static Transform _Spawn_VR;

        internal static Transform Spawn_VR
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_Spawn_VR == null)
                {
                    return _Spawn_VR = Canvas.FindObject("Button2 Spawn VR").transform;
                }

                return _Spawn_VR;
            }
        }

        private static bool _HasSubscribed = false;
        private static bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnUpdate += OnUpdate;
                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnUpdate -= OnUpdate;
                    }
                }
                _HasSubscribed = value;
            }
        }

        private static  void OnRoomLeft()
        {
            HasSubscribed = false;
        }

        private static void OnUpdate()
        {
            if (TimerEnableButtons != null)
            {
                if (TimerEnableButtons.gameObject.active)
                {
                    TimerEnableButtons.gameObject.SetActive(false);
                }
            }

            if (Spawn_VR != null)
            {
                if(!Spawn_VR.gameObject.active)
                {
                    Spawn_VR.gameObject.SetActive(true);
                }
            }
            if (Spawn_Desktop != null)
            {
                if (!Spawn_Desktop.gameObject.active)
                {
                    Spawn_Desktop.gameObject.SetActive(true);
                }
            }

        }



        private static IEnumerator FixRenderSphere()
        {
            if (!isCurrentWorld) yield return null;
            while (ShaderSphereRenderer == null) yield return null;
            while(isCurrentWorld)
            {
                ShaderSphereRenderer.bounds.Expand(float.MaxValue);
                // Log.Debug("Forcing Bounds to be higher than 2000f...");
                yield return null;
            }

            yield return null;
        }


        private static void FindEverything()
        {
            
            if(TextCooldown != null)
            {
                var text = TextCooldown.GetComponent<UnityEngine.UI.Text>();
                if(text != null)
                {
                    text.supportRichText = true;
                    text.resizeTextForBestFit = true;
                    text.text = $"Cooldown Removed By AstroClient \n R.I.P {WorldUtils.AuthorName} \n ????-2020";
                }
            }

            //// Expand the exploration area.

            //if(ShaderSphere != null)
            //{
            //    ShaderSphere.localScale = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            //    MelonCoroutines.Start(FixRenderSphere());
            //}
            var UpdateText = GameObjectFinder.Find("ui panel example/Canvas/UpdatesPanel/Extra Text");
            if(UpdateText != null)
            {
                var text = UpdateText.GetComponent<UnityEngine.UI.Text>();
                if (text != null)
                {
                    text.supportRichText = true;
                    text.text = UpdatedPanelExtraText();
                }

            }

            foreach (var prefab in SceneUtils.DynamicPrefabs)
            {
                if (prefab != null)
                {
                    GameObject template;

                    bool isTwoHanded = prefab.name.isMatch("TBDD_TwoHand");
                    if(isTwoHanded)
                    {
                        template = ClientResources.Loaders.Prefabs.VRJetpack;
                    }
                    else
                    {
                        template = ClientResources.Loaders.Prefabs.DesktopJetpack;
                    }
                    Log.Debug($"{prefab.name} Using Template {template.name}, IsTwoHanded {isTwoHanded}");
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

                }
            }

            HasSubscribed = true;
            isCurrentWorld = true;
        }


        private static string UpdatedPanelExtraText()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine();
            text.AppendLine("- couple of tiny improvements");
            text.AppendLine("- added new glass refractions shader");
            text.AppendLine("- removed kali sunset");
            text.AppendLine("- Removed Jetpack Cooldown (AstroClient)");
            text.AppendLine();
           // text.AppendLine("- Expanded Radius of Shader Sphere (AstroClient)");
            text.AppendLine();
            text.AppendLine("visit our other worlds too:");
            text.AppendLine("fractal explorer");
            text.AppendLine("music visualizer");
            text.AppendLine("home arcade");
            text.AppendLine("fluid flow studio");
            text.AppendLine("bamboo temple");
            text.AppendLine("LA2097 cyberpunk city");
            text.AppendLine();
            text.AppendLine("jetpacks by butadiene and synqark");
            text.AppendLine();
            text.AppendLine("visit shadertoy.com and learn raymarching");
            text.AppendLine();
            text.AppendLine();
            text.AppendLine($"RIP {WorldUtils.AuthorName} ????-2020");

            return text.ToString();
        }



        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.TreeHouseInTheShade)
            {

                Log.Write($"Recognized {Name} World, Removing Jetpack Panel Cooldown....", System.Drawing.Color.Chartreuse);
                Log.Write($"This author passed away of heart failure... RIP {WorldUtils.AuthorName}....", System.Drawing.Color.Gold);
                Log.Write("VRChat should keep the memory alive and keep his quality work alive...", System.Drawing.Color.Gold);
                Log.Write("Im Bypassing the Jetpack because in his other worlds , the jetpack panel has no delay...", System.Drawing.Color.Gold);
                Log.Write("And I hope this guy doesn't mind this bypass...", System.Drawing.Color.Gold);
                Log.Write("If you use munchen, and this world breaks, remove it....", System.Drawing.Color.Gold);



                isCurrentWorld = true;
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(true);
                    CurrentMenu.SetTextColor(Color.green);
                }

                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
                HasSubscribed = false;
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(false);
                    CurrentMenu.SetTextColor(Color.red);
                }
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;

        internal static QMNestedGridMenu CurrentMenu { get; set; }

    }
}