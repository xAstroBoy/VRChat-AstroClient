namespace AstroClient.ClientUI.ItemTweakerV2.Submenus.Physic.ColliderEditor
{
    using System;
    using Selector;
    using Tools.Extensions;
    using xAstroBoy.AstroButtonAPI;

    internal class ColliderEditor : Tweaker_Events
    {
        internal static void Init_ColliderEditor(QMNestedGridMenu main, bool btnhalf)
        {
            var menu = new QMNestedGridMenu(main, "Collider Editor", "Edit Collider Properties", null, null, null, null, btnhalf);

            _ = new QMSingleButton(menu, 1, 0f, "Activates all Colliders", new Action(() => { Tweaker_Object.GetGameObjectToEdit().EnableColliders(); }), "Enables all colliders bound to the object", null, null, true);
            _ = new QMSingleButton(menu, 1, 0.5f, "Add Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);
            _ = new QMSingleButton(menu, 1, 1f, "Add Trigger Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddTriggerCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);
        }
    }
}