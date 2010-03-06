using DbTracer.Core.Schema.Model;

namespace DbTracer.Core.Schema.SqlGenerator
{
    public interface IFullNameBuilder
    {
        string BuildName(ISqlObject sqlObject);
    }
}