namespace AstroClient.AstroMonos.Components.UI.SingleTag
{
    using System;
    using System.Linq;
    using CheetoLibrary;
    using ClientAttributes;
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
                Debug($"Found Target Player {p.DisplayName()}, For SingleTag");
                Player = p;
            }
            else
            {
                ModConsole.Error($"Failed to Generate a SingleTag for Player {Player.DisplayName()}");
                Destroy(this);
            }
            bool AddNewPlayer = false;
            int stack = 2;
            Debug("Searching for Entries To Parse stack order...");
            // I HOPE THIS WORKS CAUSE WHY TF IT DOESNT COUNT EM
            var entry = SingleTagsUtils.GetEntry(Player);
            if (entry != null)
            {
                Debug($"Found existing stack for {Player.DisplayName()} having current stack value : {entry.AssignedStack}");
                entry.AssignedStack++;
                stack = entry.AssignedStack;
            }
            else
            {
                Debug($"No Entry Found for player {Player.DisplayName()} , using default stack value {stack} for generated SingleTag");
                AddNewPlayer = true;
            }
            if (AddNewPlayer)
            {
                var addme = new SingleTagsUtils.PlayerTagCounter(Player, stack);
                if (SingleTagsUtils.Counter != null)
                {
                    if (!SingleTagsUtils.Counter.Contains(addme))
                    {
                        Debug($"Added New Entry for Player : {Player.DisplayName()} using stack {addme.AssignedStack}");
                        SingleTagsUtils.Counter.Add(addme);
                    }
                }
            }

            // FIND ESSENTIALS TO GENERATE A TAG.
            if (Player_content == null)
            {
                if (Player != null)
                {
                    Player_content = Player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents");
                    if (Player_content != null) Debug($"Found {Player.DisplayName()}  Nameplate Contents Required to generate a SingleTag (using : {Player_content.name})!");
                }
            }
            if (Player_QuickStats == null && Player_content != null)
            {
                Player_QuickStats = Player_content.Find("Quick Stats");
                if (Player_QuickStats != null) Debug($"Found {Player.DisplayName()}  Nameplate Quick Stats Required to generate a SingleTag (using : {Player_QuickStats.name})!");
            }
            if (Player_content != null && Player_QuickStats != null)
            {
                Debug($"Using Content from {Player.DisplayName()}  Contents : {Player_content.name})!");
                Debug($"Using QuickStats from {Player.DisplayName()}  Player_QuickStats : {Player_QuickStats.name})!");

                if (SpawnedTag == null)
                {
                    Debug($"Starting Tag Generation..");

                    SpawnedTag = Instantiate(Player_QuickStats, Player_QuickStats.parent, false);
                    if (SpawnedTag != null)
                    {
                        Debug($"Spawned SingleTag for {Player.DisplayName()}!");
                        SpawnedTag.name = TagName;

                        // TODO : MAKE A SYSTEM TO MAKE IT AUTOMATIC STACK!

                        Debug($"Purging  {Player.DisplayName()}  {SpawnedTag.name} from Useless Internals");
                        for (int i = SpawnedTag.childCount; i > 0; i--)
                        {
                            Transform child = SpawnedTag.GetChild(i - 1);
                            if (child.name == "Trust Text")
                            {
                                Debug($"Found Child {child.name} As TextChild in {SpawnedTag.name}  allocated on {Player.DisplayName()}");
                                Label = child;
                                if (Label != null) TagText = Label.GetComponent<TMPro.TextMeshProUGUI>();
                                continue;
                            }
                            Debug($"Removed Child {child.name} in {SpawnedTag.name} allocated on {Player.DisplayName()}");
                            Destroy(child.gameObject);
                            if (!SpawnedTag.gameObject.active) SpawnedTag.gameObject.SetActive(true);
                        }

                        if (SpawnedStatsImage == null)
                        {
                            var spawnedimageslice = SpawnedTag.GetComponent<ImageThreeSlice>();
                            if (spawnedimageslice != null)
                            {
                                Debug($"Found ImageThreeSlice Component As SpawnedStatsImage in {SpawnedTag.name}  allocated on {Player.DisplayName()}");
                                SpawnedStatsImage = spawnedimageslice;
                            }
                            else
                            {
                                var statsimageslice = Player_QuickStats.GetComponent<ImageThreeSlice>();
                                if (statsimageslice != null)
                                {
                                    Debug($"Using ImageThreeSlice from Original Stats As SpawnedStatsImage in {SpawnedTag.name}  allocated on {Player.DisplayName()}");
                                    SpawnedStatsImage = statsimageslice;
                                }
                            }
                        }
                    }
                }

                if (SpawnedTag != null)
                {
                    TextColor = Color.white;
                    KeepTagVisible = true;
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
            }


            AllocatedStack = stack;
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
            FixStacking();
            Destroy(TagListener);
            Destroy(this);
        }

        internal void FixStacking()
        {
            var sorted = (from s in Player.GetComponentsInChildren<SingleTag>(true) orderby s.AllocatedStack descending select s).ToList();
            if (sorted.Count() != 0 && sorted.Count() != 1)
            {
                for (int i = 0; i < sorted.Count; i++)
                {
                    SingleTag tag = sorted[i];
                    if (tag != null)
                    {
                        Debug($"Found SingleTag with Allocated TagStack {tag.AllocatedStack}");
                        if (tag == this)
                        {
                            Debug($"Skipped SingleTag marked for Destroy with Allocated TagStack {tag.AllocatedStack}");
                            continue;
                        }
                        int newTagOrder = sorted.Count();
                        if (tag.AllocatedStack > newTagOrder)
                        {
                            newTagOrder--;
                            tag.AllocatedStack = newTagOrder;
                        }
                    }
                }
            }
            var entry = SingleTagsUtils.GetEntry(Player);
            if (entry != null) entry.AssignedStack--;
        }

        internal void OnDestroy()
        {
            FixStacking();
            Destroy(TagListener);
            Destroy(SpawnedTag.gameObject);
            Destroy(this);
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


        internal string Text
        {
            [HideFromIl2Cpp]
            get
            {
                return TagText.text;
            }
            [HideFromIl2Cpp]
            set
            {
                TagText.text = value;
            }
        }

        internal Color TextColor
        {
            [HideFromIl2Cpp]
            get
            {
                return TagText.color;
            }
            [HideFromIl2Cpp]
            set
            {
                TagText.color = value;
            }
        }

        internal Color BackGroundColor
        {
            [HideFromIl2Cpp]
            get
            {
                return SpawnedStatsImage.color;
            }
            [HideFromIl2Cpp]
            set
            {
                SpawnedStatsImage.color = value;
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
            [HideFromIl2Cpp]
            get => _allocatedStack;
            [HideFromIl2Cpp]
            set
            {
                if (SpawnedTag != null)
                {
                    _allocatedStack = value;
                    var NewLocalPosition = new Vector3(0, 30 * value, 0);
                    Debug($"updating {SpawnedTag.name} LocalPosition to follow Index from {value} , New LocalPosition is  {NewLocalPosition}");
                    SpawnedTag.localPosition = NewLocalPosition;
                    var oldname = SpawnedTag.name;
                    Debug($"Updated Spawned SingleTag from {oldname} to {TagName}");
                    SpawnedTag.name = TagName;
                }
            }
        }



        internal bool KeepTagVisible { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool _ShowTag;
        internal bool ShowTag 
        {
            get
            {
                return _ShowTag; 
            }
            [HideFromIl2Cpp]
            set
            {
                _ShowTag = value;
                 SpawnedTag.gameObject.SetActive(value);
            }
        }


        internal Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private Transform Player_content;

        private Transform SpawnedTag;

        // TAG TEXT
        private Transform Label;
        private GameObjectListener TagListener;
        private TMPro.TextMeshProUGUI TagText;

        // STATS
        private Transform Player_QuickStats;
        private ImageThreeSlice SpawnedStatsImage;
    }
}