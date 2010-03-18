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

        public override string ObjectNameKeyWord
        {
            get { return "TYPE"; }
        }

        public override string ToCreateSql()
        {
            var sb = new SqlBuilder();
            sb.AppendFormatLine("CREATE TYPE {0}", FullNameBuilder.BuildName(SourceObject));
            if (SourceObject.IsAssemblyType)
                AppendDefinitionForAssemblyType(sb);
            else
                AppendDefinitionForSimpleType(sb);

            return sb.ToString();
        }

        protected virtual void AppendDefinitionForSimpleType(SqlBuilder sqlBuilder)
        {
            sqlBuilder.AppendFormat("FROM {0}", KeywordEncoder.Encode(SourceObject.SystemType.Name));
            sqlBuilder.Append(ParametersToString(SourceObject));

            sqlBuilder.Append(" ")
                .Append(Utils.GetNullableSql(SourceObject));
        }

        protected virtual void AppendDefinitionForAssemblyType(SqlBuilder sqlBuilder)
        {
            throw new NotSupportedException("Assembly types currently are not supported");
        }

        public static string ParametersToString(Type type)
        {
            if (type.IsTypeOf("decimal") || type.IsTypeOf("numeric"))
                return string.Format("({0}, {1})", type.Precision, type.Scale);
            if (type.IsTypeOf("nchar") || type.IsTypeOf("nvarchar"))
                return string.Format("({0})", type.MaxLength / 2);
            return type.IsTypeOf("binary") || type.IsTypeOf("varbinary") || type.IsTypeOf("varchar") || type.IsTypeOf("char")
                ? string.Format("({0})", type.MaxLength)
                : "";
        }
    }
}