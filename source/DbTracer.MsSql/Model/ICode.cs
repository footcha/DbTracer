namespace DbTracer.MsSql.Model
{
    public interface ICode : ISqlObject
    {
        string Definition { get; }
    }
}