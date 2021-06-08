namespace AstroClient.ItemTweakerV2.Submenus.Collider
{

	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Handlers;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus;
	using AstroClient.ItemTweakerV2.Submenus.ScrollMenus;
	using AstroClient.variables;
	using AstroLibrary;
	using RubyButtonAPI;
	using System;
	using System.Reflection;
	using UnityEngine;
	using Color = UnityEngine.Color;

	internal class ColliderEditor : Tweaker_Events
	{

		public static void Init_ColliderEditor(QMTabMenu main, float x, float y, bool btnhalf)
		{
			var menu = new QMNestedButton(main, x, y, "Collider Editor", "Edit Collider Properties", null, null, null, null, btnhalf);
			new QMSingleButton(menu, 1, 0f, "Activates all Colliders", new Action(() => { Tweaker_Object.GetGameObjectToEdit().EnableColliders(); }), "Enables all colliders bound to the object", null, null, true);
			new QMSingleButton(menu, 1, 0.5f, "Add Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);
			new QMSingleButton(menu, 1, 1f, "Add Trigger Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddTriggerCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);

		}
	}
}