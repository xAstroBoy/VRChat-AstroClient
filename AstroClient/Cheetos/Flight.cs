namespace AstroClient
{
    #region Imports

    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.Animation;

    #endregion Imports

    /// <summary>
    /// Thanks to Blaze <3
    /// Fixed by Cheetos.
    /// </summary>
    internal class Flight : GameEvents
    {
        private static Vector3 Gravity;
        private static VRCPlayer currentPlayer;
        private static bool isInVR;
        private static Transform transform;
        private static VRCMotionState motionState;
        private static bool flyEnabled;
        private static bool noClipEnabled;
        private static bool isInRoom;

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            Gravity = Physics.gravity;
            motionState = currentPlayer.GetComponent<VRCMotionState>();
            DisableNoClip();
            DisableFly();
        }

        public static void SetDesktopFlySpeed(float v)
        {
            ConfigManager.Flight.DesktopFlySpeed = v;
        }

        public static void SetVRFlySpeed(float v)
        {
            ConfigManager.Flight.VRFlySpeed = v;
        }

        public static bool FlyEnabled
        {
            get => flyEnabled;
            set
            {
                if (value)
                {
                    EnableFly();
                }
                else
                {
                    DisableNoClip();
                    DisableFly();
                }

                PlayerUtils.GetPlayer().gameObject.GetComponent<CharacterController>().enabled = value;
                ExploitsMenu.RefreshFlightButtons();
            }
        }

        private static void EnableFly()
        {
            flyEnabled = true;
            Physics.gravity = Vector3.zero;
        }

        private static void DisableFly()
        {
            flyEnabled = false;
            Physics.gravity = Gravity;
        }

        public static bool NoClipEnabled
        {
            get => noClipEnabled;
            set
            {
                if (value)
                {
                    EnableFly();
                    EnableNoClip();
                }
                else
                {
                    DisableNoClip();
                    DisableFly();
                }

                ExploitsMenu.RefreshFlightButtons();
            }
        }

        private static void EnableNoClip()
        {
            noClipEnabled = true;
            PlayerUtils.VRCPlayer.gameObject.GetComponent<CharacterController>().enabled = false;
        }

        private static void DisableNoClip()
        {
            noClipEnabled = false;
            PlayerUtils.VRCPlayer.gameObject.GetComponent<CharacterController>().enabled = true;
        }

        public override void OnRoomJoined()
        {
            isInRoom = true;
        }

        public override void OnRoomLeft()
        {
            isInRoom = false;
            FlyEnabled = false;
            NoClipEnabled = false;
        }

        public override void OnUpdate()
        {
            if (!isInRoom || PopupUtils.IsTyping)
            {
                return;
            }

            try
            {
                if (currentPlayer == null || transform == null)
                {
                    currentPlayer = PlayerUtils.VRCPlayer;
                    isInVR = currentPlayer.IsInVR();
                    transform = Camera.main.transform;
                }

                if (!ModDetector.FindMods.IsNotoriousPresent && ConfigManager.General.KeyBinds)
                {
                    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F))
                    {
                        FlyEnabled = !FlyEnabled;
                        ExploitsMenu.RefreshFlightButtons();
                    }

                    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G))
                    {
                        NoClipEnabled = !NoClipEnabled;
                        ExploitsMenu.RefreshFlightButtons();
                    }
                }

                if (FlyEnabled)
                {
                    float flySpeed = isInVR ? ConfigManager.Flight.VRFlySpeed : ConfigManager.Flight.DesktopFlySpeed;

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        flySpeed *= 2;
                    }

                    if (ConfigManager.Flight.BasicFly)
                    {
                        if (isInVR)
                        {
                            if (Math.Abs(Input.GetAxis("Vertical")) != 0f)
                                currentPlayer.transform.position += currentPlayer.transform.forward *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxis("Vertical");

                            if (Math.Abs(Input.GetAxis("Horizontal")) != 0f)
                                currentPlayer.transform.position += currentPlayer.transform.right *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxis("Horizontal");

                            if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
                                currentPlayer.transform.position += currentPlayer.transform.up *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxisRaw(
                                                                        "Oculus_CrossPlatform_SecondaryThumbstickVertical");
                            if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
                                currentPlayer.transform.position += currentPlayer.transform.up *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxisRaw(
                                                                        "Oculus_CrossPlatform_SecondaryThumbstickVertical");
                        }
                        else
                        {
                            if (Input.GetKey(KeyCode.E))
                                currentPlayer.transform.position += currentPlayer.transform.up *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.Q))
                                currentPlayer.transform.position += currentPlayer.transform.up * -1 *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.W))
                                currentPlayer.transform.position += currentPlayer.transform.forward *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.A))
                                currentPlayer.transform.position += currentPlayer.transform.right * -1f *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.D))
                                currentPlayer.transform.position += currentPlayer.transform.right *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.S))
                                currentPlayer.transform.position += currentPlayer.transform.forward * -1f *
                                                                    flySpeed * Time.deltaTime;
                        }
                    }
                    else
                    {
                        if (isInVR)
                        {
                            if (Math.Abs(Input.GetAxis("Vertical")) != 0f)
                                currentPlayer.transform.position += transform.transform.forward *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxis("Vertical");

                            if (Math.Abs(Input.GetAxis("Horizontal")) != 0f)
                                currentPlayer.transform.position += transform.transform.right *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxis("Horizontal");

                            if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
                                currentPlayer.transform.position += transform.transform.up *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxisRaw(
                                                                        "Oculus_CrossPlatform_SecondaryThumbstickVertical");
                            if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
                                currentPlayer.transform.position += transform.transform.up *
                                                                    flySpeed * Time.deltaTime *
                                                                    Input.GetAxisRaw(
                                                                        "Oculus_CrossPlatform_SecondaryThumbstickVertical");
                        }
                        else
                        {
                            if (Input.GetKey(KeyCode.E))
                                currentPlayer.transform.position += transform.transform.up *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.Q))
                                currentPlayer.transform.position += transform.transform.up * -1 *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.W))
                                currentPlayer.transform.position += transform.transform.forward *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.A))
                                currentPlayer.transform.position += transform.transform.right * -1f *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.D))
                                currentPlayer.transform.position += transform.transform.right *
                                                                    flySpeed * Time.deltaTime;

                            if (Input.GetKey(KeyCode.S))
                                currentPlayer.transform.position += transform.transform.forward * -1f *
                                                                    flySpeed * Time.deltaTime;
                        }
                    }
                }

                //if (motionState != null)
                //{
                //	motionState.Reset();
                //}
            }
            catch { }
        }
    }
}