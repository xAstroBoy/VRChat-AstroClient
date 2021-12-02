using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using VRC.Animation;
using VRC.SDKBase;
using VRC.UI.Elements;
using AstroClient.ClientAttributes;

namespace Movement
{

    [RegisterComponent]
    internal class FlyMode : MonoBehaviour
    {
        public FlyMode(IntPtr ptr) : base(ptr)
        {
        }


        internal static bool IsInVR;
        private protected void Start()
        {
            if (XRDevice.isPresent)
                IsInVR = true;
        }

        internal static float VerticalSpeed = 0f;
        internal static float FlySpeed = 0.0f;
        internal static bool Enable = false;
        internal static bool EnableNoC = false;
        internal static VRC.Player Player= null;

        internal static IEnumerator DesktopFlightSupport()
        {

            if (Player == null)
                Player = VRCPlayer.field_Internal_Static_VRCPlayer_0._player;

            if (motionState == null)
                motionState = Player.GetComponent<VRCMotionState>();

            if (RoomManager.field_Internal_Static_ApiWorld_0 != null)
            {

                for (; ; )
                {
                    try
                    {


                        if (IsFlyEnabled)
                        {
                            int num = Input.GetKey(KeyCode.LeftShift) ? 8 : 4;


                            if (Player != null)
                            {
                                Vector3 position = Player.transform.position;
                                float num2 = 0f;

                                if (IsInVR) // User is in VR, give them VR controls.
                                {
                                    Vector2 axis2D = null; // Your input for VR Axis;
                                    num2 += (System.Math.Abs(axis2D.y) > 0.05 ? (axis2D.y / 15f) : 0f);
                                }

                                if (Input.GetKey(KeyCode.Q))
                                {
                                    num2 -= num * (Time.deltaTime + FlySpeed / 6);
                                }
                                else
                                {
                                    if (Input.GetKey(KeyCode.E))
                                    {
                                        num2 += num * (Time.deltaTime + FlySpeed / 6);
                                    }
                                }

                                if (num2 != 0f)
                                {
                                    Player.transform.position = new Vector3(position.x, position.y + num2, position.z);
                                }

                                if (motionState != null)
                                {
                                    motionState.Reset();
                                }
                            }
                        }
                    }
                    catch (Exception) { }


                    yield return null;

                    if (StopCoroutine)
                        yield break;
                }

            }

        }

        

        internal static new bool StopCoroutine = false;

        internal static void Toggle(bool DissableDFly)
        {
            //if (DirectionalFly.IsDirecFlyEnable && DissableDFly)
            //{
            //    MenuAPI_New.WingPage_Movement_Fly.setOnText();
            //    DirectionalFly.ToggleFly();
            //}

            IsFlyEnabled = !IsFlyEnabled;
            bool flag = !IsFlyEnabled && IsNoclipEnabled;
            if (flag)
            {
                ToggleNoClip();
            }
            bool isFlyEnabled = IsFlyEnabled;
            if (isFlyEnabled)
            {
                StopCoroutine = false;
                DesktopFlightSupport().Coroutine();
                //MenuAPI_New.WingPage_Movement_Fly.setOnText();

                if (FlySpeed == 0)
                {

                    //if (MenuSettings.GlobalSettings.Custom_Run_Speed != 0)
                    //    VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(MenuSettings.GlobalSettings.Custom_Run_Speed);
                    //else
                    //    VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(4);


                    //if (MenuSettings.GlobalSettings.Custom_Run_Speed != 0)
                    //    VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(MenuSettings.GlobalSettings.Custom_Walk_Speed);
                    //else
                    //    VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(3);

                }
                else
                {
                    VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(FlySpeed * 18);
                    VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(FlySpeed * 22);
                }
                originalGravity = Physics.gravity;
                Physics.gravity = Vector3.zero;
            }
            else
            {
                StopCoroutine = true;
                    //MenuAPI_New.WingPage_Movement_Fly.setOffText();

                    //if (MenuSettings.GlobalSettings.Custom_Run_Speed != 0)
                    //    VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(MenuSettings.GlobalSettings.Custom_Run_Speed);
                    //else
                    //    VRC.SDKBase.Networking.LocalPlayer.SetRunSpeed(4);


                    //if (MenuSettings.GlobalSettings.Custom_Run_Speed != 0)
                    //    VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(MenuSettings.GlobalSettings.Custom_Walk_Speed);
                    //else
                    //    VRC.SDKBase.Networking.LocalPlayer.SetWalkSpeed(3);

                Physics.gravity = originalGravity;
            }
        }

        internal static void ToggleNoClip()
        {


            IsNoclipEnabled = !IsNoclipEnabled;
            bool flag = !IsFlyEnabled && IsNoclipEnabled;
            if (flag)
            {
                Toggle(false);
            }
            NoClip(IsNoclipEnabled);

            //if (IsNoclipEnabled)
            //{
            //    MenuAPI_New.WingPage_Movement_NoClip.setOnText();
            //}
            //else
            //{
            //    MenuAPI_New.WingPage_Movement_NoClip.setOffText();
            //}
        }
        internal static void NoClip(bool enable)
        {
            Collider[] array = UnityEngine.Object.FindObjectsOfType<Collider>();
            Component y = VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponents(Collider.Il2CppType).FirstOrDefault<Component>();
            foreach (Collider collider in array)
            {
                bool flag = collider.GetComponent<PlayerSelector>() != null || collider.GetComponent<VRC_Pickup>() != null || collider.GetComponentInChildren<VRC.UI.Elements.QuickMenu>() != null || collider.GetComponentInParent<VRC.UI.Elements.QuickMenu>() != null || collider.GetComponent<VRCSDK2.VRC_Station>() != null || collider.GetComponent<VRC_AvatarPedestal>() != null;
                if (flag)
                {
                    collider.enabled = true;
                }
                else
                {
                    bool flag2 = collider != y && ((enable && collider.enabled) || (!enable && noClipToEnable.Contains(collider.GetInstanceID())));
                    if (flag2)
                    {
                        collider.enabled = !enable;
                        if (enable)
                        {
                            noClipToEnable.Add(collider.GetInstanceID());
                        }
                    }
                }
            }
            bool flag3 = !enable;
            if (flag3)
            {
                noClipToEnable.Clear();
            }
        }

        internal static List<int> noClipToEnable = new List<int>();

        internal static bool IsFlyEnabled;

        internal static bool IsNoclipEnabled;

        internal static VRCMotionState motionState;

        internal static Vector3 originalGravity;
    }
}
