namespace DbTracker.MsSql.Model
{
    public class Index : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual int IndexId { get; set; }

        public virtual string Name { get; set; }

        public virtual SqlObjectType Type { get; set; }

        public virtual IndexType IndexType { get; set; }

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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var thatIndex = obj as Index;
            if (thatIndex == null) return false;
            return thatIndex.Id == Id && thatIndex.IndexId == IndexId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ IndexId;
            }
        }
    }

    //public class Index : MsSqlSchemaBase
    //{
    //    public enum IndexType
    //    {
    //        Heap = 0,
    //        Clustered = 1,
    //        Nonclustered = 2,
    //        Xml = 3,
    //        Geo = 4
    //    }

    //    public Index()
    //        : base(ObjectType1.Index)
    //    {
    //        FilterDefintion = "";
    //        Columns = new IndexColumns();
    //    }

    //    public override ISchema Clone()
    //    {
    //        var index = new Index
    //        {
    //            AllowPageLocks = AllowPageLocks,
    //            AllowRowLocks = AllowRowLocks,
    //            Columns = Columns.Clone(),
    //            FillFactor = FillFactor,
    //            FileGroup = FileGroup,
    //            Id = Id,
    //            IgnoreDupKey = IgnoreDupKey,
    //            IsAutoStatistics = IsAutoStatistics,
    //            IsDisabled = IsDisabled,
    //            IsPadded = IsPadded,
    //            IsPrimaryKey = IsPrimaryKey,
    //            IsUniqueKey = IsUniqueKey,
    //            Name = Name,
    //            SortInTempDb = SortInTempDb,
    //            Status = Status,
    //            Type = Type,
    //            Owner = Owner,
    //            FilterDefintion = FilterDefintion
    //        };
    //        ExtendedProperties.ForEach(item => index.ExtendedProperties.Add(item));
    //        return index;
    //    }

    //    public string FileGroup { get; set; }

    //    public Boolean SortInTempDb { get; set; }

    //    public string FilterDefintion { get; set; }

    //    public IndexColumns Columns { get; set; }

    //    public Boolean IsAutoStatistics { get; set; }

    //    public Boolean IsUniqueKey { get; set; }

    //    public Boolean IsPrimaryKey { get; set; }

    //    public IndexType Type { get; set; }

    //    public short FillFactor { get; set; }

    //    public Boolean IsDisabled { get; set; }

    //    public Boolean IsPadded { get; set; }

    //    public Boolean IgnoreDupKey { get; set; }

    //    public Boolean AllowPageLocks { get; set; }

    //    public Boolean AllowRowLocks { get; set; }

    //    public override string FullName
    //    {
    //        get
    //        {
    //            return Parent.FullName + ".[" + Name + "]";
    //        }
    //    }

    //    /// <summary>
    //    /// Compara dos indices y devuelve true si son iguales, caso contrario, devuelve false.
    //    /// </summary>
    //    public static Boolean Compare(Index origen, Index destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if (origen.AllowPageLocks != destino.AllowPageLocks) return false;
    //        if (origen.AllowRowLocks != destino.AllowRowLocks) return false;
    //        if (origen.FillFactor != destino.FillFactor) return false;
    //        if (origen.IgnoreDupKey != destino.IgnoreDupKey) return false;
    //        if (origen.IsAutoStatistics != destino.IsAutoStatistics) return false;
    //        if (origen.IsDisabled != destino.IsDisabled) return false;
    //        if (origen.IsPadded != destino.IsPadded) return false;
    //        if (origen.IsPrimaryKey != destino.IsPrimaryKey) return false;
    //        if (origen.IsUniqueKey != destino.IsUniqueKey) return false;
    //        if (origen.Type != destino.Type) return false;
    //        if (origen.SortInTempDb != destino.SortInTempDb) return false;
    //        if (!origen.FilterDefintion.Equals(destino.FilterDefintion)) return false;
    //        if (!IndexColumns.Compare(origen.Columns, destino.Columns)) return false;
    //        return CompareFileGroup(origen, destino);
    //    }

    //    public static Boolean CompareExceptIsDisabled(Index origen, Index destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if (origen.AllowPageLocks != destino.AllowPageLocks) return false;
    //        if (origen.AllowRowLocks != destino.AllowRowLocks) return false;
    //        if (origen.FillFactor != destino.FillFactor) return false;
    //        if (origen.IgnoreDupKey != destino.IgnoreDupKey) return false;
    //        if (origen.IsAutoStatistics != destino.IsAutoStatistics) return false;
    //        if (origen.IsPadded != destino.IsPadded) return false;
    //        if (origen.IsPrimaryKey != destino.IsPrimaryKey) return false;
    //        if (origen.IsUniqueKey != destino.IsUniqueKey) return false;
    //        if (origen.Type != destino.Type) return false;
    //        if (origen.SortInTempDb != destino.SortInTempDb) return false;
    //        if (!origen.FilterDefintion.Equals(destino.FilterDefintion)) return false;
    //        if (!IndexColumns.Compare(origen.Columns, destino.Columns)) return false;
    //        //return true;
    //        return CompareFileGroup(origen, destino);
    //    }

    //    private static Boolean CompareFileGroup(Index origen, Index destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if (origen.FileGroup != null)
    //        {
    //            if (!origen.FileGroup.Equals(destino.FileGroup)) return false;
    //        }
    //        return true;
    //    }
    //}
}