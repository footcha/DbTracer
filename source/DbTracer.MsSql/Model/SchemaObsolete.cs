using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class SchemaObsolete : MsSqlSchemaBase
    {
        public SchemaObsolete(ISchema parent)
            : base(parent, ObjectType1.Schema)
        { }
    }
}