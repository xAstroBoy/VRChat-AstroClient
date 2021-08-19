namespace AstroClient.ItemTweakerV2.Selector
{
	using AstroClient.ItemTweakerV2.TweakerEventArgs;
	using System;
	using UnityEngine;
	using AstroLibrary.Extensions;

	public class Tweaker_Selector : Tweaker_Events
    {
        public static event EventHandler<SelectedObjectArgs> Event_On_New_GameObject_Selected;

        public static event EventHandler<SelectedObjectArgs> Event_On_Old_GameObject_Removed;

        private static GameObject _SelectedObject;

        public static GameObject Component_Get_SelectedObject // This is for components to avoid Parsing constantly the same Object and calling events as well
        {
            get
            {
                return _SelectedObject;
            }
        }

        public static GameObject SelectedObject
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