namespace DbTracer.MsSql.Model
{
    public class ColumnReference
    {
        public virtual Column Source { get; set; }
        public virtual Column Reference { get; set; }
    }
}