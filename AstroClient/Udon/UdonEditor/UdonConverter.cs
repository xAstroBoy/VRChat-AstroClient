namespace AstroClient
{
	using Il2CppSystem.Collections.Generic;
	using System;
	using System.Linq;
	using System.Runtime.InteropServices;
	using UnhollowerBaseLib;
	using UnhollowerRuntimeLib;
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



		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_VRCPlayerApi(VRC.SDKBase.VRCPlayerApi[] array)
		{
			var list = new Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRCPlayerApi>();
			foreach(var item in array)
			{
				if(item != null)
				{
					if(!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_UnityEngine_GameObjects(UnityEngine.GameObject[] array)
		{
			var list = new Il2CppSystem.Collections.Generic.List<UnityEngine.GameObject>();
			foreach (var item in array)
			{
				if (item != null)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}
	

		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_UnityEngine_AudioClips(UnityEngine.AudioClip[] array)
		{
			var list = new Il2CppSystem.Collections.Generic.List<UnityEngine.AudioClip>();
			foreach (var item in array)
			{
				if (item != null)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}



		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_UnityEngine_TextMeshProUGUIs(TMPro.TextMeshProUGUI[] array)
		{
			var list = new Il2CppSystem.Collections.Generic.List<TMPro.TextMeshProUGUI>();
			foreach (var item in array)
			{
				if (item != null)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}


		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_char(char[] array)
		{

			var list = new Il2CppSystem.Collections.Generic.List<char>();
			foreach (var item in array)
			{
				if (item != null)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Array_HumanBodyBones(UnityEngine.HumanBodyBones[] array)
		{
			var list = new Il2CppSystem.Collections.Generic.List<HumanBodyBones>();
			foreach (var item in array)
			{
				if (item != null)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
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

		public static Il2CppSystem.Object Generate_Il2CPPObject_TextMeshProUGUI(TMPro.TextMeshProUGUI item)
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<TMPro.TextMeshProUGUI>.NativeClassPtr, item.Pointer));
			if (boxed != null)
			{
				return boxed;
			}
			return null;
		}



		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_HumanBodyBones(UnityEngine.HumanBodyBones value)
		{
			foreach (var item in Il2CppType.Of<UnityEngine.HumanBodyBones>().GetEnumValues())
			{
				if (item.Unbox<UnityEngine.HumanBodyBones>() == value)
				{
					return item;
				}
			}
			return null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_UnityEngine_NetworkEventTarget(VRC.Udon.Common.Interfaces.NetworkEventTarget value)
		{
			foreach (var item in Il2CppType.Of<VRC.Udon.Common.Interfaces.NetworkEventTarget>().GetEnumValues())
			{
				if (item.Unbox<VRC.Udon.Common.Interfaces.NetworkEventTarget>() == value)
				{
					return item;
				}
			}
			return null;
		}
	}
}