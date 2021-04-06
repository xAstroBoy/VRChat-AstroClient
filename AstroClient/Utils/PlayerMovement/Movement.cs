using AstroClient.extensions;
using AstroClient.variables;
using RealisticEyeMovements;
using RootMotion.FinalIK;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;
using static AstroClient.LocalPlayerUtils;

namespace AstroClient.AstroUtils.PlayerMovement
{
    public class Movement : Overridables
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var temp = new QMNestedButton(menu, x, y, "Movement Options", "Control Your Movements", null, null, null, null, btnHalf);
            UnlimitedJumpToggle = new QMSingleToggleButton(temp, 1, 0, "Unlimited Jumps", new Action(() => { IsUnlimitedJumpActive = true; }), "Unlimited Jumps OFF", new Action(() => { IsUnlimitedJumpActive = false; }), "Allows you to Unlimited jump", Color.green, Color.red, null, false, true);
            RocketJumpToggle = new QMSingleToggleButton(temp, 1, 0.5f, "Rocket Jump", new Action(() => { isRocketJumpActive = true; }), "Rocket Jump", new Action(() => { isRocketJumpActive = false; }), "Allows you to Unlimited jump", Color.green, Color.red, null, false, true);

            JumpOverrideToggle = new QMToggleButton(temp, 2, 0, "Jump Override ON", new Action(() => { IsJumpOverriden = true; }), "Jump Override OFF", new Action(() => { IsJumpOverriden = true; }), "Allows you to Bypass jump Block in certain worlds.", null, null, null, false);
            SerializerBtn = new QMToggleButton(temp, 3, 0, "Serializer ON", new Action(ToggleSerializer), "Serializer OFF", new Action(ToggleSerializer), "Blocks Movement packets (allows you to be invisible to others)", null, null, null, false);
            FreezePlayerOnQMOpenToggle = new QMToggleButton(temp, 4, 0, "Freeze On QM open \n ON", new Action(ToggleFreezePlayerOnQMOpen), "Freeze On QM Open \n OFF", new Action(ToggleFreezePlayerOnQMOpen), "Freeze Player On QuickMenu Open event.", null, null, null, false);
            new QMSingleButton(temp, 1, 1, "Spawn Avatar Clone", new Action(() => { SpawnClone(); }), "Spawns current avi clone", null, null, true);
            new QMSingleButton(temp, 1, 1.5f, "Remove Avatar Clones", new Action(() => { RemoveClones(); }), "Spawns current avi clone", null, null, true);
        }

        public override void OnUpdate()
        {
            CheckForJumpUpdates();
            FixJumpMissing();
        }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            HasCheckedJump = false;
        }

        public static void OnLevelLoad()
        {


            IsJumpOverriden = false;
            Bools.SerializerEnabled = false;


            if (Capsule != null)
            {
                Capsule.DestroyMeLocal();
            }
            if (SerializerBtn != null)
            {
                SerializerBtn.setToggleState(false);
            }
            ClonesCapsules.Clear();
        }

        private static bool HasCheckedJump = false;

        private static void FixJumpMissing()
        {
            try
            {
                if (Networking.LocalPlayer != null)
                {
                    if (!HasCheckedJump)
                    {
                        if (Networking.LocalPlayer.GetJumpImpulse() == 0f)
                        {
                            HasCheckedJump = true;
                            Networking.LocalPlayer.SetJumpImpulse(4);
                        }
                        else
                        {
                            HasCheckedJump = true;
                        }
                    }
                }
            }
            catch
            {
                HasCheckedJump = false;
            }
        }


        public static void CheckForJumpUpdates()
        {
            if (GetLocalVRCPlayer() != null)
            {
                if (LocalPlayerUtils.GetLocalPlayerAPI() != null)
                {
                    if (InputUtils.IsImputJumpCalled())
                    {
                        if (LocalPlayerUtils.isPlayerGrounded() && IsJumpOverriden)
                        {
                            EmulatedJump();
                        }
                        else
                        {
                            if (!LocalPlayerUtils.isPlayerGrounded() && IsUnlimitedJumpActive)
                            {
                                EmulatedJump();
                            }
                        }
                    }

                    if (InputUtils.isInputJumpPressed() && isRocketJumpActive)
                    {
                        EmulatedJump();
                    }

                }


            }
        }

        public static void EmulatedJump()
        {
            Vector3 velocity = Networking.LocalPlayer.GetVelocity();
            velocity.y = Networking.LocalPlayer.GetJumpImpulse();
            Networking.LocalPlayer.SetVelocity(velocity);
        }

        //Credit : Dayclient Owner ( dayoftheplay )
        public static void CustomSerialize(bool Toggle)
        {
            try
            {
                if (VRC.Core.APIUser.CurrentUser != null)
                {
                    if (VRC.Core.APIUser.CurrentUser.GetPlayer() != null)
                    {
                        var original = VRC.Core.APIUser.CurrentUser.GetPlayer().prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_GameObject_0;
                        if (original != null)
                        {
                            if (Toggle)
                            {
                                Capsule = GameObject.Instantiate(original, null, true);
                                var animator = Capsule.GetComponent<Animator>();
                                if (animator != null
                                    && animator.isHuman)
                                {
                                    var headTransform = animator.GetBoneTransform(HumanBodyBones.Head);
                                    if (headTransform != null)
                                        headTransform.localScale = Vector3.one;
                                }
                                Capsule.name = "Serialize Capsule";
                                animator.enabled = false;
                                Capsule.GetComponent<FullBodyBipedIK>().enabled = false;
                                Capsule.GetComponent<LimbIK>().enabled = false;
                                Capsule.GetComponent<VRIK>().enabled = false;
                                Capsule.GetComponent<LookTargetController>().enabled = false;
                                Capsule.transform.position = original.transform.position;
                                Capsule.transform.rotation = original.transform.rotation;
                            }
                            if (!Toggle)
                            {
                                UnityEngine.Object.Destroy(Capsule);
                                //Utils.CurrentUser.gameObject.GetComponentInChildren<FlatBufferNetworkSerializer>().enabled = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static List<GameObject> ClonesCapsules = new List<GameObject>();

        //Credit : Dayclient Owner ( dayoftheplay )
        public static void SpawnClone()
        {
            try
            {
                if (VRC.Core.APIUser.CurrentUser != null)
                {
                    if (VRC.Core.APIUser.CurrentUser.GetPlayer() != null)
                    {
                        var original = VRC.Core.APIUser.CurrentUser.GetPlayer().prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_GameObject_0;
                        if (original != null)
                        {
                            var clone = GameObject.Instantiate(original, null, true);
                            var animator = clone.GetComponent<Animator>();
                            if (animator != null
                                && animator.isHuman)
                            {
                                var headTransform = animator.GetBoneTransform(HumanBodyBones.Head);
                                if (headTransform != null)
                                    headTransform.localScale = Vector3.one;
                            }
                            clone.name = "Avatar Local Clone";
                            animator.enabled = false;
                            clone.GetComponent<FullBodyBipedIK>().enabled = false;
                            clone.GetComponent<LimbIK>().enabled = false;
                            clone.GetComponent<VRIK>().enabled = false;
                            //clone.GetComponent<LookTargetController>().enabled = false;
                            clone.transform.position = original.transform.position;
                            clone.transform.rotation = original.transform.rotation;
                            ClonesCapsules.Add(clone);
                        }
                    }
                }
            }
            catch { }
        }

        public static void RemoveClones()
        {
            try
            {
                foreach (var clone in ClonesCapsules)
                {
                    if (clone != null)
                    {
                        clone.gameObject.DestroyMeLocal();
                    }
                }
                ClonesCapsules.Clear();
            }
            catch { }
        }

        public static void ToggleSerializer()
        {
            Bools.SerializerEnabled = !Bools.SerializerEnabled;
            CustomSerialize(Bools.SerializerEnabled);
            if (SerializerBtn != null)
            {
                SerializerBtn.setToggleState(Bools.SerializerEnabled);
            }
        }

        private static bool _IsUnlimitedJumpActive;

        public static QMSingleToggleButton UnlimitedJumpToggle;
        public static bool IsUnlimitedJumpActive
        {
            get
            {
                return _IsUnlimitedJumpActive;
            }
            set
            {
                _IsUnlimitedJumpActive = value;
                if (UnlimitedJumpToggle != null)
                {
                    UnlimitedJumpToggle.setToggleState(value);
                }
            }
        }

        public static QMSingleToggleButton RocketJumpToggle;

        private static bool _isRocketJumpActive;
        public static bool isRocketJumpActive
        {
            get
            {
                return _isRocketJumpActive;
            }
            set
            {
                _isRocketJumpActive = value;
                if (RocketJumpToggle != null)
                {
                    RocketJumpToggle.setToggleState(value);
                }
            }
        }



        public static QMToggleButton JumpOverrideToggle;
        private static bool _IsJumpOverriden;
        public static bool IsJumpOverriden
        {
            get
            {
                return _IsJumpOverriden;
            }
            set
            {
                _IsJumpOverriden = value;
                if(JumpOverrideToggle != null)
                {
                    JumpOverrideToggle.setToggleState(value);
                }
            }
        }



        private static QMToggleButton SerializerBtn;
        public static GameObject Capsule;





    }
}