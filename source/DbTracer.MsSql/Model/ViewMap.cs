using System.Collections.Generic;
using ConfOrm;
using ConfOrm.Mappers;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class ViewMap
    {
        //    DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.View));

        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.JoinedSubclass<View>(j =>
            {
                j.Key(k => k.Column("object_id"));
                j.Property(w => w.Type, m => m.Type<SqlObjectTypeMap>());
                j.Schema("sys");
                j.Table("views");
                j.Property(t => t.IsReplicated, m => m.Column("is_replicated"));
                j.Property(t => t.HasReplicationFilter, m => m.Column("has_replication_filter"));
                j.Property(t => t.HasOpaqueMetadata, m => m.Column("has_opaque_metadata"));
                j.Property(t => t.HasUncheckedAssemblyData, m => m.Column("has_unchecked_assembly_data"));
                j.Property(t => t.WithCheckOption, m => m.Column("with_check_option"));
                j.Property(t => t.IsDateCorrelationView, m => m.Column("is_date_correlation_view"));
                j.Property(t => t.Definition, m => m.Formula("OBJECT_DEFINITION(object_id)"));
                j.Set(w => w.Triggers,
                    m =>
                    {
                        m.Key(k => k.Column("parent_id"));
                        m.Lazy(CollectionLazy.NoLazy);
                    },
                    r => r.OneToMany(mm => mm.NotFound(NotFoundMode.Ignore)));
            });

            entities.Add(typeof(View));
        }
    }
}