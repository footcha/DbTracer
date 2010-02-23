namespace DbTracer.MsSql.Model
{
    public class DefaultConstraint : SqlObject, ICode
    {
        public virtual Column Column { get; set; }

        public virtual string Definition { get; set; }

        public virtual bool IsSystemNamed { get; set; }
    }
}