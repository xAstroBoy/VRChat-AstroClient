namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Selector
{
    using System;
    using Tools.Extensions;
    using UnityEngine;

    internal class Tweaker_Selector : Tweaker_Events
    {
        internal static event Action<GameObject> Event_On_New_GameObject_Selected;

        internal static event Action<GameObject> Event_On_Old_GameObject_Removed;

        private static GameObject _SelectedObject;

        internal static GameObject SelectedObject
        {
            get
            {
                return _SelectedObject;
            }
            set
            {
                if (_SelectedObject == value)
                {
                    return; // Avoid Re-firing the same events over the same gameobject lol
                }
                if (value == null)
                {
                    Event_On_Old_GameObject_Removed.SafetyRaiseWithParams(null);
                    Event_On_New_GameObject_Selected.SafetyRaiseWithParams(null);
                }
                else if (_SelectedObject != null)
                {
                    if (_SelectedObject != value)
                    {
                        Event_On_Old_GameObject_Removed.SafetyRaiseWithParams(_SelectedObject);
                    }
                }
                Event_On_New_GameObject_Selected.SafetyRaiseWithParams(value);
                _SelectedObject = value;
            }
        }
    }
}