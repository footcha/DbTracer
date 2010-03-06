using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class ModelUtils
    {
        public static string ToStringWithId(ISqlObject obj)
        {
            return string.Format("{0}, ID={1}", obj.GetType().FullName, obj.Id);
        }

        public static bool Equals<T1>(T1 thisObject, object thatObject)
            where T1 : class, ISqlObject
        {
            if (ReferenceEquals(null, thatObject)) return false;
            if (ReferenceEquals(thisObject, thatObject)) return true;
            if (thisObject.Id == 0) return false;
            var that = thatObject as T1;
            return that != null && thisObject.Id == that.Id;
        }
    }
}