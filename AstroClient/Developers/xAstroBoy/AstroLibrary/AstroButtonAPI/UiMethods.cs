namespace AstroClient.xAstroBoy.AstroButtonAPI
{
    using System;
    using System.Linq;
    using System.Reflection;
    using VRC.Core;

    internal class UiMethods : AstroEvents
    {

        internal static MethodInfo _apiUserToIUser;
        internal override void OnApplicationStart()
        {
            Type iUserParent = typeof(VRCPlayer).Assembly.GetTypes()
                .First(type => type.GetMethods()
                    .FirstOrDefault(method => method.Name.StartsWith("Method_Private_Void_Action_1_ApiWorldInstance_Action_1_String_")) != null && type.GetMethods()
                    .FirstOrDefault(method => method.Name.StartsWith("Method_Public_Virtual_Final_New_Observable_1_List_1_String_")) == null);
            _apiUserToIUser = typeof(DataModelCache).GetMethod("Method_Public_TYPE_String_TYPE2_Boolean_0");
            _apiUserToIUser = _apiUserToIUser.MakeGenericMethod(iUserParent, typeof(APIUser));
        }




    }
}
