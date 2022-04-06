namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.AstroUdons;
    using CustomClasses;
    using Tools.Extensions;
    using Tools.UdonEditor;
    using UnityEngine;
    using VRC;
    using VRC.Udon;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class BOMBERio : AstroEvents
    {
        internal static void InitButtons(QMGridTab main)
        {
            BOMBERioCheatsPage = new QMNestedGridMenu(main, "BOMBERio", "BOMBERio Cheats");

            var GunModifier = new QMNestedGridMenu(BOMBERioCheatsPage, "Gun Modifier", "Modify Projectiles");

            Always_ShootBomb_0_Toggle = new QMToggleButton(GunModifier, "Shoot Bomb 0", () => { Override_ShootBomb_0_Toggle = true; }, "Shoot Bomb 0", () => { Override_ShootBomb_0_Toggle = false; }, "Always Shoot A Specified Projectile");
            Always_ShootBomb_1_Toggle = new QMToggleButton(GunModifier, "Shoot Bomb 1", () => { Override_ShootBomb_1_Toggle = true; }, "Shoot Bomb 1", () => { Override_ShootBomb_1_Toggle = false; }, "Always Shoot A Specified Projectile");
            Always_ShootBomb_2_Toggle = new QMToggleButton(GunModifier, "Shoot Bomb 2", () => { Override_ShootBomb_2_Toggle = true; }, "Shoot Bomb 2", () => { Override_ShootBomb_2_Toggle = false; }, "Always Shoot A Specified Projectile");
            Always_ShootBomb_3_Toggle = new QMToggleButton(GunModifier, "Shoot Bomb 3", () => { Override_ShootBomb_3_Toggle = true; }, "Shoot Bomb 3", () => { Override_ShootBomb_3_Toggle = false; }, "Always Shoot A Specified Projectile");
            Always_ShootBomb_4_Toggle = new QMToggleButton(GunModifier, "Shoot First Player Bomb", () => { Override_ShootBomb_4_Toggle = true; }, "Shoot First Player Bomb", () => { Override_ShootBomb_4_Toggle = false; }, "Always Shoot A Specified Projectile");
            Always_ShootBomb_5_Toggle = new QMToggleButton(GunModifier, "Shoot Rocket", () => { Override_ShootBomb_5_Toggle = true; }, "Shoot Rocket", () => { Override_ShootBomb_5_Toggle = false; }, "Always Shoot A Specified Projectile");

            var Harvester = new QMNestedGridMenu(BOMBERioCheatsPage, "Crystal Harvester", "Harvest Crystals To boost circle area");

            _ = new QMSingleButton(Harvester, "Harvest 10 Crystals", () => { HarvestQuads(10); }, "Harvest some Quads!");
            _ = new QMSingleButton(Harvester, "Harvest 20 Crystals", () => { HarvestQuads(20); }, "Harvest some Quads!");
            _ = new QMSingleButton(Harvester, "Harvest 50 Crystals", () => { HarvestQuads(50); }, "Harvest some Quads!");
            _ = new QMSingleButton(Harvester, "Harvest 100 Crystals", () => { HarvestQuads(100); }, "Harvest some Quads!");
            _ = new QMSingleButton(Harvester, "Harvest 500 Crystals", () => { HarvestQuads(500); }, "Harvest some Quads!");
            _ = new QMSingleButton(Harvester, "Harvest 1000 Crystals", () => { HarvestQuads(1000); }, "Harvest some Quads!");

            Bypass_Outside_Circle_speed_Toggle = new QMToggleButton(BOMBERioCheatsPage, "Bypass Outside Circle Speed", () => { BypassOutsideCircleSpeed = true; }, () => { BypassOutsideCircleSpeed = false; }, "Remove Outside Circle Speed Reducer!");
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.BOMBERio)
            {
                if (BOMBERioCheatsPage != null)
                {
                    BOMBERioCheatsPage.SetInteractable(true);
                    BOMBERioCheatsPage.SetTextColor(Color.green);
                }
                Log.Write($"Recognized {Name} World, Enabling Gun Projectile Hijacker..");
                isBomberIO = true;
            }
            else
            {
                if (BOMBERioCheatsPage != null)
                {
                    BOMBERioCheatsPage.SetInteractable(false);
                    BOMBERioCheatsPage.SetTextColor(Color.red);
                }

                isBomberIO = false;
            }
        }

        private bool isBomberIO = false;

        internal static GameObject GetRandomQuad()
        {
            List<Transform> list = GameObjectFinder.FindRootSceneObject("ItemManager").transform.Get_Childs();
            for (int i = 0; i < list.Count; i++)
            {
                Transform item = list[i];
                Log.Debug($"Grabbed Quad : {item.name}");
                return item.gameObject;
            }
            return null;
        }

        private static GameObject _Quad;

        private static GameObject Quad
        {
            get
            {
                return _Quad ??= GetRandomQuad();
            }
        }

        private static bool isHarvesting = false;
        private static bool isInGame = false;

        internal static void HarvestQuads(int amount)
        {
            if (!isHarvesting)
            {
                _ = MelonLoader.MelonCoroutines.Start(HarvestQuadsRoutine(amount));
                isHarvesting = true;
            }
        }

        internal static IEnumerator HarvestQuadsRoutine(int amount)
        {
            while (Quad == null) yield return null;
            int i = 0;
            var quadpos = Quad.transform.position;
            var quadrot = Quad.transform.rotation;

            while (i <= amount && isInGame)
            {
                Quad?.SetActive(true);
                Quad?.TeleportToMe(HumanBodyBones.RightFoot, true, true);
                i++;
                yield return null;
            }
            Quad.transform.rotation = quadrot;
            Quad.transform.position = quadpos;

            isHarvesting = false;
            yield return null;
        }

        private static void OnGameJoinEvent()
        {
            isInGame = true;
        }

        private static void OnGameExitStageEvent()
        {
            isInGame = false;
        }

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            if (isBomberIO)
            {
                if (sender.DisplayName() == GameInstances.LocalPlayer.GetPlayer().DisplayName())
                {
                    if (obj.name.ToLower().StartsWith("followobj"))
                    {
                        if (AssignedNode == null)
                        {
                            if (action.ToLower().Contains("join"))
                            {
                                FindEverything(obj);
                                OnGameJoinEvent();
                            }
                            else if (action.ToLower().Contains("exitstage"))
                            {
                                FindEverything(obj);
                                OnGameExitStageEvent();
                            }
                        }
                        else
                        {
                            if (obj == AssignedNode)
                            {
                                if (action.ToLower().Contains("join"))
                                {
                                    OnGameJoinEvent();
                                }
                                else if (action.ToLower().Contains("exitstage"))
                                {
                                    OnGameExitStageEvent();
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void OnPickupInteract()
        {
            if (!HasShot)
            {
                ShootModifiedBullet();
                HasShot = true;
            }
            else
            {
                HasShot = false;
            }
        }

        private static bool HasShot = false;

        private static void ShootModifiedBullet()
        {
            if (AssignedNode != null)
            {
                if (Override_ShootBomb_0_Toggle)
                {
                    if (ShootBomb0 != null)
                    {
                        ShootBomb0.InvokeBehaviour();
                    }
                }
                else if (Override_ShootBomb_1_Toggle)
                {
                    if (ShootBomb1 != null)
                    {
                        ShootBomb1.InvokeBehaviour();
                    }
                }
                else if (Override_ShootBomb_2_Toggle)
                {
                    if (ShootBomb2 != null)
                    {
                        ShootBomb2.InvokeBehaviour();
                    }
                }
                else if (Override_ShootBomb_3_Toggle)
                {
                    if (ShootBomb3 != null)
                    {
                        ShootBomb3.InvokeBehaviour();
                    }
                }
                else if (Override_ShootBomb_4_Toggle)
                {
                    if (ShootBomb4 != null)
                    {
                        ShootBomb4.InvokeBehaviour();
                    }
                }
                else if (Override_ShootBomb_5_Toggle)
                {
                    if (ShootBombEx != null)
                    {
                        ShootBombEx.InvokeBehaviour();
                    }
                }
            }
        }

        internal static void FindEverything(GameObject obj)
        {
            if (obj != null)
            {
                AssignedNode = obj;
                if (AssignedNode != null)
                {
                    try
                    {
                        FollowObjBehaviour = AssignedNode.FindUdonEvent("GetThisCrystal").UdonBehaviour;

                        if (!HasUnboxedDefaultSpeeds)
                        {
                            if (FollowObjBehaviour != null)
                            {
                                var disassembled = FollowObjBehaviour.ToRawUdonBehaviour();

                                if (disassembled != null)
                                {
                                    var Outside_RunSpeedAddress = disassembled.IUdonSymbolTable.GetAddressFromSymbol(Outside_RunSpeedSymbol);
                                    var Outside_WalkAndStrafeAddress = disassembled.IUdonSymbolTable.GetAddressFromSymbol(Outside_WalkAndStrafeSpeedSymbol);

                                    var Inner_RunSpeedAddress = disassembled.IUdonSymbolTable.GetAddressFromSymbol(Inner_RunSpeedSymbol);
                                    var Inner_WalkAndStrafeAddress = disassembled.IUdonSymbolTable.GetAddressFromSymbol(Inner_WalkAndStrafeSpeedSymbol);

                                    var Unpacked_Outside_RunSpeed = disassembled.IUdonHeap.GetHeapVariable(Outside_RunSpeedAddress).Unpack_Single();
                                    if (Unpacked_Outside_RunSpeed.HasValue)
                                    {
                                        Outside_Default_RunSpeed = Unpacked_Outside_RunSpeed.Value;
                                    }
                                    var Unpacked_Outside_WalkAndStrafe = disassembled.IUdonHeap.GetHeapVariable(Outside_WalkAndStrafeAddress).Unpack_Single();
                                    if (Unpacked_Outside_WalkAndStrafe.HasValue)
                                    {
                                        Outside_Default_StrafeAndWalkSpeed = Unpacked_Outside_WalkAndStrafe.Value;
                                    }
                                    var Unpacked_Inner_RunSpeed = disassembled.IUdonHeap.GetHeapVariable(Inner_RunSpeedAddress).Unpack_Single();
                                    if (Unpacked_Inner_RunSpeed.HasValue)
                                    {
                                        Inner_Default_RunSpeed = Unpacked_Inner_RunSpeed.Value;
                                    }
                                    var Unpacked_Inner_WalkAndStrafe = disassembled.IUdonHeap.GetHeapVariable(Inner_WalkAndStrafeAddress).Unpack_Single();
                                    if (Unpacked_Inner_WalkAndStrafe.HasValue)
                                    {
                                        Inner_Default_StrafeAndWalkSpeed = Unpacked_Inner_WalkAndStrafe.Value;
                                    }
                                    HasUnboxedDefaultSpeeds = true;
                                }
                            }
                        }
                    }
                    catch { }
                    var Item = AssignedNode.transform.FindObject("Shooter");
                    if (Item != null)
                    {
                        control = Item.GetOrAddComponent<VRC_AstroPickup>();
                        if (control != null)
                        {
                            control.OnPickupUseUp = OnPickupInteract;
                            control.InteractionText = "Hello Motherfuckers (Modified By AstroClient Developers)";
                        }
                    }
                    var shooterbody = AssignedNode.transform.FindObject("Shooter/ShooterBody");
                    if (shooterbody != null)
                    {
                        ShootBomb0 = shooterbody.gameObject.FindUdonEvent("ShootBomb0");
                        ShootBomb1 = shooterbody.gameObject.FindUdonEvent("ShootBomb1");
                        ShootBomb2 = shooterbody.gameObject.FindUdonEvent("ShootBomb2");
                        ShootBomb3 = shooterbody.gameObject.FindUdonEvent("ShootBomb3");
                        ShootBomb4 = shooterbody.gameObject.FindUdonEvent("ShootBomb4");
                        ShootBombEx = shooterbody.gameObject.FindUdonEvent("ShootBombEx");
                    }
                }
            }
        }

        internal static void Change_Behaviour_Outside_Speed(float Run_Speed, float Walk_And_Strafe_Speed)
        {
            if (FollowObjBehaviour != null)
            {
                var disassembled = FollowObjBehaviour.ToRawUdonBehaviour();
                if (HasUnboxedDefaultSpeeds)
                {
                    if (disassembled != null)
                    {
                        UdonHeapEditor.PatchHeap(disassembled, Outside_RunSpeedSymbol, Run_Speed);
                        UdonHeapEditor.PatchHeap(disassembled, Outside_WalkAndStrafeSpeedSymbol, Walk_And_Strafe_Speed);
                    }
                }
            }
        }

        internal override void OnRoomLeft()
        {
            AssignedNode = null;
            ShootBomb0 = null;
            ShootBomb1 = null;
            ShootBomb2 = null;
            ShootBomb3 = null;
            ShootBomb4 = null;
            ShootBombEx = null;
            Override_ShootBomb_0_Toggle = false;
            Override_ShootBomb_1_Toggle = false;
            Override_ShootBomb_2_Toggle = false;
            Override_ShootBomb_3_Toggle = false;
            Override_ShootBomb_4_Toggle = false;
            Override_ShootBomb_5_Toggle = false;
            control = null;
            HasShot = false;
            _Quad = null;
            isInGame = false;
            isHarvesting = false;
            BypassOutsideCircleSpeed = false;
            FollowObjBehaviour = null;
            HasUnboxedDefaultSpeeds = false;
            Outside_Default_StrafeAndWalkSpeed = 0f;
            Outside_Default_RunSpeed = 0f;
            Inner_Default_StrafeAndWalkSpeed = 0f;
            Inner_Default_RunSpeed = 0f;
        }

        internal static VRC_AstroPickup control;

        internal static UdonBehaviour_Cached ShootBomb0;
        internal static UdonBehaviour_Cached ShootBomb1;
        internal static UdonBehaviour_Cached ShootBomb2;
        internal static UdonBehaviour_Cached ShootBomb3;
        internal static UdonBehaviour_Cached ShootBomb4;
        internal static UdonBehaviour_Cached ShootBombEx;

        internal static GameObject AssignedNode;
        internal static QMNestedGridMenu BOMBERioCheatsPage;

        internal static QMToggleButton Always_ShootBomb_0_Toggle;
        internal static QMToggleButton Always_ShootBomb_1_Toggle;
        internal static QMToggleButton Always_ShootBomb_2_Toggle;
        internal static QMToggleButton Always_ShootBomb_3_Toggle;
        internal static QMToggleButton Always_ShootBomb_4_Toggle;
        internal static QMToggleButton Always_ShootBomb_5_Toggle;

        internal static QMToggleButton Bypass_Outside_Circle_speed_Toggle;

        private static bool _BypassOutsideCircleSpeed;

        internal static bool BypassOutsideCircleSpeed
        {
            get
            {
                return _BypassOutsideCircleSpeed;
            }
            set
            {
                if (HasUnboxedDefaultSpeeds)
                {
                    _BypassOutsideCircleSpeed = value;
                    if (Bypass_Outside_Circle_speed_Toggle != null)
                    {
                        Bypass_Outside_Circle_speed_Toggle.SetToggleState(value);
                    }
                    if (value)
                    {
                        Change_Behaviour_Outside_Speed(Inner_Default_RunSpeed, Inner_Default_StrafeAndWalkSpeed);
                    }
                    else
                    {
                        Change_Behaviour_Outside_Speed(Outside_Default_RunSpeed, Outside_Default_StrafeAndWalkSpeed);
                    }
                }
                else
                {
                    if (Bypass_Outside_Circle_speed_Toggle != null)
                    {
                        Bypass_Outside_Circle_speed_Toggle.SetToggleState(false);
                    }
                }
            }
        }

        private static bool _Override_ShootBomb_0_Toggle;

        internal static bool Override_ShootBomb_0_Toggle
        {
            get
            {
                return _Override_ShootBomb_0_Toggle;
            }
            set
            {
                if (value == _Override_ShootBomb_0_Toggle)
                {
                    return; // Discard.
                }

                if (value)
                {
                    // Disable the rest
                    Override_ShootBomb_1_Toggle = false;
                    Override_ShootBomb_2_Toggle = false;
                    Override_ShootBomb_3_Toggle = false;
                    Override_ShootBomb_4_Toggle = false;
                    Override_ShootBomb_5_Toggle = false;
                }

                _Override_ShootBomb_0_Toggle = value;
                if (Always_ShootBomb_0_Toggle != null)
                {
                    Always_ShootBomb_0_Toggle.SetToggleState(value);
                }
            }
        }

        private static bool _Override_ShootBomb_1_Toggle;

        internal static bool Override_ShootBomb_1_Toggle
        {
            get
            {
                return _Override_ShootBomb_1_Toggle;
            }
            set
            {
                if (value == _Override_ShootBomb_1_Toggle)
                {
                    return; // Discard.
                }

                if (value)
                {
                    // Disable the rest
                    Override_ShootBomb_0_Toggle = false;
                    Override_ShootBomb_2_Toggle = false;
                    Override_ShootBomb_3_Toggle = false;
                    Override_ShootBomb_4_Toggle = false;
                    Override_ShootBomb_5_Toggle = false;
                }

                _Override_ShootBomb_1_Toggle = value;
                if (Always_ShootBomb_1_Toggle != null)
                {
                    Always_ShootBomb_1_Toggle.SetToggleState(value);
                }
            }
        }

        private static bool _Override_ShootBomb_2_Toggle;

        internal static bool Override_ShootBomb_2_Toggle
        {
            get
            {
                return _Override_ShootBomb_2_Toggle;
            }
            set
            {
                if (value == _Override_ShootBomb_2_Toggle)
                {
                    return; // Discard.
                }

                if (value)
                {
                    // Disable the rest
                    Override_ShootBomb_0_Toggle = false;
                    Override_ShootBomb_2_Toggle = false;
                    Override_ShootBomb_3_Toggle = false;
                    Override_ShootBomb_4_Toggle = false;
                    Override_ShootBomb_5_Toggle = false;
                }

                _Override_ShootBomb_2_Toggle = value;
                if (Always_ShootBomb_2_Toggle != null)
                {
                    Always_ShootBomb_2_Toggle.SetToggleState(value);
                }
            }
        }

        private static bool _Override_ShootBomb_3_Toggle;

        internal static bool Override_ShootBomb_3_Toggle
        {
            get
            {
                return _Override_ShootBomb_3_Toggle;
            }
            set
            {
                if (value == _Override_ShootBomb_3_Toggle)
                {
                    return; // Discard.
                }

                if (value)
                {
                    // Disable the rest
                    Override_ShootBomb_0_Toggle = false;
                    Override_ShootBomb_1_Toggle = false;
                    Override_ShootBomb_2_Toggle = false;
                    Override_ShootBomb_4_Toggle = false;
                    Override_ShootBomb_5_Toggle = false;
                }

                _Override_ShootBomb_3_Toggle = value;
                if (Always_ShootBomb_3_Toggle != null)
                {
                    Always_ShootBomb_3_Toggle.SetToggleState(value);
                }
            }
        }

        private static bool _Override_ShootBomb_4_Toggle;

        internal static bool Override_ShootBomb_4_Toggle
        {
            get
            {
                return _Override_ShootBomb_4_Toggle;
            }
            set
            {
                if (value == _Override_ShootBomb_4_Toggle)
                {
                    return; // Discard.
                }

                if (value)
                {
                    // Disable the rest
                    Override_ShootBomb_0_Toggle = false;
                    Override_ShootBomb_1_Toggle = false;
                    Override_ShootBomb_2_Toggle = false;
                    Override_ShootBomb_3_Toggle = false;
                    Override_ShootBomb_5_Toggle = false;
                }

                _Override_ShootBomb_4_Toggle = value;
                if (Always_ShootBomb_4_Toggle != null)
                {
                    Always_ShootBomb_4_Toggle.SetToggleState(value);
                }
            }
        }

        private static bool _Override_ShootBomb_5_Toggle;

        internal static bool Override_ShootBomb_5_Toggle
        {
            get
            {
                return _Override_ShootBomb_5_Toggle;
            }
            set
            {
                if (value == _Override_ShootBomb_5_Toggle)
                {
                    return; // Discard.
                }

                if (value)
                {
                    // Disable the rest
                    Override_ShootBomb_0_Toggle = false;
                    Override_ShootBomb_1_Toggle = false;
                    Override_ShootBomb_2_Toggle = false;
                    Override_ShootBomb_3_Toggle = false;
                    Override_ShootBomb_4_Toggle = false;
                }

                _Override_ShootBomb_5_Toggle = value;
                if (Always_ShootBomb_5_Toggle != null)
                {
                    Always_ShootBomb_5_Toggle.SetToggleState(value);
                }
            }
        }

        private static string Outside_RunSpeedSymbol => "__8_const_intnl_SystemSingle";

        private static string Outside_WalkAndStrafeSpeedSymbol => "__5_const_intnl_SystemSingle";

        private static string Inner_RunSpeedSymbol => "__9_const_intnl_SystemSingle";

        private static string Inner_WalkAndStrafeSpeedSymbol => "__1_const_intnl_SystemSingle";

        private static bool HasUnboxedDefaultSpeeds = false;

        private static float Outside_Default_StrafeAndWalkSpeed;
        private static float Outside_Default_RunSpeed;

        private static float Inner_Default_StrafeAndWalkSpeed;
        private static float Inner_Default_RunSpeed;

        private static UdonBehaviour FollowObjBehaviour;
    }
}