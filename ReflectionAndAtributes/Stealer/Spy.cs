using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string name, string[] fieldNames)
        {
            Type type = Type.GetType(name);
            FieldInfo[] info = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(type, new object[] { });
            sb.AppendLine($"Class under investigation: {type}");

            foreach (FieldInfo field in info.Where(x => fieldNames.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return $"{sb.ToString().Trim()}";
        }

        public string AnalyzeAccessModifiers(string name)
        {
            Type type = Type.GetType(name);
            FieldInfo[] info = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] methodInfoPublic = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            MethodInfo[] methodInfoNonPublic = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            //Object instance = Activator.CreateInstance(type, new object[] { });
            foreach (FieldInfo field in info)
            {
                sb.AppendLine($"{field.Name} must be private");
            }
            foreach (MethodInfo method in methodInfoNonPublic.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public");
            }
            foreach (MethodInfo method in methodInfoNonPublic.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private");
            }


            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string name)
        {
            Type type = Type.GetType(name);
            MethodInfo[] info = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {name}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (MethodInfo method in info)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }

        public string CollectGetterAndSetters(string name)
        {
            Type type = Type.GetType(name);
            MethodInfo[] info = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            //FieldInfo[] infoField = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            foreach (MethodInfo method in info.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in info.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set fields of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }




    }
}
