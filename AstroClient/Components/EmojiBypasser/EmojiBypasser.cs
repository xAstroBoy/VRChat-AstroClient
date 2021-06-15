namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using MelonLoader;
	using System;
	using System.Collections;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC;

	public class EmojiBypasser : GameEventsBehaviour
	{
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public EmojiBypasser(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		// Use this for initialization
		public void Start()
		{
			player = GetComponent<Player>();
			if(player != null)
			{
				vrcplayer = player.GetVRCPlayer();
			}

			if(vrcplayer == null && player == null)
			{
				DestroyImmediate(this);
			}
			MelonCoroutines.Start(RunBypass());
		}

		





		private IEnumerator RunBypass()
		{
			while(vrcplayer == null) { yield return null; }
			while (!EmoteCooldown.HasValue) { yield return null; }

			if (vrcplayer != null)
			{
				if (EmoteCooldown.HasValue)
				{
					if (EmoteCooldown.Value != 0)
					{
						Old_EmoteCooldown = EmoteCooldown.Value;
						EmoteCooldown = 0f;
						ModConsole.DebugLog($"[EmojiBypasser] : Removed Player {player.DisplayName()} 's Emoji Cooldown.");
					}
				}
			}
			yield return null;
		}


		private void OnDestroy()
		{
			if (vrcplayer != null)
			{
				if (EmoteCooldown.HasValue)
				{
					EmoteCooldown = Old_EmoteCooldown;
				}
			}
			DestroyImmediate(this);
		}

		private float? EmoteCooldown
		{
			get
			{
				if(vrcplayer != null)
				{
					return vrcplayer.field_Private_Single_4;
				}
				return null;
			}
			set
			{
				if (vrcplayer != null)
				{
					vrcplayer.field_Private_Single_4 = value.Value;
				}
				return;
			}
		}



		internal float _Old_EmoteCooldown;
		private float Old_EmoteCooldown
		{
			get
			{
				return _Old_EmoteCooldown;
			}
			set
			{
				_Old_EmoteCooldown = value;
			}
		}


		internal Player player  { get; private set; }
		internal VRCPlayer vrcplayer { get; private set; }

		private bool StopOnUpdate { get; set; } = false;
	}
}