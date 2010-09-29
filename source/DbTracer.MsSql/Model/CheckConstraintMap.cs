using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class CheckConstraintMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.JoinedSubclass<CheckConstraint>(j =>
            {
                j.Key(k => k.Column("object_id"));
                j.Property(w => w.Type, m => m.Type<SqlObjectTypeMap>());
                j.Schema("sys");
                j.Table("check_constraints");
                j.Property(t => t.IsDisabled, m => m.Column("is_disabled"));
                j.Property(t => t.IsNotForReplication, m => m.Column("is_not_for_replication"));
                j.Property(t => t.IsNotTrusted, m => m.Column("is_not_trusted"));
                j.Property(t => t.Definition, m => m.Column("definition"));
                j.Property(t => t.UsesDatabaseCollation, m => m.Column("uses_database_collation"));
                j.Property(t => t.IsSystemNamed, m => m.Column("is_system_named"));
                //j.ManyToOne(e => e.ParentColumn, m => m.Columns(
                //    c => c.Name("parent_object_id"),
                //    c => c.Name("parent_column_id")
                //    ));
            });

            orm.ExcludeProperty<CheckConstraint>(c =>c.ParentColumn);
            entities.Add(typeof(CheckConstraint));
        }

        //public CheckConstraintMap()
        //{
        //    DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.CheckConstraint));
        //    Join("sys.check_constraints", join =>
        //    {
        //        join.KeyColumn("object_id");
        //        join.Map(c => c.IsDisabled, "is_disabled");
        //        join.Map(c => c.IsNotForReplication, "is_not_for_replication");
        //        join.Map(c => c.IsNotTrusted, "is_not_trusted");
        //        join.Map(c => c.Definition, "definition");
        //        join.Map(c => c.UsesDatabaseCollation, "uses_database_collation");
        //        join.Map(c => c.IsSystemNamed, "is_system_named");
        //        join.References(c => c.ParentColumn)
        //            .Columns("parent_object_id", "parent_column_id")
        //            .Not.LazyLoad();
        //    });
        //}
    }
}