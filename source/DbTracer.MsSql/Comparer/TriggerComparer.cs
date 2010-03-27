using DbTracer.Core.Schema.Model;
using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;
using SqlBuilder = DbTracer.Core.Schema.Comparer.SqlBuilder;

namespace DbTracer.MsSql.Comparer
{
    public class TriggerComparer
        : CodeComparerBase<Trigger>, ISqlGeneratorComparer<Trigger>
    {
        public TriggerComparer(Trigger source, Trigger destination) : base(source, destination) { }

        protected override SqlBuilder CreateSqlConvertor(Trigger source, Trigger destination)
        {
            return Utils.CreateSqlBuilderForCodeSqlObject(source, destination, SourceToDestinationGenerator, DestinationToSourceGenerator);
        }

        public IGenerator<Trigger> SourceToDestinationGenerator { get; set; }

        public IGenerator<Trigger> DestinationToSourceGenerator { get; set; }
    }

    public interface ISqlGeneratorComparer<T>
        where T : class, ISqlObject
    {
        IGenerator<T> SourceToDestinationGenerator { get; set; }
        IGenerator<T> DestinationToSourceGenerator { get; set; }
    }
}