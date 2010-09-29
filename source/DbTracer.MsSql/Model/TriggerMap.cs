using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class TriggerMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.JoinedSubclass<Trigger>(j =>
            {
                j.Key(k => k.Column("object_id"));
                j.Property(w => w.Type, m => m.Type<SqlObjectTypeMap>());
                j.Schema("sys");
                j.Table("triggers");
                j.Property(t => t.IsDisabled, m => m.Column("is_disabled"));
                j.Property(t => t.IsNotForReplication, m => m.Column("is_not_for_replication"));
                j.Property(t => t.IsInsteadOfTrigger, m => m.Column("is_instead_of_trigger"));
                j.Property(t => t.Definition, m => m.Formula("OBJECT_DEFINITION(object_id)"));
            });

            entities.Add(typeof(Trigger));
        }

        //    DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.SqlDmlTrigger));
    }
}