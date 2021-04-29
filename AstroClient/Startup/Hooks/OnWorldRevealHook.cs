namespace AstroClient.Startup.Hooks
{
	using AstroClient.ConsoleUtils;
	using MelonLoader;
	using System;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using UnhollowerBaseLib;

	public class OnWorldRevealHook : GameEvents
	{
		public static event EventHandler<OnWorldRevealArgs> Event_OnWorldReveal;

		public override void ExecutePriorityPatches()
		{
			HookFadeTo();
		}

		private static void HookFadeTo()
		{
			unsafe
			{
				ModConsole.Log("Hooking FadeTo");
				var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(typeof(VRCUiManager).GetMethod(nameof(VRCUiManager.Method_Public_Void_String_Single_Action_0))).GetValue(null);
				MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), typeof(OnWorldRevealHook).GetMethod(nameof(FadeToPatch), BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer());
				_fadeToDelegate = Marshal.GetDelegateForFunctionPointer<FadeToDelegate>(originalMethod);
				if (_fadeToDelegate != null)
				{
					ModConsole.Log("Hooked OnFadeTo");
				}
				else
				{
					ModConsole.Error("Failed to hook OnFadeTo!");
				}
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void FadeToDelegate(IntPtr thisPtr, IntPtr fadeTypePtr, float duration, IntPtr action);

		private static FadeToDelegate _fadeToDelegate;

		private static void FadeToPatch(IntPtr thisPtr, IntPtr fadeTypePtr, float duration, IntPtr action)
		{
			try
			{
				if (thisPtr != IntPtr.Zero && fadeTypePtr != IntPtr.Zero)
				{
					string fadeType = IL2CPP.Il2CppStringToManaged(fadeTypePtr);
					//ModConsole.Log("FadeType Called : " + fadeType + " With duration : " + duration, ConsoleColor.Yellow);
					if (fadeType.Equals("BlackFade") && duration.Equals(0f) &&
						RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
					{
						Event_OnWorldReveal?.Invoke(null, new OnWorldRevealArgs(WorldUtils.GetWorldID(), WorldUtils.GetWorldName(), WorldUtils.GetWorldAssetURL()));
						//Task.Run(() => {  });
					}
				}
			}
			catch
			{
			}
			finally
			{
				_fadeToDelegate(thisPtr, fadeTypePtr, duration, action);
			}
		}
	}
}