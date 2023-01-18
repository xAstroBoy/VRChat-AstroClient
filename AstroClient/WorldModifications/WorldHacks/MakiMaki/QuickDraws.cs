
using System.Collections.Generic;
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

namespace AstroClient.WorldModifications.WorldHacks.MakiMaki
{
    internal class QuickDraws : AstroEvents
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
            Text_Clue = null;
            Answer_Text = null;
            Answer_TextMesh = null;
            Answer_TextMesh_Animator = null;
            PlayerPermissionManager = null;
            StageCollider = null;
            Customization = null;
            Pen_Pickup = null;
            Pen_ForceActive = null;
            Pen_PickupController = null;
            AnswerToggleButton = null;
            StageColliderToggleBtn = null;
            PenTheftToggleBtn = null;
            ShowAnswers = false;
            DisableStageCollider = false;
            ForceStealPencil = false;
            Pen_InteractionCollider = null;
            MakiKeyboard = null;
            _PlayerPermissionManagerReader = null;
            _customizationReader = null;
            _MakiKeyboardReader = null;
            HasSubscribed = false;
        }

        // Copy all settings from TextMeshProUGui on the new copy

        private void SpawnSolutionViewer()
        {
            if (Text_Clue != null)
            {
                if (Answer_Text == null)
                {
                    Answer_Text = Object.Instantiate(Text_Clue, Text_Clue.transform.parent);
                }
                if (Answer_Text != null)
                {
                    Answer_Text.name = "Solution Viewer";
                    Answer_Text.transform.localPosition = new Vector3(0, -98, 0);
                    Answer_TextMesh = Answer_Text.GetComponent<TextMeshProUGUI>();
                    Answer_TextMesh_Animator = Answer_Text.GetOrAddComponent<TextAnimator>();
                }

            }
        }


        private void SetupPenHijacker()
        {
            Pen_PickupController = Pen_Pickup.GetOrAddComponent<PickupController>();
            Pen_ForceActive = Pen_Pickup.GetOrAddComponent<Enabler>();
            Pen_InteractionCollider = Pen_Pickup.AddComponent<BoxCollider>();
            if (Pen_InteractionCollider != null)
            {
                Pen_InteractionCollider.isTrigger = true;
                Pen_InteractionCollider.enabled = false;
            }
            Pen_ForceActive.enabled = false;
        }

        private void SetupWorldButtons()
        {
            if (AnswerToggleButton == null)
            {
                if (MakiKeyboardReader != null)
                {
                    AnswerToggleButton = new WorldButton_Squared(new Vector3(-5.081f, 1.284f, 10.159f), new Vector3(0, -330f, -90f), "<rainb>Show Answers!</rainb>", AnswerToggleButton_Pressed);
                    AnswerToggleButton.SetScale(1f);
                    AnswerToggleButton.Controller.SetButtonToggle(ShowAnswers);
                }
            }
            if (StageColliderToggleBtn == null)
            {
                if (StageCollider != null)
                {
                    StageColliderToggleBtn = new WorldButton_Squared(new Vector3(-5.081f, 1.065f, 10.159f), new Vector3(0, -330f, -90f), "<color=red>Disable Stage collision Block</color>", StageColliderToggleBtn_Pressed);
                    StageColliderToggleBtn.SetScale(1f);
                    StageColliderToggleBtn.Controller.SetButtonToggle(DisableStageCollider);
                }
            }
            if (PenTheftToggleBtn == null)
            {
                if (Pen_Pickup != null)
                {
                    PenTheftToggleBtn = new WorldButton_Squared(new Vector3(-5.081f, 0.83f, 10.159f), new Vector3(0, -330f, -90f), "<color=red>Force Allow Pen Interaction!</color>", PenTheftToggleBtn_Pressed);
                    PenTheftToggleBtn.SetScale(1f);
                    PenTheftToggleBtn.Controller.SetButtonToggle(ForceStealPencil);
                }
            }
        }

        private void FindEverything()
        {
            var UI = Finder.Find("----UI----");
            if (UI != null)
            {
                Customization = UI.FindObject("RightSettings/Customization").transform;
                Text_Clue = UI.FindObject("RoundInfo/Clue").transform;
            }
            var Systems = Finder.Find("----SYSTEMS----");
            if (Systems != null)
            {
                MakiKeyboard = Systems.FindObject("KeyboardToggle/MakiKeyboard");
                PlayerPermissionManager = Systems.FindObject("PlayerManager/PlayerPermissionManager").transform;
                Pen_Pickup = Systems.FindObject("Pens/Pen/Pickup").transform;
            }
            var scribble = Finder.Find("scribble");
            if (scribble != null)
            {
                StageCollider = scribble.FindObject("StageCollider").GetComponent<MeshCollider>();
            }
            _ = CustomizationReader;
            _ = MakiKeyboardReader;
            _ = PlayerPermissionManagerReader;

            SpawnSolutionViewer();
            SetupPenHijacker();
            SetupWorldButtons();
        }

        private void AnswerToggleButton_Pressed()
        {
            ShowAnswers = !ShowAnswers;
            if(Answer_TextMesh == null)
            {
                SpawnSolutionViewer();
            }
            if (ShowAnswers)
            {
                //Answer_Text.SetActive(true);
                MakiKeyboardReader.RevealAnswer();
                AnswerToggleButton.SetText("<color=red>Hide Answers!</color>");
            }
            else
            {
                //Answer_Text.SetActive(false);
                Answer_TextMesh_Animator.Safe_SetText("");
                AnswerToggleButton.SetText("<rainb>Show Answers!</rainb>");
            }
        }

        private void StageColliderToggleBtn_Pressed()
        {
            DisableStageCollider = !DisableStageCollider;
            if (DisableStageCollider)
            {
                StageCollider.IgnoreLocalPlayerCollision(true);
                StageColliderToggleBtn.SetText("<color=green>Enable Stage collision Block!</color>");
            }
            else
            {
                StageCollider.IgnoreLocalPlayerCollision(false);
                StageColliderToggleBtn.SetText("<color=red>Disable Stage collision Block!</color>");
            }
        }

        private void PenTheftToggleBtn_Pressed()
        {
            ForceStealPencil = !ForceStealPencil;
            if (ForceStealPencil)
            {
                Pen_ForceActive.enabled = true;
                Pen_InteractionCollider.enabled = true;
                Pen_PickupController.Pickup_Set_Pickupable(true);
                PenTheftToggleBtn.SetText("<color=green>Restore Normal Pen Interaction!</color>");
            }
            else
            {
                Pen_ForceActive.enabled = false;
                Pen_InteractionCollider.enabled = false;
                Pen_PickupController.Pickup_RestoreProperties();
                PenTheftToggleBtn.SetText("<color=red>Force Allow Pen Interaction!</color>");
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.QuickDraws))
            {
                isCurrentWorld = true;
                HasSubscribed = false;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
            }
        }

        private static Transform Text_Clue { get; set; }
        private static Transform Answer_Text { get; set; }
        internal static TextMeshProUGUI Answer_TextMesh { get; set; }
        internal static TextAnimator Answer_TextMesh_Animator { get; set; }

        private static Transform PlayerPermissionManager { get; set; } = null;
        private static MeshCollider StageCollider { get; set; }
        private static Transform Customization { get; set; } = null;
        private static Transform Pen_Pickup { get; set; } = null;
        private static Enabler Pen_ForceActive { get; set; } = null;
        private static BoxCollider Pen_InteractionCollider { get; set; } = null;

        private static PickupController Pen_PickupController { get; set; } = null;
        private static WorldButton_Squared AnswerToggleButton { get; set; }
        private static WorldButton_Squared StageColliderToggleBtn { get; set; }
        private static WorldButton_Squared PenTheftToggleBtn { get; set; }
        internal static bool ShowAnswers { get; set; } = false;
        internal static bool DisableStageCollider { get; set; } = false;
        internal static bool ForceStealPencil { get; set; } = false;

        private static GameObject MakiKeyboard { get; set; } = null;

        private static QuickDraws_PlayerPermissionReader _PlayerPermissionManagerReader;
        private static QuickDraws_CustomizationReader _customizationReader;
        private static QuickDraws_MakiKeyboardReader _MakiKeyboardReader;

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