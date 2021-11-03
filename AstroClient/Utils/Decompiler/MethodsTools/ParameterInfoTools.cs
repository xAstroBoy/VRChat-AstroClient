using System.Text;
using System.Linq;
using System.Reflection;

namespace AstroClient.Reflection
{
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using Microsoft.CSharp;

    public static class ParameterInfoTools
    {
        internal static string ConvertParametersToString(this MethodInfo methodinfo)
        {
            if (methodinfo != null)
            {
                StringBuilder result = new StringBuilder();
                var parameters = methodinfo.GetParameters();
                bool isFirstParam = true;

                foreach (var parameter in parameters)
                {
                    var HasValue = "";
                    Type ParameterType = (parameter.IsOut || parameter.ParameterType.IsByRef) ? parameter.ParameterType.GetElementType() : parameter.ParameterType;
                    if (ParameterType != null)
                    {
                        if (ParameterType.GetProperties().Count() == 2 && ParameterType.GetProperties()[0].Name.Equals("HasValue"))
                        {
                            HasValue = "?";
                            ParameterType = ParameterType.GetProperties()[1].PropertyType;
                        }

                        StringBuilder sb = new StringBuilder();
                        using (StringWriter sw = new StringWriter(sb))
                        {
                            var expr = new CodeTypeReferenceExpression(ParameterType);
                            var prov = new CSharpCodeProvider();
                            prov.GenerateCodeFromExpression(expr, sw, new CodeGeneratorOptions());
                        }



                        if (isFirstParam)
                        {
                            result.Append(string.Concat(sb.ToString(), HasValue, " ", parameter.Name));
                            isFirstParam = false;
                        }
                        else
                        {
                            result.Append(string.Concat(", " + sb.ToString(), HasValue, " ", parameter.Name));
                        }
                        //return "(" + string.Join(", ", methodParameterSignatures) + ")";

                    }
                }



                return result.ToString();
            }

            return "";
        }

        internal static string ConvertParametersToString(this MethodBase MethodBase)
        {
            return (MethodBase as MethodInfo).ConvertParametersToString();
        }


    }
}
