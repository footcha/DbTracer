using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public abstract class CodeGeneratorBaseTest<T> : GeneratorBaseTest<T>
        where T : ICode
    {
        protected void ToCreateSqlTest(IGenerator<T> testedGenerator, string expectedSql)
        {
            using (Mocks.Record()) { }
            using (Mocks.Playback())
            {
                Utils.AreSqlEqual(expectedSql, BuildGenerator(testedGenerator).ToCreateSql());
            }
        }
    }
}