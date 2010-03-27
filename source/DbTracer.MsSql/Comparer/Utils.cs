using System;
using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using SqlBuilder=DbTracer.Core.Schema.Comparer.SqlBuilder;

namespace DbTracer.MsSql.Comparer
{
    public static class Utils
    {
        public static SqlBuilder CreateSqlBuilderForCodeSqlObject<T>(T source, T destination, IGenerator<T> sourceGenerator, IGenerator<T> destinationGenerator)
            where T : class, ICode
        {
            Func<string> buildFunc = () =>
            {
                var sqlBuilder =
                    new SqlScriptBuilderForCodeSqlObject<T>(source, destination)
                    {
                        SourceGenerator = sourceGenerator,
                        DestinationGenerator = destinationGenerator
                    };
                return sqlBuilder.ToSql();
            };

            return new SqlBuilder(buildFunc);
        }
    }
}