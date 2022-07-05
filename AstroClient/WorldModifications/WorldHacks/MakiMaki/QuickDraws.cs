using AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense;
using AstroClient.CheetosUI;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;

    internal class QuickDraws : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void FindEverything()
        {
            Customization = GameObjectFinder.Find("----UI----/RightSettings/Customization");
            MakiKeyboard = GameObjectFinder.Find("----SYSTEMS----/KeyboardToggle/MakiKeyboard");
            PlayerPermissionManager = GameObjectFinder.Find("----SYSTEMS----/PlayerManager/PlayerPermissionManager");
            _ = CustomizationReader;
            _ = MakiKeyboardReader;
            _ = PlayerPermissionManagerReader; 

            if(MakiKeyboardReader != null)
            {
                AnswerRevealer = new WorldButton(new Vector3(4.6627f, 1.7976f, 10.8649f), new Vector3(0, 320, 0), null, "<rainb>Click Me to Reveal Words!</rainb>", () =>
                {

                    ShowAnswers = !ShowAnswers;
                    if(!ShowAnswers)
                    {
                        AnswerRevealer.SetText("<rainb>Click Me to Reveal Words!</rainb>");
                    }
                    else
                    {
                        MakiKeyboardReader.RevealAnswer();
                    }
                });
                AnswerRevealer.SetScale(new Vector3(0.23f, 0.5f, 1.2527f));
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.QuickDraws))
            {
                isCurrentWorld = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
                ShowAnswers = false;
            }
        }
        private static GameObject PlayerPermissionManager = null;

        internal static WorldButton AnswerRevealer = null;

        private static GameObject Customization = null;

        private static QuickDraws_CustomizationReader _customizationReader;

        internal static bool ShowAnswers = false;

        public static QuickDraws_CustomizationReader CustomizationReader
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_customizationReader == null)
                {
                    if (Customization != null)
                    {
                        return _customizationReader = Customization.GetOrAddComponent<QuickDraws_CustomizationReader>();
                    }
                }
                return _customizationReader;

            }
        }
        private static GameObject MakiKeyboard = null;

        private static QuickDraws_MakiKeyboardReader _MakiKeyboardReader;

        public static QuickDraws_MakiKeyboardReader MakiKeyboardReader
        {
            get
            {
                if (!isCurrentWorld) return null;

                if (_MakiKeyboardReader == null)
                {
                    if (MakiKeyboard != null)
                    {
                        return _MakiKeyboardReader = MakiKeyboard.GetOrAddComponent<QuickDraws_MakiKeyboardReader>();
                    }
                }
                return _MakiKeyboardReader;

            }
        }
        private static QuickDraws_PlayerPermissionReader _PlayerPermissionManagerReader;

        public static QuickDraws_PlayerPermissionReader PlayerPermissionManagerReader
        {
            get
            {
                if (!isCurrentWorld) return null;

                if (_PlayerPermissionManagerReader == null)
                {
                    if (PlayerPermissionManager != null)
                    {
                        return _PlayerPermissionManagerReader = PlayerPermissionManager.GetOrAddComponent<QuickDraws_PlayerPermissionReader>();
                    }
                }
                return _PlayerPermissionManagerReader;

            }
        }

        private static bool isCurrentWorld = false;
    }
}