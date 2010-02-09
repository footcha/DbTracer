namespace DbTracer.MsSql.Model
{
    public class CheckConstraint : AObjectBase, ICode
    {
        public virtual bool IsDisabled { get; set; }

        public virtual bool IsNotForReplication { get; set; }

        public virtual bool IsNotTrusted { get; set; }

        public virtual string Definition { get; set; }

        public virtual bool UsesDatabaseCollation { get; set; }

        public virtual bool IsSystemNamed { get; set; }

        public virtual Column ParentColumn { get; set; }

        public virtual Table Table { get; set; }

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            if (Id == 0) return false;
            var thatConstraint = that as CheckConstraint;
            return thatConstraint != null && Equals(Id, thatConstraint.Id);
        }
    }
}