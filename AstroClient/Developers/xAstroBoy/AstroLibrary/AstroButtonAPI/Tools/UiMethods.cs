using AstroClient.ClientActions;

namespace AstroClient.xAstroBoy.AstroButtonAPI.Tools
{
    using System;
    using System.Linq;
    using System.Reflection;
    using MelonLoader;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC.Core;
    using VRC.DataModel;
    using VRC.DataModel.Core;

    internal class UiMethods : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;

        }
        private void OnApplicationStart()
        {
            // This fixes the frame drops because it seems calling `GetMethods` on a type calls it static constructor
            Type iUserImpl = typeof(VRCPlayer).Assembly.GetTypes()
                .First(type => typeof(DataModel<APIUser>).IsAssignableFrom(type) &&
                    Il2CppType.From(typeof(DataModel<APIUser>)).IsAssignableFrom(Il2CppType.From(type)) &&
                    Il2CppType.Of<IUser>().IsAssignableFrom(Il2CppType.From(type)));

            //_apiUserToIUser = typeof(ObjectPublicDi2StObUnique).GetMethod("Method_Public_TYPE_String_TYPE2_Boolean_0").MakeGenericMethod(iUserImpl, typeof(APIUser));
            _apiUserToIUser = typeof(DataModelCache).GetMethod("Method_Public_TYPE_String_TYPE2_Boolean_0").MakeGenericMethod(iUserImpl, typeof(APIUser));

        }
        internal static MethodInfo _apiUserToIUser;
    }
}