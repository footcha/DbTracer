using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class CheckConstraintMap : SubclassMap<CheckConstraint>
    {
        public CheckConstraintMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.CheckConstraint));
            Join("sys.check_constraints", join =>
            {
                join.KeyColumn("object_id");
                join.Map(c => c.IsDisabled, "is_disabled");
                join.Map(c => c.IsNotForReplication, "is_not_for_replication");
                join.Map(c => c.IsNotTrusted, "is_not_trusted");
                join.Map(c => c.Definition, "definition");
                join.Map(c => c.UsesDatabaseCollation, "uses_database_collation");
                join.Map(c => c.IsSystemNamed, "is_system_named");
                join.References(c => c.ParentColumn)
                    .Columns("parent_column_id", "parent_object_id")
                    .Not.LazyLoad();
            });
        }
    }
}