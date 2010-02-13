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
        public virtual SqlObject Default { get; set; }
        public virtual SqlObject Rule { get; set; }
        public virtual SqlObject ParentObject { get; set; }

        public override bool Equals(object that)
        {
            if (!ModelUtils.Equals(this, that)) return false;
            var thatObject = that as Column;
            return thatObject != null && Equals(ParentObject, thatObject.ParentObject);
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
                    && Default == column.Default
                    && Rule == column.Rule
                    && ParentObject.Equals(column.ParentObject)
                   );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397);
            }
        }

        public override string ToString()
        {
            var parentId = ParentObject != null ? ParentObject.Id.ToString() : "null";
            return string.Format("{0}, Parent ID={1}, ID={2}",
                GetType().FullName, parentId, Id);
        }
    }
}