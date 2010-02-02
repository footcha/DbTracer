using System.Linq;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class TriggerMapTest : ASqlObjectTestBase, ICodeTest
    {
        private Trigger trigger;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var triggers = session.CreateCriteria<Trigger>().List<Trigger>();
                trigger = (from t in triggers where t.Name == "test_trigger" select t).First();
            }
        }

        [RowTest,
        Row("Name", "test_trigger"),
        Row("IsDisabled", false),
        Row("IsNotForReplication", false),
        Row("IsInsteadOfTrigger", false),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, trigger);
        }

        [Test]
        public void DefinitionTest()
        {
            const string expectedDefinition = "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END";
            TestUtils.TestSqlObjectDefinition(expectedDefinition, trigger.Definition);
        }
    }
}