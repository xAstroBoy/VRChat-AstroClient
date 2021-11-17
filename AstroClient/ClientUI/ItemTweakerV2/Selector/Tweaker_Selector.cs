namespace AstroClient.ClientUI.ItemTweakerV2.Selector
{
    using System;
    using Tools.Extensions;
    using TweakerEventArgs;
    using UnityEngine;

    internal class Tweaker_Selector : Tweaker_Events
    {
        internal static event EventHandler<SelectedObjectArgs> Event_On_New_GameObject_Selected;

        internal static event EventHandler<SelectedObjectArgs> Event_On_Old_GameObject_Removed;

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
                    Event_On_Old_GameObject_Removed.SafetyRaise(new SelectedObjectArgs(null));
                    Event_On_New_GameObject_Selected.SafetyRaise(new SelectedObjectArgs(null));
                }
                else if (_SelectedObject != null)
                {
                    if (_SelectedObject != value)
                    {
                        Event_On_Old_GameObject_Removed.SafetyRaise(new SelectedObjectArgs(_SelectedObject));
                    }
                }
                Event_On_New_GameObject_Selected.SafetyRaise(new SelectedObjectArgs(value));
                _SelectedObject = value;
            }
        }
    }
}