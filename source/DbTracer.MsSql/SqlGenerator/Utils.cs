using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public static class Utils
    {
        public static string GetNullableSql(INullable sqlObject)
        {
            var text = "";
            if (!sqlObject.IsNullable) text += "NOT";
            text += " NULL";

            return text;
        }
    }
}