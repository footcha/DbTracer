using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class TriggerMap : SubclassMap<Trigger>
    {
        public TriggerMap()
        {
            Table("sys.triggers");
            KeyColumn("object_id");
            Map(trigger => trigger.Definition, "object_definition")
                .Formula("OBJECT_DEFINITION(object_id)");
            Map(trigger => trigger.IsDisabled, "is_disabled");
            Map(trigger => trigger.IsNotForReplication, "is_not_for_replication");
            Map(trigger => trigger.IsInsteadOfTrigger, "is_instead_of_trigger");
        }
    }
}