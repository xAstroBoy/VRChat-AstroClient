namespace AstroClient.ItemTweakerV2.Selector
{
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	public class TweakerV2Main : ObjectSelectorHelper
	{
		public static void Init_TweakerV2Main()
		{

		}


		public override void On_New_GameObject_Selected(GameObject obj)
		{
			
		}
		public override void OnSelectedObject_Enabled()
		{
		}

		public override void OnSelectedObject_Disabled()
		{
			
		}

		public override void OnSelectedObject_Destroyed()
		{
			Selector_Utils.LockItem = false;
			Object_Selector.SelectedObject = null;
		}
			

		public override void OnLevelLoaded()
		{
			Selector_Utils.LockItem = false;
		}


		public static void Reset()
		{

		}


		public static QMSingleToggleButton LockHoldItem;
		public static QMSingleButton ObjectToEditBtn;
		public static QMSingleToggleButton ObjectActiveToggle;

	}
}
