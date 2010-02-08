namespace DbTracer.MsSql.Model
{
    public class TriggerMap : SqlClassMap<Trigger>
    {
        protected override string TableName
        {
            get { return "sys.objects"; }
        }

        protected override void Configure()
        {
            ConfigureDatabaseObject(this);
            Where("type='TR'");
            Join("sys.triggers",
                joinPart =>
                {
                    joinPart.KeyColumn("object_id")
                        .Map(trigger => trigger.Definition, "object_definition")
                        .Formula("OBJECT_DEFINITION(object_id)");
                    joinPart.Map(trigger => trigger.IsDisabled, "is_disabled");
                    joinPart.Map(trigger => trigger.IsNotForReplication, "is_not_for_replication");
                    joinPart.Map(trigger => trigger.IsInsteadOfTrigger, "is_instead_of_trigger");
                }
            );
        }
    }
}