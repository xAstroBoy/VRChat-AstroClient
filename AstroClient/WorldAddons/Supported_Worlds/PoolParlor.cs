namespace AstroClient
{
	using AstroClient.Components;
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using System.Collections.Generic;
	using UnityEngine;

	public class PoolParlor : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.PoolParlor)
            {
                ModConsole.Log($"Recognized {Name} World, Patching Skins....");
				var result = UdonSearch.FindUdonEvent("CueSkinHook", "_CanUseCueSkin").Action;
				if (result != null)
				{
					var program = result._program;
					var symbol_table = program.SymbolTable;
					var heap = program.Heap;
					if(symbol_table != null && heap != null)
					{
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__1_const_intnl_SystemString", Utils.CurrentUser.DisplayName(), true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__16_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__7_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__22_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__8_const_intnl_SystemString", Utils.CurrentUser.DisplayName(), true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__9_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__6_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__14_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__8_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__20_intnl_SystemBoolean", true, true);
					}
				}
				if (world == null)
				{
					world = GameObjectFinder.FindRootSceneObject("world").transform;
					if (world != null)
					{
						Meta_Cue_Rack = world.transform.FindObject("Meta's Cue Rack");
					}

				}
				if (table_primary == null)
				{
					table_primary = GameObjectFinder.FindRootSceneObject("table_primary").transform;
					if (table_primary != null)
					{
						table_Balls = table_primary.FindObject("intl.balls");
					}
				}

				if (world != null && table_primary != null && Meta_Cue_Rack != null && table_Balls != null)
				{
					Add_Modifier_ToCueBall(Find_Balls("0","0"));

					Add_Modifier_ToBall(Find_Balls("0", "1"));
					Add_Modifier_ToBall(Find_Balls("0" , "2"));
					Add_Modifier_ToBall(Find_Balls("0" , "3"));
					Add_Modifier_ToBall(Find_Balls("0" , "4"));
					Add_Modifier_ToBall(Find_Balls("0" , "5"));
					Add_Modifier_ToBall(Find_Balls("0" , "6"));
					Add_Modifier_ToBall(Find_Balls("0" , "7"));
					Add_Modifier_ToBall(Find_Balls("0" , "8"));
					Add_Modifier_ToBall(Find_Balls("0" , "9"));
					Add_Modifier_ToBall(Find_Balls("1" , "0"));
					Add_Modifier_ToBall(Find_Balls("1" , "1"));
					Add_Modifier_ToBall(Find_Balls("1" , "2"));
					Add_Modifier_ToBall(Find_Balls("1" , "3"));
					Add_Modifier_ToBall(Find_Balls("1" , "4"));
					Add_Modifier_ToBall(Find_Balls("1" , "5"));

				}
			}
		}


		private static void Add_Modifier_ToBall(Parlor_Balls ball)
		{
			if (ball != null)
			{
				var udon = ball.Estetic_Ball.GetOrAddComponent<VRC_AstroUdonTrigger>();
				if (udon != null)
				{
					udon.OnInteract += () => { ball.Table_Ball_Pickup.SetActive(!ball.Table_Ball_Pickup.active); };
					if (ball.Table_Ball_Pickup.active)
					{
						udon.InteractText = $"Deactivate {ball.Table_Ball.name} Pickup";
					}
					else
					{
						udon.InteractText = $"Activate {ball.Table_Ball.name} Pickup";
					}
				}
				ball.Ball_table_pickup_listener.OnDisabled += () =>
				{
					udon.InteractText = $"Activate {ball.Table_Ball.name} Pickup";
				};
				ball.Ball_table_pickup_listener.OnEnabled += () =>
				{
					udon.InteractText = $"Deactivate {ball.Table_Ball.name} Pickup";
				};
			}

		}



		private static void Add_Modifier_ToCueBall(Parlor_Balls  clue)
		{
			if (clue != null)
			{
				var udon = clue.Estetic_Ball.GetOrAddComponent<VRC_AstroUdonTrigger>();
				if (udon != null)
				{
					udon.OnInteract += () => { clue.Table_Ball_Pickup.SetActive(!clue.Table_Ball_Pickup.active); };
					if (clue.Table_Ball_Pickup.active)
					{
						udon.InteractText = "Deactivate Clue Ball Pickup";
					}
					else
					{
						udon.InteractText = "Activate Clue Ball Pickup";
					}
				}
				clue.Ball_table_pickup_listener.OnDisabled += () =>
				{
					udon.InteractText = "Activate Clue Ball Pickup";
				};
				clue.Ball_table_pickup_listener.OnEnabled += () =>
				{
					udon.InteractText = "Deactivate Clue Ball Pickup";
				};
			}
		}



		public static Parlor_Balls Find_Balls(string first_number , string second_number)
		{
			if(world != null && table_primary != null && Meta_Cue_Rack != null && table_Balls != null)
			{
				if(first_number + second_number == "00")
				{
					var cue_ball_table = table_Balls.FindObject("ball00");
					var cue_ball_table_pickup = cue_ball_table.FindObject("pickup");
					var  cue_ball_table_Pickup_Listener = cue_ball_table_pickup.GetOrAddComponent<GameObjectListener>();
					var cue_ball_estetic = Meta_Cue_Rack.FindObject("Cue_Ball");
					if(cue_ball_table != null && cue_ball_table_pickup != null &&  cue_ball_estetic != null && cue_ball_table_Pickup_Listener != null)
					{
						return  new Parlor_Balls(first_number + second_number, cue_ball_table.gameObject, cue_ball_table_pickup.gameObject, cue_ball_table_Pickup_Listener, cue_ball_estetic.gameObject);
					}
					return null;
				}
				else
				{

					Transform rack_ball;
					Transform table_ball = table_Balls.FindObject($"ball{first_number + second_number}");
					Transform table_ball_pickup = table_ball.FindObject("pickup");
					GameObjectListener table_ball_pickup_listener = table_ball_pickup.GetOrAddComponent<GameObjectListener>();
					
					if(first_number == "0")
					{
						rack_ball = Meta_Cue_Rack.FindObject($"{second_number}Ball");
					}
					else
					{
						rack_ball = Meta_Cue_Rack.FindObject($"{first_number + second_number}Ball");
					}
					if (table_ball != null && table_ball_pickup != null && rack_ball != null && table_ball_pickup_listener != null)
					{
						return new Parlor_Balls(first_number + second_number, table_ball.gameObject, table_ball_pickup.gameObject, table_ball_pickup_listener, rack_ball.gameObject);
					}
					return null;
				}
				return null;
			}
			return null;
		}

		public class Parlor_Balls
		{
			public string Ball_Number { get; set; }
			public GameObject Table_Ball { get; set; }
			public GameObject Table_Ball_Pickup { get; set; }
			public GameObject Estetic_Ball { get; set; }
			public GameObjectListener Ball_table_pickup_listener { get; set; }

			public Parlor_Balls(string Ball_Number, GameObject Table_Ball, GameObject Table_Ball_Pickup, GameObjectListener Ball_table_pickup_listener,  GameObject Estetic_Ball)
			{
				this.Ball_Number = Ball_Number;
				this.Table_Ball = Table_Ball;
				this.Table_Ball_Pickup = Table_Ball_Pickup;
				this.Ball_table_pickup_listener = Ball_table_pickup_listener;
				this.Estetic_Ball = Estetic_Ball;
			}
		}



		public override void OnSceneLoaded(int buildIndex, string sceneName)
		{
			table_primary = null;
			table_Balls = null;
			world = null;
			Meta_Cue_Rack = null;

		}


		public static Transform table_primary;
		public static Transform table_Balls;

		public static Transform world;
		public static Transform Meta_Cue_Rack;


	}
}