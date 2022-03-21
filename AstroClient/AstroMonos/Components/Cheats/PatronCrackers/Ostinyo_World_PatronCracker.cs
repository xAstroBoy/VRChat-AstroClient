namespace AstroClient.AstroMonos.Components.Cheats.PatronCrackers;

using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using ClientAttributes;
using CustomClasses;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Spoofer;
using UnhollowerBaseLib.Attributes;
using WorldModifications.WorldsIds;
using xAstroBoy.Utility;
using IntPtr = System.IntPtr;

[RegisterComponent]
public class Ostinyo_World_PatronCracker : AstroMonoBehaviour
{
    private readonly List<Object> AntiGarbageCollection = new();

    public Ostinyo_World_PatronCracker(IntPtr ptr) : base(ptr)
    {
        AntiGarbageCollection.Add(this);
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

    internal System.Collections.Generic.List<string> HiddenPatrons
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse_string_List(PatronControl, HiddenTier_Address);
            return null;
        }
    }

    internal System.Collections.Generic.List<string> HiddenPatrons_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null)
                return UdonHeapParser.Udon_Parse_string_List(PatronControl, HiddenTier_Address_2);
            return null;
        }
    }

    private string HiddenTier_Address { [HideFromIl2Cpp] get; } = "__0_hiddenList_StringArray";
    private string HiddenTier_Address_2 { [HideFromIl2Cpp] get; } = "__0_hiddenList_StringArray";

    private static RawUdonBehaviour PatronControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    private static UdonBehaviour_Cached RefreshPatronList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

    internal override void OnRoomLeft()
    {
        Destroy(this);
    }


    [HideFromIl2Cpp]
    internal void SetAsPatron(bool isPatron)
    {
        if (HiddenPatrons != null)
        {
            // Copy patron list
            var modifiedlist = new System.Collections.Generic.List<string>();
            foreach (var item in HiddenPatrons)
                if (!modifiedlist.Contains(item))
                    modifiedlist.Add(item);

            var isModified = false;

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

            if (isModified) UdonHeapEditor.PatchHeap(PatronControl, HiddenTier_Address, modifiedlist.ToArray(), true);
        }

        if (HiddenPatrons_2 != null)
        {
            // Copy patron list
            var modifiedlist = new System.Collections.Generic.List<string>();
            foreach (var item in HiddenPatrons_2)
                if (!modifiedlist.Contains(item))
                    modifiedlist.Add(item);

            var isModified = false;

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

            if (isModified) UdonHeapEditor.PatchHeap(PatronControl, HiddenTier_Address_2, modifiedlist.ToArray(), true);
        }

        this.isPatron = isPatron;
        RefreshPatronList?.InvokeBehaviour();
    }

    // Use this for initialization
    internal void Start()
    {
        if (WorldUtils.WorldID.Equals(WorldIds.PuttPuttPond) || WorldUtils.WorldID.Equals(WorldIds.PuttPuttQuest) || WorldUtils.WorldID.Equals(WorldIds.PuttPuttQuest_Night) || WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
        {
            RefreshPatronList = gameObject.FindUdonEvent("_UpdatePatronList");
            if (RefreshPatronList != null)
            {
                PatronControl = RefreshPatronList.UdonBehaviour.ToRawUdonBehaviour();
                ModConsole.DebugLog("Added Patron Cracker to This Patron System Successfully!");
            }
            else
            {
                ModConsole.Error(
                    "Can't Find PatronControl behaviour, Unable to Add Reader Component, did the author update the world?");
                Destroy(this);
            }
        }
        else
        {
            Destroy(this);
        }
    }
}