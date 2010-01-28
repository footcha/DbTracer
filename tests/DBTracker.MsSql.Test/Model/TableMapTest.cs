using System.Linq;
using DbTracker.MsSql.Model;
using MbUnit.Framework;
using NHibernate;
using NHibernate.Criterion;

namespace DbTracker.MsSql.Test.Model
{
    [TestFixture]
    public class TableMapTest : ASqlObjectTestBase
    {
        private Table table;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                table = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
            }
        }

        [RowTest,
        Row("Name", "test_table"),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, table);
        }

        [Test]
        public void TriggersTest()
        {
            Assert.AreEqual(1, table.Triggers.Count);
            var testedTrigger = (from t in table.Triggers select t.Value).First();
            using (var session = SessionFactory.OpenSession())
            {
                var testingTrigger = session.CreateCriteria<Trigger>()
                    .Add(Restrictions.Eq("Name", "test_trigger"))
                    .UniqueResult<Trigger>();
                Assert.AreEqual(testingTrigger, testedTrigger);
            }
        }

        [Test]
        public void IndexesTest()
        {
            Assert.AreEqual(2, table.Indexes.Count);
            var testedIndexPk = (from index in table.Indexes where index.Name == "PK_test_table" select index).First();
            var testedIndexIx = (from index in table.Indexes where index.Name == "IX_test" select index).First();
            using (var session = SessionFactory.OpenSession())
            {
                var testingIndexPk = GetIndexByName("PK_test_table", session);
                var testingIndexIx = GetIndexByName("IX_test", session);
                Assert.AreEqual(testingIndexPk, testedIndexPk);
                Assert.AreEqual(testingIndexIx, testedIndexIx);
            }
        }

        private static Index GetIndexByName(string indexName, ISession session)
        {
            return session.CreateCriteria<Index>()
                .Add(Restrictions.Eq("Name", indexName))
                .UniqueResult<Index>();
        }
    }
}