using System.Text.RegularExpressions;
using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class SqlScriptBuilderForCodeSqlObject<T> : SqlCompareScriptBuilder<T>
        where T : class, ICode
    {
        private static readonly Regex regex = new Regex(@"^\s*(CREATE|ALTER)\s*", RegexOptions.IgnoreCase);

        public SqlScriptBuilderForCodeSqlObject(T source, T destination)
            : base(source, destination) { }

        public new IGenerator<T> SourceGenerator
        {
            get { return base.SourceGenerator; }
            set { base.SourceGenerator = value; }
        }

        public new IGenerator<T> DestinationGenerator
        {
            get { return base.DestinationGenerator; }
            set { base.DestinationGenerator = value; }
        }

        protected override string CreateAlterScriptFromSource()
        {
            var sql = SourceGenerator.ToCreateSql();
            return regex.Replace(sql, "ALTER ");
        }
    }
}