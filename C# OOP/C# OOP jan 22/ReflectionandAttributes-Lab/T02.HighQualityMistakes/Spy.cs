using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields((BindingFlags)60);

            Object instance = Activator.CreateInstance(type);

            sb.AppendLine($"Class under investigation: {className}");
            foreach (var field in fields.Where(x => fieldsNames.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);
            FieldInfo[] piblicFields = type.GetFields(BindingFlags.Public);


            return sb.ToString().Trim();
        }
    }
}
