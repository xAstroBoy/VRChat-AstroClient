namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PuttPuttPond
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using System.Collections.Generic;
    using Constants;
    using CustomClasses;
    using JetBrains.Annotations;
    using Spoofer;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class PuttPuttPond_PatronControlEditor : AstroMonoBehaviour
    {
        private Il2CppSystem.Collections.Generic.List<Object> AntiGarbageCollection = new();

        public PuttPuttPond_PatronControlEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }
        private string isPatron_address { [HideFromIl2Cpp] get; } = "isPatron";

        internal bool? isPatron
        {
            [HideFromIl2Cpp]
            get
            {
                if (PatronControl != null) return UdonHeapParser.Udon_Parse_Boolean(PatronControl, isPatron_address);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (PatronControl != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(PatronControl, isPatron_address, value.Value);
            }
        }

        internal List<string> HiddenPatrons
        {
            [HideFromIl2Cpp]
            get
            {
                if (PatronControl != null) return UdonHeapParser.Udon_Parse_string_List(PatronControl, HiddenTier_Address);
                return null;
            }
        }

        [HideFromIl2Cpp]
        internal void SetAsPatron(bool isPatron)
        {
            if (HiddenPatrons != null)
            {
                // Copy patron list
                var modifiedlist = new List<string>();
                foreach (var item in HiddenPatrons)
                {
                    if (!modifiedlist.Contains(item))
                    {
                        modifiedlist.Add(item);
                    }
                }

                bool isModified = false;

                if (isPatron)
                {
                    if (!modifiedlist.Contains(PlayerSpooferUtils.Original_DisplayName))
                    {
                        modifiedlist.Add(PlayerSpooferUtils.Original_DisplayName);
                        isModified = true;
                    }
                }
                else
                {
                    if (modifiedlist.Contains(PlayerSpooferUtils.Original_DisplayName))
                    {
                        modifiedlist.Remove(PlayerSpooferUtils.Original_DisplayName);
                        isModified = true;
                    }
                }

                if (isModified)
                {
                    UdonHeapEditor.PatchHeap(PatronControl, HiddenTier_Address, modifiedlist.ToArray(), true);
                }
            }

            this.isPatron = isPatron;
            RefreshPatronList?.InvokeBehaviour();

        }

        private string HiddenTier_Address { [HideFromIl2Cpp] get; } = "__0_hiddenList_StringArray";

        private static RawUdonBehaviour PatronControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private static UdonBehaviour_Cached RefreshPatronList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PuttPuttPond))
            {
                RefreshPatronList = gameObject.FindUdonEvent("_UpdatePatronList");
                if (RefreshPatronList != null)
                {
                    PatronControl = RefreshPatronList.UdonBehaviour.ToRawUdonBehaviour();
                    ModConsole.DebugLog("Added PatronControlEditor to World Patron System Successfully!");

                }
                else
                {
                    ModConsole.Error("Can't Find PatronControl behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }
    }
}