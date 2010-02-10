using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class CheckConstraintMap : SubclassMap<CheckConstraint>
    {
        public CheckConstraintMap()
        {
            Table("sys.check_constraints");
            KeyColumn("object_id");
            Map(constraint => constraint.IsDisabled, "is_disabled");
            Map(constraint => constraint.IsNotForReplication, "is_not_for_replication");
            Map(constraint => constraint.IsNotTrusted, "is_not_trusted");
            Map(constraint => constraint.Definition, "definition");
            Map(constraint => constraint.UsesDatabaseCollation, "uses_database_collation");
            Map(constraint => constraint.IsSystemNamed, "is_system_named");
            References(constraint => constraint.Table)
                .Column("parent_object_id");
            References(constraint => constraint.ParentColumn)
                .Columns("parent_column_id", "parent_object_id")
                .NotFound.Ignore();
        }
    }
}