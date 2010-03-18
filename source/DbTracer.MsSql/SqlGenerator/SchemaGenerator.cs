using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class SchemaGenerator : GeneratorBase<Schema>
    {
        public SchemaGenerator(Schema sourceObject)
            : base(sourceObject) { }

        public override string ObjectNameKeyWord
        {
            get { return "SCHEMA"; }
        }

        public override string ToCreateSql()
        {
            var sql = string.Format("CREATE {0} {1}",
                ObjectNameKeyWord,
                KeywordEncoder.Encode(SourceObject.Name));
            if (GenerateAuthorization)
            {
                sql += " AUTHORIZATION " + KeywordEncoder.Encode(SourceObject.Principal.Name);
            }
            return sql;
        }

        public virtual bool GenerateAuthorization { get; set; }
    }
}