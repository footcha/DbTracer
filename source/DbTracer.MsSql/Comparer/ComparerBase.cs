using DbTracer.Core.Schema.Comparer;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Comparer
{
    public abstract class ComparerBase<T> : ISqlComparer<T>
        where T : ISqlObject
    {
        protected ComparerBase(T source)
        {
            Source = source;
        }

        protected T Source { get; private set; }

        public abstract ICompareResult<T> Compare(T destinationObject);
    }
}