namespace DbTracer.MsSql.Model
{
    public class ModelUtils
    {
        public static string ToStringWithId(ISqlObject obj)
        {
            return string.Format("{0}, ID={1}", obj.GetType().FullName, obj.Id);
        }
    }
}