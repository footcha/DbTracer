using DbTracer.Core.Schema.Comparer;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Test.Comparer
{
    public class ComparerTestBase<T, TComparer>
        where T : ISqlObject
        where TComparer : ISqlComparer<T>
    {
        protected T SourceDatabaseObject;
        protected T DestinationDatabaseObject;
        protected TComparer TestedComparer;
    }
}