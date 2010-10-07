using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class DefaultConstraintMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.JoinedSubclass<DefaultConstraint>(j =>
            {
                j.Schema("sys");
                j.Table("default_constraints");
                j.Property(w => w.Type, m => m.Type<SqlObjectTypeMap>());
                j.Key(k => k.Column("object_id"));
                j.Property(e => e.Definition, m => m.Column("definition"));
                j.Property(e => e.IsSystemNamed, m => m.Column("is_system_named"));
                j.ManyToOne(e => e.Column, m => m.Columns(x => x.Name("parent_object_id"), x => x.Name("parent_column_id")));
            });

            orm.ExcludeProperty<DefaultConstraint>(c => c.Column);
            entities.Add(typeof(DefaultConstraint));
        }

        //public DefaultConstraintMap()
        //{
        //    DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.DefaultConstraint));
        //    Join("sys.default_constraints", t =>
        //    {
        //        t.KeyColumn("object_id");
        //        t.Map(obj => obj.Definition, "definition");
        //        t.Map(obj => obj.IsSystemNamed, "is_system_named");
        //    });
        //}
    }
}