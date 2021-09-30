namespace AstroClient.ItemTweakerV2.Handlers
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using UnityEngine;

    internal class EspHandler : Tweaker_Events
    {
        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                if (TweakerESPEnabled)
                {
                    _ = obj.GetOrAddComponent<ESP_ItemTweaker>();
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
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