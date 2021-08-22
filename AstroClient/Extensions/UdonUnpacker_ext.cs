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
					return obj.Unbox<bool>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static char? Unpack_Char(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Char")
				{
					return obj.Unbox<char>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static long? Unpack_Int64(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Int64")
				{
					return obj.Unbox<long>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static uint? Unpack_UInt32(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.UInt32")
				{
					return obj.Unbox<uint>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static int? Unpack_Int32(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Int32")
				{
					return obj.Unbox<int>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static Color? Unpack_Color(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Color")
				{
					return obj.Unbox<Color>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static float? Unpack_Single(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Single")
				{
					return obj.Unbox<float>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static Transform Unpack_Transform(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Transform")
				{
					return obj.Cast<Transform>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static GameObject Unpack_GameObject(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.GameObject")
				{
					return obj.Cast<GameObject>();
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

		public static Material Unpack_Material(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Material")
				{
					return obj.Cast<Material>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static Vector3? Unpack_Vector3(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Vector3")
				{
					return obj.Unbox<Vector3>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static Quaternion? Unpack_Quaternion(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.Quaternion")
				{
					return obj.Unbox<Quaternion>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static HumanBodyBones? Unpack_HumanBodyBones(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.HumanBodyBones")
				{
					return obj.Unbox<HumanBodyBones>();
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

		public static object Unpack_System_Object(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Object")
				{
					return Serialization.FromIL2CPPToManaged<object>(obj);
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

		public static AudioSource Unpack_AudioSource(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.AudioSource")
				{
					return obj.Cast<AudioSource>();
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


		public static MeshRenderer Unpack_MeshRenderer(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.MeshRenderer")
				{
					return obj.Cast<MeshRenderer>();
				}
				else
				{
					ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
				}
			}
			return null;
		}

		public static ParticleSystem Unpack_ParticleSystem(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.ParticleSystem")
				{
					return obj.Cast<ParticleSystem>();
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

		public static AudioClip[] Unpack_Array_AudioClip(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "UnityEngine.AudioClip[]")
				{
					var array = Il2CppArrayBase<AudioClip>.WrapNativeGenericArrayPointer(obj.Pointer);
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

		public static List<AudioClip> Unpack_List_AudioClip(this Il2CppSystem.Object obj)
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

		public static char[] Unpack_Array_Char(this Il2CppSystem.Object obj)
		{
			if (obj != null)
			{
				if (obj.GetIl2CppType().FullName == "System.Char[]")
				{
					var array = Il2CppArrayBase<char>.WrapNativeGenericArrayPointer(obj.Pointer);
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

		public static List<char> Unpack_List_Char(this Il2CppSystem.Object obj)
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