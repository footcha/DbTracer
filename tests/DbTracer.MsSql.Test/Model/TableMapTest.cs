using System;
using System.Linq;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class TableMapTest : SqlObjectTest<Table>
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

        protected override Table ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                var tableLocal = CreateObject(
                    DateTime.MinValue, false, false, false, DateTime.MinValue,
                    "test_table", null, 0, schema, SqlObjectType.TableUserDefined
                    );
                tableLocal.Columns.Add(new Column { Id = 1, Name = "id" });
                tableLocal.Columns.Add(new Column { Id = 2, Name = "test" });

                return tableLocal;
            }
        }

        protected override Table TestedObject
        {
            get { return table; }
        }

        [RowTest,
         Row("LobDataSpaceId", 0),
         Row("LockOnBulkLoad", false),
         Row("UsesAnsiNulls", true),
         Row("IsReplicated", false),
         Row("HasReplicationFilter", false),
         Row("IsMergePublished", false),
         Row("IsSyncTranSubscribed", false),
         Row("HasUncheckedAssemblyData", false),
         Row("TextInRowLimit", 0),
         Row("LargeValueTypesOutOfRow", false),
        ]
        public void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, TestedObject);
        }

        [Test]
        public void ColumnsTest()
        {
            Assert.AreEqual(ExpectedObject.Columns.Count, table.Columns.Count);
            var expectedIterator = ExpectedObject.Columns.GetEnumerator();
            var testedIterator = table.Columns.GetEnumerator();
            while (expectedIterator.MoveNext())
            {
                testedIterator.MoveNext();
                var expectedColumn = expectedIterator.Current;
                var testedColumn = testedIterator.Current;
                Assert.AreEqual(expectedColumn.Name, testedColumn.Name);
            }
        }

        [Test]
        public void TriggersTest()
        {
            Assert.AreEqual(1, table.Triggers.Count);
            var testedTrigger = (from t in table.Triggers select t).First();
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var expectedTrigger = session.CreateCriteria<Trigger>()
                    .Add(Restrictions.Eq("Name", "test_trigger"))
                    .UniqueResult<Trigger>();
                Assert.AreEqual(expectedTrigger, testedTrigger);
            }
        }

        [Test]
        public void ConstraintsTest()
        {
            Assert.AreEqual(2, table.CheckConstraints.Count);
            var constraints = table.CheckConstraints.ToList();
            Assert.AreEqual("CK_test_table", constraints[0].Name);
            Assert.AreEqual("CK_test_table_2", constraints[1].Name);
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