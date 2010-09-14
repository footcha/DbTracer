using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using MbUnit.Framework;
using Rhino.Mocks;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class FunctionGeneratorTest : CodeGeneratorBaseTest<FunctionGenerator, Function>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestedObject = new Function
            {
                Name = "test_function",
                Definition = "CREATE FUNCTION [dbo].[test_function] AS RETURN 1",
                Schema = new Schema
                {
                    Name = "test_schema"
                }
            };
            TestedGenerator = BuildGenerator(new FunctionGenerator(TestedObject));
            Mocks.ReplayAll();
        }

        [Test]
        public void CreateTest()
        {
            const string expectedSql = "CREATE FUNCTION [dbo].[test_function] AS RETURN 1";
            ToCreateSqlTest(TestedGenerator, expectedSql);
        }

        [Test]
        public void DropTest()
        {
            const string expectedSql = "DROP FUNCTION [test_function]";
            SqlAssert.AreSqlEqual(expectedSql, TestedGenerator.ToDropSql());
        }

        [Test,
        Ignore("Neither function nor other code generators implement properly schema name")]
        public void CreateWithNameIncludingSchema()
        {
            using (Mocks.Record())
            {
                var fullNameBuilder = Mocks.DynamicMock<IFullNameBuilder>();
                Expect.Call(fullNameBuilder.BuildName(TestedObject))
                    .Return(string.Format("[{0}].[{1}]", TestedObject.Schema.Name, TestedObject.Name));
                TestedGenerator.FullNameBuilder = fullNameBuilder;
            }
            const string expectedSql = "CREATE FUNCTION [test_schema].[test_function] AS RETURN 1";
            ToCreateSqlTest(TestedGenerator, expectedSql);
        }
    }
}