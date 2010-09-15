using DbTracer.MsSql.Model;
using DbTracer.MsSql.Test.TestingUtils;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class TriggerMapTest : SqlObjectTest<Trigger>, ICodeTest
    {
        private Trigger trigger;
        private Table expectedTable;

        [FixtureSetUp]
        public void FixtureSetUp()
        {
            using (var session = SessionFactory.OpenSession())
            {
                trigger = session.CreateCriteria<Trigger>()
                    .Add(Restrictions.Eq("Name", "test_trigger"))
                    .UniqueResult<Trigger>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
            }
        }

        [Test,
        Row("IsDisabled", true),
        Row("IsNotForReplication", false),
        Row("IsInsteadOfTrigger", false),
        ]
        public void CheckProperty(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, trigger);
        }

        [Test]
        public void CheckDefinition()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, trigger.Definition);
        }

        protected override Trigger ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                var trigger = new TriggerBuilder()
                    .With(expectedTable)
                    .With(schema)
                    .Build();
                trigger.Name = "test_trigger";
                trigger.IsDisabled = true;
                trigger.IsMsShipped = false;
                trigger.IsPublished = false;
                trigger.IsSchemaPublished = false;
                trigger.IsNotForReplication = false;
                trigger.IsInsteadOfTrigger = false;
                trigger.Definition =
                    "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END";
                return trigger;
            }
        }

        protected override Trigger TestedObject
        {
            get { return trigger; }
        }
    }
}