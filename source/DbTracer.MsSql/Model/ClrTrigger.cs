namespace DbTracer.MsSql.Model
{
    public class ClrTrigger : ClrCode
    {
        public ClrTrigger()
            : base(ObjectType1.ClrTrigger, ScripActionType.AddTrigger, ScripActionType.DropTrigger)
        { }

        public bool IsUpdate { get; set; }

        public bool IsInsert { get; set; }

        public bool IsDelete { get; set; }
    }
}