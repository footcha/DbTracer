using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class ViewGeneratorTest : CodeGeneratorBaseTest<ViewGenerator, View>
    {
        [Test]
        public void CreateSql()
        {
            const string expectedSql = "CREATE VIEW [dbo].[test_view] AS  SELECT * FROM test_table";
            TestedObject = new View
            {
                Definition = expectedSql
            };
            var testedGenerator = BuildGenerator(new ViewGenerator(TestedObject));
            ToCreateSqlTest(testedGenerator, expectedSql);
        }

        [Test]
        public void DropSql()
        {
            TestedObject = new View
            {
                Name = "test_view"
            };
            const string expectedSql = "DROP VIEW [test_view]";
            var testedGenerator = BuildGenerator(new ViewGenerator(TestedObject));
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
        }
    }
}