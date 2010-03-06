using DbTracer.Core.Schema.SqlGenerator;

namespace DbTracer.MsSql.SqlGenerator
{
    public class KeywordEncoder : IKeywordEncoder
    {
        public string Encode(string text)
        {
            return string.Format("[{0}]", text);
        }
    }
}