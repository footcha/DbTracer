using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using DbTracer.MsSql.Test.TestingUtils;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class TriggerGeneratorTest : CodeGeneratorBaseTest<TriggerGenerator, Trigger>
    {
        private TriggerGenerator testedGenerator;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestedObject = new TriggerBuilder().Build();
            testedGenerator = BuildGenerator(new TriggerGenerator(TestedObject));
        }

        [Test]
        public void CreateSql()
        {
            const string expectedSql = "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END";
            ToCreateSqlTest(testedGenerator, expectedSql);
        }

        [Test]
        public void DropSql()
        {
            const string expectedSql = "DROP TRIGGER [test_trigger]";
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
        }

        [Test]
        public void DropDdlTrigger()
        {
            TestedObject.ParentObject = null;
            const string expectedSql = "DROP TRIGGER [test_trigger] ON DATABASE";
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
        }
    }
}