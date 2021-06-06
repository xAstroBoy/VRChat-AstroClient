namespace AstroClient.Startup.Hooks
{
	using AstroLibrary.Console;
	using MelonLoader;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Threading.Tasks;
	using UnhollowerBaseLib;

	public class QuickMenuHooks : GameEvents
	{
		public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerSelected;

		public override void ExecutePriorityPatches()
		{
			HookSelectedPlayer();
		}

		private void HookSelectedPlayer()
		{
			unsafe
			{
				try
				{
					ModConsole.DebugLog("Hooking SelectedPlayer");
					var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils
						.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(
							typeof(QuickMenu).GetMethod(
								nameof(QuickMenu
									.Method_Public_Void_Player_PDM_0))).GetValue(null);
					MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), typeof(QuickMenuHooks).GetMethod(nameof(HookSelectedPlayer), BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer());
					_SelectedPlayerHookDelegate = Marshal.GetDelegateForFunctionPointer<SelectedPlayerHookDelegate>(originalMethod);
					if (_SelectedPlayerHookDelegate != null)
					{
						ModConsole.DebugLog("Hooked SpawnEmojiRPC");
					}
					else
					{
						ModConsole.Error("Failed to hook SpawnEmojiRPC!");
					}
				}
				catch (Exception e)
				{
					ModConsole.Error("Failed to hook SpawnEmojiRPC!, ERROR : " + e);
				}
			}
		}

		public delegate void SelectedPlayerHookDelegate(IntPtr thisPtr, int emoji, IntPtr PlayerPtr);

		private static SelectedPlayerHookDelegate _SelectedPlayerHookDelegate;

		private void Test()
		{
			//Event_OnPlayerSelected?.Invoke(null, new VRCPlayerEventArgs(Instance2));
		}

		private static void QuickMenuSelectedPlayerPatch(IntPtr thisPtr, int emoji, IntPtr PlayerPtr)
		{
			try
			{
				if (thisPtr != IntPtr.Zero && PlayerPtr != IntPtr.Zero)
				{
					var player = new VRCPlayer(thisPtr);

					if (player != null)
					{
						Event_OnPlayerSelected?.Invoke(null, new VRCPlayerEventArgs(player));
					}
				}
			}
			catch (Exception e)
			{
				ModConsole.Error(e.Message);
			}
			finally
			{
				_SelectedPlayerHookDelegate(thisPtr, emoji, PlayerPtr);
			}
		}
	}
}
