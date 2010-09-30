using System.Collections.Generic;
using ConfOrm;
using ConfOrm.Mappers;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class TableMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.JoinedSubclass<Table>(j =>
            {
                j.Key(k => k.Column("object_id"));
                j.Property(w => w.Type, m => m.Type<SqlObjectTypeMap>());
                j.Schema("sys");
                j.Table("tables");
                j.Property(t => t.IsReplicated, m => m.Column("is_replicated"));
                j.Property(t => t.HasReplicationFilter, m => m.Column("has_replication_filter"));
                j.Property(t => t.HasUncheckedAssemblyData, m => m.Column("has_unchecked_assembly_data"));
                j.Property(t => t.LobDataSpaceId, m => m.Column("lob_data_space_id"));
                j.Property(t => t.LockOnBulkLoad, m => m.Column("lock_on_bulk_load"));
                j.Property(t => t.UsesAnsiNulls, m => m.Column("uses_ansi_nulls"));
                j.Property(t => t.IsMergePublished, m => m.Column("is_merge_published"));
                j.Property(t => t.IsSyncTranSubscribed, m => m.Column("is_sync_tran_subscribed"));
                j.Property(t => t.TextInRowLimit, m => m.Column("text_in_row_limit"));
                j.Property(t => t.LargeValueTypesOutOfRow, m => m.Column("large_value_types_out_of_row"));
                j.Set(w => w.Triggers,
                    m =>
                    {
                        m.Key(k => k.Column("parent_id"));
                        m.Lazy(CollectionLazy.NoLazy);
                    },
                    r => r.OneToMany(mm => mm.NotFound(NotFoundMode.Ignore)));
                j.Set(w => w.CheckConstraints,
                    m =>
                    {
                        m.Key(k => k.Column("parent_object_id"));
                        m.Lazy(CollectionLazy.NoLazy);
                    },
                    r => r.OneToMany(mm => mm.NotFound(NotFoundMode.Ignore)));
                j.Set(w => w.Columns,
                    m =>
                    {
                        m.Key(k => k.Column("object_id"));
                        m.Lazy(CollectionLazy.NoLazy);
                    },
                    r => r.OneToMany(mm => mm.NotFound(NotFoundMode.Ignore)));
            });

            orm.ExcludeProperty<Table>(t => t.Columns);
            orm.ExcludeProperty<Table>(t => t.Indexes);
            entities.Add(typeof(Table));
        }

        //public TableMap()
        //{
        //    DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.TableUserDefined));
        //    HasMany(table => table.Columns)
        //        .KeyColumn("object_id")
        //        .AsSet()
        //        .Not.LazyLoad()
        //        .ReadOnly();
        //    HasMany(table => table.Indexes)
        //        .KeyColumn("object_id")
        //        .AsSet()
        //        .Not.LazyLoad()
        //        .ReadOnly();
        //}
    }
}