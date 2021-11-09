namespace AstroClient.ClientUI.ActionMenuButtons.AvatarParametersModule.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroLibrary.Console;
    using UnityEngine;
    using VRC.Playables;

    internal static class Parameters
    {
        internal static readonly string[] DefaultParameterNames = new string[]
        {
            "Viseme",
            "GestureLeft",
            "GestureLeftWeight",
            "GestureRight",
            "GestureRightWeight",
            "TrackingType",
            "VRMode",
            "MuteSelf",
            "Grounded",
            "AngularY",
            "Upright",
            "AFK",
            "Seated",
            "InStation",
            "VelocityX",
            "VelocityY",
            "VelocityZ",
            "IsLocal",
            "AvatarVersion",
            "VRCEmote",
            "VRCFaceBlendH",
            "VRCFaceBlendV"
        };

        internal static List<AvatarParameter> FilterDefaultParameters(IEnumerable<AvatarParameter> src)
        {
            return src.Where(param => !DefaultParameterNames.Contains(param.field_Private_String_0)).ToList();
        }

        private class Parameter
        {
            internal Parameter()
            {
            }

            internal Parameter(AvatarParameter src)
            {
                type = src.field_Private_ParameterType_0;
                switch (type)
                {
                    case AvatarParameter.ParameterType.Bool:
                        val_bool = src.prop_Boolean_0;
                        break;

                    case AvatarParameter.ParameterType.Int:
                        val_int = src.prop_Int32_1;
                        break;

                    case AvatarParameter.ParameterType.Float:
                        val_float = src.prop_Single_0;
                        break;
                }
            }

            internal void Apply(AvatarParameter dst)
            {
                switch (type)
                {
                    case AvatarParameter.ParameterType.Bool:
                        dst.SetBoolProperty(val_bool);
                        break;

                    case AvatarParameter.ParameterType.Int:
                        dst.SetIntProperty(val_int);
                        break;

                    case AvatarParameter.ParameterType.Float:
                        dst.SetFloatProperty(val_float);
                        break;
                }

                dst.Lock();
            }

            internal AvatarParameter.ParameterType type;
            internal int val_int = 0;
            internal float val_float = 0.0f;
            internal bool val_bool = false;
        };

        private class AvatarSettings
        {
            internal string name;
            internal int version;
            internal Dictionary<string, Parameter> parameters;
            internal List<bool> renderers;
        }

        private static Dictionary<string, AvatarSettings> settings = new Dictionary<string, AvatarSettings>();

        internal static IEnumerable<AvatarParameter> GetAllAvatarParameters(this VRCAvatarManager manager)
        {
            var parameters = manager.field_Private_AvatarPlayableController_0?
                .field_Private_Dictionary_2_Int32_AvatarParameter_0;

            if (parameters == null)
                yield break;

            foreach (var param in parameters)
                yield return param.value;
        }

        internal static List<AvatarParameter> GetAvatarParameters(this VRCAvatarManager manager)
        {
            return FilterDefaultParameters(manager.GetAllAvatarParameters());
        }

        internal static bool HasCustomExpressions(this VRCAvatarManager manager)
        {
            return manager &&
                   manager.field_Private_AvatarPlayableController_0 != null &&
                   manager.prop_VRCAvatarDescriptor_0 != null &&
                   manager.prop_VRCAvatarDescriptor_0.customExpressions &&
                   /* Fuck you */
                   manager.prop_VRCAvatarDescriptor_0.expressionParameters != null &&
                   manager.prop_VRCAvatarDescriptor_0.expressionsMenu != null &&
                   /* This isn't funny */
                   manager.prop_VRCAvatarDescriptor_0.expressionsMenu.controls != null &&
                   manager.prop_VRCAvatarDescriptor_0.expressionsMenu.controls.Count > 0;
        }

        internal static IEnumerable<Renderer> GetAvatarRenderers(this VRCAvatarManager manager)
        {
            return manager.field_Private_ArrayOf_Renderer_0;
        }

        internal static void ApplyParameters(VRCAvatarManager manager)
        {
            var api_avatar = manager?.prop_ApiAvatar_0;
            if (api_avatar == null)
                return;

            /* Look up store */
            var key = api_avatar.id;
            if (!settings.ContainsKey(key))
                return;
            var config = settings[key];

            /* Check version */
            if (config.version != api_avatar.version)
            {
                ModConsole.Log(
                    $"Avatar {api_avatar.name} version missmatch ({config.version} != {api_avatar.version}). Removing");
                settings.Remove(key);
                return;
            }

            ModConsole.Log($"Applying avatar state to {api_avatar.name}");

            /* Apply parameters */
            if (config.parameters != null)
                foreach (var parameter in manager.GetAvatarParameters())
                    config.parameters[parameter.field_Private_String_0].Apply(parameter);

            /* Apply Meshes */
            if (config.renderers != null)
                foreach (var element in Enumerable.Zip(config.renderers, manager.GetAvatarRenderers(),
                    (state, renderer) => new { state, renderer }))
                    element.renderer.gameObject.active = element.renderer.enabled = element.state;
        }

        internal static void StoreParameters(VRCAvatarManager manager)
        {
            var api_avatar = manager?.prop_ApiAvatar_0;
            if (api_avatar == null)
                return;

            ModConsole.Log($"Storing avatar state for {api_avatar.name}");

            var config = new AvatarSettings
            {
                name = api_avatar.name,
                version = api_avatar.version,
                parameters = manager.GetAvatarParameters()
                    ?.ToDictionary(o => o.field_Private_String_0, o => new Parameter(o)),
                renderers = manager.GetAvatarRenderers().Select(o => o.gameObject.active && o.enabled).ToList()
            };

            var key = api_avatar.id;
            if (settings.ContainsKey(key))
                settings[key] = config;
            else
                settings.Add(key, config);

            /* Prevent override of changed parameters */
            foreach (var parameter in manager.GetAvatarParameters())
                parameter.Lock();
        }

        internal static void SetValue(this AvatarParameter parameter, float value)
        {
            if (parameter == null) return;
            /* Call original delegate to avoid self MITM */
            switch (parameter.field_Private_ParameterType_0)
            {
                case AvatarParameter.ParameterType.Bool:
                    _boolPropertySetterDelegate(parameter.Pointer, value != 0.0f);
                    break;

                case AvatarParameter.ParameterType.Int:
                    _intPropertySetterDelegate(parameter.Pointer, (int)value);
                    break;

                case AvatarParameter.ParameterType.Float:
                    _floatPropertySetterDelegate(parameter.Pointer, value);
                    break;
            }
        }

        internal static float GetValue(this AvatarParameter parameter)
        {
            if (parameter == null) return 0f;
            return parameter.field_Private_ParameterType_0 switch
            {
                AvatarParameter.ParameterType.Bool => parameter.prop_Boolean_0 ? 1f : 0f,
                AvatarParameter.ParameterType.Int => parameter.prop_Int32_1,
                AvatarParameter.ParameterType.Float => parameter.prop_Single_0,
                _ => 0f
            };
        }

        internal static void SetBoolProperty(this AvatarParameter parameter, bool value)
        {
            if (parameter == null) return;
            _boolPropertySetterDelegate(parameter.Pointer, value);
        }

        internal static void SetIntProperty(this AvatarParameter parameter, int value)
        {
            if (parameter == null) return;
            _intPropertySetterDelegate(parameter.Pointer, value);
        }

        internal static void SetFloatProperty(this AvatarParameter parameter, float value)
        {
            if (parameter == null) return;
            _floatPropertySetterDelegate(parameter.Pointer, value);
        }

        internal static void ResetParameters(VRCAvatarManager manager)
        {
            var api_avatar = manager?.prop_ApiAvatar_0;
            if (api_avatar == null)
                return;

            var key = api_avatar.id;

            if (settings.ContainsKey(key))
                settings.Remove(key);

            var defaults = manager.prop_VRCAvatarDescriptor_0?
                .expressionParameters;
            foreach (var parameter in manager.GetAvatarParameters())
            {
                parameter.SetValue(defaults.FindParameter(parameter.field_Private_String_0).defaultValue);
                parameter.Unlock();
            }
        }

        private static readonly HashSet<IntPtr> s_ParameterOverrideList = new HashSet<IntPtr>();

        internal static void Unlock(this AvatarParameter parameter)
        {
            /* Reenable parameter override */
            if (parameter.IsLocked())
                s_ParameterOverrideList.Remove(parameter.Pointer);
        }

        internal static void Lock(this AvatarParameter parameter)
        {
            /* Disable override parameters */
            if (!parameter.IsLocked())
                s_ParameterOverrideList.Add(parameter.Pointer);
        }

        internal static bool IsLocked(this AvatarParameter parameter)
        {
            return s_ParameterOverrideList.Contains(parameter.Pointer);
        }

        internal delegate void BoolPropertySetterDelegate(IntPtr @this, bool value);

        internal static BoolPropertySetterDelegate _boolPropertySetterDelegate;

        internal static void BoolPropertySetter(IntPtr @this, bool value)
        {
            /* Block manually overwritten parameters */
            var param = new AvatarParameter(@this);
            if (param.IsLocked())
                return;

            /* Invoke original function pointer */
            _boolPropertySetterDelegate(@this, value);
        }

        internal delegate void IntPropertySetterDelegate(IntPtr @this, int value);

        internal static IntPropertySetterDelegate _intPropertySetterDelegate;

        internal static void IntPropertySetter(IntPtr @this, int value)
        {
            /* Block manually overwritten parameters */
            var param = new AvatarParameter(@this);
            if (param.IsLocked())
                return;

            /* Invoke original function pointer */
            _intPropertySetterDelegate(@this, value);
        }

        internal delegate void FloatPropertySetterDelegate(IntPtr @this, float value);

        internal static FloatPropertySetterDelegate _floatPropertySetterDelegate;

        internal static void FloatPropertySetter(IntPtr @this, float value)
        {
            /* Block manually overwritten parameters */
            var param = new AvatarParameter(@this);
            if (param.IsLocked())
                return;

            /* Invoke original function pointer */
            _floatPropertySetterDelegate(@this, value);
        }
    }
}