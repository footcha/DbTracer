using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class Schema : MsSqlSchemaBase
    {
        public Schema(ISchema parent)
            : base(parent, ObjectType1.Schema)
        { }
    }
}