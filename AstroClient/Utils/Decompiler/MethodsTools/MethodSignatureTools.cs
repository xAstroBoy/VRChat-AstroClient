namespace AstroClient.Reflection
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public static class MethodSignatureTools
    {
        public static string GetSignature(this MethodInfo method)
        {

            var signatureBuilder = new StringBuilder();

            bool invokable = method.isInvokable();
            // Add our method accessors if it's not invokable
            if (!invokable)
            {
                signatureBuilder.Append(GetMethodAccessorSignature(method));
                signatureBuilder.Append(" ");
            }

            // Add method name
            signatureBuilder.Append($"{method.DeclaringType.Name}.{method.Name}");

            // Add method generics
            if (method.IsGenericMethod)
            {
                signatureBuilder.Append(GetGenericSignature(method));
            }

            // Add method parameters
            signatureBuilder.Append(GetMethodArgumentsSignature(method));

            return signatureBuilder.ToString();
        }


        public static bool isInvokable(this MethodInfo method)
        {
            try
            {
                if (method.ReflectedType != null)
                {
                    return method.ReflectedType.GetProperties().FirstOrDefault(p =>
                        p.GetGetMethod().GetHashCode() == method.GetHashCode()
                        || p.GetSetMethod().GetHashCode() == method.GetHashCode()) != null;
                }
            }
            catch
            {

            }

            return false;
        }

        public static string GetMethodAccessorSignature(this MethodInfo method)
        {
            string signature = null;



            if (method.IsPublic)
            {
                signature = "public ";
            }
            else if (method.IsPrivate)
            {

                signature = "private ";
            }
            else if (method.IsAssembly)
            {

                signature = "internal ";
            }

            if (method.IsStatic)
            {

                signature = "static ";
            }

            if (method.IsFamily)
            {
                signature = "protected ";

            }



            signature += TypeSignatureTools.GetSignature(method.ReturnType);

            return signature;
        }


        public static string GetFieldAccessor(this FieldInfo field)
        {
            string signature = null;



            if (field.IsPublic)
            {
                signature = "public ";
            }
            else if (field.IsPrivate)
            {

                signature = "private ";
            }
            else if (field.IsAssembly)
            {

                signature = "internal ";
            }

            if (field.IsStatic)
            {

                signature = "static ";
            }

            if (field.IsFamily)
            {
                signature = "protected ";

            }

            return signature;
        }

        
        public static string GetGenericSignature(this MethodInfo method) {
            if (method == null) throw new ArgumentNullException(nameof(method));
            if (!method.IsGenericMethod) throw new ArgumentException($"{method.Name} is not generic.");

            return TypeSignatureTools.BuildGenericSignature(method.GetGenericArguments());
        }

        public static string GetMethodArgumentsSignature(this MethodInfo method) {
            bool invokable = method.isInvokable();
            var isExtensionMethod = method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false);
            var methodParameters = method.GetParameters().AsEnumerable();

            // If this signature is designed to be invoked and it's an extension method
            if (isExtensionMethod && invokable) {
                // Skip the first argument
                methodParameters = methodParameters.Skip(1);
            }

            var methodParameterSignatures = methodParameters.Select(param => {
                var signature = string.Empty;

                if (param.ParameterType.IsByRef)
                    signature = "ref ";
                else if (param.IsOut)
                    signature = "out ";
                else if (isExtensionMethod && param.Position == 0)
                    signature = "this ";

                if (!invokable) {
                    signature += TypeSignatureTools.GetSignature(param.ParameterType) + " ";
                }

                signature += param.Name;

                return signature;
            });

            return "(" + string.Join(", ", methodParameterSignatures) + ")";

        }
    }
}
