using System.Linq;

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
public class JustBClub_PatronCracker : AstroMonoBehaviour
{
    private readonly List<Object> AntiGarbageCollection = new();

    public JustBClub_PatronCracker(IntPtr ptr) : base(ptr)
    {
        AntiGarbageCollection.Add(this);
    }



    internal override void OnRoomLeft()
    {
        Destroy(this);
    }

    void OnDestroy()
    {
        Clean_UdonVariablePatron();
    }

  
    internal void Start()
    {
        if (WorldUtils.WorldID.Equals(WorldIds.JustBClub))
        {
            RefreshPatronList = gameObject.FindUdonEvent("isElite");
            if (RefreshPatronList != null)
            {
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