namespace AstroClient.ItemTweakerV2.Handlers
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using UnityEngine;

    public class EspHandler : Tweaker_Events
    {
        public override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                if (TweakerESPEnabled)
                {
                    obj.GetOrAddComponent<ESP_ItemTweaker>();
                }
            }
        }

        public override void On_Old_GameObject_Removed(GameObject obj)
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

        public static bool TweakerESPEnabled
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
                        Tweaker_Selector.SelectedObject.GetOrAddComponent<ESP_ItemTweaker>();
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