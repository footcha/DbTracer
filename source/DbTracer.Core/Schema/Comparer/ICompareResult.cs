using DbTracer.Core.Schema.Model;

namespace DbTracer.Core.Schema.Comparer
{
    public interface ICompareResult<T>
        where T : ISqlObject
    {
        T Source { get; }
        T Destination { get; }

        /// <summary>
        /// Determines whether <see cref="Source"/> and <see cref="Destination"/>
        /// are equal.
        /// </summary>
        bool IsDifferent { get; }

        /// <summary>
        /// Returns SQL definition for <see cref="Source"/>
        /// when it is compared to <see cref="Destination"/>.
        /// </summary>
        string ToSqlSourceToDestination();

        /// <summary>
        /// Returns SQL definition for <see cref="Destination"/>
        /// when it is compared to <see cref="Source"/>.
        /// </summary>
        string ToSqlDestinationToSource();
    }
}