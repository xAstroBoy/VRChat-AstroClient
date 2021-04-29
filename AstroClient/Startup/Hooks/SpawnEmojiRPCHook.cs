namespace AstroClient.Startup.Hooks
{
	using AstroClient.ConsoleUtils;
	using MelonLoader;
	using System;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using UnhollowerBaseLib;

	public class SpawnEmojiRPCHook : GameEvents
	{
		public static event EventHandler<SpawnEmojiArgs> Event_SpawnEmojiRPC;

		public override void ExecutePriorityPatches()
		{
			HookSpawnEmojiRPC();
		}

		private void HookSpawnEmojiRPC()
		{
			unsafe
			{
				try
				{
					ModConsole.Log("Hooking SpawnEmojiRPC");
					var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils
						.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(
							typeof(VRCPlayer).GetMethod(
								nameof(VRCPlayer
									.SpawnEmojiRPC))).GetValue(null);
					MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), typeof(SpawnEmojiRPCHook).GetMethod(nameof(SpawnEmojiRPCPatch), BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer());
					_SpawnEmojiRPCDelegate = Marshal.GetDelegateForFunctionPointer<SpawnEmojiRPCDelegate>(originalMethod);
					if (_SpawnEmojiRPCDelegate != null)
					{
						ModConsole.Log("Hooked SpawnEmojiRPC");
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SpawnEmojiRPCDelegate(IntPtr thisPtr, int emoji, IntPtr PlayerPtr);

		private static SpawnEmojiRPCDelegate _SpawnEmojiRPCDelegate;

		private static void SpawnEmojiRPCPatch(IntPtr thisPtr, int emoji, IntPtr PlayerPtr)
		{
			try
			{
				if (thisPtr != IntPtr.Zero && PlayerPtr != IntPtr.Zero)
				{
					var player = new VRCPlayer(thisPtr);

					if (player != null)
					{
						Event_SpawnEmojiRPC?.Invoke(null, new SpawnEmojiArgs(player, emoji));
					}
				}
			}
			catch (Exception e)
			{
				ModConsole.Error(e.Message);
			}
			finally
			{
				_SpawnEmojiRPCDelegate(thisPtr, emoji, PlayerPtr);
			}
		}
	}
}