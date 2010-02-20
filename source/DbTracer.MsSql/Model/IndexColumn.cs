namespace DbTracer.MsSql.Model
{
    public class IndexColumn
    {
        public virtual int KeyOrdinal { get; set; }

        public virtual int PartitionOrdinal { get; set; }

        public virtual bool IsDescendingKey { get; set; }

        public virtual bool IsIncludedColumn { get; set; }

        public virtual Column Column { get; set; }
    }
}