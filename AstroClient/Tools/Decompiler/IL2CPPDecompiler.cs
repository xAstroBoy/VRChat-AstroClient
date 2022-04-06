namespace AstroClient.Tools.Decompiler
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using MethodsTools;
    using UnhollowerRuntimeLib.XrefScans;
    using xAstroBoy.Extensions;

    internal class IL2CPPDecompiler
    {
        internal static string GetClass<T>(bool PrintInConsole = false)
        {
            try
            {
                StringBuilder result = new StringBuilder();

                foreach (var member in typeof(T).GetMembers())
                {
                    switch (member.MemberType)
                    {
                        case MemberTypes.Method:
                            result.AppendLine(DumpMethod((MethodBase)member));
                            break;

                        case MemberTypes.Property:
                            result.AppendLine(GetProperty((PropertyInfo)member));
                            break;

                        case MemberTypes.Field:
                            result.AppendLine(GetField((FieldInfo)member));
                            break;

                        case MemberTypes.Constructor:
                            result.AppendLine($"[Constructor] {member.DeclaringType.Name}.{member.Name}");

                            //result.AppendLine(((MethodBase)member));
                            break;

                        default:
                            result.AppendLine($"[Unsupported {member.MemberType.ToString()}] {member.DeclaringType.Name}.{member.Name}");
                            break;
                    }
                }

                if (PrintInConsole)
                {
                    Log.Write(result.ToString());
                }
                return result.ToString();
            }
            catch (Exception e)
            {
                ModConsole.Error($"[IL2CPP Decompiler] Error :");
                ModConsole.ErrorExc(e);
            }

            return null;
        }

        internal static string DumpMethod(MethodBase MethodBase)
        {
            try
            {
                StringBuilder result = new StringBuilder();
                MethodInfo methodInfo = (MethodInfo)MethodBase;
                result.AppendLine(methodInfo.GetSignature());
                result.AppendLine(GetMethodCode(MethodBase));
                result.AppendLine();
                return result.ToString();
            }
            catch (Exception e)
            {
                ModConsole.Error($"[Method] Failed At Method: ");
                ModConsole.ErrorExc(e);
            }

            return "";
        }

        internal static string GetMethodCode(MethodBase MethodBase)
        {
            try
            {
                StringBuilder result = new StringBuilder();


                string codeline = GetCodeLineFromMethod(MethodBase);
                if (codeline.IsNotNullOrEmptyOrWhiteSpace())
                {
                    result.AppendLine("{");
                    result.AppendLine(codeline);
                    result.AppendLine("}");
                }
                else
                {
                    result.Append("{ }");
                }

                return result.ToString();
            }
            catch (Exception e)
            {
                ModConsole.Error($"[Method] Failed At Method Code: ");
                ModConsole.ErrorExc(e);
            }

            return "";
        }


        internal static string GetCodeLineFromMethod(MethodBase MethodBase)
        {
            if (MethodBase.IsConstructor || MethodBase.IsAbstract)
                return "";
            StringBuilder result = new StringBuilder();
            foreach (var Xref in XrefScanner.XrefScan(MethodBase))
            {
                try
                {

                    if (Xref.Type == XrefType.Method)
                    {

                        MethodBase Method = Xref.TryResolve();
                        if (Method != null)
                        {
                            if (Method.IsAbstract)
                            {
                                // TODO : Add support.
                                continue;
                            }
                            if (IL2CPPDecompilerHelper.nameToOperatorName.ContainsKey(Method.Name))
                            {
                                string[] Operator = IL2CPPDecompilerHelper.nameToOperatorName[Method.Name];
                                //string Params = "";
                                //foreach (var param in Method.GetParameters())
                                //{
                                //    string Translated = "";
                                //    if (param.ParameterType.Name == "Object")
                                //    {
                                //        if (param.ParameterType.FullName.Equals("UnityEngine.Object"))
                                //        {
                                //            var paramtoobj = (UnityEngine.Object)param.ParameterType;
                                //            Params += $"({paramtoobj.FullName}){param.Name}";
                                //        }
                                //        else
                                //        {
                                //            Params += $"({param.ParameterType.FullName}){param.Name}";
                                //        }
                                //    }
                                //    else
                                //    {
                                //        Params += $"({param.ParameterType.Name}){param.Name}";
                                //    }
                                //}
                                //Params = ;
                                result.AppendLine($"if(? {Operator[1]} ?) Params : {Method.ConvertParametersToString()}");
                            }
                            else
                            {
                                //string NewMethodParams = "(";
                                //foreach (var param in Method.GetParameters())
                                //    if (param != null)
                                //        NewMethodParams += $"({param.ParameterType.Name}){param.Name},";
                                //NewMethodParams += ")";

                                string Params = Method.ConvertParametersToString();
                                if (Params.IsNotNullOrEmptyOrWhiteSpace())
                                {
                                    result.AppendLine($"{Method.DeclaringType.Name}.{Method.Name}({Method.ConvertParametersToString()}) ");
                                }
                                else
                                {
                                    result.AppendLine($"{Method.DeclaringType.Name}.{Method.Name}()");
                                }



                            }
                        }
                    }

                    if (Xref.Type == XrefType.Global)
                    {
                        Il2CppSystem.Object @object = Xref.ReadAsObject();
                        if (@object != null)
                        {
                            string Name = @object.ToString();
                            result.AppendLine($"({@object.GetIl2CppType().Name}){Name} ");
                        }
                    }
                }
                catch (Exception e)
                {
                    ModConsole.Error($"Failed to Parse CodeLine from method");
                    ModConsole.ErrorExc(e);
                }
            }

            return result.ToString();
        }

        internal static string GetProperty(PropertyInfo property)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"[Property] {property.PropertyType.Name} {property.DeclaringType.Name}.{property.Name}");
            result.Append("{ ");
            if (property.CanRead)
                result.Append("get;");
            if (property.CanWrite)
                result.Append("set;");
            result.AppendLine(" }");
            return result.ToString();
        }

        public static string GetField(FieldInfo field)
        {
            StringBuilder result = new StringBuilder();
            result.Append(field.GetFieldAccessor());
            result.AppendLine($"[Field] {field.FieldType.Name} {field.DeclaringType.Name}.{field.Name}");
            return result.ToString();
        }

        internal class IL2CPPDecompilerHelper
        {
            public static readonly Dictionary<string, string[]> nameToOperatorName = new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                { "op_Addition", "operator +".Split(' ') },
                { "op_BitwiseAnd", "operator &".Split(' ') },
                { "op_BitwiseOr", "operator |".Split(' ') },
                { "op_Decrement", "operator --".Split(' ') },
                { "op_Division", "operator /".Split(' ') },
                { "op_Equality", "operator ==".Split(' ') },
                { "op_ExclusiveOr", "operator ^".Split(' ') },
                { "op_Explicit", "explicit operator".Split(' ') },
                { "op_False", "operator false".Split(' ') },
                { "op_GreaterThan", "operator >".Split(' ') },
                { "op_GreaterThanOrEqual", "operator >=".Split(' ') },
                { "op_Implicit", "implicit operator".Split(' ') },
                { "op_Increment", "operator ++".Split(' ') },
                { "op_Inequality", "operator !=".Split(' ') },
                { "op_LeftShift", "operator <<".Split(' ') },
                { "op_LessThan", "operator <".Split(' ') },
                { "op_LessThanOrEqual", "operator <=".Split(' ') },
                { "op_LogicalNot", "operator !".Split(' ') },
                { "op_Modulus", "operator %".Split(' ') },
                { "op_Multiply", "operator *".Split(' ') },
                { "op_OnesComplement", "operator ~".Split(' ') },
                { "op_RightShift", "operator >>".Split(' ') },
                { "op_Subtraction", "operator -".Split(' ') },
                { "op_True", "operator true".Split(' ') },
                { "op_UnaryNegation", "operator -".Split(' ') },
                { "op_UnaryPlus", "operator +".Split(' ') },
            };

            public static readonly HashSet<string> isKeyword = new HashSet<string>(StringComparer.Ordinal)
            {
                "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
                "char", "checked", "class", "const", "continue", "decimal", "default", "delegate",
                "do", "double", "else", "enum", "event", "explicit", "extern", "false",
                "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit",
                "in", "int", "interface", "internal", "is", "lock", "long", "namespace",
                "new", "null", "object", "operator", "out", "override", "params", "private",
                "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
                "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw",
                "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort",
                "using", "virtual", "void", "volatile", "while",
            };

            private const string Keyword_true = "true";
            private const string Keyword_false = "false";
            private const string Keyword_null = "null";
            private const string Keyword_out = "out";
            private const string Keyword_in = "in";
            private const string Keyword_ref = "ref";
            private const string Keyword_readonly = "readonly";
            private const string Keyword_this = "this";
            private const string Keyword_get = "get";
            private const string Keyword_set = "set";
            private const string Keyword_add = "add";
            private const string Keyword_remove = "remove";
            private const string Keyword_enum = "enum";
            private const string Keyword_struct = "struct";
            private const string Keyword_interface = "interface";
            private const string Keyword_class = "class";
            private const string Keyword_namespace = "namespace";
            private const string Keyword_params = "params";
            private const string Keyword_default = "default";
            private const string Keyword_delegate = "delegate";
            private const string HexPrefix = "0x";
            private const string VerbatimStringPrefix = "@";
            private const string IdentifierEscapeBegin = "@";
            private const string ModuleNameSeparator = "!";
            private const string CommentBegin = "/*";
            private const string CommentEnd = "*/";
            private const string DeprecatedParenOpen = "[";
            private const string DeprecatedParenClose = "]";
            private const string MemberSpecialParenOpen = "(";
            private const string MemberSpecialParenClose = ")";
            private const string MethodParenOpen = "(";
            private const string MethodParenClose = ")";
            private const string DescriptionParenOpen = "(";
            private const string DescriptionParenClose = ")";
            private const string IndexerParenOpen = "[";
            private const string IndexerParenClose = "]";
            private const string PropertyParenOpen = "[";
            private const string PropertyParenClose = "]";
            private const string ArrayParenOpen = "[";
            private const string ArrayParenClose = "]";
            private const string TupleParenOpen = "(";
            private const string TupleParenClose = ")";
            private const string GenericParenOpen = "<";
            private const string GenericParenClose = ">";
            private const string DefaultParamValueParenOpen = "[";
            private const string DefaultParamValueParenClose = "]";
        }
    }
}