using System.Linq;
using AstroClient.ClientActions;
using UnityEngine;

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
public class Ostinyo_World_PatronCracker : MonoBehaviour
{
    private readonly List<Object> AntiGarbageCollection = new();

    public Ostinyo_World_PatronCracker(IntPtr ptr) : base(ptr)
    {
        AntiGarbageCollection.Add(this);
    }
    private bool _HasSubscribed = false;
    private bool HasSubscribed
    {
        [HideFromIl2Cpp]
        get => _HasSubscribed;
        [HideFromIl2Cpp]
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

    internal void Initiate_UdonVariablePatron()
    {
        Private_isPatron = new AstroUdonVariable<bool>(PatronControl, "isPatron");
        Private___0_hiddenList_StringArray = new AstroUdonVariable<string[]>(PatronControl, "__0_hiddenList_StringArray");
        Private___4_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronControl, "__4_intnl_SystemStringArray");

    }

    internal void Clean_UdonVariablePatron()
    {
        Private_isPatron = null;
        Private___0_hiddenList_StringArray = null;
        Private___4_intnl_SystemStringArray = null;
    }

    internal AstroUdonVariable<bool> Private_isPatron {  [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_hiddenList_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___4_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    private static RawUdonBehaviour PatronControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    private static UdonBehaviour_Cached RefreshPatronList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

    internal bool? isPatron
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_isPatron != null) return Private_isPatron.Value;
            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_isPatron != null)
                if (value.HasValue)
                    Private_isPatron.Value = value.Value;
        }
    }

    internal string[] __0_hiddenList_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_hiddenList_StringArray != null)
            {
                return Private___0_hiddenList_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_hiddenList_StringArray != null)
            {
                Private___0_hiddenList_StringArray.Value = value;
            }
        }
    }

    internal string[] __4_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_SystemStringArray != null)
            {
                return Private___4_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_intnl_SystemStringArray != null)
            {
                Private___4_intnl_SystemStringArray.Value = value;
            }
        }
    }

    private void OnRoomLeft()
    {
        Destroy(this);
    }

    void OnDestroy()
    {
        HasSubscribed = false;
        Clean_UdonVariablePatron();		
    }

    internal string[] SetPatronList(string[] patronlist, bool isPatron)
    {
        if (patronlist != null)
        {
            if (patronlist != null)
            {
                var result = patronlist.ToList();
                if (result.Count != 0)
                {
                    var name = PlayerSpooferUtils.Original_DisplayName;
                    if (!result.Contains(name))
                    {
                        if(isPatron)
                        {
                            result.Add(name);
                        }
                    }
                    else
                    {
                        if (!isPatron)
                        {
                            result.Remove(name);
                        }
                    }
                }
                return result.ToArray();
            }
        }
        return null;
    }

    [HideFromIl2Cpp]
    internal void SetAsPatron(bool isPatron)
    {
        try
        {
            var modified = SetPatronList(__0_hiddenList_StringArray, isPatron);
            if(modified != null)
            {
                __0_hiddenList_StringArray = modified;
            }

        }
        catch {}
        try
        {
            var modified = SetPatronList(__4_intnl_SystemStringArray, isPatron);
            if (modified != null)
            {
                __4_intnl_SystemStringArray = modified;
            }

        }
        catch{}



        this.isPatron = isPatron;
        RefreshPatronList?.Invoke();
    }

    // Use this for initialization
    internal void Start()
    {
        if (WorldUtils.WorldID.Equals(WorldIds.PuttPuttPond) || WorldUtils.WorldID.Equals(WorldIds.PuttPuttQuest) || WorldUtils.WorldID.Equals(WorldIds.PuttPuttQuest_Night) || WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
        {
            RefreshPatronList = gameObject.FindUdonEvent("_UpdatePatronList");
            if (RefreshPatronList != null)
            {
                HasSubscribed = true;
                PatronControl = RefreshPatronList.RawItem;
                Initiate_UdonVariablePatron();
                Log.Debug("Added Patron Cracker to This Patron System Successfully!");
            }
            else
            {
                Log.Error("Can't Find PatronControl behaviour, Unable to Add Reader Component, did the author update the world?");
                Destroy(this);
            }
        }
        else
        {
            Destroy(this);
        }
    }
}