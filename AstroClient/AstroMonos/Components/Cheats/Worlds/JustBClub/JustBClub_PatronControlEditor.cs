using System.Linq;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JustBClub;

using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using ClientAttributes;
using Constants;
using CustomClasses;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Spoofer;
using UnhollowerBaseLib.Attributes;
using WorldModifications.WorldsIds;
using xAstroBoy.Extensions;
using xAstroBoy.Utility;
using Exception = System.Exception;
using IntPtr = System.IntPtr;

// Stupid il2cpp
[RegisterComponent]
public class JustBClub_PatronControlEditor : AstroMonoBehaviour
{
    private List<Object> AntiGarbageCollection = new();

    public JustBClub_PatronControlEditor(IntPtr ptr) : base(ptr)
    {
        AntiGarbageCollection.Add(this);
    }
    //private string isPatron_address { [HideFromIl2Cpp] get; } = "__10_intnl_SystemBoolean"; // isPatron or isElite Check ?

    //internal bool? isPatron
    //{
    //    [HideFromIl2Cpp]
    //    get
    //    {
    //        if (PatronControl != null) return UdonHeapParser.Udon_Parse_Boolean(PatronControl, isPatron_address);
    //        return null;
    //    }
    //    [HideFromIl2Cpp]
    //    set
    //    {
    //        if (PatronControl != null)
    //            if (value.HasValue)
    //                UdonHeapEditor.PatchHeap(PatronControl, isPatron_address, value.Value);
    //    }
    //}

    private string AnotherPatronList4_Address { [HideFromIl2Cpp] get => "__0_intnl_SystemObject"; }

    internal string AnotherPatronList4
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string>(PatronControl, AnotherPatronList4_Address);
            return null;
        }
    }

    private string AnotherPatronGroup_3_Address { [HideFromIl2Cpp] get => "__5_intnl_SystemString"; }

    internal string AnotherPatronGroup_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string>(PatronControl, AnotherPatronGroup_3_Address);
            return null;
        }
    }

    private string AnotherPatronList5_Address { [HideFromIl2Cpp] get => "__1_intnl_SystemStringArray"; }

    internal System.Collections.Generic.List<string> AnotherPatronList5
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string[]>(PatronControl, AnotherPatronList5_Address).ToList();
            return null;
        }
    }

    private string CurrentElites_Address { [HideFromIl2Cpp] get => "__0_mp_elites_StringArray"; }
    private string patrons_Address { [HideFromIl2Cpp] get => "patrons"; }

    internal System.Collections.Generic.List<string> patrons
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string[]>(PatronControl, patrons_Address).ToList();;
            return null;
        }
    }

    private string AnotherPatronList_Address { [HideFromIl2Cpp] get => "__0_intnl_SystemStringArray"; }

    internal System.Collections.Generic.List<string> AnotherPatronList
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string[]>(PatronControl, AnotherPatronList_Address).ToList();;
            return null;
        }
    }

    private string CurrentPatronsTiers_Address { [HideFromIl2Cpp] get => "__0_groups_StringArray"; }

    internal System.Collections.Generic.List<string> CurrentPatronsList
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string[]>(PatronControl, CurrentPatronsTiers_Address).ToList();;
            return null;
        }
    }

    internal System.Collections.Generic.List<string> CurrentElites
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string[]>(PatronControl, CurrentElites_Address).ToList();;
            return null;
        }
    }

    private string PatronsToProcess_Address { [HideFromIl2Cpp] get => "__0_mp_patronsToProcess_String"; }

    internal string PatronsToProcess
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string>(PatronControl, PatronsToProcess_Address);
            return null;
        }
    }

    private string elites_Address
    {
        [HideFromIl2Cpp]
        get => "elites";
    }

    internal System.Collections.Generic.List<string> elites
    {
        [HideFromIl2Cpp]
        get
        {
            if (PatronControl != null) return UdonHeapParser.Udon_Parse<string[]>(PatronControl, elites_Address).ToList();;
            return null;
        }
    }

    private RawUdonBehaviour PatronControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    private UdonBehaviour_Cached isPatron_Check { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    private UdonBehaviour_Cached isElite_Check { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    private string ReplaceWith { [HideFromIl2Cpp] get => $"{PlayerSpooferUtils.Original_DisplayName}\r\n" + $"{WorldUtils.AuthorName}"; }

    internal override void OnRoomLeft()
    {
        Destroy(this);
    }

    [HideFromIl2Cpp]
    internal void PatchList(System.Collections.Generic.List<string> currentlist, string listaddress, bool Delete = false)
    {
        try
        {
            if (currentlist.Count != 0 && listaddress.IsNotNullOrEmptyOrWhiteSpace())
            {
                var isModified = false;
                var modifiedlist = new System.Collections.Generic.List<string>();
                foreach (var item in currentlist) modifiedlist.Add(item);

                if (!Delete)
                {
                    if (!modifiedlist.Contains(PlayerSpooferUtils.Original_DisplayName))
                    {
                        modifiedlist.Insert(0, PlayerSpooferUtils.Original_DisplayName);
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
                    UdonHeapEditor.PatchHeap(PatronControl, listaddress, modifiedlist.ToArray());
                    if (!Delete)
                        Log.Debug($"Added {PlayerSpooferUtils.Original_DisplayName} from Patron list");
                    else
                        Log.Debug($"Removed {PlayerSpooferUtils.Original_DisplayName} from Patron list");
                }
            }
        }
        catch (Exception e)
        {
            ModConsole.DebugErrorExc(e);
        }
    }

    [HideFromIl2Cpp]
    internal void PatchStringGroup(string group, string GroupAddress, bool Delete = false)
    {
        try
        {
            if (group.IsNotNullOrEmptyOrWhiteSpace() && GroupAddress.IsNotNullOrEmptyOrWhiteSpace())
            {
                var isModified = false;
                var ModifiedGroup = string.Empty;
                if (!Delete)
                {
                    if (group.isMatch(WorldUtils.AuthorName))
                    {
                        ModifiedGroup = group.Replace(WorldUtils.AuthorName, ReplaceWith);
                        isModified = true;
                    }
                }
                else
                {
                    if (group.isMatch(ReplaceWith))
                    {
                        ModifiedGroup = group.Replace(ReplaceWith, WorldUtils.AuthorName);
                        isModified = true;
                    }
                }

                if (isModified)
                {
                    UdonHeapEditor.PatchHeap(PatronControl, GroupAddress, ModifiedGroup);
                    if (!Delete)
                        Log.Debug($"Added {PlayerSpooferUtils.Original_DisplayName} from Patron string Group list");
                    else
                        Log.Debug($"Removed {PlayerSpooferUtils.Original_DisplayName} from Patron string Group list");
                }
            }
        }
        catch (Exception e)
        {
            ModConsole.DebugErrorExc(e);
        }
    }

    [HideFromIl2Cpp]
    internal void PatchListGroup(System.Collections.Generic.List<string> currentlist, string listaddress, bool Delete = false)
    {
        try
        {
            if (currentlist.Count != 0 && listaddress.IsNotNullOrEmptyOrWhiteSpace())
            {
                var isModified = false;
                var ListClone = new System.Collections.Generic.List<string>();
                foreach (var item in currentlist) ListClone.Add(item);

                var EditedList = new System.Collections.Generic.List<string>();
                if (!Delete)
                    foreach (var group in ListClone)
                        if (@group.isMatch(WorldUtils.AuthorName))
                        {
                            var result = @group.Replace(WorldUtils.AuthorName, ReplaceWith);
                            EditedList.Add(result);
                            isModified = true;
                        }
                        else
                        {
                            EditedList.Add(@group);
                        }
                else
                    foreach (var group in ListClone)
                        if (@group.isMatch(ReplaceWith))
                        {
                            var result = @group.Replace(ReplaceWith, WorldUtils.AuthorName);
                            EditedList.Add(result);
                            isModified = true;
                        }
                        else
                        {
                            EditedList.Add(@group);
                        }

                if (isModified)
                {
                    UdonHeapEditor.PatchHeap(PatronControl, listaddress, EditedList.ToArray());
                    if (!Delete)
                        Log.Debug($"Added {PlayerSpooferUtils.Original_DisplayName} from Patron Group list");
                    else
                        Log.Debug($"Removed {PlayerSpooferUtils.Original_DisplayName} from Patron Group list");
                }
            }
        }
        catch (Exception e)
        {
            ModConsole.DebugErrorExc(e);
        }
    }

    [HideFromIl2Cpp]
    internal void SetAsPatron(bool isPatron)
    {
        PatchList(AnotherPatronList5, AnotherPatronList5_Address, !isPatron);
        PatchList(CurrentElites, CurrentElites_Address, !isPatron);
        PatchList(elites, elites_Address, !isPatron);
        PatchList(patrons, patrons_Address, !isPatron);

        PatchListGroup(CurrentPatronsList, CurrentPatronsTiers_Address, !isPatron);
        PatchListGroup(AnotherPatronList, AnotherPatronList_Address, !isPatron);

        PatchStringGroup(AnotherPatronList4, AnotherPatronList4_Address, !isPatron);
        PatchStringGroup(AnotherPatronGroup_3, AnotherPatronGroup_3_Address, !isPatron);
        PatchStringGroup(PatronsToProcess, PatronsToProcess_Address, !isPatron);

        //this.isPatron = isPatron;
        isPatron_Check?.InvokeBehaviour();
        isElite_Check?.InvokeBehaviour();
    }

    // Use this for initialization
    internal void Start()
    {
        if (WorldUtils.WorldID.Equals(WorldIds.JustBClub))
        {
            isPatron_Check = gameObject.FindUdonEvent("IsPatron");
            isElite_Check = gameObject.FindUdonEvent("IsElite");
            if (isPatron_Check != null && isElite_Check != null)
            {
                PatronControl = isPatron_Check.UdonBehaviour.ToRawUdonBehaviour();
                Log.Debug("Added PatronControlEditor to World Patron System Successfully!");
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