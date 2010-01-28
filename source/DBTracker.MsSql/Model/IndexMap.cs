namespace DbTracker.MsSql.Model
{
    public class IndexMap : SqlClassMap<Index>
    {
        protected override string TableName
        {
            get { return "sys.indexes"; }
        }

        protected override void Configure()
        {
            //ConfigureBasic(this);
            ReadOnly();
            Table(TableName);
            CompositeId()
                .KeyProperty(obj => obj.Id, "object_id")
                .KeyProperty(obj => obj.IndexId, "index_id");
            //Map(obj => obj.IndexId);
            //Map(obj => obj.Id);
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

            //Join("sys.objects", i => i.KeyColumn("parent_object_id")
            //    .Map(obj => obj.Type, "type")
            //    .CustomType<SqlObjectTypeMap>());
        }
    }
}