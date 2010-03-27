using DbTracer.Core.Schema.Model;

namespace DbTracer.Core.Schema.Comparer
{
    public interface ISqlComparer<T>
        where T : ISqlObject
    {
        ICompareResult<T> Compare();
    }
}