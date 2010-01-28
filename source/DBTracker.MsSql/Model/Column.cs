namespace DbTracker.MsSql.Model
{
    public class Column : ISqlObject
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Type SystemType { get; set; }
        public virtual Type UserType { get; set; }
        public virtual int MaxLength { get; set; }
        public virtual int Precision { get; set; }
        public virtual int Scale { get; set; }
        public virtual string Collation { get; set; }
        public virtual bool IsNullable { get; set; }
        public virtual bool IsAnsiPadded { get; set; }
        public virtual bool IsRowGuidCol { get; set; }
        public virtual bool IsIdentity { get; set; }
        public virtual bool IsComputed { get; set; }
        public virtual bool IsFileStream { get; set; }
        public virtual bool IsReplicated { get; set; }
        public virtual bool IsNonSqlSubscribed { get; set; }
        public virtual bool IsMergePublished { get; set; }
        public virtual bool IsDtsReplicated { get; set; }
        public virtual bool IsXmlDocument { get; set; }
        public virtual int XmlCollectionId { get; set; }
        public virtual int DefaultObjectId { get; set; }
        public virtual int RuleObjectId { get; set; }
        public virtual int Table { get; set; } // TODO foreign key to owning table

        public override bool Equals(object that)
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            var thatColumn = that as Column;
            if (thatColumn == null) return false;
            return thatColumn.Id == Id && thatColumn.Table == Table;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ Table;
            }
        }
    }
}