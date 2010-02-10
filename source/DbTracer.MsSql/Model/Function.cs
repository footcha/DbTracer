namespace DbTracer.MsSql.Model
{
    public class Function : SqlObject, ICode
    {
        public virtual string Definition { get; set; }
    }
}