namespace AstroLibrary.Extensions
{
	using AstroClient;
	using AstroLibrary.Console;
	using System.Collections.Generic;
	using System.Linq;
	using UnhollowerBaseLib;
	using UnityEngine;

	public static class UdonUnpacker_ext
	{
		public static string Unpack_String(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.String")
				{
					var result = Serialization.FromIL2CPPToManaged<string>(obj);
					if (!string.IsNullOrEmpty(result) && !string.IsNullOrWhiteSpace(result))
					{
						return result;
					}
					//var ptr = IL2CPP.Il2CppObjectBaseToPtrNotNull(obj);
					//if (ptr != null)
					//{
					//}
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static string[] Unpack_Array_String(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.String[]")
				{
					var array = Serialization.FromIL2CPPToManaged<string[]>(obj);
					if (array != null && array.Count() != 0)
					{
						return array;
					}
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static List<string> Unpack_List_String(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.String[]")
				{
					return obj.Unpack_Array_String()?.ToList();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static bool? Unpack_Boolean(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Boolean")
				{
					return obj.Unbox<System.Boolean>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static System.Char? Unpack_Char(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Char")
				{
					return obj.Unbox<System.Char>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static System.Int64? Unpack_Int64(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Int64")
				{
					return obj.Unbox<System.Int64>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static System.UInt32? Unpack_UInt32(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.UInt32")
				{
					return obj.Unbox<System.UInt32>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static System.Int32? Unpack_Int32(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Int32")
				{
					return obj.Unbox<System.Int32>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.Color? Unpack_Color(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Color")
				{
					return obj.Unbox<UnityEngine.Color>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static System.Single? Unpack_Single(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Single")
				{
					return obj.Unbox<System.Single>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.Transform Unpack_Transform(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Transform")
				{
					return obj.Cast<UnityEngine.Transform>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.GameObject Unpack_GameObject(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.GameObject")
				{
					return obj.Cast<UnityEngine.GameObject>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static VRC.SDKBase.VRCPlayerApi Unpack_VRCPlayerApi(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "VRC.SDKBase.VRCPlayerApi")
				{
					return obj.Cast<VRC.SDKBase.VRCPlayerApi>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static VRC.Udon.UdonBehaviour Unpack_UdonBehaviour(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "VRC.Udon.UdonBehaviour")
				{
					return obj.Cast<VRC.Udon.UdonBehaviour>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.Material Unpack_Material(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Material")
				{
					return obj.Cast<UnityEngine.Material>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.Vector3? Unpack_Vector3(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Vector3")
				{
					return obj.Unbox<UnityEngine.Vector3>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.Quaternion? Unpack_Quaternion(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Quaternion")
				{
					return obj.Unbox<UnityEngine.Quaternion>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.HumanBodyBones? Unpack_HumanBodyBones(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.HumanBodyBones")
				{
					return obj.Unbox<UnityEngine.HumanBodyBones>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static VRC.Udon.Common.Interfaces.NetworkEventTarget? Unpack_NetworkEventTarget(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "VRC.Udon.Common.Interfaces.NetworkEventTarget")
				{
					return obj.Unbox<VRC.Udon.Common.Interfaces.NetworkEventTarget>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}

			return null;
		}

		public static System.Object Unpack_System_Object(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Object")
				{
					return Serialization.FromIL2CPPToManaged<System.Object>(obj);
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static TMPro.TextMeshPro Unpack_TextMeshPro(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "TMPro.TextMeshPro")
				{
					return obj.Cast<TMPro.TextMeshPro>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.AudioSource Unpack_AudioSource(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.AudioSource")
				{
					return obj.Cast<UnityEngine.AudioSource>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.UI.Text Unpack_Text(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.UI.Text")
				{
					return obj.Cast<UnityEngine.UI.Text>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static TMPro.TextMeshProUGUI Unpack_TextMeshProUGUI(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "TMPro.TextMeshProUGUI")
				{
					return obj.Cast<TMPro.TextMeshProUGUI>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}



		public static TMPro.TextMeshProUGUI[] Unpack_Array_TextMeshProUGUI(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "TMPro.TextMeshProUGUI[]")
				{
					var array = Il2CppArrayBase<TMPro.TextMeshProUGUI>.WrapNativeGenericArrayPointer(obj.Pointer);
					if (array != null && array.Count() != 0)
					{
						return array;
					}
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static List<TMPro.TextMeshProUGUI> Unpack_List_TextMeshProUGUI(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "TMPro.TextMeshProUGUI[]")
				{
					return obj.Unpack_Array_TextMeshProUGUI()?.ToList();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}


		public static UnityEngine.MeshRenderer Unpack_MeshRenderer(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.MeshRenderer")
				{
					return obj.Cast<UnityEngine.MeshRenderer>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.ParticleSystem Unpack_ParticleSystem(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.ParticleSystem")
				{
					return obj.Cast<UnityEngine.ParticleSystem>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static GameObject[] Unpack_Array_GameObject(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.GameObject[]")
				{
					var array = Il2CppArrayBase<GameObject>.WrapNativeGenericArrayPointer(obj.Pointer);
					if (array != null && array.Count() != 0)
					{
						return array;
					}
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static List<GameObject> Unpack_List_GameObject(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.GameObject[]")
				{
					return obj.Unpack_Array_GameObject()?.ToList();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static VRC.SDKBase.VRCPlayerApi[] Unpack_Array_VRCPlayerApi(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "VRC.SDKBase.VRCPlayerApi[]")
				{
					var array = Il2CppArrayBase<VRC.SDKBase.VRCPlayerApi>.WrapNativeGenericArrayPointer(obj.Pointer);
					if (array != null && array.Count() != 0)
					{
						return array;
					}
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static List<VRC.SDKBase.VRCPlayerApi> Unpack_List_VRCPlayerApi(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "VRC.SDKBase.VRCPlayerApi[]")
				{
					return obj.Unpack_Array_VRCPlayerApi()?.ToList();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static UnityEngine.AudioClip[] Unpack_Array_AudioClip(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.AudioClip[]")
				{
					var array = Il2CppArrayBase<UnityEngine.AudioClip>.WrapNativeGenericArrayPointer(obj.Pointer);
					if (array != null && array.Count() != 0)
					{
						return array;
					}
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static List<UnityEngine.AudioClip> Unpack_List_AudioClip(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.AudioClip[]")
				{
					return obj.Unpack_Array_AudioClip()?.ToList();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static System.Char[] Unpack_Array_Char(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Char[]")
				{
					var array = Il2CppArrayBase<System.Char>.WrapNativeGenericArrayPointer(obj.Pointer);
					if (array != null && array.Count() != 0)
					{
						return array;
					}
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static List<System.Char> Unpack_List_Char(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Char[]")
				{
					return obj.Unpack_Array_Char()?.ToList();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}
	}
}