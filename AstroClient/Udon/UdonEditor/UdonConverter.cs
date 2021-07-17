namespace AstroClient
{
	using System;
	using System.Runtime.InteropServices;
	using UnhollowerBaseLib;
	using UnityEngine;

	public static class UdonConverter
	{
		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_string(string[] item)
		{
			Il2CppStringArray array2 = new Il2CppStringArray(item);
			Il2CppSystem.Object boxed = new Il2CppSystem.Object(array2.Pointer);
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_string(string item)
		{
			var ptr = IL2CPP.ManagedStringToIl2Cpp(item);
			Il2CppSystem.Object boxed = new Il2CppSystem.Object(ptr);
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}



		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_VRCPlayerApi(VRC.SDKBase.VRCPlayerApi[] item)
		{
			IntPtr ArrayPointer = Marshal.AllocHGlobal(Marshal.SizeOf(item));
			Il2CppArrayBase<VRC.SDKBase.VRCPlayerApi> array = Il2CppArrayBase<VRC.SDKBase.VRCPlayerApi>.WrapNativeGenericArrayPointer(ArrayPointer);
			Il2CppSystem.Object obj = new Il2CppSystem.Object(array.Pointer);
			Marshal.FreeHGlobal(ArrayPointer);
			return obj;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_UnityEngine_GameObjects(UnityEngine.GameObject[] item)
		{
			IntPtr ArrayPointer = Marshal.AllocHGlobal(Marshal.SizeOf(item));
			Il2CppArrayBase<GameObject> array = Il2CppArrayBase<GameObject>.WrapNativeGenericArrayPointer(ArrayPointer);
			Il2CppSystem.Object obj = new Il2CppSystem.Object(array.Pointer);
			Marshal.FreeHGlobal(ArrayPointer);
			return obj;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_UnityEngine_AudioClips(UnityEngine.AudioClip[] item)
		{
			IntPtr ArrayPointer = Marshal.AllocHGlobal(Marshal.SizeOf(item));
			Il2CppArrayBase<GameObject> array = Il2CppArrayBase<GameObject>.WrapNativeGenericArrayPointer(ArrayPointer);
			Il2CppSystem.Object obj = new Il2CppSystem.Object(array.Pointer);
			Marshal.FreeHGlobal(ArrayPointer);
			return obj;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_char(char[] item)
		{
			IntPtr ArrayPointer = Marshal.AllocHGlobal(Marshal.SizeOf(item));
			Il2CppStructArray<char> array = new Il2CppStructArray<char>(ArrayPointer);
			Il2CppSystem.Object obj = new Il2CppSystem.Object(array.Pointer);
			Marshal.FreeHGlobal(ArrayPointer);
			return obj;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_HumanBodyBones(UnityEngine.HumanBodyBones[] item)
		{
			IntPtr ArrayPointer = Marshal.AllocHGlobal(Marshal.SizeOf(item));
			Il2CppStructArray<UnityEngine.HumanBodyBones> array2 = new Il2CppStructArray<UnityEngine.HumanBodyBones>(ArrayPointer);
			Il2CppSystem.Object obj = new Il2CppSystem.Object(array2.Pointer);
			Marshal.FreeHGlobal(ArrayPointer);
			return obj;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UInt32(System.UInt32 item)
		{
			var converted = new Il2CppSystem.UInt32() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Int32(System.Int32 item)
		{
			var converted = new Il2CppSystem.Int32() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Int64(System.Int64 item)
		{
			var converted = new Il2CppSystem.Int64() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Char(System.Char item)
		{
			var converted = new Il2CppSystem.Char() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Single(System.Single item)
		{
			var converted = new Il2CppSystem.Single() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Boolean(System.Boolean item)
		{
			var converted = new Il2CppSystem.Boolean() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_color(UnityEngine.Color item)
		{
			var boxed = item.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_Vector3(UnityEngine.Vector3 item)
		{
			var boxed = item.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_Quaternion(UnityEngine.Quaternion item)
		{
			var boxed = item.BoxIl2CppObject();
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_TextMeshPro(TMPro.TextMeshPro item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<TMPro.TextMeshPro>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UdonBehaviour(VRC.Udon.UdonBehaviour item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<VRC.Udon.UdonBehaviour>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_VRCPlayerApi(VRC.SDKBase.VRCPlayerApi item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<VRC.SDKBase.VRCPlayerApi>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_Text(UnityEngine.UI.Text item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.UI.Text>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_AudioSource(UnityEngine.AudioSource item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.AudioSource>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_GameObject(UnityEngine.GameObject item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.GameObject>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_Transform(UnityEngine.Transform item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.Transform>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_ParticleSystem(UnityEngine.ParticleSystem item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.ParticleSystem>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_MeshRenderer(UnityEngine.MeshRenderer item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.MeshRenderer>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_Material(UnityEngine.Material item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.Material>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_HumanBodyBones(UnityEngine.HumanBodyBones item)
		{
			IntPtr ArrayPointer = Marshal.AllocHGlobal(Marshal.SizeOf(item));
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<UnityEngine.HumanBodyBones>.NativeClassPtr, ArrayPointer));
			Marshal.FreeHGlobal(ArrayPointer);
			return boxed;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_NetworkEventTarget(VRC.Udon.Common.Interfaces.NetworkEventTarget item)
		{
			IntPtr ArrayPointer = Marshal.AllocHGlobal(Marshal.SizeOf(item));
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<VRC.Udon.Common.Interfaces.NetworkEventTarget>.NativeClassPtr, ArrayPointer));
			Marshal.FreeHGlobal(ArrayPointer);
			return boxed;
		}
	}
}