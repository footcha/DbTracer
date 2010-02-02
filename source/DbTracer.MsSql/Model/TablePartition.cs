using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class TablePartition : MsSqlSchemaBase
    {
        public TablePartition(ISchema parent)
            : base(parent, ObjectType1.Partition)
        {
        }

        public string CompressType { get; set; }
    }
}