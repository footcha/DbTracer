using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
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