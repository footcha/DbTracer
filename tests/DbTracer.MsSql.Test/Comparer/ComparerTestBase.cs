using DbTracer.Core.Schema.Comparer;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Test.Comparer
{
    public class ComparerTestBase<T, TComparer>
        where T : ISqlObject
        where TComparer : ISqlComparer<T>
    {
        protected T TestedObject1;
        protected T TestedObject2;
        protected TComparer TestedComparer;
    }
}