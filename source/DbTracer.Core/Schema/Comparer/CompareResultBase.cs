using DbTracer.Core.Schema.Model;

namespace DbTracer.Core.Schema.Comparer
{
    public abstract class CompareResultBase<T> : ICompareResult<T>
        where T : class, ISqlObject
    {
        protected CompareResultBase(T source, T destination)
        {
            Source = source;
            Destination = destination;
        }
        public T Source { get; private set; }
        public T Destination { get; private set; }

        public virtual bool IsDifferent
        {
            get { return Source.Equals(Destination); }
        }

        public abstract string ToSqlSourceToDestination();
        public abstract string ToSqlDestinationToSource();
    }
}