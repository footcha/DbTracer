using System.Text;
using DbTracer.Core.Schema.Model;
using DbTracer.Core.Schema.SqlGenerator;

namespace DbTracer.MsSql.SqlGenerator
{
    public class FullNameWithSchemaBuilder : IFullNameBuilder
    {
        public FullNameWithSchemaBuilder(KeywordEncoder keywordEncoder)
        {
            this.keywordEncoder = keywordEncoder;
        }

        private readonly KeywordEncoder keywordEncoder;

        public string BuildName(ISqlObject sqlObject)
        {
            var sb = new StringBuilder();
            var schemaMember = sqlObject as ISchemaMember;
            if (schemaMember != null)
            {
                sb.Append(GetSchemaNameSql(schemaMember))
                    .Append(".");
            }
            sb.Append(keywordEncoder.Encode(sqlObject.Name));

            return sb.ToString();
        }

        private string GetSchemaNameSql(ISchemaMember sqlObject)
        {
            return keywordEncoder.Encode(sqlObject.Schema.Name);
        }
    }
}