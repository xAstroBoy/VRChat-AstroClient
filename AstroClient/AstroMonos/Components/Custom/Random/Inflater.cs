﻿namespace AstroClient.AstroMonos.Components.Custom.Random
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class InflaterBehaviour : AstroMonoBehaviour
    {
        private Vector3 _NewSize;
        private float InflateTimer = 0.05f;
        private float LastTimeCheck;

        private Vector3 OriginalSize;

        internal float TimerOffset = 0f;

        public InflaterBehaviour(IntPtr ptr) : base(ptr)
        {
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal Vector3 NewSize
        {
            [HideFromIl2Cpp] get => _NewSize;
            [HideFromIl2Cpp]
            set
            {
                _NewSize = value;
                Run_OnOnInflaterPropertyChanged();
            }
        }

        // Use this for initialization
        private void Start()
        {
            NewSize = gameObject.transform.localScale;
            OriginalSize = gameObject.transform.localScale;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time - LastTimeCheck > InflateTimer)
            {
                if (gameObject.transform.localScale != NewSize)
                {
                    FixX();
                    FixY();
                    FixZ();
                }

                Run_OnOnInflaterUpdate();
                LastTimeCheck = Time.time;
            }
        }

        private void OnDestroy()
        {
            gameObject.transform.localScale = OriginalSize;
        }

        private void FixX()
        {
            if (gameObject.transform.localScale.x <= NewSize.x) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.1f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            if (gameObject.transform.localScale.x >= NewSize.x) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.1f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

        private void FixY()
        {
            if (gameObject.transform.localScale.y <= NewSize.y) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y + 0.1f, gameObject.transform.localScale.z);
            if (gameObject.transform.localScale.y >= NewSize.y) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y - 0.1f, gameObject.transform.localScale.z);
        }

        private void FixZ()
        {
            if (gameObject.transform.localScale.z <= NewSize.z) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z + 0.1f);
            if (gameObject.transform.localScale.z >= NewSize.z) gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z - 0.1f);
        }

        #region actions

        private void Run_OnOnInflaterPropertyChanged()
        {
            OnInflaterPropertyChanged?.Invoke();
        }

        internal void SetOnInflaterPropertyChanged(Action action)
        {
            OnInflaterPropertyChanged += action;
        }

        private void Run_OnOnInflaterUpdate()
        {
            OnInflaterUpdate?.Invoke();
        }

        internal void SetOnInflaterUpdate(Action action)
        {
            OnInflaterUpdate += action;
        }

        internal void RemoveActionEvents()
        {
            OnInflaterPropertyChanged = null;
            OnInflaterUpdate = null;
        }

        private event Action? OnInflaterPropertyChanged;

        private event Action? OnInflaterUpdate;

        #endregion actions
    }
}