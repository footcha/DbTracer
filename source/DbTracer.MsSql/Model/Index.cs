using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class Index : ISqlObject
    {
        public Index()
        {
            Init();
        }

        private void Init()
        {
            Columns = new List<Column>();
        }

        public virtual int Id { get; set; }
        
        public virtual int ObjectId { get; set; }

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

        public virtual SqlObject ParentObject { get; set; }

        public virtual ICollection<Column> Columns { get; set; }

        public override bool Equals(object that)
        {
            if (!ModelUtils.Equals(this, that)) return false;
            if (ParentObject == null) return false;
            var thatIndex = (Index)that;
            return Equals(ParentObject, thatIndex.ParentObject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ Id;
            }
        }
    }
}