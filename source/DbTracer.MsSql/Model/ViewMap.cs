using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class ViewMap : SubclassMap<View>
    {
        public ViewMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.View));
            Join("sys.views", join =>
            {
                join.KeyColumn("object_id");
                join.Map(t => t.IsReplicated, "is_replicated");
                join.Map(t => t.HasReplicationFilter, "has_replication_filter");
                join.Map(t => t.HasOpaqueMetadata, "has_opaque_metadata");
                join.Map(t => t.HasUncheckedAssemblyData, "has_unchecked_assembly_data");
                join.Map(t => t.WithCheckOption, "with_check_option");
                join.Map(t => t.IsDateCorrelationView, "is_date_correlation_view");
            });
            HasMany(view => view.Triggers)
                .KeyColumn("parent_object_id")
                .AsSet()
                .Not.LazyLoad()
                .ReadOnly();
            SqlClassMap<View>.ConfigureCode(this);
        }
    }
}