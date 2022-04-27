using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using AstroMonos.Components.ESP.ItemTweaker;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.Utility;

    internal class EspHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.Event_On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.Event_On_Old_GameObject_Removed += On_Old_GameObject_Removed;


        }
        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                if (TweakerESPEnabled)
                {
                    _ = obj.GetOrAddComponent<ESP_ItemTweaker>();
                }
            }
        }

        private void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_ItemTweaker>();
                if (ESP != null)
                {
                    ESP.DestroyMeLocal();
                }
            }
        }

        private static bool _TweakerESPEnabled;

        internal static bool TweakerESPEnabled
        {
            get
            {
                return _TweakerESPEnabled;
            }
            set
            {
                _TweakerESPEnabled = value;
                if (value)
                {
                    if (Tweaker_Selector.SelectedObject != null)
                    {
                        _ = Tweaker_Selector.SelectedObject.GetOrAddComponent<ESP_ItemTweaker>();
                    }
                }
                else
                {
                    if (Tweaker_Selector.SelectedObject != null)
                    {
                        var ESP = Tweaker_Selector.SelectedObject.GetComponent<ESP_ItemTweaker>();
                        if (ESP != null)
                        {
                            ESP.DestroyMeLocal();
                        }
                    }
                }
                _TweakerESPEnabled = value;
            }
        }
    }
}