namespace AstroLibrary.Extensions
{
	using AstroLibrary.Utility;
	using ExitGames.Client.Photon;
	using UnityEngine;
	using VRC.SDKBase;
	using PhotonHandler = MonoBehaviour1PrivateObInPrInBoInInInInUnique;

	public class NetworkingExt
	{
		public static void RPC(RPC.Destination targetClients, GameObject targetObject, string methodname, object[] parameters)
		{
			Il2CppSystem.Object[] IL2CPPParameters = MiscUtility.Serialization.FromManagedArrayToIL2CPPArray(parameters);
			Networking.RPC(targetClients, targetObject, methodname, IL2CPPParameters);
		}

		public static void OpRaiseEvent(byte code, object customObject, Photon.Realtime.RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
		{
			Il2CppSystem.Object Object = MiscUtility.Serialization.FromManagedToIL2CPP<Il2CppSystem.Object>(customObject);
			OpRaiseEvent(code, Object, RaiseEventOptions, sendOptions);
		}

		public static void OpRaiseEvent(byte code, Il2CppSystem.Object customObject, Photon.Realtime.RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
		{
			PhotonHandler.
				field_Internal_Static_MonoBehaviour1PrivateObInPrInBoInInInInUnique_0.prop_LoadBalancingClient_0.
			 Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0
			(code,
			 customObject,
			 RaiseEventOptions,
			 sendOptions);
		}
	}
}