using AstroClient.ClientActions;

namespace AstroClient.PlayerList.Config
{
    using System;
    using System.Collections.Generic;
    using Entries;
    using MelonLoader;
    using UnityEngine;

    public static class PlayerListConfig
    {
        private static bool hasConfigChanged = false;

        public static MelonPreferences_Category category = MelonPreferences.CreateCategory("PlayerList Config");
        public static List<EntryWrapper> entries = new List<EntryWrapper>();

        //public static EntryWrapper<bool> useTabMenu;
        public struct dummyEntry
        {
            internal bool _val;
            public bool Value {
                get {
                    return _val;
                        }
                set { }
            }
        }
        public static dummyEntry useTabMenu;
        public static EntryWrapper<bool> enabledOnStart;
        public static EntryWrapper<bool> onlyEnabledInConfig;
        public static EntryWrapper<bool> condensedText;
        public static EntryWrapper<bool> numberedList;
        public static EntryWrapper<int> fontSize;
        public static EntryWrapper<int> snapToGridSize;

        public static EntryWrapper<bool> pingToggle;
        public static EntryWrapper<bool> fpsToggle;
        public static EntryWrapper<bool> platformToggle;
        public static EntryWrapper<bool> perfToggle;
        public static EntryWrapper<bool> distanceToggle;
        public static EntryWrapper<bool> photonIdToggle;
        public static EntryWrapper<bool> ownedObjectsToggle;
        public static EntryWrapper<bool> displayNameToggle;
        public static EntryWrapper<bool> jeffToggle;

        public static EntryWrapper<PlayerEntry.DisplayNameColorMode> displayNameColorMode;

        public static EntryWrapper<bool> freezeSortWhenVisible;
        public static EntryWrapper<bool> reverseBaseSort;
        public static EntryWrapper<EntrySortManager.SortType> currentBaseSort;
        public static EntryWrapper<bool> reverseUpperSort;
        public static EntryWrapper<EntrySortManager.SortType> currentUpperSort;
        public static EntryWrapper<bool> reverseHighestSort;
        public static EntryWrapper<EntrySortManager.SortType> currentHighestSort;
        public static EntryWrapper<bool> showSelfAtTop;

        public static EntryWrapper<int> polyLimit;
        public static EntryWrapper<int> meshLimit;
        public static EntryWrapper<int> matLimit;
        public static EntryWrapper<float> boundsMagLimit;


       // public static EntryWrapper<MenuManager.MenuButtonPositionEnum> menuButtonPosition;

        public static EntryWrapper<Vector2> playerListPosition;

        public static void RegisterSettings()
        {
            //useTabMenu = CreateEntry(nameof(useTabMenu), false, is_hidden: true);
            useTabMenu._val = true;
            enabledOnStart = CreateEntry( nameof(enabledOnStart), true, is_hidden: true);
            onlyEnabledInConfig = CreateEntry(nameof(onlyEnabledInConfig), false, is_hidden: true);

            condensedText = CreateEntry(nameof(condensedText), false, is_hidden: true);
            numberedList = CreateEntry(nameof(numberedList), true, is_hidden: true);
            fontSize = CreateEntry(nameof(fontSize), 35, is_hidden: true);
            snapToGridSize = CreateEntry(nameof(snapToGridSize), 420, is_hidden: true);

            pingToggle = CreateEntry(nameof(pingToggle), true, is_hidden: true);
            fpsToggle = CreateEntry(nameof(fpsToggle), true, is_hidden: true);
            platformToggle = CreateEntry(nameof(platformToggle), true, is_hidden: true);
            perfToggle = CreateEntry(nameof(perfToggle), true, is_hidden: true);
            distanceToggle = CreateEntry(nameof(distanceToggle), true, is_hidden: true);
            photonIdToggle = CreateEntry(nameof(photonIdToggle), false, is_hidden: true);
            ownedObjectsToggle = CreateEntry(nameof(ownedObjectsToggle), false, is_hidden: true);
            displayNameToggle = CreateEntry(nameof(displayNameToggle), true, is_hidden: true);
            jeffToggle = CreateEntry(nameof(jeffToggle), true, is_hidden: true);
            displayNameColorMode = CreateEntry(nameof(displayNameColorMode), PlayerEntry.DisplayNameColorMode.TrustAndFriends, is_hidden: true);

			freezeSortWhenVisible = CreateEntry(nameof(freezeSortWhenVisible), false, is_hidden: true);
            reverseBaseSort = CreateEntry(nameof(reverseBaseSort), false, is_hidden: true);
            currentBaseSort = CreateEntry(nameof(currentBaseSort), EntrySortManager.SortType.None, is_hidden: true);
            reverseUpperSort = CreateEntry(nameof(reverseUpperSort), false, is_hidden: true);
            currentUpperSort = CreateEntry(nameof(currentUpperSort), EntrySortManager.SortType.None, is_hidden: true);
            reverseHighestSort = CreateEntry(nameof(reverseHighestSort), false, is_hidden: true);
            currentHighestSort = CreateEntry(nameof(currentHighestSort), EntrySortManager.SortType.None, is_hidden: true);
            showSelfAtTop = CreateEntry(nameof(showSelfAtTop), true, is_hidden: true);

            polyLimit = CreateEntry(nameof(polyLimit), 150000, is_hidden: false);
            meshLimit = CreateEntry(nameof(meshLimit), 6, is_hidden: false);
            matLimit = CreateEntry(nameof(matLimit), 10, is_hidden: false);
            boundsMagLimit = CreateEntry(nameof(boundsMagLimit), 17.3f, is_hidden: false);

          //  menuButtonPosition = CreateEntry(nameof(menuButtonPosition), MenuManager.MenuButtonPositionEnum.TopRight, is_hidden: false);

            playerListPosition = CreateEntry(nameof(playerListPosition), new Vector2(2100, 0), is_hidden: false);

            foreach (EntryWrapper entry in entries)
                entry.OnValueChangedUntyped += new Action(() => OnConfigChange());
        }

        public static EntryWrapper<T> CreateEntry<T>(string entry_identifier, T default_value, string display_name = null, bool is_hidden = false)
        {
            MelonPreferences_Entry<T> melonPref = (MelonPreferences_Entry<T>)category.CreateEntry(entry_identifier, default_value, display_name, is_hidden);
            EntryWrapper<T> entry = new EntryWrapper<T>()
            {
                pref = melonPref
            };
            entries.Add(entry);

            return entry;
        }
        public static void SaveEntries()
        {
            if (RoomManager.field_Internal_Static_ApiWorldInstance_0 == null) return;

            if (hasConfigChanged)
            {
                MelonPreferences.Save();
                hasConfigChanged = false;
            }
        }

        public static void OnConfigChange(bool shouldSetHasConfigChanged = true)
        {
            ConfigEventActions.OnPlayerListConfigChanged?.SafetyRaise();
            hasConfigChanged = shouldSetHasConfigChanged;
        }
    }
}
