namespace AstroClient
{
    using CheetosLibrary;
    using MelonLoader;
    using System;
    using System.Collections;
    using UnityEngine;

    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("AstroClient");

            _ = MelonCoroutines.Start(OnUiManagerInitCoro(() => { AfterUI(); }));
        }

        private void AfterUI()
        {
            var junk = GameObject.Find(UIPaths.Banner);
            if (junk != null) junk.SetActive(false);

            MelonLogger.Msg("UI Initialized.");
        }

        private IEnumerator OnUiManagerInitCoro(Action code)
        {
            while (GameObject.Find(UIPaths.QuickMenu) == null)
                yield return new WaitForSeconds(0.001f);

            code();
        }
    }
}

namespace CheetosLibrary
{
    public class Utils
    {

    }
}
