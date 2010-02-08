namespace DbTracer.MsSql.Model
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
        public virtual Table Table { get; set; }

        public override bool Equals(object that)
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            var thatColumn = that as Column;
            if (thatColumn == null) return false;
            if (Id == 0) return false;
            return thatColumn.Id == Id;
        }

        /// <summary>
        /// Equality is based on all public properties including deep equality of composed objects.
        /// </summary>
        /// <param name="column">column to be compared with this object</param>
        /// <returns></returns>
        public virtual bool EqualsFully(Column column)
        {
            if (!Equals(column)) return false;
            return (Id == column.Id
                    && Name == column.Name
                    && SystemType.Equals(column.SystemType)
                    && UserType.Equals(column.UserType)
                    && MaxLength == column.MaxLength
                    && Precision == column.Precision
                    && Scale == column.Scale
                    && Collation == column.Collation
                    && IsNullable == column.IsNullable
                    && IsAnsiPadded == column.IsAnsiPadded
                    && IsRowGuidCol == column.IsRowGuidCol
                    && IsIdentity == column.IsIdentity
                    && IsComputed == column.IsComputed
                    && IsFileStream == column.IsFileStream
                    && IsReplicated == column.IsReplicated
                    && IsNonSqlSubscribed == column.IsNonSqlSubscribed
                    && IsMergePublished == column.IsMergePublished
                    && IsDtsReplicated == column.IsDtsReplicated
                    && IsXmlDocument == column.IsXmlDocument
                    && XmlCollectionId == column.XmlCollectionId
                    && DefaultObjectId == column.DefaultObjectId
                    && RuleObjectId == column.RuleObjectId
                    && Table.Equals(column.Table)
                   );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397);
            }
        }
    }
}