using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class ViewGeneratorTest : CodeGeneratorBaseTest<ViewGenerator, View>
    {
        [Test]
        public void CreateTest()
        {
            const string expectedSql = "CREATE VIEW [dbo].[test_view] AS  SELECT * FROM test_table";
            TestedObject = Mocks.Stub<View>();
            TestedObject.Definition = expectedSql;
            var testedGenerator = BuildGenerator(new ViewGenerator(TestedObject));
            ToCreateSqlTest(testedGenerator, expectedSql);
        }

        [Test]
        public void DropTest()
        {
            TestedObject = Mocks.Stub<View>();
            using (Mocks.Record())
            {
                TestedObject.Name = "test_view";
            }
            using (Mocks.Playback())
            {
                const string expectedSql = "DROP VIEW [test_view]";
                var testedGenerator = BuildGenerator(new ViewGenerator(TestedObject));
                Utils.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
            }
        }
    }
}