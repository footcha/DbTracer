namespace DbTracer.MsSql.Model
{
    public class Function : ICode
    {
        public virtual int Id { get; set; }

        public virtual string Definition { get; set; }

        public virtual string Name { get; set; }

        public virtual SqlObjectType Type { get; set; }
    }
}