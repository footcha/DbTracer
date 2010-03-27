using DbTracer.Core.Schema.Comparer;
using DbTracer.Core.Schema.Model;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.Comparer
{
    public abstract class CodeComparerBase<T> : ComparerBase<T>
        where T : class, ISqlObject, ICode
    {
        protected CodeComparerBase(T source, T destination)
            : base(source, destination) { }

        public override ICompareResult<T> Compare()
        {
            return CreateResult();
        }

        private ICompareResult<T> CreateResult()
        {
            var result = new CompareResult<T>(Source, Destination)
            {
                SourceToDestinationSqlBuilder = CreateSqlConvertor(Source, Destination),
                DestinationToSourceSqlBuilder = CreateSqlConvertor(Destination, Source)
            };

            return result;
        }

        protected abstract SqlBuilder CreateSqlConvertor(T source, T destination);
    }
}