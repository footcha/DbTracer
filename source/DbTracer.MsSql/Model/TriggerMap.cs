using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class TriggerMap : SubclassMap<Trigger>
    {
        public TriggerMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.SqlDmlTrigger));
            Join("sys.triggers", t =>
            {
                t.KeyColumn("object_id");
                t.Map(trigger => trigger.Definition, "object_definition")
                    .Formula("OBJECT_DEFINITION(object_id)");
                t.Map(trigger => trigger.IsDisabled, "is_disabled");
                t.Map(trigger => trigger.IsNotForReplication, "is_not_for_replication");
                t.Map(trigger => trigger.IsInsteadOfTrigger, "is_instead_of_trigger");
            });
        }
    }
}