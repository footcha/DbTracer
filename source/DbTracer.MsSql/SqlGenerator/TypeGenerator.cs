using System;
using DbTracer.Core.Schema.SqlGenerator;
using Type = DbTracer.MsSql.Model.Type;

namespace DbTracer.MsSql.SqlGenerator
{
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms175007%28SQL.90%29.aspx"/>
    /// <see cref="http://msdn.microsoft.com/en-us/library/ms175007.aspx"/>
    public class TypeGenerator : GeneratorBase<Type>
    {
        public TypeGenerator(Type sourceObject)
            : base(sourceObject) { }

        public override string ToCreateSql()
        {
            var sb = new SqlBuilder();
            sb.AppendFormatLine("CREATE TYPE {0}", FullNameBuilder.BuildName(SourceObject));
            if (SourceObject.IsAssemblyType) AppendDefinitionForAssemblyType(sb);
            else AppendDefinitionForSimpleType(sb);

            return sb.ToString();
        }

        public override string ToDropSql()
        {
            return new SqlBuilder()
                .AppendFormat("DROP TYPE {0}", FullNameBuilder.BuildName(SourceObject))
                .ToString();
        }

        protected virtual void AppendDefinitionForSimpleType(SqlBuilder sqlBuilder)
        {
            sqlBuilder.AppendFormat("FROM {0}", KeywordEncoder.Encode(SourceObject.SystemType.Name));
            if (SourceObject.IsTypeOf("decimal", "numeric"))
            {
                sqlBuilder.AppendFormat("({0}, {1})", SourceObject.Precision.ToString(),
                                SourceObject.Scale.ToString());
            }
            else if (SourceObject.IsTypeOf("binary", "varbinary", "varchar", "char", "nchar", "nvarchar"))
            {
                sqlBuilder.AppendFormat("({0})", SourceObject.Scale.ToString());
            }
            sqlBuilder.Append(" ")
                .Append(Utils.GetNullableSql(SourceObject));
        }

        protected virtual void AppendDefinitionForAssemblyType(SqlBuilder sqlBuilder)
        {
            throw new NotSupportedException("Assembly types currently are not supported");
        }
    }
}