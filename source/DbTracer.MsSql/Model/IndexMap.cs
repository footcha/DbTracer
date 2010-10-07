using System.Collections.Generic;
using ConfOrm;
using ConfOrm.Mappers;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class IndexMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.Class<Index>(c =>
            {
                c.Schema("sys");
                c.Table("indexes");
                c.Id(p => p.Id, m => m.Column("index_id"));
                c.Property(p => p.Name, m => m.Column("name"));
                c.Property(p => p.IndexType, m =>
                                             {
                                                 m.Column("type");
                                                 m.Type<IndexTypeMap>();
                                             });
                c.Property(p => p.IsUnique, m => m.Column("is_unique"));
                c.Property(p => p.IgnoreDuplicityKey, m => m.Column("ignore_dup_key"));
                c.Property(p => p.IsPrimaryKey, m => m.Column("is_primary_key"));
                c.Property(p => p.IsUniqueConstraint, m => m.Column("is_unique_constraint"));
                c.Property(p => p.FillFactor, m => m.Column("fill_factor"));
                c.Property(p => p.IsPadded, m => m.Column("is_padded"));
                c.Property(p => p.IsDisabled, m => m.Column("is_disabled"));
                c.Property(p => p.IsHypothetical, m => m.Column("is_hypothetical"));
                c.Property(p => p.AllowRowLocks, m => m.Column("allow_row_locks"));
                c.Property(p => p.AllowPageLocks, m => m.Column("allow_page_locks"));
                c.ManyToOne(p => p.ParentObject, m => m.Column("object_id"));
                c.Set(p => p.IndexColumns,
                    m =>
                    {
                        m.Schema("sys");
                        m.Table("index_columns");
                        m.OrderBy(o => o.KeyOrdinal);
                        m.Key(k => k.Column("object_id"));
                        m.Key(k => k.Column("index_id"));
                        m.Lazy(CollectionLazy.NoLazy);
                    },
                    r =>
                    {
                        r.Component(co =>
                        {
                            //co.Columns(cc => cc.Name("key_ordinal"), cc => cc.Name("partition_ordinal"));
                            co.Property(p => p.KeyOrdinal, m => m.Column("key_ordinal"));
                            co.Property(p => p.PartitionOrdinal, m => m.Column("partition_ordinal"));
                        });
                        r.OneToMany(mm => mm.NotFound(NotFoundMode.Ignore));
                    });
            });

            mapper.Component<IndexColumn>(c =>
            {
                c.Property(p => p.KeyOrdinal, m => m.Column("key_ordinal"));
                c.Property(p => p.PartitionOrdinal, m => m.Column("partition_ordinal"));
                c.Property(p => p.IsDescendingKey, m => m.Column("is_descending_key"));
                c.Property(p => p.IsIncludedColumn, m => m.Column("is_included_column"));
                c.ManyToOne(p => p.Column, m => m.Columns(cc => cc.Name("object_id"), cc => cc.Name("column_id")));
            });

            //orm.ExcludeProperty<Index>(p => p.IndexColumns);
            //orm.ExcludeProperty<IndexColumn>(p => p.Column);
            //orm.ExcludeProperty<IndexColumn>(p => p.IsDescendingKey);
            //orm.ExcludeProperty<IndexColumn>(p => p.IsIncludedColumn);
            //orm.ExcludeProperty<IndexColumn>(p => p.PartitionOrdinal);
            //orm.ExcludeProperty<IndexColumn>(p => p.KeyOrdinal);
            orm.ExcludeProperty<Index>(p => p.ObjectId);
            orm.TablePerClass<Index>();
            orm.Component<IndexColumn>();
            orm.NaturalId<Index>(p => p.ParentObject, p => p.Id);
            entities.Add(typeof(Index));
            entities.Add(typeof(IndexColumn));
        }
    }
}