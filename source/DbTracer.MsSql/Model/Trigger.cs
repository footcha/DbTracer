namespace DbTracer.MsSql.Model
{
    public class Trigger : SqlObject, ICode
    {
        public virtual string Definition { get; set; }

        public virtual bool IsDisabled { get; set; }

        public virtual bool IsNotForReplication { get; set; }

        public virtual bool IsInsteadOfTrigger { get; set; }

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            return ModelUtils.Equals(this, that);
        }
    }
}