
using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds;
using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds.PriceGuess;
using AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki.QuickDraws;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.febucci;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AstroClient.WorldModifications.WorldHacks.Jar.PriceGuess
{
    internal class PriceGuess : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private bool _HasSubscribed = false;

        private bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                    }
                }
                _HasSubscribed = value;
            }
        }

        private void OnRoomLeft()
        {
            AnswerToggleButton = null;
            ShowAnswers = false;
            Text_Clue = null;
            Answer_TextTransf = null;
            Answer_Text = null;
            Reader = null;
            StageCanvas = null;

            HasSubscribed = false;
        }

        // Copy all settings from TextMeshProUGui on the new copy

        private void SpawnSolutionViewer()
        {
            if (Text_Clue != null)
            {
                if (Answer_TextTransf == null)
                {
                    Answer_TextTransf = Object.Instantiate(Text_Clue, StageCanvas);
                }
                if (Answer_TextTransf != null)
                {
                    Answer_TextTransf.name = "Solution Viewer";
                    Answer_TextTransf.transform.localPosition = new Vector3(-1008f, 295.6356f, -185.3f);
                    Answer_TextTransf.transform.localRotation = Quaternion.Euler(new Vector3(0f, 314.9216f, 0f));
                    Answer_Text = Answer_TextTransf.GetComponent<Text>();
                    if(Answer_Text != null)
                    {
                        Answer_Text.text = "";
                        Answer_Text.fontSize = 50;
                    }
                    //Answer_TextTransf.gameObject.SetActive(false);
                    //Answer_TextMesh_Animator = Answer_Text.GetOrAddComponent<TextAnimator>();
                }

            }
        }

        private void SetupWorldButtons()
        {
            if (AnswerToggleButton == null)
            {
                AnswerToggleButton = new WorldButton_Squared(new Vector3(-4.063f, 1.759608f, 10.56358f), new Vector3(0f, 354.64f, 270f), 2f, "<rainb>Show Answers!</rainb>", AnswerToggleButton_Pressed);
            }

        }

        private void FindEverything()
        {
            var Root = Finder.Find("_Environment");
            StageCanvas = Root.FindObject("Architecture/multiscreen/Game Canvas/Stage Item").transform;
            Text_Clue = StageCanvas.FindObject("Reveal Animation/Reveal Title Text").transform;
            Reader = Finder.Find("PriceGame").GetOrAddComponent<PriceGuess_Controller_reader>();
            SetupWorldButtons();
            SpawnSolutionViewer();
        }

        private void AnswerToggleButton_Pressed()
        {
            if(Answer_Text == null)
            {
                SpawnSolutionViewer();
            }
            ShowAnswers = !ShowAnswers;
            if (ShowAnswers)
            {
                //Answer_TextTransf.gameObject.SetActive(true);
                Reader.RevealAnswer();
                AnswerToggleButton.SetText("<color=red>Hide Answers!</color>");
            }
            else
            {
                //Answer_TextTransf.gameObject.SetActive(false);
                Answer_Text.text = "";
                AnswerToggleButton.SetText("<rainb>Show Answers!</rainb>");
            }
        }

        

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.PriceGuess))
            {
                isCurrentWorld = true;
                HasSubscribed = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
            }
        }
        private static Transform StageCanvas { get; set; }

        private static Transform Text_Clue { get; set; }
        private static Transform Answer_TextTransf { get; set; }
        internal static Text Answer_Text { get; set; }
        private static WorldButton_Squared AnswerToggleButton { get; set; }
        internal static bool ShowAnswers { get; set; } = false;
        internal static PriceGuess_Controller_reader Reader { get; set; }
        private static bool isCurrentWorld = false;
    }
}