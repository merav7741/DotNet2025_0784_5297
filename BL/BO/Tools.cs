using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;
using DO;


namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T t)
        {
            if (t == null)
                return "null";

            Type type = t.GetType();
            var sb = new StringBuilder();

            if (type.IsPrimitive || type.IsEnum || t is string || t is DateTime || t is decimal)
                return t.ToString();

            if (t is System.Collections.IEnumerable list && !(t is string))
            {
                sb.AppendLine("[");
                foreach (var item in list)
                {
                    sb.AppendLine(item.ToStringProperty());
                }
                sb.AppendLine("]");
                return sb.ToString();
            }

            sb.AppendLine($"{type.Name} {{");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                var value = prop.GetValue(t, null);
                sb.AppendLine($"  {prop.Name}: {value.ToStringProperty()}");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

    }
}
