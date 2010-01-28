using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class Schema : MsSqlSchemaBase
    {
        public Schema(ISchema parent)
            : base(parent, MsSql.ObjectType1.Schema)
        { }

    }
}