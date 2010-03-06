using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class TriggerGenerator : CodeGeneratorBase<Trigger>
    {
        public TriggerGenerator(Trigger sourceObject)
            : base(sourceObject) { }
    }
}