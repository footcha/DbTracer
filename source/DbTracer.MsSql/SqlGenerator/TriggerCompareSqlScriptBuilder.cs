using System.Text.RegularExpressions;
using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class TriggerCompareSqlScriptBuilder : SqlCompareScriptBuilder<Trigger>
    {
        private static readonly Regex regex = new Regex(@"^\s*(CREATE|ALTER)\s*", RegexOptions.IgnoreCase);

        public TriggerCompareSqlScriptBuilder(Trigger source, Trigger destination)
            : base(source, destination)
        {
            SourceGenerator = new TriggerGenerator(Source);
            DestinationGenerator = new TriggerGenerator(Destination);
        }

        protected override string CreateAlterScriptFromSource()
        {
            var sql = SourceGenerator.ToCreateSql();
            return regex.Replace(sql, "ALTER ");
        }
    }
}