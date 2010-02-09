namespace DbTracer.MsSql.Model
{
    public class CheckConstraintMap : SqlClassMap<CheckConstraint>
    {
        protected override string TableName
        {
            get { return "sys.check_constraints"; }
        }

        protected override void Configure()
        {
            ConfigureDatabaseObject(this);
            Map(constraint => constraint.IsDisabled, "is_disabled");
            Map(constraint => constraint.IsNotForReplication, "is_not_for_replication");
            Map(constraint => constraint.IsNotTrusted, "is_not_trusted");
            Map(constraint => constraint.Definition, "definition");
            Map(constraint => constraint.UsesDatabaseCollation, "uses_database_collation");
            Map(constraint => constraint.IsSystemNamed, "is_system_named");
            References(constraint => constraint.Table)
                .Column("parent_object_id");
            References(constraint => constraint.ParentColumn)
                .Columns("parent_object_id", "parent_column_id")
                .NotFound.Ignore();
        }
    }
}