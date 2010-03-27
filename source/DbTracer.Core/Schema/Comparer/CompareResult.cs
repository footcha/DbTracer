using System;
using DbTracer.Core.Schema.Model;

namespace DbTracer.Core.Schema.Comparer
{
    public class CompareResult<T> : CompareResultBase<T>
        where T : class, ISqlObject
    {
        public CompareResult(T source, T destination)
            : base(source, destination) { }

        public SqlBuilder DestinationToSourceSqlBuilder { get; set; }

        public SqlBuilder SourceToDestinationSqlBuilder { get; set; }

        public override string ToSqlSourceToDestination()
        {
            return SourceToDestinationSqlBuilder.ToSql();
        }

        public override string ToSqlDestinationToSource()
        {
            return DestinationToSourceSqlBuilder.ToSql();
        }
    }

    public class SqlBuilder
    {
        private readonly Func<string> func;

        public SqlBuilder(string sql)
        {
            func = () => sql;
        }

        public SqlBuilder(Func<string> func)
        {
            this.func = func;
        }

        public string ToSql()
        {
            return func();
        }
    }
}