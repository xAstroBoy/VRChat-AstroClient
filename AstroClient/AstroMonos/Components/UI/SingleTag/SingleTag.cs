namespace AstroClient.AstroMonos.Components.UI.SingleTag
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AstroClient.Tools.Extensions;
    using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes;
    using CheetoLibrary;
    using ClientAttributes;
    using MelonLoader;
    using Tools.Listeners;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.SDK.Internal.ModularPieces;
    using xAstroBoy.Extensions;

    [RegisterComponent]
    public class SingleTag : AstroMonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public SingleTag(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = false;

        private void Debug(string msg)
        {
            if (DebugMode) ModConsole.DebugLog($"[SingleTag Debug] : {msg}");
        }

        // Use this for initialization
        internal void Start()
        {
            // FIND ALLOCATED PLAYER
            var p = this.GetComponent<Player>();
            if (p != null)
            {
                //Debug($"Found Target Player {p.DisplayName()}, For SingleTag");
                Player = p;
            }
            else
            {
                //ModConsole.Error($"Failed to Generate a SingleTag for Player {Player.DisplayName()}");
                Destroy(this);
            }


            #region Find and Generate a stack

            int stack = 2;
            try
            {
                StackerEntry.AssignedTags.Add(this);
                switch (StackerEntry.AssignedTags.Count)
                {
                    case 1:
                    {
                        stack = 2;
                        break;
                    }
                    default:
                    {
                        stack = StackerEntry.AssignedTags.Count + 1;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }


            #endregion

            #region Find and Build a tag!

            // FIND ESSENTIALS TO GENERATE A TAG.
            if (Player_content == null)
            {
                if (Player != null)
                {
                    Player_content = Player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents");
                    //if (Player_content != null) Debug($"Found {Player.DisplayName()}  Nameplate Contents Required to generate a SingleTag (using : {Player_content.name})!");
                }
            }

            if (Player_QuickStats == null && Player_content != null)
            {
                Player_QuickStats = Player_content.Find("Quick Stats");
                //if (Player_QuickStats != null) Debug($"Found {Player.DisplayName()}  Nameplate Quick Stats Required to generate a SingleTag (using : {Player_QuickStats.name})!");
            }

            if (Player_content != null && Player_QuickStats != null)
            {
                //Debug($"Using Content from {Player.DisplayName()}  Contents : {Player_content.name})!");
                //Debug($"Using QuickStats from {Player.DisplayName()}  Player_QuickStats : {Player_QuickStats.name})!");

                if (SpawnedTag == null)
                {
                    //Debug($"Starting Tag Generation..");

                    SpawnedTag = Instantiate(Player_QuickStats, Player_QuickStats.parent, false);
                    if (SpawnedTag != null)
                    {
                        //Debug($"Spawned SingleTag for {Player.DisplayName()}!");
                        SpawnedTag.name = TagName;

                        // TODO : MAKE A SYSTEM TO MAKE IT AUTOMATIC STACK!

                        //Debug($"Purging  {Player.DisplayName()}  {SpawnedTag.name} from Useless Internals");
                        for (int i = SpawnedTag.childCount; i > 0; i--)
                        {
                            Transform child = SpawnedTag.GetChild(i - 1);
                            if (child.name == "Trust Text")
                            {
                                //Debug($"Found Child {child.name} As TextChild in {SpawnedTag.name}  allocated on {Player.DisplayName()}");
                                Label = child;
                                if (Label != null) TagText = Label.GetComponent<TMPro.TextMeshProUGUI>();
                                continue;
                            }

                            //Debug($"Removed Child {child.name} in {SpawnedTag.name} allocated on {Player.DisplayName()}");
                            Destroy(child.gameObject);
                            if (!SpawnedTag.gameObject.active) SpawnedTag.gameObject.SetActive(true);
                        }

                        if (SpawnedStatsImage == null)
                        {
                            var spawnedimageslice = SpawnedTag.GetComponent<ImageThreeSlice>();
                            if (spawnedimageslice != null)
                            {
                                //Debug($"Found ImageThreeSlice Component As SpawnedStatsImage in {SpawnedTag.name}  allocated on {Player.DisplayName()}");
                                SpawnedStatsImage = spawnedimageslice;
                            }
                            else
                            {
                                var statsimageslice = Player_QuickStats.GetComponent<ImageThreeSlice>();
                                if (statsimageslice != null)
                                {
                                    //Debug($"Using ImageThreeSlice from Original Stats As SpawnedStatsImage in {SpawnedTag.name}  allocated on {Player.DisplayName()}");
                                    SpawnedStatsImage = statsimageslice;
                                }
                            }
                        }
                    }
                }
            }




            #endregion

            #region  Program and set Tag!
            if (SpawnedTag != null)
            {
                TextColor = Color.white;
                TagText.text = Text;
                SpawnedTag.gameObject.SetActive(ShowTag);
                if (SpawnedStatsImage != null)
                {
                    SpawnedStatsImage.color = BackGroundColor;
                }

                if (TagListener == null)
                {
                    TagListener = SpawnedTag.gameObject.AddComponent<GameObjectListener>();
                }

                if (TagListener != null)
                {
                    TagListener.OnDisabled += OnTagDisable;
                    TagListener.OnDestroyed += onTagDestroy;

                }
            }

            AllocatedStack = stack;



            #endregion
        }



        private TagStacker _StackerEntry;
        private TagStacker StackerEntry
        {
            [HideFromIl2Cpp]
            get
            {
                if (_StackerEntry == null)
                {
                    _StackerEntry = SingleTagsUtils.GetEntry(Player);
                    if (_StackerEntry == null)
                    {
                        _StackerEntry = new TagStacker(Player);
                        if (SingleTagsUtils.TagStackingMechanism != null)
                        {
                            SingleTagsUtils.TagStackingMechanism.Add(_StackerEntry);
                        }
                    }
                }

                return _StackerEntry;
            }
        }


        private void OnTagDisable()
        {
            if (KeepTagVisible)
            {
                if (ShowTag)
                {
                    SpawnedTag.gameObject.SetActive(true);
                }
            }
        }



        private void onTagDestroy()
        {
            StackerEntry.AssignedTags.Remove(this);
            if (TagListener != null)
            {
                TagListener.RemoveListener();
            }
            if (SpawnedTag.gameObject != null)
            {
                DestroyImmediate(SpawnedTag.gameObject);
            }
            CorrectTagStacking();
            DestroyImmediate(this);
        }

        private bool isAllocatedTagExisting(int value)
        {
            foreach (var tag in StackerEntry.AssignedTags)
            {
                if (tag != null)
                {
                    if (tag.TagName.Equals($"SingleTag:{value}"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CorrectTagStacking()
        {
            try
            {
                foreach (SingleTag item in StackerEntry.AssignedTags)
                {
                    if (item != null)
                    {
                        try
                        {
                            var assignedstack = item.AllocatedStack;

                        CheckAgain:
                            var result = assignedstack -1;
                            if (isAllocatedTagExisting(result))
                            {
                                goto CheckAgain;
                            }
                            item.AllocatedStack = result;
                        }
                        catch (Exception e)
                        {
                            ModConsole.ErrorExc(e);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        internal void OnDestroy()
        {
            StackerEntry.AssignedTags.Remove(this);
            if (TagListener != null)
            {
                TagListener.RemoveListener();
            }
            if (SpawnedTag.gameObject != null)
            {
                DestroyImmediate(SpawnedTag.gameObject);
            }
            CorrectTagStacking();
            DestroyImmediate(this);
        }


        // TODO : Rewrite (suspicions of Taking performance) !!!
        //// Update is called once per frame
        //internal void Update()
        //{
        //    try
        //    {
        //        //if (InternalStack != AllocatedStack)
        //        //{
        //        //    AllocatedStack = InternalStack;
        //        //}
        //        if (SpawnedTag != null)
        //        {
        //            if (SpawnedTag.gameObject.active != ShowTag) 

        //            if (TagText != null)
        //            {
        //                if (TagText.text != Label_Text) TagText.text = Label_Text;
        //                if (TagText.color != Label_TextColor) TagText.color = Label_TextColor;
        //            }
        //            if (SpawnedStatsImage != null)
        //            {
        //                if (SpawnedStatsImage.color != Tag_Color)  = Tag_Color;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModConsole.DebugError($"SingleTag Exception in Update Event : " + e);
        //    }
        //}

        private string _Text = "";
        internal string Text
        {
            [HideFromIl2Cpp]
            get
            {
                return _Text;
            }
            [HideFromIl2Cpp]
            set
            {
                _Text = value;
                if (TagText != null)
                {
                    TagText.text = value;
                }
            }
        }

        private Color _TextColor;
        internal Color TextColor
        {
            [HideFromIl2Cpp]
            get
            {
                return _TextColor;
            }
            [HideFromIl2Cpp]
            set
            {
                _TextColor = value;
                if (TagText)
                {
                    TagText.color = value;
                }
            }
        }
        private Color _BackGroundColor;
        internal Color BackGroundColor
        {
            [HideFromIl2Cpp]
            get
            {
                return _BackGroundColor;
            }
            [HideFromIl2Cpp]
            set
            {
                _BackGroundColor = value;
                if (SpawnedStatsImage)
                {
                    SpawnedStatsImage.color = value;
                }
            }
        }

        internal string TagName
        {
            [HideFromIl2Cpp]
            get => $"SingleTag:{AllocatedStack}";
        }

        private int _allocatedStack;
        internal int AllocatedStack
        {
            get => _allocatedStack;
            set
            {
                if (value <= 1) // Limit for Default tag is 2.
                {
                    value = 2;
                }
                _allocatedStack = value;
                try
                {
                    if (SpawnedTag != null)
                    {
                        var NewLocalPosition = new Vector3(0, 30 * value, 0);
                        //Debug($"updating {SpawnedTag.name} LocalPosition to follow Index from {value} , New LocalPosition is  {NewLocalPosition.ToString()}");
                        SpawnedTag.localPosition = NewLocalPosition;
                        SpawnedTag.name = TagName;
                        if (DebugMode)
                        {
                            Text = TagName;
                        }
                    }
                }
                catch (Exception e)
                {
                    ModConsole.DebugErrorExc(e);
                }

            }
        }


        internal bool KeepTagVisible { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;


        private bool _ShowTag = true;
        internal bool ShowTag
        {
            [HideFromIl2Cpp]
            get
            {
                return _ShowTag; 
            }
            [HideFromIl2Cpp]
            set
            {
                _ShowTag = value;
                if (SpawnedTag != null)
                {
                    if (SpawnedTag.gameObject != null)
                    {
                        SpawnedTag.gameObject.SetActive(value);
                    }
                }
            }
        }


        internal Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private Transform Player_content { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private Transform SpawnedTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // TAG TEXT
        private Transform Label { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private GameObjectListener TagListener { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private TMPro.TextMeshProUGUI TagText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // STATS
        private Transform Player_QuickStats { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ImageThreeSlice SpawnedStatsImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}