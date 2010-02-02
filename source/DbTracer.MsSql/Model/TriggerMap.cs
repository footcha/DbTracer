namespace DbTracer.MsSql.Model
{
    public class TriggerMap : SqlClassMap<Trigger>
    {
        protected override string TableName
        {
            get { return "sys.triggers"; }
        }

        protected override void Configure()
        {
            ConfigureBasic(this);
            ConfigureCode(this);
            Map(trigger => trigger.IsDisabled, "is_disabled");
            Map(trigger => trigger.IsNotForReplication, "is_not_for_replication");
            Map(trigger => trigger.IsInsteadOfTrigger, "is_instead_of_trigger");
        }
    }
}