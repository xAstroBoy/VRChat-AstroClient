namespace AstroClient.Menu.Movement
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using AstroClient.Features.Player.Clones;
	using AstroClient.Features.Player.Movement;
	using AstroClient.Features.Player.Movement.Exploit;
	using AstroClient.Features.Player.QuickMenu;
	using RubyButtonAPI;
	using UnityEngine;

	public static class Movement_Menu
	{

		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var temp = new QMNestedButton(menu, x, y, "Movement Options", "Control Your Movements", null, null, null, null, btnHalf);
			JumpModifier.UnlimitedJumpToggle = new QMSingleToggleButton(temp, 1, 0, "Unlimited Jumps", new Action(() => { JumpModifier.IsUnlimitedJumpActive = true; }), "Unlimited Jumps OFF", new Action(() => { JumpModifier.IsUnlimitedJumpActive = false; }), "Allows you to Unlimited jump", Color.green, Color.red, null, false, true);
			JumpModifier.RocketJumpToggle = new QMSingleToggleButton(temp, 1, 0.5f, "Rocket Jump", new Action(() => { JumpModifier.IsRocketJumpActive = true; }), "Rocket Jump", new Action(() => { JumpModifier.IsRocketJumpActive = false; }), "Allows you to Unlimited jump", Color.green, Color.red, null, false, true);

			JumpModifier.JumpOverrideToggle = new QMToggleButton(temp, 2, 0, "Jump Override ON", new Action(() => { JumpModifier.IsJumpOverriden = true; }), "Jump Override OFF", new Action(() => { JumpModifier.IsJumpOverriden = false; }), "Allows you to Bypass jump Block in certain worlds.", null, null, null, false);
			MovementSerializer.SerializerBtn = new QMToggleButton(temp, 3, 0, "Serializer ON", new Action(() => { MovementSerializer.Enabled = true; }), "Serializer OFF", new Action(() => { MovementSerializer.Enabled = false; }), "Blocks Movement packets (allows you to be invisible to others)", null, null, null, false);
			QMFreeze.FreezePlayerOnQMOpenToggle = new QMToggleButton(temp, 4, 0, "Freeze On QM open \n ON", () => { QMFreeze.FreezePlayerOnQMOpen = true; }, "Freeze On QM Open \n OFF", () => { QMFreeze.FreezePlayerOnQMOpen = false; }, "Freeze Player On QuickMenu Open event.", null, null, null, false);
			new QMSingleButton(temp, 1, 1, "Spawn Avatar Clone", new Action(() => { Clones.SpawnClone(); }), "Spawns current avi clone", null, null, true);
			new QMSingleButton(temp, 1, 1.5f, "Remove Avatar Clones", new Action(() => { Clones.RemoveClones(); }), "Removed Spawned avatars clones", null, null, true);
		}





	}
}
