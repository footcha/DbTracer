using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using DbTracer.MsSql.Test.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class TriggerGeneratorTest : CodeGeneratorBaseTest<TriggerGenerator, Trigger>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestedObject = TriggerMapTest.TestingObject;
        }

        [Test]
        public void CreateTest()
        {
            const string expectedSql = "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END";
            var testedGenerator = BuildGenerator(new TriggerGenerator(TestedObject));
            ToCreateSqlTest(testedGenerator, expectedSql);
        }

        [Test]
        public void DropTest()
        {
            using (Mocks.Record()) { }
            using (Mocks.Playback())
            {
                const string expectedSql = "DROP TRIGGER [test_trigger]";
                var testedGenerator = BuildGenerator(new TriggerGenerator(TestedObject));
                Utils.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
            }
        }

        [Test]
        public void DropDdlTriggerTest()
        {
            TestedObject = Mocks.Stub<Trigger>();
            using (Mocks.Record())
            {
                TestedObject.Name = "test_trigger";
            }
            using (Mocks.Playback())
            {
                const string expectedSql = "DROP TRIGGER [test_trigger] ON DATABASE";
                var testedGenerator = BuildGenerator(new TriggerGenerator(TestedObject));
                Utils.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
            }
        }
    }
}