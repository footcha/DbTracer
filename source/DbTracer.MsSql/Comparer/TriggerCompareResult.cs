using DbTracer.Core.Schema.Comparer;
using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;

namespace DbTracer.MsSql.Comparer
{
    public class TriggerCompareResult : CompareResultBase<Trigger>
    {
        public TriggerCompareResult(Trigger source, Trigger destination)
            : base(source, destination) { }

        public override string ToSqlSourceToDestination()
        {
            return new TriggerCompareSqlScriptBuilder(Source, Destination).ToSql();
        }

        public override string ToSqlDestinationToSource()
        {
            return new TriggerCompareSqlScriptBuilder(Destination, Source).ToSql();
        }
    }
}