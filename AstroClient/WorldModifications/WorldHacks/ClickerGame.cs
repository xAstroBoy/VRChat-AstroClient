namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using CustomClasses;
    using MelonLoader;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class ClickerGame : AstroEvents
    {
        internal static void InitButtons(QMGridTab main)
        {
            ClickerGameCheats = new QMNestedGridMenu(main, "Clicker Game", "Clicker Game AutoClicker");
            AutoClickerButton = new QMToggleButton(ClickerGameCheats, "AutoClicker", () => { CubeAutoClicker = true; }, () => { CubeAutoClicker = false; }, "Toggle AutoClicker (Power of 10 people!)");
        }

        internal static QMNestedGridMenu ClickerGameCheats { get; set; }
        internal static QMToggleButton AutoClickerButton { get; set; }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Clicker_Game)
            {
                if (ClickerGameCheats != null)
                {
                    ClickerGameCheats.SetInteractable(true);
                    ClickerGameCheats.SetTextColor(Color.green);
                }
                Log.Write($"Recognized {Name} World, AutoClicker Available!....");
                CubeClicker = UdonSearch.FindUdonEvent("MainButton", "_interact");
            }
            else
            {
                if (ClickerGameCheats != null)
                {
                    ClickerGameCheats.SetInteractable(false);
                    ClickerGameCheats.SetTextColor(Color.red);
                }
            }
        }

        internal override void OnRoomLeft()
        {
            CubeAutoClicker = false;
            CubeClicker = null;
            CancellationToken_1 = null;
            CancellationToken_2 = null;
            CancellationToken_3 = null;
            CancellationToken_4 = null;
            CancellationToken_5 = null;
            CancellationToken_6 = null;
            CancellationToken_7 = null;
            CancellationToken_8 = null;
            CancellationToken_9 = null;
            CancellationToken_10 = null;
        }

        private static IEnumerator AutoClickerRoutine1()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine2()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine3()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine4()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine5()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine6()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine7()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine8()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine9()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static IEnumerator AutoClickerRoutine10()
        {
            while (CubeAutoClicker)
            {
                if (CubeClicker != null)
                {
                    CubeClicker.InvokeBehaviour();
                }
                yield return null;
            }
            yield return null;
        }

        private static bool _CubeAutoClicker;

        internal static bool CubeAutoClicker
        {
            get
            {
                return _CubeAutoClicker;
            }
            set
            {
                _CubeAutoClicker = value;
                if (value)
                {
                    if (CancellationToken_1 == null)
                    {
                        CancellationToken_1 = MelonCoroutines.Start(AutoClickerRoutine1());
                    }

                    if (CancellationToken_2 == null)
                    {
                        CancellationToken_2 = MelonCoroutines.Start(AutoClickerRoutine2());
                    }

                    if (CancellationToken_3 == null)
                    {
                        CancellationToken_3 = MelonCoroutines.Start(AutoClickerRoutine3());
                    }

                    if (CancellationToken_4 == null)
                    {
                        CancellationToken_4 = MelonCoroutines.Start(AutoClickerRoutine4());
                    }

                    if (CancellationToken_5 == null)
                    {
                        CancellationToken_5 = MelonCoroutines.Start(AutoClickerRoutine5());
                    }

                    if (CancellationToken_6 == null)
                    {
                        CancellationToken_6 = MelonCoroutines.Start(AutoClickerRoutine6());
                    }

                    if (CancellationToken_7 == null)
                    {
                        CancellationToken_7 = MelonCoroutines.Start(AutoClickerRoutine7());
                    }

                    if (CancellationToken_8 == null)
                    {
                        CancellationToken_8 = MelonCoroutines.Start(AutoClickerRoutine8());
                    }

                    if (CancellationToken_9 == null)
                    {
                        CancellationToken_9 = MelonCoroutines.Start(AutoClickerRoutine9());
                    }

                    if (CancellationToken_10 == null)
                    {
                        CancellationToken_10 = MelonCoroutines.Start(AutoClickerRoutine10());
                    }
                }
                else
                {
                    if (CancellationToken_1 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_1);
                    }

                    if (CancellationToken_2 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_2);
                    }

                    if (CancellationToken_3 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_3);
                    }

                    if (CancellationToken_4 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_4);
                    }

                    if (CancellationToken_5 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_5);
                    }

                    if (CancellationToken_6 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_6);
                    }

                    if (CancellationToken_7 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_7);
                    }

                    if (CancellationToken_8 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_8);
                    }

                    if (CancellationToken_9 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_9);
                    }

                    if (CancellationToken_10 != null)
                    {
                        MelonCoroutines.Stop(CancellationToken_10);
                    }

                    CancellationToken_1 = null;
                    CancellationToken_2 = null;
                    CancellationToken_3 = null;
                    CancellationToken_4 = null;
                    CancellationToken_5 = null;
                    CancellationToken_6 = null;
                    CancellationToken_7 = null;
                    CancellationToken_8 = null;
                    CancellationToken_9 = null;
                    CancellationToken_10 = null;
                }
            }
        }

        private static object CancellationToken_1 { get; set; }
        private static object CancellationToken_2 { get; set; }
        private static object CancellationToken_3 { get; set; }
        private static object CancellationToken_4 { get; set; }
        private static object CancellationToken_5 { get; set; }
        private static object CancellationToken_6 { get; set; }
        private static object CancellationToken_7 { get; set; }
        private static object CancellationToken_8 { get; set; }
        private static object CancellationToken_9 { get; set; }
        private static object CancellationToken_10 { get; set; }

        private static UdonBehaviour_Cached CubeClicker { get; set; }
    }
}