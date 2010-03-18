using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.Test.SqlGenerator
{
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