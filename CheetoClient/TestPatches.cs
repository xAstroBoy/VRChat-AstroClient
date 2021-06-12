namespace CheetoClient
{
	using HarmonyLib;
	using UnityEngine;
	using UnityEngine.UI;

	//[HarmonyPatch(typeof(Text), nameof(Text.text), MethodType.Getter)]
	//public class TestPatch1
	//{
	//	static void Postfix(ref string __result, ref Text __instance)
	//	{
	//		__instance.color = Color.yellow;
	//		__result = "KEK";
	//	}
	//}
}
