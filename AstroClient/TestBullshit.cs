namespace AstroClient
{
    using AstroClient.Tools.UdonEditor;
    using AstroClient.Tools.UdonSearcher;
    using AstroClient.AstroMonos.Components.Tools;
    using UnityEngine;
    using AstroClient.xAstroBoy.Utility;
    using Tools.Extensions;
    using AstroClient.Tools.ObjectEditor.Editor.Position;

    internal class BullshitTest : AstroEvents
    {
        internal override void OnApplicationStart()
		{

            foreach (Transform item in GameObject.Find("MAP/mechanics/Stasis/Balls").GetComponents<Transform>())
            {
                if (item != null)
                {
                    ItemPosition.TeleportObject(item.gameObject);
                }
            }


        }


    }
}