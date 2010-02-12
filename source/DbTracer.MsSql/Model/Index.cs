namespace DbTracer.MsSql.Model
{
    public class Index : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual int IndexId { get; set; }

        public virtual string Name { get; set; }

        public virtual SqlObjectType Type { get; set; }

        public virtual IndexType IndexType { get; set; }

        //public virtual bool DataSpaceId { get; set; } // TODO foreing key to dataspace id

        public virtual bool IsUnique { get; set; }

        public virtual bool IgnoreDuplicityKey { get; set; }

        public virtual bool IsPrimaryKey { get; set; }

        public virtual bool IsUniqueConstraint { get; set; }

        public virtual int FillFactor { get; set; }

        public virtual bool IsPadded { get; set; }

        public virtual bool IsDisabled { get; set; }

        public virtual bool IsHypothetical { get; set; }

        public virtual bool AllowRowLocks { get; set; }

        public virtual bool AllowPageLocks { get; set; }

        public virtual Table Table { get; set; }

        public override bool Equals(object that)
        {
            if (!ModelUtils.Equals(this, that)) return false;
            if (IndexId == 0) return false;
            var thatIndex = (Index)that;
            return thatIndex.IndexId == IndexId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ IndexId;
            }
        }
    }
}