using DbTracer.Core.Schema.Model;

namespace DbTracer.Core.Schema.Comparer
{
    public interface ICompareResult<T>
        where T : ISqlObject
    {
        T Source { get; }
        T Destination { get; }
        bool IsDifferent { get; }
        string ToSqlSourceToDestination();
        string ToSqlDestinationToSource();
    }
}