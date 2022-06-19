using AstroClient.AstroMonos.Components.ESP;
using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Handlers
{
    internal class EspHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.On_Old_GameObject_Removed += On_Old_GameObject_Removed;


        }
        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                if (TweakerESPEnabled)
                {
                    _ = ComponentUtils.GetOrAddComponent<ESP_ItemTweaker>(obj);
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
                        _ = ComponentUtils.GetOrAddComponent<ESP_ItemTweaker>(Tweaker_Selector.SelectedObject);
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