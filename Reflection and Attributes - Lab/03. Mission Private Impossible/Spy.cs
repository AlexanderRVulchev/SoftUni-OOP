using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType);
            foreach (FieldInfo field in fields)
            {
                if (requestedFields.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            Object instance = Activator.CreateInstance(classType);

            foreach (FieldInfo field in fields)
                sb.AppendLine($"{field.Name} must be private!");

            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
                sb.AppendLine($"{method.Name} have to be private!");

            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
                sb.AppendLine($"{method.Name} have to be public!");

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo method in methodInfos)
                sb.AppendLine(method.Name);

            return sb.ToString().TrimEnd();
        }
    }
}
