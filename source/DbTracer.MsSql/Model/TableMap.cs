namespace DbTracer.MsSql.Model
{
    public class TableMap : SqlClassMap<Table>
    {
        protected override string TableName
        {
            get { return "sys.tables"; }
        }

        protected override void Configure()
        {
            ConfigureDatabaseObject(this);
            Map(obj => obj.LobDataSpaceId, "lob_data_space_id");
            Map(obj => obj.LockOnBulkLoad, "lock_on_bulk_load");
            Map(obj => obj.UsesAnsiNulls, "uses_ansi_nulls");
            Map(obj => obj.IsReplicated, "is_replicated");
            Map(obj => obj.HasReplicationFilter, "has_replication_filter");
            Map(obj => obj.IsMergePublished, "is_merge_published");
            Map(obj => obj.IsSyncTranSubscribed, "is_sync_tran_subscribed");
            Map(obj => obj.HasUncheckedAssemblyData, "has_unchecked_assembly_data");
            Map(obj => obj.TextInRowLimit, "text_in_row_limit");
            Map(obj => obj.LargeValueTypesOutOfRow, "large_value_types_out_of_row");
            HasMany(table => table.Triggers)
                .KeyColumn("parent_id")
                .AsMap("object_id")
                .Not.LazyLoad()
                .ReadOnly();
            HasMany(table => table.Indexes)
                .KeyColumn("object_id")
                .AsSet()
                .Not.LazyLoad()
                .ReadOnly();
        }
    }
}