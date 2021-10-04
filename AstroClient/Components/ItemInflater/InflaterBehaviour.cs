namespace AstroClient.Components
{
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;


    [RegisterComponent]

    public class InflaterBehaviour : GameEventsBehaviour
    {
        public InflaterBehaviour(IntPtr ptr) : base(ptr)
        {
        }


        // Use this for initialization
        private void Start()
        {
            NewSize = gameObject.transform.localScale;
            OriginalSize = gameObject.transform.localScale;
        }

        private void OnDestroy()
        {
            gameObject.transform.localScale = OriginalSize;
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (gameObject != null)
                {
                    if (Time.time - LastTimeCheck > InflateTimer)
                    {
                        if (gameObject.transform.localScale != NewSize)
                        {
                            // X
                            FixX();
                            // Y
                            FixY();
                            // Z
                            FixZ();
                            // Update Button

                            // TODO: Figure a way to update the button remotely. (event)
                            //GamegameObjectectActualScale.SetButtonText("gameObjectect 's Current scale : " + gameObject.transform.localScale.ToString());
                        }
                        LastTimeCheck = Time.time;
                    }
                }
            }
            catch (Exception)
            {
                DestroyImmediate(this);
            }
        }

        private void FixX()
        {
            if (gameObject.transform.localScale.x <= NewSize.x)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.1f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            if (gameObject.transform.localScale.x >= NewSize.x)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.1f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }

        private void FixY()
        {
            if (gameObject.transform.localScale.y <= NewSize.y)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y + 0.1f, gameObject.transform.localScale.z);
            }
            if (gameObject.transform.localScale.y >= NewSize.y)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y - 0.1f, gameObject.transform.localScale.z);
            }
        }

        private void FixZ()
        {
            if (gameObject.transform.localScale.z <= NewSize.z)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z + 0.1f);
            }
            if (gameObject.transform.localScale.z >= NewSize.z)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z - 0.1f);
            }
        }

        internal float TimerOffset = 0f;
        private float LastTimeCheck = 0;
        private float InflateTimer = 0.05f;
        internal Vector3 NewSize;

        internal Vector3 OriginalSize;

    }
}