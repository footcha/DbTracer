using DbTracer.MsSql.Model;
using MbUnit.Framework;
using System.Linq;
using NHibernate;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class IndexMapTest : ASqlObjectTestBase
    {
        private Index testedObject;
        private Table expectedTable;
        private ISession session;

        [FixtureSetUp]
        public void FixtureSetUp()
        {
            session = SessionFactory.OpenSession();
            testedObject = session.QueryOver<Index>()
                .And(r => r.Name == "PK_test_table")
                .SingleOrDefault();
            expectedTable = session.QueryOver<Table>()
                .And(r => r.Name == "test_table")
                .SingleOrDefault();
        }

        [FixtureTearDown]
        public void TearDown()
        {
            session.Dispose();
        }

        [Test,
        Row("Id", 1),
        Row("Name", "PK_test_table"),
        Row("IsUnique", true),
        Row("IgnoreDuplicityKey", false),
        Row("IsPrimaryKey", true),
        Row("IsUniqueConstraint", false),
        Row("FillFactor", 0),
        Row("IsPadded", false),
        Row("IsDisabled", false),
        Row("IsHypothetical", false),
        Row("AllowRowLocks", true),
        Row("AllowPageLocks", true),
        ]
        public override void CheckProperty(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, testedObject);
        }

        [Test]
        public void CheckIndexType()
        {
            Assert.AreEqual(IndexType.Clustered, testedObject.IndexType);
        }

        [Test]
        public void CheckParentObject()
        {
            Assert.IsNotNull(testedObject.ParentObject);
            Assert.AreEqual(expectedTable, testedObject.ParentObject);
            //Assert.AreSame(expectedTable, testedObject.ParentObject); // not working
        }

        [Test,
        Row("id", 0, 0, false, false),
        Row("test2", 1, 0, true, false),
        Row("test", 2, 0, false, false),
        ]
        public void CheckColumns(string columnName, int columnIndex,
            int partitionOrdinal, bool isDescendingKey, bool isIncludedColumn)
        {
            Assert.AreEqual(3, testedObject.IndexColumns.Count);
            var indexColumn = testedObject.IndexColumns.ToList()[columnIndex];
            var keyOrdinal = columnIndex + 1;
            Assert.AreEqual(columnName, indexColumn.Column.Name);
            Assert.AreEqual(keyOrdinal, indexColumn.KeyOrdinal);
            Assert.AreEqual(partitionOrdinal, indexColumn.PartitionOrdinal);
            Assert.AreEqual(isDescendingKey, indexColumn.IsDescendingKey);
            Assert.AreEqual(isIncludedColumn, indexColumn.IsIncludedColumn);
        }
    }
}