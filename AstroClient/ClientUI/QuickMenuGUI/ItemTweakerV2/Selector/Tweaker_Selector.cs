using AstroClient.ClientActions;
using UnityEngine;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector
{
    internal class Tweaker_Selector 
    {

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
                    TweakerEventActions.On_Old_GameObject_Removed.SafetyRaiseWithParams(null);
                    TweakerEventActions.On_New_GameObject_Selected.SafetyRaiseWithParams(null);
                }
                else if (_SelectedObject != null)
                {
                    if (_SelectedObject != value)
                    {
                        TweakerEventActions.On_Old_GameObject_Removed.SafetyRaiseWithParams(_SelectedObject);
                    }
                }
                TweakerEventActions.On_New_GameObject_Selected.SafetyRaiseWithParams(value);
                _SelectedObject = value;
            }
        }
    }
}