using System.Text.RegularExpressions;
using DbTracer.Core.Schema.Comparer;
using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;

namespace DbTracer.MsSql.Comparer
{
    public class TriggerCompareResult : CompareResultBase<Trigger>
    {
        private static readonly Regex regex = new Regex(@"^\s*(CREATE|ALTER)\s*", RegexOptions.IgnoreCase);

        public TriggerCompareResult(Trigger source, Trigger destination)
            : base(source, destination)
        {
            GeneratorBuilder = sourceObject => new TriggerGenerator(sourceObject);
        }

        protected override string CreateAlterScript(Trigger source)
        {
            var sql = GeneratorBuilder(source).ToCreateSql();
            return regex.Replace(sql, "ALTER ");
        }
    }
}