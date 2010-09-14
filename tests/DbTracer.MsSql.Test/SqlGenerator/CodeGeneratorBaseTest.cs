using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public abstract class CodeGeneratorBaseTest<TGenerator, T> : GeneratorBaseTest<TGenerator, T>
        where T : ICode
        where TGenerator : IGenerator<T>
    {
        protected void ToCreateSqlTest(TGenerator testedGenerator, string expectedSql)
        {
            var generator = new GeneratorBuilder()
                .WithFullNameBuilder(FullNameBuilder)
                .WithKeyWordEncoder(KeyWordEncoder)
                .Build(testedGenerator);
            SqlAssert.AreSqlEqual(expectedSql, generator.ToCreateSql());
        }
    }
}