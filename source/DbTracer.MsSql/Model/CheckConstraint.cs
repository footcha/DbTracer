namespace DbTracer.MsSql.Model
{
    public class CheckConstraint : SqlObject, ICode
    {
        public virtual bool IsDisabled { get; set; }

        public virtual bool IsNotForReplication { get; set; }

        public virtual bool IsNotTrusted { get; set; }

        public virtual string Definition { get; set; }

        public virtual bool UsesDatabaseCollation { get; set; }

        public virtual bool IsSystemNamed { get; set; }

        public virtual Column ParentColumn { get; set; }
    }
}