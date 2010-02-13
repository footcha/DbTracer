namespace DbTracer.MsSql.Model
{
    public class IndexMap : SqlClassMap<Index>
    {
        protected override string TableName
        {
            get { return "sys.indexes"; }
        }

        protected override void Configure()
        {
            ReadOnly();
            Table(TableName);
            CompositeId()
                .KeyReference(obj => obj.ParentObject, "object_id")
                .KeyProperty(obj => obj.Id, "index_id");
            Map(obj => obj.Name, "name");
            Map(obj => obj.IndexType, "type")
                .CustomType<IndexTypeMap>();
            Map(obj => obj.IsUnique, "is_unique");
            Map(obj => obj.IgnoreDuplicityKey, "ignore_dup_key");
            Map(obj => obj.IsPrimaryKey, "is_primary_key");
            Map(obj => obj.IsUniqueConstraint, "is_unique_constraint");
            Map(obj => obj.FillFactor, "fill_factor");
            Map(obj => obj.IsPadded, "is_padded");
            Map(obj => obj.IsDisabled, "is_disabled");
            Map(obj => obj.IsHypothetical, "is_hypothetical");
            Map(obj => obj.AllowRowLocks, "allow_row_locks");
            Map(obj => obj.AllowPageLocks, "allow_page_locks");
            References(obj => obj.ParentObject)
                .Column("object_id")
                .Not.LazyLoad();
            HasManyToMany(obj => obj.Columns)
                .Table("sys.index_columns")
                .AsSet()
                .ParentKeyColumn("index_id")
                .ParentKeyColumn("index_idf")
                .ChildKeyColumn("column_id1")
                .ChildKeyColumn("object_id1")
                .Subselect("aadsdf")
                .ForeignKeyConstraintNames("object_id2", "column_id2")
                .Not.LazyLoad();
        }
    }
}