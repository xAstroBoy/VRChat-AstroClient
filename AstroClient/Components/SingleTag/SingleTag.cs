using AstroClient.Components;
using AstroClient.ConsoleUtils;
using DayClientML2.Utility.Extensions;
using System;
using System.Linq;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC;
using Object = UnityEngine.Object;

namespace AstroClient.components
{
    public class SingleTag : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public SingleTag(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = false;

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[SingleTag Debug] : {msg}");
            }
        }

        // Use this for initialization
        public void Start()
        {
            // FIND ALLOCATED PLAYER
            var p = this.GetComponent<Player>();
            if (p != null)
            {
                Debug($"Found Target Player {p.DisplayName()}, For SingleTag");
                _player = p;
            }
            else
            {
                ModConsole.Error($"Failed to Generate a SingleTag for Player {player.DisplayName()}");
                Object.Destroy(this);
            }
            Debug($"Pre-assigned InternalStack {InternalStack}");
            // FIND ESSENTIALS TO GENERATE A TAG.
            if (Player_content == null)
            {
                if (player != null)
                {
                    Player_content = player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents");
                    if (Player_content != null)
                    {
                        Debug($"Found {player.DisplayName()}  Nameplate Contents Required to generate a SingleTag (using : {Player_content.name})!");
                    }
                }
            }
            if (Player_QuickStats == null && Player_content != null)
            {
                Player_QuickStats = Player_content.Find("Quick Stats");
                if (Player_QuickStats != null)
                {
                    Debug($"Found {player.DisplayName()}  Nameplate Quick Stats Required to generate a SingleTag (using : {Player_QuickStats.name})!");
                }
            }
            if (Player_content != null && Player_QuickStats != null)
            {
                Debug($"Using Content from {player.DisplayName()}  Contents : {Player_content.name})!");
                Debug($"Using QuickStats from {player.DisplayName()}  Player_QuickStats : {Player_QuickStats.name})!");

                if (SpawnedTag == null)
                {
                    Debug($"Starting Tag Generation..");

                    SpawnedTag = Object.Instantiate(Player_QuickStats, Player_QuickStats.parent, false);
                    if (SpawnedTag != null)
                    {
                        Debug($"Spawned SingleTag for {player.DisplayName()}!");
                        SpawnedTag.name = TagName;

                        // TODO : MAKE A SYSTEM TO MAKE IT AUTOMATIC STACK!

                        Debug($"Purging  {player.DisplayName()}  {SpawnedTag.name} from Useless Internals");
                        for (int i = SpawnedTag.childCount; i > 0; i--)
                        {
                            Transform child = SpawnedTag.GetChild(i - 1);
                            if (child.name == "Trust Text")
                            {
                                Debug($"Found Child {child.name} As TextChild in {SpawnedTag.name}  allocated on {player.DisplayName()}");
                                Label = child;
                                if (Label != null)
                                {
                                    LabelText = Label.GetComponent<TMPro.TextMeshProUGUI>();
                                }
                                continue;
                            }
                            Debug($"Removed Child {child.name} in {SpawnedTag.name} allocated on {player.DisplayName()}");
                            Object.Destroy(child.gameObject);
                            if (!SpawnedTag.gameObject.active)
                            {
                                SpawnedTag.gameObject.SetActive(true);
                            }
                        }

                        if (SpawnedStatsImage == null)
                        {
                            var spawnedimageslice = SpawnedTag.GetComponent<ImageThreeSlice>();
                            if (spawnedimageslice != null)
                            {
                                Debug($"Found ImageThreeSlice Component As SpawnedStatsImage in {SpawnedTag.name}  allocated on {player.DisplayName()}");
                                SpawnedStatsImage = spawnedimageslice;
                            }
                            else
                            {
                                var statsimageslice = Player_QuickStats.GetComponent<ImageThreeSlice>();
                                if (statsimageslice != null)
                                {
                                    Debug($"Using ImageThreeSlice from Original Stats As SpawnedStatsImage in {SpawnedTag.name}  allocated on {player.DisplayName()}");
                                    SpawnedStatsImage = statsimageslice;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void OnDestroy()
        {
            if (player != null)
            {
                var sorted = (from s in player.GetComponentsInChildren<SingleTag>(true) orderby s.AllocatedStack descending select s).ToList();
                if (sorted.Count() != 0 && sorted.Count() != 1)
                {
                    foreach (var tag in sorted)
                    {
                        if (tag != null)
                        {
                            Debug($"Found SingleTag with Allocated TagStack {tag.InternalStack}");
                            if (tag == this)
                            {
                                Debug($"Skipped SingleTag marked for Destroy with Allocated TagStack {tag.InternalStack}");
                                continue;
                            }
                            int newTagOrder = sorted.Count();
                            if (tag.InternalStack > newTagOrder)
                            {
                                newTagOrder--;
                                tag.InternalStack = newTagOrder;
                            }
                        }
                    }
                }
                var entry = SingleTagsUtils.GetEntry(player.GetAPIUser());
                if (entry != null)
                {
                    entry.AssignedStack--;
                }
            }
        }

        // Update is called once per frame
        public void Update()
        {
            try
            {
                if (InternalStack != AllocatedStack)
                {
                    AllocatedStack = InternalStack;
                }
                if (SpawnedTag != null)
                {
                    if (SpawnedTag.gameObject.active != ShowTag)
                    {
                        SpawnedTag.gameObject.SetActive(ShowTag);
                    }

                    if (LabelText != null)
                    {
                        if (LabelText.text != Label_Text)
                        {
                            LabelText.text = Label_Text;
                        }
                        if (LabelText.color != Label_TextColor)
                        {
                            LabelText.color = Label_TextColor;
                        }
                    }
                    if (SpawnedStatsImage != null)
                    {
                        if (SpawnedStatsImage.color != Tag_Color)
                        {
                            SpawnedStatsImage.color = Tag_Color;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugError($"SingleTag Exception in Update Event : " + e);
            }
        }

        internal string TagName
        {
            [HideFromIl2Cpp]
            get
            {
                return $"SingleTag:{_allocatedStack}";
            }
        }

        private int _allocatedStack;

        private int AllocatedStack
        {
            [HideFromIl2Cpp]
            get
            {
                return _allocatedStack;
            }
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

        internal int InternalStack;

        private Player _player;

        internal Player player
        {
            get
            {
                return _player;
            }
        }

        private Transform Player_content;

        private Transform SpawnedTag;

        // TAG TEXT
        private Transform Label;

        private TMPro.TextMeshProUGUI LabelText;
        internal Color Label_TextColor = Color.white;
        internal string Label_Text;

        // STATS
        private Transform Player_QuickStats;

        private ImageThreeSlice SpawnedStatsImage;

        internal Color Tag_Color = Color.grey;

        internal bool ShowTag = true;
    }
}