namespace DbTracer.MsSql.Model
{
    public class Trigger : SqlObject, ICode
    {
        public virtual string Definition { get; set; }

        public virtual bool IsDisabled { get; set; }

        public virtual bool IsNotForReplication { get; set; }

        public virtual bool IsInsteadOfTrigger { get; set; }

        // TODO parent object property (either table or view)

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            if (Id == 0) return false;
            var thatTrigger = that as Trigger;
            return thatTrigger != null && Equals(Id, thatTrigger.Id);
        }
    }
}