using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class TableMap : SubclassMap<Table>
    {
        public TableMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.TableUserDefined));
            Join("sys.tables", t =>
            {
                t.KeyColumn("object_id");
                t.Map(obj => obj.LobDataSpaceId, "lob_data_space_id");
                t.Map(obj => obj.LockOnBulkLoad, "lock_on_bulk_load");
                t.Map(obj => obj.UsesAnsiNulls, "uses_ansi_nulls");
                t.Map(obj => obj.IsReplicated, "is_replicated");
                t.Map(obj => obj.HasReplicationFilter, "has_replication_filter");
                t.Map(obj => obj.IsMergePublished, "is_merge_published");
                t.Map(obj => obj.IsSyncTranSubscribed, "is_sync_tran_subscribed");
                t.Map(obj => obj.HasUncheckedAssemblyData, "has_unchecked_assembly_data");
                t.Map(obj => obj.TextInRowLimit, "text_in_row_limit");
                t.Map(obj => obj.LargeValueTypesOutOfRow, "large_value_types_out_of_row");
            });
            HasMany(table => table.Triggers)
                .KeyColumn("parent_object_id")
                .AsSet()
                .Not.LazyLoad()
                .ReadOnly();
            HasMany(table => table.Columns)
                .KeyColumn("object_id")
                .AsSet()
                .Not.LazyLoad()
                .ReadOnly();
            HasMany(table => table.Indexes)
                .KeyColumn("object_id")
                .AsSet()
                .Not.LazyLoad()
                .ReadOnly();
            HasMany(table => table.CheckConstraints)
                .KeyColumn("parent_object_id")
                .AsSet()
                .Not.LazyLoad()
                .ReadOnly();
        }
    }
}