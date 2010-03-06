namespace DbTracer.Core.Schema.SqlGenerator
{
    public interface IKeywordEncoder
    {
        string Encode(string text);
    }
}