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

        public virtual Table Table
        {
            get { return (Table)ParentObject; }
            set { ParentObject = value; }
        }

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            return ModelUtils.Equals(this, that);
        }
    }
}