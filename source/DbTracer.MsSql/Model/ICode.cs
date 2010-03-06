using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public interface ICode : ISqlObject
    {
        string Definition { get; }
    }
}