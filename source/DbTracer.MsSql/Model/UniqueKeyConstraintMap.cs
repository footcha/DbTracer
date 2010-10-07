using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class UniqueKeyConstraintMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.JoinedSubclass<UniqueKeyConstraint>(j =>
            {
                j.Schema("sys");
                j.Table("key_constraints");
                j.Key(m => m.Column("object_id"));
            });

            orm.ExcludeProperty<UniqueKeyConstraint>(p => p.Index);
            entities.Add(typeof(UniqueKeyConstraint));
        }
    }
}