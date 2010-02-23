namespace DbTracer.MsSql.Model
{
    public class KeyConstraint : SqlObject
    {
        public virtual bool IsSystemNamed { get; set; }

        public virtual Index Index { get; set; }
    }
}