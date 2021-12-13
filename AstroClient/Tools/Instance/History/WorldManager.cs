namespace AstroClient.Tools.InstanceHistory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using xAstroBoy;

    internal static class WorldManager
    {
        private static MethodInfo enterWorldMethod { get; } = typeof(VRCFlowManager).GetMethod(nameof(VRCFlowManager.Method_Public_Void_String_String_WorldTransitionInfo_Action_1_String_Boolean_0));
        private static Type transitionInfoEnum { get; } =  typeof(WorldTransitionInfo).GetNestedTypes().First();


        internal static void EnterWorld(string roomId)
        {
            object currentPortalInfo = Activator.CreateInstance(typeof(WorldTransitionInfo), new object[2] { Enum.Parse(transitionInfoEnum, "Menu"), "WorldInfo_Go" });
            currentPortalInfo.GetType().GetProperty($"field_Public_{transitionInfoEnum.Name}_0").SetValue(currentPortalInfo, transitionInfoEnum.GetEnumValues().GetValue(3)); //I hate reflection
            enterWorldMethod.Invoke(VRCFlowManager.prop_VRCFlowManager_0, new object[5] { roomId.Split(':')[0], roomId.Split(':')[1], currentPortalInfo, (Il2CppSystem.Action<string>)new Action<string>((str) => UiManager.OpenAlertPopup("Cannot Join World")), false }); //Just kill me
        }
    }
}
