using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using MbUnit.Framework;
namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class FunctionGeneratorTest : CodeGeneratorBaseTest<FunctionGenerator, Function>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestedObject = Mocks.Stub<Function>();
            TestedObject.Name = "test_function";
            TestedObject.Definition = "CREATE FUNCTION [dbo].[test_function] AS RETURN 1";
            TestedGenerator = BuildGenerator(new FunctionGenerator(TestedObject));
        }

        [Test]
        public void CreateTest()
        {
            const string expectedSql = "CREATE FUNCTION [dbo].[test_function] AS RETURN 1";
            using (Mocks.Record()) { }
            using (Mocks.Playback())
            {
                ToCreateSqlTest(TestedGenerator, expectedSql);
            }
        }

        [Test]
        public void DropTest()
        {
            const string expectedSql = "DROP FUNCTION [test_function]";
            using (Mocks.Record()) { }
            using (Mocks.Playback())
            {
                Utils.AreSqlEqual(expectedSql, TestedGenerator.ToDropSql());
            }
        }
    }
}