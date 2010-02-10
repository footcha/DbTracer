using System.Linq;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class TriggerMapTest : SqlObjectTest<Trigger>, ICodeTest
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
        Row("IsDisabled", true),
        Row("IsNotForReplication", false),
        Row("IsInsteadOfTrigger", false),
        ]
        public void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, trigger);
        }

        [Test]
        public void DefinitionTest()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, trigger.Definition);
        }

        protected override Trigger ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                return new Trigger
                {
                    Name = "test_trigger",
                    IsDisabled = true,
                    IsNotForReplication = false,
                    IsInsteadOfTrigger = false,
                    Schema = schema,
                    Type = SqlObjectType.SqlDmlTrigger,
                    Definition = "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END"
                };
            }
        }

        protected override Trigger TestedObject
        {
            get { return trigger; }
        }
    }
}