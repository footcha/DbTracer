using DbTracer.Core.Schema.Comparer;
using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;

namespace DbTracer.MsSql.Comparer
{
    public class TriggerComparer : CodeComparerBase<Trigger>
    {
        public TriggerComparer(Trigger source, Trigger destination) : base(source, destination) { }

        protected override SqlBuilder CreateSqlConvertor(Trigger source, Trigger destination)
        {
            return Utils.CreateSqlBuilderForCodeSqlObject(source, destination, new TriggerGenerator(source),
                                                            new TriggerGenerator(destination));
        }
    }
}