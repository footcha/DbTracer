using System.Linq;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class TriggerMapTest : SqlObjectTest<Trigger>, ICodeTest
    {
        private Trigger trigger;
        private Table expectedTable;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var triggers = session.CreateCriteria<Trigger>().List<Trigger>();
                trigger = (from t in triggers where t.Name == "test_trigger" select t).First();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
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
                    Definition = "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END",
                    ParentObject = expectedTable
                };
            }
        }

        protected override Trigger TestedObject
        {
            get { return trigger; }
        }
    }
}